--[[
-- added by lizhe @ 2023/03/03
--]]
local ConstData = require "Game.Data.LocalData.ConstData"
local StoryConfigData = require "Game.Data.LocalData.StoryConfigData"
local DialogBehaviour = class(BaseBehaviour, "DialogBehaviour")

function DialogBehaviour:init(content)
    self.content = content
    self.assetPkg = self.content.assetPkg
    self.config = self.content.config
    self.currentPart = self.content.currentPart
end

function DialogBehaviour:Awake()
    self.animator = UIMgrUtil:getAnimator(self.transform)
	self.transDialogBox = UIMgrUtil:find(self.transform, "DialogBox")
	self.textNpcName = UIMgrUtil:getText(self.transDialogBox, "Board/Name/Text")
	self.textDialog = UIMgrUtil:getText(self.transDialogBox, "Board/Text")
	
	self.roles = {"RoleA", "RoleB", "RoleC", "RoleD"}
	self.goRole = UIMgrUtil:find(self.transDialogBox, "RoleRoot/Role").gameObject
	self.rectRole = UIMgrUtil:getRectTransform(self.goRole.transform)
end

function DialogBehaviour:talk(isFirst)
	self.config = self.content.config
	self.currentPart = self.content.currentPart
	local npcName = nil
	local spineName = nil
	for k, v in pairs(self.roles) do
		if (self.config[tostring(self.currentPart)] and self.config[tostring(self.currentPart)][v]) then 
			local arr = string.split(self.config[tostring(self.currentPart)][v], "-")
			local npcMsg = string.split(self.config[tostring(self.currentPart)][v], "_")
			if (arr[2] == "1") then
				npcName = npcMsg[1]
				local npcSpines = string.split(npcMsg[2], "-")
				spineName = StoryConfigData.NpcSpineTable[npcSpines[1]]
				debug.log(spineName, "动画名称")
				break
			end
		end
	end

	if not npcName then
		return
	end
	self.content.talking = true
	if self.cacheNpcName then
		if self.cacheNpcName ~= npcName then
			self.animator:SetTrigger(Config.AnimatorTriggerNames.TriggerShowAgain)
			AnimatorUtil:delayCall(self.animator, function()
				self:ShowContent(npcName, spineName)
			end, nil, Config.AnimationClipNames.DialogSwitchHide)

			AnimatorUtil:addCompleteCallback(self.animator, function()
				self.content.talking = false
			end, Config.AnimationClipNames.DialogSwitchShow)
		else
			-- TODO
			self:ShowContent(npcName, spineName)
			self.content.talking = false
		end
	else
		self:ShowContent(npcName, spineName)
		self.animator:SetTrigger(Config.AnimatorTriggerNames.TriggerShow)
		AnimatorUtil:addCompleteCallback(self.animator, function()
			self.content.talking = false
		end, Config.AnimationClipNames.DialogShow)
	end
	self.cacheNpcName = npcName
end

function DialogBehaviour:ShowContent(npcName, spineName)
	self.textNpcName.text = LangUtil:get(self.config[tostring(self.currentPart)].RoleName)
	local realNpcName = string.gsub(npcName, "AvatarNpc", "")
	local spinePath = ResCfg:getPathSpine(ResCfg.SpineRes.StoryNpc, realNpcName)
	self.assetPkg:SetSkeletonDataASync(self.goRole, spinePath, function()
		SpineManager.UIReset(self.goRole)
		SpineManager.UIPlay(self.goRole, spineName, true)
	end)
	local rolePosition = self.rectRole.localPosition
	self.rectRole.localPosition = Vector3(rolePosition.x, StoryConfigData.NpcYPosition[npcName] or -263, 0)
	self.rectRole.localScale = Vector3.one * (StoryConfigData.NpcScale[npcName] or 1)
	-- 更新文字
	local nickName = UserDataMgr:GetInstance():GetNickName() or ""
	self.textDialog.text = LangUtil:getFormat(self.config[tostring(self.currentPart)].Content, nickName, nickName, nickName)
end

return DialogBehaviour