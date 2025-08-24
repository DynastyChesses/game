local SeasonSeedBehaviour = class(BaseBehaviour, "SeasonSeedBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local ScaleBubble = 0.65
local AniList = {
    kAppear = "appear",
    kIdle = "idle",
    kDisappear = "receive"
}
function SeasonSeedBehaviour:init(...)
    local msg = {...}
    self.controler = msg[1]
end

function SeasonSeedBehaviour:initData(data)
    self:updateData(data) 
    self:addDrag()
    self.transform.localScale = Vector3(ScaleBubble, ScaleBubble, 1)
    local spine = self.transform:Find("spine").gameObject
    self.endCall = function(obj, name, index)
        if name == AniList.kAppear then 
            self:playIdle(math.random()) 
        elseif name == AniList.kDisappear then 
            self:destroySelf()
        end
    end
    self.eventCall = function()
    end
    self.spineObj = spine
    SpineManager.RegisterAnimationCallback(spine, self.endCall, self.eventCall)
end

function SeasonSeedBehaviour:destroySelf()
    if self.gameObject then 
        SpineManager.UIRegisterAnimationCallback(self.spineObj, self.endCall, self.eventCall)
        UGameObject.Destroy(self.gameObject)
    end
end

function SeasonSeedBehaviour:updateData(data)
    if data ~= self.data then
        self.data = data
        self.transform.position = Vector3(data.x, data.y, data.z)
    end
end

function SeasonSeedBehaviour:playAppear()
    SpineManager.Play(self.spineObj, AniList.kAppear, false)
    App:applyFunc(ConstData.Sound,  "playSound", "getBubble")
end

function SeasonSeedBehaviour:playIdle(progress)
    if progress then 
        SpineManager.Play(self.spineObj, AniList.kIdle, true, progress) 
    else
        SpineManager.Play(self.spineObj, AniList.kIdle, true) 
    end
end

function SeasonSeedBehaviour:playDisappear()
   SpineManager.Play(self.spineObj, AniList.kDisappear, false) 
end

function SeasonSeedBehaviour:addDrag()
    BaseLogic:GetInstance():AddDrag(self, {
        ["begin"] = self.onDragBegin,
        ["moving"] = self.onDragMoving,
        ["ended"] = self.onDragEnd
    })
end

function SeasonSeedBehaviour:canDrag()
    if (UI_COUNT and UI_COUNT > 0) then
        return false
    end
    if self.isLock then 
        return false
    end
    return true
end

function SeasonSeedBehaviour:isOutMap(gameObject)
    if gameObject then
        local vec_world = gameObject.transform.position
        local B_MAP_LEFT = (_MAP_LEFT or -45.5) + 0.1
        local B_MAP_RIGHT = (_MAP_RIGHT or 16.5) - 0.1
        local B_MAP_UP = (_MAP_UP or -6) - 0.1
        local B_MAP_DOWN = (_MAP_DOWN or -54.0) + 0.1
        local is_recover = false
        if vec_world.x < B_MAP_LEFT then
            vec_world = Vector3(_MAP_LEFT, vec_world.y, vec_world.z)
            is_recover = true
        end
        if vec_world.x > B_MAP_RIGHT then
            vec_world = Vector3(_MAP_RIGHT, vec_world.y, vec_world.z)
            is_recover = true
        end
        if vec_world.y > B_MAP_UP then
            vec_world = Vector3(vec_world.x, _MAP_UP, vec_world.z)
            is_recover = true
        end
        if vec_world.y < B_MAP_DOWN then
            vec_world = Vector3(vec_world.x, _MAP_DOWN, vec_world.z)
            is_recover = true
        end
        gameObject.transform.position = Vector3(vec_world.x, vec_world.y, -0.01)
        return is_recover
    end
    return false
end

function SeasonSeedBehaviour:onDragBegin(gameObject, position)
    if not self:canDrag() then return end
    self.controler.map.dragObject = self
    self.touchBeginPosition = Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.01)
    self.touchBeginTime = os.time() 
end

function SeasonSeedBehaviour:onDragMoving(gameObject, position)
    if not self:canDrag() then return end
    App:applyFunc(ConstData.Camera,  "DragAdjustCamera", gameObject, UTime.time)
    self.transform.position = Vector3(self.transform.position.x, self.transform.position.y, -0.01)
end

function SeasonSeedBehaviour:onDragEnd(gameObject, position)
    self.controler.map.dragObject = nil
    local touchList = App:applyFunc(ConstData.Touch, "getStatusList")
    -- App:applyFunc(ConstData.Touch, "setStatus", touchList.POPUP_CLICK) 
    if FakeCorouteInst then
        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 10, function() 
            App:applyFunc(ConstData.Touch, "setStatus", touchList.COMMON)
        end)
    end
    -- 防止ui穿透
    if IsNil(gameObject) then
        return
    end

    -- 检查是否超出地图边界 
    if self:isOutMap(gameObject) then
        self:syncPosition()
        return
    end

    if not self:canDrag() then return end

    self.touchBeginPosition = self.touchBeginPosition or gameObject.transform.position
    local distance = (gameObject.transform.position - self.touchBeginPosition).magnitude
    self.touchBeginTime = self.touchBeginTime or os.time()
    local offsetTime = os.time() - self.touchBeginTime
    App:applyFunc(ConstData.Cloud, "BidCloud", 0.2)
    if offsetTime <= 0.1 and distance < 0.1 then
        self:onClickObj()
    else
        self.transform.position = Vector3(self.transform.position.x, self.transform.position.y, -0.01)
        self:syncPosition()
    end   
end

function SeasonSeedBehaviour:syncPosition()
    if self.data then 
        self.data.x = self.transform.position.x
        self.data.y = self.transform.position.y
        self.controler:saveAction()
    end
end

function SeasonSeedBehaviour:onClickObj()
    App:applyFunc(ConstData.Sound,  "playSound", "bubbleclick")
    self.controler:onSeasonSeedClick(self)
end

function SeasonSeedBehaviour:setLock(value)
   self.isLock = value 
end

function SeasonSeedBehaviour:playCollect(pos, speed, callback)
    self:setLock(true)
    local time = Vector3.Distance(pos, self.transform.position)
    local aid = AnimateTween.moveToV3(self.gameObject, pos, time)
    aid:setEase(LeanTweenType.easeOutSine)
    aid:setSpeed(speed)
    AnimateTween.setCallBack(aid, function()
        self:setLock(false)
        if self.gameObject then 
            self.gameObject.transform.transform.position = pos
        end
        if callback then 
            callback()
        end
    end)
end

return SeasonSeedBehaviour