-- @author 	tomyuan
-- @datetime 2021.04.30
-- @desc 基础元素类别
local ConstData = require "Game.Data.LocalData.ConstData"
local ElementBehaviour 	= class(BaseBehaviour, "ElementBehaviour")
local StatusConst 		= require "Game.Data.LocalData.StatusConst"
local DialogBehaviour = class(BaseBehaviour, "DialogBehaviour")
local TimerFreeBtnBehaviour = class(BaseBehaviour, "TimerFreeBtnBehaviour")
local DiamondQuickBtnBehaviour = class(BaseBehaviour, "DiamondQuickBtnBehaviour")
local SpriteBehaviour   = require("Game.Behaviours.SpriteBehaviour")
local ElementInfoData = require "Game.Data.LocalData.ElementInfoData"
local StoryBannerBehaviour = require "Game.Behaviours.StoryBannerBehaviour"
local ActivityCollectBanner = require "Game.Comps.Activity.ActivityCollectBanner"
local TaleItem = require "Game.Data.LocalData.TaleItem"
local GRADIENT_TIME = 1 -- 灰色到彩色的渐变
local UP_LAYER_ID   = "OverMask"
local ORIGIN_LAYER  = "Default"

local GRUB_SCALE      = Vector2(0.5, 0.5) 		-- 调整小爪子大小的方法
local GRUB_OFFSET     = Vector2(0, 0)      		-- 调整小爪子偏移量的方法
local GRUB_POS_OFFSET = Vector3(-0.2, 0.4, 0)          -- 小手位置的偏移量
local superMapUtils = SuperMapUtils.Instance
local cellHeight = superMapUtils.cellHeight / 200
local cellWidth = superMapUtils.cellWidth / 200
local CountStatus = {
	Counted = "Counted",
	Remove  = "Remove"
}
------------------------------------- 动画方法 ------------------------------------------
function ElementBehaviour:BezierMove(startPosition, position, func, updateFunc, scale, initAble)
	if IsNil(self.sprite) then
		return
	end
	local endPosition = Vector3(position.x, position.y - cellHeight, position.z)
	-- 计算距离
	startPosition = startPosition or endPosition
	local distance = math.sqrt((endPosition.x - startPosition.x) * (endPosition.x - startPosition.x) + (endPosition.y - startPosition.y) * (endPosition.y - startPosition.y))
	
	self.sprite.gameObject.transform.localScale = Vector3(scale or 0.25, scale or 0.25, 1)
	-- 曲线移动
	local OffX = math.abs(endPosition.x - startPosition.x)
	local offY = 0.3 + OffX / 40.0
	--
	if offY > 0.5 then
		offY = 0.5
	end
	self.transform.position = startPosition
	
	local midPosition1 = startPosition + (endPosition - startPosition) * 0.35 + Vector3(0, offY, 0)
    local midPosition2 = startPosition + (endPosition - startPosition) * 0.65 + Vector3(0, offY, 0)
    local speed =  distance * 2.25
    speed = math.sqrt(speed) * 4
    if speed < 11 then
    	speed = 11
    end

    -- move方法传参应该是(点1，控制点2，控制点1，点2)
    local aid = AnimateTween.BezierMov(self.gameObject, 0.3, 
        startPosition,
        midPosition2, 
        midPosition1, 
        endPosition
    )

	if initAble then
		initAble = false
	    if self.particle then 
			App:applyFunc(ConstData.Particle, "GetParticle", self.transform, self.particle)
		end
	end

    AnimateTween.setCallBack(aid, function() 
    	self.eleIsMoving = false
    	self.justStop = self.isMovingCenter
		if func then
			func()
		end
	end)
end

function ElementBehaviour:BounceBackQuick()
	if self.bounceBackAid then
		AnimateTween.cancel(self.bounceBackAid, false)
		self.bounceBackAid = nil
	end
	local vv = superMapUtils:GridIndexConvertToPosition(self.X, self.Y) / 100
	local oldPosition = self.gameObject.transform.position
    local newPosition = Vector3(vv.x, vv.y - cellHeight, oldPosition.z)
    if not IsNil(self.gameObject) then
    	self.gameObject.transform.position = newPosition
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.END_DRAG, {from = "DragEnded-line13", param = self})
    end
    App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
end

-- 弹回
function ElementBehaviour:BounceBack(cb)
	--
	App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
	if self.bounceBackAid then
		AnimateTween.cancel(self.bounceBackAid, true)
		self.bounceBackAid = nil
	end
	local vv = superMapUtils:GridIndexConvertToPosition(self.X, self.Y) / 100
    local oldPosition = self.gameObject.transform.position
    local newPosition = Vector3(vv.x, vv.y - cellHeight, oldPosition.z)
    self.bounceBackAid = AnimateTween.valueTo(self.gameObject, 0, 1, 0.33, function(tm) 
        self.gameObject.transform.position = oldPosition + (newPosition - oldPosition) * tm
		self:UpdateBannerPos(self.gameObject.transform.position)
    end)
    self.bounceBackAid:setEase(LeanTweenType.easeOutQuint)
    AnimateTween.setCallBack(self.bounceBackAid, function() 
    	self.gameObject.transform.position = newPosition
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.END_DRAG, {from = "DragEnded-line12", param = self, pos = newPosition})
		self.bounceBackAid = nil
		if cb then
			cb()
		end
	end)
end

-- 专门给新手教学用
function ElementBehaviour:startBreathSim()
	if not IsNil(self.shadow) then
		self:OperateShadow(true)
		self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		local oldvalue = 0
		local newvalue = 0.75
		if self.shadow_aid_sim then
			AnimateTween.cancel(self.shadow_aid_sim)
			self.shadow_aid_sim = nil
		end
		self.shadow_aid_sim = AnimateTween.valueTo(self.shadow.gameObject, 0, 1, 0.8, function(tm) 
			self.shadowSpriteRenderer.color = Color(self.shadowSpriteRenderer.color.r, self.shadowSpriteRenderer.color.g, self.shadowSpriteRenderer.color.b, oldvalue + (newvalue - oldvalue) * tm)
		end)
		self.shadow_aid_sim:setLoopPingPong()
	end
end

function ElementBehaviour:stopBreathSim()
	if not IsNil(self.shadow) then
		if self.shadow_aid_sim then
			AnimateTween.cancel(self.shadow_aid_sim)
			self.shadow_aid_sim = nil
		end
		--
		self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		local oldvalue = self.shadowSpriteRenderer.color.a
		local newvalue = 0
		AnimateTween.valueTo(self.shadow.gameObject, 0, 1, 0.33, function(tm) 
			self.shadowSpriteRenderer.color = Color(self.shadowSpriteRenderer.color.r, self.shadowSpriteRenderer.color.g, self.shadowSpriteRenderer.color.b, oldvalue + (newvalue - oldvalue) * tm)
		end)
		self:OperateShadow(false)
	end
end

-- 开始地板呼吸闪烁
function ElementBehaviour:startBreath()
	if not self.shadow_aid_sim then
		if not IsNil(self.shadow) then
			self:OperateShadow(true)
			self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			local oldvalue = 0.2
			local newvalue = 0.75
			if self.shadow_aid then
				AnimateTween.cancel(self.shadow_aid)
				self.shadow_aid = nil
			end
			self.shadow_aid = AnimateTween.valueTo(self.shadow.gameObject, 0, 1, 0.8, function(tm) 
				self.shadowSpriteRenderer.color = Color(self.shadowSpriteRenderer.color.r, self.shadowSpriteRenderer.color.g, self.shadowSpriteRenderer.color.b, oldvalue + (newvalue - oldvalue) * tm)
			end)
			if self.shadow_aid then
				self.shadow_aid:setLoopPingPong()
			end
		end
	end
end

function ElementBehaviour:LayerChange(layerName)
	if not IsNil(self.sprite) then
		self.spriteRenderer = self.spriteRenderer or self.sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		if not IsNil(self.spriteRenderer) then
			self.spriteRenderer.sortingLayerName = layerName
		end
	end
	if not IsNil(self.spine) then 
		SpineManager.Layer(self.spine.gameObject, layerName)
	end

	if not IsNil(self.shadow) then
		self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		if not IsNil(self.shadowSpriteRenderer) then
			self.shadowSpriteRenderer.sortingLayerName = layerName
		end
	end
	
	if not IsNil(self.tile) then
		self.tileSpriteSpriteRenderer = self.tileSpriteSpriteRenderer or self.tile:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		if not IsNil(self.tileSpriteSpriteRenderer) then 
			self.tileSpriteSpriteRenderer.sortingLayerName = layerName
		end
	end
end

function ElementBehaviour:SealClick()
	if App:applyFunc(ConstData.FirstPlayTeach, "IsSaling") then 
		return
	end
	if not self.seal and self.data.Sell > 0 then 
		self.seal = "seal"
	else
		self.seal = nil
	end

	self:UpdateSeal()
end

function ElementBehaviour:UpdateSeal()
	if not IsNil(self.signal) then 
		self.signal = self.signal.gameObject
		self.signal.transform.position = self.sprite.transform.position
		self.signal:SetActive(self.seal ~= nil)
	end
end

-- 这个方法是在处于合成中的物品init的时候调用的，主要功能是拒绝点击
function ElementBehaviour:StartSeal()
	if App:applyFunc(ConstData.FirstPlayTeach, "OnSeal") then
		self:StopInteract()
		local no_building = (self.status == StatusConst.WaitingForBuild or self.status == StatusConst.StartForBuild)
		if (self.map.mapData[self.cellId]["Sell"] > 0 and not self.lock and not no_building) then 
	        if not IsNil(self.gameObject) then
	            self.seal = nil
	            self:UpdateSeal()

	            self:LayerUp()
		        if (self.transform.localScale.x < 0.25) then 
		            self:EleScaleChange(self, 1)
		        end
		        if (true) then
		            self:ContinueInteract()
		        end
		       	App:applyFunc(ConstData.FirstPlayTeach, "HeightLightSealStart", self)
	        end
	    end
	end
end

-- 将自己出售
function ElementBehaviour:SealSelf(seal)
	if (seal) then 
		if (self.seal == ConstData.seal) then 
			local position = self.gameObject.transform.position
	        ClientData:GetInstance():upCoin(self.data["Sell"], nil, position, nil, nil)
	        App:applyFunc(ConstData.DCAuxiliaryTool, "RecordDataResource", "get_currency_coin", "Sell", self.data["Sell"])
	        self:DestroyMySelf()
	        App:applyFunc(ConstData.Task,  ConstData.onceTask, "Sell-1")
            App:applyFunc(ConstData.DailyTask,  ConstData.CompleteDailyTask, "Sell", 1)
			App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Element", param = {"Sell-1"}})
		else
			self:UpdateSeal()
		end
	else
		self.seal = nil
		self:UpdateSeal()
	end
end

function ElementBehaviour:Cycler()
	if IsNil(self.gameObject) or IsNil(self.transform) then 
		return
	end

	local limitItemType = {
		"castle", "castlefloor", "mine", "npc"
	}
	local header = self.transform:Find("header")
	App:applyFunc(ConstData.TaskExplore, "ElementArrowBack", header)
	if not table.indexof(limitItemType, self.data.ItemType) then
		local _gameObject_ = self.gameObject
		-- X, Y
		local _X_ = self.X
		local _Y_ = self.Y
		local _map_ = self.map
		-- 先终止所有的动画类
		self:stopBreath()
		self:stopBreathSim()
		self:StopLight()
		self:changeCommon()
		self:dialogCommon()
		self:hideDialog()
		self:StopSpriteLoopPlay()
		self:CommonEffect()
		if self.bounceBackAid then
			AnimateTween.cancel(self.bounceBackAid, true)
		end
		AnimateTween.cancelAllObject(self.gameObject, false)
		-- 清空临时状态
		self.gameObject.transform.localScale = Vector3.one
		-- 工人类状态
		local old_buildSpine = self.gameObject.transform:Find("_buildSpine")
		if not IsNil(old_buildSpine) then
			UGameObject.DestroyImmediate(old_buildSpine.gameObject)
		end
		local highLight = self.transform:Find("highLight")
		if not IsNil(highLight) then
			UGameObject.DestroyImmediate(highLight.gameObject)
		end
		-- 清除组件
		local mainExtDrag = self.gameObject:GetComponent(typeof(ExtDrag))
		if not IsNil(mainExtDrag) then
			UGameObject.DestroyImmediate(mainExtDrag)
			mainExtDrag = nil
		end
		if not IsNil(self.sprite) then
			BehaviourUtil.RemoveBehaviour(self.sprite.gameObject, "SpriteBehaviour")
			self.sprite.gameObject.transform.localPosition = Vector3.zero
		end
		-- 初始化默认对象
		if not IsNil(self.shadow) then
			self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			if self.shadowSpriteRenderer then
				self.shadowSpriteRenderer.sortingLayerName = "Default"
				self.shadowSpriteRenderer.sortingOrder = 2
			end
			self.shadow.gameObject:SetActive(false)
			self.shadow.localScale = Vector3(1.511616, 1.489452, 1)
		end
		if not IsNil(self.sprite) then
			self.sprite.gameObject:SetActive(false)
			self.sprite.localScale = Vector3.one
			if not IsNil(self.spriteRenderer) then
				self.spriteRenderer.sortingOrder = 5
				self.spriteRenderer.sortingLayerName = "Default"
				self.spriteRenderer.enabled = true
			end
		end
		if not IsNil(self.signal) then
			self.signal.gameObject:SetActive(false)
			local signalSpriteRenderer = self.signal:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			if not IsNil(signalSpriteRenderer) then
				signalSpriteRenderer.sortingOrder = 5
				-- signalSpriteRenderer.sortingLayerName = "Default"
			end
		end
		if not IsNil(self.tile) then
			self:showTiledSprite("MovabledBottom")
			local tile_color = self.tile:GetComponent(ConstData.SpriteRenderer)
			tile_color.color = Color(tile_color.color.r, tile_color.color.g, tile_color.color.b, 0)
			tile_color.sortingOrder = 4
			tile_color.sortingLayerName = "Default"
			self.tile.gameObject:SetActive(false)
			self.tile.transform.localPosition = Vector3.zero
		end
		if not IsNil(self.dialog) then
			self.dialog.localScale = Vector3.one
			self.dialog.gameObject:SetActive(false)
		end
		-- 检查 EffMoveTail3
		local EffMoveTail3 = self.transform:Find("EffMoveTail3")
		if not IsNil(EffMoveTail3) and not IsNull(EffMoveTail3.gameObject) then
			GameObjectPool:GetInstance():PutObjectBackToPool(ResCfg.AlwaysExistCachePrefabs.EffMoveTail3, EffMoveTail3.gameObject)
		end

		-- role 跳过
		if not IsNil(self.mation) then
			self.mation:GetComponent("SpriteRenderer").color = Color(1, 1, 1, 0)
			self.mation:GetComponent("SpriteRenderer").sortingOrder = 6
			self.mation:GetComponent("SpriteRenderer").sortingLayerName = "Default"
			self.mation.gameObject:SetActive(false)
		end
		-- clearBar 跳过
		if not IsNil(self.clearBar) then
			self.clearBar.gameObject:SetActive(false)
		end
		-- timer
		if not IsNil(self.timer) then
			self.timer.gameObject:SetActive(false)
			self.timer = nil 
		end
		-- hourglass
		if not IsNil(self.hourglass) then
			self.hourglass:GetComponent("SpriteRenderer").color = Color(1, 1, 1, 0)
			self.hourglass.gameObject:SetActive(false)
		end
		-- spine/spine_behide
		if not IsNil(self.spine_behide) then
			self.spine_behide.gameObject:SetActive(false)
		end
		if not IsNil(self.spine) then
			self.spine.gameObject:SetActive(false)
		end
		if not IsNil(self.header) then
			for i = 1, self.header.transform.childCount do
				local child = self.header.transform:GetChild(0)
				if not IsNil(child) then
					UGameObject.DestroyImmediate(child.gameObject)
				end
			end
			self.header.gameObject:SetActive(true)
		end
		-- 子对象初始化
		if not IsNil(self.timerFreeBtn) then
			local boxCollider2D = self.timerFreeBtn:GetComponent("BoxCollider2D")
			if boxCollider2D then
				boxCollider2D.enabled = false
				if boxCollider2D.size.x == 0.68 then
					boxCollider2D.size = Vector2(1.04, 0.96)
				end
			end
		end
		if not IsNil(self.diamondQuickBtn) then
			local boxCollider2D = self.diamondQuickBtn:GetComponent("BoxCollider2D")
			if boxCollider2D then
				boxCollider2D.enabled = false
			end
		end
		-- 需要单独显示的判断下
		if not IsNil(self.dialogParent) then
			self.dialogParent.gameObject:SetActive(true)
		end
		self:hideCleanTimer()
		self:hideDiamondQuickButton()
		if not IsNil(self.time) then
			local Btn = self.time:Find("Btn")
			if not IsNil(Btn) then
				local behaviour = Btn.gameObject:GetComponent(typeof(LuaBehaviourV2))
				if behaviour then
					UGameObject.DestroyImmediate(behaviour)
				end
				-- ExtDrag
				local extDrag = Btn.gameObject:GetComponent(typeof(ExtDrag))
				if extDrag then
					UGameObject.DestroyImmediate(extDrag)
				end
			end
		end
		-- 缓存 _X_ ,_Y_ 的 currentMatrix 为空
		local o = self.map.currentMatrix[_X_ + 1 + _Y_ * self.map.cellXCount]
		if not IsNil(o) and type(o) == "table" and not IsNil(o.gameObject) and o.gameObject.name == _gameObject_.name then
			_map_.currentMatrix[_X_ + 1 + _Y_ * _map_.cellXCount] = ""
			_map_.emptyMatrix[_X_ + 1 + _Y_ * _map_.cellXCount] = true
		end
		-- 删除Bubble
		if self.data.ItemType == "bubble" then
			local bubble = self.gameObject.transform:Find("bubble")
			if not IsNil(bubble) then
				UGameObject.DestroyImmediate(bubble.gameObject)
			end
		end
		self.gameObject.name = "Element_cycle"
		-- 回收
		local path = ResCfg:getPathPrefabs(ResCfg.Prefabs.Element)
		GameObjectPool:GetInstance():PutObjectBackToPool(path, self.gameObject, true)
	else
		AnimateTween.cancelAllObject(self.gameObject, false)
		self:stopBreath()
		self:StopLight()
		self:changeCommon()
		self:dialogCommon()
		self:hideDialog()
		self.timer = nil 
		-- 工人类状态
		local old_buildSpine = self.gameObject.transform:Find("_buildSpine")
		if not IsNil(old_buildSpine) then
			UGameObject.DestroyImmediate(old_buildSpine.gameObject)
		end
		UGameObject.DestroyImmediate(self.gameObject)
	end
end

-- 点击组件 nearTrigger 表示是否由范围内的其他物品触发
function ElementBehaviour:CompsClick(nearTrigger, fromBanner)
	if SceneManager:GetInstance().busing then -- 转场时，不允许点击
		return
	end
	if self.longPressState then               -- 长按行为,不允许执行
		self.longPressState = false
		return
	end
	if self.data.ItemType == "currency" and not fromBanner then 
		self.map.popupOpening = App:applyFunc(ConstData.Popup, "judgeByStatus", self)
		return
	end
	local behaviour = self.comps[tostring(self.data.Behaviour)] or {}
    if behaviour and behaviour.Click then
        if self.data[ConstData.Params02] and self.data[ConstData.Params02] ~= "" then
            App:applyFunc(ConstData.Sound,  "playSound", self.data[ConstData.Params02])
        end
        behaviour:Click(self.data, nearTrigger)
    end
end

-- 提升层级
function ElementBehaviour:LayerUp()
	self:LayerChange(UP_LAYER_ID)
end

function ElementBehaviour:LayerDown()
	self:LayerChange(ORIGIN_LAYER)
end

function ElementBehaviour:SetFoodGenerated()
	self.foodGenerated = true
	self:delayedCall(0.5, function()
		self.foodGenerated = false
	end)
end

-- 停止地板呼吸闪烁
function ElementBehaviour:stopBreath()
	-- 
	if not self.shadow_aid_sim then
		if not IsNil(self.shadow) then
			if self.shadow_aid then
				AnimateTween.cancel(self.shadow_aid)
				self.shadow_aid = nil
			end
			--
			self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			local oldvalue = self.shadowSpriteRenderer.color.a
			local newvalue = 0
			AnimateTween.valueTo(self.shadow.gameObject, 0, 1, 0.33, function(tm) 
				self.shadowSpriteRenderer.color = Color(self.shadowSpriteRenderer.color.r, self.shadowSpriteRenderer.color.g, self.shadowSpriteRenderer.color.b, oldvalue + (newvalue - oldvalue) * tm)
			end)
			self:OperateShadow(true)
		end
	end
end

function ElementBehaviour:changeRed()
	self:OperateShadow(true)
	if not IsNil(self.shadow) then
		self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		self.shadowSpriteRenderer.color = Color(0.9, 0.1, 0.1, self.shadowSpriteRenderer.color.a)
	end
	-- 本身也变红
	if self.sprite and self.data.ItemType ~= ConstData.STR_CASTLE then
		self.spriteRenderer.color = Color(219 / 255.0, 90 / 255.0, 53 / 255.0, 1)
		ShaderController.hueValue(self.sprite.gameObject, -0.233)
	end
	-- 如果类别是floor
	if (self.data) then
		if self.data.ItemType == "castlefloor" then
			if not IsNil(self.foundation) then
				local childCount = self.foundation.transform.childCount
				for i = 1, childCount do
					local foundation_item = self.foundation.transform:GetChild(i - 1)
					if foundation_item then
						foundation_item:GetComponent(ConstData.SpriteRenderer).color = Color(1, 0, 0, 0.6)
					end
				end
			end
		end
	end
	if not IsNil(self.spine) then
		SpineManager.Color(self.spine.gameObject, Color(0.9, 0.1, 0.1))
	end
end

function ElementBehaviour:changeCommon(is_deal)
	if not IsNil(self.shadow) then
		self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
		self.shadowSpriteRenderer.color = Color(self.shadow_color.r, self.shadow_color.g, self.shadow_color.b, self.shadowSpriteRenderer.color.a)
		if not is_deal then
			self:OperateShadow(false)
		end
	end

	-- 本身也变红
	if not IsNil(self.sprite) and self.data.ItemType ~= ConstData.STR_CASTLE then
		if self.data.ItemType == "building" and self.status == StatusConst.WaitingForBuild then
			self.spriteRenderer.color = Color(1, 1, 1, 204 / 255)
		else
			self.spriteRenderer.color = Color(1, 1, 1, 1)
		end
		ShaderController.hueValue(self.sprite.gameObject, 0)
	end

	if self.data and self.data.ItemType == "castlefloor" then
		if not IsNil(self.foundation) then
			local childCount = self.foundation.transform.childCount
			for i = 1, childCount do
				local foundation_item = self.foundation.transform:GetChild(i - 1)
				if foundation_item then
					foundation_item:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
				end
			end
		end
	end
	if not IsNil(self.spine) then
		SpineManager.Color(self.spine.gameObject, Color(1, 1, 1))
	end
end

