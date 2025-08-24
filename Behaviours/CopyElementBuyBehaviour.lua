local MOVE_SPEED = {50, 65}    -- 漂浮物的速度, 随机出来的速度，会乘以0.01
local CopyElementBuyBehaviour = class(BaseBehaviour, "CopyElementBuyBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
function CopyElementBuyBehaviour:Awake()
	self.map = App:get(ConstData.STR_MAP)
	self.mapData = ClientData:GetInstance():MapData()
end

-- 初始化数据
function CopyElementBuyBehaviour:InitBehaviour(cellId, isVideo)
	self.cellId = cellId
	if self.mapData[cellId] and self.mapData[cellId].SpriteName then
		App:applyFunc(ConstData.Sprite, "getSpriteVecDialog", self.mapData[cellId].SpriteName, function (sprite, offset)
			self.good = self.gameObject.transform:Find("ballonSkel/Bone/good"):GetComponent(ConstData.SpriteRenderer)
			if not self.good_offset then 
				self.good_offset = offset
			end
			self.good.sprite = sprite
			self.good.gameObject:SetActive(true)
		end)
	end
	self.balloon = self.gameObject.transform:Find("ballonSkel")
	self.balloon.transform.localScale = Vector3.one
	self.moved = true
    self.suspended = false
    self.clicked = false
    self.isVideo = isVideo

    self:BalloonAppear()
end

-- 切换气球的状态
function CopyElementBuyBehaviour:SwitchBalloonState(aniName, loop, callback)
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
function CopyElementBuyBehaviour:BalloonAppear()
	self:SwitchBalloonState("appear", false, function ()
		if self.aniName ~= "disappear" then
			self:SwitchBalloonState("idle", true)
		end
	end)
	if self.good then
		local oldPos = Vector3(0, 0.2, 0)
		local y = self.good.bounds.size.y / 2 * 0.7
		if y < 0.3 then
			y = -0.5
		else
			y = -0.5 - (y - 0.2) 
		end
		y = y > -0.5 and -0.5 or y
		local newPos = Vector3(0, y, 0) -- -0.3
		newPos = newPos + self.good_offset
		self.good.color = Color(self.good.color.r, self.good.color.g, self.good.color.b, 0)
		AnimateTween.alphaTo(self.good.gameObject, 1, 0.66)
		AnimateTween.moveToLocal3(self.good.gameObject, newPos, 0.66)
	end
end

function CopyElementBuyBehaviour:onClick()
	-- 延时一帧 Fake
	if self.clicked then
		return
	end
	if NormalUtils.IsPointerOverGameObject() then 
		return
	end
	self.clicked = true
	if FakeCorouteInst then
        FakeCorouteInst:CreateFakeCoroute(5, function() 
        	if Global.SEAL_OPEN then
        		self.clicked = nil
        		self.moved = true
				return
			end
			self.moved = false
			-- 弹出复制品购买界面
			App:applyFunc(ConstData.Popup, "hideAll")
			UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UICopyElementBuy, {"expend"}, {["cellId"] = self.cellId, ["behaviour"] = self }, self.isVideo)
    	end)
    end
end

-- 生成复制品
function CopyElementBuyBehaviour:generateCopyElement()
	if self.cellId == nil or IsNil(self.gameObject) then
		return
	end
	-- 获取地块是否足够
	local ret = App:applyFunc(ConstData.MapCore, "getFreeGrid", 1)
	local isCreate = false
	if ret then
		local offset_y = App:applyFunc(ConstData.CopyElementBuy, "GetOffsetY") or 4
    	local vec = App:applyFunc(ConstData.MapCore, "NearestGridIndex", Vector2(self.gameObject.transform.position.x * 100, (self.gameObject.transform.position.y - offset_y) * 100))
    	local isForce = false
        if lvType == ConstData.ACTIVITY_LEVEL then
            isForce = true
        end
    	local vvv = App:applyFunc(ConstData.MapCore, "ResearchGird", vec.x, vec.y, {1, 1}, isForce)
    	local vv = vvv[1]
    	App:applyFunc(ConstData.MapCore, "RemoveGrid", 1)
    	local index = vv[1] + 1 + vv[2] * self.map.cellXCount
    	self.map.currentMatrix[index] = "Y"
    	self.map.emptyMatrix[index] = false
    	local startPosition = self.gameObject.transform.position
    	local good = self.transform:Find("ballonSkel/Bone/good")
    	if not IsNil(good) then
    		startPosition = good.transform.position
    	end
	    local pos = superMapUtils:GridIndexConvertToPosition(vv[1], vv[2]) / 100

		-- 地块足够,复制品落地
		App:applyFunc(ConstData.Element, "Generate", {
            data = clone(self.mapData[self.cellId]),
            position = pos, 
            x = vv[1], 
            y = vv[2], 
            cellId = self.cellId, 
            is_animate = true, 
            moveTo = true, 
            startPosition = startPosition,
            dynamic_data = nil,
            isNew = true,
            tag = "Copy",
            particle = "EffMoveTail3",
        })
        isCreate = true
	else
		-- 地块不足,进入天空泡泡
		local data = {
			CellId = {self.cellId},
		}
		App:applyFunc(ConstData.Airball,  "ProduceAirshipAtCurMap", data)
	end
	self:disappear(isCreate)
end

function CopyElementBuyBehaviour:OnDestroy()

end

function CopyElementBuyBehaviour:OnDisable()
	if self.map.dragObject == self then
		self.map.dragObject = nil
	end
end

-- 消失
function CopyElementBuyBehaviour:disappear(isCreate)
	if (IsNil(self.gameObject)) then return end
	self.clicked = true
	self.moved = false
	-- self:SetAnimationEnable(false)
	self:SwitchBalloonState("disappear", false, function()
		if (self.gameObject) then
			GameObjectPool:GetInstance():PutObjectBackToPool(ResCfg.UIPrefabs.CopyElementFly, self.gameObject, true)
			self.balloon = nil
		end
		-- 从库存中移除
		App:applyFunc(ConstData.CopyElementBuy, "RemoveData", self.cellId)
	end)
	if isCreate then
		if self.good then
			self.good.gameObject:SetActive(false)
		end
	else
		local aid = AnimateTween.valueTo(self.good.gameObject, 0, 1, 0.9, function(tm)
			self.good.color = Color(1, 1, 1, (1 - tm))
		end)
	end
end

-- 设置动画是否播放
function CopyElementBuyBehaviour:SetAnimationEnable(value)
	if self.animator then
		self.animator.enabled = value
	end
end

-- 从购买界面返回之后重新刷新状态
function CopyElementBuyBehaviour:RefreshState()
	self.clicked = false
	self.moved = true
	-- self:SetAnimationEnable(true)
end

function CopyElementBuyBehaviour:Update()
	if not DeltaTime then
		return
	end
	if self.cellId == nil or not self.moved then return end
	-- 不购买自动消失
	if self.gameObject.transform.position.x > 35 then
		-- 从库存中移除
		App:applyFunc(ConstData.CopyElementBuy, "RemoveData", self.cellId)
		UGameObject.DestroyImmediate(self.gameObject)
		return
	end
	if not IsNil(self.gameObject) and DeltaTime then
		self.gameObject.transform.position = self.gameObject.transform.position + Vector3(5 / 20.0 * GlobalData.FlotageSpped, 0, 0) * DeltaTime
	end
end

function CopyElementBuyBehaviour:AddSortingOrder()
	
end

function CopyElementBuyBehaviour:ReduceSortingOrder()
	
end


return CopyElementBuyBehaviour