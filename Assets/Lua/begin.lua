require("const.importClass")
require("const.requires")
require("registerItemObjects")
require("registerState")
require("uiInput")

local os=os
local pLua=PLua.instance
local UPDATECOMPONENTS=UPDATECOMPONENTS
local StateManager=StateManager


StateManager:setCurrentState(StateManager.hello)--StateManager.login

local function update()
	local cmp
	local len
	while true do
		len = #UPDATECOMPONENTS
		local ostime=os.clock()
		for i=1,len do
			cmp=UPDATECOMPONENTS[i]
			if cmp.enable then	cmp:onUpdate(ostime) end
		end

		coroutine.yield()
	end
end

pLua.updateFn=update


