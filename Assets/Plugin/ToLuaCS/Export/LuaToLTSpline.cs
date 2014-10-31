using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLTSpline {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LTSpline).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LTSpline).AssemblyQualifiedName);
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
          System.Type superT = typeof(LTSpline).BaseType;
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
          LuaDLL.lua_pushstring(L,"map");
          luafn_map= new LuaCSFunction(map);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_map);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"interp");
          luafn_interp= new LuaCSFunction(interp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_interp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"point");
          luafn_point= new LuaCSFunction(point);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_point);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"place2d");
          luafn_place2d= new LuaCSFunction(place2d);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_place2d);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"placeLocal2d");
          luafn_placeLocal2d= new LuaCSFunction(placeLocal2d);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_placeLocal2d);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"place");
          luafn_place= new LuaCSFunction(place);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_place);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"placeLocal");
          luafn_placeLocal= new LuaCSFunction(placeLocal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_placeLocal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"gizmoDraw");
          luafn_gizmoDraw= new LuaCSFunction(gizmoDraw);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_gizmoDraw);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Velocity");
          luafn_Velocity= new LuaCSFunction(Velocity);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Velocity);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_pts");
          luafn_get_pts= new LuaCSFunction(get_pts);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_pts);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_pts");
          luafn_set_pts= new LuaCSFunction(set_pts);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_pts);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_orientToPath");
          luafn_get_orientToPath= new LuaCSFunction(get_orientToPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_orientToPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_orientToPath");
          luafn_set_orientToPath= new LuaCSFunction(set_orientToPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_orientToPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_orientToPath2d");
          luafn_get_orientToPath2d= new LuaCSFunction(get_orientToPath2d);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_orientToPath2d);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_orientToPath2d");
          luafn_set_orientToPath2d= new LuaCSFunction(set_orientToPath2d);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_orientToPath2d);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_map;
          private static LuaCSFunction luafn_interp;
          private static LuaCSFunction luafn_point;
          private static LuaCSFunction luafn_place2d;
          private static LuaCSFunction luafn_placeLocal2d;
          private static LuaCSFunction luafn_place;
          private static LuaCSFunction luafn_placeLocal;
          private static LuaCSFunction luafn_gizmoDraw;
          private static LuaCSFunction luafn_Velocity;
          private static LuaCSFunction luafn_get_pts;
          private static LuaCSFunction luafn_set_pts;
          private static LuaCSFunction luafn_get_orientToPath;
          private static LuaCSFunction luafn_set_orientToPath;
          private static LuaCSFunction luafn_get_orientToPath2d;
          private static LuaCSFunction luafn_set_orientToPath2d;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int map(LuaState L)
          {
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  System.Single map= target.map( t_);
                  ToLuaCS.push(L,map); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int interp(LuaState L)
          {
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  UnityEngine.Vector3 interp= target.interp( t_);
                  ToLuaCS.push(L,interp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int point(LuaState L)
          {
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  UnityEngine.Vector3 point= target.point( ratio_);
                  ToLuaCS.push(L,point); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int place2d(LuaState L)
          {
                  UnityEngine.Transform transform_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.place2d( transform_, ratio_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int placeLocal2d(LuaState L)
          {
                  UnityEngine.Transform transform_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.placeLocal2d( transform_, ratio_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int place(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3)
              {
                  UnityEngine.Transform transform_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  UnityEngine.Vector3 worldUp_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.place( transform_, ratio_, worldUp_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Transform transform_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.place( transform_, ratio_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int placeLocal(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3)
              {
                  UnityEngine.Transform transform_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  UnityEngine.Vector3 worldUp_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.placeLocal( transform_, ratio_, worldUp_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Transform transform_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  System.Single ratio_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.placeLocal( transform_, ratio_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int gizmoDraw(LuaState L)
          {
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  target.gizmoDraw( t_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Velocity(LuaState L)
          {
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  UnityEngine.Vector3 velocity= target.Velocity( t_);
                  ToLuaCS.push(L,velocity); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pts(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  var val=  target.pts;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pts(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.pts= (UnityEngine.Vector3[])val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_orientToPath(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  var val=  target.orientToPath;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_orientToPath(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original;
                  target.orientToPath= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_orientToPath2d(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original ;
                  var val=  target.orientToPath2d;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_orientToPath2d(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTSpline target= (LTSpline) original;
                  target.orientToPath2d= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

