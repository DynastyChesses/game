local MagicBehaviour = class(BaseBehaviour, "MagicBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
local TH_STICK_ICON  = "_TH_STICK_ICON"        -- 魔石图标的本地设置
function MagicBehaviour:Click(data)
	if self.clickend then
		return
	end
	if self.behaviour.notClick then
		return
	end
	self.clickend = true
	-- 看看需要增加的钱
	self.map = App:get(ConstData.STR_MAP)
	-- 清理地皮
	local index = self.behaviour.X + 1 + self.behaviour.Y * self.map.cellXCount
	self.map.emptyMatrix[index] = true
	self.map.currentMatrix[index] = ""
	local spine = App:applyFunc(ConstData.Spine,  "spineDelCallback", "clickSpine")
	SpineManager.Order(spine, 8 + index)
	spine.transform:SetParent(self.behaviour.gameObject.transform, false)
	spine.transform.position = (self.behaviour.gameObject.transform.position + Vector3(0, -superMapUtils.cellHeight / 200.0, 0))
	spine.transform.localScale = Vector3(0.8, 0.8, 0.8)
	local parent = GameObjectPool:GetInstance():GetPoolParent()
	spine.transform:SetParent(parent, true)
	if App:applyFunc(ConstData.DCAuxiliaryTool, "IsFirstMagic") then 
        App:applyFunc(ConstData.DCAuxiliaryTool, "RecordDataTutorial", "Free_01_use_runes")
		App:applyFunc(ConstData.WbBi, "DurationEnd", DCData.new_guide, "step_08_free_01_use_runes", {step = "step_08_free_01_use_runes"})
    end

	if self.behaviour.tag == "Food_Cook_Teach" then 
		App:applyFunc(ConstData.WbBi, "DurationEnd", DCData.new_guide, "step_15_free_02_use_runes", {step = "step_15_free_02_use_runes"})
		App:applyFunc(ConstData.WbBi, "DurationStart", DCData.new_guide, "step_16_free_02_unlock_cloud_2")
	end
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    self.scene = SceneManager:GetInstance().current_scene
    if self.behaviour then
    	local position = self.behaviour.gameObject.transform.position
		ClientData:GetInstance():upMagic(tonumber(self.behaviour.data.AddCount), nil, position, nil, {reason = "use_item"})
	end
	
    MessageManager:GetInstance():Broadcast(MessageConst.UI_MAINVIEW_VIEW_REFRESH_EVENT)
    if (self.behaviour.tag) then 
		App:applyFunc(ConstData.FirstPlayTeach, "EmitEvent", "WEAK_POINT", self.behaviour.tag)
		App:applyFunc(ConstData.Cloud, "WatchCloud")
	else
		App:applyFunc(ConstData.Cloud, "WatchCloud")
	end

	self.behaviour:DestroyMySelf(function() 
	end, 0)
end
return MagicBehaviour