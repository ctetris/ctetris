using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLTBezier {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LTBezier).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LTBezier).AssemblyQualifiedName);
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
          System.Type superT = typeof(LTBezier).BaseType;
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
          LuaDLL.lua_pushstring(L,"point");
          luafn_point= new LuaCSFunction(point);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_point);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_length");
          luafn_get_length= new LuaCSFunction(get_length);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_length);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_length");
          luafn_set_length= new LuaCSFunction(set_length);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_length);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_point;
          private static LuaCSFunction luafn_get_length;
          private static LuaCSFunction luafn_set_length;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int point(LuaState L)
          {
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTBezier target= (LTBezier) original ;
                  UnityEngine.Vector3 point= target.point( t_);
                  ToLuaCS.push(L,point); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_length(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTBezier target= (LTBezier) original ;
                  var val=  target.length;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_length(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTBezier target= (LTBezier) original;
                  target.length= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

