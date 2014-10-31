using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Transform {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Transform).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Transform).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.Transform).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_position");
          luafn_get_position= new LuaCSFunction(get_position);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_position);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_position");
          luafn_set_position= new LuaCSFunction(set_position);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_position);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_localPosition");
          luafn_get_localPosition= new LuaCSFunction(get_localPosition);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_localPosition);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_localPosition");
          luafn_set_localPosition= new LuaCSFunction(set_localPosition);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_localPosition);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_eulerAngles");
          luafn_get_eulerAngles= new LuaCSFunction(get_eulerAngles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_eulerAngles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_eulerAngles");
          luafn_set_eulerAngles= new LuaCSFunction(set_eulerAngles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_eulerAngles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_localEulerAngles");
          luafn_get_localEulerAngles= new LuaCSFunction(get_localEulerAngles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_localEulerAngles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_localEulerAngles");
          luafn_set_localEulerAngles= new LuaCSFunction(set_localEulerAngles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_localEulerAngles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_right");
          luafn_get_right= new LuaCSFunction(get_right);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_right);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_right");
          luafn_set_right= new LuaCSFunction(set_right);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_right);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_up");
          luafn_get_up= new LuaCSFunction(get_up);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_up);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_up");
          luafn_set_up= new LuaCSFunction(set_up);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_up);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_forward");
          luafn_get_forward= new LuaCSFunction(get_forward);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_forward);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_forward");
          luafn_set_forward= new LuaCSFunction(set_forward);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_forward);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_rotation");
          luafn_get_rotation= new LuaCSFunction(get_rotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_rotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_rotation");
          luafn_set_rotation= new LuaCSFunction(set_rotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_rotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_localRotation");
          luafn_get_localRotation= new LuaCSFunction(get_localRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_localRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_localRotation");
          luafn_set_localRotation= new LuaCSFunction(set_localRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_localRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_localScale");
          luafn_get_localScale= new LuaCSFunction(get_localScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_localScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_localScale");
          luafn_set_localScale= new LuaCSFunction(set_localScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_localScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_parent");
          luafn_get_parent= new LuaCSFunction(get_parent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_parent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_parent");
          luafn_set_parent= new LuaCSFunction(set_parent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_parent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_worldToLocalMatrix");
          luafn_get_worldToLocalMatrix= new LuaCSFunction(get_worldToLocalMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_worldToLocalMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_localToWorldMatrix");
          luafn_get_localToWorldMatrix= new LuaCSFunction(get_localToWorldMatrix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_localToWorldMatrix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Translate");
          luafn_Translate= new LuaCSFunction(Translate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Translate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Rotate");
          luafn_Rotate= new LuaCSFunction(Rotate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Rotate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateAround");
          luafn_RotateAround= new LuaCSFunction(RotateAround);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateAround);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LookAt");
          luafn_LookAt= new LuaCSFunction(LookAt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LookAt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"TransformDirection");
          luafn_TransformDirection= new LuaCSFunction(TransformDirection);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_TransformDirection);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InverseTransformDirection");
          luafn_InverseTransformDirection= new LuaCSFunction(InverseTransformDirection);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InverseTransformDirection);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"TransformPoint");
          luafn_TransformPoint= new LuaCSFunction(TransformPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_TransformPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InverseTransformPoint");
          luafn_InverseTransformPoint= new LuaCSFunction(InverseTransformPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InverseTransformPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_root");
          luafn_get_root= new LuaCSFunction(get_root);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_root);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_childCount");
          luafn_get_childCount= new LuaCSFunction(get_childCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_childCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DetachChildren");
          luafn_DetachChildren= new LuaCSFunction(DetachChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DetachChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetAsFirstSibling");
          luafn_SetAsFirstSibling= new LuaCSFunction(SetAsFirstSibling);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetAsFirstSibling);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetAsLastSibling");
          luafn_SetAsLastSibling= new LuaCSFunction(SetAsLastSibling);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetAsLastSibling);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetSiblingIndex");
          luafn_SetSiblingIndex= new LuaCSFunction(SetSiblingIndex);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetSiblingIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetSiblingIndex");
          luafn_GetSiblingIndex= new LuaCSFunction(GetSiblingIndex);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetSiblingIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Find");
          luafn_Find= new LuaCSFunction(Find);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Find);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_lossyScale");
          luafn_get_lossyScale= new LuaCSFunction(get_lossyScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_lossyScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"IsChildOf");
          luafn_IsChildOf= new LuaCSFunction(IsChildOf);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_IsChildOf);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hasChanged");
          luafn_get_hasChanged= new LuaCSFunction(get_hasChanged);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hasChanged);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hasChanged");
          luafn_set_hasChanged= new LuaCSFunction(set_hasChanged);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hasChanged);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FindChild");
          luafn_FindChild= new LuaCSFunction(FindChild);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FindChild);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetEnumerator");
          luafn_GetEnumerator= new LuaCSFunction(GetEnumerator);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetEnumerator);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetChild");
          luafn_GetChild= new LuaCSFunction(GetChild);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetChild);
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

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_position;
          private static LuaCSFunction luafn_set_position;
          private static LuaCSFunction luafn_get_localPosition;
          private static LuaCSFunction luafn_set_localPosition;
          private static LuaCSFunction luafn_get_eulerAngles;
          private static LuaCSFunction luafn_set_eulerAngles;
          private static LuaCSFunction luafn_get_localEulerAngles;
          private static LuaCSFunction luafn_set_localEulerAngles;
          private static LuaCSFunction luafn_get_right;
          private static LuaCSFunction luafn_set_right;
          private static LuaCSFunction luafn_get_up;
          private static LuaCSFunction luafn_set_up;
          private static LuaCSFunction luafn_get_forward;
          private static LuaCSFunction luafn_set_forward;
          private static LuaCSFunction luafn_get_rotation;
          private static LuaCSFunction luafn_set_rotation;
          private static LuaCSFunction luafn_get_localRotation;
          private static LuaCSFunction luafn_set_localRotation;
          private static LuaCSFunction luafn_get_localScale;
          private static LuaCSFunction luafn_set_localScale;
          private static LuaCSFunction luafn_get_parent;
          private static LuaCSFunction luafn_set_parent;
          private static LuaCSFunction luafn_get_worldToLocalMatrix;
          private static LuaCSFunction luafn_get_localToWorldMatrix;
          private static LuaCSFunction luafn_Translate;
          private static LuaCSFunction luafn_Rotate;
          private static LuaCSFunction luafn_RotateAround;
          private static LuaCSFunction luafn_LookAt;
          private static LuaCSFunction luafn_TransformDirection;
          private static LuaCSFunction luafn_InverseTransformDirection;
          private static LuaCSFunction luafn_TransformPoint;
          private static LuaCSFunction luafn_InverseTransformPoint;
          private static LuaCSFunction luafn_get_root;
          private static LuaCSFunction luafn_get_childCount;
          private static LuaCSFunction luafn_DetachChildren;
          private static LuaCSFunction luafn_SetAsFirstSibling;
          private static LuaCSFunction luafn_SetAsLastSibling;
          private static LuaCSFunction luafn_SetSiblingIndex;
          private static LuaCSFunction luafn_GetSiblingIndex;
          private static LuaCSFunction luafn_Find;
          private static LuaCSFunction luafn_get_lossyScale;
          private static LuaCSFunction luafn_IsChildOf;
          private static LuaCSFunction luafn_get_hasChanged;
          private static LuaCSFunction luafn_set_hasChanged;
          private static LuaCSFunction luafn_FindChild;
          private static LuaCSFunction luafn_GetEnumerator;
          private static LuaCSFunction luafn_GetChild;
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
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_position(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 position= target.position;
                  ToLuaCS.push(L,position); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_position(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.position= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localPosition(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 localPosition= target.localPosition;
                  ToLuaCS.push(L,localPosition); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localPosition(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localPosition= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eulerAngles(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 eulerAngles= target.eulerAngles;
                  ToLuaCS.push(L,eulerAngles); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eulerAngles(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.eulerAngles= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localEulerAngles(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 localEulerAngles= target.localEulerAngles;
                  ToLuaCS.push(L,localEulerAngles); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localEulerAngles(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localEulerAngles= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_right(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 right= target.right;
                  ToLuaCS.push(L,right); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_right(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.right= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_up(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 up= target.up;
                  ToLuaCS.push(L,up); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_up(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.up= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_forward(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 forward= target.forward;
                  ToLuaCS.push(L,forward); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_forward(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.forward= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rotation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Quaternion rotation= target.rotation;
                  ToLuaCS.push(L,rotation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_rotation(LuaState L)
          {
                  UnityEngine.Quaternion value_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.rotation= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localRotation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Quaternion localRotation= target.localRotation;
                  ToLuaCS.push(L,localRotation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localRotation(LuaState L)
          {
                  UnityEngine.Quaternion value_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localRotation= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localScale(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 localScale= target.localScale;
                  ToLuaCS.push(L,localScale); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localScale(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.localScale= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_parent(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform parent= target.parent;
                  ToLuaCS.push(L,parent); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_parent(LuaState L)
          {
                  UnityEngine.Transform value_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.parent= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_worldToLocalMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Matrix4x4 worldToLocalMatrix= target.worldToLocalMatrix;
                  ToLuaCS.push(L,worldToLocalMatrix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localToWorldMatrix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Matrix4x4 localToWorldMatrix= target.localToWorldMatrix;
                  ToLuaCS.push(L,localToWorldMatrix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Translate(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is UnityEngine.Space)
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L,5);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( x_, y_, z_, relativeTo_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is UnityEngine.Transform)
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L,5);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( x_, y_, z_, relativeTo_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( x_, y_, z_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Transform)
              {
                  UnityEngine.Vector3 translation_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( translation_, relativeTo_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Space)
              {
                  UnityEngine.Vector3 translation_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( translation_, relativeTo_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 translation_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Translate( translation_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rotate(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is UnityEngine.Space)
              {
                  System.Single xAngle_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single yAngle_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single zAngle_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L,5);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( xAngle_, yAngle_, zAngle_, relativeTo_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is UnityEngine.Space)
              {
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( axis_, angle_, relativeTo_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single xAngle_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single yAngle_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single zAngle_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( xAngle_, yAngle_, zAngle_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( axis_, angle_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Space)
              {
                  UnityEngine.Vector3 eulerAngles_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Space relativeTo_ = (UnityEngine.Space)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( eulerAngles_, relativeTo_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 eulerAngles_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.Rotate( eulerAngles_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateAround(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Vector3 point_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.RotateAround( point_, axis_, angle_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.RotateAround( axis_, angle_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookAt(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 worldPosition_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 worldUp_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( worldPosition_, worldUp_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3)
              {
                  UnityEngine.Transform target_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 worldUp_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( target_, worldUp_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 worldPosition_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( worldPosition_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Transform)
              {
                  UnityEngine.Transform target_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.LookAt( target_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int TransformDirection(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformdirection= target.TransformDirection( x_, y_, z_);
                  ToLuaCS.push(L,transformdirection); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 direction_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformdirection= target.TransformDirection( direction_);
                  ToLuaCS.push(L,transformdirection); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InverseTransformDirection(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformdirection= target.InverseTransformDirection( x_, y_, z_);
                  ToLuaCS.push(L,inversetransformdirection); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 direction_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformdirection= target.InverseTransformDirection( direction_);
                  ToLuaCS.push(L,inversetransformdirection); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int TransformPoint(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformpoint= target.TransformPoint( x_, y_, z_);
                  ToLuaCS.push(L,transformpoint); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 transformpoint= target.TransformPoint( position_);
                  ToLuaCS.push(L,transformpoint); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InverseTransformPoint(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformpoint= target.InverseTransformPoint( x_, y_, z_);
                  ToLuaCS.push(L,inversetransformpoint); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 position_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 inversetransformpoint= target.InverseTransformPoint( position_);
                  ToLuaCS.push(L,inversetransformpoint); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_root(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform root= target.root;
                  ToLuaCS.push(L,root); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_childCount(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 childCount= target.childCount;
                  ToLuaCS.push(L,childCount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DetachChildren(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.DetachChildren();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetAsFirstSibling(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetAsFirstSibling();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetAsLastSibling(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetAsLastSibling();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetSiblingIndex(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SetSiblingIndex( index_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetSiblingIndex(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 getsiblingindex= target.GetSiblingIndex();
                  ToLuaCS.push(L,getsiblingindex); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Find(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform find= target.Find( name_);
                  ToLuaCS.push(L,find); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lossyScale(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Vector3 lossyScale= target.lossyScale;
                  ToLuaCS.push(L,lossyScale); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IsChildOf(LuaState L)
          {
                  UnityEngine.Transform parent_ = (UnityEngine.Transform)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean ischildof= target.IsChildOf( parent_);
                  ToLuaCS.push(L,ischildof); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hasChanged(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean hasChanged= target.hasChanged;
                  ToLuaCS.push(L,hasChanged); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hasChanged(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.hasChanged= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FindChild(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform findchild= target.FindChild( name_);
                  ToLuaCS.push(L,findchild); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetEnumerator(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Collections.IEnumerator getenumerator= target.GetEnumerator();
                  ToLuaCS.push(L,getenumerator); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetChild(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform getchild= target.GetChild( index_);
                  ToLuaCS.push(L,getchild); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_transform(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Transform transform= target.transform;
                  ToLuaCS.push(L,transform); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Rigidbody rigidbody= target.rigidbody;
                  ToLuaCS.push(L,rigidbody); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_rigidbody2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Rigidbody2D rigidbody2D= target.rigidbody2D;
                  ToLuaCS.push(L,rigidbody2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_camera(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Camera camera= target.camera;
                  ToLuaCS.push(L,camera); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_light(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Light light= target.light;
                  ToLuaCS.push(L,light); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animation(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Animation animation= target.animation;
                  ToLuaCS.push(L,animation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_constantForce(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.ConstantForce constantForce= target.constantForce;
                  ToLuaCS.push(L,constantForce); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderer(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Renderer renderer= target.renderer;
                  ToLuaCS.push(L,renderer); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_audio(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.AudioSource audio= target.audio;
                  ToLuaCS.push(L,audio); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiText(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.GUIText guiText= target.guiText;
                  ToLuaCS.push(L,guiText); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_networkView(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.NetworkView networkView= target.networkView;
                  ToLuaCS.push(L,networkView); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_guiTexture(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.GUITexture guiTexture= target.guiTexture;
                  ToLuaCS.push(L,guiTexture); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Collider collider= target.collider;
                  ToLuaCS.push(L,collider); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_collider2D(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Collider2D collider2D= target.collider2D;
                  ToLuaCS.push(L,collider2D); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hingeJoint(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.HingeJoint hingeJoint= target.hingeJoint;
                  ToLuaCS.push(L,hingeJoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleEmitter(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.ParticleEmitter particleEmitter= target.particleEmitter;
                  ToLuaCS.push(L,particleEmitter); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_particleSystem(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.ParticleSystem particleSystem= target.particleSystem;
                  ToLuaCS.push(L,particleSystem); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_gameObject(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponent= target.GetComponent( type_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponentinchildren= target.GetComponentInChildren( t_);
                  ToLuaCS.push(L,getcomponentinchildren); 
                  return 1;

              }

              return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponentsinchildren= target.GetComponentsInChildren( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component getcomponentinparent= target.GetComponentInParent( t_);
                  ToLuaCS.push(L,getcomponentinparent); 
                  return 1;

              }
              return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInParent(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);
                  System.Boolean includeInactive_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponentsinparent= target.GetComponentsInParent( t_, includeInactive_);
                  ToLuaCS.push(L,getcomponentsinparent); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type t_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.Component[] getcomponents= target.GetComponents( type_);
                  ToLuaCS.push(L,getcomponents); 
                  return 1;

              }
              return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tag(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.String tag= target.tag;
                  ToLuaCS.push(L,tag); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tag(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.tag= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CompareTag(LuaState L)
          {
                  System.String tag_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessageUpwards( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_, value_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.SendMessage( methodName_, value_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_, parameter_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.SendMessageOptions)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.SendMessageOptions options_ = (UnityEngine.SendMessageOptions)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_, options_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Object)
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 

                  System.Object parameter_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.BroadcastMessage( methodName_, parameter_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String methodName_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
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
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Boolean equals= target.Equals( o_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  ToLuaCS.push(L,getinstanceid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.String name= target.name;
                  ToLuaCS.push(L,name); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.name= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  target.hideFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Transform target= (UnityEngine.Transform) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
  #endregion       
  #region  static method       
  #endregion       
}

