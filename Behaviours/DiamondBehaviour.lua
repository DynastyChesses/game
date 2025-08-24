local DiamondBehaviour = class(BaseBehaviour, "DiamondBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
function DiamondBehaviour:Click(data)
	if self.clickend then
		return
	end
	if self.behaviour.notClick then
		return
	end
	self.clickend = true
	-- 看看需要增加的钻石
	self.map = App:get(ConstData.STR_MAP)
	local spine = App:applyFunc(ConstData.Spine,  "spineDelCallback", "clickSpine")
	SpineManager.Order(spine, 8 + (self.behaviour.X + 1 + self.behaviour.Y * self.behaviour.map.cellXCount))
	spine.transform:SetParent(self.behaviour.gameObject.transform, false)
	spine.transform.position = (self.behaviour.gameObject.transform.position + Vector3(0, -superMapUtils.cellHeight / 200.0, 0))
	spine.transform.localScale = Vector3(0.8, 0.8, 0.8)
	local parent = GameObjectPool:GetInstance():GetPoolParent()
	spine.transform:SetParent(parent, true)
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    self.scene = SceneManager:GetInstance().current_scene
    if self.behaviour then
    	-- 提供位置点
    	local position = self.behaviour.gameObject.transform.position
    	ClientData:GetInstance():upDiamond(tonumber(self.behaviour.data.AddCount), nil, position, nil, nil, nil, nil, {reason = "use_item"})
    	App:applyFunc(ConstData.DCAuxiliaryTool, "RecordDataResource", "get_currency_diamond", "UseItem", self.behaviour.data.AddCount)
    end
	self.behaviour:DestroyMySelf()
end
return DiamondBehaviour