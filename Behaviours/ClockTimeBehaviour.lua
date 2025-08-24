--[[
-- added by lizhe @ 2023/02/11
--]]
local ConstData = require "Game.Data.LocalData.ConstData"
local ClockTimeBehaviour = class(BaseBehaviour, "ClockTimeBehaviour")

function ClockTimeBehaviour:Awake()
    self.skelClock = UIMgrUtil:findAndGetComponent(self.transform, "SkelClock", UIMgrUtil.UIComponent.SkeletonGraphic)
    self.textTime = UIMgrUtil:findAndGetComponent(self.transform, "TextTime", UIMgrUtil.UIComponent.Text)
	self.imgBoard = UIMgrUtil:getImage(self.transform)
    self.dataMsg = nil
	self.callback = nil
end

function ClockTimeBehaviour:OnEnable()
	self.secondTime = 1
	self.runOnce = false
end

-- TODO 设置底板
function ClockTimeBehaviour:SetBoard()
	
end

-- func 获取倒计时
-- dataMsg table,倒计时的表，一定要包含remaintime
-- callback 倒计时走完执行的func
function ClockTimeBehaviour:GetTick(dataMsg, callback)
	self.dataMsg = dataMsg
	self.callback = callback
	self.secondTime = 1
	self.runOnce = false
    self.gameObject:SetActive(true)
end

function ClockTimeBehaviour:Hide()
	self.gameObject:SetActive(false)
end

function ClockTimeBehaviour:SetLanguage(id)
	self.timeText.text = LangUtil:get(id)
end

function ClockTimeBehaviour:Update()
	if self.dataMsg then
		if self.runOnce then
			self.runOnce = false
		end

		self.secondTime = self.secondTime + Time.deltaTime
		if self.dataMsg.remaintime and self.dataMsg.remaintime > 0 then
			if self.secondTime < 1 then
				return
			end
			self.secondTime = 0	
			local data = self:GetTimeMsg(self.dataMsg.remaintime)
			if data.day > 0 then
				self.textTime.text = table.concat({data.day, " Day ", data.hour, "H"})
			else
				self.textTime.text = string.format("%02d:%02d:%02d", data.hour, data.min, data.second)
			end
		else
			self.dataMsg = clone(self.dataMsg) -- 防止污染数据
			self.dataMsg = nil
			self.secondTime = 1
			local data = self:GetTimeMsg(0)
			self.textTime.text = string.format("%02d:%02d:%02d", data.hour, data.min, data.second)
		end
	else
		if not self.runOnce then
			self.runOnce = true
			if self.callback then
				self.callback()
				self.callback = nil
			end
		end
	end
end

function ClockTimeBehaviour:GetTimeMsg(timeTick)
	local day  = math.floor(timeTick / (24 * 60 * 60))
	local hour = math.floor((timeTick - day * 24 * 60 * 60) / 3600)
	local min = math.floor(((timeTick - day * 24 * 60 * 60 - hour * 60 * 60)% 3600) / 60)
	local second = math.floor(timeTick) - min * 60 - hour * 3600 - day * 24 * 60 * 60
	return {day = day, hour = hour, min = min, second = second}
end

return ClockTimeBehaviour