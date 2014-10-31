using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_GameObject {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.GameObject).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.GameObject).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.GameObject).BaseType;
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
          LuaDLL.lua_pushstring(L,"SampleAnimation");
          luafn_SampleAnimation= new LuaCSFunction(SampleAnimation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SampleAnimation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponent");
          luafn_GetComponent= new LuaCSFunction(GetComponent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInChildren");
          luafn_GetComponentInChildren= new LuaCSFunction(GetComponentInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInParent");
          luafn_GetComponentInParent= new LuaCSFunction(GetComponentInParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInParent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isStatic");
          luafn_get_isStatic= new LuaCSFunction(get_isStatic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isStatic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isStatic");
          luafn_set_isStatic= new LuaCSFunction(set_isStatic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isStatic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponents");
          luafn_GetComponents= new LuaCSFunction(GetComponents);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponents);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInChildren");
          luafn_GetComponentsInChildren= new LuaCSFunction(GetComponentsInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInParent");
          luafn_GetComponentsInParent= new LuaCSFunction(GetComponentsInParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInParent);
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

          LuaDLL.lua_pushstring(L,"get_layer");
          luafn_get_layer= new LuaCSFunction(get_layer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_layer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_layer");
          luafn_set_layer= new LuaCSFunction(set_layer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_layer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetActive");
          luafn_SetActive= new LuaCSFunction(SetActive);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetActive);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_activeSelf");
          luafn_get_activeSelf= new LuaCSFunction(get_activeSelf);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_activeSelf);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_activeInHierarchy");
          luafn_get_activeInHierarchy= new LuaCSFunction(get_activeInHierarchy);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_activeInHierarchy);
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

          LuaDLL.lua_pushstring(L,"AddComponent");
          luafn_AddComponent= new LuaCSFunction(AddComponent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_AddComponent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_gameObject");
          luafn_get_gameObject= new LuaCSFunction(get_gameObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_gameObject);
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
    
          string[] names = typeof(UnityEngine.GameObject).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.GameObject).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"CreatePrimitive");
          luafn_CreatePrimitive= new LuaCSFunction(CreatePrimitive);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CreatePrimitive);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FindGameObjectWithTag");
          luafn_FindGameObjectWithTag= new LuaCSFunction(FindGameObjectWithTag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FindGameObjectWithTag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FindWithTag");
          luafn_FindWithTag= new LuaCSFunction(FindWithTag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FindWithTag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FindGameObjectsWithTag");
          luafn_FindGameObjectsWithTag= new LuaCSFunction(FindGameObjectsWithTag);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FindGameObjectsWithTag);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Find");
          luafn_Find= new LuaCSFunction(Find);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Find);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_SampleAnimation;
          private static LuaCSFunction luafn_GetComponent;
          private static LuaCSFunction luafn_GetComponentInChildren;
          private static LuaCSFunction luafn_GetComponentInParent;
          private static LuaCSFunction luafn_get_isStatic;
          private static LuaCSFunction luafn_set_isStatic;
          private static LuaCSFunction luafn_GetComponents;
          private static LuaCSFunction luafn_GetComponentsInChildren;
          private static LuaCSFunction luafn_GetComponentsInParent;
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
          private static LuaCSFunction luafn_get_layer;
          private static LuaCSFunction luafn_set_layer;
          private static LuaCSFunction luafn_SetActive;
          private static LuaCSFunction luafn_get_activeSelf;
          private static LuaCSFunction luafn_get_activeInHierarchy;
          private static LuaCSFunction luafn_get_tag;
          private static LuaCSFunction luafn_set_tag;
          private static LuaCSFunction luafn_CompareTag;
          private static LuaCSFunction luafn_SendMessageUpwards;
          private static LuaCSFunction luafn_SendMessage;
          private static LuaCSFunction luafn_BroadcastMessage;
          private static LuaCSFunction luafn_AddComponent;
          private static LuaCSFunction luafn_get_gameObject;
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
          private static LuaCSFunction luafn_CreatePrimitive;
          private static LuaCSFunction luafn_FindGameObjectWithTag;
          private static LuaCSFunction luafn_FindWithTag;
          private static LuaCSFunction luafn_FindGameObjectsWithTag;
          private static LuaCSFunction luafn_Find;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SampleAnimation(LuaState L)
          {
                  UnityEngine.AnimationClip animation_ = (UnityEngine.AnimationClip)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SampleAnimation( animation_, time_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component getcomponentinchildren= target.GetComponentInChildren( type_);
                  ToLuaCS.push(L,getcomponentinchildren); 
                  return 1;

              }

              ToLuaCS.push(L, null);
              return 1;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component getcomponentinparent= target.GetComponentInParent( type_);
                  ToLuaCS.push(L,getcomponentinparent); 
                  return 1;

              }

              ToLuaCS.push(L, null);
              return 1;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isStatic(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean isStatic= target.isStatic;
                  ToLuaCS.push(L,isStatic); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isStatic(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.isStatic= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponents(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponents= target.GetComponents( type_);
                  ToLuaCS.push(L,getcomponents); 
                  return 1;

              }
              ToLuaCS.push(L, null);
              return 1;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( type_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( type_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( type_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( type_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Rigidbody rigidbody= target.rigidbody;
                  ToLuaCS.push(L,rigidbody); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Rigidbody2D rigidbody2D= target.rigidbody2D;
                  ToLuaCS.push(L,rigidbody2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_camera(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Camera camera= target.camera;
                  ToLuaCS.push(L,camera); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_light(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Light light= target.light;
                  ToLuaCS.push(L,light); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Animation animation= target.animation;
                  ToLuaCS.push(L,animation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_constantForce(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.ConstantForce constantForce= target.constantForce;
                  ToLuaCS.push(L,constantForce); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderer(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Renderer renderer= target.renderer;
                  ToLuaCS.push(L,renderer); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_audio(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.AudioSource audio= target.audio;
                  ToLuaCS.push(L,audio); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiText(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.GUIText guiText= target.guiText;
                  ToLuaCS.push(L,guiText); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_networkView(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.NetworkView networkView= target.networkView;
                  ToLuaCS.push(L,networkView); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiTexture(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.GUITexture guiTexture= target.guiTexture;
                  ToLuaCS.push(L,guiTexture); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Collider collider= target.collider;
                  ToLuaCS.push(L,collider); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Collider2D collider2D= target.collider2D;
                  ToLuaCS.push(L,collider2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hingeJoint(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.HingeJoint hingeJoint= target.hingeJoint;
                  ToLuaCS.push(L,hingeJoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleEmitter(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.ParticleEmitter particleEmitter= target.particleEmitter;
                  ToLuaCS.push(L,particleEmitter); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleSystem(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.ParticleSystem particleSystem= target.particleSystem;
                  ToLuaCS.push(L,particleSystem); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layer(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Int32 layer= target.layer;
                  ToLuaCS.push(L,layer); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_layer(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.layer= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetActive(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SetActive( value_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_activeSelf(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean activeSelf= target.activeSelf;
                  ToLuaCS.push(L,activeSelf); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_activeInHierarchy(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean activeInHierarchy= target.activeInHierarchy;
                  ToLuaCS.push(L,activeInHierarchy); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tag(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.String tag= target.tag;
                  ToLuaCS.push(L,tag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.tag= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessageUpwards( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessageUpwards( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessage( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.SendMessage( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
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
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.BroadcastMessage( methodName_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AddComponent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type componentType_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component addcomponent= target.AddComponent( componentType_);
                  ToLuaCS.push(L,addcomponent); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String className_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.Component addcomponent= target.AddComponent( className_);
                  ToLuaCS.push(L,addcomponent); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.GameObject gameObject= target.gameObject;
                  ToLuaCS.push(L,gameObject); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Boolean equals= target.Equals( o_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  ToLuaCS.push(L,getinstanceid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.String name= target.name;
                  ToLuaCS.push(L,name); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.name= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  target.hideFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.GameObject target= (UnityEngine.GameObject) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreatePrimitive(LuaState L)
          {
                  UnityEngine.PrimitiveType type_ = (UnityEngine.PrimitiveType)ToLuaCS.getObject(L,1);

                  UnityEngine.GameObject createprimitive= UnityEngine.GameObject.CreatePrimitive( type_);
                  ToLuaCS.push(L,createprimitive); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindGameObjectWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject findgameobjectwithtag= UnityEngine.GameObject.FindGameObjectWithTag( tag_);
                  ToLuaCS.push(L,findgameobjectwithtag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject findwithtag= UnityEngine.GameObject.FindWithTag( tag_);
                  ToLuaCS.push(L,findwithtag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindGameObjectsWithTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject[] findgameobjectswithtag= UnityEngine.GameObject.FindGameObjectsWithTag( tag_);
                  ToLuaCS.push(L,findgameobjectswithtag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Find(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject find= UnityEngine.GameObject.Find( name_);
                  ToLuaCS.push(L,find); 
                  return 1;

          }
  #endregion       
}

