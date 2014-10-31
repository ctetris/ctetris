using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLeanTween {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LeanTween).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LeanTween).AssemblyQualifiedName);
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
          System.Type superT = typeof(LeanTween).BaseType;
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
          LuaDLL.lua_pushstring(L,"Update");
          luafn_Update= new LuaCSFunction(Update);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Update);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"OnLevelWasLoaded");
          luafn_OnLevelWasLoaded= new LuaCSFunction(OnLevelWasLoaded);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_OnLevelWasLoaded);
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
    
          string[] names = typeof(LeanTween).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(LeanTween).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"init");
          luafn_init= new LuaCSFunction(init);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_init);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"reset");
          luafn_reset= new LuaCSFunction(reset);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_reset);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"update");
          luafn_update= new LuaCSFunction(update);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_update);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"removeTween");
          luafn_removeTween= new LuaCSFunction(removeTween);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_removeTween);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"add");
          luafn_add= new LuaCSFunction(add);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_add);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"closestRot");
          luafn_closestRot= new LuaCSFunction(closestRot);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_closestRot);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"cancel");
          luafn_cancel= new LuaCSFunction(cancel);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_cancel);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"description");
          luafn_description= new LuaCSFunction(description);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_description);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"pause");
          luafn_pause= new LuaCSFunction(pause);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_pause);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"resume");
          luafn_resume= new LuaCSFunction(resume);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_resume);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"isTweening");
          luafn_isTweening= new LuaCSFunction(isTweening);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_isTweening);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"drawBezierPath");
          luafn_drawBezierPath= new LuaCSFunction(drawBezierPath);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_drawBezierPath);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"logError");
          luafn_logError= new LuaCSFunction(logError);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_logError);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"options");
          luafn_options= new LuaCSFunction(options);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_options);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tweenEmpty");
          luafn_get_tweenEmpty= new LuaCSFunction(get_tweenEmpty);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tweenEmpty);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"alpha");
          luafn_alpha= new LuaCSFunction(alpha);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_alpha);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"alphaVertex");
          luafn_alphaVertex= new LuaCSFunction(alphaVertex);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_alphaVertex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"color");
          luafn_color= new LuaCSFunction(color);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_color);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"delayedCall");
          luafn_delayedCall= new LuaCSFunction(delayedCall);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_delayedCall);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"destroyAfter");
          luafn_destroyAfter= new LuaCSFunction(destroyAfter);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_destroyAfter);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"move");
          luafn_move= new LuaCSFunction(move);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_move);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveSpline");
          luafn_moveSpline= new LuaCSFunction(moveSpline);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveSpline);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveSplineLocal");
          luafn_moveSplineLocal= new LuaCSFunction(moveSplineLocal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveSplineLocal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveMargin");
          luafn_moveMargin= new LuaCSFunction(moveMargin);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveMargin);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveX");
          luafn_moveX= new LuaCSFunction(moveX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveY");
          luafn_moveY= new LuaCSFunction(moveY);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveY);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveZ");
          luafn_moveZ= new LuaCSFunction(moveZ);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveZ);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveLocal");
          luafn_moveLocal= new LuaCSFunction(moveLocal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveLocal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveLocalX");
          luafn_moveLocalX= new LuaCSFunction(moveLocalX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveLocalX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveLocalY");
          luafn_moveLocalY= new LuaCSFunction(moveLocalY);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveLocalY);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"moveLocalZ");
          luafn_moveLocalZ= new LuaCSFunction(moveLocalZ);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_moveLocalZ);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotate");
          luafn_rotate= new LuaCSFunction(rotate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotateLocal");
          luafn_rotateLocal= new LuaCSFunction(rotateLocal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotateLocal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotateX");
          luafn_rotateX= new LuaCSFunction(rotateX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotateX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotateY");
          luafn_rotateY= new LuaCSFunction(rotateY);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotateY);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotateZ");
          luafn_rotateZ= new LuaCSFunction(rotateZ);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotateZ);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotateAround");
          luafn_rotateAround= new LuaCSFunction(rotateAround);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotateAround);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"rotateAroundLocal");
          luafn_rotateAroundLocal= new LuaCSFunction(rotateAroundLocal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_rotateAroundLocal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"scale");
          luafn_scale= new LuaCSFunction(scale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_scale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"scaleX");
          luafn_scaleX= new LuaCSFunction(scaleX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_scaleX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"scaleY");
          luafn_scaleY= new LuaCSFunction(scaleY);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_scaleY);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"scaleZ");
          luafn_scaleZ= new LuaCSFunction(scaleZ);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_scaleZ);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"value");
          luafn_value= new LuaCSFunction(value);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_value);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"delayedSound");
          luafn_delayedSound= new LuaCSFunction(delayedSound);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_delayedSound);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"h");
          luafn_h= new LuaCSFunction(h);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_h);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"addListener");
          luafn_addListener= new LuaCSFunction(addListener);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_addListener);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"removeListener");
          luafn_removeListener= new LuaCSFunction(removeListener);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_removeListener);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"dispatchEvent");
          luafn_dispatchEvent= new LuaCSFunction(dispatchEvent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_dispatchEvent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_throwErrors");
          luafn_get_throwErrors= new LuaCSFunction(get_throwErrors);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_throwErrors);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_throwErrors");
          luafn_set_throwErrors= new LuaCSFunction(set_throwErrors);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_throwErrors);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_startSearch");
          luafn_get_startSearch= new LuaCSFunction(get_startSearch);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_startSearch);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_startSearch");
          luafn_set_startSearch= new LuaCSFunction(set_startSearch);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_startSearch);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_descr");
          luafn_get_descr= new LuaCSFunction(get_descr);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_descr);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_descr");
          luafn_set_descr= new LuaCSFunction(set_descr);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_descr);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_EVENTS_MAX");
          luafn_get_EVENTS_MAX= new LuaCSFunction(get_EVENTS_MAX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_EVENTS_MAX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_EVENTS_MAX");
          luafn_set_EVENTS_MAX= new LuaCSFunction(set_EVENTS_MAX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_EVENTS_MAX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_LISTENERS_MAX");
          luafn_get_LISTENERS_MAX= new LuaCSFunction(get_LISTENERS_MAX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_LISTENERS_MAX);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_LISTENERS_MAX");
          luafn_set_LISTENERS_MAX= new LuaCSFunction(set_LISTENERS_MAX);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_LISTENERS_MAX);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Update;
          private static LuaCSFunction luafn_OnLevelWasLoaded;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_init;
          private static LuaCSFunction luafn_reset;
          private static LuaCSFunction luafn_update;
          private static LuaCSFunction luafn_removeTween;
          private static LuaCSFunction luafn_add;
          private static LuaCSFunction luafn_closestRot;
          private static LuaCSFunction luafn_cancel;
          private static LuaCSFunction luafn_description;
          private static LuaCSFunction luafn_pause;
          private static LuaCSFunction luafn_resume;
          private static LuaCSFunction luafn_isTweening;
          private static LuaCSFunction luafn_drawBezierPath;
          private static LuaCSFunction luafn_logError;
          private static LuaCSFunction luafn_options;
          private static LuaCSFunction luafn_get_tweenEmpty;
          private static LuaCSFunction luafn_alpha;
          private static LuaCSFunction luafn_alphaVertex;
          private static LuaCSFunction luafn_color;
          private static LuaCSFunction luafn_delayedCall;
          private static LuaCSFunction luafn_destroyAfter;
          private static LuaCSFunction luafn_move;
          private static LuaCSFunction luafn_moveSpline;
          private static LuaCSFunction luafn_moveSplineLocal;
          private static LuaCSFunction luafn_moveMargin;
          private static LuaCSFunction luafn_moveX;
          private static LuaCSFunction luafn_moveY;
          private static LuaCSFunction luafn_moveZ;
          private static LuaCSFunction luafn_moveLocal;
          private static LuaCSFunction luafn_moveLocalX;
          private static LuaCSFunction luafn_moveLocalY;
          private static LuaCSFunction luafn_moveLocalZ;
          private static LuaCSFunction luafn_rotate;
          private static LuaCSFunction luafn_rotateLocal;
          private static LuaCSFunction luafn_rotateX;
          private static LuaCSFunction luafn_rotateY;
          private static LuaCSFunction luafn_rotateZ;
          private static LuaCSFunction luafn_rotateAround;
          private static LuaCSFunction luafn_rotateAroundLocal;
          private static LuaCSFunction luafn_scale;
          private static LuaCSFunction luafn_scaleX;
          private static LuaCSFunction luafn_scaleY;
          private static LuaCSFunction luafn_scaleZ;
          private static LuaCSFunction luafn_value;
          private static LuaCSFunction luafn_delayedSound;
          private static LuaCSFunction luafn_h;
          private static LuaCSFunction luafn_addListener;
          private static LuaCSFunction luafn_removeListener;
          private static LuaCSFunction luafn_dispatchEvent;
          private static LuaCSFunction luafn_get_throwErrors;
          private static LuaCSFunction luafn_set_throwErrors;
          private static LuaCSFunction luafn_get_startSearch;
          private static LuaCSFunction luafn_set_startSearch;
          private static LuaCSFunction luafn_get_descr;
          private static LuaCSFunction luafn_set_descr;
          private static LuaCSFunction luafn_get_EVENTS_MAX;
          private static LuaCSFunction luafn_set_EVENTS_MAX;
          private static LuaCSFunction luafn_get_LISTENERS_MAX;
          private static LuaCSFunction luafn_set_LISTENERS_MAX;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Update(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LeanTween target= (LeanTween) original ;
                  target.Update();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnLevelWasLoaded(LuaState L)
          {
                  System.Int32 lvl_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LeanTween target= (LeanTween) original ;
                  target.OnLevelWasLoaded( lvl_);
                 return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int init(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 maxSimultaneousTweens_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.init( maxSimultaneousTweens_);
                 return 0;

              }
              if(true)
              {

                  LeanTween.init();
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int reset(LuaState L)
          {

                  LeanTween.reset();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int update(LuaState L)
          {

                  LeanTween.update();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int removeTween(LuaState L)
          {
                  System.Int32 i_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.removeTween( i_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int add(LuaState L)
          {
                  UnityEngine.Vector3[] a_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3[] add= LeanTween.add( a_, b_);
                  ToLuaCS.push(L,add); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int closestRot(LuaState L)
          {
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single closestrot= LeanTween.closestRot( from_, to_);
                  ToLuaCS.push(L,closestrot); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int cancel(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.cancel( ltRect_, uniqueId_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.cancel( gameObject_, uniqueId_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);

                  LeanTween.cancel( gameObject_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int description(LuaState L)
          {
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LTDescr description= LeanTween.description( uniqueId_);
                  ToLuaCS.push(L,description); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int pause(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.pause(uniqueId_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);

                  LeanTween.pause( gameObject_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.pause( uniqueId_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int resume(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  LeanTween.resume( gameObject_, uniqueId_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);

                  LeanTween.resume( gameObject_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.resume( uniqueId_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int isTweening(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is LTRect)
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);

                  System.Boolean istweening= LeanTween.isTweening( ltRect_);
                  ToLuaCS.push(L,istweening); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 uniqueId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  System.Boolean istweening= LeanTween.isTweening( uniqueId_);
                  ToLuaCS.push(L,istweening); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);

                  System.Boolean istweening= LeanTween.isTweening( gameObject_);
                  ToLuaCS.push(L,istweening); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int drawBezierPath(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 c_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 d_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);

                  LeanTween.drawBezierPath( a_, b_, c_, d_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int logError(LuaState L)
          {
                  System.String error_ =  LuaDLL.lua_tostring(L,1); 


                  System.Object logerror= LeanTween.logError( error_);
                  ToLuaCS.push(L,logerror); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int options(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is LTDescr)
              {
                  LTDescr seed_ = (LTDescr)ToLuaCS.getObject(L,1);

                  LTDescr options= LeanTween.options( seed_);
                  ToLuaCS.push(L,options); 
                  return 1;

              }
              if(true)
              {

                  LTDescr options= LeanTween.options();
                  ToLuaCS.push(L,options); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tweenEmpty(LuaState L)
          {

                  UnityEngine.GameObject tweenEmpty= LeanTween.tweenEmpty;
                  ToLuaCS.push(L,tweenEmpty); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int alpha(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 alpha= LeanTween.alpha( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,alpha); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 alpha= LeanTween.alpha( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,alpha); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 alpha= LeanTween.alpha( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,alpha); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 alpha= LeanTween.alpha( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,alpha); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr alpha= LeanTween.alpha( gameObject_, to_, time_);
                  ToLuaCS.push(L,alpha); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr alpha= LeanTween.alpha( ltRect_, to_, time_);
                  ToLuaCS.push(L,alpha); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int alphaVertex(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr alphavertex= LeanTween.alphaVertex( gameObject_, to_, time_);
                  ToLuaCS.push(L,alphavertex); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int color(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Color to_ = (UnityEngine.Color)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr color= LeanTween.color( gameObject_, to_, time_);
                  ToLuaCS.push(L,color); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int delayedCall(LuaState L)
          {
              if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TNUMBER && ToLuaCS.getObject(L, 2) is LuaInterface.LuaFunction && ToLuaCS.getObject(L, 3) is System.Collections.Hashtable)
              {
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L, 1);
                  LuaInterface.LuaFunction callback_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L, 3);

                  System.Int32 delayedcall = LeanTween.delayedCall(delayTime_, callback_, optional_);
                  ToLuaCS.push(L, delayedcall);
                  return 1;

              }
              if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TNUMBER && ToLuaCS.getObject(L, 2) is LuaInterface.LuaFunction && ToLuaCS.getObject(L, 3) is System.Object[])
              {
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L, 1);
                  LuaInterface.LuaFunction callback_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L, 2);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L, 3);

                  System.Int32 delayedcall = LeanTween.delayedCall(delayTime_, callback_, optional_);
                  ToLuaCS.push(L, delayedcall);
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.String callback_ =  LuaDLL.lua_tostring(L,3); 

                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  ToLuaCS.push(L,delayedcall); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action && ToLuaCS.getObject(L, 4) is System.Object[])
              //{
              //    UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
              //    System.Action callback_ = (System.Action)ToLuaCS.getObject(L,3);
              //    System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

              //    System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.String callback_ =  LuaDLL.lua_tostring(L,3); 

                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  ToLuaCS.push(L,delayedcall); 
                  return 1;

              }
              //if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action<System.Object> && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              //{
              //    UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
              //    System.Action<System.Object> callback_ = (System.Action<System.Object>)ToLuaCS.getObject(L,3);
              //    System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

              //    System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              //{
              //    UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
              //    System.Action callback_ = (System.Action)ToLuaCS.getObject(L,3);
              //    System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

              //    System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is LuaInterface.LuaFunction && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  LuaInterface.LuaFunction callback_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_, optional_);
                  ToLuaCS.push(L,delayedcall); 
                  return 1;

              }
              //if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action && ToLuaCS.getObject(L, 3) is System.Object[])
              //{
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
              //    System.Action callback_ = (System.Action)ToLuaCS.getObject(L,2);
              //    System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,3);

              //    System.Int32 delayedcall= LeanTween.delayedCall( delayTime_, callback_, optional_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action<System.Object>)
              //{
              //    UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
              //    System.Action<System.Object> callback_ = (System.Action<System.Object>)ToLuaCS.getObject(L,3);

              //    LTDescr delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              //if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action)
              //{
              //    UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);
              //    System.Action callback_ = (System.Action)ToLuaCS.getObject(L,3);

              //    LTDescr delayedcall= LeanTween.delayedCall( gameObject_, delayTime_, callback_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Collections.Hashtable)
              {
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.String callback_ =  LuaDLL.lua_tostring(L,2); 

                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,3);

                  System.Int32 delayedcall= LeanTween.delayedCall( delayTime_, callback_, optional_);
                  ToLuaCS.push(L,delayedcall); 
                  return 1;

              }

              //if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action)
              //{
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
              //    System.Action callback_ = (System.Action)ToLuaCS.getObject(L,2);

              //    LTDescr delayedcall= LeanTween.delayedCall( delayTime_, callback_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
              //if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action<System.Object>)
              //{
              //    System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,1);
              //    System.Action<System.Object> callback_ = (System.Action<System.Object>)ToLuaCS.getObject(L,2);

              //    LTDescr delayedcall= LeanTween.delayedCall( delayTime_, callback_);
              //    ToLuaCS.push(L,delayedcall); 
              //    return 1;

              //}
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int destroyAfter(LuaState L)
          {
                  LTRect rect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single delayTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  LTDescr destroyafter= LeanTween.destroyAfter( rect_, delayTime_);
                  ToLuaCS.push(L,destroyafter); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int move(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 move= LeanTween.move( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && ToLuaCS.getObject(L, 2) is UnityEngine.Vector2 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 move= LeanTween.move( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 move= LeanTween.move( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector2 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( gameObject_, to_, time_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( gameObject_, to_, time_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && ToLuaCS.getObject(L, 2) is UnityEngine.Vector2 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( ltRect_, to_, time_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr move= LeanTween.move( gameObject_, to_, time_);
                  ToLuaCS.push(L,move); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveSpline(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movespline= LeanTween.moveSpline( gameObject_, to_, time_);
                  ToLuaCS.push(L,movespline); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveSplineLocal(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movesplinelocal= LeanTween.moveSplineLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,movesplinelocal); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveMargin(LuaState L)
          {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movemargin= LeanTween.moveMargin( ltRect_, to_, time_);
                  ToLuaCS.push(L,movemargin); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveX(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movex= LeanTween.moveX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movex); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movex= LeanTween.moveX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movex); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movex= LeanTween.moveX( gameObject_, to_, time_);
                  ToLuaCS.push(L,movex); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveY(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movey= LeanTween.moveY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movey); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movey= LeanTween.moveY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movey); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movey= LeanTween.moveY( gameObject_, to_, time_);
                  ToLuaCS.push(L,movey); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveZ(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movez= LeanTween.moveZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movez); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movez= LeanTween.moveZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movez); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movez= LeanTween.moveZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,movez); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocal(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movelocal= LeanTween.moveLocal( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocal= LeanTween.moveLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3[] && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3[] to_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocal= LeanTween.moveLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocal); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocalX(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movelocalx= LeanTween.moveLocalX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocalx); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movelocalx= LeanTween.moveLocalX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocalx); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocalx= LeanTween.moveLocalX( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocalx); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocalY(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movelocaly= LeanTween.moveLocalY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocaly); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movelocaly= LeanTween.moveLocalY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocaly); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocaly= LeanTween.moveLocalY( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocaly); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int moveLocalZ(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 movelocalz= LeanTween.moveLocalZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocalz); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 movelocalz= LeanTween.moveLocalZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,movelocalz); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr movelocalz= LeanTween.moveLocalZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,movelocalz); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotate(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 rotate= LeanTween.rotate( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotate); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 rotate= LeanTween.rotate( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,rotate); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 rotate= LeanTween.rotate( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,rotate); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 rotate= LeanTween.rotate( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotate); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotate= LeanTween.rotate( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotate); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotate= LeanTween.rotate( ltRect_, to_, time_);
                  ToLuaCS.push(L,rotate); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateLocal(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 rotatelocal= LeanTween.rotateLocal( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 rotatelocal= LeanTween.rotateLocal( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatelocal= LeanTween.rotateLocal( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatelocal); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateX(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 rotatex= LeanTween.rotateX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatex); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 rotatex= LeanTween.rotateX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatex); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatex= LeanTween.rotateX( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatex); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateY(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 rotatey= LeanTween.rotateY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatey); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 rotatey= LeanTween.rotateY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatey); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatey= LeanTween.rotateY( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatey); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateZ(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 rotatez= LeanTween.rotateZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatez); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 rotatez= LeanTween.rotateZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,rotatez); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr rotatez= LeanTween.rotateZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,rotatez); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateAround(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,5);

                  System.Int32 rotatearound= LeanTween.rotateAround( gameObject_, axis_, add_, time_, optional_);
                  ToLuaCS.push(L,rotatearound); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,5);

                  System.Int32 rotatearound= LeanTween.rotateAround( gameObject_, axis_, add_, time_, optional_);
                  ToLuaCS.push(L,rotatearound); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  LTDescr rotatearound= LeanTween.rotateAround( gameObject_, axis_, add_, time_);
                  ToLuaCS.push(L,rotatearound); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int rotateAroundLocal(LuaState L)
          {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single add_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  LTDescr rotatearoundlocal= LeanTween.rotateAroundLocal( gameObject_, axis_, add_, time_);
                  ToLuaCS.push(L,rotatearoundlocal); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scale(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 scale= LeanTween.scale( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && ToLuaCS.getObject(L, 2) is UnityEngine.Vector2 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 scale= LeanTween.scale( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && ToLuaCS.getObject(L, 2) is UnityEngine.Vector2 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 scale= LeanTween.scale( ltRect_, to_, time_, optional_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 scale= LeanTween.scale( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scale= LeanTween.scale( gameObject_, to_, time_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is LTRect && ToLuaCS.getObject(L, 2) is UnityEngine.Vector2 && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  LTRect ltRect_ = (LTRect)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getObject(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scale= LeanTween.scale( ltRect_, to_, time_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scaleX(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 scalex= LeanTween.scaleX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scalex); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 scalex= LeanTween.scaleX( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scalex); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scalex= LeanTween.scaleX( gameObject_, to_, time_);
                  ToLuaCS.push(L,scalex); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scaleY(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 scaley= LeanTween.scaleY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scaley); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 scaley= LeanTween.scaleY( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scaley); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scaley= LeanTween.scaleY( gameObject_, to_, time_);
                  ToLuaCS.push(L,scaley); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scaleZ(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,4);

                  System.Int32 scalez= LeanTween.scaleZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scalez); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,4);

                  System.Int32 scalez= LeanTween.scaleZ( gameObject_, to_, time_, optional_);
                  ToLuaCS.push(L,scalez); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr scalez= LeanTween.scaleZ( gameObject_, to_, time_);
                  ToLuaCS.push(L,scalez); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int value(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Collections.Hashtable)
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object[])
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Object[] optional_ = (System.Object[])ToLuaCS.getObject(L,6);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Vector3> && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 4) is UnityEngine.Vector3 && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<UnityEngine.Vector3> callOnUpdate_ = (System.Action<UnityEngine.Vector3>)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<UnityEngine.Color> && ToLuaCS.getObject(L, 3) is UnityEngine.Color && ToLuaCS.getObject(L, 4) is UnityEngine.Color && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<UnityEngine.Color> callOnUpdate_ = (System.Action<UnityEngine.Color>)ToLuaCS.getObject(L,2);
                  UnityEngine.Color from_ = (UnityEngine.Color)ToLuaCS.getObject(L,3);
                  UnityEngine.Color to_ = (UnityEngine.Color)ToLuaCS.getObject(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,2); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  System.Int32 value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Collections.Hashtable)
              {
                  System.String callOnUpdate_ =  LuaDLL.lua_tostring(L,1); 

                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Collections.Hashtable optional_ = (System.Collections.Hashtable)ToLuaCS.getObject(L,5);

                  System.Int32 value= LeanTween.value( callOnUpdate_, from_, to_, time_, optional_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is System.Action<System.Single> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.GameObject gameObject_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Action<System.Single> callOnUpdate_ = (System.Action<System.Single>)ToLuaCS.getObject(L,2);
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single time_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  LTDescr value= LeanTween.value( gameObject_, callOnUpdate_, from_, to_, time_);
                  ToLuaCS.push(L,value); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int delayedSound(LuaState L)
          {
                  UnityEngine.AudioClip audio_ = (UnityEngine.AudioClip)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 pos_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single volume_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  LTDescr delayedsound= LeanTween.delayedSound( audio_, pos_, volume_);
                  ToLuaCS.push(L,delayedsound); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int h(LuaState L)
          {
                  System.Object[] arr_ = (System.Object[])ToLuaCS.getObject(L,1);

                  System.Collections.Hashtable h= LeanTween.h( arr_);
                  ToLuaCS.push(L,h); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int addListener(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action<LTEvent>)
              {
                  UnityEngine.GameObject caller_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L,3);

                  LeanTween.addListener( caller_, eventId_, callback_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action<LTEvent>)
              {
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L,2);

                  LeanTween.addListener( eventId_, callback_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int removeListener(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 3) is System.Action<LTEvent>)
              {
                  UnityEngine.GameObject caller_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L,3);

                  System.Boolean removelistener= LeanTween.removeListener( caller_, eventId_, callback_);
                  ToLuaCS.push(L,removelistener); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Action<LTEvent>)
              {
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Action<LTEvent> callback_ = (System.Action<LTEvent>)ToLuaCS.getObject(L,2);

                  System.Boolean removelistener= LeanTween.removeListener( eventId_, callback_);
                  ToLuaCS.push(L,removelistener); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int dispatchEvent(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 2) is System.Object)
              {
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Object data_ = (System.Object)ToLuaCS.getObject(L,2);

                  LeanTween.dispatchEvent( eventId_, data_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 eventId_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  LeanTween.dispatchEvent( eventId_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_throwErrors(LuaState L)
          {
                  var val=   LeanTween.throwErrors;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_throwErrors(LuaState L)
          {
                  LeanTween.throwErrors= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_startSearch(LuaState L)
          {
                  var val=   LeanTween.startSearch;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_startSearch(LuaState L)
          {
                  LeanTween.startSearch= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_descr(LuaState L)
          {
                  var val=   LeanTween.descr;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_descr(LuaState L)
          {
                   var val= ToLuaCS.getObject(L, 1);
                  LeanTween.descr= (LTDescr)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_EVENTS_MAX(LuaState L)
          {
                  var val=   LeanTween.EVENTS_MAX;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_EVENTS_MAX(LuaState L)
          {
                  LeanTween.EVENTS_MAX= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_LISTENERS_MAX(LuaState L)
          {
                  var val=   LeanTween.LISTENERS_MAX;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_LISTENERS_MAX(LuaState L)
          {
                  LeanTween.LISTENERS_MAX= (System.Int32)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
  #endregion       
}

