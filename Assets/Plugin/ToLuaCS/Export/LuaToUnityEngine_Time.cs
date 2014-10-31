using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Time {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Time).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Time).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.Time).BaseType;
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
          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
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
    
          string[] names = typeof(UnityEngine.Time).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.Time).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_time");
          luafn_get_time= new LuaCSFunction(get_time);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_time);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_timeSinceLevelLoad");
          luafn_get_timeSinceLevelLoad= new LuaCSFunction(get_timeSinceLevelLoad);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_timeSinceLevelLoad);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_deltaTime");
          luafn_get_deltaTime= new LuaCSFunction(get_deltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_deltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fixedTime");
          luafn_get_fixedTime= new LuaCSFunction(get_fixedTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fixedTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_unscaledTime");
          luafn_get_unscaledTime= new LuaCSFunction(get_unscaledTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_unscaledTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_unscaledDeltaTime");
          luafn_get_unscaledDeltaTime= new LuaCSFunction(get_unscaledDeltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_unscaledDeltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fixedDeltaTime");
          luafn_get_fixedDeltaTime= new LuaCSFunction(get_fixedDeltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fixedDeltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fixedDeltaTime");
          luafn_set_fixedDeltaTime= new LuaCSFunction(set_fixedDeltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fixedDeltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_maximumDeltaTime");
          luafn_get_maximumDeltaTime= new LuaCSFunction(get_maximumDeltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_maximumDeltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_maximumDeltaTime");
          luafn_set_maximumDeltaTime= new LuaCSFunction(set_maximumDeltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_maximumDeltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_smoothDeltaTime");
          luafn_get_smoothDeltaTime= new LuaCSFunction(get_smoothDeltaTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_smoothDeltaTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_timeScale");
          luafn_get_timeScale= new LuaCSFunction(get_timeScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_timeScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_timeScale");
          luafn_set_timeScale= new LuaCSFunction(set_timeScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_timeScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_frameCount");
          luafn_get_frameCount= new LuaCSFunction(get_frameCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_frameCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_renderedFrameCount");
          luafn_get_renderedFrameCount= new LuaCSFunction(get_renderedFrameCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_renderedFrameCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_realtimeSinceStartup");
          luafn_get_realtimeSinceStartup= new LuaCSFunction(get_realtimeSinceStartup);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_realtimeSinceStartup);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_captureFramerate");
          luafn_get_captureFramerate= new LuaCSFunction(get_captureFramerate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_captureFramerate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_captureFramerate");
          luafn_set_captureFramerate= new LuaCSFunction(set_captureFramerate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_captureFramerate);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_ToString;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_time;
          private static LuaCSFunction luafn_get_timeSinceLevelLoad;
          private static LuaCSFunction luafn_get_deltaTime;
          private static LuaCSFunction luafn_get_fixedTime;
          private static LuaCSFunction luafn_get_unscaledTime;
          private static LuaCSFunction luafn_get_unscaledDeltaTime;
          private static LuaCSFunction luafn_get_fixedDeltaTime;
          private static LuaCSFunction luafn_set_fixedDeltaTime;
          private static LuaCSFunction luafn_get_maximumDeltaTime;
          private static LuaCSFunction luafn_set_maximumDeltaTime;
          private static LuaCSFunction luafn_get_smoothDeltaTime;
          private static LuaCSFunction luafn_get_timeScale;
          private static LuaCSFunction luafn_set_timeScale;
          private static LuaCSFunction luafn_get_frameCount;
          private static LuaCSFunction luafn_get_renderedFrameCount;
          private static LuaCSFunction luafn_get_realtimeSinceStartup;
          private static LuaCSFunction luafn_get_captureFramerate;
          private static LuaCSFunction luafn_set_captureFramerate;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.Boolean equals= target.Equals( obj_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Time target= (UnityEngine.Time) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_time(LuaState L)
          {

                  System.Single time= UnityEngine.Time.time;
                  ToLuaCS.push(L,time); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_timeSinceLevelLoad(LuaState L)
          {

                  System.Single timeSinceLevelLoad= UnityEngine.Time.timeSinceLevelLoad;
                  ToLuaCS.push(L,timeSinceLevelLoad); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_deltaTime(LuaState L)
          {

                  System.Single deltaTime= UnityEngine.Time.deltaTime;
                  ToLuaCS.push(L,deltaTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fixedTime(LuaState L)
          {

                  System.Single fixedTime= UnityEngine.Time.fixedTime;
                  ToLuaCS.push(L,fixedTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_unscaledTime(LuaState L)
          {

                  System.Single unscaledTime= UnityEngine.Time.unscaledTime;
                  ToLuaCS.push(L,unscaledTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_unscaledDeltaTime(LuaState L)
          {

                  System.Single unscaledDeltaTime= UnityEngine.Time.unscaledDeltaTime;
                  ToLuaCS.push(L,unscaledDeltaTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fixedDeltaTime(LuaState L)
          {

                  System.Single fixedDeltaTime= UnityEngine.Time.fixedDeltaTime;
                  ToLuaCS.push(L,fixedDeltaTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fixedDeltaTime(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.fixedDeltaTime= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_maximumDeltaTime(LuaState L)
          {

                  System.Single maximumDeltaTime= UnityEngine.Time.maximumDeltaTime;
                  ToLuaCS.push(L,maximumDeltaTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_maximumDeltaTime(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.maximumDeltaTime= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_smoothDeltaTime(LuaState L)
          {

                  System.Single smoothDeltaTime= UnityEngine.Time.smoothDeltaTime;
                  ToLuaCS.push(L,smoothDeltaTime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_timeScale(LuaState L)
          {

                  System.Single timeScale= UnityEngine.Time.timeScale;
                  ToLuaCS.push(L,timeScale); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_timeScale(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.timeScale= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_frameCount(LuaState L)
          {

                  System.Int32 frameCount= UnityEngine.Time.frameCount;
                  ToLuaCS.push(L,frameCount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderedFrameCount(LuaState L)
          {

                  System.Int32 renderedFrameCount= UnityEngine.Time.renderedFrameCount;
                  ToLuaCS.push(L,renderedFrameCount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_realtimeSinceStartup(LuaState L)
          {

                  System.Single realtimeSinceStartup= UnityEngine.Time.realtimeSinceStartup;
                  ToLuaCS.push(L,realtimeSinceStartup); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_captureFramerate(LuaState L)
          {

                  System.Int32 captureFramerate= UnityEngine.Time.captureFramerate;
                  ToLuaCS.push(L,captureFramerate); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_captureFramerate(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Time.captureFramerate= value_;
                 return 0;

          }
  #endregion       
}

