local FoodBehaviour = class(BaseBehaviour, "FoodBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
function FoodBehaviour:Click(data, nearTrigger)
	if self.clickend then
		return
	end
	self.clickend = true
	self:delayedCall(0.33, function() 
		self.clickend = false
	end)
	-- 音效 + 震动
	-- App:applyFunc(ConstData.Sound,  "PlaySoundAndVibrate", "tap")
	AnimateTween.cancelAllObject(self.gameObject, false)
	local spine = App:applyFunc(ConstData.Spine,  "spineDelCallback", "clickSpine")
	SpineManager.Order(spine,  8 + (self.behaviour.X + 1 + self.behaviour.Y * self.behaviour.map.cellXCount))
	spine.transform:SetParent(self.behaviour.gameObject.transform, false)
	spine.transform.position = (self.behaviour.gameObject.transform.position + Vector3(0, -superMapUtils.cellHeight / 200.0, 0))
	spine.transform.localScale = Vector3(0.8, 0.8, 1)
	local parent = GameObjectPool:GetInstance():GetPoolParent()
	spine.transform:SetParent(parent, true)
	-- 增加经验
	App:applyFunc(ConstData.Hint, "CancelArrow", table.concat({self.behaviour.gameObject.name, "_Arrow"}))
    if self.behaviour then
    	if self.behaviour.data.AddCount > 0 then
    		ClientData:GetInstance():upExp(tonumber(self.behaviour.data.AddCount), nil, self.behaviour.gameObject.transform.position + Vector3(0, 0.2, 0))
    		ClientData:GetInstance():upCoin(tonumber(self.behaviour.data.AddCount), nil, self.behaviour.gameObject.transform.position + Vector3(0, 0.2, 0))
    	end
	end
	-- if self.behaviour.cellId == "Food01_GS" then
	-- 	local count = App:applyFunc(ConstData.Warehouse,  "getCacheObjectCount", self.behaviour.cellId)
	-- 	if count > 0 then
	-- 		count = count - 1
    -- 	end
    -- 	if count == 0 then
	-- 		if not App:applyFunc(ConstData.MapArea, "existHash", "Food01_GS") then
	-- 			App:applyFunc(ConstData.MapArea, "saveHash", "Food01_GS")
	-- 			-- 
	-- 			MessageManager:GetInstance():Broadcast(MessageConst.UI_MAINVIEW_VIEW_REFRESH_EVENT)
	-- 		end
	-- 	end
	-- end
	if self.behaviour.tag == "Food_Cook_Teach" then
		local collect_time = App:applyFunc(ConstData.WbBi, "GetLifeData", WbBiLifeConst.wheat_collect_time) or 0
		collect_time = collect_time + 1
		if collect_time < 2 then 
			App:applyFunc(ConstData.WbBi, "DurationEnd", DCData.new_guide, "step_12_free_02_collect_wheat", {step = "step_12_free_02_collect_wheat"})
		end
		App:applyFunc(ConstData.WbBi, "ModifyLifeData", WbBiLifeConst.wheat_collect_time, collect_time)
	end
	
    App:applyFunc(ConstData.Task,  "onceTask",  table.concat({"AddFood-", self.behaviour.cellId}))
	-- 因为飞特效这个事情, bu允许在跳转场景后执行，所以，这里我们只能放在事件里
	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Food", param = {table.concat({"AddFood-", self.behaviour.cellId})}, other = {self.behaviour.cellId, self.transform.position}})
    App:applyFunc(ConstData.Warehouse,  "addFood", self.behaviour.cellId)

    if not nearTrigger then -- 不是由周围的物品触发，而是玩家主动点击
    	App:applyFunc(ConstData.FirstPlayTeach, "NearByCollect", self.behaviour)
    end

	self.behaviour:DestroyMySelf(function() 
		App:applyFunc(ConstData.DailyTask,  "CompleteDailyTask", "Collect", 1)
	end)
end

return FoodBehaviour