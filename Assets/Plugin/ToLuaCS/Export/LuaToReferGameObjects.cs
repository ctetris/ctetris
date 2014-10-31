using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToReferGameObjects {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(ReferGameObjects).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(ReferGameObjects).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

      #region 判断父类
          System.Type superT = typeof(ReferGameObjects).BaseType;
          if (superT != null)
          {
              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
              if (!LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_setmetatable(L, -2);
              }
              else
              {
                  LuaDLL.lua_remove(L, -1);
              }
          }
      #endregion

      #region  注册实例luameta
          LuaDLL.lua_pushstring(L,"get_refers");
          luafn_get_refers= new LuaCSFunction(get_refers);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_refers);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_refers");
          luafn_set_refers= new LuaCSFunction(set_refers);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_refers);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_monos");
          luafn_get_monos= new LuaCSFunction(get_monos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_monos);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_monos");
          luafn_set_monos= new LuaCSFunction(set_monos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_monos);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_userObject");
          luafn_get_userObject= new LuaCSFunction(get_userObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_userObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_userObject");
          luafn_set_userObject= new LuaCSFunction(set_userObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_userObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_userBool");
          luafn_get_userBool= new LuaCSFunction(get_userBool);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_userBool);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_userBool");
          luafn_set_userBool= new LuaCSFunction(set_userBool);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_userBool);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_userInt");
          luafn_get_userInt= new LuaCSFunction(get_userInt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_userInt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_userInt");
          luafn_set_userInt= new LuaCSFunction(set_userInt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_userInt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_userFloat");
          luafn_get_userFloat= new LuaCSFunction(get_userFloat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_userFloat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_userFloat");
          luafn_set_userFloat= new LuaCSFunction(set_userFloat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_userFloat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_userString");
          luafn_get_userString= new LuaCSFunction(get_userString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_userString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_userString");
          luafn_set_userString= new LuaCSFunction(set_userString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_userString);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_refers;
          private static LuaCSFunction luafn_set_refers;
          private static LuaCSFunction luafn_get_monos;
          private static LuaCSFunction luafn_set_monos;
          private static LuaCSFunction luafn_get_userObject;
          private static LuaCSFunction luafn_set_userObject;
          private static LuaCSFunction luafn_get_userBool;
          private static LuaCSFunction luafn_set_userBool;
          private static LuaCSFunction luafn_get_userInt;
          private static LuaCSFunction luafn_set_userInt;
          private static LuaCSFunction luafn_get_userFloat;
          private static LuaCSFunction luafn_set_userFloat;
          private static LuaCSFunction luafn_get_userString;
          private static LuaCSFunction luafn_set_userString;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_refers(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.refers;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_refers(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.refers= (System.Collections.Generic.List<UnityEngine.GameObject>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_monos(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.monos;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_monos(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.monos= (System.Collections.Generic.List<UnityEngine.MonoBehaviour>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userObject(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userObject;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userObject(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.userObject= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userBool(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userBool;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userBool(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  target.userBool= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userInt(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userInt;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userInt(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.userInt= (System.Int32)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userFloat(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userFloat;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userFloat(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.userFloat= (System.Single)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userString(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original ;
                  var val=  target.userString;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userString(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ReferGameObjects target= (ReferGameObjects) original;
                  target.userString= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

