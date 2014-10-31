using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Text;
using LuaInterface;
using System.Text.RegularExpressions;

/// <summary>
/// author:ricky蒲
/// QQ:32145628
/// </summary>
public class ToLuaCSEditor
{

    private const string OutLuaPath = "Plugin/ToLuaCS/Export/";
    private const string OutLuaPath1 = "Script/ToLuaCS/";
    [MenuItem("Assets/", false, 2)]
    static void Breaker() { }

    //[MenuItem("Assets/ToLuaCS/LuaToCS Build To (Plugin)", false, 4)]
    static void ExportLuaToCSP()
    {
        UnityEngine.Object[] objs = Selection.objects;

        foreach (var o in objs)
        {
            ExportFullCalssMtLua(o.name, OutLuaPath);
        }
    }
    [MenuItem("Assets/ToLuaCS/LuaToCS  Build To (Plugin) Floder", false ,3)]
    static void ExportLuaToCSP1()
    {
        UnityEngine.Object[] objs = Selection.objects;

        foreach (var o in objs)
        {
            ExportDeclaredOnlyClassMtLua(o.name, OutLuaPath);
        }
    }

    //[MenuItem("Assets/ToLuaCS/LuaToCS Build To Script", false, 2)]
    static void ExportLuaToCS()
    {
        UnityEngine.Object[] objs = Selection.objects;

        foreach (var o in objs)
        {
            ExportFullCalssMtLua(o.name, OutLuaPath1);
        }
    }

    [MenuItem("Assets/ToLuaCS/LuaToCS  Build To Script", false, 1)] //DeclaredOnly
    static void ExportLuaToCS1()
    {
        UnityEngine.Object[] objs = Selection.objects;

        foreach (var o in objs)
        {
            ExportDeclaredOnlyClassMtLua(o.name, OutLuaPath1);
        }
    }


    #region v1.0 bata

