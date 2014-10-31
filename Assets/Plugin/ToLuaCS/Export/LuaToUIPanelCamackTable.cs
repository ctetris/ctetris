using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUIPanelCamackTable {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UIPanelCamackTable).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UIPanelCamackTable).AssemblyQualifiedName);
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
          System.Type superT = typeof(UIPanelCamackTable).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_scrollDirection");
          luafn_get_scrollDirection= new LuaCSFunction(get_scrollDirection);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_scrollDirection);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_recordCount");
          luafn_get_recordCount= new LuaCSFunction(get_recordCount);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_recordCount);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_data");
          luafn_get_data= new LuaCSFunction(get_data);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_data);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_data");
          luafn_set_data= new LuaCSFunction(set_data);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_data);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_headIndex");
          luafn_get_headIndex= new LuaCSFunction(get_headIndex);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_headIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_currFirstIndex");
          luafn_get_currFirstIndex= new LuaCSFunction(get_currFirstIndex);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_currFirstIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"getIndex");
          luafn_getIndex= new LuaCSFunction(getIndex);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_getIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"removeChild");
          luafn_removeChild= new LuaCSFunction(removeChild);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_removeChild);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"insertData");
          luafn_insertData= new LuaCSFunction(insertData);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_insertData);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"removeDataAt");
          luafn_removeDataAt= new LuaCSFunction(removeDataAt);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_removeDataAt);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"clear");
          luafn_clear= new LuaCSFunction(clear);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_clear);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"scrollTo");
          luafn_scrollTo= new LuaCSFunction(scrollTo);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_scrollTo);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Refresh");
          luafn_Refresh= new LuaCSFunction(Refresh);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Refresh);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_direction");
          luafn_get_direction= new LuaCSFunction(get_direction);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_direction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_direction");
          luafn_set_direction= new LuaCSFunction(set_direction);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_direction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_moveContainer");
          luafn_get_moveContainer= new LuaCSFunction(get_moveContainer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_moveContainer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_moveContainer");
          luafn_set_moveContainer= new LuaCSFunction(set_moveContainer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_moveContainer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tileItem");
          luafn_get_tileItem= new LuaCSFunction(get_tileItem);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tileItem);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_tileItem");
          luafn_set_tileItem= new LuaCSFunction(set_tileItem);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_tileItem);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onItemRender");
          luafn_get_onItemRender= new LuaCSFunction(get_onItemRender);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onItemRender);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onItemRender");
          luafn_set_onItemRender= new LuaCSFunction(set_onItemRender);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onItemRender);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onPreRender");
          luafn_get_onPreRender= new LuaCSFunction(get_onPreRender);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onPreRender);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onPreRender");
          luafn_set_onPreRender= new LuaCSFunction(set_onPreRender);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onPreRender);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onDataRemove");
          luafn_get_onDataRemove= new LuaCSFunction(get_onDataRemove);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onDataRemove);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onDataRemove");
          luafn_set_onDataRemove= new LuaCSFunction(set_onDataRemove);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onDataRemove);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onDataInsert");
          luafn_get_onDataInsert= new LuaCSFunction(get_onDataInsert);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onDataInsert);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onDataInsert");
          luafn_set_onDataInsert= new LuaCSFunction(set_onDataInsert);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onDataInsert);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_pageSize");
          luafn_get_pageSize= new LuaCSFunction(get_pageSize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_pageSize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_pageSize");
          luafn_set_pageSize= new LuaCSFunction(set_pageSize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_pageSize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_renderPerFrames");
          luafn_get_renderPerFrames= new LuaCSFunction(get_renderPerFrames);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_renderPerFrames);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_renderPerFrames");
          luafn_set_renderPerFrames= new LuaCSFunction(set_renderPerFrames);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_renderPerFrames);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_columns");
          luafn_get_columns= new LuaCSFunction(get_columns);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_columns);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_columns");
          luafn_set_columns= new LuaCSFunction(set_columns);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_columns);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_padding");
          luafn_get_padding= new LuaCSFunction(get_padding);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_padding);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_padding");
          luafn_set_padding= new LuaCSFunction(set_padding);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_padding);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_tileSize");
          luafn_get_tileSize= new LuaCSFunction(get_tileSize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_tileSize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_tileSize");
          luafn_set_tileSize= new LuaCSFunction(set_tileSize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_tileSize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_keepTileBound");
          luafn_get_keepTileBound= new LuaCSFunction(get_keepTileBound);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_keepTileBound);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_keepTileBound");
          luafn_set_keepTileBound= new LuaCSFunction(set_keepTileBound);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_keepTileBound);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_scrollDirection;
          private static LuaCSFunction luafn_get_recordCount;
          private static LuaCSFunction luafn_get_data;
          private static LuaCSFunction luafn_set_data;
          private static LuaCSFunction luafn_get_headIndex;
          private static LuaCSFunction luafn_get_currFirstIndex;
          private static LuaCSFunction luafn_getIndex;
          private static LuaCSFunction luafn_removeChild;
          private static LuaCSFunction luafn_insertData;
          private static LuaCSFunction luafn_removeDataAt;
          private static LuaCSFunction luafn_clear;
          private static LuaCSFunction luafn_scrollTo;
          private static LuaCSFunction luafn_Refresh;
          private static LuaCSFunction luafn_get_direction;
          private static LuaCSFunction luafn_set_direction;
          private static LuaCSFunction luafn_get_moveContainer;
          private static LuaCSFunction luafn_set_moveContainer;
          private static LuaCSFunction luafn_get_tileItem;
          private static LuaCSFunction luafn_set_tileItem;
          private static LuaCSFunction luafn_get_onItemRender;
          private static LuaCSFunction luafn_set_onItemRender;
          private static LuaCSFunction luafn_get_onPreRender;
          private static LuaCSFunction luafn_set_onPreRender;
          private static LuaCSFunction luafn_get_onDataRemove;
          private static LuaCSFunction luafn_set_onDataRemove;
          private static LuaCSFunction luafn_get_onDataInsert;
          private static LuaCSFunction luafn_set_onDataInsert;
          private static LuaCSFunction luafn_get_pageSize;
          private static LuaCSFunction luafn_set_pageSize;
          private static LuaCSFunction luafn_get_renderPerFrames;
          private static LuaCSFunction luafn_set_renderPerFrames;
          private static LuaCSFunction luafn_get_columns;
          private static LuaCSFunction luafn_set_columns;
          private static LuaCSFunction luafn_get_padding;
          private static LuaCSFunction luafn_set_padding;
          private static LuaCSFunction luafn_get_tileSize;
          private static LuaCSFunction luafn_set_tileSize;
          private static LuaCSFunction luafn_get_keepTileBound;
          private static LuaCSFunction luafn_set_keepTileBound;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_scrollDirection(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 scrollDirection= target.scrollDirection;
                  ToLuaCS.push(L,scrollDirection); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_recordCount(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 recordCount= target.recordCount;
                  ToLuaCS.push(L,recordCount); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_data(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  LuaInterface.LuaTable data= target.data;
                  ToLuaCS.push(L,data); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_data(LuaState L)
          {
                  LuaInterface.LuaTable value_ = (LuaInterface.LuaTable)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  target.data= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_headIndex(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 headIndex= target.headIndex;
                  ToLuaCS.push(L,headIndex); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_currFirstIndex(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 currFirstIndex= target.currFirstIndex;
                  ToLuaCS.push(L,currFirstIndex); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int getIndex(LuaState L)
          {
                  ReferGameObjects item_ = (ReferGameObjects)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 getindex= target.getIndex( item_);
                  ToLuaCS.push(L,getindex); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int removeChild(LuaState L)
          {
                  ReferGameObjects item_ = (ReferGameObjects)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 removechild= target.removeChild( item_);
                  ToLuaCS.push(L,removechild); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int insertData(LuaState L)
          {
                  System.Object item_ = (System.Object)ToLuaCS.getObject(L,2);
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 insertdata= target.insertData( item_, index_);
                  ToLuaCS.push(L,insertdata); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int removeDataAt(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  System.Int32 removedataat= target.removeDataAt( index_);
                  ToLuaCS.push(L,removedataat); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int clear(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  target.clear();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int scrollTo(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  target.scrollTo( index_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Refresh(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Int32 begin_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Int32 end_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  target.Refresh( begin_, end_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is ReferGameObjects)
              {
                  ReferGameObjects item_ = (ReferGameObjects)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  target.Refresh( item_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_direction(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.direction;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_direction(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.direction= (UIPanelCamackTable.Direction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_moveContainer(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.moveContainer;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_moveContainer(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.moveContainer= (UnityEngine.GameObject)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tileItem(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.tileItem;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tileItem(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.tileItem= (ReferGameObjects)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onItemRender(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.onItemRender;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onItemRender(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onItemRender= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onPreRender(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.onPreRender;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onPreRender(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onPreRender= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDataRemove(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.onDataRemove;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDataRemove(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onDataRemove= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDataInsert(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.onDataInsert;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDataInsert(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onDataInsert= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pageSize(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.pageSize;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pageSize(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.pageSize= (System.Int32)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_renderPerFrames(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.renderPerFrames;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_renderPerFrames(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.renderPerFrames= (System.Single)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_columns(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.columns;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_columns(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.columns= (System.Int32)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_padding(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.padding;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_padding(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.padding= (UnityEngine.Vector2)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_tileSize(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.tileSize;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_tileSize(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.tileSize= (UnityEngine.Vector3)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_keepTileBound(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original ;
                  var val=  target.keepTileBound;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_keepTileBound(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UIPanelCamackTable target= (UIPanelCamackTable) original;
                  target.keepTileBound= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

