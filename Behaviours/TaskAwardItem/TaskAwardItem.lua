--[[
-- added by lizhe @ 2023/02/08
--]]
local ConstData = require "Game.Data.LocalData.ConstData"
local MaxSizeDelta = Vector2(80, 80)
local ExpScale = 0.85
local OtherScale = 0.75
local TaskAwardItem = class(BaseBehaviour, "TaskAwardItem")

function TaskAwardItem:init(content)
    self.content = content
    self.mapData = content.mapData
end

-- func 设置奖励元素内容
-- @param award 奖励字符串
-- @param delimiter 分隔符，该数据以什么符号分割，例 - , |
-- @param isShow 是否直接显示
function TaskAwardItem:setContent(award, delimiter, isShow)
    self.animator = self.transform:GetComponent("Animator")
    self.animator.enabled = false
    local main = self.transform:Find("Main")
    self.canvasGroup = main:GetComponent("CanvasGroup")
    self.itemIcon = main:Find("Icon"):GetComponent("Image")
    self.itemText = main:Find("Icon/Text"):GetComponent("Text")
    local award_list = string.split(award, delimiter)
    local spriteName = award_list[1]
    local award_count = tonumber(award_list[2])
    if self.mapData[spriteName] then
        if self.mapData[spriteName].SpriteName and self.mapData[spriteName].SpriteName ~= "" then
            spriteName = self.mapData[spriteName].SpriteName
        end
    end
    App:applyFunc(ConstData.Sprite, "getSpriteVec55", spriteName, function(sprite) 
        self.itemIcon.sprite = sprite
        self.itemIcon:SetNativeSize()
        local rect = self.itemIcon.transform:GetComponent("RectTransform")
        local size = rect.sizeDelta
        if size.x > MaxSizeDelta.x  or size.y > MaxSizeDelta.y then
            rect.sizeDelta = MaxSizeDelta
        end

        if string.find(spriteName, "exp") then
            rect.sizeDelta = rect.sizeDelta * ExpScale
        else
            rect.sizeDelta = rect.sizeDelta * OtherScale
        end
    end)
    self.itemText.text = tostring("×" .. award_count)
    local rect = self.transform:GetComponent("RectTransform")
    local fitter = self.itemText.transform:GetComponent("ContentSizeFitter")
    fitter:SetLayoutHorizontal()
    local textRect = self.itemText.transform:GetComponent("RectTransform")
    local textX = textRect.sizeDelta.x
    local iconRect = self.itemIcon.transform:GetComponent("RectTransform")
    local iconX = iconRect.sizeDelta.x
    rect.sizeDelta = Vector2(iconX + textX, rect.sizeDelta.y)
    self.canvasGroup.alpha = isShow and 1 or 0
end

function TaskAwardItem:playAnimator(callback, time)
    self.animator.enabled = true
    AnimatorUtil:delayCall(self.animator, function()
        if callback then
            callback()
        end
    end, time)
end

function TaskAwardItem:hide()
    self.animator:SetTrigger(Config.AnimatorTriggerNames.TriggerHide)
end

function TaskAwardItem:getIconPosition()
    return MapUtil:getMainCamera():ScreenToWorldPoint(
        Vector3(self.itemIcon.transform.position.x,
        self.itemIcon.transform.position.y,
        -MapUtil:getMainCamera().gameObject.transform.position.z)) 
end

return TaskAwardItem