    private static void ExportFullCalssMtLua(string name, string OutLuaPath)
    {
        StringBuilder st = new StringBuilder();
        System.Type t = GetTypeByName(name);
        List<List<string>> methods = FilterMethod(t, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        Build_Class(st, t);
        Build_CreateMetaTableToLua(st, t, methods[0], methods[1]);
        Build_DeclareLuaFn(st, t, methods[0], methods[1]);
        Build_Methods(st, t, methods[0], methods[1]);
        Build_ClassEnd(st);
        Build_ClassFile(st, t, OutLuaPath);
        //Debug.Log(st.ToString()); 
    }

    private static void ExportDeclaredOnlyClassMtLua(string name, string OutLuaPath)
    {
        StringBuilder st = new StringBuilder();
        System.Type t = GetTypeByName(name);
        List<List<string>> methods = FilterMethod(t, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public|BindingFlags.DeclaredOnly);
        Build_Class(st, t);
        Build_CreateMetaTableToLua(st, t, methods[0], methods[1]);
        Build_DeclareLuaFn(st, t, methods[0], methods[1]);
        Build_Methods(st, t, methods[0], methods[1]);
        Build_ClassEnd(st);
        Build_ClassFile(st, t, OutLuaPath);
    }
    /// <summary>
    /// 过滤要生成的字段
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private static List<List<string>> FilterMethod(System.Type t,BindingFlags flags)
    {
        List<List<string>> methodInfos = new List<List<string>>();
        //非静态方法
        methodInfos.Add(new List<string>());
        List<string> instances = methodInfos[0];
        //静态方法
        methodInfos.Add(new List<string>());
        List<string> statics = methodInfos[1];

        MemberInfo[] fields = t.GetMembers(flags);//BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public
        Dictionary<string, bool> addedMemberInfo = new Dictionary<string, bool>();

        //bool breakOne = false;
        foreach (MemberInfo fInfo in fields)
        {
            if (!fInfo.Name.Contains("op_") && !fInfo.Name.StartsWith("add_") && !fInfo.Name.StartsWith("remove_") && !IsObsoleteAttribute(fInfo)) //去掉操作函数 扔掉 unity3d 废弃的函数
            {
               
                 if (!addedMemberInfo.ContainsKey(fInfo.Name) && fInfo.MemberType == MemberTypes.Method)
                {
                    bool isPr = (fInfo.Name.StartsWith("set_") || fInfo.Name.StartsWith("get_"));
                    string realName = "";
                    MemberInfo checkInfo = fInfo;
                    if (isPr)
                    {
                        realName = fInfo.Name.Replace("set_", "").Replace("get_", "");
                        MemberInfo[] infos = t.GetMember(realName);
                        if (infos.Length > 0)
                        {
                            checkInfo = infos[0];
                            if (IsObsoleteAttribute(checkInfo)) continue;
                        }
                    }                   
                    //Debug.Log("add method "+realName);
                    if (((MethodInfo)fInfo).IsStatic)
                    {
                        statics.Add(fInfo.Name);
                    }
                    else
                    {
                        instances.Add(fInfo.Name);
                    }
                    addedMemberInfo[fInfo.Name] = ((MethodInfo)fInfo).IsStatic;
                    
                }
                else if (!addedMemberInfo.ContainsKey(fInfo.Name) && fInfo.MemberType == MemberTypes.Field)
                {

                    string getmethName = "get_" + fInfo.Name;
                    string setmethName = "set_" + fInfo.Name;
                    if (((FieldInfo)fInfo).IsStatic)
                    {
                        statics.Add(getmethName);
                        statics.Add(setmethName);
                    }
                    else
                    {
                        instances.Add(getmethName);
                        instances.Add(setmethName);
                    }
                    //Debug.Log(fInfo.Name);
                    addedMemberInfo[fInfo.Name] = ((FieldInfo)fInfo).IsStatic;
                }
            }
        }

        return methodInfos;
    }

    private static void Build_Class(StringBuilder sbTmp, System.Type t)
    {
        string classTname = t.FullName.Replace(".", "_");
        sbTmp.AppendLine("using System.Collections;");
        sbTmp.AppendLine("using LuaInterface;");
        sbTmp.AppendLine("using Lua = LuaInterface.LuaState;");
        sbTmp.AppendLine("using LuaDLL = LuaInterface.LuaDLL;");
        sbTmp.AppendLine("using LuaState = System.IntPtr;");
        sbTmp.AppendLine("using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;");
        sbTmp.AppendLine("using LuaCSFunction = LuaInterface.LuaCSFunction;");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("public static class LuaTo" + classTname + " {");
        sbTmp.AppendLine("");
    }
    private static void Build_CreateMetaTableToLua(StringBuilder sbTmp, System.Type t, List<string> instances, List<string> statics)
    {
        string classTname = t.FullName;
        sbTmp.AppendLine("  public static void CreateMetaTableToLua(LuaState L) {");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("       LuaDLL.luaL_getmetatable(L, typeof(" + classTname + ").AssemblyQualifiedName);");

        sbTmp.AppendLine("      if (LuaDLL.lua_isnil(L, -1))");
        sbTmp.AppendLine("      {");
        sbTmp.AppendLine("          LuaDLL.lua_settop(L, -2);");
        sbTmp.AppendLine("          LuaDLL.luaL_newmetatable(L, typeof(" + classTname + ").AssemblyQualifiedName);");
        sbTmp.AppendLine("          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());");
        sbTmp.AppendLine("          LuaDLL.lua_pushnumber(L, 1);");
        sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
        sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"__gc\");");
        sbTmp.AppendLine("          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);");
        sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
        sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"__tostring\");");
        sbTmp.AppendLine("          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);");
        sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
        sbTmp.AppendLine("");

