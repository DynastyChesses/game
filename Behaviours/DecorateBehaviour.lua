local DecorateBehaviour = class(BaseBehaviour, "DecorateBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"

function DecorateBehaviour:Click(data)
	if self.clickend then
		return
	end
	if self.behaviour.notClick then
		return
	end
	self.clickend = true
	-- 清理地皮 这里就是当前地皮
	local spine = self.transform:Find("spine").gameObject
	if spine and spine.gameObject.activeSelf then
		SpineManager.RegisterAnimationCallback(spine, function(spine, name)
			SpineManager.UnRegisterAnimationCallback(spine)
			SpineManager.Play(spine, "idle", true)
			self.clickend = false
		end, _)
		SpineManager.Play(spine, "Clickon", false)
	else
		self.behaviour:shake()
		App:applyFunc(ConstData.Sound,  "playSound", "touch")
		AnimateTween.delayCall(0.3, function()
			self.clickend = false
		end)
	end 
	-- 弹出UI
	local extraData = ClientData:GetInstance():ExtraData()
	if extraData and extraData[self.behaviour.cellId] then
		if extraData[self.behaviour.cellId]["UIName"] then
			if extraData[self.behaviour.cellId]["Params"] then
				UIManager:GetInstance():OpenWindow(extraData[self.behaviour.cellId]["UIName"], {"expend"}, extraData[self.behaviour.cellId]["Params"])
			else
				UIManager:GetInstance():OpenWindow(extraData[self.behaviour.cellId]["UIName"], {"expend"})
			end
		end
	end
end

return DecorateBehaviour