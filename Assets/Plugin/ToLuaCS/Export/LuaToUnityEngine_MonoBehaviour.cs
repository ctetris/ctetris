using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_MonoBehaviour {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.MonoBehaviour).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.MonoBehaviour).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.MonoBehaviour).BaseType;
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
          LuaDLL.lua_pushstring(L,"Invoke");
          luafn_Invoke= new LuaCSFunction(Invoke);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Invoke);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InvokeRepeating");
          luafn_InvokeRepeating= new LuaCSFunction(InvokeRepeating);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InvokeRepeating);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CancelInvoke");
          luafn_CancelInvoke= new LuaCSFunction(CancelInvoke);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CancelInvoke);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"IsInvoking");
          luafn_IsInvoking= new LuaCSFunction(IsInvoking);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_IsInvoking);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"StartCoroutine");
          luafn_StartCoroutine= new LuaCSFunction(StartCoroutine);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_StartCoroutine);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"StartCoroutine_Auto");
          luafn_StartCoroutine_Auto= new LuaCSFunction(StartCoroutine_Auto);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_StartCoroutine_Auto);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"StopCoroutine");
          luafn_StopCoroutine= new LuaCSFunction(StopCoroutine);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_StopCoroutine);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"StopAllCoroutines");
          luafn_StopAllCoroutines= new LuaCSFunction(StopAllCoroutines);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_StopAllCoroutines);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_useGUILayout");
          luafn_get_useGUILayout= new LuaCSFunction(get_useGUILayout);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_useGUILayout);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_useGUILayout");
          luafn_set_useGUILayout= new LuaCSFunction(set_useGUILayout);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_useGUILayout);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_enabled");
          luafn_get_enabled= new LuaCSFunction(get_enabled);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_enabled);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_enabled");
          luafn_set_enabled= new LuaCSFunction(set_enabled);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_enabled);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_transform");
          luafn_get_transform= new LuaCSFunction(get_transform);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_transform);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rigidbody");
          luafn_get_rigidbody= new LuaCSFunction(get_rigidbody);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rigidbody);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rigidbody2D");
          luafn_get_rigidbody2D= new LuaCSFunction(get_rigidbody2D);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rigidbody2D);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_camera");
          luafn_get_camera= new LuaCSFunction(get_camera);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_camera);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_light");
          luafn_get_light= new LuaCSFunction(get_light);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_light);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_animation");
          luafn_get_animation= new LuaCSFunction(get_animation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_animation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_constantForce");
          luafn_get_constantForce= new LuaCSFunction(get_constantForce);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_constantForce);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_renderer");
          luafn_get_renderer= new LuaCSFunction(get_renderer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_renderer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_audio");
          luafn_get_audio= new LuaCSFunction(get_audio);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_audio);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_guiText");
          luafn_get_guiText= new LuaCSFunction(get_guiText);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_guiText);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_networkView");
          luafn_get_networkView= new LuaCSFunction(get_networkView);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_networkView);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_guiTexture");
          luafn_get_guiTexture= new LuaCSFunction(get_guiTexture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_guiTexture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_collider");
          luafn_get_collider= new LuaCSFunction(get_collider);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_collider);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_collider2D");
          luafn_get_collider2D= new LuaCSFunction(get_collider2D);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_collider2D);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hingeJoint");
          luafn_get_hingeJoint= new LuaCSFunction(get_hingeJoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hingeJoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_particleEmitter");
          luafn_get_particleEmitter= new LuaCSFunction(get_particleEmitter);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_particleEmitter);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_particleSystem");
          luafn_get_particleSystem= new LuaCSFunction(get_particleSystem);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_particleSystem);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_gameObject");
          luafn_get_gameObject= new LuaCSFunction(get_gameObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_gameObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponent");
          luafn_GetComponent= new LuaCSFunction(GetComponent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInChildren");
          luafn_GetComponentInChildren= new LuaCSFunction(GetComponentInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInChildren");
          luafn_GetComponentsInChildren= new LuaCSFunction(GetComponentsInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInParent");
          luafn_GetComponentInParent= new LuaCSFunction(GetComponentInParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInParent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInParent");
          luafn_GetComponentsInParent= new LuaCSFunction(GetComponentsInParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInParent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponents");
          luafn_GetComponents= new LuaCSFunction(GetComponents);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponents);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tag");
          luafn_get_tag= new LuaCSFunction(get_tag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_tag");
          luafn_set_tag= new LuaCSFunction(set_tag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_tag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CompareTag");
          luafn_CompareTag= new LuaCSFunction(CompareTag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CompareTag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SendMessageUpwards");
          luafn_SendMessageUpwards= new LuaCSFunction(SendMessageUpwards);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SendMessageUpwards);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SendMessage");
          luafn_SendMessage= new LuaCSFunction(SendMessage);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SendMessage);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"BroadcastMessage");
          luafn_BroadcastMessage= new LuaCSFunction(BroadcastMessage);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_BroadcastMessage);
          LuaDLL.lua_rawset(L, -3);

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
    
          string[] names = typeof(UnityEngine.MonoBehaviour).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.MonoBehaviour).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"print");
          luafn_print= new LuaCSFunction(print);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_print);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Invoke;
          private static LuaCSFunction luafn_InvokeRepeating;
          private static LuaCSFunction luafn_CancelInvoke;
          private static LuaCSFunction luafn_IsInvoking;
          private static LuaCSFunction luafn_StartCoroutine;
          private static LuaCSFunction luafn_StartCoroutine_Auto;
          private static LuaCSFunction luafn_StopCoroutine;
          private static LuaCSFunction luafn_StopAllCoroutines;
          private static LuaCSFunction luafn_get_useGUILayout;
          private static LuaCSFunction luafn_set_useGUILayout;
          private static LuaCSFunction luafn_get_enabled;
          private static LuaCSFunction luafn_set_enabled;
          private static LuaCSFunction luafn_get_transform;
          private static LuaCSFunction luafn_get_rigidbody;
          private static LuaCSFunction luafn_get_rigidbody2D;
          private static LuaCSFunction luafn_get_camera;
          private static LuaCSFunction luafn_get_light;
          private static LuaCSFunction luafn_get_animation;
          private static LuaCSFunction luafn_get_constantForce;
          private static LuaCSFunction luafn_get_renderer;
          private static LuaCSFunction luafn_get_audio;
          private static LuaCSFunction luafn_get_guiText;
          private static LuaCSFunction luafn_get_networkView;
          private static LuaCSFunction luafn_get_guiTexture;
          private static LuaCSFunction luafn_get_collider;
          private static LuaCSFunction luafn_get_collider2D;
          private static LuaCSFunction luafn_get_hingeJoint;
          private static LuaCSFunction luafn_get_particleEmitter;
          private static LuaCSFunction luafn_get_particleSystem;
          private static LuaCSFunction luafn_get_gameObject;
          private static LuaCSFunction luafn_GetComponent;
          private static LuaCSFunction luafn_GetComponentInChildren;
          private static LuaCSFunction luafn_GetComponentsInChildren;
          private static LuaCSFunction luafn_GetComponentInParent;
          private static LuaCSFunction luafn_GetComponentsInParent;
          private static LuaCSFunction luafn_GetComponents;
          private static LuaCSFunction luafn_get_tag;
          private static LuaCSFunction luafn_set_tag;
          private static LuaCSFunction luafn_CompareTag;
          private static LuaCSFunction luafn_SendMessageUpwards;
          private static LuaCSFunction luafn_SendMessage;
          private static LuaCSFunction luafn_BroadcastMessage;
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
          private static LuaCSFunction luafn_print;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Invoke(LuaState L)
          {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.Invoke( methodName_, time_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InvokeRepeating(LuaState L)
          {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single repeatRate_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.InvokeRepeating( methodName_, time_, repeatRate_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CancelInvoke(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.CancelInvoke( methodName_);
                 return 0;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.CancelInvoke();
                 return 0;

              }
          //return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsInvoking(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean isinvoking= target.IsInvoking( methodName_);
                  ToLuaCS.push(L,isinvoking); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean isinvoking= target.IsInvoking();
                  ToLuaCS.push(L,isinvoking); 
                  return 1;

              }
          //return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StartCoroutine(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine= target.StartCoroutine( methodName_, value_);
                  ToLuaCS.push(L,startcoroutine); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine= target.StartCoroutine( methodName_);
                  ToLuaCS.push(L,startcoroutine); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Collections.IEnumerator)
              {
                  System.Collections.IEnumerator routine_ = (System.Collections.IEnumerator)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine= target.StartCoroutine( routine_);
                  ToLuaCS.push(L,startcoroutine); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StartCoroutine_Auto(LuaState L)
          {
                  System.Collections.IEnumerator routine_ = (System.Collections.IEnumerator)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Coroutine startcoroutine_auto= target.StartCoroutine_Auto( routine_);
                  ToLuaCS.push(L,startcoroutine_auto); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopCoroutine(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Collections.IEnumerator)
              {
                  System.Collections.IEnumerator routine_ = (System.Collections.IEnumerator)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopCoroutine( routine_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopCoroutine( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopAllCoroutines(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.StopAllCoroutines();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useGUILayout(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean useGUILayout= target.useGUILayout;
                  ToLuaCS.push(L,useGUILayout); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useGUILayout(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.useGUILayout= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_enabled(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean enabled= target.enabled;
                  ToLuaCS.push(L,enabled); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_enabled(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.enabled= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Rigidbody rigidbody= target.rigidbody;
                  ToLuaCS.push(L,rigidbody); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Rigidbody2D rigidbody2D= target.rigidbody2D;
                  ToLuaCS.push(L,rigidbody2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_camera(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Camera camera= target.camera;
                  ToLuaCS.push(L,camera); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_light(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Light light= target.light;
                  ToLuaCS.push(L,light); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Animation animation= target.animation;
                  ToLuaCS.push(L,animation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_constantForce(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.ConstantForce constantForce= target.constantForce;
                  ToLuaCS.push(L,constantForce); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderer(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Renderer renderer= target.renderer;
                  ToLuaCS.push(L,renderer); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_audio(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.AudioSource audio= target.audio;
                  ToLuaCS.push(L,audio); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiText(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.GUIText guiText= target.guiText;
                  ToLuaCS.push(L,guiText); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_networkView(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.NetworkView networkView= target.networkView;
                  ToLuaCS.push(L,networkView); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiTexture(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.GUITexture guiTexture= target.guiTexture;
                  ToLuaCS.push(L,guiTexture); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Collider collider= target.collider;
                  ToLuaCS.push(L,collider); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Collider2D collider2D= target.collider2D;
                  ToLuaCS.push(L,collider2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hingeJoint(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.HingeJoint hingeJoint= target.hingeJoint;
                  ToLuaCS.push(L,hingeJoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleEmitter(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.ParticleEmitter particleEmitter= target.particleEmitter;
                  ToLuaCS.push(L,particleEmitter); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleSystem(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.ParticleSystem particleSystem= target.particleSystem;
                  ToLuaCS.push(L,particleSystem); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.GameObject gameObject= target.gameObject;
                  ToLuaCS.push(L,gameObject); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInChildren(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component getcomponentinchildren= target.GetComponentInChildren( t_);
                  ToLuaCS.push(L,getcomponentinchildren); 
                  return 1;

              }
              ToLuaCS.push(L,null);
              return 1;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component getcomponentinparent= target.GetComponentInParent( t_);
                  ToLuaCS.push(L,getcomponentinparent); 
                  return 1;

              }
              ToLuaCS.push(L,null);
              return 1;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponents(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.Component[] getcomponents= target.GetComponents( type_);
                  ToLuaCS.push(L,getcomponents); 
                  return 1;

              }
              ToLuaCS.push(L, null);
              return 1;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tag(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.String tag= target.tag;
                  ToLuaCS.push(L,tag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.tag= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean comparetag= target.CompareTag( tag_);
                  ToLuaCS.push(L,comparetag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendMessageUpwards(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object && ToLuaCS.getObject(L, 4) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessageUpwards( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendMessage(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object && ToLuaCS.getObject(L, 4) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.SendMessage( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int BroadcastMessage(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object && ToLuaCS.getObject(L, 4) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L,3);
                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.BroadcastMessage( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Boolean equals= target.Equals( o_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  ToLuaCS.push(L,getinstanceid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.String name= target.name;
                  ToLuaCS.push(L,name); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.name= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  target.hideFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.MonoBehaviour target= (UnityEngine.MonoBehaviour) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int print(LuaState L)
          {
                  System.Object message_ = (System.Object)ToLuaCS.getObject(L,1);

                  UnityEngine.MonoBehaviour.print( message_);
                 return 0;

          }
  #endregion       
}

