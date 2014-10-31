using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUIEventLuaTrigger {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UIEventLuaTrigger).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UIEventLuaTrigger).AssemblyQualifiedName);
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
          System.Type superT = typeof(UIEventLuaTrigger).BaseType;
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
          LuaDLL.lua_pushstring(L,"OnLuaTrigger");
          luafn_OnLuaTrigger= new LuaCSFunction(OnLuaTrigger);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_OnLuaTrigger);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_luaFn");
          luafn_get_luaFn= new LuaCSFunction(get_luaFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_luaFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_luaFn");
          luafn_set_luaFn= new LuaCSFunction(set_luaFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_luaFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_trigger");
          luafn_get_trigger= new LuaCSFunction(get_trigger);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_trigger);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_trigger");
          luafn_set_trigger= new LuaCSFunction(set_trigger);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_trigger);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_target");
          luafn_get_target= new LuaCSFunction(get_target);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_target);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_target");
          luafn_set_target= new LuaCSFunction(set_target);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_target);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_OnLuaTrigger;
          private static LuaCSFunction luafn_get_luaFn;
          private static LuaCSFunction luafn_set_luaFn;
          private static LuaCSFunction luafn_get_trigger;
          private static LuaCSFunction luafn_set_trigger;
          private static LuaCSFunction luafn_get_target;
          private static LuaCSFunction luafn_set_target;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnLuaTrigger(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original ;
                  target.OnLuaTrigger();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_luaFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original ;
                  var val=  target.luaFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_luaFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.luaFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_trigger(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original ;
                  var val=  target.trigger;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_trigger(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.trigger= (UnityEngine.MonoBehaviour)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_target(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original ;
                  var val=  target.target;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_target(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIEventLuaTrigger target= (UIEventLuaTrigger) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.target= (System.Collections.Generic.List<UnityEngine.MonoBehaviour>)val;
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

