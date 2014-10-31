luanet.load_assembly(assemblyname)

local ToLuaCSTest = luanet.ToLuaCSTest -- 1 生成toluacs的metatable
StaticToLuaCSTest = toluacs.ToLuaCSTest -- 静态属性的获取要从 toLuaCS表中获取
--==========================静态方法调用测试==========================
-- StaticToLuaCSTest = ToLuaCSTest --放开注释表示不用toluacs 可以对比性能差距

local t = 100000
local dt = nil
local b=os.clock()
for i=1,t do
	local re=StaticToLuaCSTest.Add(i-1,t-i)
end
dt = os.clock()-b
print(string.format("Static ToLuaCSTest lua times = %s w, dt=%s ms, re =%s",t/10000,dt*1000,1))

--==========================实例方法调用测试==========================
local instance_ToLuaCSTest = ToLuaCSTest()
b=os.clock()
for i=1,t do
	local re=instance_ToLuaCSTest:Ins_Add(i-1,t-i)
end
dt = os.clock()-b
print(string.format("instance ToLuaCSTest lua times = %s w, dt=%s ms, re =%s",t/10000,dt*1000,1))


--=============================================下面两组为启用和不启用toluacs性能差异
--启用 
-- LUA: Static ToLuaCSTest lua times = 10 w, dt=15.999999999622 ms, re =1
-- LUA: instance ToLuaCSTest lua times = 10 w, dt=46.999999999571 ms, re =1
--不启用 （删除对应的LuaToToLuaCSTest类）
-- LUA: Static ToLuaCSTest lua times = 10 w, dt=578.00000000043 ms, re =1
-- LUA: instance ToLuaCSTest lua times = 10 w, dt=329.00000000063 ms, re =1

--==================================获取语言包====================================
luanet.import_type("Localization") --生成toluacs 绑定
Localization = toluacs.Localization--luanet.import_type("Localization") --toLuaCS.Localization --

local Localization = Localization
Localization.language="Chinese"

local testfn = function()
	local b=os.clock()
	for i=1,t do
		Localization.Get("quest_title_600001")
	end
	local dt = os.clock()-b
	print(string.format(" language lua times = %s w, dt=%s, re =%s",t/10000,dt*1000,1))
end

delay(testfn,2)
