using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToFileHelper {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(FileHelper).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(FileHelper).AssemblyQualifiedName);
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
          System.Type superT = typeof(FileHelper).BaseType;
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
    
          string[] names = typeof(FileHelper).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(FileHelper).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"UnZipFile");
          luafn_UnZipFile= new LuaCSFunction(UnZipFile);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnZipFile);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"UnpackConfigZip");
          luafn_UnpackConfigZip= new LuaCSFunction(UnpackConfigZip);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnpackConfigZip);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PersistentUTF8File");
          luafn_PersistentUTF8File= new LuaCSFunction(PersistentUTF8File);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PersistentUTF8File);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"UnpackConfigZipFn");
          luafn_UnpackConfigZipFn= new LuaCSFunction(UnpackConfigZipFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnpackConfigZipFn);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_UnZipFile;
          private static LuaCSFunction luafn_UnpackConfigZip;
          private static LuaCSFunction luafn_PersistentUTF8File;
          private static LuaCSFunction luafn_UnpackConfigZipFn;
 #endregion        
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnZipFile(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is System.Byte[] && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,1);
                  System.String outPath_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.UnZipFile( bytes_, outPath_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is System.IO.Stream && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.IO.Stream stream_ = (System.IO.Stream)ToLuaCS.getObject(L,1);
                  System.String outPath_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.UnZipFile( stream_, outPath_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 

                  System.String outPath_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.UnZipFile( path_, outPath_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnpackConfigZip(LuaState L)
          {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,1);
                  onTxtUnZip ontz_ = (onTxtUnZip)ToLuaCS.getObject(L,2);

                  FileHelper.UnpackConfigZip( bytes_, ontz_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PersistentUTF8File(LuaState L)
          {
                  System.String context_ =  LuaDLL.lua_tostring(L,1); 

                  System.String fileName_ =  LuaDLL.lua_tostring(L,2); 


                  FileHelper.PersistentUTF8File( context_, fileName_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnpackConfigZipFn(LuaState L)
          {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,1);
                  LuaInterface.LuaFunction luaFn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,2);

                  FileHelper.UnpackConfigZipFn( bytes_, luaFn_);
                 return 0;

          }
  #endregion       
}