        //sbTmp.AppendLine("          LuaDLL.lua_pushstring(L,\"__index\");");
        //sbTmp.AppendLine("          LuaDLL.lua_pushvalue(L, -1);");
        //sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
        sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"__index\");");
        sbTmp.AppendLine("          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);");
        sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"__newindex\");");
        sbTmp.AppendLine("          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);");
        sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("      #region 判断父类");
        sbTmp.AppendLine("          System.Type superT = typeof(" + classTname + ").BaseType;");
        sbTmp.AppendLine("          if (superT != null)");
        sbTmp.AppendLine("          {");
        sbTmp.AppendLine("              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);");
        sbTmp.AppendLine("              if (!LuaDLL.lua_isnil(L, -1))");
        sbTmp.AppendLine("              {");
        sbTmp.AppendLine("                  LuaDLL.lua_setmetatable(L, -2);");
        sbTmp.AppendLine("              }");
        sbTmp.AppendLine("              else");
        sbTmp.AppendLine("              {");
        sbTmp.AppendLine("                  LuaDLL.lua_remove(L, -1);");
        sbTmp.AppendLine("              }");
        sbTmp.AppendLine("          }");
        sbTmp.AppendLine("      #endregion");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("      #region  注册实例luameta");
        foreach (string mname in instances)
        {
            sbTmp.AppendLine("          LuaDLL.lua_pushstring(L,\"" + mname + "\");");
            sbTmp.AppendLine("          luafn_" + mname + "= new LuaCSFunction(" + mname + ");");
            sbTmp.AppendLine("          LuaDLL.lua_pushstdcallcfunction(L, luafn_" + mname + ");");
            sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
            sbTmp.AppendLine("");
        }
        sbTmp.AppendLine("      #endregion");
        sbTmp.AppendLine("");

        if (statics.Count > 0)
        {
            sbTmp.AppendLine("  #region  static method       ");

            sbTmp.AppendLine("          //static    ");
            sbTmp.AppendLine("          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));");
            sbTmp.AppendLine("          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);");
            sbTmp.AppendLine("          if (LuaDLL.lua_isnil(L, -1))");
            sbTmp.AppendLine("          {");
            sbTmp.AppendLine("             LuaDLL.lua_newtable(L);//table");
            sbTmp.AppendLine("             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table");
            sbTmp.AppendLine("             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));");
            sbTmp.AppendLine("             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);");
            sbTmp.AppendLine("          }");
            sbTmp.AppendLine("    ");
            sbTmp.AppendLine("          string[] names = typeof(" + classTname + ").FullName.Split(new char[] { '.' });");
            sbTmp.AppendLine("          foreach (string name in names)");
            sbTmp.AppendLine("          {");
            sbTmp.AppendLine("              LuaDLL.lua_getfield(L, -1, name);");
            sbTmp.AppendLine("              if (LuaDLL.lua_isnil(L, -1))");
            sbTmp.AppendLine("              {");
            sbTmp.AppendLine("                  LuaDLL.lua_pop(L, 1);");
            sbTmp.AppendLine("                  LuaDLL.lua_pushstring(L, name);");
            sbTmp.AppendLine("                  LuaDLL.lua_newtable(L);");
            sbTmp.AppendLine("                  LuaDLL.lua_rawset(L, -3);");
            sbTmp.AppendLine("                  LuaDLL.lua_getfield(L, -1, name);");
            sbTmp.AppendLine("              }   ");
            sbTmp.AppendLine("    ");
            sbTmp.AppendLine("              LuaDLL.lua_remove(L, -2);");
            sbTmp.AppendLine("          }");

            sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"name\");");
            sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, typeof(" + classTname + ").FullName);");
            sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
            sbTmp.AppendLine("          ");
            sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"__index\");");
            sbTmp.AppendLine("          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);");
            sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
            sbTmp.AppendLine("          ");
            sbTmp.AppendLine("          LuaDLL.lua_pushstring(L, \"__newindex\");");
            sbTmp.AppendLine("          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);");
            sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
            sbTmp.AppendLine("          ");
            sbTmp.AppendLine("          LuaDLL.lua_pushvalue(L, -1);");
            sbTmp.AppendLine("          LuaDLL.lua_setmetatable(L, -2);");
            sbTmp.AppendLine("            ");

            foreach (string mname in statics)
            {
                sbTmp.AppendLine("          LuaDLL.lua_pushstring(L,\"" + mname + "\");");
                sbTmp.AppendLine("          luafn_" + mname + "= new LuaCSFunction(" + mname + ");");
                sbTmp.AppendLine("          LuaDLL.lua_pushstdcallcfunction(L, luafn_" + mname + ");");
                sbTmp.AppendLine("          LuaDLL.lua_rawset(L, -3);");
                sbTmp.AppendLine("");
            }

            sbTmp.AppendLine("#endregion       ");
        }
        sbTmp.AppendLine("         }");
        sbTmp.AppendLine("}");

    }
    private static void Build_DeclareLuaFn(StringBuilder sbTmp, System.Type t, List<string> instances, List<string> statics)
    {

        sbTmp.AppendLine("  #region instances declaration       ");
        foreach (string mname in instances)
        {
            sbTmp.AppendLine("          private static LuaCSFunction luafn_" + mname + ";");
        }
        sbTmp.AppendLine(" #endregion        ");

        sbTmp.AppendLine("  #region statics declaration       ");
        foreach (string mname in statics)
        {
            sbTmp.AppendLine("          private static LuaCSFunction luafn_" + mname + ";");
        }
        sbTmp.AppendLine(" #endregion        ");
    }
    private static void Build_Methods(StringBuilder sbTmp, System.Type t, List<string> instances, List<string> statics)
    {
        #region 生成绑定方法
        sbTmp.AppendLine("  #region  instances method       ");
        foreach (string method in instances)
        {
            BuildMethodByNameNew(sbTmp, t, method, false);
        }
        #endregion
        sbTmp.AppendLine("  #endregion       ");
        sbTmp.AppendLine("  #region  static method       ");
        foreach (string method in statics)
        {
            BuildMethodByNameNew(sbTmp, t, method, true);
        }
        sbTmp.AppendLine("  #endregion       ");
    }
    private static void Build_ClassEnd(StringBuilder sbTmp)
    {
        sbTmp.AppendLine("}");
    }
    private static void Build_ClassFile(StringBuilder sbTmp, System.Type t, string outPutPath)
    {
        string classTname = t.FullName;
        string path = Application.dataPath + "/" + outPutPath + "LuaTo" + classTname.Replace(".", "_") + ".cs";
        checkLuaToCSExportPath();
        using (StreamWriter sr = new StreamWriter(path, false))
        {
            sr.WriteLine(sbTmp.ToString());
        }
        Debug.Log(sbTmp.ToString());
    }

    private static void BuildMethodByNameNew(StringBuilder sbTmp, System.Type t, string name, bool isStatic)
    {
        string realName = name.Replace("get_", "").Replace("set_", "");
        MemberInfo[] infos = t.GetMember(name);
        if(infos.Length==0)infos= t.GetMember(realName);
        bool isGet = name.StartsWith("get_");
        bool isSet = name.StartsWith("set_");
       
        //方法头
        sbTmp.AppendLine("          ");
        sbTmp.AppendLine("          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sbTmp.AppendLine("          public static int " + name + "(LuaState L)");
        sbTmp.AppendLine("          {");
        System.Array.Sort(infos, CompareParByLength);
        string allIf = "";
        int i = 1;
        int realyMethodCount = 0;
        foreach (MemberInfo inf in infos)
        {
            i = 2;
            if (isStatic) i = 1;
            if (inf is MethodInfo)
            {
                allIf = "";
                MethodInfo mInfo = ((MethodInfo)inf);
                if (mInfo.ContainsGenericParameters) continue;
                ParameterInfo[] pars = mInfo.GetParameters();
                if (infos.Length > 1)
                {
                    allIf = GetIFStr(pars, i);
                }
                if (allIf != "")
                {
                    sbTmp.AppendLine("              "+allIf);
                    sbTmp.AppendLine("              {");
                }
                sbTmp.AppendLine(GetParStr(pars, i));

                sbTmp.AppendLine(GetCallMethod(t, mInfo, pars, i, mInfo.IsStatic));
                if (allIf != "")
                {
                    sbTmp.AppendLine("              }");
                }
                realyMethodCount++;
            }
            else if (inf is FieldInfo)
            {
                FieldInfo fInfo = ((FieldInfo)inf);
                sbTmp.AppendLine(GetFieldStr(t, fInfo, i, fInfo.IsStatic, isGet));
            }
        }

        if (realyMethodCount > 1)
            sbTmp.AppendLine("          return 0;");

        sbTmp.AppendLine("          }");


    }
    private static string GetIFStr(ParameterInfo[] pars, int i)
    {
        string allIf = "";
        string split = "";

        if (pars.Length >= 1)
        {
            allIf = "if(";

            foreach (ParameterInfo pinfo in pars)
            {
                System.Type pt = pinfo.ParameterType;
                if (pt == typeof(string))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TSTRING ";
                }
                else if (pt == typeof(Boolean))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TNUMBER ";//LuaTypes.LUA_TNUMBER
                }
                else if (pt == typeof(uint) || pt == typeof(UInt16) || pt == typeof(UInt32) || pt == typeof(UInt64)
                        || pt == typeof(Int16) || pt == typeof(Int32) || pt == typeof(Int64)
                        || pt == typeof(Single) || pt == typeof(Double) || pt == typeof(Byte) || pt == typeof(Char))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TNUMBER ";//LuaTypes.LUA_TNUMBER
                }
                else if (pt == typeof(LuaCSFunction))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TFUNCTION ";//LuaTypes.LUA_TFUNCTION
                }
                else
                {
                    allIf += split + " ToLuaCS.getObject(L, " + i + ") is " + GetSafeTypeString(pt) + "";
                }

                i++;
                split = " &&";
            }

            allIf += ")";
        }
        else
        {
            allIf = "if(true)";
        }
        return allIf;
    }
    /// <summary>
    /// 生成调用参数
    /// </summary>
    /// <param name="pinfo"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    private static string GetParStr(ParameterInfo[] pars, int i)
    {
        StringBuilder re = new StringBuilder();
        foreach (ParameterInfo pinfo in pars)
        {

            System.Type t = pinfo.ParameterType;
            if (t == typeof(string))
            {
                re.AppendLine("                  " + pinfo.ParameterType + " " + GetSafeParName(pinfo.Name) + " =  LuaDLL.lua_tostring(L," + i + "); \r\n");
            }
            else if (t == typeof(Boolean))
            {
                re.AppendLine("                  " + pinfo.ParameterType+ " " + GetSafeParName(pinfo.Name) + " =  LuaDLL.lua_toboolean(L," + i + ");");
            }
            else if (t == typeof(uint) || t == typeof(UInt16) || t == typeof(UInt32) || t == typeof(UInt64)
             || t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64)
             || t == typeof(Single) || t == typeof(Double) || t == typeof(Byte) || t == typeof(Char))
            {
                re.AppendLine("                  " +pinfo.ParameterType + " " + GetSafeParName(pinfo.Name) + " = (" + t + ")LuaDLL.lua_tonumber(L," + i + ");");
            }
            else
            {
                re.AppendLine("                  " + GetSafeTypeString(pinfo.ParameterType) + " " + GetSafeParName(pinfo.Name) + " = (" + GetSafeTypeString(pinfo.ParameterType) + ")ToLuaCS.getObject(L," + i + ");");
            }
            i++;
        }
        return re.ToString();
    }
    private static string GetCallMethod(System.Type t, MethodInfo mInfo,ParameterInfo[] pars, int i,bool isStatic)
    {
        StringBuilder sbTmp = new StringBuilder();
        string classTname = t.FullName;

        string parstr = "";
        string sp = "";
        string target = "";
        foreach (ParameterInfo pinfo in pars)
        {
            if (pinfo.ParameterType.ToString().Contains("&"))
            {
                parstr += sp + " ref " + GetSafeParName(pinfo.Name);
            }
            else
            {
                parstr += sp + " " + GetSafeParName(pinfo.Name);
            }
            sp = ",";
            //i++;
        }

        bool isPro = false;
        string proName = mInfo.Name;
        if (mInfo.Name.StartsWith("set_") || mInfo.Name.StartsWith("get_")) isPro = true;
        if (isPro)
        {
            proName = mInfo.Name.Replace("set_", "").Replace("get_", "");
            //Debug.Log(" method "+proName + " isStatic = " + isStatic);
        }

        if (!isStatic)
        {
            sbTmp.AppendLine("                  object original = ToLuaCS.getObject(L, 1);");
            sbTmp.AppendLine("                  " + classTname + " target= (" + classTname + ") original ;");
            target = "target";
        }
        else
        {
            target = classTname;
        }

        if (mInfo.ReturnType == typeof(void))
        {
            if (isPro)
            {
                if (pars.Length > 1)
                {
                    string[] items = parstr.Split(new char[] { ','});
                    sbTmp.AppendLine("                  " + target + "[ " + items[0] + "]=" + items[1] + ";");
                }
                else
                    sbTmp.AppendLine("                  " + target + "." + proName + "=" + parstr + ";");
            }
            else
            {
                sbTmp.AppendLine("                  " + target + "." + mInfo.Name + "(" + parstr + ");");
            }
            sbTmp.AppendLine("                 return 0;");
        }
        else
        {
            if (isPro)
            {
                if (pars.Length > 0)
                {
                    sbTmp.AppendLine("                  " + GetSafeTypeString(mInfo.ReturnType) + " " + proName + "= " + target + "[" + parstr + "];");
                    sbTmp.AppendLine("                  ToLuaCS.push(L," + proName + "); ");
                    sbTmp.AppendLine("                  return 1;");
                }
                else
                {
                    sbTmp.AppendLine("                  " + GetSafeTypeString(mInfo.ReturnType) + " " + proName + "= " + target + "." + proName + ";");
                    sbTmp.AppendLine("                  ToLuaCS.push(L," + proName + "); ");
                    sbTmp.AppendLine("                  return 1;");
                }
            }
            else
            {
                sbTmp.AppendLine("                  " + GetSafeTypeString(mInfo.ReturnType) + " " + mInfo.Name.ToLower() + "= " + target + "." + mInfo.Name + "(" + parstr + ");");
                sbTmp.AppendLine("                  ToLuaCS.push(L," + mInfo.Name.ToLower() + "); ");
                sbTmp.AppendLine("                  return 1;");
            }
        }

        return sbTmp.ToString();
    }
    private static string GetFieldStr(System.Type t, FieldInfo fInfo, int i, bool isStatic, bool isGet)
    {
        StringBuilder re = new StringBuilder();
        string classTname = t.FullName;

        string proName = fInfo.Name;
        System.Type ft = fInfo.FieldType;
        //Debug.Log("GetFieldStr = " + proName + " target= " + isStatic); 
        //proName = mInfo.Name.Replace("set_", "").Replace("get_", "");
        if (isStatic)
        {
            if (isGet)
            {
                re.AppendLine("                  var val=   " + classTname + "." + proName + ";");
                re.AppendLine("                  ToLuaCS.push(L,val);");
                re.AppendLine("                  return 1;");
            }
            else //set
            {
                if (ft == typeof(string))
                {
                    re.AppendLine("                  " + classTname + "." + proName + "= LuaDLL.lua_tostring(L,1);");
                }
                else if (ft == typeof(Boolean))
                {
                    re.AppendLine("                  " + classTname + "." + proName + "= LuaDLL.lua_toboolean(L,1);");
                }
                else if (ft == typeof(uint) || ft == typeof(UInt16) || ft == typeof(UInt32) || ft == typeof(UInt64)
                   || ft == typeof(Int16) || ft == typeof(Int32) || ft == typeof(Int64)
                   || ft == typeof(Single) || ft == typeof(Double) || ft == typeof(Byte) || ft == typeof(Char))
                {
                    re.AppendLine("                  " + classTname + "." + proName + "= (" + ft + ")LuaDLL.lua_tonumber(L,1);");
                }
                else
                {
                    re.AppendLine("                   var val= ToLuaCS.getObject(L, 1);");
                    re.AppendLine("                  " + classTname + "." + proName + "= (" + GetSafeTypeString(ft) + ")val;");
                }
                re.AppendLine("                  return 0;");

            }
        }
        else
        {
            if (isGet)
            {
                re.AppendLine("                  object original = ToLuaCS.getObject(L, 1);");
                re.AppendLine("                  " + classTname + " target= (" + classTname + ") original ;");
                re.AppendLine("                  var val=  target." + proName + ";");
                re.AppendLine("                  ToLuaCS.push(L,val);");
                re.AppendLine("                  return 1;");
            }
            else
            {
                re.AppendLine("                  object original = ToLuaCS.getObject(L, 1);");
                re.AppendLine("                  " + classTname + " target= (" + classTname + ") original;");
                if (ft == typeof(string))
                {
                    re.AppendLine("                  target." + proName + "= LuaDLL.lua_tostring(L,2);");
                }
                else if (ft == typeof(Boolean))
                {
                    re.AppendLine("                  target." + proName + "= LuaDLL.lua_toboolean(L,2);");
                }
                else if (ft == typeof(uint) || ft == typeof(UInt16) || ft == typeof(UInt32) || ft == typeof(UInt64)
                   || ft == typeof(Int16) || ft == typeof(Int32) || ft == typeof(Int64)
                   || ft == typeof(Single) || ft == typeof(Double) || ft == typeof(Byte) || ft == typeof(Char))
                {
                    re.AppendLine("                  target." + proName + "= (" + ft + ")LuaDLL.lua_tonumber(L,2);");
                }
                else
                {
                    re.AppendLine("                  var val= ToLuaCS.getObject(L, 2);");
                    re.AppendLine("                  target." + proName + "= (" + GetSafeTypeString(ft) + ")val;");
                }
                re.AppendLine("                  return 0;");

            }
        }

        return re.ToString();
    }

    #endregion

     #region helper

    private static bool IsObsoleteAttribute(MemberInfo fInfo)
    {
        object[] attrs = fInfo.GetCustomAttributes(true);
        for (int j = 0; j < attrs.Length; j++)
        {
            if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
            {
                return true;
            }
        }

        return false;
    }

    private static int CompareParByLength(MemberInfo x, MemberInfo y)
    {
        MethodInfo mx = ((MethodInfo)x);
        MethodInfo my = ((MethodInfo)y);

        return my.GetParameters().Length - mx.GetParameters().Length;
    }

    private static string GetSafeTypeString(System.Type t)
    {
        if (t == null) return "object";
        if (t.ToString() == "T" || t.ToString() == "T[]") return "object";
        string tname = t.FullName;
        tname=tname.Replace("&", "").Replace("+",".");

        Match math= Regex.Match(tname, pattern);
        if (math.Success)
        {
            string remp = math.Groups[0].Value;
            string re = math.Groups["cla"].Value;
            string rerE = "<" + re + ">";
            tname = tname.Replace(remp, rerE);
        }
        return tname;// t.ToString().Replace("+", ".").Replace("`1[", "<"); //.Replace("]", ">").Replace("[","<")
    }

    private const string pattern=@"\`\d\[\[(?<cla>[\w|\d|\.]+),.*\]\]";

    private static string GetSafeParName(string parsName)
    {
        return parsName + "_";
    }

    private static void checkLuaToCSExportPath()
    {
        string dircAssert = Application.dataPath+"/" + OutLuaPath;
        if (!Directory.Exists(dircAssert))
        {
            Directory.CreateDirectory(dircAssert);
        }
    }

    public static System.Type GetTypeByName(string classname)
    {
        System.Type t = null;
        Assembly assb = Assembly.GetExecutingAssembly();
        t = assb.GetType(classname);
        if (t == null)
        {
            assb = Assembly.GetAssembly(typeof(PLua));
            t = assb.GetType(classname);
        }
        if (t == null)
        {
            assb = Assembly.GetAssembly(typeof(UnityEngine.GameObject));
            t = assb.GetType(classname);
        }
        if (t == null)
        {
            assb = Assembly.GetAssembly(typeof(LuaBase));
            t = assb.GetType(classname);
        }
        return t;
    }
    #endregion
}
