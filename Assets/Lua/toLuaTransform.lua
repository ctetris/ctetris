require("core.unity3d")
require("core.loader")
require("const.importClass")
json=require("lib/json")

local Quaternion = toluacs.UnityEngine.Quaternion -- 注释后取消toluacs功能 可用于性能对比
Transform = UnityEngine.Transform   -- 注释后取消toluacs功能 可用于性能对比

local t = 10000
local Cube=toluacs.UnityEngine.GameObject.Find("Cube")
local v1=Vector3.up
local transform = Cube.transform

local b=os.clock()
local dt = os.clock()-b
for i=1,t do
	transform.rotation= Quaternion.Euler(0, i, 0)
end
dt = os.clock()-b
print(string.format("transform.rotation lua times = %s w, dt=%s, re =%s",t/1000,dt*1000,1))


-- function loop(trans)
-- 	local v = luanet.UnityEngine.Vector3.one
-- 	for i=1,10000 do
-- 		trans.position=v
-- 	end
-- end