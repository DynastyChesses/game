--[[
-- added by lizhe @ 2023/02/09
--]]
local ConstData = require "Game.Data.LocalData.ConstData"
local CircleBoard = class(BaseBehaviour, "CircleBoard")

function CircleBoard:init(content)
	self.content = content
	self.assetPkg = self.content.assetPkg
	self.mapData = self.content.mapData
end

function CircleBoard:Awake()
	if self.onLoaded then
		return
	end
	self.onLoaded = true
	self.animator = UIMgrUtil:getAnimator(self.transform)
    self.canvasGroup = UIMgrUtil:getCanvasGroup(self.transform)
    self.transImgLight = UIMgrUtil:find(self.transform, "ImgLight")
	local transCellRoot = UIMgrUtil:find(self.transform, "CellRoot")
    self.imgCircleBoard = UIMgrUtil:getImage(transCellRoot, "ImgCircleBoard")
    self.imgItemIcon = UIMgrUtil:getImage(self.imgCircleBoard, "ImgItemIcon")
	self.transPinBannerBoard = UIMgrUtil:find(self.imgCircleBoard, "PinBannerBoard")
    self.imgBannerBoard = UIMgrUtil:getImage(self.transPinBannerBoard, "ImgBannerBoard")
    self.textCount = UIMgrUtil:getText(self.imgBannerBoard, "TextCount")
    self.textDes = UIMgrUtil:getText(self.transform, "TextDes")
	self.transform.name = "CircleBoard"
end

function CircleBoard:setContent(task, fromView)
	self:commonContent(task)
	-- App:applyFunc(ConstData.Cache,  "RemoveQueueBykey", "NEWTASK|" .. tostring(self.taskID))

	if string.find(task.Mission, "UpLevel") then
		local LvArr = string.split(task.Mission, "-")
		local LvIndex = tonumber(LvArr[#LvArr])
		local level = UserData:GetInstance():level()
		if LvIndex < level then
			-- 完成任务
			App:applyFunc(ConstData.Task,  "onceTask", task.Mission)
			App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = fromView, param = {task.Mission}})
		end
	end

	self.textCount.text = "x " .. self.taskCount
end

