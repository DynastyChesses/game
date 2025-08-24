local MOVE_SPEED             = {30, 45}    -- 漂浮物的速度, 随机出来的速度，会乘以0.01
local FLOAT_ADS_SCALE        = 0.55 -- 广告漂浮物的缩放
local FLOAT_SEED_SCALE       = 0.40 -- 普通漂浮物的缩放
local SPEED_COEFFICIENT      = 1    -- 增加速度系数取值 系数小于零时漂浮物将向左移动，等于零将不动，大于零将向右移动
local NormalFloatBehaviour = class(BaseBehaviour, "NormalFloatBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
local SpriteBehaviour   = require("Game.Behaviours.SpriteBehaviour")

function NormalFloatBehaviour:Awake()
	self.moveSpeed = self.moveSpeed or Vector3.zero
end


function NormalFloatBehaviour:AddDragFunc(msg)
	self.cellId = msg.key
    self.moved = msg.moved
    self.suspended = msg.suspended
    self.key = msg.key
	self.map = msg.map
	local mapArr = string.split(self.map.levelMap, "/")
    local mapPath = string.split(mapArr[#mapArr], "%.")[1]
    self.mapname = mapPath
	self.reward = msg.reward
	self.prefabPath = msg.prefabPath
	self.disable = false
	self.mapData = ClientData:GetInstance():MapData()

	self.transform.position = Vector3(self.transform.position.x, self.transform.position.y, -0.008)

	local currentTan = App:applyFunc(ConstData.FloatSystem, "GetAngleTan")
	local direction =  Vector3.Normalize(Vector3(1, currentTan, 0))
	local moveSpeed = math.random(MOVE_SPEED[1], MOVE_SPEED[2]) * 0.01
	if self.cellId == "MASTER_ADS" then 
		self.moveSpeed = direction * moveSpeed * SPEED_COEFFICIENT
	else
		self.moveSpeed = direction * moveSpeed
	end

	self.masterAd = self.transform:Find("MASTER_ADS").gameObject
	self.masterSeed = self.transform:Find("MASTER_SEED").gameObject
	self.masterSeedSea = self.transform:Find("MASTER_SEED_Sea").gameObject

	BaseLogic:GetInstance():AddDrag(self, {
        ["begin"] = self.DragBegin,
        ["moving"] = self.DragMoving,
        ["ended"] = self.DragEnded
    })
end

-- 气球的拖拽
function NormalFloatBehaviour:DragBegin(gameObject, position)
	-- 防止ui穿透
	if (UI_COUNT and UI_COUNT > 0) then
		return
	end
	if Global.SEAL_OPEN then
		return
	end
	if not self then
		return
	end
	self.map = App:applyFunc(ConstData.MapCore, "getMap")
	if not self.map then
		return
	end
    self.map.dragObject = self
    self.touchBeginPosition = Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.5)
    self.touchBeginTime = os.time()
end

function NormalFloatBehaviour:DragMoving(gameObject, position)
	-- 防止ui穿透
	if (UI_COUNT and UI_COUNT > 0) then
		return
	end
	if Global.SEAL_OPEN then
		return
	end
	-- 删除旧的相机移动代码
 	App:applyFunc(ConstData.Camera,  "DragAdjustCamera", self.gameObject, UTime.time)
 	self.transform.position = Vector3(self.transform.position.x, self.transform.position.y, -0.008)
end

function NormalFloatBehaviour:DragEnded(gameObject, position)
	-- 防止ui穿透
	if (UI_COUNT and UI_COUNT > 0) then
		return
	end
	if FakeCorouteInst then
        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
			if Global.SEAL_OPEN or Global.UIMainViewClick then
				CLOUD_BID = nil
				self.map.dragObject = nil
				self.generated = nil
				return
			end
		    self.touchBeginPosition = self.touchBeginPosition or gameObject.transform.position
		    local distance = (gameObject.transform.position - self.touchBeginPosition).magnitude
		    self.map.dragObject = nil
		    self.touchBeginTime = self.touchBeginTime or os.time()
		    local offsetTime = os.time() - self.touchBeginTime
			App:applyFunc(ConstData.Cloud, "BidCloud", 0.2)
		    if offsetTime <= 0.25 and distance < 2 then
		        -- TapFloat-1
		        if not self.generated then
		            self.generated = true
		            AnimateTween.delayCall(2.0, function() 
		                self.generated = false
		            end)
		            self:generate(function() 
		                App:applyFunc(ConstData.Task,  "onceTask", "TapFloat-1")
						App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "NormalFloat", param = {"TapFloat-1"}})
		            end)
		        end
		    else
		        self.transform.position = Vector3(self.transform.position.x, self.transform.position.y, -0.008)
		    end
		end) 
	end 
