local DecoratePropBehaviour = class(BaseBehaviour, "DecoratePropBehaviour")
local ConstData     = require "Game.Data.LocalData.ConstData"
function DecoratePropBehaviour:Click(data)
	if self.clickend then
		return
	end
	if self.behaviour.notClick then
		return
	end
	self.clickend = true
	-- 清理地皮 这里就是当前地皮
	self.clickend = false
	local map = App:applyFunc(ConstData.MapCore, "getMap")
	
	local elementBehaviour = App:applyFunc(ConstData.Warehouse,  "GetElementByName", self.gameObject.name)
	local propGroup = map.activityProp[data.ItemType] or {}
	local spineMsg = propGroup[elementBehaviour.cellId] or {}

	elementBehaviour:DecorateNpc(spineMsg["npc"] or "NPC_01", spineMsg["animation"] or "idle_1")
end

return DecoratePropBehaviour