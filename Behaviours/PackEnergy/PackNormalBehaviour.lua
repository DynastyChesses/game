--[[
-- added by lizhe @ 2023/02/11
--]]
local ConstData = require "Game.Data.LocalData.ConstData"
local PackNormalBehaviour = class(BaseBehaviour, "PackNormalBehaviour")

function PackNormalBehaviour:init(content)
    self.content = content
    self.assetPkg = content.assetPkg
end

function PackNormalBehaviour:Awake()
    self.transBoard = UIMgrUtil:find(self.transform, "Board")
    self.textEnergyCount = UIMgrUtil:findAndGetComponent(self.transform, "Board/TextEnergyCount", UIMgrUtil.UIComponent.Text)
    self.textPrice = UIMgrUtil:findAndGetComponent(self.transform, "BtnBuy/TextPrice", UIMgrUtil.UIComponent.Text)
    self.luaNotifier = UIMgrUtil:getLuaNotifier(self.transform)
    if self.luaNotifier then
        self.luaNotifier:AddListener(LuaNotifier.KEY_ONCLICK, self.onClick, self)
    end
end

function PackNormalBehaviour:SetContent(shopPack)
    local goodsInfo = App:applyFunc(ConstData.EnergyShop, "GetGoodsInfo", shopPack.PackID)
    self:Show()
    self.shopPack = shopPack
    self.textPrice.text = App:applyFunc(ConstData.Purchasing, "getLocalPriceByPackId", shopPack.PackID)
    local goodInfo = goodsInfo[1]  -- 奖励只有一个
    local des = LangUtil:get("800027")
    if goodInfo.goodType == 0 then
        local energyIcon = shopPack.EnergyIcon
        des = string.gsub(des, "%%s", energyIcon)
        des = des .. goodInfo.num
        self.textEnergyCount.text = des
    else
        self.textEnergyCount.text = goodInfo.num
    end
    
    SpriteManager:SetUISprite(self.assetPkg, self.transBoard.gameObject, ResCfg.Altas.UIEnergyShop, App:applyFunc(ConstData.EnergyShop, "GetImageByShopPack", shopPack))
end

function PackNormalBehaviour:onClick(args)
    if self.clicked then
        return
    end
    self.clicked = true
    local packId = self.shopPack.PackID
    App:applyFunc(ConstData.EnergyShop, "SetFromPanelView", self.shopPack)
	local function success()
        MM.AdsPlay:adsGradeChangedEvent()
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
		BuyFrom  = Config.UIWindowNames.UIEnergyShop       -- 从何处购买
	}
	App:applyFunc(ConstData.Purchasing, "startBuy", packId, buyData, success, fail)
end

function PackNormalBehaviour:Show()
    if not IsNull(self.gameObject) then
        self.gameObject:SetActive(true)
    end
end

function PackNormalBehaviour:Hide()
    if not IsNull(self.gameObject) then
        self.gameObject:SetActive(false)
    end
end

function PackNormalBehaviour:OnDestroy()
    if self.luaNotifier then
        self.luaNotifier:RemoveListener(LuaNotifier.KEY_ONCLICK, self.onClick, self)
    end
end

return PackNormalBehaviour