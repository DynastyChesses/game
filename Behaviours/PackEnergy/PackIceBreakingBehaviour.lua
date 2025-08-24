--[[
-- added by lizhe @ 2023/02/11
--]]
local ConstData = require "Game.Data.LocalData.ConstData"
local ClockTimeBehaviour = require "Game.Behaviours.ClockTimeBehaviour"
local LanguageData = require "Game.Data.LocalData.LanguageData"
local PackIceBreakingBehaviour = class(BaseBehaviour, "PackIceBreakingBehaviour")

function PackIceBreakingBehaviour:init(content)
    self.content = content
end

function PackIceBreakingBehaviour:Awake()
    self.clockTime = UIMgrUtil:find(self.transform, "ClockRoot/ClockTime")
    self.halfSaleSkel = UIMgrUtil:findAndGetComponent(self.transform, "HalfSaleSkel", UIMgrUtil.UIComponent.SkeletonGraphic)
    self.textEnergyCount = UIMgrUtil:findAndGetComponent(self.transform, "TextEnergyCount", UIMgrUtil.UIComponent.Text)
    local btnBuy = UIMgrUtil:findAndGetComponent(self.transform, "BtnBuy", UIMgrUtil.UIComponent.Button)
    self.textOriginPrice = UIMgrUtil:findAndGetComponent(btnBuy.transform, "TextOriginPrice", UIMgrUtil.UIComponent.Text)
    self.textFinalPrice = UIMgrUtil:findAndGetComponent(btnBuy.transform, "TextFinalPrice", UIMgrUtil.UIComponent.Text)
    
    self.luaNotifier = UIMgrUtil:getLuaNotifier(self.transform)
    if self.luaNotifier then
        self.luaNotifier:AddListener(LuaNotifier.KEY_ONCLICK, self.onClick, self)
    end
    self.clockTimeBehaviour = BehaviourUtil.AddBehaviourV2(self.clockTime, ClockTimeBehaviour, self)
    self.aniSuffix = LanguageData[LANG] or "_c" -- 动画后缀,默认为英语
end

function PackIceBreakingBehaviour:SetContent(shopPack)
    self.shopPack = shopPack
    self:Show()
    self.dataMsg = {}
    local dataMsg = {}
    if self.dataMsg.energy_pack then
        dataMsg = self.dataMsg.energy_pack
    end
    self.clockTimeBehaviour:GetTick(dataMsg, function()
        self:Hide()
        App:applyFunc(ConstData.EnergyShop, "AddEnergyShopPackIceBreak", shopPack.ID, true)
    end)
    local goodsInfo = App:applyFunc(ConstData.EnergyShop, "GetGoodsInfo", shopPack.PackID)
    SpineManager.UIReset(self.halfSaleSkel.gameObject)
    SpineManager.UIPlay(self.halfSaleSkel.gameObject, "bargain_1" .. self.aniSuffix, false)
    SpineManager.UIRegisterAnimationCallback(self.halfSaleSkel.gameObject, function(obj, name, number)
        SpineManager.UIPlay(self.halfSaleSkel.gameObject, "bargain_2" .. self.aniSuffix, true)
	end, function()

	end)
    self.textOriginPrice = App:applyFunc(ConstData.Purchasing, "getLocalPriceByPackId", shopPack.PackID, true)
    self.textFinalPrice = App:applyFunc(ConstData.Purchasing, "getLocalPriceByPackId", shopPack.PackID)
    self.textEnergyCount.text = goodsInfo[1].num
end

function PackIceBreakingBehaviour:onClick(args)
    if self.clicked then
        return
    end
    self.clicked = true
    local packId = self.shopPack.PackID
    App:applyFunc(ConstData.EnergyShop, "SetFromPanelView", self.shopPack)
	local function success()
		self.clicked = false
	end
	local function fail()
		self.clicked = false
        App:applyFunc(ConstData.EnergyShop, "SetFromPanelView")
	end
	local lvty = App:applyFunc(ConstData.Level, ConstData.getMapType)
	local buyData = {
        RelatedPackSystem = self.shopPack.RelatedPackSystem, -- 是否关联礼包
		BuyScene = lvty ,       -- 购买场景
		BuyFrom  = Config.UIWindowNames.UIPackEnergyPannel       -- 从何处购买,这个地方走礼包的逻辑
	}
	App:applyFunc(ConstData.Purchasing, "startBuy", packId, buyData, success, fail)
end

function PackIceBreakingBehaviour:Show()
    if not IsNull(self.gameObject) then
        self.gameObject:SetActive(true)
    end
end

function PackIceBreakingBehaviour:Hide()
    if not IsNull(self.gameObject) then
        self.gameObject:SetActive(false)
    end
end

function PackIceBreakingBehaviour:OnDestroy()
    if self.luaNotifier then
        self.luaNotifier:RemoveListener(LuaNotifier.KEY_ONCLICK, self.onClick, self)
    end
end

return PackIceBreakingBehaviour