-- @author  tomyuan
-- @datetime 2021.04.25
-- @datetime 2021.06.10 update by tomyuan
-- @datetime 2021.06.15 update by tomyuan 重构结构
-- @datetime 2021.06.16 根绝新版本的数据，重写Common Map @tomyuan
-- @datetime 2021.07.19 优化 by tomyuan
-- @detetime 2022.08.06 针对drag进行优化 by tomyuan
-- @desc 通用地图类
local MapBehaviour          = class(BaseBehaviour, "MapBehaviour")
local superMapUtils = SuperMapUtils.Instance
-- 变量
local current               = nil
local ConstData = require "Game.Data.LocalData.ConstData"

-- 地图初始化，在Awake之前
function MapBehaviour:init(...) 
    -- param init
    local param = {...}
    if param[2] then
        self.levelMap = param[2]
    end
    if param[3] then
        self.initCallBack = param[3]
    end
    self.abs = math.abs
    if MapUtil:getMainCamera() then
        self.mainCamera = MapUtil:getMainCamera()
    end
    -- 来自于曾经的关卡
    local isCommingFromLevel = App:applyFunc(ConstData.Level,  "isComingFromLevel")
    current = self
    GlobalDataMgr:SetBIDMove(false)
    CAMERA_LOCK_SCREEN = false
    self.mapData = ClientData:GetInstance():MapData()
    self.storyCastleData = ClientData:GetInstance():StoryCastleData()

    self.activityProp = clone(require "Game.Data.LocalData.ActivityData.ActivityProp")

end

function MapBehaviour:Awake()
    App:applyFunc(ConstData.Sound, "getVibrateSetting")
    -- 第一次获取
    local first_timestamp = UPlayerPrefs.GetInt(CURRENT_USER .. "_FIRST_TIMESTAMP", -1)
    if first_timestamp < 0 then
        -- 存储
        local time = math.ceil(os.time())
        UPlayerPrefs.SetInt(CURRENT_USER .. "_FIRST_TIMESTAMP", time)
    end
    -- 加载场景预设
    coroutine.start(function() 
        self:PreloadSceneElements()
        -- if self.model then
            Start:GetInstance():set(ConstData.STR_MAP, self)
            self.touched = false
            self.forceBack = false -- 是否强制物体返回原来的位置
            self.currentMousePosition = Vector3.zero
            self.highingTile = {}
            self.decelerationRate = 0.0008
            -- self.speed = Vector3.zero
            --
            App:applyFunc(ConstData.Bubble, "clearCurrentFloat")
            App:applyFunc(ConstData.UserLimit,  "StartLimitUser")
            MapLoadingUtil:addProgress(0.01)
            coroutine.waitforframes(FRAME_ONE)
            -- 加载Stage
            self:LoadStage(function()
                -- 地图加载是否完车
                self:MapInit()
                self:ObjectsInit()
                MapLoadingUtil:addProgress(0.01, LangUtil:get("700033")) --"Loading service!"
                coroutine.waitforframes(FRAME_ONE)
                MapUpdate:SetMap(self)
                MM:setMap(self)
                local services = ServiceManager:GetInstance():allServices()
                for k, v in pairs(services) do
                    local serviceName = string.gsub(k, "Service", "")
                    App:applyFunc(serviceName, "setMap", self)
                end
                App:applyFunc(ConstData.Purchasing, "onAllMapSet")
                -- 去除无用的气泡位置信息
                -- App:applyFunc(ConstData.Airball, "removeUnuselessPositions")
                -- 设置/更新UserData里面的map
                ClientData:GetInstance():CheckMap()
                MapLoadingUtil:addProgress(0.01, LangUtil:get("700034")) -- "Loading popups!"
                coroutine.waitforframes(FRAME_ONE)
                App:applyFunc(ConstData.Popup, "loadAsync", function()
                    MapLoadingUtil:addProgress(0.01, LangUtil:get("700035")) -- "Loading levels!"
                    -- 相机移动
                    local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
                    if lvType == ConstData.STR_MASTER then
                        -- App:applyFunc(ConstData.Bubble, "setCurrentFloat", {"MASTER_SEED"}, math.random(30, 60))
                        -- App:applyFunc(ConstData.Bubble, "setCurrentFloat", {"MASTER_ADS"}, math.random(30, 60))
                        --
                        local nextPos = App:applyFunc(ConstData.MapArea, "getStartPosition")
                        if Global.MAIN_POSITION then
                            Global.MAIN_POSITION = Vector2(Global.MAIN_POSITION.x, Global.MAIN_POSITION.y)
                        end
                        self.startMapPosition = Global.MAIN_POSITION or nextPos or Vector2(-24.6, -37.4)
                        Global.MAIN_POSITION = nil
                        -- 相机最新代码
                        if MapUtil:getMainCamera() then
                            local posZ = App:applyFunc(ConstData.Camera, "GetCameraDefaultPosZ")
                            local oldPos = MapUtil:getMainCamera().gameObject.transform.position
                            MapUtil:getMainCamera().gameObject.transform.position = Vector3(oldPos.x, oldPos.y, posZ)
                        end

                        superMapUtils:MoveCameraToPosition(self.startMapPosition)
                    else
                    end
                    coroutine.waitforframes(FRAME_ONE)
                    self:LoadLevelMap()
                    App:applyFunc(ConstData.Camera, "getCameraLastStopPosition")
                    App:applyFunc(ConstData.Airball, "initAirball")

                    coroutine.waitforframes(FRAME_ONE * 5)
                    if self.initCallBack then
                        self.initCallBack()
                    end
                end)
            end)
        -- end
    end)
    self._cellHeight = superMapUtils.cellHeight / 200.0
end

-- 加载预设
function MapBehaviour:PreloadSceneElements()
    -- 普通Element 可以回收
    local elementPath = ResCfg:getPathPrefabs(ResCfg.Prefabs.Element)
    local load_all_count = 1
    local load_count = 0
    GameObjectPool:GetInstance():PreloadObject(elementPath, 10, false, function()
        load_count = load_count + 1
    end)
    coroutine.waituntil(function ()
        return load_count >= load_all_count
    end)
end

-- 加载通用Stage
function MapBehaviour:LoadStage(callback)
    loadAssetAsync("Prefabs/Stage.prefab", typeof(UGameObject), function(go)
        MapLoadingUtil:addProgress(0.01)
        self.Stage = AGameObject.Instantiate(go)
        self.Stage.name = "Stage"
        if callback then
            callback()
        end
    end)
end

function MapBehaviour:LoadLevelMap(level, callback)
    -- 使用coroutine
    MapLoadingUtil:addProgress(0.01, LangUtil:get("700036")) -- "Loading surface!"
    coroutine.waitforframes(FRAME_ONE)
    loadAssetAsync("Prefabs/Water.prefab", typeof(UGameObject), function(go) 
        self.Water = AGameObject.Instantiate(go)
        self.Water.name = "Water"
        self.Water.transform:SetParent(self.Stage.transform, true)
    end)
    MapLoadingUtil:addProgress(0.01, LangUtil:get("700037")) -- "Loading objects!"
    coroutine.waitforframes(FRAME_ONE)

    App:applyFunc(ConstData.SeasonSeed, "initViwByData")
    self:initMartix()

    local lvType = App:applyFunc(ConstData.Level, ConstData.getMapType)
    if lvType == ConstData.STR_MASTER then
        -- 判断当前是否有RunningTask
        local runningTaskPool = App:applyFunc(ConstData.Task, "RunningTaskPool")
        if #runningTaskPool == 0 then
            UIManager:GetInstance():CloseView(Config.UIWindowNames.UITaskBar)
        end
        -- 云朵恢复
        App:applyFunc(ConstData.Cloud, "recoverClick")
        -- 不理会完成状态
        App:applyFunc(ConstData.Task,  "refreshToolBar")
    end
    App:applyFunc(ConstData.Time,  "storeVisitTime")
    coroutine.waitforframes(FRAME_ONE)
    MapLoadingUtil:addProgress(0.01, LangUtil:get("700038")) -- "Loading sounds!"
    App:applyFunc(ConstData.Sound,  "playBackgroudMusic", "BG02")
    App:applyFunc(ConstData.MapArea, "loadHash")
    -- App:applyFunc(ConstData.SeasonSeed, "initViwByData")
end

function MapBehaviour:MapInit()
    -- setStartPosition
    local nextPos = App:applyFunc(ConstData.MapArea, "getStartPosition")
    local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    App:applyFunc(ConstData.MapArea, "clearStartPosition")
    -- 相机初始化
    self.camera = MapUtil:getMainCamera().gameObject
    if self.camera then
        self.cameraComp = self.camera:GetComponent(typeof(UCamera))
        self.transform = self.camera:GetComponent(typeof(UTransform))
        self._luaParam = self.camera:GetComponent(typeof(LuaParameter))
    end
end

function MapBehaviour:ObjectsInit()
    self.locksTr = self.Stage.transform:Find("Locks")
    if not IsNil(self.locksTr) then
        self.locks = self.locksTr.gameObject
    end
    self.elementParentTr = self.Stage.transform:Find("Elements")
    if not IsNil(self.elementParentTr) then
        self.elementParent = self.elementParentTr.gameObject
    end
    self.cloudParentTr = self.Stage.transform:Find("Clouds")
    if not IsNil(self.cloudParentTr) then
        self.cloudParent = self.cloudParentTr.gameObject
    end
end

