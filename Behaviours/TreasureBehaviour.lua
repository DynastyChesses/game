local TreasureBehaviour = class(BaseBehaviour, "TreasureBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
function TreasureBehaviour:Open(output)
	local spine = App:applyFunc(ConstData.Spine,  "spineDelCallback", "clickSpine")
	SpineManager.Order(spine, 8 + (self.behaviour.X + 1 + self.behaviour.Y * self.behaviour.map.cellXCount))
	spine.transform:SetParent(self.behaviour.gameObject.transform, false)
	spine.transform.position = (self.behaviour.gameObject.transform.position + Vector3(0, -superMapUtils.cellHeight / 200.0, 0))
	spine.transform.localScale = Vector3(0.8, 0.8, 0.8)
	local parent = GameObjectPool:GetInstance():GetPoolParent()
	spine.transform:SetParent(parent, true)
	App:applyFunc(ConstData.Sound,  "playSound", "openBox")
	App:applyFunc(ConstData.DailyTask,  "CompleteDailyTask", "Treasure", 1)
	local behaviour_tmp = {}
	behaviour_tmp.position = self.behaviour.gameObject.transform.position
	behaviour_tmp.X = self.behaviour.X
	behaviour_tmp.Y = self.behaviour.Y
	behaviour_tmp.cellId  = self.behaviour.cellId
	behaviour_tmp.ItemType = self.behaviour.data.ItemType
	local position = self.behaviour.transform.position
	-- 常规BP 增加经验
	App:applyFunc(ConstData.BattlePass, "NortifyMainEvent", {eventName = "opentreasure", cellId = self.behaviour.cellId, itemType = self.behaviour.data.ItemType, position = position}) -- 倍数
	self.behaviour:DestroyMySelf(function() 
		if not self.behaviour.current_output then
			output = output or {}
		else
			output = self.behaviour.current_output
		end
		self.behaviour.tag = nil -- 宝箱再产生的物品无需有Tag
		App:applyFunc(ConstData.Element, "generateObjectByOutput2", behaviour_tmp, output, function(isFinish, generateAward) 
			-- OpenTreasure
			if (isFinish) then 
				self.scene = SceneManager:GetInstance().current_scene
				local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
				if lvType == ConstData.STR_MASTER then
		            App:applyFunc(ConstData.Task,  "onceTask", "OpenTreasure")
		            App:applyFunc(ConstData.Task,  "onceTask", "OpenTreasure-" .. behaviour_tmp.cellId)
					App:applyFunc(ConstData.NewbiesAndDailyTask, "onceCompleteTask", "OpenTreasure-" .. tostring(behaviour_tmp.ItemType))
		        end
				App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ACTION_COMPLETE, {from = "Treasure", param = {"OpenTreasure"}})
				App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ACTION_COMPLETE, {from = "Treasure", param = {"OpenTreasure-" .. behaviour_tmp.cellId}})
		    end

		    local ssDmdEvent = nil
		    if behaviour_tmp.cellId == "Treasure99_01" then -- 免费宝箱
		    	ssDmdEvent = "Chest_Free"
			elseif string.find(behaviour_tmp.cellId, "NpcTreasure_03") then
				ssDmdEvent = "Chest_Friend"
			elseif string.find(behaviour_tmp.cellId, "BuildingTreasure") then
				ssDmdEvent = "Chest_Building"
			elseif string.find(behaviour_tmp.cellId, "CurrencyTreasure") then
				ssDmdEvent = "Chest_Currency"
			elseif string.find(behaviour_tmp.cellId, "Seedbag") then 
				ssDmdEvent = "Chest_Seebag"
			else
				ssDmdEvent = "Chest_Series"
		    end
		    App:applyFunc(ConstData.DCAuxiliaryTool, "RecordResItem", "get_item_diamond", ssDmdEvent, generateAward)
		    App:applyFunc(ConstData.DCAuxiliaryTool, "RecordResItem", "get_item_coin", ssDmdEvent, generateAward)
		end, true)
	end, 0.3)
end
function TreasureBehaviour:Click(data)
	-- 防止和队列行为界面重叠
	local actionCount = App:applyFunc(ConstData.Cache, "Queue")
	if actionCount > 0 then
		return
	end
	-- 看看需要增加的属性
	if self.clickend then
		return
	end
	if self.behaviour.notClick then
		return
	end
	self.clickend = true
	-- debug.log(data.name)
	-- debug.log("AddType:", data.AddType)
	if string.lower(data.AddType) == string.lower(AwardConst.COIN) then
		-- 金币
		debug.log("金币!")
	elseif string.lower(data.AddType) == string.lower(AwardConst.DIAMOND) then
		-- 钻石
		debug.log("钻石!")
	elseif string.lower(data.AddType) == string.lower(AwardConst.EXP) then
		-- 经验
		debug.log("经验!")
	elseif string.lower(data.AddType) == string.lower(AwardConst.TREASURE) then
		-- 宝箱类
		-- 显示窗口 [UITreasure]
		UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UITreasure, {"expend"} ,{
			behaviour = self,
			data = data
		})
	elseif string.lower(data.AddType) == string.lower(AwardConst.SEED) then
		UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UISeed, {"expend"} ,{
			behaviour = self,
			data = data
		})
	end
	self.clickend = false
end
return TreasureBehaviour