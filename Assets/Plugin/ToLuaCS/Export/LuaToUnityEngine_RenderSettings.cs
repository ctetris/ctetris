using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_RenderSettings {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.RenderSettings).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.RenderSettings).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.RenderSettings).BaseType;
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

          LuaDLL.lua_pushstring(L,"GetInstanceID");
          luafn_GetInstanceID= new LuaCSFunction(GetInstanceID);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetInstanceID);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_name");
          luafn_get_name= new LuaCSFunction(get_name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_name");
          luafn_set_name= new LuaCSFunction(set_name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hideFlags");
          luafn_get_hideFlags= new LuaCSFunction(get_hideFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hideFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hideFlags");
          luafn_set_hideFlags= new LuaCSFunction(set_hideFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hideFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
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
    
          string[] names = typeof(UnityEngine.RenderSettings).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.RenderSettings).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_fog");
          luafn_get_fog= new LuaCSFunction(get_fog);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fog);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fog");
          luafn_set_fog= new LuaCSFunction(set_fog);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fog);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fogMode");
          luafn_get_fogMode= new LuaCSFunction(get_fogMode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fogMode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fogMode");
          luafn_set_fogMode= new LuaCSFunction(set_fogMode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fogMode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fogColor");
          luafn_get_fogColor= new LuaCSFunction(get_fogColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fogColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fogColor");
          luafn_set_fogColor= new LuaCSFunction(set_fogColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fogColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fogDensity");
          luafn_get_fogDensity= new LuaCSFunction(get_fogDensity);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fogDensity);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fogDensity");
          luafn_set_fogDensity= new LuaCSFunction(set_fogDensity);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fogDensity);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fogStartDistance");
          luafn_get_fogStartDistance= new LuaCSFunction(get_fogStartDistance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fogStartDistance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fogStartDistance");
          luafn_set_fogStartDistance= new LuaCSFunction(set_fogStartDistance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fogStartDistance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_fogEndDistance");
          luafn_get_fogEndDistance= new LuaCSFunction(get_fogEndDistance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_fogEndDistance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_fogEndDistance");
          luafn_set_fogEndDistance= new LuaCSFunction(set_fogEndDistance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_fogEndDistance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_ambientLight");
          luafn_get_ambientLight= new LuaCSFunction(get_ambientLight);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_ambientLight);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_ambientLight");
          luafn_set_ambientLight= new LuaCSFunction(set_ambientLight);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_ambientLight);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_haloStrength");
          luafn_get_haloStrength= new LuaCSFunction(get_haloStrength);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_haloStrength);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_haloStrength");
          luafn_set_haloStrength= new LuaCSFunction(set_haloStrength);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_haloStrength);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_flareStrength");
          luafn_get_flareStrength= new LuaCSFunction(get_flareStrength);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_flareStrength);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_flareStrength");
          luafn_set_flareStrength= new LuaCSFunction(set_flareStrength);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_flareStrength);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_flareFadeSpeed");
          luafn_get_flareFadeSpeed= new LuaCSFunction(get_flareFadeSpeed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_flareFadeSpeed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_flareFadeSpeed");
          luafn_set_flareFadeSpeed= new LuaCSFunction(set_flareFadeSpeed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_flareFadeSpeed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_skybox");
          luafn_get_skybox= new LuaCSFunction(get_skybox);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_skybox);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_skybox");
          luafn_set_skybox= new LuaCSFunction(set_skybox);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_skybox);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetInstanceID;
          private static LuaCSFunction luafn_get_name;
          private static LuaCSFunction luafn_set_name;
          private static LuaCSFunction luafn_get_hideFlags;
          private static LuaCSFunction luafn_set_hideFlags;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_GetType;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_fog;
          private static LuaCSFunction luafn_set_fog;
          private static LuaCSFunction luafn_get_fogMode;
          private static LuaCSFunction luafn_set_fogMode;
          private static LuaCSFunction luafn_get_fogColor;
          private static LuaCSFunction luafn_set_fogColor;
          private static LuaCSFunction luafn_get_fogDensity;
          private static LuaCSFunction luafn_set_fogDensity;
          private static LuaCSFunction luafn_get_fogStartDistance;
          private static LuaCSFunction luafn_set_fogStartDistance;
          private static LuaCSFunction luafn_get_fogEndDistance;
          private static LuaCSFunction luafn_set_fogEndDistance;
          private static LuaCSFunction luafn_get_ambientLight;
          private static LuaCSFunction luafn_set_ambientLight;
          private static LuaCSFunction luafn_get_haloStrength;
          private static LuaCSFunction luafn_set_haloStrength;
          private static LuaCSFunction luafn_get_flareStrength;
          private static LuaCSFunction luafn_set_flareStrength;
          private static LuaCSFunction luafn_get_flareFadeSpeed;
          private static LuaCSFunction luafn_set_flareFadeSpeed;
          private static LuaCSFunction luafn_get_skybox;
          private static LuaCSFunction luafn_set_skybox;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Boolean equals= target.Equals( o_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  ToLuaCS.push(L,getinstanceid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.String name= target.name;
                  ToLuaCS.push(L,name); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  target.name= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  target.hideFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.RenderSettings target= (UnityEngine.RenderSettings) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fog(LuaState L)
          {

                  System.Boolean fog= UnityEngine.RenderSettings.fog;
                  ToLuaCS.push(L,fog); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fog(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,1);

                  UnityEngine.RenderSettings.fog= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogMode(LuaState L)
          {

                  UnityEngine.FogMode fogMode= UnityEngine.RenderSettings.fogMode;
                  ToLuaCS.push(L,fogMode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogMode(LuaState L)
          {
                  UnityEngine.FogMode value_ = (UnityEngine.FogMode)ToLuaCS.getObject(L,1);

                  UnityEngine.RenderSettings.fogMode= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogColor(LuaState L)
          {

                  UnityEngine.Color fogColor= UnityEngine.RenderSettings.fogColor;
                  ToLuaCS.push(L,fogColor); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getObject(L,1);

                  UnityEngine.RenderSettings.fogColor= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogDensity(LuaState L)
          {

                  System.Single fogDensity= UnityEngine.RenderSettings.fogDensity;
                  ToLuaCS.push(L,fogDensity); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogDensity(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.fogDensity= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogStartDistance(LuaState L)
          {

                  System.Single fogStartDistance= UnityEngine.RenderSettings.fogStartDistance;
                  ToLuaCS.push(L,fogStartDistance); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogStartDistance(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.fogStartDistance= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fogEndDistance(LuaState L)
          {

                  System.Single fogEndDistance= UnityEngine.RenderSettings.fogEndDistance;
                  ToLuaCS.push(L,fogEndDistance); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fogEndDistance(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.fogEndDistance= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ambientLight(LuaState L)
          {

                  UnityEngine.Color ambientLight= UnityEngine.RenderSettings.ambientLight;
                  ToLuaCS.push(L,ambientLight); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ambientLight(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getObject(L,1);

                  UnityEngine.RenderSettings.ambientLight= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_haloStrength(LuaState L)
          {

                  System.Single haloStrength= UnityEngine.RenderSettings.haloStrength;
                  ToLuaCS.push(L,haloStrength); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_haloStrength(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.haloStrength= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flareStrength(LuaState L)
          {

                  System.Single flareStrength= UnityEngine.RenderSettings.flareStrength;
                  ToLuaCS.push(L,flareStrength); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_flareStrength(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.flareStrength= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flareFadeSpeed(LuaState L)
          {

                  System.Single flareFadeSpeed= UnityEngine.RenderSettings.flareFadeSpeed;
                  ToLuaCS.push(L,flareFadeSpeed); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_flareFadeSpeed(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.RenderSettings.flareFadeSpeed= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_skybox(LuaState L)
          {

                  UnityEngine.Material skybox= UnityEngine.RenderSettings.skybox;
                  ToLuaCS.push(L,skybox); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_skybox(LuaState L)
          {
                  UnityEngine.Material value_ = (UnityEngine.Material)ToLuaCS.getObject(L,1);

                  UnityEngine.RenderSettings.skybox= value_;
                 return 0;

          }
  #endregion       
}