-- 初始化地图矩阵
function MapBehaviour:initMartix()
    -- 地图是否加载完成
    self.loadMapOver = false
    -- 初始化当前矩阵,包含所有内容
    self.currentMatrix = {}
    -- 表示空格
    self.emptyMatrix = {}
    -- 当前云
    self.currentLockMatrixCloud = {}
    -- 当前障碍锁区
    self.currentLockArea = {}
    -- 当前可活动区域
    self.currentAreas = {}
    -- 临时存储去
    self.tempMatrix = {}
    --
    self.wallMatrix = {}
    -- 
    self.npcs = {}
    -- 地图基本信息
    self.cellXCount = MapUtil:getMaxX() 
    self.cellYCount = MapUtil:getMaxY() 
    self.cellWidth = MapUtil:getCellWidth()
    self.cellHeight = MapUtil:getCellHeight()
    -- 配置地图的矩阵和锁矩阵
    for i = 1, self.cellXCount * self.cellYCount do
        self.currentMatrix[i] = ""
        self.currentLockMatrixCloud[i] = ""
        self.emptyMatrix[i] = true
    end

    -- 判断是否有当前缓存的数据
    local mapArr = string.split(self.levelMap, "/")
    local mapPath = string.split(mapArr[#mapArr], "%.")[1]
    local First = CustomPlayerPrefs.GetString(CURRENT_USER  .. "_" .. LocalData.First .. "V2", "")

    if First == ""  then    -- 
        -- 没有数据，加载新数据
        self:startNewMap()
    else
        -- 不需要验证数据
        self:startLoadMap()
    end
    App:applyFunc(ConstData.RedPoint,  "RefreshFlag")
    self:dcEnterMap(First == "", mapPath)
end

-- func 进入地图打点
function MapBehaviour:dcEnterMap(isFirst, mapPath)
    local data = {
        label_id = mapPath,
        is_first = isFirst and 1 or 0
    }
    DC:dcWbBI(DCData.enter_map, data)
end

-- 添加npc
function MapBehaviour:AddNpc(cellId, npcElement)
    
    if (not self.npcs[cellId] and npcElement.data["ItemType"] == "npc") then 
        -- debug.log("添加npc", cellId)
        self.npcs[cellId] = npcElement
    end
end

-- 加载当前地图的数据 
function MapBehaviour:startLoadMap()
    -- 在此之前完成Version对比
    App:applyFunc(ConstData.Version, "mainMapRun")
    local t = App:applyFunc(ConstData.Save, "LoadMap")
    -- 版本对比
    local newer = App:applyFunc(ConstData.Version,  "newer")
    newer = newer or {}
    local isFlyup = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeached", "Ph02_Worker_Flyup")
    -- 判断ID
    local onceIDS = {}
    debug.log('newer====>', newer)
    for k, v in pairs(newer) do
        if current.mapData[v] then
            -- 2x2类型
            if current.mapData[v].ItemType == ConstData.STR_CASTLE or current.mapData[v].ItemType == "castlefloor" or current.mapData[v].ItemType == "mine" then
                -- 判断xy
                local pos = string.split(k, ",")
                local x = tonumber(pos[1])
                local y = tonumber(pos[2])
                local index = x + 1 + y * self.cellXCount
                if not onceIDS[v] then
                    onceIDS[v] = {index, k}
                elseif onceIDS[v][1] > index then
                    onceIDS[v] = {index, k}
                end
                newer[k] = nil
            end
        end
    end
    for k, v in pairs(onceIDS) do
        newer[v[2]] = k
    end
    for k, v in pairs(newer) do
        local pos = string.split(k, ",")
        if current.mapData[v] then
            local X = tonumber(pos[1])
            local Y = tonumber(pos[2])
            if type(current.currentMatrix[X + 1 + Y * current.cellXCount]) == ConstData.TABLE_TYPE then
                local cellId = current.currentMatrix[X + 1 + Y * current.cellXCount].cellId
                current.currentMatrix[X + 1 + Y * current.cellXCount]:DestroyMySelf()
            end
            App:applyFunc(ConstData.Element, "Generate", {
                data = clone(current.mapData[v]),
                position = superMapUtils:GridIndexConvertToPosition(tonumber(pos[1]), tonumber(pos[2])) / 100, 
                x = tonumber(pos[1]), 
                y = tonumber(pos[2]), 
                cellId = v, 
                is_animate = nil, 
                moveTo = nil, 
                startPosition = nil,
                dynamic_data = nil,
                isNew = true,
                Createed = true,
                origin_params = {}
            })
        end
    end
    debug.log("isFlyup=====>", isFlyup)
    if isFlyup then
        -- 如果存在
        local element1 = App:applyFunc(ConstData.MapArea, "GetElementByCoordinate", 27, 55)
        local element2 = App:applyFunc(ConstData.MapArea, "GetElementByCoordinate", 28, 55)
        if (element1 and type(element1) == ConstData.TABLE_TYPE) and element1.cellId == "Worker_01" then 
            element1:DestroyMySelfImmediate()
        end
        if (element2 and type(element2) == ConstData.TABLE_TYPE) and element2.cellId == "Worker_01" then 
            element2:DestroyMySelfImmediate()
        end
    end
    coroutine.waitforframes(FRAME_ONE)
    App:applyFunc(ConstData.Cloud, "setAllCloudFlag") -- 刷新云朵数据

    MapLoadingUtil:addProgress(0.01, LangUtil:get("700041")) -- "Loading goods!"
    coroutine.waitforframes(FRAME_ONE)
    -- 91%的进度
    -- -- 新增 2021.08.23
    App:applyFunc(ConstData.MapArea, "loadSpecialArea", t)
    App:applyFunc(ConstData.MapArea, "refreshLockGrid")


    -- 版本对比
    -- 需要清理在重建
    -- 根据Diff处理Locked
    local diff = App:applyFunc(ConstData.Version,  "returnDiff")
    if diff then
        for k2, v2 in pairs(diff) do
            local k2_arr = string.split(k2, ",")
            local X = math.floor(tonumber(k2_arr[1]))
            local Y = math.floor(tonumber(k2_arr[2]))
            if current.currentLockArea[X + 1 + Y * current.cellXCount] then
                -- 删除Element
                if type(current.currentMatrix[X + 1 + Y * current.cellXCount]) == ConstData.TABLE_TYPE then
                    local cellId = current.currentMatrix[X + 1 + Y * current.cellXCount].cellId
                    current.currentMatrix[X + 1 + Y * current.cellXCount]:DestroyMySelf()
                    --
                    App:applyFunc(ConstData.Element, "Generate", {
                        data = clone(current.mapData[cellId]),
                        position = superMapUtils:GridIndexConvertToPosition(tonumber(X), tonumber(Y)) / 100, 
                        x = tonumber(X), 
                        y = tonumber(Y), 
                        cellId = cellId, 
                        is_animate = nil, 
                        moveTo = nil, 
                        startPosition = nil,
                        dynamic_data = nil,
                        isNew = true,
                        Createed = true,
                        origin_params = {}
                    })
                end
            end
        end
    end
    App:applyFunc(ConstData.Version,  "clearDiff")
    -- 缓存池
    self.loadMapOver = true
    -- 存储数据
    MapLoadingUtil:addProgress(0.01, LangUtil:get("700042")) -- "Loading grids!"
    coroutine.waitforframes(FRAME_ONE)
    -- App:applyFunc(ConstData.Cloud, "levelCloudCheck")
    App:applyFunc(ConstData.Cloud, "NearbyCloudDeal")
    -- 存储点
    Global.CanLoadMap = true
end

-- 新地图加载
function MapBehaviour:startNewMap()
    App:applyFunc(ConstData.Version, "mainMapRun")
    local info = superMapUtils:getObjectInfo()
    local t = {}
    t = StructUtils.Instance:GetDictionary(t, info)
    local loginUser = UserDataMgr:GetInstance():GetUser(CURRENT_USER)
    local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    if not loginUser["cloud_load"] then
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700039")) -- "Loading clouds!"
        coroutine.waitforframes(FRAME_ONE)
        if lvType == ConstData.STR_MASTER then
            App:applyFunc(ConstData.MapArea, "newCloud", t)
        elseif lvType == ConstData.STORY_LEVEL then
            App:applyFunc(ConstData.MapArea, "newLevelCloud", t)
        elseif lvType == ConstData.ACTIVITY_LEVEL then
            -- 活动岛云朵 TODO
        end
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700040")) -- "Loading areas!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newArea", t)
        MapLoadingUtil:addProgress(0.01)
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newDisabled", t)
        MapLoadingUtil:addProgress(0.01)
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newLock", t)
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700041"))-- "Loading goods!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newGood", t)

        -- 新增 2021.08.23
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700042"))-- "Loading grids!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newSpecialArea", t)
        App:applyFunc(ConstData.MapArea, "refreshLockGrid")
        App:applyFunc(ConstData.Cloud, "levelCloudCheck")
    else
        -- 更新等级和钥匙
        if loginUser["level"] then
            for i = 1, tonumber(loginUser["level"]) do
                ClientData:GetInstance():upLevel(true)
            end
        end
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700039"))-- "Loading clouds!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "loadCustomCloud", t, loginUser["cloud_load"])

        MapLoadingUtil:addProgress(0.01, LangUtil:get("700040"))-- "Loading areas!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newArea", t)

        MapLoadingUtil:addProgress(0.01)
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newDisabled", t)
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700041"))-- "Loading goods!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "loadCustomLock", t, loginUser["locked_load"])
        App:applyFunc(ConstData.MapArea, "loadCustomGood", loginUser["good_load"])

        -- 新增 2021.08.23
        MapLoadingUtil:addProgress(0.01, LangUtil:get("700042"))-- "Loading grids!"
        coroutine.waitforframes(FRAME_ONE)
        App:applyFunc(ConstData.MapArea, "newSpecialArea", t)
        App:applyFunc(ConstData.MapArea, "refreshLockGrid")
        --
        App:applyFunc(ConstData.Cloud, "levelCloudCheck")
    end
    App:applyFunc(ConstData.Cloud, "NearbyCloudDeal")
    -- 缓存池
    self.loadMapOver = true
    -- 检测存储
    -- 存储点
    Global.CanLoadMap = true
    -- App:applyFunc(ConstData.CacheObjectPool, "CacheObject")
    CustomPlayerPrefs.SetString(CURRENT_USER .. "_" .. LocalData.First .. "V2", "true")
end

function MapBehaviour:checkWall(x, y)
    return false
end

-- 拖拽 此处特别说明 current表示CommonMap, self表示gameobject所属的Behaviour 
function MapBehaviour:DragBegin(gameObject, position)
    local cond = 
        UI_COUNT > 0                                            -- 表示当前界面有UI打开
        or GlobalDataMgr:GetBidMove()                                            -- 全局禁止移动，一般配合UI同时使用
        or App:applyFunc(ConstData.FirstPlayTeach, "OnSeal")    -- 售卖状态
        or App:applyFunc(ConstData.Touch, "isElementDraging")   -- 是否已经执行了Begin ? 这个条件的意义不明确
    cond = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeaching", "Ph06_Castle_Pointer") or cond
    if cond then
        return
    end
    -- 关闭设置按钮
    -- MessageManager:GetInstance():Broadcast(MessageConst.Main_View_Btn_Set)

    App:applyFunc(ConstData.Time, "setOpt")
    -- 增加选择物品的层级
    App:applyFunc(ConstData.MapCore, ConstData.addSortingOrder, self, nil, true)
    -- 记录移动前的位置
    current.previousX = X
    current.previousY = Y
    -- 判断教学状态
    if App:applyFunc(ConstData.FirstPlayTeach, "InForceState") then 
        App:applyFunc(ConstData.FirstPlayTeach, "DragBegin", self)
    end

    -- 移动的fixed
    self.fixed = false
    current.dragObject = self
    current.forceBack = false
    -- 拖动的元素开始播放呼吸
    self:startBreath()
    -- 记录开始位置
    current.dragBeginPosition = gameObject.transform.position
    
    if self.data then
        if self.data[ConstData.Params02] == '' then
            App:applyFunc(ConstData.Sound,  "playSound", "touch")
        end
    end
    -- 存储begin点
    current.beginPosition = position
    current.maxDistance = 0
    current.interactTime = 0
    current.prevPosition = position
    current.playInteractSound = false -- 判断是否出发控感
    current.castleElement = nil       -- 判断是否可否投喂城堡
    current.mergeConfirmState = false -- 合并确认面板状态
    App:applyFunc(ConstData.Touch, "startElementDraging")
    self.dragDuring = 0.0
    -- 取消箭头显示
    self:cancelArrow()
    -- 可投喂城堡逻辑处理
    local canFeed, castleElement = App:applyFunc(ConstData.MapCore, "checkCastleCanFeed", self)
    if canFeed then
        current.castleElement = castleElement
    end
end

