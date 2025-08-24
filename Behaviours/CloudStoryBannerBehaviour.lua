-- CloudStoryBannerBehaviour
local CloudStoryBannerBehaviour = class(BaseBehaviour, "CloudStoryBannerBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local TaleItem = require "Game.Data.LocalData.TaleItem"
-- TODO
function CloudStoryBannerBehaviour:Init(position, cloudname, ani)
	self.gameObject.transform.position = Vector3(position.x, position.y, 0)
    if ani then
        self.gameObject.transform.localScale = Vector3.zero
        local aniAid = AnimateTween.scaleTo(self.gameObject, Vector3.one * 0.013, 0.5)
        aniAid:setEase(LeanTweenType.easeOutSine)
        AnimateTween.setCallBack(aniAid, function()
            self.gameObject.transform.position = Vector3(position.x, position.y, 0)
        end)
    else
        self.gameObject.transform.localScale = Vector3(0.013, 0.013, 0.013)
    end
	-- 处理点击事件
	local luaNotifier = self.gameObject:GetComponent(typeof(LuaNotifier))
    if luaNotifier then
        -- 添加
        luaNotifier:AddListener(LuaNotifier.KEY_ONCLICK, self.onCustomPopupClick, self)
    end
    self.cloudname = cloudname
    -- 处理本地化
    App:applyFunc(ConstData.Text,  "deal", self.gameObject)
end

function CloudStoryBannerBehaviour:onCustomPopupClick(args)
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
    -- npc_01_story_01
    if text == "OpenCloud" then
        if not IsNil(self.gameObject) then
            self.gameObject:SetActive(false)
        end
    	App:applyFunc(ConstData.MapArea, "unlockLevelCloud", self.cloudname)
    	-- 删除自己
    	UGameObject.Destroy(self.gameObject)
    end
    self.onClicked = nil
end
return CloudStoryBannerBehaviour