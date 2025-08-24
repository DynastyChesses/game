local SkinBehaviour = class(BaseBehaviour, "SkinBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
local TH_SKIN_ADD = "_TH_SKIN_ADD"
function SkinBehaviour:Click(data, nearTrigger)
	if self.clickend then
		return
	end
	self.clickend = true
	self:delayedCall(0.33, function() 
		self.clickend = false
	end)

	-- 音效 + 震动
	App:applyFunc(ConstData.Sound,  "PlaySoundAndVibrate", "tap")
	if not App:applyFunc(ConstData.FirstPlayTeach, "CheckTeached", "Ph08_Skin_Show") then 
		App:applyFunc(ConstData.FirstPlayTeach, "StartTeach", "Ph08_Skin_Show")
	end
	-- 增加经验
	App:applyFunc(ConstData.Hint, "CancelArrow", table.concat({self.behaviour.gameObject.name, "_Arrow"}))
    if self.behaviour then
    	-- TODO 特效
	end

    UserData:GetInstance():flyPropOnly("BtnSet", "Image", self.behaviour.cellId, self.transform.position, function()
		if UPlayerPrefs.GetInt(CURRENT_USER .. TH_SKIN_ADD, 1) == 1 then 
			UPlayerPrefs.SetInt(CURRENT_USER .. TH_SKIN_ADD, 2)
			MessageManager:GetInstance():Broadcast(MessageConst.UI_MAINVIEW_VIEW_REFRESH_EVENT)
		end
	end, nil, self.behaviour.data.AddCount or 1, {group = "UI_Static"})
    App:applyFunc(ConstData.SkinSystem, "AddChips", self.behaviour.cellId, self.behaviour.data.AddCount or 1)

	self.behaviour:DestroyMySelf(function()

	end)
end

return SkinBehaviour