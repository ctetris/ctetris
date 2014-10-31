using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Random {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Random).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Random).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.Random).BaseType;
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
    
          string[] names = typeof(UnityEngine.Random).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.Random).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_seed");
          luafn_get_seed= new LuaCSFunction(get_seed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_seed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_seed");
          luafn_set_seed= new LuaCSFunction(set_seed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_seed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Range");
          luafn_Range= new LuaCSFunction(Range);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Range);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_value");
          luafn_get_value= new LuaCSFunction(get_value);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_value);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_insideUnitSphere");
          luafn_get_insideUnitSphere= new LuaCSFunction(get_insideUnitSphere);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_insideUnitSphere);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_insideUnitCircle");
          luafn_get_insideUnitCircle= new LuaCSFunction(get_insideUnitCircle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_insideUnitCircle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUnitSphere");
          luafn_get_onUnitSphere= new LuaCSFunction(get_onUnitSphere);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUnitSphere);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rotation");
          luafn_get_rotation= new LuaCSFunction(get_rotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rotationUniform");
          luafn_get_rotationUniform= new LuaCSFunction(get_rotationUniform);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rotationUniform);
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
          private static LuaCSFunction luafn_get_seed;
          private static LuaCSFunction luafn_set_seed;
          private static LuaCSFunction luafn_Range;
          private static LuaCSFunction luafn_get_value;
          private static LuaCSFunction luafn_get_insideUnitSphere;
          private static LuaCSFunction luafn_get_insideUnitCircle;
          private static LuaCSFunction luafn_get_onUnitSphere;
          private static LuaCSFunction luafn_get_rotation;
          private static LuaCSFunction luafn_get_rotationUniform;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.Boolean equals= target.Equals( obj_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Random target= (UnityEngine.Random) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_seed(LuaState L)
          {

                  System.Int32 seed= UnityEngine.Random.seed;
                  ToLuaCS.push(L,seed); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_seed(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Random.seed= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Range(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 min_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 max_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 range= UnityEngine.Random.Range( min_, max_);
                  ToLuaCS.push(L,range); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single min_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single max_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single range= UnityEngine.Random.Range( min_, max_);
                  ToLuaCS.push(L,range); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_value(LuaState L)
          {

                  System.Single value= UnityEngine.Random.value;
                  ToLuaCS.push(L,value); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_insideUnitSphere(LuaState L)
          {

                  UnityEngine.Vector3 insideUnitSphere= UnityEngine.Random.insideUnitSphere;
                  ToLuaCS.push(L,insideUnitSphere); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_insideUnitCircle(LuaState L)
          {

                  UnityEngine.Vector2 insideUnitCircle= UnityEngine.Random.insideUnitCircle;
                  ToLuaCS.push(L,insideUnitCircle); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUnitSphere(LuaState L)
          {

                  UnityEngine.Vector3 onUnitSphere= UnityEngine.Random.onUnitSphere;
                  ToLuaCS.push(L,onUnitSphere); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rotation(LuaState L)
          {

                  UnityEngine.Quaternion rotation= UnityEngine.Random.rotation;
                  ToLuaCS.push(L,rotation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rotationUniform(LuaState L)
          {

                  UnityEngine.Quaternion rotationUniform= UnityEngine.Random.rotationUniform;
                  ToLuaCS.push(L,rotationUniform); 
                  return 1;

          }
  #endregion       
}