function ElementBehaviour:HighLight()
	-- 
	if self.HighLighting then
		return false
	end
	if self.light_aid then
		AnimateTween.cancel(self.light_aid)
		self.light_aid = nil
	end
	self.HighLighting = true
	local oldvalue = 1.1
	local newvalue = 1.4
	local mat = self.spriteRenderer.material
	self.light_aid = AnimateTween.valueTo(self.sprite.gameObject, 0, 1, 0.5, function(tm) 
		ShaderController.lightingValue(self.sprite.gameObject, oldvalue + (newvalue - oldvalue) * tm, mat)
	end)
	if self.light_aid then
		self.light_aid:setLoopPingPong()
	else
		return false
	end
	return true
end

function ElementBehaviour:ShowCropBar()
	if (not self.data.ItemType == "crop") then 
		return false
	end
	local count = 1
	if not IsNil(self.clearBar) then
		self:showClearBar(count)
		return true
	end
	return false
end

function ElementBehaviour:HideCropBar()
	if (not self.data.ItemType == "crop") then 
		return false
	end
	if not IsNil(self.clearBar) then
		if FakeCorouteInst then
	        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
	        	AnimateTween.cancelAllObject(self.clearBar.gameObject, false)
				self.clearBar:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
				-- bar
				local bar = self.clearBar:Find("bar")
				if bar then
					-- Loop
					local oldAlpha = 1
					local newAlpha = 0.8
					local bar_spriterender = bar:GetComponent(ConstData.SpriteRenderer)
					bar_spriterender.color = Color(1, 1, 1, 0)
				end
				self.clearBar.gameObject:SetActive(false)
	    	end)
	    end
	end
end

-- Bar
function ElementBehaviour:ShowBar(jump_status)
	local count = 0
	if self.data.ItemType == "obstacle" or self.data.ItemType == "res" then
		if self.data.DigCount <= 0 then
			return false
		else
			count = tonumber(self.data.DigCount)
		end
	elseif self.data.ItemType == "crop" then
		if self.data.RipeCount <= 0 then
			return false
		else
			count = tonumber(self.data.DigCount)
		end
	end
	
	-- 显示clearBar，控制透明度
	if not IsNil(self.clearBar) then
		if not jump_status then
			self.current_showing_bar = 1
		end
		self:showClearBar(count)
		return true
	end
	return false
end

function ElementBehaviour:showClearBar(count)
	if IsNil(self.clearBar) then
		return
	end
	self.clearBar.gameObject:SetActive(true)
	self.clearBar:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
	-- bar
	-- 根据当前的情况进行配置
	self.currentRootIndex = self.currentRootIndex or 1		-- 表示第几次清理
	local totalRootCount = count							-- 总共需要清理的次数
	local realDigCount = totalRootCount - self.currentRootIndex + 1 -- 实际还需清理几次
	self.progressBar = self.progressBar or self.transform:Find("clearBar/progress_bar")
  	self.progressMaskBar = self.progressMaskBar or self.transform:Find("clearBar/progress_mask_bar")
  	self.progressMaskSliceBar = self.progressMaskSliceBar or self.transform:Find("clearBar/progress_mask_slice_bar")
  	local oldAlpha = 0.8
	local newAlpha = 0.3
  	self.progressBarSpRen = self.progressBarSpRen or self.progressBar.gameObject:GetComponent(ConstData.SpriteRenderer)
  	self.progressMaskBarSpRen = self.progressMaskBarSpRen or self.progressMaskBar.gameObject:GetComponent(ConstData.SpriteRenderer)
  	self.progressMaskSliceBarSpRen = self.progressMaskSliceBarSpRen or self.progressMaskSliceBar.gameObject:GetComponent(ConstData.SpriteRenderer)
  	if not IsNil(self.progressBar) and not IsNil(self.progressMaskBar) and not IsNil(self.progressMaskSliceBar) then
  		self.progressBar.gameObject:SetActive(realDigCount > 1)
  		self.progressMaskBar.gameObject:SetActive(realDigCount == totalRootCount)
  		self.progressMaskSliceBar.gameObject:SetActive(realDigCount ~= totalRootCount)
  		local bar_side_scale_x = self.progressBar.transform.localScale.x
  		local all_length = 1.11
  		local percent = all_length / totalRootCount		-- 每一份的长度
  		if realDigCount == totalRootCount then
  			local size_x = percent * (realDigCount -1)
  			self.progressBarSpRen.size = Vector2(size_x, 0.195)
  			self.BarAnimateId = AnimateTween.valueTo(self.progressMaskBar.gameObject, 0, 1, 0.4, function(tm) 
				self.progressMaskBarSpRen.color = Color(1, 1, 1, oldAlpha + (newAlpha - oldAlpha) * tm)
			end)
  		else
  			self.progressBarSpRen.size = Vector2(percent * (realDigCount - 1) , 0.195)
  			self.progressMaskSliceBarSpRen.size = Vector2(percent * realDigCount, 0.195)
  			self.progressMaskSliceBarSpRen.sortingOrder = 2 + self.X + 1 + self.Y * self.map.cellXCount
  			self.BarAnimateId = AnimateTween.valueTo(self.progressMaskSliceBarSpRen.gameObject, 0, 1, 0.4, function(tm) 
				self.progressMaskSliceBarSpRen.color = Color(1, 1, 1, oldAlpha + (newAlpha - oldAlpha) * tm)
			end)
  		end
  		if not IsNil(self.BarAnimateId) then
		 	self.BarAnimateId:setLoopPingPong()
  		end
  	end
end

function ElementBehaviour:showTimeelfClearBar(unusedTime)
	if not self.data.ItemType == "timeelf" or IsNil(self.clearBar) then
		return
	end
	self.clearBar.gameObject:SetActive(true)
	self.progressBar = self.progressBar or self.transform:Find("clearBar/progress_bar")
  	self.progressMaskBar = self.progressMaskBar or self.transform:Find("clearBar/progress_mask_bar")
  	self.progressMaskSliceBar = self.progressMaskSliceBar or self.transform:Find("clearBar/progress_mask_slice_bar")
  	self.progressBarSpRen = self.progressBarSpRen or self.progressBar.gameObject:GetComponent(ConstData.SpriteRenderer)
  	self.progressMaskSliceBar.gameObject:SetActive(false)
  	self.progressMaskBar.gameObject:SetActive(false)
  	self.progressBar.gameObject:SetActive(true)
  	if unusedTime then
  		self.unusedTime = unusedTime
  	end
	self.progressBarSpRen.size = Vector2(self.unusedTime / (GlobalData.QuickWorker * 1.0) * 1.11, 0.195)
end

function ElementBehaviour:HideBar(jump_status)
	if self.data.DigCount <= 0 then
		return false
	end
	if self.BarAnimateId then
		AnimateTween.cancel(self.BarAnimateId)
		self.BarAnimateId = nil
	end
	if not IsNil(self.clearBar) then
		if not jump_status then
			self.current_showing_bar = 0
		end
		if FakeCorouteInst then
	        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
	        	AnimateTween.cancelAllObject(self.clearBar.gameObject, false)
				self.clearBar:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
				-- bar
				local bar = self.clearBar:Find("bar")
				if bar then
					-- Loop
					local oldAlpha = 1
					local newAlpha = 0.8
					local bar_spriterender = bar:GetComponent(ConstData.SpriteRenderer)
					bar_spriterender.color = Color(1, 1, 1, 0)
				end
				self.clearBar.gameObject:SetActive(false)
	    	end)
	    end
	end
end

function ElementBehaviour:StopLight()
	-- 
	if not self.HighLighting then
		return
	end
	
	if self.light_aid then
		AnimateTween.cancel(self.light_aid)
		self.light_aid = nil
	end
	self.HighLighting = false
	local mat = self.sprite:GetComponent("SpriteRenderer").material
	ShaderController.lightingValue(self.sprite.gameObject, 1, mat)
end

-- 
function ElementBehaviour:BuildingEffect()
	if not IsNil(self.sprite) then
		ShaderController.alphaValue(self.sprite.gameObject, 0.8)
		ShaderController.saturationValue(self.sprite.gameObject, 0.4)
		ShaderController.lightingValue(self.sprite.gameObject, 0.8)
	end
end

function ElementBehaviour:CommonEffect()
	if not IsNil(self.sprite) then
		ShaderController.alphaValue(self.sprite.gameObject, 1.0)
		ShaderController.saturationValue(self.sprite.gameObject, 1.0)
		ShaderController.lightingValue(self.sprite.gameObject, 1.0)
	end
end


function ElementBehaviour:shake()
	-- 通过Animation的方式 
	-- 骨骼动画
	if not IsNil(self.spine) then
		self.spine_animation = self.spine_animation or self.spine.gameObject:GetComponent("Animation")
	end
	if self.spine_animation then
		self.spine_animation:Play()
	end
	self.sprite_animation = self.sprite_animation or self.sprite.gameObject:GetComponent("Animation")
	if self.sprite_animation then
		self.sprite_animation:Play()
	end

	if (self.data["ItemType"] == "obstacle" or self.data["ItemType"] == "res") then 
		self:OperateTile(true)
		local aid1 = AnimateTween.valueTo(self.tile.gameObject, 1, 1.1, 0.15, function(tm)
			self.tile.localScale = Vector3.one * tm
		end)
		
		AnimateTween.setCallBack(aid1, function()
			AnimateTween.valueTo(self.tile.gameObject, 1.1, 1, 0.15, function(tm)
				self.tile.transform.localScale = Vector3.one * tm
			end)
		end)
	end
end

-- 加锁
function ElementBehaviour:locked()
	if self.sprite then
		superMapUtils:SetMaterial(self.sprite.gameObject, "_Saturation", 0.1)
	end
	if self.data.ItemType == "bubble" then
		local bubble = self.gameObject.transform:Find("bubble")
		if not IsNil(bubble) then
			superMapUtils:SetMaterial(bubble.gameObject, "_Saturation", 0.1)
		end
	end
	-- 城堡类型
	if self.data.ItemType == "castlefloor" then
		if not IsNil(self.sprite3) then
			self.sprite3.gameObject:GetComponent("SpriteRenderer").color = Color(1, 1, 1, 0.50196)
			superMapUtils:SetMaterial(self.sprite3.gameObject, "_Saturation", 0.1)
		end
		if not IsNil(self.hint) then
			self.hint.gameObject:SetActive(false)
		end
	end
	-- 需要变更底板的颜色
	if self.tile then
		self.unlock_tile_color = self.tile:GetComponent(ConstData.SpriteRenderer).color
		if self.data.ItemType == "res" or self.data.ItemType == "obstacle" then
			self.tile:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
			self:OperateTile(true)
		else
			self.unlock_tile_color = nil
			self:OperateTile(false)
		end
		superMapUtils:SetMaterial(self.tile.gameObject, "_Saturation", 0.1)
	end
	-- 骨骼动画锁死
	if self.cellId ~= "Vine_01" then
		if not IsNil(self.spine) and self.spine.gameObject.activeSelf then
			if (self.cellId == "Timeelf05") and not IsNil(self.highLight) then 
				self.highLight.gameObject:SetActive(false)
				self.spine.transform.localScale = Vector3.zero
				-- self.spriteRenderer.enabled = true
				self:HideSpine()
				self:showSpriteRenderer()
			else
				SpineManager.Color(self.spine.gameObject, Color(0.5, 0.5, 0.5))
			end
		end
	end
	if self.cellId == "Timeelf05" or self.data.ItemType == "wishingwell" or self.data.ItemType == "treehole" then
		-- self.spriteRenderer.enabled = true
		if self.spine then
			self.spine.gameObject.transform.localScale = Vector3.zero
		end
		self:HideSpine()
		self:showSpriteRenderer()
	end

    if not IsNil(self.spine_behide) then 
        self.spine_behide.transform.localScale = Vector3.zero
    end
    if not IsNil(self.zuowu) then 
        self.zuowu.transform.gameObject:SetActive(false)
    end
	if self.data.ItemType == "food" then -- gaoqiwen
		self:StopSpriteLoopPlay()
	end
	self:CloseDialog()
	self:HideExclamationPoint()
	-- 是否处于可用状态 加锁状态
	self.lock = true
end

function ElementBehaviour:spriteGradient(sprite)
	local tmp_sprite = AGameObject.Instantiate(sprite, sprite.transform.parent)
	superMapUtils:SetMaterial(tmp_sprite, "_Saturation", 0.1)
	tmp_sprite:GetComponent(ConstData.SpriteRenderer).sortingOrder = sprite:GetComponent(ConstData.SpriteRenderer).sortingOrder + 1
	local color = tmp_sprite:GetComponent(ConstData.SpriteRenderer).color
	tmp_sprite:GetComponent(ConstData.SpriteRenderer).color = Color(color.r, color.g, color.b, 1)
	local aid = AnimateTween.valueTo(tmp_sprite, 0, 1, GRADIENT_TIME, function(tm)
		tmp_sprite:GetComponent(ConstData.SpriteRenderer).color = Color(color.r, color.g, color.b, 1 - tm)
	end)
	AnimateTween.setCallBack(aid, function()
		UGameObject.DestroyImmediate(tmp_sprite)
	end)
end

-- 处理sprite的渐变
function ElementBehaviour:elementGradient()
	local tile_color = self.tile:GetComponent(ConstData.SpriteRenderer).color
	if not IsNil(self.tile) and tile_color.a ~= 0 then
		self:spriteGradient(self.tile.gameObject)
	end
	if (self.sprite) then -- 对sprite进行拷贝
		self:spriteGradient(self.sprite.gameObject)
	end
	-- 对Spine进行拷贝
	if not IsNil(self.spine) and self.spine.gameObject.activeSelf then
		local tmp_spine = AGameObject.Instantiate(self.spine.gameObject, self.spine.transform.parent)
		local idx = SpineManager.getOrder(self.spine.gameObject) + 1
		SpineManager.Order(tmp_spine.gameObject, idx)
		local aid = AnimateTween.valueTo(tmp_spine, 0, 1, GRADIENT_TIME, function(tm)
			SpineManager.Alpha(tmp_spine, tm)
		end)
		AnimateTween.setCallBack(aid, function()
			UGameObject.DestroyImmediate(tmp_spine)
		end)
	end
end

function ElementBehaviour:addBubble()
	-- 判断是否是锁区
	local index = self.X + 1 + self.Y * self.map.cellXCount
	if self.map.currentLockArea[index] then
		return
	end
	if self.map.currentLockMatrixCloud[index] and self.map.currentLockMatrixCloud[index] ~= "" then
		return
	end
	if self.data.ItemType == "bubble" then
    	-- 飞入
    	-- 获取ID存储
    	-- 每个关卡的
    	flyDelayTime = flyDelayTime or 0
    	AnimateTween.delayCall(flyDelayTime * 0.1, function()
    		self:FlyToGiftBox()
    	end)
  	else
  		-- 修正sortingOrder
    	self:setNeedSortingOrder(true)
    end
end

-- 解锁
function ElementBehaviour:unlock(gradient, flyDelayTime)
	-- 是否处于可用状态 加锁状态
	self.lock = false
	self:CloseTransparentDeal()
	local force = self.status == StatusConst.WaitingForReap
	App:applyFunc(ConstData.DCAuxiliaryTool, "AddElement", self.cellId, self)
	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ADD_ELEMENT, {from = "unlock", params = {cellId = self.cellId, ele = self}})
	if not gradient then
		-- show
		-- App:applyFunc(ConstData.Task,  "showObject", self.cellId)
		-- App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.SHOW_OBJECT, {from = "ElementBehaviour - unlock", cellId = self.cellId})
		App:applyFunc(ConstData.Trigger, "trigger", TriggerCfg.Type.ShowObject, {from = "ElementBehaviour - unlock", cellId = self.cellId})
	end
	if self.data.ItemType == "castlefloor" then
		self:DealCastlefloor()
	else
		if gradient then 
			self:elementGradient()
		end
		if self.sprite then
			superMapUtils:SetMaterial(self.sprite.gameObject, "_Saturation", 1.0)
			if self.spriteRenderer then
				self.spriteRenderer.color = Color.white
			end
		end
		
	end
	if self.data.ItemType == "bubble" then
		local bubble = self.gameObject.transform:Find("bubble")
		if not IsNil(bubble) then
			superMapUtils:SetMaterial(bubble.gameObject, "_Saturation", 1.0)
		end
	end
	
	-- 需要变更底板的颜色
	if not IsNil(self.tile) then
		if self.unlock_tile_color then
			self.tile:GetComponent(ConstData.SpriteRenderer).color = self.unlock_tile_color
		end
		superMapUtils:SetMaterial(self.tile.gameObject, "_Saturation", 1.0)
	end

	if self.oldStatus then
		self.status = self.oldStatus
		if self.status == StatusConst.Locked then
			local data = self.data
			if data.RipeCount > 0 then
		    	self.status = StatusConst.WaitingForReap
		    elseif data.ItemType == "res" and data.DigCount > 0 then
		        self.status = StatusConst.WaitingForResHag
		    elseif data.ItemType == "obstacle" and data.DigCount > 0 then
		    	self.status = StatusConst.WaitingForObstacleHag
		    elseif data.ItemType == "supreme" then
		    	self.status = StatusConst.MaxGem
		    elseif data.ItemType == "timeelf" and self.cellId == "Timeelf05" then
	    		self.status = StatusConst.QuickWorker
	    		self.unusedTime = GlobalData.QuickWorker
		    elseif data.ItemType == "mine" then
		    	self.status = StatusConst.UnBuild
		    elseif data.ItemType == "castle" then
		    	self.status = StatusConst.WaitingForCollectObject
		    else
		    	self.status = StatusConst.Common
		    end
		end
		if self.status == StatusConst.Common then
            if self.data.ItemType == "castle" then
                self.status = StatusConst.WaitingForCollectObject
            end
        end
	else
		-- 建筑是否需要等待市场，且消耗工人
		local data = self.data
		if data.RipeCount > 0 then
	    	self.status = StatusConst.WaitingForReap
	    elseif data.ItemType == "res" and data.DigCount > 0 then
	        self.status = StatusConst.WaitingForResHag
	    elseif data.ItemType == "obstacle" and data.DigCount > 0 then
	    	self.status = StatusConst.WaitingForObstacleHag
	    elseif data.ItemType == "supreme" then
	    	self.status = StatusConst.MaxGem
	    elseif data.ItemType == "timeelf" and self.cellId == "Timeelf05" then
    		self.status = StatusConst.QuickWorker
    		self.unusedTime = GlobalData.QuickWorker
	    elseif data.ItemType == "mine" then
	    	self.status = StatusConst.UnBuild
	    elseif data.ItemType == "castle" then
	    	self.status = StatusConst.WaitingForCollectObject
	    else
	    	self.status = StatusConst.Common
	    end
	end
	if self.status == StatusConst.Common then
        if self.data.ItemType == "castle" then
            self.status = StatusConst.WaitingForCollectObject
        end
    end
	App:applyFunc(ConstData.Status, "refreshStatus", self)
	if self.data.ItemType ~= "special" and self.data.ItemType ~= "monster" then
		-- 增加一帧
		if FakeCorouteInst then
	        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
	        	self:addInteract()
	    	end)
	    end
	end
	if App:applyFunc(ConstData.Element, "CheckSpineOnly", self.cellId) then 
		self.spine.gameObject.transform.localScale = Vector3.one
		-- SpineManager.Speed(self.spine.gameObject, 1)
		self:hideSpriteRenderer()
		self:ShowSpine()
		SpineManager.Color(self.spine.gameObject, Color.white)
	else
		-- SpineManager.Speed(self.spine.gameObject, 1)
		self:ShowSpine()
		SpineManager.Color(self.spine.gameObject,  Color.white)
	end
	if self.cellId == "Timeelf05" or self.data.ItemType == "wishingwell" or self.data.ItemType == "treehole" then 
		local highLight = self.transform:Find("highLight")
		if highLight then
			highLight.gameObject:SetActive(true)
		end
	end
	-- if self.spine and self.spine.gameObject.activeSelf then
	-- 	self.spine.gameObject.transform.localScale = Vector3.one
	-- 	if self.cellId == "Timeelf05" or self.data.ItemType == "wishingwell" or self.data.ItemType == "treehole" then 
	-- 		local highLight = self.transform:Find("highLight")
	-- 		if highLight then
	-- 			highLight.gameObject:SetActive(true)
	-- 		end
	-- 		-- self.spine.transform.localScale = Vector3.one
	-- 		SpineManager.Color(self.spine.gameObject, Color(1, 1, 1))
	-- 		SpineManager.Speed(self.spine.gameObject, 1)
	-- 		-- self.spriteRenderer.enabled = false
	-- 		self:hideSpriteRenderer()
	-- 		self:ShowSpine()
	-- 		self.spriteRenderer.color = Color(255 / 255, 255 / 255, 255 / 255)
	-- 	else
	-- 		self:ShowSpine()
	-- 		SpineManager.Color(self.spine.gameObject, Color(1, 1, 1))
	-- 		SpineManager.Speed(self.spine.gameObject, 1)
	-- 	end
	-- end
	-- 实用Illustrated 根据当前的关卡情况来计算
    local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    if not gradient then
		if lvType == ConstData.STR_MASTER then
	    	if self.status ~= StatusConst.WaitingForBuild and
	    		self.status ~= StatusConst.StartForBuild and
	    		self.status ~= StatusConst.WaitingTimeForBuild then
	        	App:applyFunc(ConstData.Illustrated, "Illustrated", self.cellId, self.transform.position)
	        end
	        -- 所有内容
	        App:applyFunc(ConstData.Illustrated, "AllIllustrated", self.cellId)
	    elseif lvType == ConstData.STORY_LEVEL or lvType == ConstData.ACTIVITY_LEVEL then
	    	if self.status ~= StatusConst.WaitingForBuild and
	    		self.status ~= StatusConst.StartForBuild and
	    		self.status ~= StatusConst.WaitingTimeForBuild then
	        	App:applyFunc(ConstData.StoryAtlasLvData, "UnLockElement", self.cellId)
	        end
	    end
	end
	--
	if lvType == ConstData.STORY_LEVEL then
        App:applyFunc(ConstData.Cloud, "levelCloudCheck", tostring(self.cellId))
    elseif lvType == ConstData.ACTIVITY_LEVEL then -- 刚解锁
		if self.map then
			local index = self.X + 1 + self.Y * self.map.cellXCount
			if not self.map.currentLockArea[index] then -- 如果还在锁区里，那还是不可以解锁云的
    			App:applyFunc(ConstData.Cloud, "levelCloudCheck", tostring(self.cellId))
			end
		end
    end

    if not IsNil(self.spine_behide) then 
        self.spine_behide.transform.localScale = Vector3.one
    end

    if not IsNil(self.spine_clone) then 
    	UGameObject.Destroy(self.spine_clone)
    	self.spine_clone = nil
    end

    -- 多余的spine(Clone)处理
    for i = 1, 10 do
    	local spine_clone = self.transform:Find("spine(Clone)")
    	if spine_clone and spine_clone.gameObject then
    		UGameObject.DestroyImmediate(spine_clone.gameObject)
    	end
    end

    if not IsNil(self.zuowu) then 
        self.zuowu.transform.gameObject:SetActive(true)
    end
    
	if self.data.ItemType == "food" then -- gaoqiwen
		self:SpriteLoopPlay()
	end

    self:ShowDialog()
    self:showDialog(nil, force)
    self.lock = false

    -- 判断是否是bubble
    if self.data.ItemType == "bubble" then
    	if not gradient then
	    	-- 飞入
	    	-- 获取ID存储
	    	-- 每个关卡的
	    	flyDelayTime = flyDelayTime or 0
	    	AnimateTween.delayCall(flyDelayTime * 0.1, function()
	    		self:FlyToGiftBox()
	    	end)
	    end
  	else
  		-- 修正sortingOrder
    	self:setNeedSortingOrder(true)
    end
    if table.indexof(StoryMarkData, self.data.ItemType) then
		-- 增加Popup
		self.addPopup = true
		MapUpdate:addPopupItem(self)
		self.popup_during = 0.2
		--
		self.needItem = true
		MapUpdate:addNeedItem(self)
    	self.needItemTime = 0.01
	end

	if lvType == ConstData.STORY_LEVEL then
		local tp = {"treehole", "wishingwell"}
		if table.indexof(tp, self.data.ItemType) then
			-- 判断是否在云朵下或者锁区中
			local index = self.X + 1 + self.Y * self.map.cellXCount
			local is_clouded = false
			local is_locked = false
			if self.map.currentLockMatrixCloud[index] and self.map.currentLockMatrixCloud[index] ~= "" then
				is_clouded = true
			end
			if self.map.currentLockArea[index] and self.map.currentLockArea[index] ~= "" then
				is_locked = true
			end
			if not is_locked and not is_clouded then
				-- 加入到列表中
				App:applyFunc(ConstData.Element, "accommodationStatusIn", self)
			else
				-- 剧情关卡许愿池层级有问题
				self.addPopup = false
				self.popup_during = 0
				self.needItem = false
				self.needItemTime = 0
				MapUpdate:removePopupItem(self)
				MapUpdate:removeNeedItem(self)
			end
		end
	end

	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.UNLOCK_FINISH, {from = "unlock-1189", params = {cellId = self.cellId, ele = self}})