end

-- 进行随机横向移动
function NormalFloatBehaviour:Update()
	if self.cellId == "" then 
		return
	end

	if self.transform.position.x > 35 then
		App:applyFunc(ConstData.FloatSystem, "DeleteFloat", self, "AutoDelete")
		self:RecycleSelfToPool()
		return
	end
	
	if not self.isStop then 
		self.transform.position = self.transform.position + self.moveSpeed * DeltaTime
	end
end

-- 回收自己到对象池中
function NormalFloatBehaviour:RecycleSelfToPool()
	if IsNil(self.gameObject) then return end

	local header = self.transform:Find("header")
	App:applyFunc(ConstData.TaskExplore, "ElementArrowBack", header)
	
	if self.prefabPath == nil then
		UGameObject.DestroyImmediate(self.gameObject)
		return
	end
	if self.masterSeed and self.masterAd then 
		-- 回收自身到对象池中
		self.masterAd:SetActive(false)
		self.masterSeed:SetActive(false)
		self.masterSeed = nil 
		self.masterAd = nil 
	end
	local gameObject = self.gameObject
	BehaviourUtil.RemoveBehaviour(gameObject, "NormalFloatBehaviour")	
	GameObjectPool:GetInstance():PutObjectBackToPool(self.prefabPath, gameObject, true)
end

function NormalFloatBehaviour:ExchangeSprite(spriteName, rewardCellId)
	-- self.transform:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
	self.transform:Find(spriteName).gameObject:SetActive(false)

	BehaviourUtil.RemoveBehaviour(self.masterSeed, "SpriteBehaviour")
	BehaviourUtil.RemoveBehaviour(self.masterAd, "SpriteBehaviour")
	BehaviourUtil.RemoveBehaviour(self.masterSeedSea, "SpriteBehaviour")
	if (self.cellId == "MASTER_ADS") then 
	  	self.transform.localScale = Vector3.one * FLOAT_ADS_SCALE
		self.masterSeed:SetActive(false)
		UIMgrUtil:SetActive(self.masterSeedSea.gameObject, false)
		self.masterAd:SetActive(true)
		BehaviourUtil.AddBehaviour(self.masterAd, SpriteBehaviour, self)
	else
		self.transform.localScale = Vector3.one * FLOAT_SEED_SCALE
		self.masterAd:SetActive(false)
		UIMgrUtil:SetActive(self.masterSeedSea.gameObject, false)
		local lvty = App:applyFunc(ConstData.Level, ConstData.getMapType)
		if lvty == ConstData.ACTIVITY_LEVEL then
			local bpId =  App:applyFunc(ConstData.ActivityIsLandBP, "GetActivityBPDynamicValue", "ID")
			-- 海岛专属漂浮物
			UIMgrUtil:SetActive(self.masterSeedSea.gameObject, bpId == "1005")
			UIMgrUtil:SetActive(self.masterSeed.gameObject, bpId ~= "1005")
			if bpId == "1005" then
				BehaviourUtil.AddBehaviour(self.masterSeedSea, SpriteBehaviour, self)
			else
				BehaviourUtil.AddBehaviour(self.masterSeed, SpriteBehaviour, self)
			end
		else
			self.masterSeed:SetActive(true)
			BehaviourUtil.AddBehaviour(self.masterSeed, SpriteBehaviour, self)
		end
	end
	self.originScale = self.transform.localScale
