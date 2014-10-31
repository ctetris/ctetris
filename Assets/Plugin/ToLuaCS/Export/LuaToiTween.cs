using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToiTween {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(iTween).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(iTween).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.lua.translator.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.lua.translator.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

#region 判断父类
          System.Type superT = typeof(iTween).BaseType;
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
  #region  declaration nonStatic       
          LuaDLL.lua_pushstring(L,"get_id");
          luafn_get_id= new LuaCSFunction(get_id);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_id);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_id");
          luafn_set_id= new LuaCSFunction(set_id);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_id);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_type");
          luafn_get_type= new LuaCSFunction(get_type);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_type);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_type");
          luafn_set_type= new LuaCSFunction(set_type);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_type);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_method");
          luafn_get_method= new LuaCSFunction(get_method);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_method);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_method");
          luafn_set_method= new LuaCSFunction(set_method);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_method);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_easeType");
          luafn_get_easeType= new LuaCSFunction(get_easeType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_easeType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_easeType");
          luafn_set_easeType= new LuaCSFunction(set_easeType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_easeType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_time");
          luafn_get_time= new LuaCSFunction(get_time);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_time);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_time");
          luafn_set_time= new LuaCSFunction(set_time);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_time);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_delay");
          luafn_get_delay= new LuaCSFunction(get_delay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_delay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_delay");
          luafn_set_delay= new LuaCSFunction(set_delay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_delay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_loopType");
          luafn_get_loopType= new LuaCSFunction(get_loopType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_loopType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_loopType");
          luafn_set_loopType= new LuaCSFunction(set_loopType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_loopType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isRunning");
          luafn_get_isRunning= new LuaCSFunction(get_isRunning);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isRunning);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isRunning");
          luafn_set_isRunning= new LuaCSFunction(set_isRunning);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isRunning);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isPaused");
          luafn_get_isPaused= new LuaCSFunction(get_isPaused);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isPaused);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isPaused");
          luafn_set_isPaused= new LuaCSFunction(set_isPaused);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isPaused);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get__name");
          luafn_get__name= new LuaCSFunction(get__name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get__name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set__name");
          luafn_set__name= new LuaCSFunction(set__name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set__name);
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
    
          string[] names = typeof(iTween).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(iTween).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"Init");
          luafn_Init= new LuaCSFunction(Init);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Init);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraFadeFrom");
          luafn_CameraFadeFrom= new LuaCSFunction(CameraFadeFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraFadeFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraFadeTo");
          luafn_CameraFadeTo= new LuaCSFunction(CameraFadeTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraFadeTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ValueTo");
          luafn_ValueTo= new LuaCSFunction(ValueTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ValueTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FadeFrom");
          luafn_FadeFrom= new LuaCSFunction(FadeFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FadeFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FadeTo");
          luafn_FadeTo= new LuaCSFunction(FadeTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FadeTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ColorFrom");
          luafn_ColorFrom= new LuaCSFunction(ColorFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ColorFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ColorTo");
          luafn_ColorTo= new LuaCSFunction(ColorTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ColorTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"AudioFrom");
          luafn_AudioFrom= new LuaCSFunction(AudioFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_AudioFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"AudioTo");
          luafn_AudioTo= new LuaCSFunction(AudioTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_AudioTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Stab");
          luafn_Stab= new LuaCSFunction(Stab);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Stab);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LookFrom");
          luafn_LookFrom= new LuaCSFunction(LookFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LookFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LookTo");
          luafn_LookTo= new LuaCSFunction(LookTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LookTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"MoveTo");
          luafn_MoveTo= new LuaCSFunction(MoveTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_MoveTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"MoveFrom");
          luafn_MoveFrom= new LuaCSFunction(MoveFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_MoveFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"MoveAdd");
          luafn_MoveAdd= new LuaCSFunction(MoveAdd);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_MoveAdd);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"MoveBy");
          luafn_MoveBy= new LuaCSFunction(MoveBy);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_MoveBy);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScaleTo");
          luafn_ScaleTo= new LuaCSFunction(ScaleTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScaleTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScaleFrom");
          luafn_ScaleFrom= new LuaCSFunction(ScaleFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScaleFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScaleAdd");
          luafn_ScaleAdd= new LuaCSFunction(ScaleAdd);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScaleAdd);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScaleBy");
          luafn_ScaleBy= new LuaCSFunction(ScaleBy);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScaleBy);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateTo");
          luafn_RotateTo= new LuaCSFunction(RotateTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateFrom");
          luafn_RotateFrom= new LuaCSFunction(RotateFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateAdd");
          luafn_RotateAdd= new LuaCSFunction(RotateAdd);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateAdd);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateBy");
          luafn_RotateBy= new LuaCSFunction(RotateBy);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateBy);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ShakePosition");
          luafn_ShakePosition= new LuaCSFunction(ShakePosition);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ShakePosition);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ShakeScale");
          luafn_ShakeScale= new LuaCSFunction(ShakeScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ShakeScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ShakeRotation");
          luafn_ShakeRotation= new LuaCSFunction(ShakeRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ShakeRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PunchPosition");
          luafn_PunchPosition= new LuaCSFunction(PunchPosition);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PunchPosition);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PunchRotation");
          luafn_PunchRotation= new LuaCSFunction(PunchRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PunchRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PunchScale");
          luafn_PunchScale= new LuaCSFunction(PunchScale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PunchScale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RectUpdate");
          luafn_RectUpdate= new LuaCSFunction(RectUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RectUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Vector3Update");
          luafn_Vector3Update= new LuaCSFunction(Vector3Update);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Vector3Update);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Vector2Update");
          luafn_Vector2Update= new LuaCSFunction(Vector2Update);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Vector2Update);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FloatUpdate");
          luafn_FloatUpdate= new LuaCSFunction(FloatUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FloatUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FadeUpdate");
          luafn_FadeUpdate= new LuaCSFunction(FadeUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FadeUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ColorUpdate");
          luafn_ColorUpdate= new LuaCSFunction(ColorUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ColorUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"AudioUpdate");
          luafn_AudioUpdate= new LuaCSFunction(AudioUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_AudioUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateUpdate");
          luafn_RotateUpdate= new LuaCSFunction(RotateUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ScaleUpdate");
          luafn_ScaleUpdate= new LuaCSFunction(ScaleUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ScaleUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"MoveUpdate");
          luafn_MoveUpdate= new LuaCSFunction(MoveUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_MoveUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LookUpdate");
          luafn_LookUpdate= new LuaCSFunction(LookUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LookUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PathLength");
          luafn_PathLength= new LuaCSFunction(PathLength);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PathLength);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraTexture");
          luafn_CameraTexture= new LuaCSFunction(CameraTexture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraTexture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PutOnPath");
          luafn_PutOnPath= new LuaCSFunction(PutOnPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PutOnPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"PointOnPath");
          luafn_PointOnPath= new LuaCSFunction(PointOnPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_PointOnPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DrawLine");
          luafn_DrawLine= new LuaCSFunction(DrawLine);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DrawLine);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DrawLineGizmos");
          luafn_DrawLineGizmos= new LuaCSFunction(DrawLineGizmos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DrawLineGizmos);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DrawLineHandles");
          luafn_DrawLineHandles= new LuaCSFunction(DrawLineHandles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DrawLineHandles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DrawPath");
          luafn_DrawPath= new LuaCSFunction(DrawPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DrawPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DrawPathGizmos");
          luafn_DrawPathGizmos= new LuaCSFunction(DrawPathGizmos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DrawPathGizmos);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DrawPathHandles");
          luafn_DrawPathHandles= new LuaCSFunction(DrawPathHandles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DrawPathHandles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraFadeDepth");
          luafn_CameraFadeDepth= new LuaCSFunction(CameraFadeDepth);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraFadeDepth);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraFadeDestroy");
          luafn_CameraFadeDestroy= new LuaCSFunction(CameraFadeDestroy);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraFadeDestroy);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraFadeSwap");
          luafn_CameraFadeSwap= new LuaCSFunction(CameraFadeSwap);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraFadeSwap);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CameraFadeAdd");
          luafn_CameraFadeAdd= new LuaCSFunction(CameraFadeAdd);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CameraFadeAdd);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Resume");
          luafn_Resume= new LuaCSFunction(Resume);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Resume);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Pause");
          luafn_Pause= new LuaCSFunction(Pause);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Pause);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Count");
          luafn_Count= new LuaCSFunction(Count);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Count);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Stop");
          luafn_Stop= new LuaCSFunction(Stop);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Stop);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"StopByName");
          luafn_StopByName= new LuaCSFunction(StopByName);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_StopByName);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Hash");
          luafn_Hash= new LuaCSFunction(Hash);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Hash);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"HashLua");
          luafn_HashLua= new LuaCSFunction(HashLua);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_HashLua);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tweens");
          luafn_get_tweens= new LuaCSFunction(get_tweens);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tweens);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_tweens");
          luafn_set_tweens= new LuaCSFunction(set_tweens);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_tweens);
          LuaDLL.lua_rawset(L, -3);

