local StateManager = StateManager
local LuaItemManager = LuaItemManager
local StateBase = StateBase
StateManager:setStateTransform(LuaItemManager:getItemObject("transform"))
-- StateManager:showTransform()
StateManager.hello=StateBase({LuaItemManager:getItemObject("hello")},"hello") --frist 
StateManager.tetris=StateBase({LuaItemManager:getItemObject("tetris")},"tetris")
