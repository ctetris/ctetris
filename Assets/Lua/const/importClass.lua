local luanet=luanet
UnityEngine=luanet.UnityEngine
local UnityEngine = UnityEngine
GameObject=UnityEngine.GameObject
Vector3=UnityEngine.Vector3
Quaternion = UnityEngine.Quaternion
-----------------------init---------------------------
local   tolua1 = luanet.import_type("CUtils")
        tolua1 = luanet.import_type("LuaHelper")
        tolua1 = luanet.import_type("Localization")
local tolua11 = luanet.ReferGameObjects
local tolua12 =luanet.UnityEngine.MonoBehaviour
local tolua13 =luanet.UnityEngine.Random
local tolua14 =luanet.UnityEngine.Time 
----------------------leantween--------------------------
local tolua14=luanet.LeanTween
local tolua14=luanet.LTBezier
local tolua14=luanet.LTBezierPath
local tolua14=luanet.LTDescr
local tolua14=luanet.LTSpline

iTween = luanet.import_type("iTween")
LeanTweenType=luanet.LeanTweenType

------------------------------static 变量---------------------------
LeanTween=toluacs.LeanTween
Random = toluacs.UnityEngine.Random
CUtils=toluacs.CUtils --luanet.import_type("CUtils") -- --LCUtils --
LuaHelper=toluacs.LuaHelper --LLuaHelper --luanet.import_type("LuaHelper")
Localization = toluacs.Localization --luanet.import_type("Localization")
toluaiTween=toluacs.iTween

PLua = luanet.import_type("PLua")
NetChat=luanet.import_type("LNet").ChatInstance
Net=luanet.import_type("LNet").instance
Msg=luanet.import_type("Msg")
Request=luanet.import_type("LRequest")

local LocalizationMy = Localization
--获取语言包内容
function getValue(key)
    return Localization.Get(key)
end
-----------------------------toluacs import-----------------------------------

---------------------------------NGUI--------------------------