end

function NormalFloatBehaviour:LeaveGo(inVisable)
	if IsNil(self.gameObject) then 
		return 
	end
	self.extDragComp = self.extDragComp or self.gameObject:GetComponent("ExtDrag")
	self.extDragComp.enabled = inVisable
	self.boxCollider2D = self.boxCollider2D or self.gameObject:GetComponent("BoxCollider2D")
	self.boxCollider2D.enabled = inVisable
	NormalUtils.SpineAnimationStateAdjust(self.gameObject, inVisable)
end

function NormalFloatBehaviour:DisAppear(callback)
		if (IsNil(self.transform)) then return end
		self.disable = true
		local newScale = Vector3.zero
		local oldScale = Vector3.one * FLOAT_ADS_SCALE
		if self.cellId ~= "MASTER_ADS" then
			oldScale = Vector3.one * FLOAT_SEED_SCALE
		end
		self.transform.localScale = oldScale
		local scaleAid = AnimateTween.valueTo(self.gameObject, 0, 1, 0.33, function(tm)
			self.transform.localScale = oldScale + (newScale - oldScale) * tm
		end)
		scaleAid:setEase(LeanTweenType.easeInBack)
		AnimateTween.setCallBack(scaleAid, function()
			App:applyFunc(ConstData.FloatSystem, "DeleteFloat", self, "Click")
			if callback then
				callback()
			end
			if (self.gameObject) then
				-- UGameObject.DestroyImmediate(self.gameObject)
				-- 普通销毁
				-- UGameObject.DestroyImmediate(self.gameObject)
				-- 对象池回收
				self:RecycleSelfToPool()
			end
		end)
end

function NormalFloatBehaviour:SetMoveProperties(value)
		self.moved = value
end

