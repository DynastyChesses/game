local CloudAirBallBehaviour = class(BaseBehaviour, "CloudAirBallBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local SpriteBehaviour   = require("Game.Behaviours.SpriteBehaviour")
function CloudAirBallBehaviour:Awake()
	self.map = App:get(ConstData.STR_MAP)
	self.mapData = ClientData:GetInstance():MapData()
end

-- 初始化数据
function CloudAirBallBehaviour:InitBehaviour(cloudName)
	self.cloudName = cloudName
	self.balloon = self.gameObject.transform:Find("ballonSkel")
	self.balloon.transform.localScale = Vector3.one
    self:BalloonAppear()
    BaseLogic:GetInstance():AddClick(self, nil, nil, self.onClick)
	BehaviourUtil.AddOrReplaceBehaviour(self.balloon.gameObject, SpriteBehaviour, self)
end

function CloudAirBallBehaviour:LeaveGo(isInVisible)
	self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
	self.extDragComp.enabled = isInVisible
	self.boxCollider2D = self.boxCollider2D or self.gameObject:GetComponent("BoxCollider2D")
	self.boxCollider2D.enabled = isInVisible
	self.isInVisible = isInVisible
	if self.aniName == "idle_present" then 
		NormalUtils.SpineAnimationStateAdjust(self.gameObject, isInVisible)
	end
end
-- 切换气球的状态
function CloudAirBallBehaviour:SwitchBalloonState(aniName, loop, callback)
	if not self.balloon then return end
	self.aniName = aniName
	SpineManager.Reset(self.balloon.gameObject)
	SpineManager.Play(self.balloon.gameObject, aniName, loop)
	if callback then
		local ani_time = SpineManager.getAnimationTime(self.balloon.gameObject, aniName) or 0
		AnimateTween.delayCall(ani_time, function ()
			if self.balloon then 
				callback()
			end
		end)
	end
end

-- 气球出场
function CloudAirBallBehaviour:BalloonAppear()
	--不播放出现动画 ，别的状态不对，
	self:SwitchBalloonState("appear_present", false, function ()
		self:SwitchBalloonState("idle_present", true)
		self:LeaveGo(self.isInVisible)
	end)

	if self.good then
		local oldPos = self.good.transform.localPosition
		local newPos = Vector3(0, -0.3, 0)
		self.good.color = Color(self.good.color.r, self.good.color.g, self.good.color.b, 0)
		AnimateTween.alphaTo(self.good.gameObject, 1, 0.66)
		AnimateTween.moveToLocal3(self.good.gameObject, newPos, 0.66)
	end
end

function CloudAirBallBehaviour:Disappear()
	self:SwitchBalloonState("disappear_present", false, function()
		if (self.gameObject) then
			UGameObject.DestroyImmediate(self.gameObject)
			self:onDisappear()
		end
	end)
end

function CloudAirBallBehaviour:onDisappear()
	self.balloon = nil	
end

function CloudAirBallBehaviour:onClick()
	if App:applyFunc(ConstData.FirstPlayTeach, "InForceState") then 
        return
    end
    if App:applyFunc(ConstData.Cloud, "GetBuyStatues") then 
    	return
    end
	local view = UIManager:GetInstance():GetView(Config.UIWindowNames.UICloudBuyPannel)
	if view then
		return
	end
    if FakeCorouteInst then
        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 3, function() 
        	if GlobalDataMgr:GetBidMove() then
		    	return
		    end
		    if Global.UIMainViewClick then
		    	return
		    end

		    self.map.offsetPositionLen = currentController.map.offsetPositionLen or 0
		    if self.map.offsetPositionLen > 50 then
		        return
		    end

		    if App:applyFunc(ConstData.FirstPlayTeach, "OnSeal") then 
		    	return
		    end
			local view = UIManager:GetInstance():GetView(Config.UIWindowNames.UICloudBuyPannel)
			if view then
				return
			end
		
			if self.clicked then
				return
			end
			self.clicked = true	
			UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UICloudBuyPannel, {"expend"}, self, self.cloudName)
    	end)
    end
end

function CloudAirBallBehaviour:ClickCancel()
	self.clicked = false
end

return CloudAirBallBehaviour