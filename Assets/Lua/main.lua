require("core.unity3d")
require("core.loader")
json=require("lib/json")
ResVersion = 0

local resourceURL ="http://192.168.18.152:8345/api" --http://121.199.51.39:8080/client_update?v_id=%s&platform=%s&code=%s";

local progressBarTxt;
local update_id="";
local FRIST_VIEW = "Frist.u3d";
local VIDEO_NAME = "Loading.mp4";
local VERSION_FILE_NAME = "Ver.t";
local luanet = luanet
local RuntimePlatform= luanet.UnityEngine.RuntimePlatform
local Application= luanet.UnityEngine.Application
local GameObject= luanet.UnityEngine.GameObject
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs
local Request=luanet.import_type("LRequest")
local tolua1 = luanet.import_type("Localization")
	  tolua1 = luanet.FileHelper
	  tolua1 = luanet.UILabel
	  tolua1 = luanet.UISprite
	  tolua1 = luanet.UITexture

local CUtils=toluacs.CUtils
local LuaHelper=toluacs.LuaHelper
local FilLoadereHelper=toluacs.FileHelper -- luanet.import_type("FileHelper")
local Localization = toluacs.Localization
local delay = delay
local Loader = Loader

local fristView

local function languageInit()
	local lan=PlayerPrefs.GetString("Language","")
	if lan=="" then lan=Application.systemLanguage:ToString() end
	Localization.language=lan --"Chinese"
	print(Application.systemLanguage:ToString().."current language is "..Localization.language)
end 

languageInit()

local function enterGame()
	require("begin")
	if fristView then LuaHelper.Destroy(fristView) end
	fristView = nil 

	local function dsLog() 
		-- local logo = LuaHelper.Find("Logo")
		-- if logo then  LuaHelper.Destroy(logo) end 
	end
	-- delay(dsLog,2,nil)
end

local function onProgress(loader,arg)
	-- body
end

local function onUpdateItemComp(req)
	local bytes=req:get_data().bytes
	if(bytes~=nil) then
		FileHelper.UnZipFile(bytes,Application.persistentDataPath);
	end
end

local function onAllUpdateResComp(loader)
	--SetProgressTxt("wait start...");
    loader:setOnAllCompelteFn(nil)
	loader:setOnProgressFn(nil)
	seveVersion()
	enterGame()
end

local function seveVersion()
	FileHelper.PersistentUTF8File(update_id,VERSION_FILE_NAME)	
end

local function  onUpdateResComp(req)
    local www=req:get_data();
	if(www) then
		local txt=www.text;
        local res = json:decode(txt)
		if res["error"] then
			enterGame()
		elseif res["update_url"] then
			local upURL=res["update_url"]
			local reqs={}
			local len=#upURL
			for i=1,len do
				table.insert(reqs,{upURL[i],onUpdateItemComp})
			end
			Loader:getResource(reqs)
			Loader:setOnAllCompelteFn(onAllUpdateResComp)
			Loader:setOnProgressFn(onProgress)
		else
			enterGame()
		end
	end
end

local function checkRes()

	if(Application.platform==RuntimePlatform.OSXEditor) then
		enterGame()
	elseif(Application.platform==RuntimePlatform.WindowsEditor) then
		enterGame()
	else
		enterGame()
		-- local url=string.format(resourceURL,tostring(ResVersion),Application.platform,"0.2.0");
		-- local req=Request(url)
		-- req.onCompleteFn=onUpdateResComp

		-- local function onErr( req )
		-- 	print("checkRes on erro")
		-- 	enterGame()
		-- end
		-- print("begin checkRes "..url)
		-- req.onEndFn=onErr
	 --    Loader:getResource(req,false)
	end
end

local function checkVerion()
	local function onURLComp(req )	ResVersion=req:get_data().text checkRes() end
	local function onURLErComp(req )   checkRes() end
	
	local verPath=CUtils.GetFileFullPath(VERSION_FILE_NAME);
	-- print("checkVerion . verPath"..verPath)
	local req=Request(verPath)
	req:set_onCompleteFn(onURLComp)
	req:set_onEndFn(onURLErComp)
  	--print("request create "..tostring(req))
  	--print(Loader)
    Loader:getResource(req,false)
    --print("checkVerion . Loader:getResource called  "..verPath)
end

local function loadFrist()

	local function onLoadComp(r)

		
		local www=r.data
		-- print(r.url.." loaded ")
		--print(www)
        fristView = LuaHelper.Instantiate(www.assetBundle.mainAsset)
        progressBarTxt = LuaHelper.GetComponentInChildren(fristView,"UILabel")
        progressBarTxt.text="loading new ..."
        www.assetBundle:Unload(false)
        www:Dispose()
        checkVerion()
    end

	Application.targetFrameRate=30
   
    checkVerion()
	-- local url = CUtils.getFileFullPath(CUtils.getAssetPath(FRIST_VIEW))
	-- print("begin"..url)
	-- Loader:getResource(url,onLoadComp,true)
end


loadFrist()
