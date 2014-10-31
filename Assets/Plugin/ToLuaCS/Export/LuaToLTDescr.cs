using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLTDescr {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LTDescr).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LTDescr).AssemblyQualifiedName);
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
          System.Type superT = typeof(LTDescr).BaseType;
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
          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"cancel");
          luafn_cancel= new LuaCSFunction(cancel);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_cancel);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_uniqueId");
          luafn_get_uniqueId= new LuaCSFunction(get_uniqueId);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_uniqueId);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_id");
          luafn_get_id= new LuaCSFunction(get_id);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_id);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"reset");
          luafn_reset= new LuaCSFunction(reset);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_reset);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"pause");
          luafn_pause= new LuaCSFunction(pause);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_pause);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"resume");
          luafn_resume= new LuaCSFunction(resume);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_resume);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setAxis");
          luafn_setAxis= new LuaCSFunction(setAxis);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setAxis);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setDelay");
          luafn_setDelay= new LuaCSFunction(setDelay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setDelay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setEase");
          luafn_setEase= new LuaCSFunction(setEase);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setEase);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setTo");
          luafn_setTo= new LuaCSFunction(setTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setFrom");
          luafn_setFrom= new LuaCSFunction(setFrom);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setFrom);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setHasInitialized");
          luafn_setHasInitialized= new LuaCSFunction(setHasInitialized);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setHasInitialized);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setId");
          luafn_setId= new LuaCSFunction(setId);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setId);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setRepeat");
          luafn_setRepeat= new LuaCSFunction(setRepeat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setRepeat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setLoopType");
          luafn_setLoopType= new LuaCSFunction(setLoopType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setLoopType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setUseEstimatedTime");
          luafn_setUseEstimatedTime= new LuaCSFunction(setUseEstimatedTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setUseEstimatedTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setUseFrames");
          luafn_setUseFrames= new LuaCSFunction(setUseFrames);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setUseFrames);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setLoopCount");
          luafn_setLoopCount= new LuaCSFunction(setLoopCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setLoopCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setLoopOnce");
          luafn_setLoopOnce= new LuaCSFunction(setLoopOnce);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setLoopOnce);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setLoopClamp");
          luafn_setLoopClamp= new LuaCSFunction(setLoopClamp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setLoopClamp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setLoopPingPong");
          luafn_setLoopPingPong= new LuaCSFunction(setLoopPingPong);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setLoopPingPong);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnComplete");
          luafn_setOnComplete= new LuaCSFunction(setOnComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnCompleteParam");
          luafn_setOnCompleteParam= new LuaCSFunction(setOnCompleteParam);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnCompleteParam);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnUpdate");
          luafn_setOnUpdate= new LuaCSFunction(setOnUpdate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnUpdate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnUpdateObject");
          luafn_setOnUpdateObject= new LuaCSFunction(setOnUpdateObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnUpdateObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnUpdateVector3");
          luafn_setOnUpdateVector3= new LuaCSFunction(setOnUpdateVector3);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnUpdateVector3);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnUpdateColor");
          luafn_setOnUpdateColor= new LuaCSFunction(setOnUpdateColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnUpdateColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnUpdateParam");
          luafn_setOnUpdateParam= new LuaCSFunction(setOnUpdateParam);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnUpdateParam);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOrientToPath");
          luafn_setOrientToPath= new LuaCSFunction(setOrientToPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOrientToPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOrientToPath2d");
          luafn_setOrientToPath2d= new LuaCSFunction(setOrientToPath2d);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOrientToPath2d);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setRect");
          luafn_setRect= new LuaCSFunction(setRect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setRect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setPath");
          luafn_setPath= new LuaCSFunction(setPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setPoint");
          luafn_setPoint= new LuaCSFunction(setPoint);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setPoint);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setDestroyOnComplete");
          luafn_setDestroyOnComplete= new LuaCSFunction(setDestroyOnComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setDestroyOnComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setAudio");
          luafn_setAudio= new LuaCSFunction(setAudio);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setAudio);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"setOnCompleteOnRepeat");
          luafn_setOnCompleteOnRepeat= new LuaCSFunction(setOnCompleteOnRepeat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_setOnCompleteOnRepeat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_toggle");
          luafn_get_toggle= new LuaCSFunction(get_toggle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_toggle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_toggle");
          luafn_set_toggle= new LuaCSFunction(set_toggle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_toggle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_useEstimatedTime");
          luafn_get_useEstimatedTime= new LuaCSFunction(get_useEstimatedTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_useEstimatedTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_useEstimatedTime");
          luafn_set_useEstimatedTime= new LuaCSFunction(set_useEstimatedTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_useEstimatedTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_useFrames");
          luafn_get_useFrames= new LuaCSFunction(get_useFrames);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_useFrames);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_useFrames");
          luafn_set_useFrames= new LuaCSFunction(set_useFrames);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_useFrames);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hasInitiliazed");
          luafn_get_hasInitiliazed= new LuaCSFunction(get_hasInitiliazed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hasInitiliazed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hasInitiliazed");
          luafn_set_hasInitiliazed= new LuaCSFunction(set_hasInitiliazed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hasInitiliazed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hasPhysics");
          luafn_get_hasPhysics= new LuaCSFunction(get_hasPhysics);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hasPhysics);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hasPhysics");
          luafn_set_hasPhysics= new LuaCSFunction(set_hasPhysics);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hasPhysics);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_passed");
          luafn_get_passed= new LuaCSFunction(get_passed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_passed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_passed");
          luafn_set_passed= new LuaCSFunction(set_passed);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_passed);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_delay");
          luafn_get_delay= new LuaCSFunction(get_delay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_delay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_delay");
          luafn_set_delay= new LuaCSFunction(set_delay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_delay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_time");
          luafn_get_time= new LuaCSFunction(get_time);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_time);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_time");
          luafn_set_time= new LuaCSFunction(set_time);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_time);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_lastVal");
          luafn_get_lastVal= new LuaCSFunction(get_lastVal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_lastVal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_lastVal");
          luafn_set_lastVal= new LuaCSFunction(set_lastVal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_lastVal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_loopCount");
          luafn_get_loopCount= new LuaCSFunction(get_loopCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_loopCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_loopCount");
          luafn_set_loopCount= new LuaCSFunction(set_loopCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_loopCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_counter");
          luafn_get_counter= new LuaCSFunction(get_counter);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_counter);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_counter");
          luafn_set_counter= new LuaCSFunction(set_counter);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_counter);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_direction");
          luafn_get_direction= new LuaCSFunction(get_direction);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_direction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_direction");
          luafn_set_direction= new LuaCSFunction(set_direction);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_direction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_destroyOnComplete");
          luafn_get_destroyOnComplete= new LuaCSFunction(get_destroyOnComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_destroyOnComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_destroyOnComplete");
          luafn_set_destroyOnComplete= new LuaCSFunction(set_destroyOnComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_destroyOnComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_trans");
          luafn_get_trans= new LuaCSFunction(get_trans);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_trans);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_trans");
          luafn_set_trans= new LuaCSFunction(set_trans);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_trans);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_ltRect");
          luafn_get_ltRect= new LuaCSFunction(get_ltRect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_ltRect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_ltRect");
          luafn_set_ltRect= new LuaCSFunction(set_ltRect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_ltRect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_from");
          luafn_get_from= new LuaCSFunction(get_from);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_from);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_from");
          luafn_set_from= new LuaCSFunction(set_from);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_from);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_to");
          luafn_get_to= new LuaCSFunction(get_to);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_to);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_to");
          luafn_set_to= new LuaCSFunction(set_to);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_to);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_diff");
          luafn_get_diff= new LuaCSFunction(get_diff);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_diff);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_diff");
          luafn_set_diff= new LuaCSFunction(set_diff);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_diff);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_point");
          luafn_get_point= new LuaCSFunction(get_point);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_point);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_point");
          luafn_set_point= new LuaCSFunction(set_point);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_point);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_axis");
          luafn_get_axis= new LuaCSFunction(get_axis);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_axis);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_axis");
          luafn_set_axis= new LuaCSFunction(set_axis);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_axis);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_origRotation");
          luafn_get_origRotation= new LuaCSFunction(get_origRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_origRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_origRotation");
          luafn_set_origRotation= new LuaCSFunction(set_origRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_origRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_path");
          luafn_get_path= new LuaCSFunction(get_path);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_path);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_path");
          luafn_set_path= new LuaCSFunction(set_path);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_path);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_spline");
          luafn_get_spline= new LuaCSFunction(get_spline);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_spline);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_spline");
          luafn_set_spline= new LuaCSFunction(set_spline);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_spline);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_type");
          luafn_get_type= new LuaCSFunction(get_type);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_type);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_type");
          luafn_set_type= new LuaCSFunction(set_type);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_type);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tweenType");
          luafn_get_tweenType= new LuaCSFunction(get_tweenType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tweenType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_tweenType");
          luafn_set_tweenType= new LuaCSFunction(set_tweenType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_tweenType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_animationCurve");
          luafn_get_animationCurve= new LuaCSFunction(get_animationCurve);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_animationCurve);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_animationCurve");
          luafn_set_animationCurve= new LuaCSFunction(set_animationCurve);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_animationCurve);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_loopType");
          luafn_get_loopType= new LuaCSFunction(get_loopType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_loopType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_loopType");
          luafn_set_loopType= new LuaCSFunction(set_loopType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_loopType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUpdateFloat");
          luafn_get_onUpdateFloat= new LuaCSFunction(get_onUpdateFloat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUpdateFloat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onUpdateFloat");
          luafn_set_onUpdateFloat= new LuaCSFunction(set_onUpdateFloat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onUpdateFloat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUpdateFloatObject");
          luafn_get_onUpdateFloatObject= new LuaCSFunction(get_onUpdateFloatObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUpdateFloatObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onUpdateFloatObject");
          luafn_set_onUpdateFloatObject= new LuaCSFunction(set_onUpdateFloatObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onUpdateFloatObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUpdateVector3");
          luafn_get_onUpdateVector3= new LuaCSFunction(get_onUpdateVector3);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUpdateVector3);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onUpdateVector3");
          luafn_set_onUpdateVector3= new LuaCSFunction(set_onUpdateVector3);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onUpdateVector3);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUpdateVector3Object");
          luafn_get_onUpdateVector3Object= new LuaCSFunction(get_onUpdateVector3Object);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUpdateVector3Object);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onUpdateVector3Object");
          luafn_set_onUpdateVector3Object= new LuaCSFunction(set_onUpdateVector3Object);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onUpdateVector3Object);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUpdateColor");
          luafn_get_onUpdateColor= new LuaCSFunction(get_onUpdateColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUpdateColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onUpdateColor");
          luafn_set_onUpdateColor= new LuaCSFunction(set_onUpdateColor);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onUpdateColor);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onComplete");
          luafn_get_onComplete= new LuaCSFunction(get_onComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onComplete");
          luafn_set_onComplete= new LuaCSFunction(set_onComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onLuaComplete");
          luafn_get_onLuaComplete= new LuaCSFunction(get_onLuaComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onLuaComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onLuaComplete");
          luafn_set_onLuaComplete= new LuaCSFunction(set_onLuaComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onLuaComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onCompleteObject");
          luafn_get_onCompleteObject= new LuaCSFunction(get_onCompleteObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onCompleteObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onCompleteObject");
          luafn_set_onCompleteObject= new LuaCSFunction(set_onCompleteObject);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onCompleteObject);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onCompleteParam");
          luafn_get_onCompleteParam= new LuaCSFunction(get_onCompleteParam);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onCompleteParam);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onCompleteParam");
          luafn_set_onCompleteParam= new LuaCSFunction(set_onCompleteParam);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onCompleteParam);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onUpdateParam");
          luafn_get_onUpdateParam= new LuaCSFunction(get_onUpdateParam);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onUpdateParam);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onUpdateParam");
          luafn_set_onUpdateParam= new LuaCSFunction(set_onUpdateParam);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onUpdateParam);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onCompleteOnRepeat");
          luafn_get_onCompleteOnRepeat= new LuaCSFunction(get_onCompleteOnRepeat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onCompleteOnRepeat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onCompleteOnRepeat");
          luafn_set_onCompleteOnRepeat= new LuaCSFunction(set_onCompleteOnRepeat);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onCompleteOnRepeat);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_optional");
          luafn_get_optional= new LuaCSFunction(get_optional);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_optional);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_optional");
          luafn_set_optional= new LuaCSFunction(set_optional);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_optional);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_cancel;
          private static LuaCSFunction luafn_get_uniqueId;
          private static LuaCSFunction luafn_get_id;
          private static LuaCSFunction luafn_reset;
          private static LuaCSFunction luafn_pause;
          private static LuaCSFunction luafn_resume;
          private static LuaCSFunction luafn_setAxis;
          private static LuaCSFunction luafn_setDelay;
          private static LuaCSFunction luafn_setEase;
          private static LuaCSFunction luafn_setTo;
          private static LuaCSFunction luafn_setFrom;
          private static LuaCSFunction luafn_setHasInitialized;
          private static LuaCSFunction luafn_setId;
          private static LuaCSFunction luafn_setRepeat;
          private static LuaCSFunction luafn_setLoopType;
          private static LuaCSFunction luafn_setUseEstimatedTime;
          private static LuaCSFunction luafn_setUseFrames;
          private static LuaCSFunction luafn_setLoopCount;
          private static LuaCSFunction luafn_setLoopOnce;
          private static LuaCSFunction luafn_setLoopClamp;
          private static LuaCSFunction luafn_setLoopPingPong;
          private static LuaCSFunction luafn_setOnComplete;
          private static LuaCSFunction luafn_setOnCompleteParam;
          private static LuaCSFunction luafn_setOnUpdate;
          private static LuaCSFunction luafn_setOnUpdateObject;
          private static LuaCSFunction luafn_setOnUpdateVector3;
          private static LuaCSFunction luafn_setOnUpdateColor;
          private static LuaCSFunction luafn_setOnUpdateParam;
          private static LuaCSFunction luafn_setOrientToPath;
          private static LuaCSFunction luafn_setOrientToPath2d;
          private static LuaCSFunction luafn_setRect;
          private static LuaCSFunction luafn_setPath;
          private static LuaCSFunction luafn_setPoint;
          private static LuaCSFunction luafn_setDestroyOnComplete;
          private static LuaCSFunction luafn_setAudio;
          private static LuaCSFunction luafn_setOnCompleteOnRepeat;
          private static LuaCSFunction luafn_get_toggle;
          private static LuaCSFunction luafn_set_toggle;
          private static LuaCSFunction luafn_get_useEstimatedTime;
          private static LuaCSFunction luafn_set_useEstimatedTime;
          private static LuaCSFunction luafn_get_useFrames;
          private static LuaCSFunction luafn_set_useFrames;
          private static LuaCSFunction luafn_get_hasInitiliazed;
          private static LuaCSFunction luafn_set_hasInitiliazed;
          private static LuaCSFunction luafn_get_hasPhysics;
          private static LuaCSFunction luafn_set_hasPhysics;
          private static LuaCSFunction luafn_get_passed;
          private static LuaCSFunction luafn_set_passed;
          private static LuaCSFunction luafn_get_delay;
          private static LuaCSFunction luafn_set_delay;
          private static LuaCSFunction luafn_get_time;
          private static LuaCSFunction luafn_set_time;
          private static LuaCSFunction luafn_get_lastVal;
          private static LuaCSFunction luafn_set_lastVal;
          private static LuaCSFunction luafn_get_loopCount;
          private static LuaCSFunction luafn_set_loopCount;
          private static LuaCSFunction luafn_get_counter;
          private static LuaCSFunction luafn_set_counter;
          private static LuaCSFunction luafn_get_direction;
          private static LuaCSFunction luafn_set_direction;
          private static LuaCSFunction luafn_get_destroyOnComplete;
          private static LuaCSFunction luafn_set_destroyOnComplete;
          private static LuaCSFunction luafn_get_trans;
          private static LuaCSFunction luafn_set_trans;
          private static LuaCSFunction luafn_get_ltRect;
          private static LuaCSFunction luafn_set_ltRect;
          private static LuaCSFunction luafn_get_from;
          private static LuaCSFunction luafn_set_from;
          private static LuaCSFunction luafn_get_to;
          private static LuaCSFunction luafn_set_to;
          private static LuaCSFunction luafn_get_diff;
          private static LuaCSFunction luafn_set_diff;
          private static LuaCSFunction luafn_get_point;
          private static LuaCSFunction luafn_set_point;
          private static LuaCSFunction luafn_get_axis;
          private static LuaCSFunction luafn_set_axis;
          private static LuaCSFunction luafn_get_origRotation;
          private static LuaCSFunction luafn_set_origRotation;
          private static LuaCSFunction luafn_get_path;
          private static LuaCSFunction luafn_set_path;
          private static LuaCSFunction luafn_get_spline;
          private static LuaCSFunction luafn_set_spline;
          private static LuaCSFunction luafn_get_type;
          private static LuaCSFunction luafn_set_type;
          private static LuaCSFunction luafn_get_tweenType;
          private static LuaCSFunction luafn_set_tweenType;
          private static LuaCSFunction luafn_get_animationCurve;
          private static LuaCSFunction luafn_set_animationCurve;
          private static LuaCSFunction luafn_get_loopType;
          private static LuaCSFunction luafn_set_loopType;
          private static LuaCSFunction luafn_get_onUpdateFloat;
          private static LuaCSFunction luafn_set_onUpdateFloat;
          private static LuaCSFunction luafn_get_onUpdateFloatObject;
          private static LuaCSFunction luafn_set_onUpdateFloatObject;
          private static LuaCSFunction luafn_get_onUpdateVector3;
          private static LuaCSFunction luafn_set_onUpdateVector3;
          private static LuaCSFunction luafn_get_onUpdateVector3Object;
          private static LuaCSFunction luafn_set_onUpdateVector3Object;
          private static LuaCSFunction luafn_get_onUpdateColor;
          private static LuaCSFunction luafn_set_onUpdateColor;
          private static LuaCSFunction luafn_get_onComplete;
          private static LuaCSFunction luafn_set_onComplete;
          private static LuaCSFunction luafn_get_onLuaComplete;
          private static LuaCSFunction luafn_set_onLuaComplete;
          private static LuaCSFunction luafn_get_onCompleteObject;
          private static LuaCSFunction luafn_set_onCompleteObject;
          private static LuaCSFunction luafn_get_onCompleteParam;
          private static LuaCSFunction luafn_set_onCompleteParam;
          private static LuaCSFunction luafn_get_onUpdateParam;
          private static LuaCSFunction luafn_set_onUpdateParam;
          private static LuaCSFunction luafn_get_onCompleteOnRepeat;
          private static LuaCSFunction luafn_set_onCompleteOnRepeat;
          private static LuaCSFunction luafn_get_optional;
          private static LuaCSFunction luafn_set_optional;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int cancel(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr cancel= target.cancel();
                  ToLuaCS.push(L,cancel); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_uniqueId(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  System.Int32 uniqueId= target.uniqueId;
                  ToLuaCS.push(L,uniqueId); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_id(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  System.Int32 id= target.id;
                  ToLuaCS.push(L,id); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int reset(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  target.reset();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int pause(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr pause= target.pause();
                  ToLuaCS.push(L,pause); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int resume(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr resume= target.resume();
                  ToLuaCS.push(L,resume); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setAxis(LuaState L)
          {
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setaxis= target.setAxis( axis_);
                  ToLuaCS.push(L,setaxis); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setDelay(LuaState L)
          {
                  System.Single delay_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setdelay= target.setDelay( delay_);
                  ToLuaCS.push(L,setdelay); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setEase(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.AnimationCurve)
              {
                  UnityEngine.AnimationCurve easeCurve_ = (UnityEngine.AnimationCurve)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setease= target.setEase( easeCurve_);
                  ToLuaCS.push(L,setease); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is LeanTweenType)
              {
                  LeanTweenType easeType_ = (LeanTweenType)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setease= target.setEase( easeType_);
                  ToLuaCS.push(L,setease); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setTo(LuaState L)
          {
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setto= target.setTo( to_);
                  ToLuaCS.push(L,setto); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setFrom(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setfrom= target.setFrom( from_);
                  ToLuaCS.push(L,setfrom); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setHasInitialized(LuaState L)
          {
                  System.Boolean has_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr sethasinitialized= target.setHasInitialized( has_);
                  ToLuaCS.push(L,sethasinitialized); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setId(LuaState L)
          {
                  System.UInt32 id_ = (System.UInt32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setid= target.setId( id_);
                  ToLuaCS.push(L,setid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setRepeat(LuaState L)
          {
                  System.Int32 repeat_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setrepeat= target.setRepeat( repeat_);
                  ToLuaCS.push(L,setrepeat); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setLoopType(LuaState L)
          {
                  LeanTweenType loopType_ = (LeanTweenType)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setlooptype= target.setLoopType( loopType_);
                  ToLuaCS.push(L,setlooptype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setUseEstimatedTime(LuaState L)
          {
                  System.Boolean useEstimatedTime_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setuseestimatedtime= target.setUseEstimatedTime( useEstimatedTime_);
                  ToLuaCS.push(L,setuseestimatedtime); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setUseFrames(LuaState L)
          {
                  System.Boolean useFrames_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setuseframes= target.setUseFrames( useFrames_);
                  ToLuaCS.push(L,setuseframes); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setLoopCount(LuaState L)
          {
                  System.Int32 loopCount_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setloopcount= target.setLoopCount( loopCount_);
                  ToLuaCS.push(L,setloopcount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setLoopOnce(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setlooponce= target.setLoopOnce();
                  ToLuaCS.push(L,setlooponce); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setLoopClamp(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setloopclamp= target.setLoopClamp();
                  ToLuaCS.push(L,setloopclamp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setLoopPingPong(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setlooppingpong= target.setLoopPingPong();
                  ToLuaCS.push(L,setlooppingpong); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnComplete(LuaState L)
          {
              //if( ToLuaCS.getObject(L, 2) is System.Action<System.Object> && ToLuaCS.getObject(L, 3) is System.Object)
              //{
              //    System.Action<System.Object> onComplete_ = (System.Action<System.Object>)ToLuaCS.getObject(L,2);
              //    System.Object onCompleteParam_ = (System.Object)ToLuaCS.getObject(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setoncomplete= target.setOnComplete( onComplete_, onCompleteParam_);
              //    ToLuaCS.push(L,setoncomplete); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 2) is System.Action<System.Object>)
              //{
              //    System.Action<System.Object> onComplete_ = (System.Action<System.Object>)ToLuaCS.getObject(L,2);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setoncomplete= target.setOnComplete( onComplete_);
              //    ToLuaCS.push(L,setoncomplete); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 2) is System.Action)
              //{
              //    System.Action onComplete_ = (System.Action)ToLuaCS.getObject(L,2);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setoncomplete= target.setOnComplete( onComplete_);
              //    ToLuaCS.push(L,setoncomplete); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 2) is LuaInterface.LuaFunction)
              {
                  LuaInterface.LuaFunction onComplete_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setoncomplete= target.setOnComplete( onComplete_);
                  ToLuaCS.push(L,setoncomplete); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnCompleteParam(LuaState L)
          {
                  System.Object onCompleteParam_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setoncompleteparam= target.setOnCompleteParam( onCompleteParam_);
                  ToLuaCS.push(L,setoncompleteparam); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnUpdate(LuaState L)
          {
              //if( ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is System.Object)
              //{
              //    System.Action<UnityEngine.Vector3> onUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
              //    System.Object onUpdateParam_ = (System.Object)ToLuaCS.getObject(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setonupdate= target.setOnUpdate( onUpdate_, onUpdateParam_);
              //    ToLuaCS.push(L,setonupdate); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is System.Object)
              //{
              //    System.Action<UnityEngine.Vector3> onUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
              //    System.Object onUpdateParam_ = (System.Object)ToLuaCS.getObject(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setonupdate= target.setOnUpdate( onUpdate_, onUpdateParam_);
              //    ToLuaCS.push(L,setonupdate); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 2) is System.Action<System.Single> && ToLuaCS.getObject(L, 3) is System.Object)
              //{
              //    System.Action<System.Single> onUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
              //    System.Object onUpdateParam_ = (System.Object)ToLuaCS.getObject(L,3);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setonupdate= target.setOnUpdate( onUpdate_, onUpdateParam_);
              //    ToLuaCS.push(L,setonupdate); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 2) is System.Action<System.Single>)
              //{
              //    System.Action<System.Single> onUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);

              //    object original = ToLuaCS.getObject(L, 1);
              //    LTDescr target= (LTDescr) original ;
              //    LTDescr setonupdate= target.setOnUpdate( onUpdate_);
              //    ToLuaCS.push(L,setonupdate); 
              //    return 1;

              //}
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnUpdateObject(LuaState L)
          {
                  //System.Action<System.Single> onUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);

                  //object original = ToLuaCS.getObject(L, 1);
                  //LTDescr target= (LTDescr) original ;
                  //LTDescr setonupdateobject= target.setOnUpdateObject( onUpdate_);
                  //ToLuaCS.push(L,setonupdateobject); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnUpdateVector3(LuaState L)
          {
                  System.Action<UnityEngine.Vector3> onUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setonupdatevector3= target.setOnUpdateVector3( onUpdate_);
                  ToLuaCS.push(L,setonupdatevector3); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnUpdateColor(LuaState L)
          {
                  System.Action<UnityEngine.Color> onUpdate_ = (System.Action<UnityEngine.Color>)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setonupdatecolor= target.setOnUpdateColor( onUpdate_);
                  ToLuaCS.push(L,setonupdatecolor); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnUpdateParam(LuaState L)
          {
                  System.Object onUpdateParam_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setonupdateparam= target.setOnUpdateParam( onUpdateParam_);
                  ToLuaCS.push(L,setonupdateparam); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOrientToPath(LuaState L)
          {
                  System.Boolean doesOrient_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setorienttopath= target.setOrientToPath( doesOrient_);
                  ToLuaCS.push(L,setorienttopath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOrientToPath2d(LuaState L)
          {
                  System.Boolean doesOrient2d_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setorienttopath2d= target.setOrientToPath2d( doesOrient2d_);
                  ToLuaCS.push(L,setorienttopath2d); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setRect(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Rect)
              {
                  UnityEngine.Rect rect_ = (UnityEngine.Rect)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setrect= target.setRect( rect_);
                  ToLuaCS.push(L,setrect); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 2) is LTRect)
              {
                  LTRect rect_ = (LTRect)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setrect= target.setRect( rect_);
                  ToLuaCS.push(L,setrect); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setPath(LuaState L)
          {
                  LTBezierPath path_ = (LTBezierPath)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setpath= target.setPath( path_);
                  ToLuaCS.push(L,setpath); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setPoint(LuaState L)
          {
                  UnityEngine.Vector3 point_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setpoint= target.setPoint( point_);
                  ToLuaCS.push(L,setpoint); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setDestroyOnComplete(LuaState L)
          {
                  System.Boolean doesDestroy_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setdestroyoncomplete= target.setDestroyOnComplete( doesDestroy_);
                  ToLuaCS.push(L,setdestroyoncomplete); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setAudio(LuaState L)
          {
                  System.Object audio_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setaudio= target.setAudio( audio_);
                  ToLuaCS.push(L,setaudio); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int setOnCompleteOnRepeat(LuaState L)
          {
                  System.Boolean isOn_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  LTDescr setoncompleteonrepeat= target.setOnCompleteOnRepeat( isOn_);
                  ToLuaCS.push(L,setoncompleteonrepeat); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_toggle(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.toggle;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_toggle(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.toggle= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useEstimatedTime(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.useEstimatedTime;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useEstimatedTime(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.useEstimatedTime= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_useFrames(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.useFrames;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_useFrames(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.useFrames= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hasInitiliazed(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.hasInitiliazed;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hasInitiliazed(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.hasInitiliazed= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hasPhysics(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.hasPhysics;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hasPhysics(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.hasPhysics= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_passed(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.passed;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_passed(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.passed= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_delay(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.delay;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_delay(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.delay= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_time(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.time;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_time(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.time= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lastVal(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.lastVal;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_lastVal(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.lastVal= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_loopCount(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.loopCount;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_loopCount(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.loopCount= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_counter(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.counter;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_counter(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.counter= (System.UInt32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_direction(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.direction;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_direction(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.direction= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_destroyOnComplete(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.destroyOnComplete;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_destroyOnComplete(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.destroyOnComplete= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_trans(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.trans;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_trans(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.trans= (UnityEngine.Transform)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_ltRect(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.ltRect;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_ltRect(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.ltRect= (LTRect)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_from(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.from;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_from(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.from= (UnityEngine.Vector3)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_to(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.to;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_to(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.to= (UnityEngine.Vector3)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_diff(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.diff;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_diff(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.diff= (UnityEngine.Vector3)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_point(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.point;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_point(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.point= (UnityEngine.Vector3)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_axis(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.axis;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_axis(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.axis= (UnityEngine.Vector3)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_origRotation(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.origRotation;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_origRotation(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.origRotation= (UnityEngine.Quaternion)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_path(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.path;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_path(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.path= (LTBezierPath)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_spline(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.spline;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_spline(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.spline= (LTSpline)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_type(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.type;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_type(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.type= (TweenAction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tweenType(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.tweenType;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tweenType(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.tweenType= (LeanTweenType)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_animationCurve(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.animationCurve;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_animationCurve(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.animationCurve= (UnityEngine.AnimationCurve)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_loopType(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.loopType;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_loopType(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.loopType= (LeanTweenType)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUpdateFloat(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onUpdateFloat;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onUpdateFloat(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onUpdateFloat= (System.Action<System.Single>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUpdateFloatObject(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onUpdateFloatObject;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onUpdateFloatObject(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  //target.onUpdateFloatObject= (System.Action<System.Single>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUpdateVector3(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onUpdateVector3;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onUpdateVector3(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onUpdateVector3= (System.Action<UnityEngine.Vector3>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUpdateVector3Object(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onUpdateVector3Object;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onUpdateVector3Object(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  //target.onUpdateVector3Object= (System.Action<UnityEngine.Vector3>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUpdateColor(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onUpdateColor;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onUpdateColor(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onUpdateColor= (System.Action<UnityEngine.Color>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onComplete(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onComplete;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onComplete(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onComplete= (System.Action)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onLuaComplete(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onLuaComplete;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onLuaComplete(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onLuaComplete= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCompleteObject(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onCompleteObject;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCompleteObject(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCompleteObject= (System.Action<System.Object>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCompleteParam(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onCompleteParam;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCompleteParam(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCompleteParam= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onUpdateParam(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onUpdateParam;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onUpdateParam(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onUpdateParam= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCompleteOnRepeat(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.onCompleteOnRepeat;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCompleteOnRepeat(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  target.onCompleteOnRepeat= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_optional(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original ;
                  var val=  target.optional;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_optional(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LTDescr target= (LTDescr) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.optional= (System.Collections.Hashtable)val;
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