#endregion       
          }
         }
  #region  declaration       
          private static LuaCSFunction luafn_Init;
          private static LuaCSFunction luafn_CameraFadeFrom;
          private static LuaCSFunction luafn_CameraFadeTo;
          private static LuaCSFunction luafn_ValueTo;
          private static LuaCSFunction luafn_FadeFrom;
          private static LuaCSFunction luafn_FadeTo;
          private static LuaCSFunction luafn_ColorFrom;
          private static LuaCSFunction luafn_ColorTo;
          private static LuaCSFunction luafn_AudioFrom;
          private static LuaCSFunction luafn_AudioTo;
          private static LuaCSFunction luafn_Stab;
          private static LuaCSFunction luafn_LookFrom;
          private static LuaCSFunction luafn_LookTo;
          private static LuaCSFunction luafn_MoveTo;
          private static LuaCSFunction luafn_MoveFrom;
          private static LuaCSFunction luafn_MoveAdd;
          private static LuaCSFunction luafn_MoveBy;
          private static LuaCSFunction luafn_ScaleTo;
          private static LuaCSFunction luafn_ScaleFrom;
          private static LuaCSFunction luafn_ScaleAdd;
          private static LuaCSFunction luafn_ScaleBy;
          private static LuaCSFunction luafn_RotateTo;
          private static LuaCSFunction luafn_RotateFrom;
          private static LuaCSFunction luafn_RotateAdd;
          private static LuaCSFunction luafn_RotateBy;
          private static LuaCSFunction luafn_ShakePosition;
          private static LuaCSFunction luafn_ShakeScale;
          private static LuaCSFunction luafn_ShakeRotation;
          private static LuaCSFunction luafn_PunchPosition;
          private static LuaCSFunction luafn_PunchRotation;
          private static LuaCSFunction luafn_PunchScale;
          private static LuaCSFunction luafn_RectUpdate;
          private static LuaCSFunction luafn_Vector3Update;
          private static LuaCSFunction luafn_Vector2Update;
          private static LuaCSFunction luafn_FloatUpdate;
          private static LuaCSFunction luafn_FadeUpdate;
          private static LuaCSFunction luafn_ColorUpdate;
          private static LuaCSFunction luafn_AudioUpdate;
          private static LuaCSFunction luafn_RotateUpdate;
          private static LuaCSFunction luafn_ScaleUpdate;
          private static LuaCSFunction luafn_MoveUpdate;
          private static LuaCSFunction luafn_LookUpdate;
          private static LuaCSFunction luafn_PathLength;
          private static LuaCSFunction luafn_CameraTexture;
          private static LuaCSFunction luafn_PutOnPath;
          private static LuaCSFunction luafn_PointOnPath;
          private static LuaCSFunction luafn_DrawLine;
          private static LuaCSFunction luafn_DrawLineGizmos;
          private static LuaCSFunction luafn_DrawLineHandles;
          private static LuaCSFunction luafn_DrawPath;
          private static LuaCSFunction luafn_DrawPathGizmos;
          private static LuaCSFunction luafn_DrawPathHandles;
          private static LuaCSFunction luafn_CameraFadeDepth;
          private static LuaCSFunction luafn_CameraFadeDestroy;
          private static LuaCSFunction luafn_CameraFadeSwap;
          private static LuaCSFunction luafn_CameraFadeAdd;
          private static LuaCSFunction luafn_Resume;
          private static LuaCSFunction luafn_Pause;
          private static LuaCSFunction luafn_Count;
          private static LuaCSFunction luafn_Stop;
          private static LuaCSFunction luafn_StopByName;
          private static LuaCSFunction luafn_Hash;
          private static LuaCSFunction luafn_HashLua;
          private static LuaCSFunction luafn_get_tweens;
          private static LuaCSFunction luafn_set_tweens;
          private static LuaCSFunction luafn_get_id;
          private static LuaCSFunction luafn_set_id;
          private static LuaCSFunction luafn_get_type;
          private static LuaCSFunction luafn_set_type;
          private static LuaCSFunction luafn_get_method;
          private static LuaCSFunction luafn_set_method;
          private static LuaCSFunction luafn_get_easeType;
          private static LuaCSFunction luafn_set_easeType;
          private static LuaCSFunction luafn_get_time;
          private static LuaCSFunction luafn_set_time;
          private static LuaCSFunction luafn_get_delay;
          private static LuaCSFunction luafn_set_delay;
          private static LuaCSFunction luafn_get_loopType;
          private static LuaCSFunction luafn_set_loopType;
          private static LuaCSFunction luafn_get_isRunning;
          private static LuaCSFunction luafn_set_isRunning;
          private static LuaCSFunction luafn_get_isPaused;
          private static LuaCSFunction luafn_set_isPaused;
          private static LuaCSFunction luafn_get__name;
          private static LuaCSFunction luafn_set__name;
 #endregion        
  #region  method       
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Init(LuaState L)
          {
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.Init( target);
                 return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeFrom(LuaState L)
          {
          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  System.Single amount = (System.Single)LuaDLL.lua_tonumber(L,1);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,2);

                  iTween.CameraFadeFrom( amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is System.Collections.Hashtable){
                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.CameraFadeFrom( args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeTo(LuaState L)
          {
          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  System.Single amount = (System.Single)LuaDLL.lua_tonumber(L,1);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,2);

                  iTween.CameraFadeTo( amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is System.Collections.Hashtable){
                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.CameraFadeTo( args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ValueTo(LuaState L)
          {
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ValueTo( target, args);
                 return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FadeFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Single alpha = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.FadeFrom( target, alpha, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.FadeFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FadeTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Single alpha = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.FadeTo( target, alpha, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.FadeTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ColorFrom( target, color, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ColorFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ColorTo( target, color, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ColorTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AudioFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Single volume = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single pitch = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,4);

                  iTween.AudioFrom( target, volume, pitch, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.AudioFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AudioTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Single volume = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single pitch = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,4);

                  iTween.AudioTo( target, volume, pitch, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.AudioTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Stab(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.AudioClip&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.AudioClip audioclip = (UnityEngine.AudioClip)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single delay = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.Stab( target, audioclip, delay);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.Stab( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 looktarget = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.LookFrom( target, looktarget, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.LookFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 looktarget = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.LookTo( target, looktarget, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.LookTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 position = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveTo( target, position, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.MoveTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 position = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveFrom( target, position, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.MoveFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveAdd(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveAdd( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.MoveAdd( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveBy(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveBy( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.MoveBy( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 scale = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleTo( target, scale, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ScaleTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 scale = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleFrom( target, scale, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ScaleFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleAdd(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleAdd( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ScaleAdd( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleBy(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleBy( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ScaleBy( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTo(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 rotation = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateTo( target, rotation, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.RotateTo( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateFrom(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 rotation = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateFrom( target, rotation, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.RotateFrom( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateAdd(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateAdd( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.RotateAdd( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateBy(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateBy( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.RotateBy( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ShakePosition(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ShakePosition( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ShakePosition( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ShakeScale(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ShakeScale( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ShakeScale( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ShakeRotation(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ShakeRotation( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ShakeRotation( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PunchPosition(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PunchPosition( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.PunchPosition( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PunchRotation(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PunchRotation( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.PunchRotation( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PunchScale(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 amount = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PunchScale( target, amount, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.PunchScale( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RectUpdate(LuaState L)
          {
                  UnityEngine.Rect currentValue = (UnityEngine.Rect)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Rect targetValue = (UnityEngine.Rect)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single speed = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Rect rectupdate= iTween.RectUpdate( currentValue, targetValue, speed);
                  ToLuaCS.lua.translator.push(L,rectupdate); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Vector3Update(LuaState L)
          {
                  UnityEngine.Vector3 currentValue = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 targetValue = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single speed = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 vector3update= iTween.Vector3Update( currentValue, targetValue, speed);
                  ToLuaCS.lua.translator.push(L,vector3update); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Vector2Update(LuaState L)
          {
                  UnityEngine.Vector2 currentValue = (UnityEngine.Vector2)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector2 targetValue = (UnityEngine.Vector2)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single speed = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector2 vector2update= iTween.Vector2Update( currentValue, targetValue, speed);
                  ToLuaCS.lua.translator.push(L,vector2update); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FloatUpdate(LuaState L)
          {
                  System.Single currentValue = (System.Single)LuaDLL.lua_tonumber(L,1);

                  System.Single targetValue = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single speed = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single floatupdate= iTween.FloatUpdate( currentValue, targetValue, speed);
                  ToLuaCS.lua.translator.push(L,floatupdate); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FadeUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Single alpha = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.FadeUpdate( target, alpha, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.FadeUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ColorUpdate( target, color, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ColorUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AudioUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Single volume = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single pitch = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,4);

                  iTween.AudioUpdate( target, volume, pitch, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.AudioUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 rotation = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.RotateUpdate( target, rotation, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.RotateUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScaleUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 scale = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.ScaleUpdate( target, scale, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.ScaleUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 position = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.MoveUpdate( target, position, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.MoveUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookUpdate(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3 looktarget = (UnityEngine.Vector3)ToLuaCS.lua.translator.getObject(L,2);

                  System.Single time = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.LookUpdate( target, looktarget, time);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is System.Collections.Hashtable){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable args = (System.Collections.Hashtable)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.LookUpdate( target, args);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PathLength(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  System.Single pathlength= iTween.PathLength( path);
                  ToLuaCS.lua.translator.push(L,pathlength); 
                  return 1;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  System.Single pathlength= iTween.PathLength( path);
                  ToLuaCS.lua.translator.push(L,pathlength); 
                  return 1;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraTexture(LuaState L)
          {
                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Texture2D cameratexture= iTween.CameraTexture( color);
                  ToLuaCS.lua.translator.push(L,cameratexture); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PutOnPath(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Transform[]&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,2);

                  System.Single percent = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target, path, percent);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Transform[]&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Transform target = (UnityEngine.Transform)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,2);

                  System.Single percent = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target, path, percent);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3[]&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,2);

                  System.Single percent = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target, path, percent);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Vector3[]&& LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Transform target = (UnityEngine.Transform)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,2);

                  System.Single percent = (System.Single)LuaDLL.lua_tonumber(L,3);

                  iTween.PutOnPath( target, path, percent);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PointOnPath(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  System.Single percent = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3 pointonpath= iTween.PointOnPath( path, percent);
                  ToLuaCS.lua.translator.push(L,pointonpath); 
                  return 1;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  System.Single percent = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3 pointonpath= iTween.PointOnPath( path, percent);
                  ToLuaCS.lua.translator.push(L,pointonpath); 
                  return 1;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawLine(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Transform[] line = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawLine( line, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Vector3[] line = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawLine( line, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] line = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawLine( line);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] line = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawLine( line);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawLineGizmos(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Transform[] line = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawLineGizmos( line, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Vector3[] line = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawLineGizmos( line, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] line = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawLineGizmos( line);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] line = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawLineGizmos( line);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawLineHandles(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Transform[] line = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawLineHandles( line, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Vector3[] line = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawLineHandles( line, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] line = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawLineHandles( line);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] line = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawLineHandles( line);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawPath(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawPath( path, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawPath( path, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawPath( path);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawPath( path);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawPathGizmos(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawPathGizmos( path, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawPathGizmos( path, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawPathGizmos( path);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawPathGizmos( path);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DrawPathHandles(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawPathHandles( path, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]&& ToLuaCS.lua.translator.getObject(L, 2) is UnityEngine.Color){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.Color color = (UnityEngine.Color)ToLuaCS.lua.translator.getObject(L,2);

                  iTween.DrawPathHandles( path, color);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Vector3[]){
                  UnityEngine.Vector3[] path = (UnityEngine.Vector3[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawPathHandles( path);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Transform[]){
                  UnityEngine.Transform[] path = (UnityEngine.Transform[])ToLuaCS.lua.translator.getObject(L,1);

                  iTween.DrawPathHandles( path);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeDepth(LuaState L)
          {
                  System.Int32 depth = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  iTween.CameraFadeDepth( depth);
                 return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeDestroy(LuaState L)
          {
                  iTween.CameraFadeDestroy();
                 return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeSwap(LuaState L)
          {
                  UnityEngine.Texture2D texture = (UnityEngine.Texture2D)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.CameraFadeSwap( texture);
                 return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CameraFadeAdd(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Texture2D&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Texture2D texture = (UnityEngine.Texture2D)ToLuaCS.lua.translator.getObject(L,1);

                  System.Int32 depth = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.GameObject camerafadeadd= iTween.CameraFadeAdd( texture, depth);
                  ToLuaCS.lua.translator.push(L,camerafadeadd); 
                  return 1;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.Texture2D){
                  UnityEngine.Texture2D texture = (UnityEngine.Texture2D)ToLuaCS.lua.translator.getObject(L,1);

                  UnityEngine.GameObject camerafadeadd= iTween.CameraFadeAdd( texture);
                  ToLuaCS.lua.translator.push(L,camerafadeadd); 
                  return 1;
          }

          if(true){
                  UnityEngine.GameObject camerafadeadd= iTween.CameraFadeAdd();
                  ToLuaCS.lua.translator.push(L,camerafadeadd); 
                  return 1;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Resume(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,3);

                  iTween.Resume( target, type, includechildren);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  iTween.Resume( target, type);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,2);

                  iTween.Resume( target, includechildren);
                 return 0;
          }

          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type =  LuaDLL.lua_tostring(L,1); 


                  iTween.Resume( type);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.Resume( target);
                 return 0;
          }

          if(true){
                  iTween.Resume();
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Pause(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,3);

                  iTween.Pause( target, type, includechildren);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  iTween.Pause( target, type);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,2);

                  iTween.Pause( target, includechildren);
                 return 0;
          }

          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type =  LuaDLL.lua_tostring(L,1); 


                  iTween.Pause( type);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.Pause( target);
                 return 0;
          }

          if(true){
                  iTween.Pause();
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Count(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  System.Int32 count= iTween.Count( target, type);
                  ToLuaCS.lua.translator.push(L,count); 
                  return 1;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Int32 count= iTween.Count( target);
                  ToLuaCS.lua.translator.push(L,count); 
                  return 1;
          }

          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type =  LuaDLL.lua_tostring(L,1); 


                  System.Int32 count= iTween.Count( type);
                  ToLuaCS.lua.translator.push(L,count); 
                  return 1;
          }

          if(true){
                  System.Int32 count= iTween.Count();
                  ToLuaCS.lua.translator.push(L,count); 
                  return 1;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Stop(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,3);

                  iTween.Stop( target, type, includechildren);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,2);

                  iTween.Stop( target, includechildren);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String type =  LuaDLL.lua_tostring(L,2); 


                  iTween.Stop( target, type);
                 return 0;
          }

          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String type =  LuaDLL.lua_tostring(L,1); 


                  iTween.Stop( type);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  iTween.Stop( target);
                 return 0;
          }

          if(true){
                  iTween.Stop();
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int StopByName(LuaState L)
          {
          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String name =  LuaDLL.lua_tostring(L,2); 


                  System.Boolean includechildren =  LuaDLL.lua_toboolean(L,3);

                  iTween.StopByName( target, name, includechildren);
                 return 0;
          }

          if( ToLuaCS.lua.translator.getObject(L, 1) is UnityEngine.GameObject&& LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING ){
                  UnityEngine.GameObject target = (UnityEngine.GameObject)ToLuaCS.lua.translator.getObject(L,1);

                  System.String name =  LuaDLL.lua_tostring(L,2); 


                  iTween.StopByName( target, name);
                 return 0;
          }

          if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING ){
                  System.String name =  LuaDLL.lua_tostring(L,1); 


                  iTween.StopByName( name);
                 return 0;
          }

          return 0;
          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Hash(LuaState L)
          {
                  System.Object[] args = (System.Object[])ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable hash= iTween.Hash( args);
                  ToLuaCS.lua.translator.push(L,hash); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int HashLua(LuaState L)
          {
                  LuaInterface.LuaTable args = (LuaInterface.LuaTable)ToLuaCS.lua.translator.getObject(L,1);

                  System.Collections.Hashtable hashlua= iTween.HashLua( args);
                  ToLuaCS.lua.translator.push(L,hashlua); 
                  return 1;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tweens(LuaState L)
          {
                  var val=   iTween .tweens;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tweens(LuaState L)
          {
                   var val= ToLuaCS.lua.translator.getObject(L, 1);
                  iTween.tweens= (System.Collections.Generic.List<System.Collections.Hashtable>)val;
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_id(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.id;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_id(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.id= LuaDLL.lua_tostring(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_type(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.type;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_type(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.type= LuaDLL.lua_tostring(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_method(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.method;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_method(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.method= LuaDLL.lua_tostring(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_easeType(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.easeType;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_easeType(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val= ToLuaCS.lua.translator.getObject(L, 2);
                  target.easeType= (iTween.EaseType)val;
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_time(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.time;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_time(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.time= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_delay(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.delay;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_delay(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.delay= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_loopType(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.loopType;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_loopType(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val= ToLuaCS.lua.translator.getObject(L, 2);
                  target.loopType= (iTween.LoopType)val;
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isRunning(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.isRunning;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isRunning(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.isRunning= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isPaused(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target.isPaused;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isPaused(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target.isPaused= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }

          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get__name(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  var val=  target._name;
                  ToLuaCS.lua.translator.push(L,val);
                  return 1;

          }
           
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set__name(LuaState L)
          {
                  object original = ToLuaCS.lua.translator.getObject(L, 1);
                  iTween target=  original as iTween;
                  target._name= LuaDLL.lua_tostring(L,2);
                  return 0;

          }

  #endregion       
}