end

function ElementBehaviour:FlyToGiftBox()
	if self.flyToGifted then
		return
	end
	self.flyToGifted = true
	local count = 0
	App:applyFunc(ConstData.Sound, "playSound", "getBubble")
	App:applyFunc(ConstData.MapCore, ConstData.addSortingOrder, self, nil, true)
	-- 存储
	local mapArr = string.split(self.map.levelMap, "/")
	local mapPath = string.split(mapArr[#mapArr], "%.")[1]
    local BackPackJson = CustomPlayerPrefs.GetString(CURRENT_USER .. "_" .. mapPath .. "BackPack", "")
    if BackPackJson ~= "" then
        self.backPack = JsonHelper.decode(BackPackJson)
    end
    self.backPack = self.backPack or {}
   	-- 替换Bubble
   	if not App:applyFunc(ConstData.StoryCastle, "InStoryLevelCheckPassed") then
   		if not LOCKED_SCREEN then
		   	local pack_cell_id = string.gsub(self.cellId, "Bubble", "")
		    self.backPack[pack_cell_id] = self.backPack[pack_cell_id] or 0
		    self.backPack[pack_cell_id] = self.backPack[pack_cell_id] + 1
		    -- Json存储
	    	BackPackJson = JsonHelper.encode(self.backPack)
	   		CustomPlayerPrefs.SetString(CURRENT_USER .. "_" .. mapPath .. "BackPack", BackPackJson)
	   	end
	end
	UserData:GetInstance():flyToUI("GiftBoxButton", "Image", self.gameObject, self.transform.position, function() 
		self:DestroyMySelf()
		--
		if LOCKED_SCREEN then
			-- 
			LOCKED_SCREEN = nil
			UI_TOUCH = nil
            GlobalDataMgr:SetBIDMove(false)
			UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIStoryLevelAward, {"expend"}, self.backPack)
		end
	end)
end

-- 处理城堡状态
function ElementBehaviour:DealCastlefloor()
	if self.data.ItemType == "castlefloor" then
		if not IsNil(self.sprite) then
			superMapUtils:SetMaterial(self.sprite.gameObject, "_Saturation", 0.4)
			superMapUtils:SetMaterial(self.sprite.gameObject, "_Brightness", 0.8)
			self.spriteRenderer.color = Color(1, 1, 1, 0.50196)
		end

		if not IsNil(self.sprite3) then
			self.sprite3.gameObject:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0.50196)
			if not IsNil(self.hint) then
				self.hint.gameObject:SetActive(true)
				self.hint.gameObject:GetComponent(ConstData.SpriteRenderer).sortingOrder = self.sprite3.gameObject:GetComponent(ConstData.SpriteRenderer).sortingOrder + 1
			end
			superMapUtils:SetMaterial(self.sprite3.gameObject, "_Saturation", 0.4)
			superMapUtils:SetMaterial(self.sprite3.gameObject, "_Brightness", 0.8)
		end
	end
end

-- 显示hourglass
function ElementBehaviour:showHourglass(alpha)
	alpha = alpha or 1
	if not IsNil(self.hourglass) then
		self:OperateHourglass(true)
		self.hourglass:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, alpha)
		if self.data.ItemType == ConstData.STR_CASTLE or self.data.ItemType == "mine" then
			-- 层级提高200
			if not self.castle_hour_glass_order then
				self.castle_hour_glass_order = self.hourglass:GetComponent(ConstData.SpriteRenderer).sortingOrder
			end
			self.hourglass:GetComponent(ConstData.SpriteRenderer).sortingOrder = 7 + self.X + 1 + (self.Y + 1) * self.map.cellXCount  -- self.castle_hour_glass_order + 1000
		else
			self.hourglass:GetComponent(ConstData.SpriteRenderer).sortingOrder = 7 + self.X + 1 + self.Y * self.map.cellXCount
		end
		self.hourglass.gameObject:GetComponent("Animation").enabled = true
	end
end

-- 隐藏hourglass
function ElementBehaviour:hideHourglass()
	if not IsNil(self.hourglass) then
		self:OperateHourglass(false)
		self.hourglass:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
		if self.data.ItemType == ConstData.STR_CASTLE or self.data.ItemType == "mine" then
			if not self.castle_hour_glass_order then
				self.castle_hour_glass_order = self.hourglass:GetComponent(ConstData.SpriteRenderer).sortingOrder
			end
			self.hourglass:GetComponent(ConstData.SpriteRenderer).sortingOrder = 7 + self.X + 1 + (self.Y + 1) * self.map.cellXCount  -- self.castle_hour_glass_order + 1000
		end
		self.hourglass.gameObject:GetComponent("Animation").enabled = false
		self:HiedeAdsState()
	end
end

function ElementBehaviour:ShowAdsState(order)
	local canShow = true
	-- 主世界内广告次数调整
	local lvty = App:applyFunc(ConstData.Level, ConstData.getMapType)
	-- 获取状态
	canShow = MM.AdsPlay:getSpeedUpAdsState()

	local showState = App:applyFunc(ConstData.AdsPlay,  "UsingAdsPannel", self)
	if not IsNil(self.transform) and canShow then
		local adsFlower = self.transform:Find("AdsFlower")
		local hourglass = self.transform:Find("hourglass")
		self.needShowAds = false
		if not adsFlower then 
			return
		end
		self.adsFlowerShow = true
		adsFlower.gameObject:SetActive(showState)
		local glass_order = 7 + self.X + 1 + self.Y * self.map.cellXCount + 1000 -- hourglass:GetComponent(ConstData.SpriteRenderer).sortingOrder + 1000
		SpineManager.Order(adsFlower.gameObject, glass_order)
	end
end

function ElementBehaviour:HiedeAdsState()
	if not IsNil(self.transform) then
		local adsFlower = self.transform:Find("AdsFlower")
		if not adsFlower then 
			return
		end
		self.adsFlowerShow = false
		adsFlower.gameObject:SetActive(false)
	end
end

function ElementBehaviour:showCleanTimer()
	if not self.cost_animate then
		if not IsNil(self.time) then
			self.time.gameObject:SetActive(true)
			self.needShowAds = true
			self.h1 = self.h1 or self.time.transform:Find("h1")
			self.h2 = self.h2 or self.time.transform:Find("h2")
			self.m1 = self.m1 or self.time.transform:Find("m1")
			self.m2 = self.m2 or self.time.transform:Find("m2")
			self.s1 = self.s1 or self.time.transform:Find("s1")
			self.s2 = self.s2 or self.time.transform:Find("s2")
			self.timerLuaParam = self.timerLuaParam or self.time:GetComponent("LuaParameter")
			self.timerFreeBtn = self.timerFreeBtn or self.time.transform:Find("Btn")
			self.diamondQuickBtn = self.diamondQuickBtn or self.time.transform:Find("QuickBtn")
		end
	end
end

function ElementBehaviour:hideCleanTimer()
	if IsNil(self.transform) then
		return
	end
	if not IsNil(self.time) then
		self.time.gameObject:SetActive(false)
		self:HiedeAdsState()
		if (self.timerFree) then
			self.timerFree = false
			self.timerFreeBtn.gameObject:SetActive(false)
		end
	end
end

function ElementBehaviour:showBuildTimer()
	if not self.cost_animate then
		if not IsNil(self.time) then
			self.time.gameObject:SetActive(true)
			self.needShowAds = true
			self.h1 = self.h1 or self.time.transform:Find("h1")
			self.h2 = self.h2 or self.time.transform:Find("h2")
			self.m1 = self.m1 or self.time.transform:Find("m1")
			self.m2 = self.m2 or self.time.transform:Find("m2")
			self.s1 = self.s1 or self.time.transform:Find("s1")
			self.s2 = self.s2 or self.time.transform:Find("s2")
			self.timerLuaParam = self.timerLuaParam or self.time:GetComponent("LuaParameter")
			self.timerFreeBtn = self.timerFreeBtn or self.time.transform:Find("Btn")
			self.diamondQuickBtn = self.diamondQuickBtn or self.time.transform:Find("QuickBtn")
		end
	end
end

function ElementBehaviour:hideBuildTimer()
	if not IsNil(self.time) then
		self.time.gameObject:SetActive(false)
		self:HiedeAdsState()
		self:hideDiamondQuickButton()
	end
end

-- 出现时间免费按钮
function ElementBehaviour:showTimerFreeButton()
	-- 解决时间精灵加速的时候也出现免费按钮的问题
	if (self:GetBuildingWorkerType() ~= "worker") then
		return
	end
	if not self.timerFree then
		self.timerFree = true
		if self.timerFreeBtn then
			local assetPkg = ResourcesManager:GetInstance():getAssetPkg()
			self.textFree = self.textFree or UIMgrUtil:find(self.timerFreeBtn, "txt")
			local spriteName = "Lang_" .. LANG
			if LANG == "Russian" or LANG == "Italian" then
				spriteName = "Lang_English"
			end
			SpriteManager:SetUISprite(assetPkg, self.textFree.gameObject, ResCfg.Altas.Texture, spriteName, true)
			self.timerFreeBtn.gameObject:SetActive(true)
			if FakeCorouteInst then
		        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
		        	self.time_btnCollider = self.time_btnCollider or self.timerFreeBtn:GetComponent("BoxCollider2D")
					if not self.time_btnCollider.enabled then
						self.time_btnCollider.enabled = true
						local timerFreeBtnBehaviour = BehaviourUtil.AddBehaviour(self.timerFreeBtn.gameObject, TimerFreeBtnBehaviour, self)
						BaseLogic:GetInstance():AddClick(timerFreeBtnBehaviour, nil, nil, self.TimerFreeClick, self)
					end
					-- 隐藏砖石加速按钮
		    		self:hideDiamondQuickButton()
		    	end)
		    end
		end
	end
end

-- 显示钻石加速
function ElementBehaviour:showDiamondQuickButton()
	self.diamond = self.diamond or 0 -- 加速需要消耗的砖石数
	self.curDiamond = self.curDiamond or -1
	if math.abs(self.cost_time - GlobalData.FreeTime) < 1 then
		self:hideDiamondQuickButton()
		return
	end
	if (not self.diamondQuick) then
		self.diamondQuick = true
		self.diamondQuickBtn = self.diamondQuickBtn or self.transform:Find("timer/QuickBtn")
		self.disQuickBtn = self.disQuickBtn or self.transform:Find("timer/QuickBtn/disQuickBtn")
		local coin_buff = App:applyFunc(ConstData.ActivityBuff, "GetBuffType") == "buff_coin_speed"
		if self.diamondQuickBtn then
			self.diamondQuickBtn.gameObject:SetActive(true)
			if self.disQuickBtn then
				self.disQuickBtn.gameObject:SetActive(coin_buff)
			end
			self.curDiamond = self:GetSpeedDiamond()
			if FakeCorouteInst then
			    FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
			       self.diamond_btnCollider = self.diamond_btnCollider or self.diamondQuickBtn:GetComponent("BoxCollider2D")
					if not self.diamond_btnCollider.enabled then
						self.diamond_btnCollider.enabled = true
						local diamondQuickBtnBehaviour = BehaviourUtil.AddBehaviour(self.diamondQuickBtn.gameObject, DiamondQuickBtnBehaviour, self)
						diamondQuickBtnBehaviour.element = self
						BaseLogic:GetInstance():AddClick(diamondQuickBtnBehaviour, nil, nil, self.DiamondQuickClick)
					end
			    end)
			end
		end
		App:applyFunc(ConstData.Element, "addDiamondQuickBuildElement", self)
	end
end

function ElementBehaviour:refreshDiamondQuickButton()
	self.diamondQuickBtn = self.diamondQuickBtn or self.transform:Find("timer/QuickBtn")
	if self.diamondQuickBtn and self.diamondQuickBtn.gameObject.activeSelf then
		self:CheckSpeedDiamondChange(true)
	end
end

function ElementBehaviour:hideDiamondQuickButton()
	self.diamondQuick = false
	self.diamondQuickBtn = self.diamondQuickBtn or self.transform:Find("timer/QuickBtn")
	self.disQuickBtn = self.disQuickBtn or self.transform:Find("timer/QuickBtn/disQuickBtn")
	if self.disQuickBtn then
		self.disQuickBtn.gameObject:SetActive(false)
	end
	if (self.diamondQuickBtn) then
		self.diamondQuickBtn.gameObject:SetActive(false)
	end
	App:applyFunc(ConstData.Element, "removeDiamondQuickBuildElement", self)
	self.diamond = 0
	self.curDiamond = 0
end

--
function ElementBehaviour:TimerFreeClick(gameObject, position, isMoved, tb)
	if self.dialogClick then
        return
    end

    if App:applyFunc(ConstData.FirstPlayTeach, "InForceState") then -- 教学引导时不起作用
    	return
    end
    self.dialogClick = true
    self:delayedCall(0.1, function() 
        self.dialogClick = false
    end)
	if tb then
		-- 隐藏Timer，重置self.cost_time
		App:applyFunc(ConstData.Sound,  "playSound", "overtime")
		-- tb.cost_time = DeltaTime
		tb:setCostTime(DeltaTime)
	end
end

function ElementBehaviour:DiamondQuickClick(gameObject, position, isMoved, tb)
	-- 判断
	if VISITOR_MODE then
		UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UILogin, {"expend"}, {
			Scene = "Main"
		})
	else
		local clip = "closeBtn"
		local coin_buff = App:applyFunc(ConstData.ActivityBuff, "GetBuffType") == "buff_coin_speed"
		if coin_buff then
			local needCoin = (GlobalData.CoinExDiamondRatio or 5) * self.element.diamond
            if math.floor(needCoin) <= UserData:GetInstance():coin() then
            	clip = "overtime"
				-- self.element.cost_time = DeltaTime
				self.element:setCostTime(DeltaTime)
            	ClientData:GetInstance():changeCoin(UserData:GetInstance():coin() - math.floor(needCoin))
				App:applyFunc(ConstData.DCAuxiliaryTool, "RecordDataResource", "cost_currency_coin", "SpeedUp_Building", math.floor(needCoin))
                App:applyFunc(ConstData.Task,  "onceTask", "UseCoin-1-" .. tostring(math.floor(needCoin)))
				App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Element", param = {"UseCoin"}})
                self.element:hideDiamondQuickButton()
            else
				local userCoin = UserData:GetInstance():coin()
				local lackCoin = tonumber(math.floor(needCoin) - userCoin)
				UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIMarketCoinBuyPannel, {"expend"}, lackCoin)
            end
		else
			if self.element.diamond <= UserData:GetInstance():diamond() then
				-- 砖石加速
				clip = "overtime"
				-- self.element.cost_time = DeltaTime
				self.element:setCostTime(DeltaTime)
				--
				ClientData:GetInstance():changeDiamond(UserData:GetInstance():diamond() - math.floor(self.element.diamond))
				App:applyFunc(ConstData.DCAuxiliaryTool, "RecordDataResource", "cost_currency_diamond", "SpeedUp_Building", math.floor(self.element.diamond))
				App:applyFunc(ConstData.Task,  "onceTask", "UseDiamond-1-" .. tostring(math.floor(self.element.diamond)))
				App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Element", param = {"UseDiamond"}})
				self.element:hideDiamondQuickButton()
			else
				UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIDiamondShop, {"expend"})
			end
		end
	end
	App:applyFunc(ConstData.Sound,  "playSound", clip)
end

function ElementBehaviour:dialogRed()
	if not IsNil(self.dialog) then
		self.dialog:GetComponent(ConstData.SpriteRenderer).color = Color(1, 0, 0, 1)
		-- 内部物品显示
		self:OperateDicon(true)
		self.icon:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
	end
end

function ElementBehaviour:dialogCommon()
	if not IsNil(self.dialog) then
		-- 解决快速点击可收获的农作物，出现一个农作物无法消失的问题
		AnimateTween.cancelAllObject(self.dialog.gameObject, false)
		self.dialog:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
	end
end

-- 隐藏显示对话框
function ElementBehaviour:hideDialog(func)
	if self.status == StatusConst.WaitingForReap or 
	   self.status == StatusConst.WaitingForFood or
	   self.status == StatusConst.FinishForCook or
	   self.status == StatusConst.Common then
		if not IsNil(self.dialog) and self.dialog_show then
			AnimateTween.delayCall(0.1, function() 
				if not IsNil(self.header) then
					if (self.data.ItemType == "castlefloor") then 
						self.header.localPosition = Vector3(0, 1.4, 0)
					else
						self.header.localPosition = Vector3(0, 0.76, 0)
					end
				end
			end)
			self.dialog_show = false
		    -- 消失
		    self:OperateDicon(false)
		    if not IsNil(self.icon) then
		    	self.icon.gameObject:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
		    end
		    self.map.dialogShow = false
		    self.dialog_scale_aid = AnimateTween.valueTo(self.dialog.gameObject, 0, 1, 0.2, function(tm) 
		        self.dialog.transform.localScale = self.dialogOldScale * (1 - tm)
		    end)
		    if not IsNil(self.dialogAni) then
		    	self.dialogAni.gameObject:GetComponent("Animation").enabled = false
		    end
		    AnimateTween.setCallBack(self.dialog_scale_aid, function() 
				if not self.dialog_show then
		    		self.dialog:GetComponent(ConstData.SpriteRenderer).enabled = false
				end
		    	if func then
		    		func()
		    	end
			end)
		else
			if func then
	    		func()
	    	end
		end
	end
end

-- 显示对话框
function ElementBehaviour:showDialog(func, force)
	local reap = UPlayerPrefs.GetInt(CURRENT_USER .. "_Reap_Enable", 0)
	if (self.status == StatusConst.WaitingForReap and reap > 0) or 
		self.status == StatusConst.WaitingForFood or
		self.status == StatusConst.FinishForResUpgrade or force then
		if (not IsNil(self.dialog) and not self.dialog_show) or force then
			-- 
			if not IsNil(self.header) then
				self.header_show = self.header.gameObject.activeSelf
				if self.header_show then
					local offY = 0.8
					if ElementInfoData[self.cellId] then
						offY = ElementInfoData[self.cellId].headerOffsetY or 0.8
					end
					self.header.transform.localPosition = Vector3(0, 0.76 + offY, 0) -- 0.8
				end
			end
			if self.dialog_scale_aid then
				AnimateTween.cancel(self.dialog_scale_aid)
				self.dialog_scale_aid = nil
			end
		    self.dialog:GetComponent(ConstData.SpriteRenderer).enabled = true
			self.dialog_show = true
		    -- 消失
		    self.map.dialogShow = true
		    local aid = AnimateTween.valueTo(self.dialog.gameObject, 1, 0, 0.2, function(tm) 
		        self.dialog.transform.localScale = self.dialogOldScale * (1 - tm)
		    end)
		    AnimateTween.setCallBack(aid, function() 
		    	if func then
		    		func()
		    	end
			end)
		    -- alpha
		    self.dialog:GetComponent(ConstData.SpriteRenderer).color = Color(
		    	self.dialog:GetComponent(ConstData.SpriteRenderer).color.r, 
		    	self.dialog:GetComponent(ConstData.SpriteRenderer).color.g, 
		    	self.dialog:GetComponent(ConstData.SpriteRenderer).color.b, 1)
		    -- dialogAni
		    if not IsNil(self.dialogAni) then
		    	self.dialogAni.gameObject:GetComponent("Animation").enabled = true
		    end
		    -- icon
		    self:OperateDicon(true)
		    if not IsNil(self.icon) then
		    	self.icon.gameObject:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
		    end
		else
			if func then
				func()
			end
		end
	end
end

function ElementBehaviour:showTiledSprite(spriteName)
	if not IsNil(self.tile) then
		App:applyFunc(ConstData.Sprite, "getSprite", spriteName, function(sprite, offset) 
			if sprite then
				if not IsNil(self.tile) then
					self.tileSprite_origin_position = self.tileSprite_origin_position or self.tile.localPosition
					self.tile.gameObject:GetComponent(ConstData.SpriteRenderer).sprite = sprite
					self.tile.localPosition = self.tileSprite_origin_position + offset
				end
				self.tile.gameObject:SetActive(true)
				self.tile.gameObject:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
			end
		end)
	end
end

-- 显示地片
function ElementBehaviour:showTiled(color)
	if not IsNil(self.tile) then
		self.tile.gameObject:SetActive(true)
		self.tile.gameObject:GetComponent(ConstData.SpriteRenderer).color = color or Color(1, 1, 1, 1)
	end
end

-- 隐藏地片
function ElementBehaviour:hideTiled()
	if not IsNil(self.tile) then
		self.tile.gameObject:SetActive(false)
		self.tile.gameObject:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
	end
end

function ElementBehaviour:reflushBloodBar()
	-- TODO 关卡专用
end

function ElementBehaviour:reduceBloodBar(value)
	-- TODO 关卡专用
end

function ElementBehaviour:addBloodBar()
	-- TODO 关卡专用
end

function ElementBehaviour:showSpriteRenderer()
	if not IsNil(self.sprite) then
		BehaviourUtil.SetBehaviourEnable(self.sprite.gameObject, "SpriteBehaviour", true)
		self.sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer)).enabled = true
	end
end

function ElementBehaviour:hideSpriteRenderer()
	if not IsNil(self.sprite) then
		BehaviourUtil.SetBehaviourEnable(self.sprite.gameObject, "SpriteBehaviour", false)
		self.sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer)).enabled = false
	end
end

