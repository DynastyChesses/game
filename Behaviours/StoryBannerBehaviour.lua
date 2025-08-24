local StoryBannerBehaviour = class(BaseBehaviour, "StoryBannerBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local TaleItem = require "Game.Data.LocalData.TaleItem"
-- TODO
function StoryBannerBehaviour:Init(behaviour, position)
	self.behaviour = behaviour
	-- 
	local data = TaleItem[self.behaviour.cellId]
	--
	self.gameObject.transform.position = Vector3(position.x, position.y, 0)
	self.gameObject.transform.localScale = Vector3(0.013, 0.013, 0.013)
	self.luaParam = self.gameObject:GetComponent(typeof(LuaParameter))
	self.button = self.gameObject.transform:Find("TimerBanner/Button")
    self.arrow = self.gameObject.transform:Find("TimerBanner/Arrow")
	-- 处理点击事件
	local luaNotifier = self.gameObject:GetComponent(typeof(LuaNotifier))
    if luaNotifier then
        -- 添加
        luaNotifier:AddListener(LuaNotifier.KEY_ONCLICK, self.onCustomPopupClick, self)
    end
    self.Objects = self.transform:Find("TimerBanner/Objects")
    self.TimerBanner = self.transform:Find("TimerBanner")
    self.timeBannerRect = self.transform:Find("TimerBanner"):GetComponent("RectTransform")
    -- 处理本地化
    App:applyFunc(ConstData.Text,  "deal", self.gameObject)
    -- 数据配置
    if data then
	    self.Describe = data.Describe
	    self.ActiveStory = data.ActiveStory
	    self.Require = data.Require
	    self.Produce = data.Produce
        self.Stone = self.Stone or {}
        self.Icons = self.Icons or {}
        self.Data = self.Data or {}
	    -- 生成
	    -- 逗号分隔
	    local item_arr = string.split(self.Require, ",")
        self.childCount = #item_arr
	    local Icon = self.luaParam:getGameObject("Icon")
        local finishNumber = 0
	    for i = 1, #item_arr do
	    	local icon_data = string.split(item_arr[i], "%|")
	    	-- 生成对象
	    	local IconObj = UGameObject.Instantiate(Icon)
	    	IconObj.transform:SetParent(self.Objects, false)
            self.Stone[icon_data[1]] = {}
	    	-- 更换图标
            local icon = IconObj.transform:Find("Image")
	    	App:applyFunc(ConstData.Sprite, "getSpriteVecUI", icon_data[1], function(sprite, pivot, scale)
                if not sprite then
                    return
                end
                App:applyFunc(ConstData.Sprite, "UICheckSizeDelta", icon.gameObject, sprite, pivot, scale)
            end)
            self.Icons[icon_data[1]] = IconObj
            self.Data[icon_data[1]] = icon_data
            -- 更换数量
            self:redraw(icon_data, IconObj, function(isFinish)
                if isFinish == 1 then
                    finishNumber = finishNumber + 1
                end
            end)
    	end
        if finishNumber == #item_arr then
            if not IsNil(self.button) then
                self.button.gameObject:SetActive(true)
            end
            if not IsNil(self.arrow) then
                self.arrow.gameObject:SetActive(true)
            end
            self:PlayAnimation("idle2", true)
        end
        self:RefreshBanner()
	end
	-- 判断是否是云朵中
	local index = self.behaviour.X + 1 + self.behaviour.Y * self.behaviour.map.cellXCount
	if self.behaviour.map.currentMatrix[index] == "C" then
		-- 隐藏自己localScale
		self.gameObject.transform.localScale = Vector3(0, 0, 0)
        self.__hide = true
	end
end

function StoryBannerBehaviour:PlayAnimation(aniName, loop, callback)
    if not self.behaviour or not self.behaviour.gameObject or self.behaviour.spine == nil then
        return
    end
    SpineManager.Play(self.behaviour.spine.gameObject, aniName, loop)
    if callback then
        local ani_time = SpineManager.getAnimationTime(self.behaviour.spine.gameObject, aniName) or 0
        AnimateTween.delayCall(ani_time, function()
            callback()
        end)
    end
end

function StoryBannerBehaviour:redraw(icon_data, IconObj, func)
    if not IsNil(IconObj) then
        self.behaviour.map.storyStore[self.behaviour.cellId] = self.behaviour.map.storyStore[self.behaviour.cellId] or {}
        self.behaviour.map.storyStore[self.behaviour.cellId][icon_data[1]] = self.behaviour.map.storyStore[self.behaviour.cellId][icon_data[1]] or 0
        local count = tonumber(icon_data[2])
        local color_str = "EA473D"
        self.Stone[icon_data[1]] = {tonumber(self.behaviour.map.storyStore[self.behaviour.cellId][icon_data[1]]), tonumber(count)} 
        self.behaviour.Stone = self.Stone
        if self.behaviour.map.storyStore[self.behaviour.cellId][icon_data[1]] < count then
            -- EA473D 红色
            color_str = "EA473D"
            -- 数量不够
            if not IsNil(self.button) then
                self.button.gameObject:SetActive(false)
            end
            if not IsNil(self.arrow) then
                self.arrow.gameObject:SetActive(false)
            end
            -- 配置高度 188.85
            -- self.TimerBanner:GetComponent("RectTransform").sizeDelta = Vector2(sizeDelta.x, 188.85)
            if func then
                func(0)
            end
        else
            -- 75C13C 绿色
            color_str = "75C13C"
            if func then
                func(1)
            end
        end
        IconObj.transform:Find("Count").gameObject:GetComponent("Text").text = '<color="#'.. color_str ..'">'.. tostring(self.behaviour.map.storyStore[self.behaviour.cellId][icon_data[1]]) ..'</color>/' .. tostring(count)
    end
end

-- button出现动画
function StoryBannerBehaviour:ShowButtonAnimation()
    if not self.button_animate_played then
        self.button_animate_played = true
        App:applyFunc(ConstData.Sound,  "playSound", "switch")
        self.timeBannerRect = self.timeBannerRect or self.transform:Find("TimerBanner"):GetComponent("RectTransform")
        local old_size = self.timeBannerRect.sizeDelta
        local new_size = Vector2(old_size.x, 225)
        self.button = self.button or self.gameObject.transform:Find("TimerBanner/Button")
        self.button.transform.localScale = Vector3(0, 0, 0)
        -- 
        self.button_sp_comp = self.button.transform:Find("sp"):GetComponent("SpriteRenderer")
        self.button_Text_comp = self.button.transform:Find("Text"):GetComponent("Text")
        -- m_OutlineColor
        -- self.button_Text_outline_comp = self.button.transform:Find("Text"):GetComponent("TextOutline")
        -- if not IsNil(self.button_sp_comp) then
        --     self.button_sp_comp.color = Color(self.button_sp_comp.color.r, self.button_sp_comp.color.g, self.button_sp_comp.color.b, 0)
        -- end
        -- if not IsNil(self.button_Text_comp) then
        --     self.button_Text_comp.color = Color(self.button_Text_comp.color.r, self.button_Text_comp.color.g, self.button_Text_comp.color.b, 0)
        -- end
        -- if not IsNil(self.button_Text_outline_comp) then
        --     self.button_Text_outline_comp.m_OutlineColor = Color(self.button_Text_outline_comp.m_OutlineColor.r, self.button_Text_outline_comp.m_OutlineColor.g, self.button_Text_outline_comp.m_OutlineColor.b, 0)
        -- end
        local moveUpAid = AnimateTween.valueTo(self.timeBannerRect.gameObject, 0, 1, 0.28, function(tm)
            self.timeBannerRect.sizeDelta = old_size + (new_size - old_size) * tm
        end)
        moveUpAid:setEase(LeanTweenType.easeOutSine)
        AnimateTween.setCallBack(moveUpAid, function()
            self.button.transform.localScale = Vector3(1.1, 1.1, 1.1)
            -- if not IsNil(self.button_sp_comp) and not IsNil(self.button_Text_comp) and not IsNil(self.button_Text_outline_comp) then
            --     local scaleAid = AnimateTween.valueTo(self.button.gameObject, 0, 1, 0.28, function(tm)
            --         -- self.button.transform.localScale = Vector3.one * tm
            --         -- 按钮出现
            --         self.button_sp_comp.color = Color(self.button_sp_comp.color.r, self.button_sp_comp.color.g, self.button_sp_comp.color.b, tm)
            --         self.button_Text_comp.color = Color(self.button_Text_comp.color.r, self.button_Text_comp.color.g, self.button_Text_comp.color.b, tm)
            --         self.button_Text_outline_comp.m_OutlineColor = Color(self.button_Text_outline_comp.m_OutlineColor.r, self.button_Text_outline_comp.m_OutlineColor.g, self.button_Text_outline_comp.m_OutlineColor.b, tm)
            --     end)
            --     scaleAid:setEase(LeanTweenType.easeOutBack)
            -- end
            if not IsNil(self.arrow) then
                self.arrow.gameObject:SetActive(true)
            end
        end)
    end
end

function StoryBannerBehaviour:RefreshBanner()
    if self.childCount then
        self.childCount = self.Objects.transform.childCount
    end
    self.timeBannerRect = self.timeBannerRect or self.transform:Find("TimerBanner"):GetComponent("RectTransform")
    local width = 193
    local height = 163
    if self.childCount > 2 then
        width = width + (self.childCount - 2) * 85
    end
    if self.button and self.button.gameObject.activeSelf then
        height = 225
    end
    self.timeBannerRect.sizeDelta = Vector2(width, height)
end

function StoryBannerBehaviour:FillIn(cellId, isOnlyData, isShowOnly)
    if isOnlyData or (not isOnlyData and not isShowOnly) then
        -- 增加Story的自身的ID
        self.behaviour.map.storyStore[self.behaviour.cellId] = self.behaviour.map.storyStore[self.behaviour.cellId] or {}
        self.behaviour.map.storyStore[self.behaviour.cellId][cellId] = self.behaviour.map.storyStore[self.behaviour.cellId][cellId] or 0
        self.behaviour.map.storyStore[self.behaviour.cellId][cellId] = self.behaviour.map.storyStore[self.behaviour.cellId][cellId] + 1
        -- 落地
        local mapArr = string.split(self.behaviour.map.levelMap, "/")
        local mapPath = string.split(mapArr[#mapArr], "%.")[1]
        local key = CURRENT_USER .. "_" .. mapPath .. "StroyStore"
        local value = JsonHelper.encode(self.behaviour.map.storyStore)
        CustomPlayerPrefs.SetString(key, value)
    end
    if isShowOnly or (not isOnlyData and not isShowOnly) then
        App:applyFunc(ConstData.Sound,  "playSound", "tale_get")
        local finishNumber = 0
        self:redraw(self.Data[cellId], self.Icons[cellId], function(isFinish) 
            -- 刷新
            if isFinish == 1 then
                local elements = App:applyFunc(ConstData.Element, "scanStoryElement")
                for i = 1, #elements do
                    if not IsNil(elements[i]) then
                        -- 刷新
                        elements[i].needItem = true
                        MapUpdate:addNeedItem(elements[i])
                        elements[i].needItemTime = 0.01
                    end
                end
                -- 根据self.Stone来判断完成情况
                for k, v in pairs(self.Stone) do
                    if v[1] >= v[2] then
                        finishNumber = finishNumber + 1
                    end
                end
            end
        end)
        -- 完成状态
        if self.behaviour and self.behaviour.data.ItemType == "wishingwell" then
            if finishNumber < self.childCount then
                self:PlayAnimation("trigger1", false, function()
                    self:PlayAnimation("idle1", true)
                end)
            else
                self:PlayAnimation("trigger2", false, function()
                    self:PlayAnimation("idle2", true)
                end)
            end
            if finishNumber >= self.childCount then
                if not IsNil(self.button) then
                    self.button.gameObject:SetActive(true)
                end
                self:ShowButtonAnimation()
            end
        else
             if finishNumber >= self.childCount then
                if not IsNil(self.button) then
                    self.button.gameObject:SetActive(true)
                end
                self:PlayAnimation("idle2", true)
                self:ShowButtonAnimation()
            end 
        end
    end
end

function StoryBannerBehaviour:onCustomPopupClick(args)
    if CAMERA_LOCK_SCREEN then
        return
    end
	if self.onClicked then
        return
    end
    self.onClicked = true
    if FakeCorouteInst then
        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 10, function() 
            App:applyFunc(ConstData.Touch, "setStatus", touchList.COMMON)
            self.onClicked = false
        end)
    end
    local text = args:get("text")
   
    App:applyFunc(ConstData.Cloud, "BidCloud", 0.3)
    App:applyFunc(ConstData.Sound,  "playSound", "closeBtn")

    if (App:applyFunc(ConstData.FirstPlayTeach, "OnSeal")) then 
        return
    end

    if NormalUtils.RayCheckCopyColiders(Input.mousePosition) then -- 点到复制品
        return
    end
    debug.log("text:", text)
    local Produce = self.Produce
    if text == "OpenStory" then
        -- 清理生成
        UGameObject.Destroy(self.gameObject)
        local behaviour_tmp = {}
        behaviour_tmp.position = self.behaviour.gameObject.transform.position
        behaviour_tmp.X = self.behaviour.X
        behaviour_tmp.Y = self.behaviour.Y
        if (self.behaviour.tag == "Pointer") then 
            behaviour_tmp.tag = self.behaviour.tag
        end
        if not string.find(self.behaviour.gameObject.name, "WishingWell") then
            self.behaviour:DestroyMySelf(function() 
                -- 生成
                -- Tale01_01
                -- 逗号分隔
                local cellIds = string.split(self.Produce, ",")
                debug.log("cellIds--->", cellIds)
                -- 生成
                App:applyFunc(ConstData.Element, "generateObjectByOutput2", behaviour_tmp, cellIds, function(isFinish) 
                end, true)
            end)
        else
            LOCKED_SCREEN = true
            UI_TOUCH = true
            GlobalDataMgr:SetBIDMove(true)
            local cellIds = string.split(self.Produce, ",")
            -- 该关卡通关,存储奖励以及关卡通关数据
            self:StoryLevelPassDataAction(cellIds)
            -- 禁用
            UGameObject.Destroy(self.gameObject)
            local behaviour_tmp = {}
            behaviour_tmp.position = self.behaviour.gameObject.transform.position
            behaviour_tmp.X = self.behaviour.X
            behaviour_tmp.Y = self.behaviour.Y
            if (self.behaviour.tag == "Pointer") then 
                behaviour_tmp.tag = self.behaviour.tag
            end
            App:applyFunc(ConstData.Sound,  "playSound", "bubbleclick")
            App:applyFunc(ConstData.Camera, "move", self.behaviour.transform.position, function()
                -- self:PlayAnimation("trigger", false, function ()
                   -- self:PlayAnimation("idle2", true)
                    App:applyFunc(ConstData.Element, "generateObjectByOutput2", behaviour_tmp, cellIds, function(isFinish) 
                    -- 检测云朵 TODO
                    end, true)
                -- end)
            end, 5, 1)
           
        end
    elseif text == "banner_click" then
        App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.WISH_TREE_CLICK, {from = "storyBanner", param = {element = self.behaviour}})
    end
    self.onClicked = nil
end

-- 通关存储数据
function StoryBannerBehaviour:StoryLevelPassDataAction(cellIds)
    self.map = self.map or App:get(ConstData.STR_MAP)
    if not self.map then
        return
    end
    local mapArr = string.split(self.map.levelMap, "/")
    local mapPath = string.split(mapArr[#mapArr], "%.")[1]
    local BackPackJson = CustomPlayerPrefs.GetString(CURRENT_USER .. "_" .. mapPath .. "BackPack", "")
    if BackPackJson ~= "" then
        self.backPack = JsonHelper.decode(BackPackJson)
    end
    self.backPack = self.backPack or {}
    if cellIds then
        for i = 1, #cellIds do
            local pack_cell_id = string.gsub(cellIds[i], "Bubble", "")
            self.backPack[pack_cell_id] = self.backPack[pack_cell_id] or 0
            self.backPack[pack_cell_id] = self.backPack[pack_cell_id] + 1
        end
    end
    BackPackJson = JsonHelper.encode(self.backPack)
    CustomPlayerPrefs.SetString(CURRENT_USER .. "_" .. mapPath .. "BackPack", BackPackJson)

    -- local cellsAll = {}
    -- for cellId, num in pairs(self.backPack) do 
    --     for k = 1, num do 
    --         table.insert(cellsAll, cellId)
    --     end
    -- end

    -- local mapName = App:applyFunc(ConstData.Level, "getMapNameByLevelType", ConstData.STR_MASTER)
    -- App:applyFunc(ConstData.Airball, "addAirBallData", nil, mapName, cellsAll, nil, ConstData.STORY_LEVEL)

    -- 存储奖励信息
    -- local airBallName = tostring(math.floor(os.time() + 0.5)) .. tostring(math.random(100, 999))
    -- for k,v in pairs(self.backPack) do
    --     -- 存入气泡
    --     local count = tonumber(v)
    --     local awardTab = {}
    --     for i = 1, count do
    --         table.insert(awardTab, k)
    --     end
    --     App:applyFunc(ConstData.Airball, "saveAirball", airBallName, awardTab)
    --     CustomPlayerPrefs.SetString(CURRENT_USER .. "_StoryAirball", airBallName)
    -- end
    -- 设置该关卡过关
    App:applyFunc(ConstData.StoryCastle, "StoryLevelPass")
end

return StoryBannerBehaviour