function CircleBoard:commonContent(task)
	if not self.onLoaded then
		self:Awake()
	end
	self.task = task -- 任务table
	self.taskID = task.TaskID -- 任务ID
    self.textDes.text = LangUtil:get(task.TaskName)
		
	local spriteName = task.TaskSprite
	-- 更新图片 增加全局变量
	if spriteName and spriteName ~= "" then
		if string.find(spriteName, "{") then
			local match_str = string.gsub(spriteName, "{(.*)}", function(q)
				local defalut_value = "01"
				if type(q) == ConstData.STR_TYPE then
					-- 替换
					if App[q] then
						defalut_value = App[q]
					end
				end
				return defalut_value
			end)
			spriteName = match_str
		end
	end

	if self.mapData[spriteName] then
		if self.mapData[spriteName].SpriteName and self.mapData[spriteName].SpriteName ~= "" then
			spriteName = self.mapData[spriteName].SpriteName
		end
	end

	local adapt = Config.CircleBoardAdapt[self.content.transform.name]
    -- 特殊任务表示
	local spriteCircleName = Config.TaskTypeNames.NormaCircle
	local spriteBannerName = Config.TaskTypeNames.NormalBanner
	if task["loopType"] then
		spriteCircleName = Config.TaskTypeNames.LoopCircle
		spriteBannerName = Config.TaskTypeNames.LoopBanner
	end
	SpriteManager:SetUISprite(self.assetPkg, self.imgCircleBoard.gameObject, ResCfg.Altas.UIMainView, spriteCircleName, true, function()
		self.imgCircleBoard.transform.localScale = Vector3.one * adapt.Circle
	end)
	SpriteManager:SetUISprite(self.assetPkg, self.imgBannerBoard.gameObject, ResCfg.Altas.UIMainView, spriteBannerName, true, function()
		self.transPinBannerBoard.transform.localScale = Vector3.one * adapt.Banner / adapt.Circle
	end)

	-- 解析Mission
	local MissionArray = string.split(task.Mission, "-")
	self.taskCount = tonumber(MissionArray[#MissionArray]) -- 任务数量
	self.taskCount = self.taskCount or 1
	
	App:applyFunc(ConstData.Sprite, "getSpriteVecUI", spriteName, function(sprite, pivot, scale) 
		App:applyFunc(ConstData.Sprite, "UICheckSizeDelta", self.imgItemIcon, sprite, pivot, scale)
	end)
end

function CircleBoard:setContentDisplay(task, isTaskBar)
	self:commonContent(task)
	self.textCount.text = '<color="red">'.. math.floor(tonumber(task.Current)) ..'</color>/' .. self.taskCount

	if not isTaskBar then
		return
	end
	local current = task.Current
	local count = self.taskCount
	-- local rect = UIMgrUtil:getRectTransform(self.transform)
	-- local sizeDelta = rect.sizeDelta
	-- rect.sizeDelta = sizeDelta * 0.7
	self.transform.name = task.TaskID
	-- 更新Text
	if current < count then
		self.imgItemIcon.color = Color(1, 1, 1, 1)
		self.imgCircleBoard.color = Color(1, 1, 1, 1)
		self.transPinBannerBoard.gameObject:SetActive(true)
		-- right隐藏
		self.transform:Find("right").gameObject:SetActive(false)
		self.transform:Find("right"):GetComponent("Image").color = Color(0, 0, 0, 0)
		local luaNotifier = self.transform:GetComponent("LuaNotifier")
		luaNotifier:AddListener(LuaNotifier.KEY_ONCLICK, self.content.OnClick, self.content)
	else
		-- 更新界面
		self.imgItemIcon.color = Color(0.5, 0.5, 0.5, 1)
		self.imgCircleBoard.color = Color(0.5, 0.5, 0.5, 1)
		self.transPinBannerBoard.gameObject:SetActive(false)
		-- right显示
		self.transform:Find("right").gameObject:SetActive(true)
		self.transform:Find("right"):GetComponent("Image").color = Color(1, 1, 1, 1)
	end
end

function CircleBoard:setStatus(status)
	self.animator.enabled = status
	self.canvasGroup.alpha = status and 1 or 0
end

function CircleBoard:fly(index)
	index = index or 1
	local go = AGameObject.Instantiate(self.gameObject)
	local tiplLayer = UIMgrUtil:getUILayerGameObject(UILayers.TipLayer)
	go.transform:SetParent(tiplLayer.transform)
	go.transform.localScale = self.transform.localScale
	go.transform.position = self.transform.position
	self.flyBehaviour = BehaviourUtil.AddOrReplaceBehaviour(go, CircleBoard, self.content)
	self.flyBehaviour.animator.enabled = false
	self.flyBehaviour.canvasGroup.alpha = 1
	self.flyBehaviour.transImgLight.gameObject:SetActive(false)
	self.flyBehaviour.textDes.gameObject:SetActive(false)
	local textCount = self.flyBehaviour.textCount
	local count = self.taskCount
	local taskID = self.taskID
	local textObj = self.flyBehaviour.textCount.gameObject
	local text = self.flyBehaviour.textCount
	local textRect = textObj:GetComponent("RectTransform")
	local oldColor = text.color
	local banner = self.flyBehaviour.imgBannerBoard.transform:GetComponent("RectTransform")
	local icon = self.flyBehaviour.imgItemIcon
	local aid01 = AnimateTween.colorTextTo(textObj.gameObject, Color(0, 0, 0, 0), 0.1)
	AnimateTween.setCallBack(aid01, function() 
		text.text = "<color=red>0</color>/" .. tostring(count)
		text.fontSize = 22
		AnimateTween.colorTextTo(textObj.gameObject, oldColor, 0.1)
	end)
	-- 飞入制定位置
	local dst = App:applyFunc(ConstData.Task,  "refreshToolBar", taskID, false, true)
	-- 获取第一位置
	local uiTaskBar = UIMgrUtil:getUIPanelViewGameObject(Config.UIWindowNames.UITaskBar)
	local levelType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
	local dst_position = uiTaskBar.transform:Find("taskBar/" .. index).transform.position
	if dst then
		-- 增加粒子 TODO
		dst_position = dst_position or dst.transform.position
		AnimateTween.delayCall(go, 0.1, function()
			local aid_move = AnimateTween.moveToV3(go.gameObject, dst_position, 0.8)
			aid_move:setEase(LeanTweenType.easeOutCubic)
			local adapt = Config.CircleBoardAdapt[Config.UIWindowNames.UITaskBar]
			local aid_scale_circle = AnimateTween.scaleTo(self.flyBehaviour.imgCircleBoard.gameObject, Vector3.one * adapt.Circle, 0.8)
			aid_scale_circle:setEase(LeanTweenType.easeOutCubic)
			local aid_scale_banner = AnimateTween.scaleTo(self.flyBehaviour.transPinBannerBoard.gameObject, Vector3.one * adapt.Banner / adapt.Circle, 0.8)
			aid_scale_banner:setEase(LeanTweenType.easeOutCubic)
			local aid_scale_text = AnimateTween.scaleTo(self.flyBehaviour.textCount.gameObject, Vector3.one / adapt.Banner, 0.8)
			aid_scale_text:setEase(LeanTweenType.easeOutCubic)
			local task = App:applyFunc(ConstData.Cache, "EnqueuePopup", CacheCfg.ActionType.NewTask)
			if task then
				AnimateTween.delayCall(go, 0.1, function()
					go.transform:SetParent(UIMgrUtil:getUILayerGameObject(UILayers.BackgroudLayer).transform)
				end)
			end
			AnimateTween.delayCall(dst.gameObject, 0.25, function()
				dst.gameObject:SetActive(true)
				dst.gameObject.transform.localScale = Vector3.zero
			end)

			AnimateTween.setCallBack(aid_move, function() 
				local scale = go.transform.localScale
				local aid  = AnimateTween.scaleTo(go.gameObject, scale * 1.1, 0.2)
				aid:setEase(LeanTweenType.easeOutCubic)
				aid:setLoopPingPong(1)
				AnimateTween.setCallBack(aid, function()
					if not IsNil(go) then
						UGameObject.DestroyImmediate(go.gameObject)
					end
					if not IsNil(dst) then
						dst.gameObject.transform.localScale = Vector3.one
					end
				end)
			end)
		end)
	else
		if go then
			UGameObject.DestroyImmediate(go.gameObject)
			go = nil
		end
	end
end

return CircleBoard