-- 元素初始化方法即生成方法
function ElementBehaviour:InitBehaviour(options)
	self:initProp()
	self.map = self.map or App:get(ConstData.STR_MAP)
  	self.mapData = self.mapData or ClientData:GetInstance():MapData()
  	self.extraData = self.extraData or ClientData:GetInstance():ExtraData()
  	self.particle = options.particle
  	local cameraLook = options.cameraLook
	-- 参数化
	local position = options.position
	-- 这里的name是Sprite
	local name = options.name
	local x = options.x
	local y = options.y
	local moveTo = options.moveTo
	local startPosition = options.startPosition
	self.posInPlace = false -- 生成是否位置到位
	-- PROCESS
	self.HighLighting = false
	BehaviourUtil.RemoveBehaviour(self.spine.gameObject, "SpriteBehaviour")
	BehaviourUtil.RemoveBehaviour(self.sprite.gameObject, "SpriteBehaviour")
  	if App:applyFunc(ConstData.Element, "CheckSpineOnly", self.cellId) then 
		BehaviourUtil.AddBehaviour(self.spine.gameObject, SpriteBehaviour, self)
		BehaviourUtil.AddBehaviour(self.sprite.gameObject, SpriteBehaviour, self)
	else
  		BehaviourUtil.AddBehaviour(self.sprite.gameObject, SpriteBehaviour, self)
  	end
  	-- 
  	self.dialogBehaviour = {}
  	self.dialogBehaviour.gameObject = self.dialog.gameObject
	self.name = name
	self.dialogOldScale = Vector3.one
	-- 特征
    self.X = x
    self.Y = y
    -- 针对精灵设置的一个状态
    self.isWorking = false 
    -- debug.log("element-->", self.status)
    self.status = self.status or StatusConst.Common
    -- 本身对象层级记录
    self.orders = {}
	-- 获取图片 (临时)
	if self.data.ItemType == "special" or self.data.ItemType == "npc" or self.data.ItemType == "monster" then
		name = "100x200"
	end
	if self.data.ItemType == "npc" then
		self.status = StatusConst.Common
		--
		self.map.npcs[self.cellId] = self
		App:applyFunc(ConstData.ProfilePicture, "AddExistProfilePic", self.cellId, true)
	end
	local spriteName = name
	if self.mapData[name] then
		spriteName = self.mapData[name].SpriteName
	end
	App:applyFunc(ConstData.Sprite, "getSprite", spriteName, function(sprite, offset) 
		if sprite and name ~= "100x200" then
			self.spriteRenderer.sprite = sprite
			self.gameObject:GetComponent(typeof(SpriteRenderer)).sprite = sprite
		elseif sprite then
			self.spriteRenderer.sprite = nil
			self.gameObject:GetComponent(typeof(SpriteRenderer)).sprite = sprite
		else
			self.spriteRenderer.sprite = nil
			self.gameObject:GetComponent(typeof(SpriteRenderer)).sprite = sprite
		end
		
		self.sprite_origin_localposition = self.sprite_origin_localposition or self.sprite.gameObject.transform.localPosition
		offset = offset or Vector3.zero
		self.sprite.gameObject.transform.localPosition = self.sprite_origin_localposition + offset

		if self.data.ItemType ~= "special" and self.data.ItemType ~= "monster" then
			self:addInteract()
		else
			-- 切换
			App:applyFunc(ConstData.Locked, "hide", self.X, self.Y)
			if self.cellId == "Base_01" or self.cellId == "Base_02" then
				-- 藤蔓台子
				if self.sprite then
					self.sprite.gameObject.transform.localPosition = Vector2(0, 0.3, 0)
					self:delayedCall(0.25, function() 
						self.spriteRenderer.sortingOrder = SpineManager.getOrder(self.spine.gameObject) + 1
						-- 配置限制虚影
						if self.mapData[self.originParam.Key] then
							local spriteName = self.mapData[self.originParam.Key].SpriteName
							App:applyFunc(ConstData.Sprite, "getSprite", spriteName, function(sprite, offset2) 
								if sprite then
									self.spriteRenderer.sprite = sprite
									self.spriteRenderer.color = Color(1, 1, 1, 0.5)
									self.sprite.gameObject.transform.localPosition = self.sprite.gameObject.transform.localPosition + offset2
								end
							end)
						end
					end)
				end
			end
		end
		--
	 	self.shadowSpriteRenderer = self.shadowSpriteRenderer or self.shadow:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
	 	self.shadow_color = self.shadowSpriteRenderer.color
	 	local n_name = (self.cellId or "element") .. "_" .. math.random(10000, 99999)
	 	self.gameObject.name = n_name
		-- 改名结束，赋值优化
		self:CloseTransparentDeal()
		local index = self.X + 1 + self.Y * self.map.cellXCount
		local spriteOrder = 4 + index
		if self.map.currentMatrix[index] == "C" then
			spriteOrder = 5
		end
		
		if not IsNil(self.mation) then
			self.mation.gameObject:GetComponent(ConstData.SpriteRenderer).sortingOrder = 6 + index
		end

		if (self.status == StatusConst.Common) then 
	    	self:buildFinish()
	    end

	    if (self.data.ItemType == "castlefloor" and self.status == StatusConst.Common) then
		   	self:buildFinish()
		end
		self:LayerDown()
		if not moveTo then
			self.gameObject.transform.position = Vector3(position.x, position.y - cellHeight, position.z)
			self.spriteRenderer.sortingOrder = spriteOrder
			self.posInPlace = true -- 生成是否位置到位
			self:StartSeal()
		else
			self.spriteRenderer.sortingLayerName = "ForeGround"
			local originScale = self.sprite.transform.localScale
			if originScale.x < 0.5 then
				originScale = Vector3.one
			end

			self.sprite.transform.localScale = Vector3.zero
			local giveBpExp = (self.tag and self.tag == "Copy")
			-- 抛物线
			self:BezierMove(startPosition, position, function() 
				self.spriteRenderer.sortingLayerName = "Default"
				self.spriteRenderer.sortingOrder = spriteOrder
				local spine = App:applyFunc(ConstData.Spine, "spineDelCallback", "ShowSpine")
			   	spine.transform:SetParent(self.transform, false)
			   	spine.transform.localPosition = Vector3(0, -0.42, 0)
			   	spine.transform.localScale = Vector3(0.8, 0.8, 0.8)
				if FakeCorouteInst then
			        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
			        	if not IsNil(spine) then
							local parent = GameObjectPool:GetInstance():GetPoolParent()
			        		spine.transform:SetParent(parent, true)
			        	end
			    	end)
			    end
			    if not IsNil(self.spine) and not IsNil(self.sprite) then
			    	if not self.data.ItemType == "treasure" then
			    		self:MoveEnd(self.spine.gameObject, self.sprite.gameObject)
			    	end
			    end
			  
			    self.posInPlace = true -- 生成是否位置到位
			    if cameraLook then 
					-- 相机移动加入队列
					App:applyFunc(ConstData.Cache, ConstData.Insert, CacheCfg.ActionType.CameraMove, {
						MethodName = "move",
						Position = self.transform.position,
						Speed = 7.5, 
						MoveTime = 1,
					})
			    end
			    self:StartSeal()
			    if self.data.ItemType == "bubble" then
					-- 复制Sprite变更为气泡
					if not IsNil(self.sprite.gameObject) then
						AnimateTween.delayCall(0.2, function() 
							-- 飞入
							self:FlyToGiftBox()
						end)
					end
				end
				if giveBpExp then
					-- 购买复制品时候 活动岛增加经验
					App:applyFunc(ConstData.ActivityIsLandBP, "OnMapItemBuildFinish", self)
				end
			end, nil, nil, true)

			-- 单独归还
			AnimateTween.delayCall(0.38, function() 
				-- 归还粒子
			    if self.particle and self.particle ~= "" and not IsNil(self.gameObject) then 
			    	App:applyFunc(ConstData.Particle, "GiveBackParticle", self.transform, self.particle)
			    	self.particle = nil
			    end
			end)

	        -- 从小到大
	        local aid = AnimateTween.valueTo(self.sprite.gameObject, 0, 1, 0.2, function(tm)
	        	local curScale = originScale * tm
	        	curScale.x = curScale.x > 1 and 1 or curScale.x 
	        	curScale.y = curScale.y > 1 and 1 or curScale.y
	        	self.sprite.localScale = curScale
	    	end)

	        aid:setEase(LeanTweenType.easeOutBack)
	        AnimateTween.setCallBack(aid, function ()
		    	AnimateTween.delayCall(0.33, function()
		    		if self.data.ItemType ~= "food" and self.data.ItemType ~= "cook" then
		    			if self.gameObject and  self.sprite.gameObject then
			        		self.sprite.gameObject.transform.localScale = originScale
			    		end
		    		end
		       	end)
		    end)
	        if self.tag and self.tag == "Copy" then
		        self.tag = nil
	        end
		end
		if self.data.ItemType == "timeelf" and self.cellId == "Timeelf05" then
			-- 针对精灵处理
			App:applyFunc(ConstData.Element, "refreshStatus", self)
		end
		App:applyFunc(ConstData.Status, "refreshStatus", self)
	end)
    --
    if self.data.ItemType == "monster" then
		-- 增加血条
		self:addBloodBar()
	end
	-- 初始化 Order
	self:setNeedSortingOrder(true)
	if table.indexof(StoryMarkData, self.data.ItemType) then
		-- 增加Popup
		local is_locked, is_in_cloud = false, false
		local index = self.X + 1 + self.Y * self.map.cellXCount
		if self.map.currentLockArea[index] and self.map.currentLockArea[index] ~= "" then
			is_locked = true
		end

		if self.map.currentMatrix[index] == "C" then 
			is_in_cloud = true
		end
		if not (is_locked or is_in_cloud) then 
			self.addPopup = true
			MapUpdate:addPopupItem(self)
			self.popup_during = 0.2
		end
	end
	
    self.needShowAds = false
    self.adsFlowerShow = false
    self.GRID_INDEX_SHOW = GRID_INDEX_SHOW
    if self.GRID_INDEX_SHOW  == 1 then
	    self.grid = self.transform:Find("grid")
	    if not IsNil(self.grid) then
	    	self.grid.gameObject:SetActive(true)
	    	self:SetXY()
	    end
	end
	-- App:applyFunc(ConstData.Time, "addUpdate", self)

    if self.data.ItemType == "npc" then 
		local skinData = App:applyFunc(ConstData.SkinSystem, "GetSkinAssetName", self.cellId)
		if skinData then 
			self:SpineExchange(skinData.Spine, skinData.Skin, skinData.SpineAct)
		end
	end

	-- 根据Type
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    if lvType == ConstData.STORY_LEVEL then
    	-- 
		if self.data.ItemType == "bubble" then
			-- 复制Sprite变更为气泡
			if not IsNil(self.sprite.gameObject) then
				local bubble = self.sprite.gameObject.transform.parent:Find("bubble")
				if IsNil(bubble) then
					local o = UGameObject.Instantiate(self.sprite.gameObject)
					o.transform:SetParent(self.sprite.gameObject.transform.parent, false)
					o.transform.localPosition = Vector3(0, 0.2, 0)
					o.transform.localScale = Vector3(1, 1, 1)
					o.gameObject.name = "bubble"
					-- 变更 
					App:applyFunc(ConstData.Sprite, "getSprite", "bubble_01", function(sprite, offset) 
		                o.gameObject:GetComponent("SpriteRenderer").sprite = sprite
		            end)
		            o.gameObject:GetComponent("SpriteRenderer").sortingOrder = self.sprite.gameObject:GetComponent("SpriteRenderer").sortingOrder + 1
		        end
		        self.addBubbleTime = 0.5
				MapUpdate:addBubbleListUpdate(self)
			end
		end
    	-- 自动刷新
    	self.needItem = true
    	self.needItemTime = 0.01
		MapUpdate:addNeedItem(self)
    	-- 检测一下有没有ActiveStory
    	-- self.cellId
    	local award_data = App:applyFunc(ConstData.StoryCastle, "GetTaleItemById", self.cellId)
    	if award_data and award_data.ActiveStory and tonumber(award_data.ActiveStory) > 0 then
    		-- 判断是否已经关卡内播放过
    		-- 使用string的方式进行存储
    		local played = UPlayerPrefs.GetString(CURRENT_USER .. "_StoryTale_Played", "")
    		local played_cellIds = {}
    		if played ~= "" then
    			played_cellIds = JsonHelper.decode(played)
    		end
    		if not table.indexof(played_cellIds, self.cellId) then
    			local delayTime = 0
    			if self.map and not self.map.enterLevelAniEnd then
    				self.map.enterLevelAniEnd = true
    				delayTime = 0.5
    			end
    			AnimateTween.delayCall(delayTime, function()
    				App:applyFunc(ConstData.Camera,  "move", self.transform.position, function() 
		    			AnimateTween.delayCall(0.5, function() 
		    				-- 播放故事
							UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIStoryTale, {"expend"}, award_data.ActiveStory, self.cellId, function()
								-- 判断是否需要处理云
								if lvType == ConstData.STORY_LEVEL then
									local is_building = (self.status == StatusConst.WaitingForBuild or self.status == StatusConst.StartForBuild or self.status == StatusConst.WaitingTimeForBuild)
									if not is_building then
										App:applyFunc(ConstData.Warehouse,  "saveLevelOfCurrentObject", self.cellId)
										App:applyFunc(ConstData.Cloud, "levelCloudCheck", tostring(self.cellId))
							            -- 存储
							            played_cellIds[#played_cellIds + 1] = self.cellId
							            --
							            played = JsonHelper.encode(played_cellIds)
							            UPlayerPrefs.SetString(CURRENT_USER .. "_StoryTale_Played", played)
							        end
						        end
							end)
		    			end)
		    		end)
    			end)	
			else
				local is_building = (self.status == StatusConst.WaitingForBuild or self.status == StatusConst.StartForBuild or self.status == StatusConst.WaitingTimeForBuild)
				if not is_building then
					App:applyFunc(ConstData.Cloud, "levelCloudCheck", tostring(self.cellId), true)
				end
			end
		else
			local is_building = (self.status == StatusConst.WaitingForBuild or self.status == StatusConst.StartForBuild or self.status == StatusConst.WaitingTimeForBuild)
			if not is_building then
				App:applyFunc(ConstData.Warehouse,  "saveLevelOfCurrentObject", self.cellId)
	            App:applyFunc(ConstData.Cloud, "levelCloudCheck", tostring(self.cellId))
	        end
    	end
    	local tp = {"treehole", "wishingwell"}
    	if table.indexof(tp, self.data.ItemType) then
    		-- 判断是否在云朵下或者锁区中
    		local index = self.X + 1 + self.Y * self.map.cellXCount
    		local is_clouded = false
    		local is_locked = false
    		if self.map.currentLockMatrixCloud[index] and self.map.currentLockMatrixCloud[index] ~= "" then
    			is_clouded = true
    		end
    		if self.map.currentLockArea[index] and self.map.currentLockArea[index] ~= "" then
    			is_locked = true
    		end
    		if not is_locked and not is_clouded then
    			-- 加入到列表中
    			App:applyFunc(ConstData.Element, "accommodationStatusIn", self)
    		end
    	end
    end

	local current_tile_index = self.X + 1 + self.Y * self.map.cellXCount
	if self.map.currentLockArea[current_tile_index] and self.map.currentLockArea[current_tile_index] ~= "" then
		if self.map.currentMatrix[current_tile_index] ~= "C" then
			App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ADD_ELEMENT, {from = "init", params = {cellId = self.cellId, ele = self, isMove = moveTo}})
		end
    elseif self.map.currentMatrix[current_tile_index] == "C" then -- 云朵中, 含薄云

    elseif self.gameObject.activeSelf then
	    if lvType == ConstData.ACTIVITY_LEVEL then
	    	-- 活动
	    	local is_building = (self.status == StatusConst.WaitingForBuild or self.status == StatusConst.StartForBuild or self.status == StatusConst.WaitingTimeForBuild)
			if not is_building then
		    	App:applyFunc(ConstData.Warehouse,  "saveLevelOfCurrentObject", self.cellId)
		        App:applyFunc(ConstData.Cloud, "levelCloudCheck", tostring(self.cellId))
		    end
	    end
    	App:applyFunc(ConstData.DCAuxiliaryTool, "AddElement", self.cellId, self)
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ADD_ELEMENT, {from = "init", params = {cellId = self.cellId, ele = self, isMove = moveTo}})
    end
end

function ElementBehaviour:storyBannerShow()
	local ret = false
	if self.storyBannerBvr then
		self.storyBannerBvr.__hide = nil
		self.storyBannerBvr.gameObject.transform.localScale = Vector3(0.013, 0.013, 0.013)
		App:applyFunc(ConstData.Element, "InContainer", self)
		--
		local elements = App:applyFunc(ConstData.Element, "scanStoryElement")
		for i = 1, #elements do
			if not IsNil(elements[i]) then
				elements[i].needItem = true
				MapUpdate:addNeedItem(elements[i])
				elements[i].needItemTime = 0.01
				ret = true
			end
		end
	end
	return ret
end

-- 设置X,Y
function ElementBehaviour:SetXY()
	if self.GRID_INDEX_SHOW == 1 then
		if not IsNil(self.grid) then
			self.n1_sprite = self.n1_sprite or self.grid.transform:Find("1")
			self.n2_sprite = self.n2_sprite or self.grid.transform:Find("2")
			self.n3_sprite = self.n3_sprite or self.grid.transform:Find("3")
			self.n4_sprite = self.n4_sprite or self.grid.transform:Find("4")
			if not IsNil(self.n1_sprite) then
				self.n1_sprterenderer = self.n1_sprterenderer or self.n1_sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			end
			if not IsNil(self.n2_sprite) then
				self.n2_sprterenderer = self.n2_sprterenderer or self.n2_sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			end
			if not IsNil(self.n3_sprite) then
				self.n3_sprterenderer = self.n3_sprterenderer or self.n3_sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			end
			if not IsNil(self.n4_sprite) then
				self.n4_sprterenderer = self.n4_sprterenderer or self.n4_sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
			end
			-- 生成字符串
			local index = self.X + 1 + self.Y * self.map.cellXCount
			local str = string.format("%04d", index)
			if not IsNil(self.n1_sprterenderer) then
				self.n1_sprterenderer.sprite = self.map._luaParam:getSprite(string.sub(str, 1, 1))
			end
			if not IsNil(self.n2_sprterenderer) then
				self.n2_sprterenderer.sprite = self.map._luaParam:getSprite(string.sub(str, 2, 2))
			end
			if not IsNil(self.n3_sprterenderer) then
				self.n3_sprterenderer.sprite = self.map._luaParam:getSprite(string.sub(str, 3, 3))
			end
			if not IsNil(self.n4_sprterenderer) then
				self.n4_sprterenderer.sprite = self.map._luaParam:getSprite(string.sub(str, 4, 4))
			end
		end
	end
end

-- 关闭消耗性能的半透明物品 之后使用结束需要自行做关闭处理
function ElementBehaviour:CloseTransparentDeal()
	self:OperateShadow(false)
	self:OperateMation(false)
	self:OperateHourglass(false)
	self:OperateTile(false)
	self:OperateDicon(false)
	-- 这个在预制体上直接不激活了，目前看没有什么问题
	self.main_sprite = self.main_sprite or self.gameObject:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
	if self.main_sprite then 
		self.main_sprite.enabled = false
	end
end

-- 以下是为了打开半透明物品而出的接口
function ElementBehaviour:OperateShadow(show)
	if not IsNil(self.shadow) then 
		self.shadow.gameObject:SetActive(show)
	end
end 

function ElementBehaviour:OperateTile(show)
	if self.data["ItemType"] == "obstacle" or self.data["ItemType"] == "res" then 
		return
	end
	if not IsNil(self.tile) then 
		self.tile.gameObject:SetActive(show)
	end
end 

function ElementBehaviour:OperateDicon(show)
	if not IsNil(self.icon) then 
		self.icon.gameObject:SetActive(show)
	end
end

function ElementBehaviour:OperateMation(show)
	if not IsNil(self.mation) then 
		self.mation.gameObject:SetActive(show)
	end
end

function ElementBehaviour:OperateHourglass(show)
	if not IsNil(self.hourglass) then 
		self.hourglass.gameObject:SetActive(show)
	end
end
-- 
function ElementBehaviour:MoveEnd(spine, sprite)
	if (not IsNil(spine)) then
		if (spine.activeSelf and spine.transform.localScale.x ~= 0) then 
			self:MoveEndScale(spine)
			return
		end
	end

	if (not IsNil(sprite)) then
		if (sprite.activeSelf) then 
			self:MoveEndScale(sprite)
		end
	end
end

function ElementBehaviour:MoveEndScale(spineOrSprite)
	local totalScale = 0.7
	local originScale = spineOrSprite.transform.localScale
	-- 第一阶段
	local yScaleStep1 = 0.9 -- 这里的0.8, 是指当前scale的大小的0.8
	local xScaleStep1 = 1 -- 这里的0.8, 是指当前scale的大小的0.8
	local yFromValue1 = originScale.y
	local xFromValue1 = originScale.x
	local yDesScaleStep1 = originScale.y * yScaleStep1
	local xDesScaleStep1 = originScale.x * xScaleStep1
	local stepTime1 = 0.15 * totalScale
	local tweenStep1 = LeanTweenType.linear

	-- 第二阶段
	local yScaleStep2 = 1.1
	local xScaleStep2 = 0.9
	local yDesScaleStep2 = originScale.y * yScaleStep2
	local xDesScaleStep2 = originScale.x * xScaleStep2
	local yFromValue2 = yDesScaleStep1
	local xFromValue2 = xScaleStep1
	local stepTime2 = 0.15 * totalScale
	local tweenStep2 = LeanTweenType.linear

	-- 第三阶段
	local yScaleStep3 = 1
	local xScaleStep3 = 1
	local yDesScaleStep3 = originScale.y * yScaleStep3
	local xDesScaleStep3 = originScale.x * xScaleStep3
	local yFromValue3 = yDesScaleStep2
	local xFromValue3 = xDesScaleStep2
	local stepTime3 = 0.2 * totalScale
	local tweenStep3 = LeanTweenType.linear

	-- 缩放函数
	local salceFunc = function(finalX, finalY, fromX, fromY, time, tween, nextFunc)
		-- debug.log("缩放参数:", tostring(finalX), "-", tostring(finalY), "-", tostring(fromX), "-", tostring(fromY))
		local aid = AnimateTween.valueTo(spineOrSprite.gameObject, 0, 1, time, function(tm)
			if (not IsNil(spineOrSprite)) then 
				spineOrSprite.transform.localScale = Vector3(fromX * (1 - tm) + tm * finalX, fromY * (1 - tm) + finalY * tm, 1)
			end
		end)
		if (tween) then
			aid:setEase(tween)
		end
		AnimateTween.setCallBack(aid, function()
			aid = nil
			if (nextFunc) then nextFunc() end
		end)
	end

	-- 步骤函数
	local step3Func = function()
		salceFunc(xDesScaleStep3, yDesScaleStep3, xFromValue3, yFromValue3, stepTime3, tweenStep3, nil)
	end

	local step2Func = function()
		salceFunc(xDesScaleStep2, yDesScaleStep2, xFromValue2, yFromValue2, stepTime2, tweenStep2, step3Func)
	end

	local step1Func = function()
		if (self.data.ItemType == "cook") then 
			local from_Npc = App:applyFunc(ConstData.Cook,  "GenerateFoodFromNpc")
			if (from_Npc == false) then
				App:applyFunc(ConstData.Camera,  "move", self.transform.position)
			end
		end
		salceFunc(xDesScaleStep1, yDesScaleStep1, xFromValue1, yFromValue1, stepTime1, tweenStep1, step2Func)
	end
	step1Func()
end

