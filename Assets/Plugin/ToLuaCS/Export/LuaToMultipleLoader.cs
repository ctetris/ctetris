using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToMultipleLoader {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(MultipleLoader).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(MultipleLoader).AssemblyQualifiedName);
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
          System.Type superT = typeof(MultipleLoader).BaseType;
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
          LuaDLL.lua_pushstring(L,"LoadReq");
          luafn_LoadReq= new LuaCSFunction(LoadReq);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadReq);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InitProgressState");
          luafn_InitProgressState= new LuaCSFunction(InitProgressState);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InitProgressState);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadError");
          luafn_LoadError= new LuaCSFunction(LoadError);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadError);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_currentWillLoading");
          luafn_get_currentWillLoading= new LuaCSFunction(get_currentWillLoading);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_currentWillLoading);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_currentLoading");
          luafn_get_currentLoading= new LuaCSFunction(get_currentLoading);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_currentLoading);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_maxLoading");
          luafn_get_maxLoading= new LuaCSFunction(get_maxLoading);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_maxLoading);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_totalLoading");
          luafn_get_totalLoading= new LuaCSFunction(get_totalLoading);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_totalLoading);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_totalLoading");
          luafn_set_totalLoading= new LuaCSFunction(set_totalLoading);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_totalLoading);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_currentLoaded");
          luafn_get_currentLoaded= new LuaCSFunction(get_currentLoaded);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_currentLoaded);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_cache");
          luafn_get_cache= new LuaCSFunction(get_cache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_cache);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_cache");
          luafn_set_cache= new LuaCSFunction(set_cache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_cache);
          LuaDLL.lua_rawset(L, -3);

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
    
          string[] names = typeof(MultipleLoader).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(MultipleLoader).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"GetInstance");
          luafn_GetInstance= new LuaCSFunction(GetInstance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetInstance);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_LoadReq;
          private static LuaCSFunction luafn_InitProgressState;
          private static LuaCSFunction luafn_LoadError;
          private static LuaCSFunction luafn_get_currentWillLoading;
          private static LuaCSFunction luafn_get_currentLoading;
          private static LuaCSFunction luafn_get_maxLoading;
          private static LuaCSFunction luafn_get_totalLoading;
          private static LuaCSFunction luafn_set_totalLoading;
          private static LuaCSFunction luafn_get_currentLoaded;
          private static LuaCSFunction luafn_get_cache;
          private static LuaCSFunction luafn_set_cache;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_GetInstance;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadReq(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is CRequest)
              {
                  CRequest req_ = (CRequest)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  target.LoadReq( req_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is System.Collections.Generic.IList<CRequest>)
              {
                  System.Collections.Generic.IList<CRequest> req_ = (System.Collections.Generic.IList<CRequest>)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  target.LoadReq( req_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InitProgressState(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  target.InitProgressState();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadError(LuaState L)
          {
                  CLoader cloader_ = (CLoader)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  target.LoadError( cloader_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currentWillLoading(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  System.Int32 currentWillLoading= target.currentWillLoading;
                  ToLuaCS.push(L,currentWillLoading); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currentLoading(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  System.Int32 currentLoading= target.currentLoading;
                  ToLuaCS.push(L,currentLoading); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_maxLoading(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  System.Int32 maxLoading= target.maxLoading;
                  ToLuaCS.push(L,maxLoading); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_totalLoading(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  System.Int32 totalLoading= target.totalLoading;
                  ToLuaCS.push(L,totalLoading); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_totalLoading(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  target.totalLoading= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currentLoaded(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  System.Int32 currentLoaded= target.currentLoaded;
                  ToLuaCS.push(L,currentLoaded); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cache(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  System.Object cache= target.cache;
                  ToLuaCS.push(L,cache); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cache(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  MultipleLoader target= (MultipleLoader) original ;
                  target.cache= value_;
                 return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstance(LuaState L)
          {

                  MultipleLoader getinstance= MultipleLoader.GetInstance();
                  ToLuaCS.push(L,getinstance); 
                  return 1;

          }
  #endregion       
}

