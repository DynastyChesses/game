local BubbleBehaviour = class(BaseBehaviour, "BubbleBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"

function BubbleBehaviour:init(...)
	local msg = {...}
	self.from = msg[2]
end

function BubbleBehaviour:Awake()
	self.map = App:applyFunc(ConstData.MapCore, "getMap")
	self.mapData = ClientData:GetInstance():MapData()
end

function BubbleBehaviour:changeSprite()
	if self.cellId then
		-- 使用Sprite
		local spriteName = self.mapData[self.cellId].SpriteName
		App:applyFunc(ConstData.Sprite, "getSpriteVec55", spriteName, function(sprite) 
			self.gameObject.transform:Find("Item"):GetComponent(ConstData.SpriteRenderer).sprite = sprite
		end)
	end
end

-- 进行随机横向移动
function BubbleBehaviour:Update()
	if self.is_ads then 
		if self.gameObject.transform.position.x > 35 then
			local position = self.transform.position
			self.gameObject.transform.position = Vector3(GlobalData.StartPosition.x - 20.0, position.y, position.z)
			return
		end
		if (not App:applyFunc(ConstData.FloatAds,  "GetStop")) then
			self.gameObject.transform.position = self.gameObject.transform.position + Vector3(5 / 20.0 * GlobalData.FlotageSpped, 0, 0) * DeltaTime
		end
	elseif self.cellId ~= nil then
		if self.gameObject.transform.position.x > 35 then
			UGameObject.DestroyImmediate(self.gameObject)
			return
		end
		self.gameObject.transform.position = self.gameObject.transform.position + Vector3(5 / 20.0 * GlobalData.FlotageSpped, 0, 0) * DeltaTime
	end
end

function BubbleBehaviour:ExchangeSprite(spriteName, rewardCellId)
	self.transform:GetComponent(ConstData.SpriteRenderer).color = Color(1, 1, 1, 0)
	self.transform:Find(spriteName).gameObject:SetActive(true)
	self.transform.localScale = Vector3.one * 0.65
 	local rewardTable = {"Timeelf01", "Gem_01", "Coin01_02", "Diamond01_01"}
 	if (not rewardCellId) then
 		self.rewardId = rewardTable[math.random(1, #rewardTable)]
 	else
 		self.rewardId = rewardCellId
 	end

end

function BubbleBehaviour:AdsFloatGenerate(rewardId)
	local count = App:applyFunc(ConstData.Element, "Area", rewardId)
	local ret = App:applyFunc(ConstData.MapCore, "getFreeGrid", count)
	if ret then
		self.moved = nil
		App:applyFunc(ConstData.Task,  "onceTask", "TapFloat")
		App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Bubble", param = {"TapFloat"}})
		-- 当前对象处理
		local generateCellId = rewardId or "Building01_01"
		local generatePosition = nil
		if (not self.gameObject) then 
			generatePosition = Vector3.zero
		else
			generatePosition = self.gameObject.transform.position
		end
		App:applyFunc(ConstData.Element, "generateObjectByBall", self, generatePosition, {generateCellId}, function(isFinish) 
			if isFinish then
				if (self.gameObject) then
					UGameObject.DestroyImmediate(self.gameObject)
				end
			end
		end, true)
	end
end

function BubbleBehaviour:DisAppear()
	if (IsNil(self.transform)) then return end
	local aid = LeanTween.scale(self.gameObject, Vector3.zero, 0.33)
	AnimateTween.setCallBack(aid, function()
		if (self.gameObject) then
			UGameObject.DestroyImmediate(self.gameObject)
		end
	end)
end

function BubbleBehaviour:SetMoveProperties(value)
	self.moved = value
end

function BubbleBehaviour:generate(func)
	if self.key == "MASTER_ADS" then 
		if FakeCorouteInst then
	        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
				if Global.SEAL_OPEN then
					return
				end
				UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIAdsRewardsPanel, {"expend"}, self)
			end)
		end
		return
	end
	App:applyFunc(ConstData.Sound,  "playSound", "bubbleclick")
	-- 通过cellId
	if self.cellId then
		local count = App:applyFunc(ConstData.Element, "Area", self.cellId)
		local ret = App:applyFunc(ConstData.MapCore, "getFreeGrid", count)
		if ret then -- 
			self.moved = nil
			App:applyFunc(ConstData.Task,  "onceTask", "TapFloat")
			App:applyFunc(ConstData.DailyTask,  "CompleteDailyTask", "Float", 1)
			App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Bubble", param = {"TapFloat"}})
			-- 当前对象处理
			self.cellId = string.split(self.cellId, "%.")
			if #self.cellId > 0 then
				self.cellId = self.cellId[math.random(1, #self.cellId)]
			end
			App:applyFunc(ConstData.Element, "generateObjectByBall", self, self.gameObject.transform.position, {self.cellId}, function(isFinish) 
				if isFinish then
					UGameObject.DestroyImmediate(self.gameObject)
					if func then
						func()
					end
				else
					App:applyFunc(ConstData.Hint, "Text", LangData["100029"][LANG])
					-- self:RefreshBubbleView()
				end
			end, true)
		else
			-- 震荡
			-- 提醒没有空位置
			App:applyFunc(ConstData.Hint, "Text", LangData["100029"][LANG])

			self.moved = nil
			local oldPosition = self.gameObject.transform.position
			local newPosition = oldPosition + Vector3(0, 0.1, 0)
			local aid = AnimateTween.moveToV3(self.gameObject, newPosition, 0.05)
			aid:setLoopPingPong()
			self:delayedCall(0.33, function(tm) 
				AnimateTween.cancelAllObject(self.gameObject)
				self.moved = true
			end)
		end
	else
		-- 100029
		App:applyFunc(ConstData.Hint, "Text", LangData["100029"][LANG])
		-- 删除
		self:SwitchBubbleAni("storage_adventure_dianji", false, function()
			UGameObject.DestroyImmediate(self.gameObject)
			if func then
				func()
			end
			self:SwitchBubbleAni("storage_adventure1", true)
		end)
	end
end

function BubbleBehaviour:SwitchBubbleAni(aniName, loop, callback)
	if IsNil(self.gameObject) then
		return
	end
	self.bubble = self.bubble or self.transform:Find("Bubble")
	SpineManager.Play(self.gameObject, aniName, loop)
	SpineManager.Play(self.bubble.gameObject, aniName, loop)
	SpineManager.RegisterAnimationCallback(self.gameObject, function(obj, name, index)
       	if callback then
       		callback()
       	end
    end)
end

-- 处理bubble有部分物体已经实例化到场景,但是气泡内并没有刷新
-- function BubbleBehaviour:RefreshBubbleView()
-- 	local balls_output_json = CustomPlayerPrefs.GetString(CURRENT_USER .. "_BALLS_OUTPUT", "")
--      -- Keys
--     local balls_output = {}
--     if balls_output_json ~= "" then
--         balls_output = JsonHelper.decode(balls_output_json)
--     end
--     if balls_output[tostring(self.gameObject.name)] then
--         self.current_output = balls_output[tostring(self.gameObject.name)]
--     end
--     if self.current_output == nil or #self.current_output == 0 then
--     	return
--     end
--     -- 先删除再排序
--     local followBone = self.gameObject.transform:Find("FollowBone")
--     local childCount = followBone.gameObject.transform.childCount
--     local removeObjs = {}
--     local current_output = clone(self.current_output)
--     for i = 0, childCount - 1  do
-- 		local spriteRender = followBone.transform:GetChild(i):GetComponent(ConstData.SpriteRenderer)
-- 		if spriteRender and spriteRender.sprite ~= nil  then
-- 			local isContains, key = self:contains(current_output, spriteRender.sprite.name)
--     		if not isContains then
--     				removeObjs[#removeObjs + 1] = spriteRender.gameObject
--     		else
--     			table.removebyvalue(current_output, key)
--     		end
-- 		end
--     end
--     for i = 1, #removeObjs do
-- 		UGameObject.DestroyImmediate(removeObjs[i])
--     end
--     childCount = followBone.gameObject.transform.childCount
-- 	local curIndex = 0
-- 	local fowardPosition = App:applyFunc(ConstData.Airball,  "getGoodsTopFivePosition", childCount)
-- 	-- 更新动效的显示
-- 	for i = 0, childCount - 1 do
-- 		local childItem = followBone.transform:GetChild(i)
-- 		if (childItem) then
-- 			if i < 5 then
-- 				curIndex = curIndex + 1
-- 				local endPos = curIndex <= 5 and fowardPosition[curIndex]
-- 				if endPos.x < 0 then
-- 					endPos.x = endPos.x + 0.1
-- 				end
-- 				if endPos.x > 0 then
-- 					endPos.x = endPos.x - 0.1
-- 				end
-- 				if endPos.y < 0 then
-- 					endPos.y = endPos.y + 0.1
-- 				end
-- 				if endPos.y > 0 then
-- 					endPos.y = endPos.y - 0.1
-- 				end
-- 				AnimateTween.moveToLocal3(childItem.gameObject, endPos, 0.1)
-- 			else 
-- 				childItem.transform.localPosition = Vector3(math.random(-100, 100) / 400.0, math.random(-100, 100) / 400.0, 0)
-- 			end
-- 		end
-- 	end
-- end

function BubbleBehaviour:contains(tab, value)
	local isContains = false
	local key = nil
	if tab == nil or #tab == 0 or value == "" then return false end
	for i = 1, #tab do
		if string.find(value, tab[i]) then
			isContains = true
			key = tab[i]
			break
		end
	end
	return isContains, key
end

return BubbleBehaviour