function NormalFloatBehaviour:generate(func)
		-- 点击漂浮物。音效+ 震动
		-- 针对地图存储增加
	  	App:applyFunc(ConstData.Sound,  "PlaySoundAndVibrate", "tap")
		if (self.key == "MASTER_ADS") then 
			-- TODO 广告漂浮物
			UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIAdsRewardsPanel, {"expend"}, self, self.reward)
			return
		end
	  	App:applyFunc(ConstData.Sound,  "playSound", "floatClick")
		if self.cellId then
			local ret = App:applyFunc(ConstData.MapCore, "getFreeGrid", 1)
			if ret then -- 
				if self.mapname then
					-- 进行Float存储
					local NormalFloatGenerateLimitString = UPlayerPrefs.GetString(CURRENT_USER .. "_" .. "NormalFloatGenerateLimit", "")
					local NormalFloatGenerateLimitArray = {}
					if NormalFloatGenerateLimitString ~= "" then
						NormalFloatGenerateLimitArray = JsonHelper.decode(NormalFloatGenerateLimitString)
					end
					NormalFloatGenerateLimitArray[self.mapname] = NormalFloatGenerateLimitArray[self.mapname] or 0
					NormalFloatGenerateLimitArray[self.mapname] = NormalFloatGenerateLimitArray[self.mapname] + 1
					-- 存储
					NormalFloatGenerateLimitString = JsonHelper.encode(NormalFloatGenerateLimitArray)
					UPlayerPrefs.SetString(CURRENT_USER .. "_" .. "NormalFloatGenerateLimit", NormalFloatGenerateLimitString)
				end
				self.moved = nil
				-- App:applyFunc(ConstData.Task,  "onceTask", "TapFloat")
				App:applyFunc(ConstData.DailyTask,  "CompleteDailyTask", "Float", 1)
				App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "NormalFloat", param = {"TapFloat"}})
				-- 当前对象处理
				self.cellId = string.split(self.cellId, "%.")
				if #self.cellId > 0 then
					self.cellId = self.cellId[math.random(1, #self.cellId)]
				end
				App:applyFunc(ConstData.Element, "generateObjectByBall", self, self.gameObject.transform.position, {self.reward}, function(isFinish) 
						if isFinish then
								if string.find(self.reward, "Coin") then 
									App:applyFunc(ConstData.DCAuxiliaryTool, "RecordResItem", "get_item_coin", "Float", {self.rewardId})
								elseif string.find(self.reward, "Diamond") then
									App:applyFunc(ConstData.DCAuxiliaryTool, "RecordResItem", "get_item_diamond", "Float", {self.reward})
								end
								App:applyFunc(ConstData.FloatSystem, "DeleteFloat", self, "Click")
								local lvType = App:applyFunc(ConstData.Level, ConstData.getMapType)
								if lvType ~= ConstData.STORY_LEVEL then
									local data = {
										page_name = "",
										button_name = lvType == ConstData.STR_MASTER and "main_float" or "activity_float",
										label_id = "",
									}
									DC:dcWbBI(DCData.click, data)
								end
								-- UGameObject.DestroyImmediate(self.gameObject)
								-- 普通销毁
								-- UGameObject.DestroyImmediate(self.gameObject)
								-- 对象池回收
								self:RecycleSelfToPool()
								if func then
									func()
								end
						else
								App:applyFunc(ConstData.Hint, "Text", LangData["100029"][LANG])
						end
				end, true)
			else
				-- 震荡
				-- 提醒没有空位置
				App:applyFunc(ConstData.Hint, "Text", LangData["100029"][LANG])
				self.moved = nil
				local oldPosition = self.gameObject.transform.position
				local newPosition = oldPosition + Vector3(0, 0.1, 0)
				local aid = AnimateTween.valueTo(self.gameObject, 0, 1, 0.05, function(tm) 
						self.gameObject.transform.position = oldPosition + (newPosition - oldPosition) * tm
				end)
				aid:setLoopPingPong()
				self:delayedCall(0.33, function(tm) 
					AnimateTween.cancelAllObject(self.gameObject, false)
					self.moved = true
				end)
			end
		else
				App:applyFunc(ConstData.Hint, "Text", LangData["100029"][LANG])
		end
end

-- 生成广告漂浮物
function NormalFloatBehaviour:generateAdsElement()
	if self.reward == nil or IsNil(self.gameObject) then
		return
	end
	-- 获取地块是否足够
	local ret = App:applyFunc(ConstData.MapCore, "getFreeGrid", 1)
	local isCreate = false
	if ret then
		local offset_y = 0
    	local vec = App:applyFunc(ConstData.MapCore, "NearestGridIndex", Vector2(self.gameObject.transform.position.x * 100, (self.gameObject.transform.position.y - offset_y) * 100))
    	local isForce = false
		local lvType = App:applyFunc(ConstData.Level, ConstData.getMapType)
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
	    local pos = superMapUtils:GridIndexConvertToPosition(vv[1], vv[2]) / 100

		-- 地块足够,复制品落地
		App:applyFunc(ConstData.Element, "Generate", {
            data = clone(self.mapData[self.reward]),
            position = pos, 
            x = vv[1], 
            y = vv[2], 
            cellId = self.reward, 
            is_animate = true, 
            moveTo = true, 
            startPosition = startPosition,
            dynamic_data = nil,
            isNew = true,
            tag = "AdsFloat",
            particle = "EffMoveTail3",
        })
        isCreate = true
	else
		-- 地块不足,进入天空泡泡
		local data = {CellId = {self.reward}}
		App:applyFunc(ConstData.Airball, "ProduceAirshipAtCurMap", data)
	end
end

function NormalFloatBehaviour:StopFloat()
	if self.isStop then 
		return 
	end
	self.originScale = self.transform.localScale
	self.transform.localScale = Vector3.zero
	self.isStop = true
end

function NormalFloatBehaviour:ContinueFloat()
	self.isStop = false
	self.transform.localScale = self.originScale
end

return NormalFloatBehaviour