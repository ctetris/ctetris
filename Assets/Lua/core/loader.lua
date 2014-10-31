Loader={}
local luanet = luanet
local LMultipleLoader= luanet.import_type("LMultipleLoader") --toLuaCS.LMultipleLoader--
LMultipleLoader=LMultipleLoader.instance
local Request=luanet.LRequest
local AssetBundle = luanet.UnityEngine.AssetBundle
local WWW = luanet.UnityEngine.WWW
local to1=luanet.LuaHelper
local to2=luanet.CUtils

local LuaHelper = toluacs.LuaHelper
local delay = delay
local CUtils = toluacs.CUtils

local Loader=Loader 
Loader.multipleLoader=LMultipleLoader
Loader.resdic={} --cache dic
Loader.shareCache ={}
LMultipleLoader.cache=Loader.resdic

-- printTable(getmetatable(LMultipleLoader))
local function dispatchComplete(req)
	if req.onCompleteFn then req.onCompleteFn(req) end
end

local function loadByUrl(url,compFn,cache,endFn,head)
	local req=Request(url)
	if compFn then req.onCompleteFn=compFn end
	if endFn then req.onEndFn=endFn end
	if head~=nil then req.head=head end
	if cache==nil or cache==true then req.cache=true end
	local key=req.key
	local cacheData=Loader.resdic[key]
	if cacheData~=nil then req.data=cacheData dispatchComplete(req)
	else Loader.multipleLoader:LoadReq(req) 
	end
end

local function loadByReq( req,cache )
	if cache==nil or cache==true then req.cache=true end
	local key=req.key
	local cacheData=Loader.resdic[key]
	if cacheData~=nil then req.data=cacheData dispatchComplete(req)
	else Loader.multipleLoader:LoadReq(req)
	end 
end

local function loadByTable(tb,cache)
	local arrList={} --ArrayList()
	local len=#tb
	local key = ""
	-- printTable(tb)
	--for i=1,len do
	for k,v in pairs(tb) do
		--local v = tb[i]
		local l1=#v
		local req=Request(v[1])
		key=req.key
		if l1>1 then req.onCompleteFn=v[2] end
		if l1>2 then req.onEndFn=v[3] end
		if l1>3 then req.head=v[4] end
		if cache==nil or cache==true then req.cache=true end
		local cacheData=Loader.resdic[key]
		if cacheData~=nil then req.data=cacheData dispatchComplete(req)
		else table.insert(arrList,req)--arrList:Add(req)
		end
	end
	Loader.multipleLoader:LoadLuaTable(arrList)
end

function Loader:clearItem(key)
	local www =	self.resdic[key]
	if www then
		if www.assetBundle~=null then www.assetBundle:Unload(false) end
		www:Dispose()
		www = nil
	end
	self.resdic[key]=nil 
end

function Loader:clear(key)
	if key then 
		self:clearItem(key)
	elseif (key==true) then
		for k, v in pairs(self.resdic) do
			self:clearItem(k)
		end
	end 
end

function Loader:unload(url)
	if url then
		local key=CUtils.getURLFullFileName(url)
		self:clearItem(key)
	end
end

function Loader:getResource(...)
	local a,b,c,d=...
	--print("Loader:getResource type=" ..type(a))
	--url,onComplete
	if type(a)=="string" then 
		loadByUrl(a,b,c,d)
	elseif type(a)=="userdata" then
		loadByReq(a,b)
	elseif type(a) == "table" then
		loadByTable(a,b)
	end
	--print("getResource  ed...."..tostring(a))
end

function disposeWWW( www )
	www.assetBundle:Unload(false) 
	www:Dispose()
	www = nil
end

local function onCache( req)
	local key=req.key
	local www=req.data
	Loader.resdic[key]=www
end

local function onSharedComplete(req)
	local typeName = req:GetType().Name
	if typeName == "CRequest" or typeName == "LRequest"  then
		local key=req.key
		local www=req.data
		local name = www.assetBundle.mainAsset:GetType().Name
		if name == "GameObject" then
			LuaHelper.RefreshShader(www)
			local m = www.assetBundle.mainAsset--LuaHelper.Instantiate(www.assetBundle.mainAsset)
			Loader.resdic[key]= m
			Loader.shareCache[key] = m
			--local dis = function()  disposeWWW(www)  print("dispose www"..key) end
			--delay(dis,5,nil)
		else
			Loader.resdic[key] = www.assetBundle.mainAsset --www.assetBundle.mainAsset
			--www.assetBundle:Unload(false) 
			--disposeWWW(www)
		end
	end
end

function Loader:setOnAllCompelteFn(compFn)
	self.multipleLoader.onAllCompleteFn=compFn
end

function Loader:setOnProgressFn(progFn)
	self.multipleLoader.onProgressFn=progFn
end

-- print(Loader.multipleLoader.onCacheFn)
Loader.multipleLoader.onCacheFn=onCache
Loader.multipleLoader.onSharedCompleteFn=onSharedComplete