-- 显示感叹号
function ElementBehaviour:ShowExclamationPoint()
	if not IsNil(self.mation) then
		self:OperateMation(true)
		self.mation:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
		if self.data.ItemType == "castle" or self.data.ItemType == "mine" then
			self.mation.gameObject.transform.localPosition = Vector3(0, -0.1, 0)
		end
		if self.data.ItemType == ConstData.STR_CASTLE or self.data.ItemType == "mine" then
			-- 层级提高200
			local sprite2_render = self.sprite2.gameObject:GetComponent(ConstData.SpriteRenderer)
			if not self.castle_exclamation_order then
				self.castle_exclamation_order = self.mation:GetComponent(ConstData.SpriteRenderer).sortingOrder
			end
			self.mation:GetComponent(ConstData.SpriteRenderer).sortingOrder = sprite2_render.sortingOrder + 1
		end
	end
end

-- 获取是否在等待和创建状态 主要用于建筑类
function ElementBehaviour:GetBuildFineshStatus()
	local build_finished = false
	if not IsNil(self.mation) and not IsNil(self.hourglass) then
		if (self.mation:GetComponent(ConstData.SpriteRenderer).color.a <= 0.1) and 
			(self.hourglass.gameObject:GetComponent(ConstData.SpriteRenderer).color.a <= 0.1) then
			build_finished = true
		end
	end
	return build_finished
end

-- 隐藏感叹号
function ElementBehaviour:HideExclamationPoint()
	if not IsNil(self.mation) then
		self:OperateMation(false)
		self.mation:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
		if self.data.ItemType == ConstData.STR_CASTLE or self.data.ItemType == "mine" then
			-- 层级提高200
			if not self.castle_exclamation_order then
				self.castle_exclamation_order = self.mation:GetComponent(ConstData.SpriteRenderer).sortingOrder
			end
			self.mation:GetComponent(ConstData.SpriteRenderer).sortingOrder = self.castle_exclamation_order + 1000
		end
	end
end

function ElementBehaviour:DestroyMySelfImmediate(func)
	if IsNil(self.gameObject) then
		return
	end
	self:ElementEnd(self.gameObject, "TouchEnd")
	AnimateTween.cancelAllObject(self.gameObject, false)
	-- 清除Drag和所有组件
	self.boxCollider2D = self.boxCollider2D or self.gameObject:GetComponent("BoxCollider2D")
	if not IsNil(self.boxCollider2D) then
		UGameObject.DestroyImmediate(self.boxCollider2D)
		self.boxCollider2D = nil
	end
	-- 拖动
	self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
	if not IsNil(self.extDragComp) then
		UGameObject.DestroyImmediate(self.extDragComp)
		self.extDragComp = nil
	end
	-- 清理地皮
	local index = self.X + 1 + self.Y * self.map.cellXCount
	self.map.currentMatrix[index] = ""
	self.map.emptyMatrix[index] = true
	if type(self.map.currentLockMatrixCloud[index]) == ConstData.TABLE_TYPE then
		self.map.currentLockMatrixCloud[index] = ""
	end
	local X = self.X
	local Y = self.Y
	-- 重新计算Locked 与当前移除的元素联通的Lock区域解锁，需要属于currentLockArea区域
	if self.data.ItemType == "obstacle" then
		if self.map.currentLockArea[X + 1 + Y * self.map.cellXCount] then
			self.map.currentLockArea[X + 1 + Y * self.map.cellXCount] = nil
			App:applyFunc(ConstData.Locked, "del", X, Y)
			self.ActiveNodeList = {}
			self.ForbiddenNodeList = {}
			local tempMatrix = {}
			for k, v in pairs(self.map.currentLockArea) do
				local behaviour = self.map.currentMatrix[v.X + 1 + v.Y * self.map.cellXCount]
				if type(behaviour) == ConstData.TABLE_TYPE then
					if (behaviour.data and behaviour.data.IsObstacle == 1) or (behaviour.cellId == "Vine_01") then
						tempMatrix[v.X + 1 + v.Y * self.map.cellXCount] = "Z"
						self.ForbiddenNodeList[#self.ForbiddenNodeList + 1] = v.X + 1 + v.Y * self.map.cellXCount
					else
						tempMatrix[v.X + 1 + v.Y * self.map.cellXCount] = v
					end
				else
					tempMatrix[v.X + 1 + v.Y * self.map.cellXCount] = v
				end
			end 

			-- 从X和Y开始便利
			self:travArea(tempMatrix, X + 1, Y)
			self:travArea(tempMatrix, X - 1, Y)
			self:travArea(tempMatrix, X, Y + 1)
			self:travArea(tempMatrix, X, Y - 1)
			--
			for k1, v1 in pairs(self.ActiveNodeList) do
				local _X = v1 % self.map.cellXCount - 1
				local _Y = math.floor((v1 - (v1 % self.map.cellXCount)) / self.map.cellXCount)
				App:applyFunc(ConstData.Locked,  "del", _X, _Y)
				if self.map.currentLockArea[_X + 1 + _Y * self.map.cellXCount] then
					self.map.currentLockArea[_X + 1 + _Y * self.map.cellXCount] = nil
					local behaviour = self.map.currentMatrix[_X + 1 + _Y * self.map.cellXCount]
					if behaviour.unlock then
						if behaviour.oldStatus then
	                        behaviour.status = behaviour.oldStatus
	                        behaviour.oldStatus = nil
	                    end
						behaviour:unlock()
					end
				end
			end
			-- 
			if FakeCorouteInst then
		        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 5, function() 
		        	local floors = App:applyFunc(ConstData.Element, "Floors")
			        floors = floors or {}
			        for k, v in pairs(floors) do
			            App:applyFunc(ConstData.Warehouse,  "floorCheck", v)
			        end
		    	end)
		    end
			App:applyFunc(ConstData.MapArea, "refreshLockGrid")
			-- 刷新剧情关卡arrow
		    App:applyFunc(ConstData.Status, "RefreshStoryArrow", self)
		end
	end
	self:setNeedSortingOrder(false)
	-- 回收
	if self then 
		self:Cycler()
	end
	if func then
		func()
	end
end