-- 此处特别说明 current表示CommonMap, self表示gameobject所属的Behaviour
function MapBehaviour:DragMoving(gameObject, position)
    local cond = 
        not current.mainCamera
        or GlobalDataMgr:GetBidMove()
        or current.forceBack
        or App:applyFunc(ConstData.FirstPlayTeach, "OnSeal")
        or not current.prevPosition
        or not position

    cond = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeaching", "Ph06_Castle_Pointer") or cond
    if cond then
        return
    end
    App:applyFunc(ConstData.Time, "setOpt")
    local input_position = Input.mousePosition
    local speed = current.abs(current.prevPosition.x - input_position.x) + current.abs(current.prevPosition.y - input_position.y) / (DeltaTime * 100.0)
    current.prevPosition = input_position
    -- 计算最大的移动距离
    local distance = (current.abs(position.x - current.beginPosition.x) + current.abs(position.y - current.beginPosition.y)) * 0.75
    if distance and current.maxDistance and distance > current.maxDistance then
        current.maxDistance = distance
    end
    local distance_tmp = current.abs(gameObject.transform.position.x - current.dragBeginPosition.x) + current.abs(gameObject.transform.position.y - current.dragBeginPosition.y) * 0.75
    -- 如果满足下面条件，就是点击地图对象的操作，处理~ 2021.08.22
    if not ((distance_tmp and distance_tmp < 0.1) and (current.maxDistance and current.maxDistance < 0.5)) then
        if not current.playInteractSound then
            current.playInteractSound = true
        end
        if not self.popup_hide_all then
            self.popup_hide_all = true
            -- 当我拖动的时候，关闭所有弹窗
            App:applyFunc(ConstData.Popup, "hideAll")
        end
    end

    -- 位移情况下关闭 合并链提示
    MapUpdate:removeLongPressItemList(self)
    MergeChainUtil:hide()
    self.longPressState = false -- 修改本身状态 不是长按

    -- 如果当前对象非npc，隐藏对话框
    if self.dialog_show and self.data.ItemType ~= "npc" then
        self:hideDialog()
    end

    if current.cameraComp and current.transform then
        local is_grid_align = false
        local vec = current.mainCamera:WorldToViewportPoint(position);
        local x = vec.x
        local y = vec.y
        local offX = 0
        local offY = 0
        if x >= 0.93 then
            -- 相机向右移动
            offX = 0.2
        end
        if x <= 0.08 then
            -- 相机向左移动
            offX = -0.2
        end
        if y >= 0.92 then
            -- 相机向上移动
            offY = 0.2
        end
        if y <= 0.08 then
            -- 相机向下移动
            offY = -0.2
        end
        -- 判断Input
        local inputVec = Input.mousePosition
        if (Input.touchCount > 1) then 
            local input_touches_0 = Input.touches[0]
            inputVec = Vector3(input_touches_0.position.x, input_touches_0.position.y, 0)
        end
        if inputVec.x < 0 or inputVec.x > 10000 then
            inputVec = Vector2(0, inputVec.y)
        end
        if inputVec.y < 0 or inputVec.y > 10000 then
            inputVec = Vector2(inputVec.x, 0)
        end
        local vec_world = current.mainCamera:ScreenToWorldPoint(Vector3(inputVec.x, inputVec.y, -current.camera.transform.position.z)) + Vector3(0, 0.18, 0) -- 策划调整挪动手感
        _MAP_LEFT = _MAP_LEFT or -45.5
        _MAP_RIGHT = _MAP_RIGHT or 16.5
        _MAP_UP = _MAP_UP or -6
        _MAP_DOWN = _MAP_DOWN or -54.0
        if vec_world.x < _MAP_LEFT then
            vec_world = Vector3(_MAP_LEFT, vec_world.y, vec_world.z)
        end
        if vec_world.x > _MAP_RIGHT then
            vec_world = Vector3(_MAP_RIGHT, vec_world.y, vec_world.z)
        end
        if vec_world.y > _MAP_UP then
            vec_world = Vector3(vec_world.x, _MAP_UP, vec_world.z)
        end
        if vec_world.y < _MAP_DOWN then
            vec_world = Vector3(vec_world.x, _MAP_DOWN, vec_world.z)
        end
        -- 求解最近格子的坐标
        local vec = App:applyFunc(ConstData.MapCore, "NearestGridIndex", Vector2(vec_world.x * 100, vec_world.y * 100))
        self.gird_move_index = vec
        self.superMapUtils = self.superMapUtils or superMapUtils
        local vv = self.superMapUtils:GridIndexConvertToPosition(vec.x, vec.y) / 100
        -- 调整移动速率问题
        App:applyFunc(ConstData.Camera,  "DragAdjustCamera", gameObject, UTime.time)
        if math.abs(offX) > 0.01 or math.abs(offY) > 0.01 and not LOCKED_SCREEN then
            if not LOCKED_SCREEN then
                -- 处理到这里了 TODO
                gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = Vector3(-9999, -9999, 0)
            end
        elseif speed > 3 then
            self.fixed = false
            self.dragDuring = 0
            gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = Vector3(-9999, -9999, 0)
        else
            if speed <= 0.3 or self.fixed then
                self.fixed = true
                self.dragDuring = self.dragDuring + DeltaTime
                if self.dragDuring > 0.1 then
                    is_grid_align = true
                    self.newPosition = Vector3(vv.x, vv.y - current._cellHeight, -0.005)
                    gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = self.newPosition
                end
            else
                gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = Vector3(-9999, -9999, 0)
            end
        end
        
        -- 判断连通性
        -- 检测是否在锁区中
        local is_lock = false
        if current.currentLockArea[vec.x + 1 + vec.y * current.cellXCount] then
            is_lock = true
        end
        
        -- 判断位置
        if self.movingX ~= math.floor(vec.x) or self.movingY ~= math.floor(vec.y) then
            self.movingX = math.floor(vec.x)
            self.movingY = math.floor(vec.y)
            -- 
            local isLocked = App:applyFunc(ConstData.Locked,  "get", self.movingX, self.movingY)
            if not is_lock then
                is_lock = isLocked
            end
        end

        local currentTiled = current.currentMatrix[vec.x + 1 + vec.y * current.cellXCount]
        local IsObstacle = nil
        if type(currentTiled) == ConstData.TABLE_TYPE then
            if currentTiled.data then
                IsObstacle = (currentTiled.data.IsObstacle == 1)
            end
        else
            -- 空格子
            App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
        end

        local bigBuilder = false
        if type(currentTiled) == ConstData.TABLE_TYPE and currentTiled.data then
            if table.indexof(LandMarkData, currentTiled.data.ItemType) then    -- currentTiled.data.Grid
                bigBuilder = true
            end
        end
        local check_wall = current:checkWall(vec.x, vec.y)
        if self.data and not table.indexof(LandMarkData, self.data.ItemType) then -- self.data.Grid
            if currentTiled and currentTiled ~= "B" and currentTiled ~= "C" and currentTiled ~= "H" and not IsObstacle and not is_lock and 
                current.currentAreas[vec.x + 1 + vec.y * current.cellXCount] == "Y" and not bigBuilder 
                and self.status ~= StatusConst.QuickWorker and not check_wall and ((type(currentTiled) == ConstData.TABLE_TYPE and (currentTiled.cellId ~= "Base_02" and currentTiled.cellId ~= "Base_01")) or (type(currentTiled) ~= ConstData.TABLE_TYPE)) then
                if currentTiled and currentTiled.data then
                    if currentTiled.data.ItemType == "monster" then
                        -- 禁止区域，切换红色底板
                        for i = 1, #current.highingTile do
                            local behaviour = current.highingTile[i]
                            if behaviour.gameObject.name ~= self.gameObject.name then
                                behaviour:stopBreath()
                                behaviour:StopToCenterGird()
                                if FakeCorouteInst then
                                    FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 1, function() 
                                        if not current.merge_success then
                                            behaviour:ResetPosition()
                                        end
                                    end)
                                end

                                behaviour:ResetPosition()
                            end
                            behaviour:StopLight()
                        end
                        current.highingTile = {}
                        self:changeRed()
                        return
                    end
                end
                if FakeCorouteInst then
                    FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 2, function() 
                        current.merge_success = nil
                    end)
                end

                self:changeCommon(true)
                if type(currentTiled) == ConstData.TABLE_TYPE then
                    if currentTiled.isHighest and not currentTiled:isHighest() then
                        --
                        local other = currentTiled
                        if other and other.gameObject and gameObject and other.gameObject.name ~= gameObject.name then
                            local behaviours = App:applyFunc(ConstData.MapCore, "checkConnect", other, self)
                            -- 变亮
                            if #behaviours >= 3 then
                                -- 开启亮片
                                -- for i = 1, #current.highingTile do
                                --     local behaviour = current.highingTile[i]
                                --     if behaviour.gameObject.name ~= self.gameObject.name then
                                --         behaviour:stopBreath()
                                --     end
                                --     behaviour:StopLight()
                                -- end
                                -- 高亮呼吸
                                for i = 1, #behaviours do
                                    if not IsNil(behaviours[i]) and not IsNil(behaviours[i].gameObject) then
                                        if behaviours[i]:HighLight() then
                                            if behaviours[i].gameObject.name ~= self.gameObject.name then
                                                behaviours[i]:startBreath()
                                            end
                                            current.highingTile[#current.highingTile + 1] = behaviours[i]
                                        end
                                    end
                                end
                                if is_grid_align then
                                    if current.previousX ~= other.X or current.previousY ~= other.Y then
                                        current.previousX = other.X
                                        current.previousY = other.Y
                                        for i = 1, #current.highingTile do
                                            local behaviour = current.highingTile[i]
                                            if behaviour.gameObject.name ~= self.gameObject.name then
                                                behaviour:StopToCenterGird()
                                                behaviour:ResetPosition()
                                            end
                                        end
                                    end
                                    -- 高亮呼吸
                                    local need_refresh = nil
                                    self.newPosition = self.newPosition or Vector3(vv.x, vv.y - current._cellHeight, -0.005)
                                    for i = 1, #behaviours do
                                        if not IsNil(behaviours[i]) and not IsNil(behaviours[i].gameObject) then
                                            if not behaviours[i].isMovingCenter then
                                                if behaviours[i].gameObject.name ~= self.gameObject.name then
                                                    -- 开始移动
                                                    behaviours[i]:MoveToCenterGird(self.newPosition)
                                                end
                                            end
                                        end
                                    end
                                    if #behaviours < 5 then
                                        -- 开始监测 万能合成宝石特殊处理
                                        App:applyFunc(ConstData.Hint, "FiveMergeMonitor", behaviours[1] or self)
                                    end
                                end
                            else
                                for i = 1, #current.highingTile do
                                    local behaviour = current.highingTile[i]
                                    if behaviour then
                                        if behaviour.gameObject.name ~= self.gameObject.name then
                                            behaviour:stopBreath()
                                            behaviour:StopToCenterGird()
                                            behaviour:ResetPosition()
                                        end
                                        behaviour:StopLight()
                                    end
                                end
                                current.highingTile = {}
                                App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
                            end
                        else
                            if not other:isHighest() then
                                for i = 1, #current.highingTile do
                                    local behaviour = current.highingTile[i]
                                    if behaviour then
                                        if behaviour.gameObject.name ~= self.gameObject.name then
                                            behaviour:stopBreath()
                                            behaviour:StopToCenterGird()
                                            behaviour:ResetPosition()
                                        end
                                        behaviour:StopLight()
                                    end
                                end
                                current.highingTile = {}
                            end
                            -- 为自身位置
                            App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
                        end
                    else
                        for i = 1, #current.highingTile do
                            local behaviour = current.highingTile[i]
                            if behaviour then
                                if behaviour.gameObject.name ~= self.gameObject.name then
                                    behaviour:stopBreath()
                                    behaviour:StopToCenterGird()
                                    behaviour:ResetPosition()
                                end
                                behaviour:StopLight()
                            end
                        end
                        current.highingTile = {}
                    end
                else
                    for i = 1, #current.highingTile do
                        local behaviour = current.highingTile[i]
                        if behaviour then
                            if behaviour.gameObject.name ~= self.gameObject.name then
                                behaviour:stopBreath()
                                behaviour:StopToCenterGird()
                                behaviour:ResetPosition()
                            end
                            behaviour:StopLight()
                        end
                    end
                    current.highingTile = {}
                end
            elseif currentTiled and (type(currentTiled) == ConstData.TABLE_TYPE and self.data.ItemType == "timeelf" and (not IsObstacle and not is_lock and 
                current.currentAreas[vec.x + 1 + vec.y * current.cellXCount] == "Y") or (self.data.ItemType == "timeelf" and currentTiled == "" and not is_lock)) then
                self:changeCommon(true)
            elseif currentTiled and type(currentTiled) == ConstData.TABLE_TYPE and currentTiled.data.ItemType == "castlefloor" then
                -- 判断放置的位置是castlefloor
                self.newPosition = self.newPosition or Vector3(vv.x, vv.y - current._cellHeight, -0.005)
                gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = self.newPosition + Vector3(-0.076, 0.14, 0)
                if currentTiled.heightestBuilding then
                    if currentTiled.heightestBuilding == self.cellId then    -- 
                        -- 高亮当前
                        self:changeCommon(true)
                    end
                end
                for i = 1, #current.highingTile do
                    local behaviour = current.highingTile[i]
                    if behaviour then
                        if behaviour.gameObject.name ~= self.gameObject.name then
                            behaviour:stopBreath()
                            behaviour:StopToCenterGird()
                            behaviour:ResetPosition()
                        end
                        behaviour:StopLight()
                    end
                end
                current.highingTile = {}
            elseif currentTiled and type(currentTiled) == ConstData.TABLE_TYPE and (currentTiled.cellId == "Base_01" or currentTiled.cellId == "Base_02") then
                self.newPosition = self.newPosition or Vector3(vv.x, vv.y - current._cellHeight, -0.005)
                gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = self.newPosition + Vector3(0, 0.27, 0)
                self:changeCommon(true)
            elseif currentTiled and type(currentTiled) == ConstData.TABLE_TYPE and currentTiled.data.ItemType == ConstData.STR_CASTLE then
                -- 
                if CastleData[currentTiled.cellId] then
                    local NeedItem = CastleData[currentTiled.cellId][currentTiled.castleLevel].NeedItem
                    if NeedItem then
                        gameObject:GetComponent(typeof(ExtDrag)).fixedPosition = currentTiled.gameObject.transform.position - Vector3(0, 0.4, 0)
                        -- 可以放置的物品 Building01_{01;07}
                        -- {[\S\s]+}
                        local str = string.match(NeedItem, "%{(.+)%}")
                        local up_down = string.split(str, ";")
                        local min = tonumber(up_down[1])
                        local max = tonumber(up_down[2])
                        local kind = string.split(NeedItem, "_")
                        kind = kind[1]
                        local is_collect = false
                        for i = min, max do
                            local name = string.format(kind .. "_%02d", i)
                            if name == self.cellId then
                                is_collect = true
                                break
                            end
                        end
                        if is_collect then
                            self:changeCommon(true)
                        else
                            self:changeRed()
                        end
                    end
                end
                for i = 1, #current.highingTile do
                    local behaviour = current.highingTile[i]
                    if behaviour then
                        if behaviour.gameObject.name ~= self.gameObject.name then
                            behaviour:stopBreath()
                            behaviour:StopToCenterGird()
                            behaviour:ResetPosition()
                        end
                        behaviour:StopLight()
                    end
                end
                current.highingTile = {}
            else
                -- 禁止区域，切换红色底板
                for i = 1, #current.highingTile do
                    local behaviour = current.highingTile[i]
                    if behaviour then
                        if behaviour.gameObject.name ~= self.gameObject.name then
                            behaviour:stopBreath()
                            behaviour:StopToCenterGird()
                            behaviour:ResetPosition()
                        end
                        behaviour:StopLight()
                    end
                end
                current.highingTile = {}
                self:changeRed()
            end
        elseif self.data then
            -- 大建筑(2x2)，目前只有2x2 @tomyuan TODO
            self.data.Grid = {2, 2}
            local grid = self.data.Grid
            local tempGrids = {}
            local IsObstacle = nil
            local bigBuilder = false
            local is_lock = false
            local is_B = false
            local is_C = false
            local is_Y = false
            local is_big = false
            for i = 1, grid[1] do
                for j = 1, grid[2] do
                    tempGrids[#tempGrids + 1] = current.currentMatrix[vec.x + i + (vec.y + j - 2) * current.cellXCount]
                    if type(tempGrids[#tempGrids]) == ConstData.TABLE_TYPE then
                        if tempGrids[#tempGrids].data then
                            IsObstacle = IsObstacle or (tempGrids[#tempGrids].data.IsObstacle == 1)
                            if table.indexof(LandMarkData, tempGrids[#tempGrids].data.ItemType) and not (tempGrids[#tempGrids] == self) then
                                bigBuilder = true
                            end
                        end
                    end
                    if current.currentLockArea[vec.x + i + (vec.y + j - 2) * current.cellXCount] then
                        is_lock = true
                    end
                    is_B = (tempGrids[#tempGrids] == "B") or is_B
                    is_C = (tempGrids[#tempGrids] == "C") or is_C
                    is_Y = current.currentAreas[vec.x + i + (vec.y + j - 2) * current.cellXCount]
                    if type(tempGrids[#tempGrids]) == ConstData.TABLE_TYPE then
                        if table.indexof(LandMarkData, self.data.ItemType) then
                        end
                    end
                    is_big = type(tempGrids[#tempGrids]) == ConstData.TABLE_TYPE and type(tempGrids[#tempGrids]).ItemType == "castlefloor"
                end
            end
            if not is_B and not is_C and not IsObstacle and not is_lock and is_Y and not bigBuilder then
                self:changeCommon(true)
            else
                -- 禁止区域，切换红色底板
                for i = 1, #current.highingTile do
                    local behaviour = current.highingTile[i]
                    if behaviour then
                        if behaviour.gameObject.name ~= self.gameObject.name then
                            behaviour:stopBreath()
                            behaviour:StopToCenterGird()
                            behaviour:ResetPosition()
                        end
                        behaviour:StopLight()
                    end
                end
                current.highingTile = {}
                self:changeRed()
            end
        else
            -- 禁止区域，切换红色底板
            for i = 1, #current.highingTile do
                local behaviour = current.highingTile[i]
                if behaviour then
                    if behaviour.gameObject.name ~= self.gameObject.name then
                        behaviour:stopBreath()
                        behaviour:StopToCenterGird()
                        behaviour:ResetPosition()
                    end
                    behaviour:StopLight()
                end
            end
            current.highingTile = {}
            self:changeRed()
        end
    end

    -- 城堡需要发光闪烁
    if current.castleElement then
        current.castleElement:onCastleStarFlicker()
    end
end

-- 特殊的点击类型 只用于障碍物
-- dialogForce这里的dialogForce, 判断调用是否来自dialog和其他元素重叠时，优先处理dialog,若dialogForce为true,则，不再进行重叠检测
-- 防止死循环
-- 2022 袁博备注，点击障碍物
function MapBehaviour:OnClick(gameObject, position, isNotMoved, _currentTiled, force, dialogForce)
    if self.dialogClick then
        return
    end
    if UI_TOUCH then
        return
    end

    -- 清理所有的
    -- for i = 1, #current.currentMatrix do
    --     local v = current.currentMatrix[i]
    --     if type(v) == "table" then
    --         if v.data.ItemType == 'obstacle' then
    --             v:DestroyMySelf()
    --         end
    --     end
    -- end
    if GlobalDataMgr:GetBidMove() then
        return
    end

    App:applyFunc(ConstData.Cloud, "BidCloud", 0.2)
    self.dialogClick = true
    self:delayedCall(0.05, function() 
        self.dialogClick = false
    end)
    local diff_distance = 0
    if current.cameraPosition then
        local cameraPosition = MapUtil:getMainCamera().gameObject.transform.position
        diff_distance = math.abs(cameraPosition.x - current.cameraPosition.x) + math.abs(cameraPosition.y - current.cameraPosition.y)
    end
    if diff_distance < 0.5 then
        local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
        if lvType == ConstData.STR_MASTER then
            if CURRENT_USER then
                local CURRENT_STEP = UPlayerPrefs.GetInt(CURRENT_USER .. "_CURRENT_STEP", 0)
                if CURRENT_STEP == 3 or CURRENT_STEP == 4 then
                    App:applyFunc(ConstData.Hint, "CancelArrow", "object".. tostring(tonumber(self.X) + 1 + tonumber(self.Y) * current.cellXCount) .."_Arrow")
                end
            end
        end
        local touchList = App:applyFunc(ConstData.Touch, "getStatusList")
        local touchStatus = App:applyFunc(ConstData.Touch, "getStatus")
        App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
        -- 没有点击则窒执行shake
        if touchStatus == touchList.COMMON then
            local ret = App:applyFunc(ConstData.Status, "DialogClick", self)
            if not ret then
                if not self.data["Behaviour"] or self.data["Behaviour"] == '' then
                    if dialogForce then 
                        current:ObstacleForceNoRetClick(self)
                    else
                        if not NormalUtils.RayCheckColiders(Input.mousePosition) then
                            current:ObstacleForceNoRetClick(self)
                        end
                    end
                else
                    -- 脚本类, 这里的current是，map, self是元素
                    if dialogForce then 
                        current:ObstacleForceClick(self)
                    else
                        if not NormalUtils.RayCheckColiders(Input.mousePosition) then
                            current:ObstacleForceClick(self)
                        end
                    end    
                end
            else
                -- ret 表示目前障碍物上，是否存在可以开采的内容
                self:shake()
            end
        end
    end
end

-- 此处特别说明 current表示CommonMap, self表示gameobject所属的Behaviour， 
-- dialogForce这里的dialogForce, 判断调用是否来自dialog和其他元素重叠时，优先处理dialog,若dialogForce为true,则，不再进行重叠检测
-- 防止死循环
function MapBehaviour:DragEnded(gameObject, position, isNotMoved, _currentTiled, force, dialogForce, isMov)
    App:applyFunc(ConstData.Time, "setOpt")
    local teachstatus = App:applyFunc(ConstData.FirstPlayTeach, "InForceState")
    current.dragObject = nil
    local interactTime = current.interactTime
    current.interactTime = nil
    -- 城堡需要关闭发光闪烁
    if current.castleElement then
        current.castleElement:offCastleStarFlicker()
        current.castleElement = nil
    end
    -- 不运行同时拖动两个
    App:applyFunc(ConstData.Camera, "ClearLastTime")
    local isForceBack = false -- 是否强制弹回
    App:applyFunc(ConstData.Touch, "stopElementDraging")
    current.highingTile = current.highingTile or {}
    for i = 1, #current.highingTile do
        local behaviour = current.highingTile[i]
        behaviour:StopLight()
        behaviour:stopBreath()
        behaviour:StopToCenterGird()
        behaviour:ResetPosition()
        behaviour:changeCommon()
    end
    if self.stopBreath then
        self:stopBreath()
    end
    if self.changeCommon then
        self:changeCommon()
    end
    if GlobalDataMgr:GetBidMove() or UI_COUNT > 0 then
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
        end
        self:BounceBack(function() 
            -- 恢复所有层级 
            App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
            self:setNeedSortingOrder(true)
        end)
        return
    end
   
    if current.forceBack then
        if not IsNil(current) and not IsNil(self) then
            -- 返回原来的位置
            isForceBack = true
        else
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
            end
            self:BounceBack(function() 
                -- 恢复所有层级 
                App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                self:setNeedSortingOrder(true)
            end)
            return
        end
    end

    -- 清除 GRUB 删除
    if App:applyFunc(ConstData.FirstPlayTeach, "OnSeal") then 
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
        end
        self:SealClick()
        return
    end

    -- 处理城堡点击教学
    if App:applyFunc(ConstData.FirstPlayTeach, "CheckTeaching", "Ph06_Castle_Pointer") then
        if Global.IsStoryLevelShown == 1 then
            local storyCastleData = ClientData:GetInstance():StoryCastleData()
            if storyCastleData[self.cellId] then
                local cellId = storyCastleData[self.cellId]["CastleId"]
                local have_story_level = App:applyFunc(ConstData.StoryCastle, "CheckHaveStoryByCellId", cellId)
                if have_story_level then
                    local teached = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeached", "Ph06_Castle_Pointer")
                    local teaching = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeaching", "Ph06_Castle_Pointer")
                    if not teached and not teaching then
                    else
                        UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleStoryInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
                    end
                else
                    UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
                end
            end
        else
            UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
        end
        -- wbbi 等合并后处理
        UIManager:GetInstance():CloseWindow(Config.UIWindowNames.UICastleMask, {"expend"})
        self:ClosePointer()
        return
    end
    -- 没有问题
    if self.bounceBackAid then
        AnimateTween.cancel(self.bounceBackAid, true)
        self.bounceBackAid = nil
    end
    self.popup_hide_all = nil
    -- 如果存在dialog
    local cellHeight = current._cellHeight
    App:applyFunc(ConstData.Camera, "ClearLastTime")
    
    --
    current.highingTile = current.highingTile or {}
    for i = 1, #current.highingTile do
        local behaviour = current.highingTile[i]
        behaviour:StopLight()
        behaviour:StopToCenterGird()
        behaviour:ResetPosition()
        behaviour:stopBreath()
    end
    current.highingTile = {}
    App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, nil, gameObject, true)

    self.fixed = false
    local touchList = App:applyFunc(ConstData.Touch, "getStatusList")
    if not self.dialog_show and current.maxDistance and current.maxDistance > 0.12 then
        self:showDialog()
    end
    current.canBreath = false
    --
    local inputVec = Input.mousePosition
    if Input.touchCount > 1 then 
        inputVec = Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 0)
    end
    if inputVec.x < 0 or inputVec.x > 10000 then
        inputVec = Vector2(0, inputVec.y)
    end
    if inputVec.y < 0 or inputVec.y > 10000 then
        inputVec = Vector2(inputVec.x, 0)
    end
    local vec_world = current.mainCamera:ScreenToWorldPoint(Vector3(inputVec.x, inputVec.y, -current.camera.transform.position.z)) + Vector3(0, 0.18, 0) -- 策划调整手感
    -- 得到当前的世界坐标，并设置
    local vec = App:applyFunc(ConstData.MapCore, "NearestGridIndex", Vector2(vec_world.x * 100, vec_world.y * 100))
    if isForceBack then
        vec = Vector2(self.X, self.Y)
    end
    if not gameObject.transform.position or not current.dragBeginPosition then
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
        end
        return
    end

    -- 判断vec.x, vec.y
    if vec then
        local isError = false
        if vec.x then
            if tonumber(vec.x) > current.cellXCount or vec.x < 0 then
                isError = true
            end
        end
        if vec.y then
            if tonumber(vec.y) > current.cellYCount or vec.y < 0 then
                isError = true
            end
        end
        if isError then
            -- 踢回
            -- 立即弹回
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
            end
            self:BounceBackQuick()
        end
    end

    local distance_tmp = (gameObject.transform.position - current.dragBeginPosition).magnitude
    local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
    if lvType == ConstData.STR_MASTER then
        if CURRENT_USER then
            local CURRENT_STEP = UPlayerPrefs.GetInt(CURRENT_USER .. "_CURRENT_STEP", 0)
            if CURRENT_STEP == 3 or CURRENT_STEP == 4 then
                if current and self and self.X and self.Y and tonumber(self.X) and tonumber(self.Y) then
                    App:applyFunc(ConstData.Hint, "CancelArrow", "object".. tostring(tonumber(self.X) + 1 + tonumber(self.Y) * current.cellXCount) .."_Arrow")
                else
                    UPlayerPrefs.SetInt(CURRENT_USER .. "_CURRENT_STEP", 14)
                end
            end
        end
    end
    -- 如果满足下面条件，就是点击地图对象的操作，处理~ 2021.08.22
    if ((distance_tmp and distance_tmp < 0.1) and (current.maxDistance and current.maxDistance <= 0.12)) or dialogForce then
        -- 恢复所有层级
        self.before_status = self.status
        if UI_TOUCH then
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
            end
            return
        end
        -- 返回原来的位置(瞬间)
        local vv1 = superMapUtils:GridIndexConvertToPosition(self.X, self.Y) / 100
        local _index = self.X + 1 + self.Y * self.map.cellXCount
        local add = 0.01 / _index
        local newPosition = Vector3(vv1.x, vv1.y - cellHeight, -0.005 + add)
        self.gameObject.transform.position = newPosition
        local touchStatus = App:applyFunc(ConstData.Touch, "getStatus")

        if self.tag ~= nil and self.tag ~= "" and not (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) and string.find(self.cellId, "_GS") then 
            self.tag = nil
        end
        if self.data and touchStatus == touchList.COMMON and self.tag ~= "MoveOnly" then
            local ret_status = App:applyFunc(ConstData.Status, "DialogClick", self)
            local _COOK_ICON = UPlayerPrefs.GetInt(CURRENT_USER .. "_COOK_ICON", 0)
            if self.data.ItemType == "npc" then
                if self.status == StatusConst.FinishForCook and not self.foodGenerated then
                    self:SetFoodGenerated()
                    App:applyFunc(ConstData.Cook,  "GenerateFood", self.cellId, true)
                else
                    -- 如果是正常状态或者等待做饭
                    local animate = self.data.SpineAnimationList[math.random(1, #self.data.SpineAnimationList)]
                    self:PlaySpine(animate)
                    self.animated = true
                    -- TODO 烹饪系统 版号包先隐藏
                    App:applyFunc(ConstData.Cook,  "SetSelectByNpcId", self.cellId)
                    UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UICookPanel, {"expend"})
                end
            else
                if not self.data["Behaviour"] or self.data["Behaviour"] == '' then
                    if not IsNil(self) then
                        self:shake()
                        if self.data.ItemType == "castlefloor" then
                            local ret = App:applyFunc(ConstData.Warehouse,  "findCurrentFloor", self)
                            if not ret then
                                -- AB/Test
                                debug.log("Global.IsStoryLevelShown====>", Global.IsStoryLevelShown)
                                if Global.IsStoryLevelShown == 1 then
                                    --  判断允许开启剧情的城堡
                                    self.storyCastleData = self.storyCastleData or ClientData:GetInstance():StoryCastleData()
                                    -- 并且判断有没有关卡,如果没有关卡,则显示老版详情
                                    if self.storyCastleData[self.cellId] then
                                        local cellId = self.storyCastleData[self.cellId]["CastleId"]
                                        local have_story_level = App:applyFunc(ConstData.StoryCastle, "CheckHaveStoryByCellId", cellId)
                                        if have_story_level then
                                            local teached = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeached", "Ph06_Castle_Pointer")
                                            local teaching = App:applyFunc(ConstData.FirstPlayTeach, "CheckTeaching", "Ph06_Castle_Pointer")
                                            if not teached and not teaching then
                                            else
                                                UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleStoryInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
                                            end
                                        else
                                            UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
                                        end
                                    else
                                        -- 弹出提示框 (UIRootCastleInfo)
                                        UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
                                    end
                                else
                                    -- 弹出提示框 (UIRootCastleInfo)
                                    UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UIRootCastleInfo, {"expend"}, {["cellId"] = self.cellId, ["tag"] = self.tag})
                                end 
                                self:ClosePointer()
                            end
                        end
                        if self.data.ItemType == "decoratenpc" then
                            if self.status == StatusConst.CollectDecorateProp then
                                App:applyFunc(ConstData.Status, "DialogClick", self)
                            end
                        end
                        -- 弹出[建筑弹窗][清理弹窗][生长弹窗][云朵解锁弹窗]
                        if dialogForce then 
                            current:JudgeBanner(self, ret_status)
                        else
                            if not NormalUtils.RayCheckColiders(Input.mousePosition) then
                                current:JudgeBanner(self, ret_status)
                            end
                        end
                        
                        -- 如果当前的状态
                        local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
                        if lvType == ConstData.STR_MASTER then
                            if self.status == StatusConst.WaitingTimeForBuild or 
                                self.status == StatusConst.WaitingForResHagFinish or 
                                self.status == StatusConst.WaitingForObstacleHagFinish or
                                self.status == StatusConst.WaitingForMineFinish then
                                -- 弹出
                                if self.cost_time and self.cost_time > 31 then
                                    if self:GetBuildingWorkerType() == "worker" then
                                        local path = "SpeedUp_Building"
                                        if self.data.ItemType == "res" then 
                                            path = "SpeedUp_Obstacle"
                                        elseif self.data.ItemType == "crop" then 
                                            path = "SpeedUp_Crop"
                                        end
                                        UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UINotice01RefreshPannel, {"expend"}, self, App:applyFunc(ConstData.AdsPlay,  "UsingAdsPannel", self), path)
                                    end
                                end
                            end
                        end
                    end
                    App:applyFunc(ConstData.Sound,  "playSound", "touch")
                else
                    local noBanner = true
                    if UserData:GetInstance():level() >= (GlobalData.BannerShowLevel or 1) or App:applyFunc(ConstData.FirstPlayTeach, "CheckTeached", FirstPlayTeachConst.TEACH_NAMES.Ph05_Free_Gift_07) then -- 需要照顾老用户 
                        noBanner = UPlayerPrefs.GetInt("CurrencyUseMetion", 1) == 0
                    end
                    -- 点击脚本1
                    if dialogForce then 
                        self:CompsClick(nil, noBanner)
                    else
                        if not NormalUtils.RayCheckColiders(Input.mousePosition) then
                            self:CompsClick(nil, noBanner)
                        end
                    end
                end
            end
        else
            App:applyFunc(ConstData.Task,  "onceTask", "Sell")
            App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Map", param = {"Sell"}})
        end
        current.maxDistance = nil
        current.interactTime = nil
        local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
        if lvType == ConstData.STR_MASTER then 
            -- 新手
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
            end
            self:MergeIntoCastleFloor()
        end
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
        end
        return
    end
    -- 判断当前是否存在物体
    -- 检测是否在锁区中 
    local is_lock = false
    if current.currentLockArea[vec.x + 1 + vec.y * current.cellXCount] then
        is_lock = true
    end
    
    local currentTiled = _currentTiled or current.currentMatrix[vec.x + 1 + vec.y * current.cellXCount]
    local IsObstacle = nil
    if type(currentTiled) == ConstData.TABLE_TYPE then
        if currentTiled.data then
            IsObstacle = (currentTiled.data.IsObstacle == 1)
        end
    end

    local bigBuilder = false
    if type(currentTiled) == ConstData.TABLE_TYPE then
        if currentTiled.data and table.indexof(LandMarkData, currentTiled.data.ItemType) then -- currentTiled.data.Grid
            bigBuilder = true
        end
    end

    if not isMov then
        -- 立即弹回
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
        end
        self:BounceBackQuick()
        return
    end
    current.movingTime = 0.3
    -- 如果不是大建筑 城堡底板/城堡/矿藏
    if self.data and not table.indexof(LandMarkData, self.data.ItemType) then
        -- 普通类
        if currentTiled and currentTiled ~= "Y" and currentTiled and currentTiled ~= "B" and currentTiled ~= "C" and currentTiled ~= "H" and not IsObstacle and not is_lock and 
            current.currentAreas[vec.x + 1 + vec.y * current.cellXCount] == "Y" and not bigBuilder
            and self.status ~= StatusConst.QuickWorker then
            if type(currentTiled) == "table" and currentTiled.bounceBackAid then
                AnimateTween.cancel(currentTiled.bounceBackAid, true)
                currentTiled.bounceBackAid = nil
            end
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState") and not App:applyFunc(ConstData.FirstPlayTeach, "CheckInEleArea", {vec.x, vec.y})) then 
                -- TODO弹回 教学出界
                if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                    App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                end
                self:BounceBack(function() 
                    -- 恢复所有层级 
                    if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                        App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                    end
                    App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                    self:setNeedSortingOrder(true)
                end)
                return
            else
                if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                    if (App:applyFunc(ConstData.FirstPlayTeach, "CheckForceDrag")) then 
                        App:applyFunc(ConstData.FirstPlayTeach, "EmitEvent", "FORCE_DRAG", {{vec.x, vec.y}, self.cellId})
                    else
                        if (currentTiled == "") then 
                            self:BounceBack(function() 
                                -- 恢复所有层级 
                                App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                                self:setNeedSortingOrder(true)
                                
                            end)
                            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                            return
                        end
                    end
                end
            end
            -- 条件非常多 TODO
            if currentTiled and currentTiled.data then
                if currentTiled.data.ItemType == "monster" then
                    -- 弹回
                    if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                        App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                    end
                    self:BounceBack(function() 
                        -- 恢复所有层级 
                        App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                        self:setNeedSortingOrder(true)
                        
                    end)
                    return
                end
            end
            App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
            if current.currentMatrix[vec.x + 1 + vec.y * current.cellXCount] ~= "" then
                local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
                local other = current.currentMatrix[vec.x + 1 + vec.y * current.cellXCount]
                local behaviours = {}
                local connects = {}
                if other and gameObject and other.gameObject and other.gameObject.name ~= gameObject.name then
                    behaviours = App:applyFunc(ConstData.MapCore, "checkConnect", other, self)
                    connects = App:applyFunc(ConstData.MapCore, "checkInConnect", other, self)
                end
                if not gameObject then
                    if not IsNil(self.gameObject) then
                        self:BounceBackQuick()
                    end
                    return
                end
                if not other then
                    if not IsNil(self.gameObject) then
                        self:BounceBackQuick()
                    end
                    return
                end
                if IsNil(other.gameObject) then
                    if not IsNil(self.gameObject) then
                        self:BounceBackQuick()
                    end
                    return
                end
                if type(other) ~= ConstData.TABLE_TYPE then
                    if not IsNil(self.gameObject) then
                        self:BounceBackQuick()
                    end
                    return
                end
                if other == self then
                    if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                        App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                    end
                    if not IsNil(self.gameObject) then
                        self:BounceBackQuick()
                    end
                    return
                end
                -- 如果联通性不足三个或者其中有最高级别
                if #behaviours < 3 or (#behaviours > 0 and behaviours[1]:isHighest()) then
                    if not teachstatus then
                        current:MoveToNeatBy(self, vec, other, cellHeight)
                    else
                        -- 归位
                        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                        end
                        self:BounceBack(function() 
                            -- 恢复所有层级 
                            App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                            self:setNeedSortingOrder(true)
                        end)
                    end
                else
                    local leave_over_count = 0
                    local generate_count = 0
                    local mergeData = App:applyFunc(ConstData.MapCore, "getMergeOutputData", self, behaviours)
                    leave_over_count = mergeData.overCount
                    generate_count = mergeData.genCount
                    if mergeData.exchange then
                       -- 不满足合并交换
                        if table.indexof(connects, self) then -- 存在于连同队列的，进行交换
                            App:applyFunc(ConstData.Element, "MergeLockEffect", other.transform.position)
                            current:ExchangeTwoElement(other, self)
                        else -- 不在联通队列的，就近
                            App:applyFunc(ConstData.Element, "MergeLockEffect", other.transform.position)
                            current:MoveToNeatBy(self, vec, other, cellHeight)
                        end
                        self:setNeedSortingOrder(true)
                    else
                        -- 三合确认面板
                        if mergeData.showMergeConfirm then
                            App:applyFunc(ConstData.Popup, "showMergeConfirmPanel", self, behaviours, other)
                            current.mergeConfirmState = true
                        else   -- 直接合成
                            App:applyFunc(ConstData.MapCore, "FinalMerge", self, behaviours, other)
                        end
                    end
                end
                -- self:setNeedSortingOrder(true)
            else
                if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                    App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                end
                App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
                local vv = superMapUtils:GridIndexConvertToPosition(vec.x, vec.y) / 100
                local oldPosition = gameObject.transform.position
                local _index = vec.x + 1 + vec.y * current.cellXCount
                local add = 0.01 / _index
                local newPosition = Vector3(vv.x, vv.y - cellHeight, -0.005 + add)
                if not isForce then
                    local aid = AnimateTween.moveToV3(self.gameObject, newPosition, 0.33)
                    aid:setEase(LeanTweenType.easeOutQuint)
                    AnimateTween.setCallBack(aid, function() 
                        gameObject.transform.position = newPosition
                    end)
                else
                    gameObject.transform.position = newPosition
                end
                local index = vec.x + 1 + vec.y * current.cellXCount
                current.emptyMatrix[index] = false
                current.currentMatrix[index] = self
                if current.currentLockMatrixCloud[index] ~= "" then
                    current.currentLockMatrixCloud[index] = ""
                end
                --
                index = self.X + 1 + self.Y * current.cellXCount
                current.emptyMatrix[index] = true
                current.currentMatrix[index] = ""
                if current.currentLockMatrixCloud[index] ~= "" then
                    current.currentLockMatrixCloud[index] = ""
                end
                self.X = vec.x
                self.Y = vec.y
                self:setNeedSortingOrder(true)
            end
        elseif currentTiled and (type(currentTiled) == ConstData.TABLE_TYPE and self.data.ItemType == "timeelf") or ((currentTiled == "") and not is_lock and self.data.ItemType == "timeelf") then
            if  (type(currentTiled) == ConstData.TABLE_TYPE and self.data.ItemType == "timeelf" and (currentTiled.status == StatusConst.WaitingTimeForBuild or currentTiled.status == StatusConst.WaitingForBuild or currentTiled.status == StatusConst.UnBuild)) then
                -- 隐藏buildpanel
                App:applyFunc(ConstData.Popup, "hideAll")
                -- 如果当前已经使用了Quick则返回
                if currentTiled.quickBuilding then
                    -- 弹回
                    self:BounceBackQuick()
                    return
                end
                self.isWorking = true
                -- 矿藏处理, 矿藏工人处理,如果为unbuilder
                local is_mine_use_worker = false
                if currentTiled.status == StatusConst.UnBuild and currentTiled.data.ItemType == "mine" then
                    currentTiled:SetBuildingWorkerType("worker_powerful")
                    currentTiled:setQuickBuild()
                    is_mine_use_worker = true
                    -- 变更为状态WaitingForMine
                    App:applyFunc(ConstData.Status, ConstData.TransferStatus, currentTiled)
                end
                -- 如果当前正在建造，切换普通工人到精灵工人
                local is_building = false
                if currentTiled.status == StatusConst.WaitingTimeForBuild then
                    -- 正在创建
                    if not is_mine_use_worker then
                        -- 如果矿藏部分没有起作用
                        currentTiled:SetBuildingWorkerType("worker")
                        currentTiled:setQuickBuild()
                        App:applyFunc(ConstData.Worker, "recoveWorker", currentTiled)
                    end
                    -- 取消普通工人
                    App:applyFunc(ConstData.Worker, "hideEffect", currentTiled)
                    App:applyFunc(ConstData.Worker, "hideBuildEffect", currentTiled)
                    currentTiled:SetBuildingWorkerType("worker_powerful")
                    currentTiled:setQuickBuild()
                    is_building = true
                end

                -- 其他情况
                if FakeCorouteInst then
                    local wait_frame = 1
                    if is_building then
                        wait_frame = FRAME_ONE * 6
                    end
                    FakeCorouteInst:CreateFakeCoroute(wait_frame, function()
                        -- 快速建造!
                        if currentTiled.status == StatusConst.WaitingForBuild then
                            -- 如果是等待建造的情况
                            currentTiled.unworker = 1
                            currentTiled.status = StatusConst.StartForBuild
                            currentTiled:SetBuildingWorkerType("worker_powerful")
                            currentTiled:setQuickBuild()
                            App:applyFunc(ConstData.Status, "refreshStatus", currentTiled)
                        end
                        if FakeCorouteInst then
                            FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
                                if currentTiled.status == StatusConst.WaitingTimeForBuild then
                                    currentTiled.unworker = 1
                                    App:applyFunc(ConstData.Status, "refreshStatus", currentTiled)
                                end
                                if FakeCorouteInst then
                                    FakeCorouteInst:CreateFakeCoroute(FRAME_ONE, function() 
                                        App:applyFunc(ConstData.Time,  "quickTime", self, currentTiled, function(overall) 
                                            App:applyFunc(ConstData.Task,  "onceTask", "UseWorker-1")
                                            App:applyFunc(ConstData.ActivityMapMsg, "notify", ConstData.MapEvents.ONCE_TASK, {from = "Map", param = {"UseWorker-1"}})
                                            currentTiled:clearQuickBuild()
                                            if overall then
                                                -- 精灵加速时间 < 建筑建造时间 精灵加速后 白嫖一位工人
                                                App:applyFunc(ConstData.Worker, "hideEffect", currentTiled)
                                                App:applyFunc(ConstData.Worker, "hideBuildEffect", currentTiled)
                                                FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 6,function ()
                                                    currentTiled:SetBuildingWorkerType()  -- 设置为普通工人
                                                    App:applyFunc(ConstData.Status, "refreshStatus", currentTiled)
                                                end)
                                                -- 用完则消失
                                                self:DestroyMySelf()
                                            else
                                                -- 设置为普通工人
                                                currentTiled:SetBuildingWorkerType()
                                                currentTiled.unworker = nil
                                                self.isWorking = false
                                                -- 返回原来的位置
                                                local vv1 = superMapUtils:GridIndexConvertToPosition(self.X, self.Y) / 100
                                                local oldPosition = self.gameObject.transform.position
                                                local newPosition = Vector3(vv1.x, vv1.y - cellHeight, -0.005)
                                                local aid = AnimateTween.moveToV3(self.gameObject, newPosition, 0.33)
                                                AnimateTween.valueTo(self.gameObject, 0, 1, 0.33, function(tm) 
                                                    self.gameObject.transform.localScale = Vector3.one * tm
                                                end)
                                                aid:setEase(LeanTweenType.easeOutQuint)
                                                AnimateTween.setCallBack(aid, function() 
                                                    self.gameObject.transform.position = newPosition
                                                end)
                                                self:setNeedSortingOrder(true)
                                            end
                                        end)
                                    end)
                                end
                            end)
                        end
                    end)
                end     
            else
                local other = current.currentMatrix[vec.x + 1 + vec.y * current.cellXCount]
                local lvType = App:applyFunc(ConstData.Level, ConstData.getMapType)
                local isForce = false
                if lvType == ConstData.ACTIVITY_LEVEL then
                    isForce = true
                end
                local vvv = App:applyFunc(ConstData.MapCore, "ResearchGird", vec.x, vec.y, {1, 1}, isForce)
                local next_pos = vvv[1]
                if next_pos then
                    App:applyFunc(ConstData.MapCore, "RemoveGrid", 1)
                end
                if next_pos and #next_pos > 0 and type(other) == ConstData.TABLE_TYPE and 
                    other and other ~= "Y" and other and other ~= "B" and other ~= "C" and other ~= "H" and not IsObstacle and not is_lock and 
                current.currentAreas[vec.x + 1 + vec.y * current.cellXCount] == "Y" and not bigBuilder
                and other.cellId ~= "Base_01" and other.cellId ~= "Base_02" 
                and not current:checkWall(vec.x, vec.y) then
                    local vv1 = superMapUtils:GridIndexConvertToPosition(next_pos[1], next_pos[2]) / 100
                    local oldPosition = other.gameObject.transform.position
                    local newPosition = Vector3(vv1.x, vv1.y - cellHeight, -0.005)
                    local other_aid = AnimateTween.moveToV3(other.gameObject, newPosition, 0.33)
                    other_aid:setEase(LeanTweenType.easeOutQuint)
                    AnimateTween.setCallBack(other_aid, function() 
                        other.gameObject.transform.position = newPosition
                    end)
                    local index = next_pos[1] + 1 + next_pos[2] * current.cellXCount
                    current.emptyMatrix[index] = false
                    current.currentMatrix[index] = other
                    other.X = next_pos[1]
                    other.Y = next_pos[2]
                    ---
                    local vv = superMapUtils:GridIndexConvertToPosition(vec.x, vec.y) / 100
                    local oldPosition = gameObject.transform.position
                    local newPosition = Vector3(vv.x, vv.y - cellHeight, -0.005)
                    local aid = AnimateTween.moveToV3(gameObject, newPosition, 0.33)
                    aid:setEase(LeanTweenType.easeOutQuint)
                    AnimateTween.setCallBack(aid, function() 
                        gameObject.transform.position = newPosition
                    end)
                    local index = self.X + 1 + self.Y * current.cellXCount
                    current.emptyMatrix[index] = true
                    current.currentMatrix[index] = ""
                    if current.currentLockMatrixCloud[index] ~= "" then
                        current.currentLockMatrixCloud[index] = ""
                    end
                    local index = vec.x + 1 + vec.y * current.cellXCount
                    current.emptyMatrix[index] = false
                    current.currentMatrix[index] = self
                    self.X = vec.x
                    self.Y = vec.y
                    self:setNeedSortingOrder(true)
                elseif type(other) == ConstData.TABLE_TYPE then
                    -- 弹回
                    if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                        App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                    end
                    self:BounceBack(function() 
                        -- 恢复所有层级 
                        App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                        self:setNeedSortingOrder(true)
                    end)
                else
                    -- 其他情况
                    local vv = superMapUtils:GridIndexConvertToPosition(vec.x, vec.y) / 100
                    local oldPosition = gameObject.transform.position
                    local newPosition = Vector3(vv.x, vv.y - cellHeight, -0.005)
                    local aid = AnimateTween.moveToV3(self.gameObject, newPosition, 0.33)
                    aid:setEase(LeanTweenType.easeOutQuint)
                    AnimateTween.setCallBack(aid, function() 
                        self.gameObject.transform.position = newPosition
                    end)
                    local index = self.X + 1 + self.Y * current.cellXCount
                    current.emptyMatrix[index] = true
                    current.currentMatrix[index] = ""
                    if current.currentLockMatrixCloud[index] ~= "" then
                        current.currentLockMatrixCloud[index] = ""
                    end
                    self.X = vec.x
                    self.Y = vec.y
                    local index = vec.x + 1 + vec.y * current.cellXCount
                    current.emptyMatrix[index] = false
                    current.currentMatrix[index] = self
                    self:setNeedSortingOrder(true)
                end
            end
        elseif currentTiled and type(currentTiled) == ConstData.TABLE_TYPE and currentTiled.data.ItemType == "castlefloor" then
            -- 判断放置的位置是castlefloor
            if currentTiled.heightestBuilding then
                if currentTiled.heightestBuilding == self.cellId and self.status == StatusConst.Common then    -- 
                    -- 高亮当前
                    App:applyFunc(ConstData.Warehouse,  "refreshFoundation", currentTiled, self, 1)
                    -- 查询
                    if FakeCorouteInst then
                        FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 2, function() 
                            local floors = App:applyFunc(ConstData.Element, "Floors")
                            for k, v in pairs(floors) do
                                App:applyFunc(ConstData.Warehouse,  "floorCheck", v)
                            end
                        end)
                    end
                else
                    -- 弹回
                    if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                        App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                    end
                    self:BounceBack(function() 
                        -- 恢复所有层级 
                        App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                        self:setNeedSortingOrder(true)
                    end)
                end
            end
        elseif currentTiled and type(currentTiled) == ConstData.TABLE_TYPE and currentTiled.data.ItemType == ConstData.STR_CASTLE then
            -- NeedItem
            if CastleData[currentTiled.cellId] and (currentTiled.status == StatusConst.WaitingForCollectObject or 
                currentTiled.status == StatusConst.FinishForCollectObject or currentTiled.status == StatusConst.Common
                or currentTiled.status == StatusConst.FinishForCollectOver) then
                local NeedItem = CastleData[currentTiled.cellId][currentTiled.castleLevel].NeedItem
                if NeedItem then
                    -- 可以放置的物品 Building01_{01;07}
                    -- {[\S\s]+}
                    local str = string.match(NeedItem, "%{(.+)%}")
                    local up_down = string.split(str, ";")
                    local min = tonumber(up_down[1])
                    local max = tonumber(up_down[2])
                    local kind = string.split(NeedItem, "_")
                    kind = kind[1]
                    local is_collect = false
                    for i = min, max do
                        local name = string.format(kind .. "_%02d", i)
                        if name == self.cellId then
                            is_collect = true
                            break
                        end
                    end
                    if is_collect and self.status == StatusConst.Common then
                        local score = self.data.Score or 0
                        -- 放入城堡动画,清除自身
                        currentTiled:castleEatFoodEffect(self, score) 
                        self:delayedCall(0.2, function()
                            currentTiled.castle_score = currentTiled.castle_score or 0
                            currentTiled.castle_score = currentTiled.castle_score + score
                            App:applyFunc(ConstData.Element, "updateCastleStar", currentTiled)
                        end)
                    else
                        -- 弹回
                        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                        end
                        self:BounceBack(function() 
                            -- 恢复所有层级 
                            App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                            self:setNeedSortingOrder(true)
                        end)
                    end
                end
            else
                if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                    App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
                end
                self:BounceBack(function() 
                    -- 恢复所有层级 
                    App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                    self:setNeedSortingOrder(true)
                end)
            end
        else
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
            end
            -- 弹回
            self:BounceBack(function() 
                local lvType = App:applyFunc(ConstData.Level,  ConstData.getMapType)
                -- 恢复所有层级 
                App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                self:setNeedSortingOrder(true)
            end)
        end
    elseif self.data then
        self.data.Grid = {2, 2}
        local grid = self.data.Grid
        local tempGrids = {}
        local IsObstacle = nil
        local bigBuilder = false
        local is_lock = false
        local is_B = false
        local is_C = false
        local is_Y = false
        for i = 1, grid[1] do
            for j = 1, grid[2] do
                tempGrids[#tempGrids + 1] = current.currentMatrix[vec.x + i + (vec.y + j - 2) * current.cellXCount]
                if type(tempGrids[#tempGrids]) == ConstData.TABLE_TYPE then
                    if tempGrids[#tempGrids].data then
                        IsObstacle = IsObstacle or (tempGrids[#tempGrids].data.IsObstacle == 1)
                    end
                    if table.indexof(LandMarkData, tempGrids[#tempGrids].data.ItemType) and not (tempGrids[#tempGrids] == self) then
                        bigBuilder = true
                    end
                end
                if current.currentLockArea[vec.x + i + (vec.y + j - 2) * current.cellXCount] then
                    is_lock = true
                end
                is_B = (tempGrids[#tempGrids] == "B") or is_B
                is_C = (tempGrids[#tempGrids] == "C") or is_C
                is_Y = current.currentAreas[vec.x + i + (vec.y + j - 2) * current.cellXCount]
            end
        end
        if not is_B and not is_C and not IsObstacle and not is_lock and is_Y and not bigBuilder then
            -- 当前地块符合规范
            -- 恢复层级
            App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
            -- 求空出来的位置 
            -- 1. 本身的位置
            local old_position = {}
            for i = 1, grid[1] do
                for j = 1, grid[2] do
                    local index = self.X + i + (self.Y + j - 1) * current.cellXCount
                    old_position[#old_position + 1] = index
                end
            end
            -- 2. 当前的位置，并去除重叠位置，并获得需要移动的element，并标记城堡位置
            local temp_element = {}
            for i = 1, grid[1] do
                for j = 1, grid[2] do
                    local index = vec.x + i + (vec.y + j - 2) * current.cellXCount
                    if current.currentMatrix[index] ~= self and type(current.currentMatrix[index]) == ConstData.TABLE_TYPE and not IsNil(current.currentMatrix[index].gameObject) then
                        temp_element[#temp_element + 1] = current.currentMatrix[index]
                    end
                    for k = 1, #old_position do
                        if old_position[k] == index then
                            old_position[k] = nil
                        end
                    end
                    if current.currentLockMatrixCloud[index] ~= "" then
                        current.currentLockMatrixCloud[index] = ""
                    end
                    current.currentMatrix[index] = self
                    current.emptyMatrix[index] = false
                end
            end
            -- RemoveGrid
            local _index = vec.x + 1 + (vec.y - 1) * self.map.cellXCount
            local add = 0.01 / _index
            local vv = superMapUtils:GridIndexConvertToPosition(vec.x, vec.y - 1) / 100
            local oldPosition = gameObject.transform.position
            local newPosition = Vector3(vv.x, vv.y - cellHeight, -0.005 + add)
            local aid = AnimateTween.moveToV3(self.gameObject, newPosition, 0.33)
            aid:setEase(LeanTweenType.easeOutQuint)
            AnimateTween.setCallBack(aid, function() 
                self.gameObject.transform.position = newPosition
            end)
            self.X = vec.x
            self.Y = vec.y - 1
            self:setNeedSortingOrder(true)
            local sortingFirst = false
            -- 对于 old_position 置空
            for k, v in pairs(old_position) do
                if v then
                    current.emptyMatrix[v] = true
                    current.currentMatrix[v] = ""
                    if current.currentLockMatrixCloud[v] ~= "" then
                        current.currentLockMatrixCloud[v] = ""
                    end
                end
            end
            -- 移动temp_element
            local lvType = App:applyFunc(ConstData.Level, ConstData.getMapType)
            local isForce = false
            if lvType == ConstData.ACTIVITY_LEVEL then
                isForce = true
            end
            local vvv = App:applyFunc(ConstData.MapCore, "ResearchGird", vec.x - 1, vec.y - 1, {1, 1}, isForce)
            if #vvv < grid[1] * grid[2] and not isForce then
                vvv = App:applyFunc(ConstData.MapCore, "ResearchGird", vec.x - 1, vec.y - 1, {1, 1}, true)
            end
            for i = 1, #temp_element do
                local other = temp_element[i]
                if type(other) == ConstData.TABLE_TYPE and not IsNil(other.gameObject) then
                    local next_pos = vvv[1]
                    if next_pos and next_pos[1] and next_pos[2] then
                        -- 计算index
                        local index = next_pos[1] + 1 + next_pos[2] * self.map.cellXCount
                        local add = 0.01 / index
                        App:applyFunc(ConstData.MapCore, "RemoveGrid", 1)
                        local vv1 = superMapUtils:GridIndexConvertToPosition(next_pos[1], next_pos[2]) / 100
                        local oldPosition = other.gameObject.transform.position
                        local newPosition = Vector3(vv1.x, vv1.y - cellHeight, -0.005 + add)
                        local aid = AnimateTween.moveToV3(other.gameObject, newPosition, 0.33)
                        aid:setEase(LeanTweenType.easeOutQuint)
                        AnimateTween.setCallBack(aid, function() 
                            other.gameObject.transform.position = newPosition
                        end)
                        current.emptyMatrix[index] = false
                        current.currentMatrix[index] = other
                        other.X = next_pos[1]
                        other.Y = next_pos[2]
                        other:setNeedSortingOrder(true)
                        other.sortingOrderTime = 0.2
                    end
                end
            end
        else
            -- 弹回
            if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
                App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
            end
            self:BounceBack(function() 
                -- 恢复所有层级 
                App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, self, nil, true)
                self:setNeedSortingOrder(true)
            end)
        end
    else
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", self)
        end
        local currentTiled = current.currentMatrix[vec.x + 1 + vec.y * current.cellXCount]
        if currentTiled and type(currentTiled) == ConstData.TABLE_TYPE then
            if currentTiled.data.Sell and currentTiled.data.Sell >= 0 then
                -- 弹出弹窗
                UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UINotice05Pannel, {"expend"}, {
                    ["Tiled"] = currentTiled,
                    ["SpriteName"] = currentTiled.data.SpriteName,
                    ["Sell"] = currentTiled.data.Sell
                })
            end
        end
    end
    if self.used and self.status == StatusConst.MaxGem then
        self.cellId = "Gem_04"
    end
    self:buildFinish()
    self:DialogRefresh()
end

function MapBehaviour:IsLastNpcToken(tokenCellId)
    local lastNpcToken = GlobalData.LastNpcToken
    local tokenGroup = string.split(lastNpcToken, '|')
    return table.indexof(tokenGroup, tokenCellId)
end

function MapBehaviour:OnEnable()

end

function MapBehaviour:Update()
    if current.interactTime then
        current.interactTime = current.interactTime + DeltaTime
    end
end

function MapBehaviour:LateUpdate()  
    if not DeltaTime then
        return
    end
    -- 是否生成气泡
    if not MapUtil:getMainCamera() then 
        return
    end
    if Input.touchCount > 2 then
        return
    end

    if IsNil(current) or IsNil(current.camera) then
        return
    end
    if self.movingTime and DeltaTime then
        if self.movingTime > 0 then
            self.movingTime = self.movingTime - DeltaTime
        else
            self.movingTime = nil
        end
    end
    if Input.GetMouseButtonUp(0) then
        self.touched = nil
        if FakeCorouteInst then
            FakeCorouteInst:CreateFakeCoroute(FRAME_ONE * 3, function() 
                UI_TOUCH = false
            end)
        end
    end
    if LOCKED_SCREEN then
        return
    end
    if UI_TOUCH then
        return
    end

    if GlobalDataMgr:GetBidMove() then
        return
    end
    if not current or not current.cellXCount then
        return
    end
    -- 计算点
    if Input.touchCount == 1 or CS.UnityEngine.Application.isEditor or ExtDrag.Drag then
        if Input.GetMouseButtonDown(0) then
            local inputVec = Input.mousePosition
            local vec_world = current.mainCamera:ScreenToWorldPoint(Vector3(inputVec.x, inputVec.y, -current.camera.transform.position.z)) + Vector3(0, 0.18, 0)
            local vec = App:applyFunc(ConstData.MapCore, "NearestGridIndex", Vector2(vec_world.x * 100, vec_world.y * 100))
            local obj = current.currentMatrix[tonumber(vec.x) + 1 + tonumber(vec.y) * current.cellXCount]
            if type(obj) == "table" and not IsNil(obj.gameObject) then
                debug.log("Touch:(", vec.x, vec.y, ")", tonumber(vec.x) + 1 + tonumber(vec.y) * current.cellXCount, "当前所在格子的物品:", obj.gameObject.name, obj.status)
            else
                debug.log("Touch:(", vec.x, vec.y, ")", tonumber(vec.x) + 1 + tonumber(vec.y) * current.cellXCount, "当前所在格子的物品:", obj)
            end
            MessageManager:GetInstance():Broadcast(MessageConst.Main_View_Btn_Set)
        end
    end

    if self.dragObject and not ExtDrag.Drag then
        if (self.mutilArg == 1) then -- 一只手松开时，为了 
            self.mutilArg = 0
        end
        self:InertiaSpeedMove() -- 惯性运动
        return
    else
        if self.mutilArg == 1 and Input.touchCount < 2 then
            self:InertiaSpeedMove()
        end
    end
    if not current or not current.camera then
        return
    end
    if (CAMERA_LOCK_SCREEN) then -- 相机在移动时锁屏
        current.mergeConfirmState = false
        return
    end
    -- TODO
    if self.suspendedTime then
        self.suspendedTm = self.suspendedTm or {}
        for i = 1, #self.suspendedTime do
            local suspendedTime = self.suspendedTime[i]
            self.suspendedTm[i] = self.suspendedTm[i] or 0
            self.suspendedTm[i] = self.suspendedTm[i] + DeltaTime
            if self.suspendedTm[i] > suspendedTime then
                self.suspendedTm[i] = 0
                App:applyFunc(ConstData.Bubble, "suspendedSolids", i)
            end
        end
    end

    if Input.touchCount == 1 or CS.UnityEngine.Application.isEditor or ExtDrag.Drag then
        if self.touch_scale then
            return
        end
        if Input.GetMouseButtonDown(0) then
            self.lastClick = nil
            self.mov_vec = 0
            local inputVec = Input.mousePosition

            if inputVec.x < 0 or inputVec.x > 10000 then
                inputVec = Vector2(0, inputVec.y)
            end
            if inputVec.y < 0 or inputVec.y > 10000 then
                inputVec = Vector2(inputVec.x, 0)
            end
            local newPosition1 = current.mainCamera:ScreenToWorldPoint(Vector3(inputVec.x, inputVec.y, -current.camera.transform.position.z))    
            local newPosition2 = current.mainCamera:ScreenToWorldPoint(Vector3(inputVec.x + 100, inputVec.y, -current.camera.transform.position.z))    
            self.unitLength = newPosition2.x - newPosition1.x
            -- 
            self.startMousePosition = inputVec
            self.cameraPosition = MapUtil:getMainCamera().gameObject.transform.position
            self.oldCameraPosition = MapUtil:getMainCamera().gameObject.transform.position
            self.touched = true
            self.beginTime = UTime.time
            self.speed = Vector3.zero
            self.mutilArg = 0
        elseif self.touched then
            if GlobalDataMgr:GetBidMove() then
                return
            end
            if current.dragObject and not ExtDrag.Drag then
                return
            end
            local inputVec =  Input.mousePosition
            if inputVec.x < 0 or inputVec.x > 10000 then
                inputVec = Vector2(0, inputVec.y)
            end
            if inputVec.y < 0 or inputVec.y > 10000 then
                inputVec = Vector2(inputVec.x, 0)
            end
            local currentMousePosition = inputVec
            if not currentMousePosition or not self.startMousePosition then
                return
            end
            local offsetMousePosition = currentMousePosition - self.startMousePosition
            --
            local offsetPosition = (offsetMousePosition / 100.0) * self.unitLength
            self.offsetPositionLen = offsetMousePosition.x * offsetMousePosition.x + offsetMousePosition.y * offsetMousePosition.y
            self.cameraPosition = self.cameraPosition or MapUtil:getMainCamera().gameObject.transform.position
            local newCameraPosition = self.cameraPosition - Vector3(offsetPosition.x, offsetPosition.y, 0)
            local clear = false
            _MAP_LEFT = _MAP_LEFT or -45.5
            _MAP_RIGHT = _MAP_RIGHT or 16.5
            _MAP_UP = _MAP_UP or -6
            _MAP_DOWN = _MAP_DOWN or -54.0
            if newCameraPosition.x < _MAP_LEFT then
                newCameraPosition = Vector3(_MAP_LEFT, newCameraPosition.y, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            if newCameraPosition.x > _MAP_RIGHT then
                newCameraPosition = Vector3(_MAP_RIGHT, newCameraPosition.y, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            if newCameraPosition.y < _MAP_DOWN then
                newCameraPosition = Vector3(newCameraPosition.x, _MAP_DOWN, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            if newCameraPosition.y > _MAP_UP then
                newCameraPosition = Vector3(newCameraPosition.x, _MAP_UP, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            MapUtil:getMainCamera().gameObject.transform.position = Vector3.Lerp(MapUtil:getMainCamera().gameObject.transform.position, newCameraPosition, 0.4)
            
            -- 计算速度
            if self.prevMousePos then
                if not self.offVec then
                    self.offVec = current.mainCamera:ScreenToWorldPoint(Vector3(currentMousePosition.x, currentMousePosition.y, -current.camera.transform.position.z)) - 
                        current.mainCamera:ScreenToWorldPoint(Vector3(self.prevMousePos.x, self.prevMousePos.y, -current.camera.transform.position.z))
                else
                    self.offVec = self.offVec * 0.3 + (current.mainCamera:ScreenToWorldPoint(Vector3(currentMousePosition.x, currentMousePosition.y, -current.camera.transform.position.z)) - 
                        current.mainCamera:ScreenToWorldPoint(Vector3(self.prevMousePos.x, self.prevMousePos.y, -current.camera.transform.position.z))) * 0.7
                end
                if math.abs(self.beginTime - UTime.time) < DeltaTime * 4 then
                    self.offVec = Vector3.zero
                end
                if clear then
                    self.offVec = Vector3.zero
                end
                self.speed = self.offVec / DeltaTime
                if self.speed and self.speed.magnitude > 20 then
                    self.speed = self.speed / (self.speed.magnitude * 0.05)
                end
            end
            self.prevMousePos = currentMousePosition;
        elseif ExtDrag.Drag then 
            if GlobalDataMgr:GetBidMove() then
                return
            end
            if (Input.touchCount < 2) then 
                return
            end
            local inputVec = Vector3(Input.touches[1].position.x, Input.touches[1].position.y, 0)
            if inputVec.x < 0 or inputVec.x > 10000 then
                inputVec = Vector3(0, inputVec.y, 0)
            end
            if inputVec.y < 0 or inputVec.y > 10000 then
                inputVec = Vector3(inputVec.x, 0, 0)
            end
            if self.mutilArg == 0 or self.mutilArg == nil then -- 这些需要重新赋值
                self.mutilArg = 1
                self.startMousePosition = inputVec
                local newPosition1 = MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(inputVec.x, inputVec.y, -current.camera.transform.position.z))    
                local newPosition2 = MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(inputVec.x + 100, inputVec.y, -current.camera.transform.position.z))    
                self.unitLength = newPosition2.x - newPosition1.x
                self.cameraPosition = MapUtil:getMainCamera().gameObject.transform.position
                self.oldCameraPosition = MapUtil:getMainCamera().gameObject.transform.position
                self.prevMousePos = inputVec
                self.beginTime = UTime.time
            end
           
            local currentMousePosition = inputVec
            if not currentMousePosition or not self.startMousePosition then
                return
            end
            local offsetMousePosition = currentMousePosition - self.startMousePosition
            --
            self.cameraPosition = self.cameraPosition or MapUtil:getMainCamera().gameObject.transform.position
            local offsetPosition = (offsetMousePosition / 100.0) * self.unitLength
            self.offsetPositionLen = offsetMousePosition.x * offsetMousePosition.x + offsetMousePosition.y * offsetMousePosition.y
            local newCameraPosition = self.cameraPosition - Vector3(offsetPosition.x, offsetPosition.y, 0)
            local clear = false
            _MAP_LEFT = _MAP_LEFT or -45.5
            _MAP_RIGHT = _MAP_RIGHT or 16.5
            _MAP_UP = _MAP_UP or -6
            _MAP_DOWN = _MAP_DOWN or -54.0
            if newCameraPosition.x < _MAP_LEFT then
                newCameraPosition = Vector3(_MAP_LEFT, newCameraPosition.y, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            if newCameraPosition.x > _MAP_RIGHT then
                newCameraPosition = Vector3(_MAP_RIGHT, newCameraPosition.y, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            if newCameraPosition.y < _MAP_DOWN then
                newCameraPosition = Vector3(newCameraPosition.x, _MAP_DOWN, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end
            if newCameraPosition.y > _MAP_UP then
                newCameraPosition = Vector3(newCameraPosition.x, _MAP_UP, MapUtil:getMainCamera().gameObject.transform.position.z)
                clear = true
            end

            MapUtil:getMainCamera().gameObject.transform.position = Vector3.Lerp(MapUtil:getMainCamera().gameObject.transform.position, newCameraPosition, 0.4)
            
            -- 计算速度
            if self.prevMousePos then
                if not self.offVec then
                    self.offVec = MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(currentMousePosition.x, currentMousePosition.y, -current.camera.transform.position.z)) - 
                        MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(self.prevMousePos.x, self.prevMousePos.y, -current.camera.transform.position.z))
                else
                    self.offVec = self.offVec * 0.3 + (MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(currentMousePosition.x, currentMousePosition.y, -current.camera.transform.position.z)) - 
                        MapUtil:getMainCamera():ScreenToWorldPoint(Vector3(self.prevMousePos.x, self.prevMousePos.y, -current.camera.transform.position.z))) * 0.7
                end
                if math.abs(self.beginTime - UTime.time) < DeltaTime * 4 then
                    self.offVec = Vector3.zero
                end
                if clear then
                    self.offVec = Vector3.zero
                end
                self.speed = self.offVec / DeltaTime
                if self.speed and self.speed.magnitude > 20 then
                    self.speed = self.speed / (self.speed.magnitude * 0.05)
                end
            end
            self.prevMousePos = currentMousePosition;

        end
        if Input.GetMouseButtonUp(0) then
            self.offVec = nil
            self.touched = nil

            local vec = Vector3.zero
            if MapUtil:getMainCamera().gameObject.transform.position then
                vec = Vector3(MapUtil:getMainCamera().gameObject.transform.position.x, MapUtil:getMainCamera().gameObject.transform.position.y, MapUtil:getMainCamera().gameObject.transform.position.z)
            end
            if (self.oldCameraPosition ~= nil) then
                self.mov_vec = (self.oldCameraPosition - vec).magnitude
            else
                self.mov_vec = 0
            end
            
            local ui_click = App:applyFunc(ConstData.Popup, "ClickEvent")
            if self.mov_vec < 0.2 and not self.same and not self.lastClick and not self.popupOpening then
                App:applyFunc(ConstData.Popup, "clearChooseElement")
                App:applyFunc(ConstData.Popup, "hideAll", nil, current.mergeConfirmState)
                current.mergeConfirmState = false
            end
            self.same = false
            self.popupOpening = false
            self.mov_vec = 0
            self.oldCameraPosition = nil
            App:applyFunc(ConstData.Popup, "CancalClickEvent")
            self.newPosition1 = nil
            self.newPosition2 = nil
            self.cameraPosition = nil
        end
    elseif Input.touchCount == 2 then
        if not self.touch_scale then
            self.touch_scale = true
        end
        if not self.tow_touched then
            self.tow_touched = true
            CameraUtils.Instance:MoveCameraBegin()
        end

        if self.tow_touched and not App:applyFunc(ConstData.FirstPlayTeach, "CheckTeaching", "Ph06_Castle_Pointer") then
            local minZ = App:applyFunc(ConstData.Camera, "GetCameraNearPosZ")
            local maxZ = App:applyFunc(ConstData.Camera, "GetCameraFarPosZ")
            CameraUtils.Instance:MoveCamera(maxZ, minZ)
        end
    end
    if Input.touchCount < 2 then
        if self.tow_touched then
            self.startMousePosition = nil
            CameraUtils.Instance:MoveCameraEnded()
            self.tow_touched = false
            self:delayedCall(0.1, function() 
                self.touch_scale = false
            end)
        end
    end
    if not self.touched or (self.speed ~= nil and not ExtDrag.Drag) then -- 这里表示松手
        self:InertiaSpeedMove()
    end
    current.tempWall = nil
end

-- 惯性移动, self.decelerationRate = 0.0008
function MapBehaviour:InertiaSpeedMove()
    if self.speed then
        if type(DeltaTime) == "number" then 
            self.speed = self.speed * Mathf.Pow(self.decelerationRate, DeltaTime * 0.8);
        end
        if self.speed.magnitude < 0.15 then
            self.speed = Vector3.zero
            self.speed = nil
        else
            if self.speed.magnitude > 0 then
                local clear = false
                local vec = MapUtil:getMainCamera().gameObject.transform.localPosition - self.speed * DeltaTime
                _MAP_LEFT = _MAP_LEFT or -45.5
                _MAP_RIGHT = _MAP_RIGHT or 16.5
                _MAP_UP = _MAP_UP or -6
                _MAP_DOWN = _MAP_DOWN or -54.0
                if vec.x < _MAP_LEFT then
                    vec = Vector3(_MAP_LEFT, vec.y, MapUtil:getMainCamera().gameObject.transform.position.z)
                    clear = true
                end
                if vec.x > _MAP_RIGHT then
                    vec = Vector3(_MAP_RIGHT, vec.y, MapUtil:getMainCamera().gameObject.transform.position.z)
                    clear = true
                end
                if vec.y < _MAP_DOWN then
                    vec = Vector3(vec.x, _MAP_DOWN, MapUtil:getMainCamera().gameObject.transform.position.z)
                    clear = true
                end
                if vec.y > _MAP_UP then
                    vec = Vector3(vec.x, _MAP_UP, MapUtil:getMainCamera().gameObject.transform.position.z)
                    clear = true
                end
                MapUtil:getMainCamera().gameObject.transform.localPosition = vec;
            end
        end
    end
end

--- func 
function MapBehaviour:onSealOpen()
    self:setSkyEnable(false)
end

function MapBehaviour:onSealClose()
    self:setSkyEnable(true)
end

function MapBehaviour:setSkyEnable(enable)
    if self.Stage then
        local sky = self.Stage.transform:Find("Sky").gameObject
        if sky then
            sky:SetActive(enable)
        end
    end
end


function MapBehaviour:Start()
end

function MapBehaviour:OnDisable()
end

function MapBehaviour:OnDestroy()
    -- 退出进行存储
    -- App:applyFunc(ConstData.Time,  "storeVisitTime")
    -- App:applyFunc(ConstData.Sound,  "setupBGMusic", nil)
    -- UserDataMgr:GetInstance():StoreRegistUserData()
    -- -- clear Services
    -- local services = ServiceManager:GetInstance():allServices()
    -- for k, v in pairs(services) do
    --     local serviceName = string.gsub(k, "Service", "")
    --     App:applyFunc(serviceName, "clear")
    -- end
    -- Global.CanLoadMap = false
    -- CS.CustomPlayerPrefs.WriteAll()
    debug.log("MapBehaviour ---> OnDestroy!!!")
end

function MapBehaviour:onLevelScene()
    App:applyFunc(ConstData.Time,  "storeVisitTime")
    App:applyFunc(ConstData.Sound,  "setupBGMusic", nil)
    UserDataMgr:GetInstance():StoreRegistUserData()
    -- clear Services
    MM:clearMap()
    local services = ServiceManager:GetInstance():allServices()
    for k, v in pairs(services) do
        local serviceName = string.gsub(k, "Service", "")
        App:applyFunc(serviceName, "clear")
    end
    Global.CanLoadMap = false
    CS.CustomPlayerPrefs.WriteAll()
    debug.log("MapBehaviour ---> onLevelScene!!!")
end


------------------------------------------ 测试 -----------------------------------------
--- 测试
function MapBehaviour:DelayCallTest()
    -- 测试delayCall [OK]
    self:delayedCall(4.0, function() 
        debug.log("Awake!!!")
    end)
end

function MapBehaviour:SoundTest()
    -- 测试声音
    self:playSound(self.gameObject, "Audios/Ambient1Music.wav", {}, function()
    end)
end

--------------------------------------- 重复代码抽离 -------------------------------------
-- 点击Element, 判断出现哪个banner
function MapBehaviour:JudgeBanner(element, ret_status)
    if not IsNil(element) and not ret_status then
        self.popupOpening = App:applyFunc(ConstData.Popup, "judgeByStatus", element)
        local popupElement = App:applyFunc(ConstData.Popup, "getElementBehaviour")
        if (self.popupOpening) then 
            App:applyFunc(ConstData.Camera,  "MoveObjectInEdge", element.gameObject, nil, "1240")
        end
    end
end

-- onclick 方法中障碍物类型上带有comps
function MapBehaviour:ObstacleForceClick(element)
    local behaviour = element.comps[tostring(element.data.Behaviour)] or {}
    if behaviour and behaviour.Click then
        if element.data[ConstData.Params02] and element.data[ConstData.Params02] ~= "" then
            App:applyFunc(ConstData.Sound,  "playSound", element.data[ConstData.Params02])
        end
        behaviour:Click(element.data)
    end
end

-- onclick障碍物类型中，开采障碍物，抽离公用
function MapBehaviour:ObstacleForceNoRetClick(element)
    element:shake()
    if element.status == StatusConst.WaitingTimeForBuild or 
        element.status == StatusConst.WaitingForResHagFinish or 
        element.status == StatusConst.WaitingForObstacleHagFinish or
        element.status == StatusConst.WaitingForMineFinish then
        -- 弹出
        if element.cost_time and element.cost_time > 31 then
            UIManager:GetInstance():OpenWindow(Config.UIWindowNames.UINotice01RefreshPannel, {"expend"}, element, App:applyFunc(ConstData.AdsPlay,  "UsingAdsPannel", element), "SpeedUp_Obstacle")
        end
        App:applyFunc(ConstData.Sound,  "playSound", "touch")
        return
    end
    local popupElement = App:applyFunc(ConstData.Popup, "getElementBehaviour")
    if ((popupElement ~= element)) then 
        App:applyFunc(ConstData.Camera,  "MoveObjectInEdge", element.gameObject, nil, "1055")
    end
    if self.lastClick ~= element and not element._dialogClick then
        self.lastClick = element
        self.popupOpening = App:applyFunc(ConstData.Popup, "judgeByStatus", element)
    elseif self.lastClick ~= nil then
        self.same = true
    end
    App:applyFunc(ConstData.Sound,  "playSound", "touch")
end

-- 交换两个元素的代码抽离
function MapBehaviour:ExchangeTwoElement(other, element)
    -- App:applyFunc(ConstData.MapCore, "RemoveGrid", 1)
    -- 位置上的物体移动到vv1
    local cellHeight = self._cellHeight
    local next_pos = {element.X, element.Y}
    local otherX = other.X
    local otherY = other.Y
    --------------------------------- Begin ----------------------------------------------
    local vv1 = superMapUtils:GridIndexConvertToPosition(next_pos[1], next_pos[2]) / 100
    local oldPosition = other.gameObject.transform.position
    local newPosition = Vector3(vv1.x, vv1.y - cellHeight, -0.005)
    local other_aid = AnimateTween.moveToV3(other.gameObject, newPosition, 0.33)
    other_aid:setEase(LeanTweenType.easeOutQuint)
    AnimateTween.setCallBack(other_aid, function() 
        other.gameObject.transform.position = newPosition
    end)
    local index = next_pos[1] + 1 + next_pos[2] * current.cellXCount
    current.emptyMatrix[index] = false
    current.currentMatrix[index] = other
    other.X = next_pos[1]
    other.Y = next_pos[2]
    --------------------------------- End ----------------------------------------------
    --------------------------------- element Begin ----------------------------------------------
    local vv = superMapUtils:GridIndexConvertToPosition(otherX, otherY) / 100
    local oldPosition = element.gameObject.transform.position
    local newPosition = Vector3(vv.x, vv.y - cellHeight, -0.005)
    local cur_aid = AnimateTween.moveToV3(element.gameObject, newPosition, 0.33)
    cur_aid:setEase(LeanTweenType.easeOutQuint)
    AnimateTween.setCallBack(cur_aid, function() 
        element.gameObject.transform.position = newPosition
    end)
    local index = otherX + 1 + otherY * current.cellXCount
    current.emptyMatrix[index] = false
    current.currentMatrix[index] = element
    element.X = otherX
    element.Y = otherY
    --------------------------------- element Ended ----------------------------------------------
    -- 更新层级
    other:setNeedSortingOrder(true)
    other.sortingOrderTime = 0.1
    element:setNeedSortingOrder(true)
    element.sortingOrderTime = 0.1
end

-- 就近找，挤走等代码抽离
function MapBehaviour:MoveToNeatBy(element, vec, other, cellHeight)
    local gameObject = element.gameObject
    if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
        App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", element)
    end
    -- 这里做出说明： vec 指的是 鼠标当前位置所指向的位置, element.X 指的是当前块的位置
    -- 方式(先置空当前位置)
    if (lvType == ConstData.STR_MASTER) then 
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            element:BounceBack(function() 
                -- 恢复所有层级 
                App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, element, nil, true)
                element:setNeedSortingOrder(true)
            end)
            return
        end
    end
    -- 拖住物品本身的索引值
    local index = element.X + 1 + element.Y * self.cellXCount
    -- 滞空
    self.emptyMatrix[index] = true
    self.currentMatrix[index] = ""
    -- 查找 vec 附近的格子，使用一个，去除一个
    local vvv = App:applyFunc(ConstData.MapCore, "ResearchGird", vec.x, vec.y, {1, 1}, true)
    local next_pos = vvv[1]
    -- 如果存在格子
    if next_pos and #next_pos > 0 then
        App:applyFunc(ConstData.MapCore, "RemoveGrid", 1)
        -- 位置上的物体移动到vv1
        local otherX = other.X
        local otherY = other.Y
        --------------------------------- Begin ----------------------------------------------
        local vv1 = superMapUtils:GridIndexConvertToPosition(next_pos[1], next_pos[2]) / 100
        local oldPosition = other.gameObject.transform.position
        local newPosition = Vector3(vv1.x, vv1.y - cellHeight, -0.005)
        local other_aid = AnimateTween.moveToV3(other.gameObject, newPosition, 0.33)
        other_aid:setEase(LeanTweenType.easeOutQuint)
        AnimateTween.setCallBack(other_aid, function() 
            other.gameObject.transform.position = newPosition
        end)
        local index = next_pos[1] + 1 + next_pos[2] * self.cellXCount
        self.emptyMatrix[index] = false
        self.currentMatrix[index] = other
        other.X = next_pos[1]
        other.Y = next_pos[2]
        --------------------------------- End ----------------------------------------------
        --------------------------------- element Begin ----------------------------------------------
        local vv = superMapUtils:GridIndexConvertToPosition(otherX, otherY) / 100
        local oldPosition = gameObject.transform.position
        local newPosition = Vector3(vv.x, vv.y - cellHeight, -0.005)
        local cur_aid = AnimateTween.moveToV3(gameObject, newPosition, 0.33)
        cur_aid:setEase(LeanTweenType.easeOutQuint)
        AnimateTween.setCallBack(cur_aid, function() 
            gameObject.transform.position = newPosition
        end)
        local index = otherX + 1 + otherY * self.cellXCount
        self.emptyMatrix[index] = false
        self.currentMatrix[index] = element
        element.X = otherX
        element.Y = otherY
        --------------------------------- element Ended ----------------------------------------------
        --------------------------------- Merge Monitor Begin----------------------------------------------
        App:applyFunc(ConstData.Hint, "HiddenFiveMergeMonitor")
        if other.cellId == element.cellId then
            if other.status == element.status then  --相同状态
                App:applyFunc(ConstData.Hint, "ThreeMergeMonitor", element, true, LangData["700080"][LANG])
            end
        else
            App:applyFunc(ConstData.Hint, "ThreeMergeMonitor", element, false, LangData["700081"][LANG])
        end
        --------------------------------- Merge Monitor Ended----------------------------------------------
        -- 更新层级
        other:setNeedSortingOrder(true)
        other.sortingOrderTime = 0.1
        element:setNeedSortingOrder(true)
        element.sortingOrderTime = 0.1
    else
        -- 弹回
        if (App:applyFunc(ConstData.FirstPlayTeach, "InForceState")) then 
            App:applyFunc(ConstData.FirstPlayTeach, "DragEnd", element)
        end
        element:BounceBack(function() 
            -- 恢复所有层级 
            App:applyFunc(ConstData.MapCore, ConstData.reduceSortingOrder, element, nil, true)
            element:setNeedSortingOrder(true)
        end)
    end
end

return MapBehaviour