local ConstData = require "Game.Data.LocalData.ConstData"

local PackEntranceBehaviour = class(BaseBehaviour, "PackEntranceBehaviour")
function PackEntranceBehaviour:init(view, uiWindowName, entrance, groupID)
    self.view = view
    self.assetPkg = self.view.assetPkg
    self.uiWindowName = uiWindowName
    self.entrance = entrance
    self.groupID = groupID
end

function PackEntranceBehaviour:Awake()
    self.luaNotifier = self.gameObject:GetComponent("LuaNotifier")
    self.luaNotifier:AddListener(LuaNotifier.KEY_ONCLICK, self.onClick, self)
    local panel = UIMgrUtil:find(self.transform, "Panel")
    if self.entrance then
        SpriteManager:SetUISprite(self.assetPkg, panel.gameObject, ResCfg.Altas.UIMainView, self.entrance.EntrancePanel, true)
        local goIcon = UIMgrUtil:find(panel, "Icon").gameObject
        SpriteManager:SetUISprite(self.assetPkg, goIcon, ResCfg.Altas.UIMainView, self.entrance.EntranceIcon, true)
        self.animator = UIMgrUtil:getAnimator(goIcon)
        self.textTitle = UIMgrUtil:getText(panel, "TitleBoard/TextTitle")
        self.goMetion = UIMgrUtil:find(panel, "metion").gameObject
        if self.entrance.LabelType == 2 then
            self.textTitle.text = LangUtil:get(self.entrance.LabelInfo)
        end
    end
end

function PackEntranceBehaviour:refreshUI()
    if self.uiWindowName == Config.UIWindowNames.UIEnergyFund then
        self.goMetion:SetActive(App:applyFunc(ConstData.EnergyFund, "IsShowPoint", self.groupID))
    elseif self.uiWindowName == Config.UIWindowNames.UIChainTreasure then
        local active = App:applyFunc(ConstData.ChainTreasure, "GetFirstTypeIsFree")
	    self.goMetion:SetActive(active)
    end
end

function PackEntranceBehaviour:countDown(countDowntr)
	self.textTitle.text = countDowntr
end

function PackEntranceBehaviour:onClick(args)
    if self.uiWindowName == Config.UIWindowNames.UIEnergyFund then
        App:applyFunc(ConstData.EnergyFund, "OpenUIEnergyFund", self.groupID, true)
    elseif self.uiWindowName == Config.UIWindowNames.UIChainTreasure then
        App:applyFunc(ConstData.ChainTreasure, "OpenUIChainTreasure")
    end
end

function PackEntranceBehaviour:OnDestroy()
    self.luaNotifier:RemoveListener(LuaNotifier.KEY_ONCLICK, self.onClick, self)
end

return PackEntranceBehaviour