-- 如果保证执行
function ElementBehaviour:DestroyMySelf(func, temp, rightNow)
	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ELEMENT_DESTROY, {from = "DestroyMySelf", param = self})
	self:ElementEnd(self.gameObject, "TouchEnd")
	if IsNil(self.boxCollider2D) and not IsNil(self.gameObject) then
		self.boxCollider2D = self.gameObject:GetComponent("BoxCollider2D")
	end
	if not IsNil(self.boxCollider2D) then
		UGameObject.DestroyImmediate(self.boxCollider2D)
		self.boxCollider2D = nil
	end
	-- 拖动
	if IsNil(self.extDragComp) and not IsNil(self.gameObject) then
		self.extDragComp = self.gameObject:GetComponent("ExtDrag")
	end
	if not IsNil(self.extDragComp) then
		UGameObject.DestroyImmediate(self.extDragComp)
		self.extDragComp = nil
	end

	if not IsNil(self.gameObject) then 
    	local aid = LeanTween.scale(self.gameObject, Vector3.zero, 0.33)
		aid:setEase(LeanTweenType.easeInBack)
	end

	-- 清理地皮
	local index = self.X + 1 + self.Y * self.map.cellXCount
	self.map.emptyMatrix[index] = true
	self.map.currentMatrix[index] = ""
	if type(self.map.currentLockMatrixCloud[index]) == ConstData.TABLE_TYPE then
		self.map.currentLockMatrixCloud[index] = ""
	end
	local X = self.X
	local Y = self.Y
	self.isWorking = false
	local isDelLock = false
	-- 目前只有levelType
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
	-- 如果是Story
	if lvType == ConstData.STORY_LEVEL then
		self:cancelArrowInStory()
		App:applyFunc(ConstData.Status, "UnSpecialStatus", self, true)
	end
	App:applyFunc(ConstData.Element, "OnElementDestroy", self)
	App:applyFunc(ConstData.DCAuxiliaryTool, "ReduceElement", self.cellId, self)
	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.REDUCE_ELEMENT, {from = "destroySelf", params = {cellId = self.cellId, ele = self}})

	-- 重新计算Locked 与当前移除的元素联通的Lock区域解锁，需要属于currentLockArea区域
	-- 只有类别是 obstacle
	if self.data.ItemType == "obstacle" then
		if self.map.currentLockArea[X + 1 + Y * self.map.cellXCount] then
			self.map.currentLockArea[X + 1 + Y * self.map.cellXCount] = nil
			isDelLock = true
			App:applyFunc(ConstData.Locked,  "del", X, Y)
			--
			self.ActiveNodeList = {}
			self.ForbiddenNodeList = {}
			local tempMatrix = {}
			for k, v in pairs(self.map.currentLockArea) do
				local behaviour = self.map.currentMatrix[v.X + 1 + v.Y * self.map.cellXCount]
				if type(behaviour) == ConstData.TABLE_TYPE then
					if behaviour.data and behaviour.data.IsObstacle == 1 or (behaviour.cellId == "Vine_01") then
						tempMatrix[v.X + 1 + v.Y * self.map.cellXCount] = "Z"
						self.ForbiddenNodeList[#self.ForbiddenNodeList + 1] = v.X + 1 + v.Y * self.map.cellXCount
					else
						tempMatrix[v.X + 1 + v.Y * self.map.cellXCount] = v
					end
				else
					tempMatrix[v.X + 1 + v.Y * self.map.cellXCount] = v
				end
			end 
			-- 从X和Y开始便利
			self:travArea(tempMatrix, X + 1, Y)
			self:travArea(tempMatrix, X - 1, Y)
			self:travArea(tempMatrix, X, Y + 1)
			self:travArea(tempMatrix, X, Y - 1)
			local delayIndex = 0
			for k1, v1 in pairs(self.ActiveNodeList) do
				local _X = v1 % self.map.cellXCount - 1
				local _Y = math.floor((v1 - (v1 % self.map.cellXCount)) / self.map.cellXCount)
				App:applyFunc(ConstData.Locked,  "del", _X, _Y)
				self.map.currentLockArea[_X + 1 + _Y * self.map.cellXCount] = nil
				local behaviour = self.map.currentMatrix[_X + 1 + _Y * self.map.cellXCount]
				if behaviour.unlock then
					if behaviour.oldStatus then
                        behaviour.status = behaviour.oldStatus
                        behaviour.oldStatus = nil
                    end
					behaviour:unlock(nil, delayIndex)
                    delayIndex = delayIndex + 1					
				end
			end
	    	if lvType == ConstData.STR_MASTER then
				App:applyFunc(ConstData.Task,  "onceTask", "UnlockArea")
				App:applyFunc(ConstData.Task,  "triggerTaskPool", "UnlockArea")
				App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Element", param = {"UnlockArea"}})
			end
		    App:applyFunc(ConstData.MapArea, "refreshLockGrid")
		    -- 刷新剧情关卡arrow
		    App:applyFunc(ConstData.Status, "RefreshStoryArrow", self)
		end
	end

	-- 针对2x2
	if table.indexof(LandMarkData, self.data.ItemType) then
		App:applyFunc(ConstData.Element, "ClearLandMarks", X, Y)
		App:applyFunc(ConstData.Element, "ClearLandMarks", X + 1, Y)
		App:applyFunc(ConstData.Element, "ClearLandMarks", X, Y + 1)
		App:applyFunc(ConstData.Element, "ClearLandMarks", X + 1, Y + 1)

		local index = self.X + 2 + self.Y * self.map.cellXCount
		self.map.emptyMatrix[index] = true
        self.map.currentMatrix[index] = ""
		if type(self.map.currentLockMatrixCloud[index]) == ConstData.TABLE_TYPE then
			self.map.currentLockMatrixCloud[index] = ""
		end

		index = self.X + 1 + (self.Y + 1) * self.map.cellXCount
		self.map.emptyMatrix[index] = true
		self.map.currentMatrix[index] = ""
		if type(self.map.currentLockMatrixCloud[index]) == ConstData.TABLE_TYPE then
			self.map.currentLockMatrixCloud[index] = ""
		end

		index = self.X + 2 + (self.Y + 1) * self.map.cellXCount
		self.map.currentMatrix[index] = ""
		self.map.emptyMatrix[index] = true
		if type(self.map.currentLockMatrixCloud[index]) == ConstData.TABLE_TYPE then
			self.map.currentLockMatrixCloud[index] = ""
		end

		if self.map.currentLockArea[X + 2 + Y * self.map.cellXCount] then
			self.map.currentLockArea[X + 2 + Y * self.map.cellXCount] = nil
			App:applyFunc(ConstData.Locked,  "del", X + 1, Y)
		elseif self.map.currentLockArea[X + 1 + (Y + 1) * self.map.cellXCount] then
			self.map.currentLockArea[X + 1 + (Y + 1) * self.map.cellXCount] = nil
			App:applyFunc(ConstData.Locked,  "del", X, Y + 1)
		elseif self.map.currentLockArea[X + 2 + (Y + 1) * self.map.cellXCount] then
			self.map.currentLockArea[X + 2 + (Y + 1) * self.map.cellXCount] = nil
			App:applyFunc(ConstData.Locked,  "del", X + 1, Y + 1)
		end
    end

    if rightNow then
    	if type(rightNow) == "function" then
    		rightNow()
    	end
    end
	self:setNeedSortingOrder(false)
    self.destroyedTime = 0
    self.destroyed = true
	MapUpdate:addDestroyItem(self)
    self.destroyed_callback = func
    -- accommodationStatusOut
    local tp = {"treehole", "wishingwell"}
	if table.indexof(tp, self.data.ItemType) then
		App:applyFunc(ConstData.Element, "accommodationStatusOut", self)
	end
    App:applyFunc(ConstData.Element, "delStoryElement", self)
end

-- 回溯遍历
function ElementBehaviour:travArea(tempMatrix, x, y)
	-- 判断当前点在ForbiddenNodeList中与否
	if table.indexof(self.ForbiddenNodeList, x + 1 + y * self.map.cellXCount) then
		return
	end
	-- 判断当前点是否已经在其中
	if table.indexof(self.ActiveNodeList, x + 1 + y * self.map.cellXCount) then
		return
	end
	-- 判断是否在area区域中
	if not tempMatrix[x + 1 + y * self.map.cellXCount] then
		return
	end
	self.ActiveNodeList[#self.ActiveNodeList + 1] = x + 1 + y * self.map.cellXCount
	self:travArea(tempMatrix, x + 1, y)
	self:travArea(tempMatrix, x - 1, y)
	self:travArea(tempMatrix, x, y + 1)
	self:travArea(tempMatrix, x, y - 1)
end

------------------------------------- 点击CallBack方法 ---------------------------------------
function ElementBehaviour:Clicked()
	if StatusConst.Locked == self.status then
		return
	end
    if self.status == StatusConst.WaitingForExpend then
    	-- 等待能量消耗
    	self.map:TipFrameShow2(self)
    elseif self.status == StatusConst.WaitingForTime then
    	self:shake()
        -- 显示收割，类似苹果树
        self.bidCannel = true
        self.map:TipFrameShow(self)
    end
end

function ElementBehaviour:StopInteract()
	if IsNil(self.gameObject) then 
		return 
	end
	self.boxCollider2D = self.boxCollider2D or self.gameObject:GetComponent("BoxCollider2D")
	if not IsNil(self.boxCollider2D) then 
		self.boxCollider2D.enabled = false
	end
	self.polygonCollider2D = self.polygonCollider2D or self.gameObject:GetComponent(typeof(CS.UnityEngine.PolygonCollider2D))
	if not IsNil(self.polygonCollider2D) then 
		self.polygonCollider2D.enabled = false
	end

	local dialog = self.transform:Find("dialog") or self.transform:Find("dialogParent/dialogAni/dialog")
    if not IsNil(dialog) then
       dialog.gameObject:GetComponent("BoxCollider2D").enabled = false
    end
	self.stopinteracted = true
end

function ElementBehaviour:ContinueInteract()
	if IsNil(self.gameObject) then 
		return 
	end
	self.boxCollider2D = self.boxCollider2D or self.gameObject:GetComponent("BoxCollider2D")
	if not IsNil(self.boxCollider2D) then 
		self.boxCollider2D.enabled = true
	end
	self.polygonCollider2D = self.polygonCollider2D or self.gameObject:GetComponent(typeof(CS.UnityEngine.PolygonCollider2D))
	if not IsNil(self.polygonCollider2D) then 
		self.polygonCollider2D.enabled = true
	end

	local dialog = self.transform:Find("dialog") or self.transform:Find("dialogParent/dialogAni/dialog")
    if not IsNil(dialog) then
       dialog.gameObject:GetComponent("BoxCollider2D").enabled = true
    end
	self.stopinteracted = false
end

-- 提交交互
function ElementBehaviour:addInteract()
	-- 如果是Locked状态，则不添加交互
	if self.cellId == "Worker_01" then
		return
	end
	if StatusConst.Locked == self.status then
		-- 检测当前是否为Locked
		local is_lock = false
		if self.map then
			if self.map.currentLockArea[self.X + 1 + self.Y * self.map.cellXCount] then
				is_lock = true
			end
	    else
	    	return
	    end
	    if is_lock then
			return
		end
		if self.data.ItemType == "mine" or self.data.ItemType == "castlefloor" or self.data.ItemType == ConstData.STR_CASTLE then
			return
		end
	end
	--
	self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
	if IsNil(self.extDragComp) and self.cellId then
		-- 目前所有的物品都可以拖动，除了云彩内的
		if self.X then
			if self.map.currentMatrix[self.X + 1 + self.Y * self.map.cellXCount] ~= "C" then
				-- 是否为点击还是拖拽
				if self.data.IsObstacle == 1 or
						-- 剧情关卡专用 
						self.data.ItemType == "wishingwell" or
						self.data.ItemType == "excastle" or
						self.data.ItemType == "treehole" then
						-- 如果是障碍，则走OnClick!!
					BaseLogic:GetInstance():AddClick(self, nil, nil, self.map.OnClick, self)
				else
					if self.data.ItemType ~= "bubble" then
						-- 非气泡物品
						BaseLogic:GetInstance():AddDrag(self, {
			                ["begin"] = self.map.DragBegin,
			                ["moving"] = self.map.DragMoving,
			                ["ended"] = self.map.DragEnded
			            })
			        end
				end
	        end
	    else
	    	BaseLogic:GetInstance():AddDrag(self, {
                ["begin"] = self.map.DragBegin,
                ["moving"] = self.map.DragMoving,
                ["ended"] = self.map.DragEnded
            })
	    end
	    self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
	elseif IsNil(self.extDragComp) then
		BaseLogic:GetInstance():AddDrag(self, {
            ["begin"] = self.map.DragBegin,
            ["moving"] = self.map.DragMoving,
            ["ended"] = self.map.DragEnded
        })
        self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
	end

	-- 判断2x2，配置 overlay_offset
	if table.indexof(LandMarkData, self.data.ItemType) then
		if not IsNil(self.extDragComp) then
			self.extDragComp.overlay_offset = Vector3(cellWidth - 0.1, cellHeight * 2 - 0.1, 0)
		end
	end

	-- 碰撞盒
	self.GRID_INDEX_SHOW = self.GRID_INDEX_SHOW or GRID_INDEX_SHOW
	if self.GRID_INDEX_SHOW == 1 then
		local Square = self.transform:Find("Square")
		if not IsNil(Square) then
			Square.gameObject:SetActive(true)
			--
			local boxCollider2D = self.gameObject:GetComponent("BoxCollider2D")
			if not IsNil(boxCollider2D) then
				Square.transform.localScale = Vector3(boxCollider2D.size.x * 50,  boxCollider2D.size.y * 50)
				Square.transform.localPosition = Vector3(boxCollider2D.offset.x, boxCollider2D.offset.y)
			end
		end
	end

	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ADD_INTERACT, {from = self.gameObject.name, params = {element = self}})
end

-- 增加禁止拖动的方法
function ElementBehaviour:BindMove()
	if self.extDragComp then 
		self.extDragComp.isClick = true
	end
end

function ElementBehaviour:ShowSpine()
	self.spine = self.spine or self.transform:Find("spine")
	if not IsNil(self.spine) then
		BehaviourUtil.SetBehaviourEnable(self.spine.gameObject, "SpriteBehaviour", true)
		self.spine.gameObject:SetActive(true)
		-- 解决城堡等spineonly 类型物品 不播放动画的问题
		local spineOnly = App:applyFunc(ConstData.Element, "CheckSpineOnly", self.cellId)
		if spineOnly then
			self:LeaveGo(true)
		end
		self:setNeedSortingOrder(true)
	end
end

function ElementBehaviour:HideSpine()
	if not IsNil(self.spine) then
		self.spine.gameObject:SetActive(false)
		BehaviourUtil.SetBehaviourEnable(self.spine.gameObject, "SpriteBehaviour", false)
	end
end

function ElementBehaviour:ShowBeforeSpine() -- 姜英宣2022年01月28日修改，增加显示spine_before的方法，用于满足只在城堡奖励可领取时显示特效的需求
	if self.spine_before then
		self.spine_before.gameObject:SetActive(true)
	end
end

function ElementBehaviour:HideBeforeSpine() -- 姜英宣2022年01月28日修改，增加隐藏spine_before的方法，用于满足只在城堡奖励可领取时显示特效的需求
	if self.spine_before then
		self.spine_before.gameObject:SetActive(false)
	end
end

function ElementBehaviour:PlaySpine(animateName)
	if not IsNil(self.spine) then
		SpineManager.Play(self.spine.gameObject, animateName, false)
	end
end

-- 前方动画
function ElementBehaviour:BeforeSpineAnimation(animateName)
	if self.data["SpineBefore"] and not IsNil(self.spine_before) then
		self.spine_before.gameObject:SetActive(true)
	    -- 更新骨骼数据
	    local before_skeleton = self.map._luaParam:getSkeletonDataAsset(self.data["SpineBefore"])
	    SpineManager.setSkeletonData(self.spine_before.gameObject, before_skeleton)
	    -- 播放动画 默认循环
	    SpineManager.Play(self.spine_before.gameObject, animateName, true)
	    -- 配置order [Order]
		if not IsNil(self.spine) then
			local originOrder = SpineManager.getOrder(self.spine.gameObject)
			SpineManager.Order(self.spine_before.gameObject, originOrder + (self.data["Order"] or 0))
	    end
	    -- 修正位置
	    self.spine_before.localPosition = Vector3(self.data.SpineBeforeOffSet[1], self.data.SpineBeforeOffSet[2], 0)
	    if self.data.SpineBeforeScale then
	        self.spine_before.localScale = Vector3(self.data.SpineBeforeScale[1], self.ata.SpineBeforeScale[2], self.data.SpineBeforeScale[3])
	    end
	end
end

-- 获取树洞或则许愿池所需的物品
function ElementBehaviour:GetCurrentNeedCellId()
	self.Stone = self.Stone or {}
    local need_cellIds = {}
    for k,v in pairs(self.Stone) do
        if v[1] and v[2] and v[1] < v[2] then
        	need_cellIds[#need_cellIds + 1] = k
        end
    end
    return need_cellIds
end

-- FillIn
function ElementBehaviour:FillIn(cellId, isOnlyData, isShowOnly)
	-- 必须存在self.storyBannerBvr
	-- 等待60帧结束
	self.wait_fill_in = self.wait_fill_in or 0
	coroutine.start(function() 
		while not self.storyBannerBvr do
        	coroutine.waitforframes(FRAME_ONE)
        	self.wait_fill_in = self.wait_fill_in + 1
        	if self.wait_fill_in > 60 then
        		break
        	end
        end
        coroutine.waitforframes(FRAME_ONE)
		self.storyBannerBvr:FillIn(cellId, isOnlyData, isShowOnly)
	end)
end

-- 获取加速砖石数量
function ElementBehaviour:GetSpeedDiamond()
	local costTime = self.lastStr or ""
	if (IsNil(costTime) or costTime == "") then
		return
	end
	local t = string.split(costTime, "%:")
	local part1 = tonumber(t[1])
	local h = math.floor(part1 / 60)
	local m = part1 - h * 60
	local s = tonumber(t[2])
	local needSecond = h * 3600 + m * 60 + s
	self.diamond = CurrencyNeedMgr:CalculateDiamond(needSecond or 0)
	if self.diamond < 0 then
		self.diamond = 0
	end
	self:CheckSpeedDiamondChange()
	return self.diamond
end

-- 刷新砖石数量
function ElementBehaviour:CheckSpeedDiamondChange(forceRefresh)
	if (not self.diamondQuick) then
		return
	end
	if not forceRefresh then
		if (self.curDiamond == self.diamond) then return end
	end
	self.diamondQuickBtn = self.diamondQuickBtn or self.transform:Find("timer/QuickBtn")
	self.disQuickBtn = self.disQuickBtn or self.transform:Find("timer/QuickBtn/disQuickBtn")
	local coin_buff = App:applyFunc(ConstData.ActivityBuff, "GetBuffType") == "buff_coin_speed"
	if (self.diamondQuickBtn and self.diamondQuickBtn.gameObject.activeSelf) then
		if (self.curDiamond ~= self.diamond) or forceRefresh then
			-- 刷新
			self.curDiamond = self.diamond
			if self.disQuickBtn then
				self.disQuickBtn.gameObject:SetActive(coin_buff)
			end
			if coin_buff then
				if self.disQuickBtn and self.disQuickBtn.gameObject.activeSelf then
					local text = self.disQuickBtn.transform:Find("text"):GetComponent("TextMeshPro")
					if text then
						text.text = self.curDiamond
					end
					local text2 = self.diamondQuickBtn.transform:Find("tmp_text"):GetComponent("TextMeshPro")
					if (text2) then
						text2.text = self.curDiamond * (GlobalData.CoinExDiamondRatio or 5)
						text2.transform.localPosition = Vector3(1.42, 0.023, 0)
					end
					local diamond = self.diamondQuickBtn.transform:Find("diamond")
					if diamond then
						diamond.gameObject:SetActive(false)
					end 
				end
			else
				local text = self.diamondQuickBtn.transform:Find("tmp_text"):GetComponent("TextMeshPro")
				if (text) then
					text.text = self.curDiamond
					text.transform.localPosition = Vector3(1.12, 0.023, 0)
				end
				local diamond = self.diamondQuickBtn.transform:Find("diamond")
				if diamond then
					diamond.gameObject:SetActive(true)
				end 
			end
		end
	end
end

function ElementBehaviour:init(...)
	local params = {...}
	cellHeight = superMapUtils.cellHeight / 200
	cellWidth = superMapUtils.cellWidth / 200
end

function ElementBehaviour:initProp()
	-- 子对象
  	self.sprite = self.transform:Find("sprite")
  	self.spine = self.transform:Find("spine")
  	self.stars = self.transform:Find("sprite2/stars")
  	self.header = self.transform:Find("header")
  	self.sprite2 = self.transform:Find("sprite2")
  	self.dialogParent = self.transform:Find("dialogParent")
  	self.dialogAni = self.transform:Find("dialogParent/dialogAni")
  	self.dialog = self.transform:Find("dialog")
  	if IsNil(self.dialog) then
  		self.dialog = self.transform:Find("dialogParent/dialogAni/dialog")
  	end
  	self.mation = self.transform:Find("mation")
  	self.zuowu = self.transform:Find("_zuowu")
  	self.tile = self.transform:Find("tile")
  	self.signal = self.transform:Find("signal")
  	self.highLight = self.transform:Find("highLight")
  	self.time = self.transform:Find("timer")
  	self.foundation = self.transform:Find("sprite2/foundation")
  	self.clearBar = self.transform:Find("clearBar")
  	self.progressBar = self.transform:Find("clearBar/progress_bar")
  	self.progressMaskBar = self.transform:Find("clearBar/progress_mask_bar")
  	self.progressMaskSliceBar = self.transform:Find("clearBar/progress_mask_slice_bar")
  	self.spine_behide = self.transform:Find("spine_behide")
  	self.spine_before = self.transform:Find("spine_before")
  	self.spine_clone = self.transform:Find("spine(Clone)")
  	self.sprite3 = self.transform:Find("sprite2/sprite3")
  	self.hint = self.transform:Find("sprite2/hint")
  	self.hourglass = self.transform:Find("hourglass")
  	self.AdsFlower = self.transform:Find("AdsFlower")
  	self.shadow = self.transform:Find("shadow")

  	-- 之前用的变量
  	self.timer = self.time

  	if IsNil(self.mation) then
  		self.mation = self.transform:Find("_mation")
  	end
  	if not IsNil(self.dialog) then
  		self.icon = self.dialog:Find("icon")
  	end
  	if not IsNil(self.time) then
  		self.time_btn = self.time:Find("Btn")
  	end
  	if IsNil(self.sprite) and not IsNil(self.sprite2) then
  		self.sprite = self.sprite2
	end
  	-- Component
  	if self.sprite then
  		self.spriteRenderer = self.sprite:GetComponent(typeof(CS.UnityEngine.SpriteRenderer))
  		-- 之前用到的变量
  		self.spriteRender = self.spriteRenderer
  	end
end

------------------------------------- 生命周期的方法 ------------------------------------------
function ElementBehaviour:Awake()
  	self.map = App:get(ConstData.STR_MAP)
  	self.mapData = ClientData:GetInstance():MapData()
  	self.extraData = ClientData:GetInstance():ExtraData()
end

function ElementBehaviour:OnEnable()
	self.disabled = nil
end

function ElementBehaviour:updateBubbleTime(deltaTime)
	if self.addBubbleTime then
		if self.addBubbleTime <= 0 then
			self:addBubble()
			self.addBubbleTime = nil
			MapUpdate:removeBubbleListUpdate(self)
		else
			self.addBubbleTime = self.addBubbleTime - deltaTime
		end
	end
end

function ElementBehaviour:upateNeedItemTime(deltaTime)
	if self.needItem then
		if self.needItemTime > 0 or self.addPopup then
			self.needItemTime = self.needItemTime - deltaTime
		else
			if self.status == StatusConst.Common then
				self.needItem = false
				MapUpdate:removeNeedItem(self)
				self.needItemTime = 0
				local needItems = App:applyFunc(ConstData.Element, "GetNeedItems", true)
				if table.indexof(needItems, self.cellId) and self.status == StatusConst.Common then
					-- 高级别
					App:applyFunc(ConstData.Status, "SpecialStatus", self, true)
					-- 增加箭头
					self:createArrowInStory()
					App:applyFunc(ConstData.Element, "addStoryElement", self)
				else
					self:cancelArrowInStory()
					App:applyFunc(ConstData.Status, "UnSpecialStatus", self, true)
				end
			end
		end
	end
end

function ElementBehaviour:updateAddPopUpItem(deltaTime)
	if self.addPopup then
		self.popup_during = self.popup_during - deltaTime
		if self.popup_during < 0 then
			self.addPopup = nil
			MapUpdate:removePopupItem(self)
			self.popup_during = 0
			if not self.lock then
				local StoryBanner = self.map._luaParam:getGameObject("StoryBanner")
				if not IsNil(StoryBanner) and not self.storyBannerBvr then
					local position = self.gameObject.transform.position -- + Vector3(0, cellHeight, 0)
					local StoryBannerObj = UGameObject.Instantiate(StoryBanner)
					-- 配置 StoryBannerBehaviour
					self.storyBannerBvr = BehaviourUtil.AddBehaviour(StoryBannerObj, StoryBannerBehaviour, self)
					local pos = position
					if ElementInfoData[self.cellId] then
						pos = pos + (ElementInfoData[self.cellId]["bannerPos"] or Vector3.zero)
					end
					self.storyBannerBvr:Init(self, pos)
					-- 记录到Stone
					if not self.storyBannerBvr.__hide then
						App:applyFunc(ConstData.Element, "InContainer", self)
						-- 需要刷新 所有的Element
						App:applyFunc(ConstData.Element, "StoryUpdate")
					end
				end
			end
		end
	end
end

function ElementBehaviour:updateDestroyTime(deltaTime)
	if self.destroyed then
		-- 0.5s后删除
		self.destroyedTime = self.destroyedTime or 0
		self.destroyedTime = self.destroyedTime + deltaTime
		if self.destroyedTime > 0.33 then
			self.destroyedTime = 0
			if self.destroyed_callback then
				self.destroyed_callback()
				self.destroyed_callback = nil
			end
			MapUpdate:removeDestroyPopupItem(self)
			self:Cycler()
		end
	end
end

function ElementBehaviour:updateMetionTime(deltaTime)
	if self.metion_hide_time then
		self.metion_hide_time = self.metion_hide_time - deltaTime
		if self.metion_hide_time < 0 then
			self.metion_hide_time = nil
		end
	end

	if self.metion_show_time then
		self.metion_show_time = self.metion_show_time - deltaTime
		if self.metion_show_time < 0 then
			self.metion_show_time = nil
		end
	end

	if self.metion_show_time == nil and self.metion_hide_time == nil then 
		MapUpdate:removeMetionTimeUpdateList(self)
	end
end

function ElementBehaviour:setNeedSortingOrder(value)
	self.needSortingOrder = value
	if value then 
		MapUpdate:addNeedSortingOrderUpdate(self)
	else
		MapUpdate:removeNeedSortingOrderUpdate(self)
	end
end

function ElementBehaviour:updateSortingOrder(deltaTime)
	if self.needSortingOrder and self.gameObject then
		App:applyFunc(ConstData.MapCore, "sortingOrder", self)
		-- 更新z
		local _position = self.gameObject.transform.position
		local _index = self.X + 1 + self.Y * self.map.cellXCount
		local add = 0.01 / _index
		self.gameObject.transform.position = Vector3(_position.x, _position.y, -0.005 + add)
		self:setNeedSortingOrder(false)
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.SORT_ORDER, {from = "NeedSortingOrder", param = self})
	end	
end

function ElementBehaviour:setCostTime(value)
	self.cost_time = value
	if value == nil then 
		MapUpdate:removeCostTimeUpdate(self)
	else
		MapUpdate:addCostTimeUpdate(self)
	end
end

function ElementBehaviour:updateLongPressTime(deltaTime)
	if not self.longPressTime then
		self.longPressTime = 0
	end
	self.longPressTime = self.longPressTime + deltaTime
	if self.longPressTime > 0.33 then
		MapUpdate:removeLongPressItemList(self)
		if self:TouchDrag() then
			self.longPressState = MergeChainUtil:show(self)
		end
	end
end

function ElementBehaviour:updateCostTime(deltaTime)
	local is_cost_time_activiy = false
	if self.cost_time and self.cost_time > 0 then
		--- ******非常重要，逻辑正确，不能删除
		-- 开始计时	
		if not self.cost_time_only then
			if not self.quickBuilding then
				self.cost_time = self.cost_time - deltaTime
				is_cost_time_activiy = true
			end
		end
		if self.needShowAds then
			self:ShowAdsState()
		end

		if self.cost_time < GlobalData.AdsPlayLeastTime and self.adsFlowerShow then 
			self:HiedeAdsState()
		end
	end
	--- 上面减少过时间，所以没有问题 by tomyuan
	if is_cost_time_activiy and self.cost_time then
		if self.cost_time <= 0 then
			self:setCostTime(nil)
			self.ended_time = nil
			self.diamond = 0
			if self.status ~= StatusConst.WaitingForDecorateProp then 
				App:applyFunc(ConstData.Status, ConstData.TransferStatus, self)
			end
			if ConstData[self.data.ItemType] == 2 or ConstData.STR_CASTLE == self.data.ItemType then 
				-- building
				self:buildFinish(true)
			end
		else
			local tm = self.cost_time
			local min = math.floor(tm * 0.01667)
			local second = math.floor(tm - min * 60)
			if self.old_min ~= min or self.old_second ~= second then
				self.old_min = min
				self.old_second = second
				local str = string.format("%02d:%02d", min, second)
				if self.lastStr ~= str then
					self.lastStr = str
					App:applyFunc(ConstData.Status, "Update", self, self.lastStr)
				end
				-- 获取消耗的砖石
				if (self.cost_time > GlobalData.FreeTime and self.diamondQuick) then
					self:GetSpeedDiamond()
				else
					self.diamond = 0
				end
				if not self.cost_time_only then
					if not self.quickBuilding then 
						App:applyFunc(ConstData.Status, "Update", self, self.lastStr)
					end
				end
			end
		end
	end
end

--- func 更新timer 
---@param str 显示的字符串,时间
function ElementBehaviour:updateTimeView(str)
	if not self.timer then 
		return
	end

    local t = string.split(str, "%:")
    local part1 = tonumber(t[1])
    local h = math.floor(part1 / 60)
    local m = part1 - h * 60
    m = m < 0 and 0 or m
    local s = tonumber(t[2])
    if s < 0 then
        s = 60 + s
        if m > 0 then
            m = m - 1
            if m == 0 and h > 0 then
                h = h - 1
            end
        else
            if h > 0 then
                h = h - 1
                m = 59
            end
        end
    end
	local h1 = math.min(math.floor(h/10), 9) 
	local h2 = h%10
	local m1 = math.floor(m/10)
	local m2 = m%10
	local s1 = math.floor(s/10)
	local s2 = s%10

    -- TODO
    self.h1:GetComponent(ConstData.SpriteRenderer).sprite = self.timerLuaParam:getSprite(tostring(h1))
    self.h2:GetComponent(ConstData.SpriteRenderer).sprite = self.timerLuaParam:getSprite(tostring(h2))
    self.m1:GetComponent(ConstData.SpriteRenderer).sprite = self.timerLuaParam:getSprite(tostring(m1))
    self.m2:GetComponent(ConstData.SpriteRenderer).sprite = self.timerLuaParam:getSprite(tostring(m2))
    self.s1:GetComponent(ConstData.SpriteRenderer).sprite = self.timerLuaParam:getSprite(tostring(s1))
    self.s2:GetComponent(ConstData.SpriteRenderer).sprite = self.timerLuaParam:getSprite(tostring(s2))
end


function ElementBehaviour:setSpriteEnable(value)
	self.showSpriteEnable = value
	if value then 
		MapUpdate:addSpriteEnableUpdate(self)
	else
		MapUpdate:removeSpriteEnableUpdate(self)
	end
end

function ElementBehaviour:updateSpriteEnable()
	if self.showSpriteEnable then
		self:setSpriteEnable(false)
		self:showSpriteRenderer()
	end	
end

function ElementBehaviour:Update(deltaTime)
	-- 如果对象为空则返回
	if IgnoreUpdate then 
		return
	end
	
	-- if IsNil(self.gameObject) then
	-- 	return
	-- end
	-- if self.addBubbleTime then
	-- 	if self.addBubbleTime <= 0 then
	-- 		self:addBubble()
	-- 		self.addBubbleTime = nil
	-- 	end
	-- 	if self.addBubbleTime then
	-- 		self.addBubbleTime = self.addBubbleTime - deltaTime
	-- 	end
	-- end
	
	-- if self.needItem then
	-- 	if self.needItemTime > 0 or self.addPopup then
	-- 		self.needItemTime = self.needItemTime - deltaTime
	-- 	else
	-- 		if self.status == StatusConst.Common then
	-- 			self.needItem = false
	-- 			self.needItemTime = 0
	-- 			local needItems = App:applyFunc(ConstData.Element, "GetNeedItems", true)
	-- 			if table.indexof(needItems, self.cellId) and self.status == StatusConst.Common then
	-- 				-- 高级别
	-- 				App:applyFunc(ConstData.Status, "SpecialStatus", self, true)
	-- 				-- 增加箭头
	-- 				self:createArrowInStory()
	-- 				App:applyFunc(ConstData.Element, "addStoryElement", self)
	-- 			else
	-- 				self:cancelArrowInStory()
	-- 				App:applyFunc(ConstData.Status, "UnSpecialStatus", self, true)
	-- 			end
	-- 		end
	-- 	end
	-- end
	-- if self.addPopup then
	-- 	self.popup_during = self.popup_during - deltaTime
	-- 	if self.popup_during < 0 then
	-- 		self.addPopup = nil
	-- 		self.popup_during = 0
	-- 		if not self.lock then
	-- 			local StoryBanner = self.map._luaParam:getGameObject("StoryBanner")
	-- 			if not IsNil(StoryBanner) then
	-- 				local position = self.gameObject.transform.position -- + Vector3(0, cellHeight, 0)
	-- 				local StoryBannerObj = UGameObject.Instantiate(StoryBanner)
	-- 				-- 配置 StoryBannerBehaviour
	-- 				self.storyBannerBvr = BehaviourUtil.AddBehaviour(StoryBannerObj, StoryBannerBehaviour, self)
	-- 				local pos = position
	-- 				if ElementInfoData[self.cellId] then
	-- 					pos = pos + (ElementInfoData[self.cellId]["bannerPos"] or Vector3.zero)
	-- 				end
	-- 				self.storyBannerBvr:Init(self, pos)
	-- 				-- 记录到Stone
	-- 				if not self.storyBannerBvr.__hide then
	-- 					App:applyFunc(ConstData.Element, "InContainer", self)
	-- 					-- 需要刷新 所有的Element
	-- 					App:applyFunc(ConstData.Element, "StoryUpdate")
	-- 				end
	-- 			end
	-- 		end
	-- 	end
	-- end
	-- if self.destroyed then
	-- 	-- 0.5s后删除
	-- 	self.destroyedTime = self.destroyedTime or 0
	-- 	self.destroyedTime = self.destroyedTime + deltaTime
	-- 	if self.destroyedTime > 0.33 then
	-- 		self.destroyedTime = 0
	-- 		if self.destroyed_callback then
	-- 			self.destroyed_callback()
	-- 			self.destroyed_callback = nil
	-- 		end
	-- 		self:Cycler()
	-- 		return
	-- 	end
	-- end

	-- --状态处理
	-- if self.metion_hide_time then
	-- 	self.metion_hide_time = self.metion_hide_time - deltaTime
	-- 	if self.metion_hide_time < 0 then
	-- 		self.metion_hide_time = nil
	-- 	end
	-- end

	-- if self.metion_show_time then
	-- 	self.metion_show_time = self.metion_show_time - deltaTime
	-- 	if self.metion_show_time < 0 then
	-- 		self.metion_show_time = nil
	-- 	end
	-- end

	-- if self.needSortingOrder then
	-- 	App:applyFunc(ConstData.MapCore, "sortingOrder", self)
	-- 	-- 更新z
	-- 	local _position = self.gameObject.transform.position
	-- 	local _index = self.X + 1 + self.Y * self.map.cellXCount
	-- 	local add = 0.01 / _index
	-- 	self.gameObject.transform.position = Vector3(_position.x, _position.y, -0.005 + add)
	-- 	self.needSortingOrder = false
	-- 	App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.SORT_ORDER, {from = "NeedSortingOrder", param = self})
	-- end
	
	-- if self.interactTime then
    --     self.interactTime = self.interactTime + deltaTime
    -- end

    -- local is_cost_time_activiy = false
	-- if self.cost_time and self.cost_time > 0 then
	-- 	--- ******非常重要，逻辑正确，不能删除
	-- 	-- 开始计时	
	-- 	if not self.cost_time_only then
	-- 		if not self.quickBuilding then
	-- 			self.cost_time = self.cost_time - deltaTime
	-- 			is_cost_time_activiy = true
	-- 		end
	-- 	end
	-- 	if self.needShowAds then
	-- 		self:ShowAdsState()
	-- 	end

	-- 	if self.cost_time < GlobalData.AdsPlayLeastTime and self.adsFlowerShow then 
	-- 		self:HiedeAdsState()
	-- 	end
	-- end
	-- --- 上面减少过时间，所以没有问题 by tomyuan
	-- if is_cost_time_activiy and self.cost_time then
	-- 	if self.cost_time <= 0 then
	-- 		self.cost_time = nil
	-- 		self.ended_time = nil
	-- 		self.diamond = 0
	-- 		if self.status ~= StatusConst.WaitingForDecorateProp then 
	-- 			App:applyFunc(ConstData.Status, ConstData.TransferStatus, self)
	-- 		end
	-- 		if ConstData[self.data.ItemType] == 2 then 
	-- 			-- building
	-- 			self:buildFinish(true)
	-- 		end
	-- 	else
	-- 		local tm = self.cost_time
	-- 		local min = math.floor(tm * 0.01667)
	-- 		local second = math.floor(tm - min * 60)
	-- 		if self.old_min ~= min or self.old_second ~= second then
	-- 			self.old_min = min
	-- 			self.old_second = second
	-- 			local str = string.format("%02d:%02d", min, second)
	-- 			if self.lastStr ~= str then
	-- 				self.lastStr = str
	-- 				App:applyFunc(ConstData.Status, "Update", self, self.lastStr)
	-- 			end
	-- 			-- 获取消耗的砖石
	-- 			if (self.cost_time > GlobalData.FreeTime and self.diamondQuick) then
	-- 				self:GetSpeedDiamond()
	-- 			else
	-- 				self.diamond = 0
	-- 			end
	-- 			if not self.cost_time_only then
	-- 				if not self.quickBuilding then 
	-- 					App:applyFunc(ConstData.Status, "Update", self, self.lastStr)
	-- 				end
	-- 			end
	-- 		end
	-- 	end
	-- end
	--
	-- if self.showSpriteEnable then
	-- 	self.showSpriteEnable = nil
	-- 	self:showSpriteRenderer()
	-- end
	-- self:SetXY()
end


function ElementBehaviour:Start()

end

function ElementBehaviour:OnDisable()
	self.disabled = true
end

function ElementBehaviour:OnDestroy()
	-- App:applyFunc(ConstData.Time, "removeUpdate", self)
end

------------------------------------- 外部调用方法 ------------------------------------------
-- 开启移动中心
function ElementBehaviour:MoveToCenterGird(p)
	self.isMovingCenter = true

	if self.eleIsMoving then 
		return
	end
	self.justStop = false
	local spine_only_element = false
	-- 解决SpineOnly的物品合并之前没有向中心聚拢的问题
	if self.extraData[self.cellId] then
        if self.extraData[self.cellId]['SpineOnly'] then
            spine_only_element = true
        end
    end
    local moveObj = nil
    -- 如果是SpineOnly类型的物品则移动spine，否则移动sprite, 修改方式把下面的self.sprite换成moveObj
    if spine_only_element and not IsNil(self.spine) then
    	moveObj = self.spine.gameObject
    elseif not IsNil(self.sprite) then
    	moveObj = self.sprite.gameObject
    end

    if not IsNil(moveObj) then
    	if self.near_aid then
			AnimateTween.cancel(self.near_aid)
			self.near_aid = nil
		end
		self.oldPosition = moveObj.transform.position
		self.oldLocalPosition = moveObj.transform.localPosition
		local currentPoint = self.oldPosition
		-- 得到单位向量
		p = p + moveObj.transform.localPosition
		local vec3 = Vector3(p.x - currentPoint.x, p.y - currentPoint.y, 0)
		local unit_vec = Vector3.zero
		if vec3.magnitude > 0.2 then
			unit_vec = vec3 / vec3.magnitude * 0.2
			local newPosition = Vector3(self.oldPosition.x + unit_vec.x, self.oldPosition.y + unit_vec.y, self.sprite.transform.position.z)
			-- 得到目的点
			self.near_aid = AnimateTween.valueTo(moveObj, 0, 1, 0.33, function(tm) 
				if not IsNil(moveObj) then
					moveObj.transform.position = Vector3(self.oldPosition.x + (newPosition.x - self.oldPosition.x) * tm,
						self.oldPosition.y + (newPosition.y - self.oldPosition.y) * tm, 0)
				else
					if self.near_aid then
						AnimateTween.cancel(self.near_aid)
						self.near_aid = nil
					end
				end
			end)
			if self.near_aid then
				self.near_aid:setLoopPingPong()
				self.near_aid:setEase(LeanTweenType.easeInCubic)
			end
		end
	end
