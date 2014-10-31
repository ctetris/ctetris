local hello = LuaItemManager:getItemObject("hello")
local StateManager = StateManager
local delay = delay
-- local LuaHelper=LuaHelper

hello.assets=
{
  Asset("Hello.u3d")
}

function hello:onAssetsLoad(items)
   
end


function hello:onClick(obj,arg)
	local cmd =obj.name
	if cmd == "Button" then
		print(" you are click "..cmd)
    StateManager:setCurrentState(StateManager.tetris)
	end
 -- print("hello onclick "..obj.name)
end
