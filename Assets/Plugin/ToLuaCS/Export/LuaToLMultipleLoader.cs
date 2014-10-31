using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLMultipleLoader {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LMultipleLoader).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LMultipleLoader).AssemblyQualifiedName);
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
          System.Type superT = typeof(LMultipleLoader).BaseType;
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
          LuaDLL.lua_pushstring(L,"LoadLuaTable");
          luafn_LoadLuaTable= new LuaCSFunction(LoadLuaTable);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadLuaTable);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_cache");
          luafn_get_cache= new LuaCSFunction(get_cache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_cache);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_cache");
          luafn_set_cache= new LuaCSFunction(set_cache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_cache);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onAllCompleteFn");
          luafn_get_onAllCompleteFn= new LuaCSFunction(get_onAllCompleteFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onAllCompleteFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onAllCompleteFn");
          luafn_set_onAllCompleteFn= new LuaCSFunction(set_onAllCompleteFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onAllCompleteFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onProgressFn");
          luafn_get_onProgressFn= new LuaCSFunction(get_onProgressFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onProgressFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onProgressFn");
          luafn_set_onProgressFn= new LuaCSFunction(set_onProgressFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onProgressFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onSharedCompleteFn");
          luafn_get_onSharedCompleteFn= new LuaCSFunction(get_onSharedCompleteFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onSharedCompleteFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onSharedCompleteFn");
          luafn_set_onSharedCompleteFn= new LuaCSFunction(set_onSharedCompleteFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onSharedCompleteFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onCacheFn");
          luafn_get_onCacheFn= new LuaCSFunction(get_onCacheFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onCacheFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onCacheFn");
          luafn_set_onCacheFn= new LuaCSFunction(set_onCacheFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onCacheFn);
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
    
          string[] names = typeof(LMultipleLoader).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(LMultipleLoader).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_instance");
          luafn_get_instance= new LuaCSFunction(get_instance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_instance);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_LoadLuaTable;
          private static LuaCSFunction luafn_get_cache;
          private static LuaCSFunction luafn_set_cache;
          private static LuaCSFunction luafn_get_onAllCompleteFn;
          private static LuaCSFunction luafn_set_onAllCompleteFn;
          private static LuaCSFunction luafn_get_onProgressFn;
          private static LuaCSFunction luafn_set_onProgressFn;
          private static LuaCSFunction luafn_get_onSharedCompleteFn;
          private static LuaCSFunction luafn_set_onSharedCompleteFn;
          private static LuaCSFunction luafn_get_onCacheFn;
          private static LuaCSFunction luafn_set_onCacheFn;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_instance;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadLuaTable(LuaState L)
          {
                  LuaInterface.LuaTable reqs_ = (LuaInterface.LuaTable)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  target.LoadLuaTable( reqs_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cache(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  System.Object cache= target.cache;
                  ToLuaCS.push(L,cache); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cache(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  target.cache= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onAllCompleteFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  var val=  target.onAllCompleteFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onAllCompleteFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onAllCompleteFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onProgressFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  var val=  target.onProgressFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onProgressFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onProgressFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onSharedCompleteFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  var val=  target.onSharedCompleteFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onSharedCompleteFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onSharedCompleteFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCacheFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original ;
                  var val=  target.onCacheFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCacheFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LMultipleLoader target= (LMultipleLoader) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCacheFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  LMultipleLoader instance= LMultipleLoader.instance;
                  ToLuaCS.push(L,instance); 
                  return 1;

          }
  #endregion       
}