end

-- 关闭移动中心
function ElementBehaviour:StopToCenterGird()
	if self.near_aid then
		AnimateTween.cancel(self.near_aid)
		self.near_aid = nil
	end
	self.isMovingCenter = false
end

function ElementBehaviour:ResetPosition()
	-- 重制归位
	if self.oldLocalPosition then
		local spine_only_element = false
		-- 解决SpineOnly的物品合并之前没有向中心聚拢的问题
		if self.extraData[self.cellId] then
	        if self.extraData[self.cellId]['SpineOnly'] then
	            spine_only_element = true
	       end
    	end
    	if spine_only_element and not IsNil(self.spine) then
    		self.spine.gameObject.transform.localPosition = self.oldLocalPosition
    	elseif not IsNil(self.sprite) then
			self.sprite.transform.localPosition = self.oldLocalPosition
    	end
	end
end

-- 判断是否是最高等级
function ElementBehaviour:isHighest()
	-- self.scene.mapData
	-- 如果有特殊的单独处理
	if self.cellId and self.mapData[self.cellId] then
		return (not self.mapData[self.cellId]['ParentID']) or tostring(self.mapData[self.cellId]['ParentID']) == '' or tostring(self.mapData[self.cellId]['ParentID']) == '0'
	end
end

-- 点击次高级的建筑合入城堡
function ElementBehaviour:MergeIntoCastleFloor()
	local mergeTable = App:applyFunc(ConstData.Warehouse,  "GetAllHeightestBuilding")
	if (mergeTable[self.gameObject.name]) then -- 存在城堡
		local currentTiled = App:applyFunc(ConstData.Warehouse,  "GetElementByName", mergeTable[self.gameObject.name])
		if (not currentTiled) then
			self:cancelArrow()
			return 
		end -- 没有找到大城堡
		if (self.status ~= StatusConst.Common) then return end -- 自身没有修建结束
		if (self.mergeInto) then return end
		if self.spriteRenderer then
			self.spriteRenderer.sortingOrder = 9999
		end
		self.mergeInto = true
		-- 相机移动加入队列
		App:applyFunc(ConstData.Cache, ConstData.Insert, CacheCfg.ActionType.CameraMove, {
			MethodName = "move",
			Position = currentTiled.transform.position
		})
		local currentPosition = self.transform.position
		local dstPosition = currentTiled.transform.position
		self:BezierMove(currentPosition, dstPosition, function()
			self.mergeInto = false
			App:applyFunc(ConstData.Warehouse, "refreshFoundation", currentTiled, self, 1)
	        if FakeCorouteInst then
	            FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 2, function() 
	                local floors = App:applyFunc(ConstData.Element, "Floors")
	                for k, v in pairs(floors) do
	                    App:applyFunc(ConstData.Warehouse, "floorCheck", v)
	                end
	            end)
	        end
		end, function()
			
		end)
	end
end

-- 点击飞入制定的element，并执行func，目前给Story使用
function ElementBehaviour:MergeIntoElementAndCallback(element, callback)
	if not element then
		return
	end
	if self.spriteRenderer then
		self.spriteRenderer.sortingOrder = 9999
	end
	self.mergeInto = true
	App:applyFunc(ConstData.Camera,  "move", element.transform.position)
	local currentPosition = self.transform.position
	local dstPosition = element.transform.position + Vector3(0, cellHeight, 0)
	self:BezierMove(currentPosition, dstPosition, function()
		self.mergeInto = false
		if callback then
			callback()
		end
	end, function()
		
	end)
end

-- 点击次高级的建筑合入城堡
function ElementBehaviour:DecorateNpc(npcName, animateName)
	local map = App:applyFunc(ConstData.MapCore, "getMap")
	local npc = nil

	for k, v in pairs(map.npcs) do
		if (k == npcName) then 
			npc = map.npcs[k]
		end
	end

	local mergeTable = App:applyFunc(ConstData.Warehouse,  "GetAllHeightestBuilding")
	debug.log(npcName, animateName)

	if (npc) then -- 存在npc
		if (npc.gameObject.activeSelf) then 
			local currentTiled = npc
			if (self.mergeInto) then return end
			if self.spriteRenderer then
				self.spriteRenderer.sortingOrder = 9999
			end
			self.mergeInto = true
			local currentPosition = self.transform.position
			local dstPosition = currentTiled.transform.position
			App:applyFunc(ConstData.Camera, "move", dstPosition)
			self:BezierMove(currentPosition, dstPosition + Vector3(0, 0.65, 0), function()
				self.mergeInto = nil
				self:DestroyMySelfImmediate() -- 播放Spine的主体有问题
				if not IsNil(npc.spine) then
					SpineManager.RegisterAnimationCallback(npc.spine.gameObject, function()
						SpineManager.UnRegisterAnimationCallback(npc.spine.gameObject) -- 这里先记录一个问题，播放完后，npc应该是可以随机动作的
						local skinData = App:applyFunc(ConstData.SkinSystem, "GetSkinAssetName", npcName)
						if skinData then 
							npc:SpineExchange(skinData.Spine, skinData.Skin, skinData.SpineAct)
						end
					end, _)
					SpineManager.Play(npc.spine.gameObject, animateName, false)
				end
			end, function()
				
			end, 1)
		else
			App:applyFunc(ConstData.Hint, "Arrow45", "Point" .. tostring(npcName), nil, npc.transform.position, false)
			App:applyFunc(ConstData.Hint, "Text", LangData["100272"][LANG])
			App:applyFunc(ConstData.Camera,  "move", npc.transform.position)
		end
	else
		local LangID = tostring(self.map.mapData[npcName]['Lang'])
        local npc_name = LangData[LangID][LANG]
        App:applyFunc(ConstData.Hint, "Text", LangData["700009"][LANG] .. tostring(npc_name))
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ATLAS_NPC_POINT, {from = "decorate-click", params = npcName})
	end
end

-- func 当拿起一个可以投入城堡的建筑时,城堡需要发光闪烁
function ElementBehaviour:onCastleStarFlicker()
	if self.flicker or self.data.ItemType ~= ConstData.STR_CASTLE then
		return
	end
	local starBg = self.stars.transform:Find("star_group").transform:GetChild(self.castleLevel - 1)
	self:addOrReduceCastleStarlOrder(true)
	AnimateTween.cancel(self.castleAid, false)
	self.castleAid = AnimateTween.scaleTo(starBg.gameObject, Vector3.one * 0.9, 0.2)
	SpineManager.Play(self.spine.gameObject, "flash", true)
	self.flicker = true
end

-- func 当放下一个可以投入城堡的建筑时,城堡关闭发光闪烁
function ElementBehaviour:offCastleStarFlicker()
	if not self.flicker or self.data.ItemType ~= ConstData.STR_CASTLE then
		return
	end
	self:addOrReduceCastleStarlOrder(false)
	self.castleLevel = self.castleLevel > 5 and 5 or self.castleLevel
	local starBg = self.stars.transform:Find("star_group").transform:GetChild(self.castleLevel - 1)
	AnimateTween.cancel(self.castleAid, false)
	self.castleAid = AnimateTween.scaleTo(starBg.gameObject, Vector3.one * 0.42, 0.1)
	AnimateTween.setCallBack(self.castleAid, function()
		starBg.transform.localScale = Vector3.one * 0.42
	end)
	SpineManager.Play(self.spine.gameObject, "animation", true)
	self.flicker = false
end

-- func 增加或则减少城堡星星等级
function ElementBehaviour:addOrReduceCastleStarlOrder(isAdd)
	local order = isAdd and 10 or -10
	self.castleLevel = self.castleLevel > 5 and 5 or self.castleLevel
	local starBg = self.stars.transform:Find("star_group").transform:GetChild(self.castleLevel - 1)
	local starBgSp = starBg.gameObject:GetComponent(typeof(SpriteRenderer))
	starBgSp.sortingOrder = starBgSp.sortingOrder + order
	local starSp = starBg.transform:Find("star" .. tostring(self.castleLevel)).gameObject:GetComponent(typeof(SpriteRenderer))
	starSp.sortingOrder = starSp.sortingOrder + order
	if self.castleLevel < 5 then
		local nextStarBg = self.stars.transform:Find("star_group").transform:GetChild(self.castleLevel)
		local mask = nextStarBg.transform:Find("star" .. tostring(self.castleLevel + 1) .. "/Mask"):GetComponent("SpriteMask")
		if isAdd then
			mask.frontSortingOrder = starSp.sortingOrder - order + 2
			mask.backSortingOrder = starSp.sortingOrder - order - 2
		end
		mask.isCustomRangeActive = isAdd
	end
end

-- func 物品放入城堡效果,并销毁放入的物品
function ElementBehaviour:castleEatFoodEffect(element, score)
	SpineManager.Play(self.spine.gameObject, "put", false)
	SpineManager.RegisterAnimationCallback(self.spine.gameObject, function(obj, name, index)
		if not IsNull(self.spine.gameObject) and name == "put" then
			SpineManager.Play(self.spine.gameObject, "animation", true)
		end
 	end)
	local putEffectSpine = self.transform:Find("spine_put_effect")
	local order = SpineManager.getOrder(self.spine.gameObject)
	SpineManager.Order(putEffectSpine.gameObject, order + 3)
	App:applyFunc(ConstData.MapCore, ConstData.addSortingOrder, element, nil, true)
	local newPos = self.transform.position + Vector3(0, 0.66, 0)
	local aid = AnimateTween.moveToV3(element.gameObject, newPos, 0.2)
	AnimateTween.setCallBack(aid, function()
		newPos = newPos + Vector3(0, -1.2, 0)
		AnimateTween.moveToV3(element.gameObject, newPos, 0.2)
		local scaleAid = AnimateTween.scaleTo(element.gameObject, Vector3.zero, 0.2)
		scaleAid:setEase(LeanTweenType.easeInBack)
		AnimateTween.setCallBack(scaleAid, function()
			putEffectSpine.transform.position = newPos + Vector3(0, -1, 0)
			if not putEffectSpine.gameObject.activeSelf then
				putEffectSpine.gameObject:SetActive(true)
			end
			SpineManager.Play(putEffectSpine.gameObject, "put", false)
			App:applyFunc(ConstData.Hint, "showCastleAddExp", self, score)
			element:DestroyMySelf()
		end)
	end)
end

--- func 检查城堡是否满级
function ElementBehaviour:checkCastleIsFullLevel()
	local castle_level = self.castleLevel
	if castle_level < 5 then
		return false
	end
	local level = castle_level - 1
	level = level < 1 and 1 or level
	local castle_score = self.castle_score or 0
	local need_score = CastleData[self.cellId][level].CostScore
	return castle_score >= need_score
end

-- 房子建造成功
function ElementBehaviour:buildFinish(realBuild)
	self:createArrow()
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
	if (realBuild and (lvType == ConstData.STR_MASTER)) then 
		App:applyFunc(ConstData.Festival,  "NortifyMainEvent", {eventName = "BuildFinish", cellId = self.cellId, itemType = self.data.ItemType, position = self.transform.position})
    	App:applyFunc(ConstData.BattlePass, "NortifyMainEvent", {eventName = "build", cellId = self.cellId, itemType = self.data.ItemType, position = self.transform.position}) -- 倍数
		-- 新手 & 每日任务 任务进度
		App:applyFunc(ConstData.NewbiesAndDailyTask, "onceCompleteBuildingTask", self)
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.SHOW_ELEMENT, {from = "Show-Element-buildFinish", element = self.cellId})
	end

	if realBuild then
		local data = {
			label_id = self.cellId,
			type = self.data.ItemType,
			activity_id = "",
			level = UserData:GetInstance():level(),
		}
		if lvType == ConstData.ACTIVITY_LEVEL then
			data.activity_id = App:applyFunc(ConstData.ActivityIsLand, "GetCurrentActivityIsLand") or ""
		end
		DC:dcWbBI(DCData.castle_change, data)
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.BUILD_ELEMENT, {from = self.gameObject.name, params = {element = self, realBuild = realBuild}})
	end

	if self.cost_time and self.cost_time >= GlobalData.AdsPlayLeastTime then
	else
		self.needShowAds = false
		self:HiedeAdsState()
	end
	
	if self.data then
		if (self.data.ItemType == ConstData.STR_CASTLE) then
			if (self.status == StatusConst.FinishForBuild) then
			    if (not IsNil(self.stars)) and (not self.stars.gameObject.activeSelf) then
			        self.stars.gameObject:SetActive(true)
			        self:setNeedSortingOrder(true)
    				
			        -- 城堡建造完成默认为一星
			        self.castleLevel = 1
				    self.castle_score = CastleData[self.cellId][self.castleLevel].CostScore or 0
			        App:applyFunc(ConstData.Element, "updateCastleStar", self)
			        App:applyFunc(ConstData.StoryCastle, "RecordACastleInfo", self.cellId)
			    end
			end
		end
	end

	-- 创建完成根据条件出现复制品
	if realBuild and self.data.ItemType == "building" then
		App:applyFunc(ConstData.Element, "ReproductionsAppear", self)
		App:applyFunc(ConstData.Element, "OnBuildFinish", self)
	end

	if (self.data.CopyFloat == 2 and realBuild and self.data.ItemType == "building") then 
		App:applyFunc(ConstData.CopyElementBuy, "CreateCopyElement", self, true)
	end
end

function ElementBehaviour:CheckCastleBuildFinish()
	if self.data and self.data.ItemType == ConstData.STR_CASTLE then
		if not IsNil(self.stars) and self.stars.gameObject.activeSelf then
			return true
		else
			return false
		end
	end
	return false
end

function ElementBehaviour:createArrow()
	if not self.data then
		return
	end
	local heightest = {
		["Building01_07"] = "CastleFloor01_01", 
		["Building02_08"] = "CastleFloor02_01", 
		["Building03_08"] = "CastleFloor03_01", 
		["Building04_08"] = "CastleFloor04_01",
		["Building05_09"] = "CastleFloor05_01",
		["Building06_09"] = "CastleFloor06_01",
		["Building07_09"] = "CastleFloor07_01",
		["Building08_09"] = "CastleFloor08_01",
		["Building09_10"] = "CastleFloor09_01",
		["Building10_10"] = "CastleFloor10_01",
		["Building11_10"] = "CastleFloor11_01",
		["Building12_11"] = "CastleFloor12_01",
		["Building13_12"] = "CastleFloor13_01",

	}
	-- local heightestBuilding = App:applyFunc(ConstData.Warehouse,  "CheckHeightestName")
	-- 如果建造的是次顶级建筑，则判断城堡是否存在，如果存在则让次顶级建筑缩放
	if (heightest[self.cellId]) and (self.status == StatusConst.Common)then 
		if (App:applyFunc(ConstData.Warehouse,  "GetElementByCellId", heightest[self.cellId])) then
			if self.header and self.data.ItemType == "castlefloor" then
				self.header.localPosition = Vector3(0, 1.4, 0)
			end
			if not IsNil(self.gameObject) then
				App:applyFunc(ConstData.Hint, "ArrowLonglive", self.gameObject.name .. "_Arrow", self.header)
			end
			-- 次顶级建筑需要放大缩小
			self:SpriteLoopPlay()
		end
	end
	-- 如果当前是城堡，则判断次顶级建筑是否在场景存在，如果存在，则让其缩放
	if (self.data.ItemType == "castlefloor") then
		local reverse_heightest = {}
		for k,v in pairs(heightest) do
			reverse_heightest[v] = k
		end
		if (reverse_heightest[self.cellId]) then
			-- 获取所有的次建筑
			local hopeElements = App:applyFunc(ConstData.Warehouse,  "GetElementsByCellId", reverse_heightest[self.cellId])
			if (hopeElements) then
				for i=1, #hopeElements do
					if (hopeElements[i]:GetBuildFineshStatus()) then
						hopeElements[i]:SpriteLoopPlay()
					end
				end
			end
		end
	end
end

--- func 在剧情关卡内创建箭头指示
function ElementBehaviour:createArrowInStory(offY)
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
	if lvType == ConstData.STORY_LEVEL then
		if offY then
			offY = offY - 0.76
		else
			offY = 0.64    -- offY 默认为1.4  默认高度为0.76
			if ElementInfoData[self.cellId] and ElementInfoData[self.cellId].headerOffSetY then
				offY = ElementInfoData[self.cellId].headerOffSetY.y
			end	
		end
		if not IsNil(self.gameObject) then
			App:applyFunc(ConstData.Hint, "ArrowLonglive", self.gameObject.name .. "_Arrow_Stroy", self.header, offY)
		end
	end
end

function ElementBehaviour:cancelArrowInStory()
	local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
	if lvType == ConstData.STORY_LEVEL then
		if not IsNil(self.gameObject) then
			local value = table.concat({self.gameObject.name, "_Arrow_Stroy"})
			App:applyFunc(ConstData.Hint, "CancelArrowLongLive", value)
		end
	end
end

function ElementBehaviour:cancelArrow()
	-- 连接字符串
	if not IsNil(self.gameObject) then
		local value = table.concat({self.gameObject.name, "_Arrow"})
		App:applyFunc(ConstData.Hint, "CancelArrowLongLive", value)
	end
end

-- 物体循环缩放
function ElementBehaviour:SpriteLoopPlay(scaleFactor)
	if not self.sprite then
		return
	end
	scaleFactor = scaleFactor or 1.1
	self.HighLighting = false
	local oldScale = Vector3.one
	local newScale = oldScale * scaleFactor
	local gameObject = self.sprite.gameObject
	local tr = self.sprite
	local aid = AnimateTween.valueTo(gameObject, 0, 1, 0.6, function(tm) 
		tr.localScale = oldScale + (newScale - oldScale) * tm
	end)
	if (aid) then 
		aid:setLoopPingPong()
	end
	self:HighLight()
end

function ElementBehaviour:StopSpriteLoopPlay()
	if not self.sprite then
		return
	end
	local gameObject = self.sprite.gameObject
	self:StopLight()
	AnimateTween.cancelAllObject(gameObject, false)
	self.sprite.localScale = Vector3.one
	self.HighLighting = false
	ShaderController.lightingValue(gameObject, 1)
end

function ElementBehaviour:CreateDecorateProp()
	local propGroup = self.map.activityProp[self.data.ItemType] or {}
	local mineMsg = propGroup[self.cellId] or {}
	App:applyFunc(ConstData.Status, ConstData.TransferStatus, self)
	if not mineMsg["AwardId"] then 
		if (not mineMsg["CreateProp"]) then 
			return 
		end
		App:applyFunc(ConstData.Element, "generateObjectByOutput", self, {mineMsg["CreateProp"]}, function(isFinish) end, true)
	else
		local cellIDS = App:applyFunc(ConstData.Award, "awardDetail", mineMsg["AwardId"]) -- 更换奖励
		App:applyFunc(ConstData.Element, "generateObjectByOutput", self, cellIDS, function(isFinish) end, true)
	end
end

function ElementBehaviour:ShowPointer()
	local choose_ele = App:applyFunc(ConstData.Popup, "hasElement")
	if not IsNil(choose_ele) and choose_ele == self then
		return
	end
	if (self.tag == "Pointer" or self.tag == "Food_Cook_Teach") then
		if FakeCorouteInst then
	        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
				if (self.status == StatusConst.WaitingForObstacleHag or
					self.status == StatusConst.FinishForObstacleHagFinish or
					self.tag == "Food_Cook_Teach" or self.data.ItemType == "castlefloor" or self.data.ItemType == "treasure") then
					if self.dialog_show then
						local offY = 0.8
						if ElementInfoData[self.cellId] then
							offY = ElementInfoData[self.cellId].headerOffsetY or 0.8
						end
						self.header.gameObject.transform.localPosition = Vector3(0, 0.76 + offY, 0) -- 0.8
					else
						self.header.gameObject.transform.localPosition = Vector3(0, 0.76, 0)
					end
					self.header.gameObject:SetActive(true)
					if (self.data.ItemType == "castlefloor") then 
						self.header.localPosition = Vector3(0, 1.4, 0)
					end
				else
					self:ClosePointer()
				end
			end)
		end
	end
end

function ElementBehaviour:ClosePointer()
	if (self.tag == "Pointer" or self.tag == "Food_Cook_Teach") then 
		self.header.gameObject:SetActive(false)
	end

	if (self.tag == "Food_Cook_Teach" or self.data.ItemType == "castlefloor") then 
		self.tag = nil
	end
end

function ElementBehaviour:GetSprite()
	return self.sprite or self.sprite2
end

-- 新手引导专用，其他地方禁止使用
function ElementBehaviour:CloseDialog()
	self:OperateDicon(false)
	self.dialog.gameObject:SetActive(false)
end

-- 新手引导专用，其他地方禁止使用
function ElementBehaviour:ShowDialog()
	self:OperateDicon(true)
	self.dialog.gameObject:SetActive(true)
end

function ElementBehaviour:ToRealWorld(camera, o)
	local retPosition = Vector3.zero
	local posZ = MapUtil:getMainCamera().transform.position.z;
	local oldPosition = MapUtil:getMainCamera().gameObject.transform.position;
    MapUtil:getMainCamera().gameObject.transform.position = Vector3(MapUtil:getMainCamera().gameObject.transform.position.x, MapUtil:getMainCamera().gameObject.transform.position.y, MapUtil:getMainCamera().gameObject.transform.position.z);
    local postion = camera:WorldToScreenPoint(o.transform.position);
    retPosition = MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(postion.x, postion.y, -posZ));
    MapUtil:getMainCamera().gameObject.transform.position = oldPosition;
    return retPosition;
end

-- 设置是否当前快速工人正在工作
function ElementBehaviour:setQuickBuild()
	self.quickBuilding = true
end

function ElementBehaviour:clearQuickBuild()
	self.quickBuilding = false
end

-- 设置工人类型
function ElementBehaviour:SetBuildingWorkerType(workName)
	self.worker = workName or "worker"
end

function ElementBehaviour:GetBuildingWorkerType()
	return self.worker or "worker"
end

