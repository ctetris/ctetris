using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToTimer {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(Timer).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(Timer).AssemblyQualifiedName);
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
          System.Type superT = typeof(Timer).BaseType;
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
    
          string[] names = typeof(Timer).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(Timer).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"AddFn");
          luafn_AddFn= new LuaCSFunction(AddFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_AddFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RemoveFn");
          luafn_RemoveFn= new LuaCSFunction(RemoveFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RemoveFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Update");
          luafn_Update= new LuaCSFunction(Update);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Update);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_AddFn;
          private static LuaCSFunction luafn_RemoveFn;
          private static LuaCSFunction luafn_Update;
 #endregion        
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddFn(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is LuaInterface.LuaFunction && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  LuaInterface.LuaFunction fn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,1);
                  System.Single delaytime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  Timer.AddFn( fn_, delaytime_, arg_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is LuaInterface.LuaFunction && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  LuaInterface.LuaFunction fn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,1);
                  System.Single delaytime_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  Timer.AddFn( fn_, delaytime_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RemoveFn(LuaState L)
          {
                  LuaInterface.LuaFunction fn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,1);

                  Timer.RemoveFn( fn_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Update(LuaState L)
          {

                  Timer.Update();
                 return 0;

          }
  #endregion       
}

