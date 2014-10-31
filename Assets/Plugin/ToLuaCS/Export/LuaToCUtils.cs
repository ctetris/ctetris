using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCUtils {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(CUtils).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(CUtils).AssemblyQualifiedName);
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
          System.Type superT = typeof(CUtils).BaseType;
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
      #endregion

  #region  static method       
          //static    
          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);
          if (LuaDLL.lua_isnil(L, -1))
          {
             LuaDLL.lua_newtable(L);//table
             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table
             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);
          }
    
          string[] names = typeof(CUtils).FullName.Split(new char[] { '.' });
          foreach (string name in names)
          {
              LuaDLL.lua_getfield(L, -1, name);
              if (LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_pop(L, 1);
                  LuaDLL.lua_pushstring(L, name);
                  LuaDLL.lua_newtable(L);
                  LuaDLL.lua_rawset(L, -3);
                  LuaDLL.lua_getfield(L, -1, name);
              }   
    
              LuaDLL.lua_remove(L, -2);
          }
          LuaDLL.lua_pushstring(L, "name");
          LuaDLL.lua_pushstring(L, typeof(CUtils).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"GetURLFileSuffix");
          luafn_GetURLFileSuffix= new LuaCSFunction(GetURLFileSuffix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetURLFileSuffix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetURLFileName");
          luafn_GetURLFileName= new LuaCSFunction(GetURLFileName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetURLFileName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetKeyURLFileName");
          luafn_GetKeyURLFileName= new LuaCSFunction(GetKeyURLFileName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetKeyURLFileName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetURLFullFileName");
          luafn_GetURLFullFileName= new LuaCSFunction(GetURLFullFileName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetURLFullFileName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetFileFullPath");
          luafn_GetFileFullPath= new LuaCSFunction(GetFileFullPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetFileFullPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetAssetFullPath");
          luafn_GetAssetFullPath= new LuaCSFunction(GetAssetFullPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetAssetFullPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetFileFullPathNoProtocol");
          luafn_GetFileFullPathNoProtocol= new LuaCSFunction(GetFileFullPathNoProtocol);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetFileFullPathNoProtocol);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetDirectoryFullPathNoProtocol");
          luafn_GetDirectoryFullPathNoProtocol= new LuaCSFunction(GetDirectoryFullPathNoProtocol);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetDirectoryFullPathNoProtocol);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_dataPath");
          luafn_get_dataPath= new LuaCSFunction(get_dataPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_dataPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetAssetPath");
          luafn_GetAssetPath= new LuaCSFunction(GetAssetPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetAssetPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Collect");
          luafn_Collect= new LuaCSFunction(Collect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Collect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ADD");
          luafn_ADD= new LuaCSFunction(ADD);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ADD);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_currPersistentExist");
          luafn_get_currPersistentExist= new LuaCSFunction(get_currPersistentExist);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_currPersistentExist);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_currPersistentExist");
          luafn_set_currPersistentExist= new LuaCSFunction(set_currPersistentExist);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_currPersistentExist);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_GetURLFileSuffix;
          private static LuaCSFunction luafn_GetURLFileName;
          private static LuaCSFunction luafn_GetKeyURLFileName;
          private static LuaCSFunction luafn_GetURLFullFileName;
          private static LuaCSFunction luafn_GetFileFullPath;
          private static LuaCSFunction luafn_GetAssetFullPath;
          private static LuaCSFunction luafn_GetFileFullPathNoProtocol;
          private static LuaCSFunction luafn_GetDirectoryFullPathNoProtocol;
          private static LuaCSFunction luafn_get_dataPath;
          private static LuaCSFunction luafn_GetAssetPath;
          private static LuaCSFunction luafn_Collect;
          private static LuaCSFunction luafn_ADD;
          private static LuaCSFunction luafn_get_currPersistentExist;
          private static LuaCSFunction luafn_set_currPersistentExist;
 #endregion        
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetURLFileSuffix(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String geturlfilesuffix= CUtils.GetURLFileSuffix( url_);
                  ToLuaCS.push(L,geturlfilesuffix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetURLFileName(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String geturlfilename= CUtils.GetURLFileName( url_);
                  ToLuaCS.push(L,geturlfilename); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetKeyURLFileName(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getkeyurlfilename= CUtils.GetKeyURLFileName( url_);
                  ToLuaCS.push(L,getkeyurlfilename); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetURLFullFileName(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 


                  System.String geturlfullfilename= CUtils.GetURLFullFileName( url_);
                  ToLuaCS.push(L,geturlfullfilename); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetFileFullPath(LuaState L)
          {
                  System.String absolutePath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getfilefullpath= CUtils.GetFileFullPath( absolutePath_);
                  ToLuaCS.push(L,getfilefullpath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAssetFullPath(LuaState L)
          {
                  System.String assetPath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getassetfullpath= CUtils.GetAssetFullPath( assetPath_);
                  ToLuaCS.push(L,getassetfullpath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetFileFullPathNoProtocol(LuaState L)
          {
                  System.String absolutePath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getfilefullpathnoprotocol= CUtils.GetFileFullPathNoProtocol( absolutePath_);
                  ToLuaCS.push(L,getfilefullpathnoprotocol); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetDirectoryFullPathNoProtocol(LuaState L)
          {
                  System.String absolutePath_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getdirectoryfullpathnoprotocol= CUtils.GetDirectoryFullPathNoProtocol( absolutePath_);
                  ToLuaCS.push(L,getdirectoryfullpathnoprotocol); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dataPath(LuaState L)
          {

                  System.String dataPath= CUtils.dataPath;
                  ToLuaCS.push(L,dataPath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAssetPath(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  System.String getassetpath= CUtils.GetAssetPath( name_);
                  ToLuaCS.push(L,getassetpath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Collect(LuaState L)
          {

                  CUtils.Collect();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ADD(LuaState L)
          {
                  System.Int32 a_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 b_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 add= CUtils.ADD( a_, b_);
                  ToLuaCS.push(L,add); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currPersistentExist(LuaState L)
          {
                  var val=   CUtils.currPersistentExist;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_currPersistentExist(LuaState L)
          {
                  CUtils.currPersistentExist= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
  #endregion       
}