-- 从一些元素中获取当前距离最近的一个工人
function ElementBehaviour:GetNeareastElementBy(elements)
	local neareast_element = nil
	if (elements == nil or #elements == 0) then
		return nil
	end
	local len = #elements
	if (len == 1) then
		return elements[1]
	end
	local min_dis = self:GetDistance(elements[1].transform.position, self.transform.position)
	for i=1,len do
		local distance = self:GetDistance(elements[i].transform.position, self.transform.position)
		if (distance <= min_dis) then
			min_dis = distance
			neareast_element = elements[i]
		end
	end
	return neareast_element
end

function ElementBehaviour:GetDistance(startPos, endPos)
	return math.sqrt((startPos.x - endPos.x) * (startPos.x  - endPos.x) + (startPos.y - endPos.y) * (startPos.y - endPos.y))
end

-- 显示箭头
function ElementBehaviour:CreateArrow(delTime)
	if (not self.transform) then return end
	if self.data.ItemType == "castlefloor" then
		self.header.gameObject.transform.localPosition = Vector3(0, 1.4, 0)
	end
	self.header.gameObject:SetActive(true)
	App:applyFunc(ConstData.Hint, "ArrowLonglive", self.gameObject.name .. "_Arrow", self.header)
	delTime = delTime or 0
	if (delTime == 0) then return end
	self:delayedCall(delTime,function()
		self:cancelArrow()
	end)
end

function ElementBehaviour:moveTo(endElementBehaviour, offsetVec, delTime, callBack)
	if (self.map == nil) then
		self.map = self.map or App:get(ConstData.STR_MAP)
	end
	self.isWorking = true
    local start_pos = self.gameObject.transform.position
	local end_pos = endElementBehaviour.gameObject.transform.position + offsetVec
	self.map.DragBegin(self, self.gameObject, self.gameObject.transform.position)
	local aid = AnimateTween.moveToV3(self.gameObject, end_pos, delTime)
	aid:setEase(LeanTweenType.easeOutBack)
	AnimateTween.setCallBack(aid, function ()
		self.gameObject.transform.position = end_pos
		self.map.DragEnded(self, self.gameObject, self.gameObject.transform.position, false, endElementBehaviour, false, false, true)
		if (callBack) then
			callBack()
		end
	end)
end

-- 触碰
function ElementBehaviour:ElementTouch(gameObject, touchMsg)
	local mousePos = Input.mousePosition
	if GlobalDataMgr:GetBidMove() then 
		return
	end
	App:applyFunc(ConstData.Sound,  "PlaySoundAndVibrate", "tap")
	self.touchCondition = "start"
end

-- 触碰结束, 
function ElementBehaviour:ElementEnd(gameObject, touchMsg)
	if self:TouchLimit() then 
		self:ElementTouchDown()
		App:applyFunc(ConstData.Hint, "TouchMsgHide")
		MergeChainUtil:hide()
	end
	self.touchCondition = "end"
	MapUpdate:removeLongPressItemList(self)
end

-- 判断触碰提示生效的时间，是在ElementTouch事件ExtDrag.touchJudge时间后执行
function ElementBehaviour:ElementMetion(gameObject, touchMsg)
	if App:applyFunc(ConstData.FirstPlayTeach, "OnSeal") then 
        return
    end
	self.touchCondition = "drag"
	if self:TouchLimit() then 
		self:ElementTouchUp()
		local cellId = self.originCellId or self.cellId
		local parentId = self.mapData.ParentID
		if self.mapData ~= nil then 
			parentId = self.mapData[cellId].ParentID
		end
		App:applyFunc(ConstData.Hint, "TouchMsgShow", cellId, parentId)
		self.longPressTime = 0
		self.longPressState = false
		MapUpdate:addLongPressItemUpdate(self)
	end
end

function ElementBehaviour:TouchDrag()
	return self.touchCondition == "drag"
end

-- 碰触:变大抬起
function ElementBehaviour:ElementTouchUp()
	-- 暂时注释
	if true then
		return
	end
	if IsNil(self.sprite) then 
		return
	end
		
	if (self.touchState == "up") then 
		return
	end

	self.touchDownAtOnce = false

	if not self.touchOriginLocalScale then 
		self.touchOriginLocalScale = self.sprite.transform.localScale
	end

	if not self.touchOriginLocalPosition then 
		self.touchOriginLocalPosition = self.sprite.transform.localPosition
	end

	if not IsNil(self.spine) then 
		self.touchSpineContain = true
		if not self.touchOriginLocalScaleSpine then 
			self.touchOriginLocalScaleSpine = self.spine.transform.localScale
		end

		if not self.touchOriginLocalPositionSpine then 
			self.touchOriginLocalPositionSpine = self.spine.transform.localPosition
		end
	end

	if not IsNil(self.mation) then 
		self.touchMationContain = true
		if not self.touchOriginLocalScaleMation then 
			self.touchOriginLocalScaleMation = self.mation.transform.localScale
		end

		if not self.touchOriginLocalPositionMation then 
			self.touchOriginLocalPositionMation = self.mation.transform.localPosition
		end
	end

	if not IsNil(self.zuowu) then
		self.touchZuowuContain = true
		if not IsNil(self.dialog) then 
			self.dialog.gameObject:SetActive(false)
		end
		if not self.touchOriginLocalScaleZuowu then 
			self.touchOriginLocalScaleZuowu = self.zuowu.transform.localScale
		end

		if not self.touchOriginLocalPositionZuowu then 
			self.touchOriginLocalPositionZuowu = self.zuowu.transform.localPosition
		end
	end

	local finalLocalPosition = self.touchOriginLocalPosition + Vector3(0, 0.25, 0)
	local finalLocalScale    = self.touchOriginLocalScale + Vector3.one * 0.15

	local finalLocalPositionSpine = (self.touchOriginLocalPositionSpine or Vector3.zero) + Vector3(0, 0.25, 0)
	local finalLocalScaleSpine    = (self.touchOriginLocalScaleSpine or Vector3.one) + Vector3.one * 0.15

	local finalLocalPositionMation = (self.touchOriginLocalPositionMation or Vector3.zero) + Vector3(0, 0.25, 0)
	local finalLocalScaleMation    = (self.touchOriginLocalScaleMation or Vector3.one) + Vector3.one * 0.15

	local finalLocalPositionZuowu = (self.touchOriginLocalPositionZuowu or Vector3.zero) + Vector3(0, 0.25, 0)
	local finalLocalScaleZuowu    = (self.touchOriginLocalScaleZuowu or Vector3.one) + Vector3.one * 0.15

	local aid = AnimateTween.valueTo(self.sprite.gameObject, 0, 1, 0.05, function(tm)
        self.sprite.transform.localPosition = self.touchOriginLocalPosition * (1 - tm) + finalLocalPosition * tm
        self.sprite.transform.localScale = self.touchOriginLocalScale * (1 - tm) + finalLocalScale * tm
        if self.touchSpineContain then 
        	self.spine.transform.localPosition = self.touchOriginLocalPositionSpine * (1 - tm) + finalLocalPositionSpine * tm
        	self.spine.transform.localScale = self.touchOriginLocalScaleSpine * (1 - tm) + finalLocalScaleSpine * tm
        end

        if self.touchMationContain then 
        	self.mation.transform.localPosition = self.touchOriginLocalPositionMation * (1 - tm) + finalLocalPositionMation * tm
        	self.mation.transform.localScale = self.touchOriginLocalScaleMation * (1 - tm) + finalLocalScaleMation * tm
        end

        if self.touchZuowuContain then 
        	self.zuowu.transform.localPosition = self.touchOriginLocalPositionZuowu * (1 - tm) + finalLocalPositionZuowu * tm
        	self.zuowu.transform.localScale = self.touchOriginLocalScaleZuowu * (1 - tm) + finalLocalScaleZuowu * tm
        end
    end)

    aid:setEase(LeanTweenType.easeOutCirc) -- 曲线
    AnimateTween.setCallBack(aid, function() 
        self.touchState = "up"
        if self.touchDownAtOnce then 
        	self:ElementTouchDown(true)
        end
    end)
end

-- 碰触:抬手, 缩小落下
function ElementBehaviour:ElementTouchDown(inner)
	-- 暂时取消
	if true then
		return
	end
	if IsNil(self.sprite) then 
		return
	end
	if not self.touchOriginLocalScale then 
		return
	end

	if not self.touchOriginLocalPosition then 
		return
	end

	if (self.touchState == "down") then 
		self.touchDownAtOnce = true
		return
	end
	if not IsNil(self.zuowu) and not IsNil(self.dialog) then 
		self.dialog.gameObject:SetActive(true)
	end
	local currentLocalPosition      = self.touchOriginLocalPosition + Vector3(0, 0.25, 0)
	local currentLocalScale         = self.touchOriginLocalScale + Vector3.one * 0.15

	local currentLocalPositionSpine = (self.touchOriginLocalPositionSpine or Vector3.zero) + Vector3(0, 0.25, 0)
	local currentLocalScaleSpine    = (self.touchOriginLocalScaleSpine or Vector3.one) + Vector3.one * 0.15

	local currentLocalPositionMation = (self.touchOriginLocalPositionMation or Vector3.zero) + Vector3(0, 0.25, 0)
	local currentLocalScaleMation    = (self.touchOriginLocalScaleMation or Vector3.one) + Vector3.one * 0.15

	local currentLocalPositionZuowu = (self.touchOriginLocalPositionZuowu or Vector3.zero) + Vector3(0, 0.25, 0)
	local currentLocalScaleZuowu    = (self.touchOriginLocalScaleZuowu or Vector3.one) + Vector3.one * 0.15

	local aid = AnimateTween.valueTo(self.sprite.gameObject, 0, 1, 0.05, function(tm)
        self.sprite.localPosition = self.touchOriginLocalPosition * tm + currentLocalPosition * (1 - tm)
        self.sprite.localScale = self.touchOriginLocalScale * (tm) + currentLocalScale * (1 - tm)
        if self.touchSpineContain then 
        	self.spine.localPosition = self.touchOriginLocalPositionSpine * tm + currentLocalPositionSpine * (1 - tm)
        	self.spine.localScale = self.touchOriginLocalScaleSpine * (tm) + currentLocalScaleSpine * (1 - tm)
        end

        if self.touchMationContain then
        	self.mation.localPosition = self.touchOriginLocalPositionMation * tm + currentLocalPositionMation * (1 - tm)
        	self.mation.localScale = self.touchOriginLocalScaleMation * (tm) + currentLocalScaleMation * (1 - tm)
        end

        if self.touchZuowuContain then
        	self.zuowu.localPosition = self.touchOriginLocalPositionZuowu * tm + currentLocalPositionZuowu * (1 - tm)
        	self.zuowu.localScale = self.touchOriginLocalScaleZuowu * (tm) + currentLocalScaleZuowu * (1 - tm)
        end
    end)

    aid:setEase(LeanTweenType.easeOutCirc) -- 曲线
    AnimateTween.setCallBack(aid, function() 
        self.touchState = "down"
    end)
end

function ElementBehaviour:TouchLimit()
	local limitItemType = {
		"castle", "castlefloor", "mine", "npc"
	}
	return not table.indexof(limitItemType, self.data.ItemType)
end


function ElementBehaviour:LeaveGo(inVisable)
	if IsNil(self.gameObject) or TEST_MODE or IsNil(NativeHelper.Instance) then 
		return
	end
    self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
    self.boxCollider2D = self.boxCollider2D or self.gameObject:GetComponent("BoxCollider2D")
    if not IsNil(self.extDragComp) then 
        self.extDragComp.enabled = inVisable
    end
    if not self.stopinteracted then
	    if not IsNil(self.boxCollider2D) then 
	        self.boxCollider2D.enabled = inVisable
        end
	end
    if not IsNil(self.sprite) then 
        self.sprite_animation = self.sprite_animation or self.sprite.gameObject:GetComponent("Animation")
        if not IsNil(self.sprite_animation) then 
            self.sprite_animation.enabled = inVisable
        end
    end
    NormalUtils.SpineAnimationStateAdjust(self.gameObject, inVisable)
end

-- dialog/icon 设置偏移
function ElementBehaviour:DialogIconOffset(sprite, offset)
	if IsNil(self.dialog) then 
		return
	end
	if not self.icon_origin_localpos then 
		self.icon_origin_localpos = self.icon.transform.localPosition
	end
	self.icon:GetComponent(ConstData.SpriteRenderer).sprite = sprite
	self.icon:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
	if offset then 
		self.icon.transform.localPosition = self.icon_origin_localpos + offset
	end
	if (string.find(self.name, "NPC") or string.find(self.name, "Npc")) then
		if self.status == StatusConst.WaitingForFinishCook then
			self.icon.transform.localScale = Vector3(0.9, 0.9, 1)
		else
			self.icon.transform.localScale = Vector3(0.8, 0.8, 1)
		end
	else
		local ele_data = ElementInfoData[self.cellId]
		if IsNil(ele_data) or IsNil(ele_data["dialogIconScale"]) then
			self.icon.transform.localScale = Vector3(0.7, 0.7, 1)
		else
			self.icon.transform.localScale = ele_data["dialogIconScale"]
		end
	end
	return self.icon
end

-- 处理npc上dialog的问题
function ElementBehaviour:DialogRefresh()
	if IsNil(self.dialog) or self.data.ItemType ~= "npc" then 
		return
	end

	if FakeCorouteInst then
        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 3, function() 
            local statusTable = {"right", "metion"}
			local order = self.dialog:GetComponent(typeof(CS.UnityEngine.SpriteRenderer)).sortingOrder

			for k, v in pairs(statusTable) do
				local statusIcon = self.dialog.transform:Find("status/" .. tostring(v)).gameObject
				if (statusIcon) then 
					statusIcon.gameObject:GetComponent(typeof(CS.UnityEngine.SpriteRenderer)).sortingOrder = order + 1
				end
			end
        end)
    end
end

function ElementBehaviour:PlayDialogAni()
	self.dialogAni = self.dialogAni or self.transform:Find("dialogParent/dialogAni")
	if not IsNil(self.dialogAni) then
		self.dialogAni.gameObject:GetComponent("Animation").enabled = true
	end
end

function ElementBehaviour:SpineExchange(spinePath, skinName, act)
	local assetPkg = ResourcesManager:GetInstance():getAssetPkg()
	local spinePath = ResCfg:getPathSpine(ResCfg.SpineRes.NPC, spinePath)
	local spine = self.transform:Find("spine").gameObject
	if spinePath and spine then
		assetPkg:SetSkeletonData(spine.gameObject, spinePath)
		SpineManager.Skin(spine.gameObject, skinName)
		SpineManager.Play(spine, act, false)
		SpineManager.RegisterAnimationCallback(spine,
	        function(obj, name, index)
	            if self.animated then
	                self.animated = false
	                SpineManager.Play(spine, self.data.SpineAnimationList[math.random(1, #self.data.SpineAnimationList)], false)
	                return
	            end
	            if self.data.SpineAnimationList then
	                if math.random(1, 4) == 1 then
	                    SpineManager.Play(spine, self.data.SpineAnimationList[math.random(1, #self.data.SpineAnimationList)], false)
	                else
	                    SpineManager.Play(spine, self.data.SpineAnimation, false)
	                end
	            end
	        end,
        	function() 
        	end)
	end
end

-- 活动岛用到的方法
function ElementBehaviour:CreateAwardByMerge()
	if not self or IsNil(self.gameObject) then
		-- 当前对象不存在
		return
	end
	if self.current_output then 
		self.cellIDS = self.current_output
		self:ShowDialogAward()
		self:AddDialogClick()
		return
	end
	local awardId = self.map.mapData[self.cellId].MergeDropID
	if awardId == "" then 
		return
	end
	local cellIDS = App:applyFunc(ConstData.Award, "awardDetail", awardId) -- 更换奖励
	if #cellIDS < 1 then 
		return
	end
	local behaviour_tmp = {}
	behaviour_tmp.position = self.gameObject.transform.position
	behaviour_tmp.X = self.X
	behaviour_tmp.Y = self.Y
	local mapArr = string.split(self.map.levelMap, "/")
    local mapPath = string.split(mapArr[#mapArr], "%.")[1]
	App:applyFunc(ConstData.Element, "generateObjectByOutput2", behaviour_tmp, cellIDS, function(isFinish, generateAward, remainAward) 
		if not isFinish then 
			self.cellIDS = remainAward
			self.current_output = remainAward
			self:ShowDialogAward()
			self:AddDialogClick()
		else
			self.tag = nil
		end
	end, true, nil, true)
end

-- 根据MapDada中得AwardId生成奖励
function ElementBehaviour:CreateAward(tag)
	if not self or IsNil(self.gameObject) then
		return
	end
	self.tag = tag
	if self.current_output then 
		self.cellIDS = self.current_output
		self:ShowDialogAward()
		self:AddDialogClick()
		return
	end
	local awardId = self.map.mapData[self.cellId].GetDropID
	if awardId == "" then 
		self.tag = nil
		return
	end
	local cellIDS = App:applyFunc(ConstData.Award, "awardDetail", awardId) -- 更换奖励
	if #cellIDS < 1 then 
		self.tag = nil
		return
	end
	local behaviour_tmp = {}
	behaviour_tmp.position = self.gameObject.transform.position
	behaviour_tmp.X = self.X
	behaviour_tmp.Y = self.Y
	local mapArr = string.split(self.map.levelMap, "/")
    local mapPath = string.split(mapArr[#mapArr], "%.")[1]
	App:applyFunc(ConstData.Element, "generateObjectByOutput2", behaviour_tmp, cellIDS, function(isFinish, generateAward, remainAward) 
		if not isFinish then 
			self.cellIDS = remainAward
			self.tag = tag
			self.current_output = remainAward
			self:ShowDialogAward()
			self:AddDialogClick()
		else
			self.tag = nil
			self.current_output = nil
		end
	end, true, nil, true)
end

function ElementBehaviour:ShowDialogAward()
	if not self.cellIDS then 
		return 
	end
	local SpriteName = self.cellIDS[1]
	if self.dialog and not self.dialog_show then
		self.dialog_show = true
		self.map.dialogShow = true
		if not IsNil(self.dialogAni) then
			self.dialogAni.gameObject:GetComponent("Animation").enabled = true
		end
		self.expendAward = false
		SpriteName = ClientData:GetInstance():getItemSpriteName(SpriteName)
		App:applyFunc(ConstData.Sprite, "getSpriteVecDialog", SpriteName, function(sprite, offset) 
			self:OperateDicon(true)
			self:DialogIconOffset(sprite, offset)
			-- 更新位置
			if not IsNil(self.dialogParent) then
				local ele_data = ElementInfoData[self.cellId]
				if not IsNil(ele_data) then
					self.dialogParent.transform.localPosition = ele_data["dialogPosition"] or Vector3(0, 0.4, 0)
				end
			end
			self.dialog = self.transform:Find("dialogParent/dialogAni/dialog")
			if not self.dialog then 
				return
			end
			self.dialog.gameObject:GetComponent(ConstData.SpriteRenderer).enabled = true
			self.dialog.gameObject:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 1)
			local aid = AnimateTween.valueTo(self.dialog.gameObject, 0, 1, 0.2, function(tm) 
				self.dialog.transform.localScale = self.dialogOldScale * tm
			end)
			AnimateTween.setCallBack(aid, function() 
				-- 替换之前的
				self.expendAward = true
			end)
		end)
	end
end

function ElementBehaviour:AddDialogClick()
	if not self.dialogBehaviour.gameObject then 
		self.dialogBehaviour.gameObject = self.transform:Find("dialogParent/dialogAni/dialog").gameObject
		if not self.dialogBehaviour.gameObject then 
			return
		end
	end
	local function beginCall()
		self.dialogBeginTouch = true	
	end
	local function endCall()
		if not self.dialogBeginTouch then 
			return
		end
		self.dialogBeginTouch = nil
		
		if App:applyFunc(ConstData.FirstPlayTeach, "OnSeal") then
			return
		end
		App:applyFunc(ConstData.Cloud, "BidCloud", 0.2)
		if not self.expendAward then
			return
		end
		if UI_TOUCH then
			return
		end
		if GlobalDataMgr:GetBidMove() then
			return
		end
		-- 生成Outputs
		local Outputs = self.cellIDS
		if self.current_output then
			Outputs = self.current_output
		else
			self.current_output = self.cellIDS
		end
		-- 音效 + 震动
		App:applyFunc(ConstData.Sound,  "PlaySoundAndVibrate", "tap")
		self:ClickCreateAward()	
	end
	BaseLogic:GetInstance():AddClick(self.dialogBehaviour, beginCall, nil, endCall)
end

function ElementBehaviour:ClickCreateAward()
	if not self.current_output then 
		return
	end
	if not self.expendAward then 
		return
	end
	self.expendAward = false
	App:applyFunc(ConstData.Element, "generateObjectByOutput2", self, self.current_output, function(isFinish, generateAward, remainAward)
		if isFinish then
			self.current_output = nil
			self.dialog.transform.localScale = Vector3.zero
			self.dialog_show = false
			self.expendAward = false
			self.tag = nil
		else
			self.current_output = remainAward
			self.expendAward = true
		end
	end, true)
end


-->> 短链岛用
function ElementBehaviour:SetCounted()
	self.m_Counted = CountStatus.Counted
end

function ElementBehaviour:SetRemove()
	self.m_Counted = CountStatus.Remove
end

function ElementBehaviour:CreateCollectBanner(banner)
	self.collectBanner = ActivityCollectBanner(self, banner)
end

function ElementBehaviour:RefreshBanner(needData, realHave, status, from)
	if not self.collectBanner then 
		return
	end
	self.collectBanner:RefreshBanner(needData, realHave, status, from)
end

function ElementBehaviour:ClearCollectBanner()
	if not self.collectBanner then 
		return
	end
	App:applyFunc(ConstData.ActivityTrade, "RecycleBanner", self.collectBanner.banner)
	self.collectBanner:ClearBanner()
	self.collectBanner = nil
end

function ElementBehaviour:OnDrag()
	if not self.collectBanner then 
		return
	end
	self.collectBanner:HideBanner()
end

function ElementBehaviour:EndDrag(position)
	self:UpdateBannerPos(position)
end

function ElementBehaviour:ExchangeTradeOrder()
	if self.tradeSignal and self.tradeSignal ~= "wait" then 
		if self.spriteRenderer then 
			SpineManager.Layer(self.tradeSignal, self.spriteRenderer.sortingLayerName)
			SpineManager.Order(self.tradeSignal, self.spriteRenderer.sortingOrder + 1)
		end
	end
end

function ElementBehaviour:UpdateBannerPos(position)
	if not self.collectBanner then 
		return
	end
	
	self.collectBanner:ShowBanner(position)
end

function ElementBehaviour:TradeEnd()
	if not self.collectBanner then 
		return
	end
	self.collectBanner:RefreshAwards()
end

function ElementBehaviour:TradeAward(awards, callback)
	App:applyFunc(ConstData.Element, "generateObjectByOutput2", self, awards, function(isFinish, generateAward, remainAward)
		if callback then 
			callback()
		end
	end, true)
end

function ElementBehaviour:OperateSignal(active)
	if self.tradeSignal and self.tradeSignal ~= "wait" then 
		self.tradeSignal:SetActive(active)
	elseif not self.tradeSignal then
		self.tradeSignal = "wait"
		local path = ResCfg:getPathPrefabs(ResCfg.Prefabs.TradeSubmit)
        ResourcesManager:GetInstance():LoadAsync(path, typeof(UGameObject), function(go) 
            prefabGo = go 
			self.tradeSignal = AGameObject.Instantiate(go)
			self.tradeSignal.transform:SetParent(self.gameObject.transform)
			self.tradeSignal.transform.position = self.transform.position
			self.tradeSignal:SetActive(active)
			self.tradeSignal.transform.localScale = Vector3.one
			self:ExchangeTradeOrder()
		end)
	end
end

function ElementBehaviour:ClearTradeSignal()
	if not IsNil(self.tradeSignal) and self.tradeSignal ~= "wait" then 
		UGameObject.Destroy(self.tradeSignal)
	end
	self.tradeSignal = nil
end
--<< 短链岛用
-- 活动到用到的方法(收)
return ElementBehaviour