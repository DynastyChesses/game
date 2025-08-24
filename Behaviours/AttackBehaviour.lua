local AttackBehaviour = class(BaseBehaviour, "AttackBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
local superMapUtils = SuperMapUtils.Instance
function AttackBehaviour:Click(data)
	-- TODO
	if self.behaviour.notClick then
		return
	end
	if self.clickend then
		return
	end
	self.clickend = true
	-- 生成攻击的钻石
	self.map = App:get(ConstData.STR_MAP)
	local xingxing2Prefab = self.map._luaParam:getGameObject("xingxing2")
	local guang2Prefab = self.map._luaParam:getGameObject("guang2")
	local AddCount = data["AddCount"]
	local monster = App:applyFunc(ConstData.Element, "getMonster")
	if IsNil(monster) then	-- 
		-- 直接破碎
		local spine = self.behaviour.gameObject.transform:Find("spine")
		local attack_spine_name = "crystal_1_attack"
		local AttackItemName = "Attackitem01"
		if self.behaviour.cellId == "Attackitem01_01" then
			attack_spine_name = "crystal_1_attack"
		elseif self.behaviour.cellId == "Attackitem01_02" then
			attack_spine_name = "crystal_2_attack"
		elseif self.behaviour.cellId == "Attackitem01_03" then
			attack_spine_name = "crystal_3_attack"
		elseif self.behaviour.cellId == "Attackitem01_04" then
			attack_spine_name = "crystal_4_attack"
		elseif self.behaviour.cellId == "Attackitem01_05" then
			attack_spine_name = "crystal_5_attack"
		end
		SpineManager.Play(spine.gameObject, attack_spine_name, false)
		SpineManager.RegisterAnimationCallback(spine.gameObject,
	    function(obj, name, index)
	        if name == "crystal_1_attack" then
	            -- 生成攻击粒子
	            self.behaviour:DestroyMySelfImmediate()
	        elseif name == "crystal_2_attack" then
	        	self.behaviour:DestroyMySelfImmediate()
	        elseif name == "crystal_3_attack" then
	        	self.behaviour:DestroyMySelfImmediate()
	        elseif name == "crystal_4_attack" then
	        	self.behaviour:DestroyMySelfImmediate()
	        elseif name == "crystal_5_attack" then
	        	self.behaviour:DestroyMySelfImmediate()
	        end
	    end,
	    function() end)
		return
	end
	-- 生成X, Y
	local vec = superMapUtils:GridIndexConvertToPosition(monster.X, monster.Y) / 100
	-- 播放骨骼动画
	local spine = self.behaviour.gameObject.transform:Find("spine")
	local attack_spine_name = "crystal_1_attack"
	local attack_power = 1
	local AttackItemName = "Attackitem01"
	local scale = Vector3(0.6, 0.6, 0.6)
	if self.behaviour.cellId == "Attackitem01_01" then
		attack_spine_name = "crystal_1_attack"
		attack_power = 1
		AttackItemName = "Attackitem01"
		scale = Vector3(0.6, 0.6, 0.6)
	elseif self.behaviour.cellId == "Attackitem01_02" then
		attack_spine_name = "crystal_2_attack"
		attack_power = 1
		AttackItemName = "Attackitem01"
		scale = Vector3(0.6, 0.6, 0.6)
	elseif self.behaviour.cellId == "Attackitem01_03" then
		attack_spine_name = "crystal_3_attack"
		attack_power = 1
		AttackItemName = "Attackitem01"
		scale = Vector3(0.6, 0.6, 0.6)
	elseif self.behaviour.cellId == "Attackitem01_04" then
		AddCount = AddCount / 12
		attack_spine_name = "crystal_4_attack"
		attack_power = 12
		AttackItemName = "Attackitem02"
		scale = Vector3(0.88, 0.88, 0.88)
	elseif self.behaviour.cellId == "Attackitem01_05" then
		AddCount = AddCount / 12
		attack_spine_name = "crystal_5_attack"
		attack_power = 12
		AttackItemName = "Attackitem02"
		scale = Vector3(0.88, 0.88, 0.88)
	end
	--
	local wall = App:applyFunc(ConstData.MapArea, "wall")
	if wall then
		attack_power = attack_power / 2.0
	end
	SpineManager.Play(spine.gameObject, attack_spine_name, false)
	-- 生成
	local Attackitem01Prefab = self.behaviour.map._luaParam:getGameObject(AttackItemName)
	local att_effPrefab = self.behaviour.map._luaParam:getGameObject("att_eff")
	self:delayedCall(0.5, function() 
		for i = 1, AddCount do
			local Attackitem01 = AGameObject.Instantiate(Attackitem01Prefab)
			Attackitem01.transform.position = self.behaviour.gameObject.transform.position + Vector3(0, 0.3, 0)
			Attackitem01.transform.localScale = scale
			local startPosition = Attackitem01.transform.position
			-- 绑定粒子(xingxing2)
			local lizi = AGameObject.Instantiate(xingxing2Prefab)
			lizi.transform:SetParent(Attackitem01.transform, true)
			lizi.transform.localPosition = Vector3.zero
			lizi:GetComponent("ParticleSystem"):Play()
			lizi.transform.localPosition = Vector3(0.3, 0.3, 0.3)
			local lizi2 = AGameObject.Instantiate(guang2Prefab)
			lizi2.transform:SetParent(Attackitem01.transform, true)
			lizi2.transform.localPosition = Vector3.zero
			lizi2:GetComponent("ParticleSystem"):Play()
			lizi2.transform.localScale = Vector3.one
			-- table.unpack()
			-- 一般生成6个参数
			local paramPosition = {}
			local step = math.random(6, 8)
			local startX = startPosition.x
			local endedX = vec.x
			local startY = startPosition.y
			local endedY = vec.y
			local rndY = math.random(-30, -10) / 10.0
			if math.random(1, 2) == 1 then
				rndY = math.random(10, 30) / 10.0
			end
			local rndX = math.random(-40, -20) / 10.0
			if math.random(1, 2) == 1 then
				rndX = math.random(20, 40) / 10.0
			end
			local _endedY = endedY + rndY
			local _endedX = endedX + rndX
			for i = 1, step + 1 do
				-- 从X方向是要线性前进
				local lerpX = _endedX + (1 / step * (i - 1)) * (1 / step * (i - 1)) * (endedX - _endedX)
				local x = startX + (1 / step * (i - 1)) * (lerpX - startX)
				-- _endedY
				local lerpY = _endedY + (1 / step * (i - 1)) * (1 / step * (i - 1)) * (endedY - _endedY)
				local y = startY + (1 / step * (i - 1)) * (lerpY - startY)
				if #paramPosition == 0 then
					paramPosition[#paramPosition + 1] = Vector3(x, y, 0)
				else
					paramPosition[#paramPosition + 1] = (paramPosition[#paramPosition] + Vector3(x, y, 0)) / 2
					paramPosition[#paramPosition + 1] = Vector3(x, y, 0)
				end
			end
			paramPosition[#paramPosition + 1] = Vector3(endedX, endedY, 0)
			local aid = AnimateTween.splineMove(Attackitem01, math.random(550, 750) / 100.0, Attackitem01.transform.position, table.unpack(paramPosition))
			AnimateTween.setCallBack(aid, function() 
				-- 攻击
				-- 生成
				if not IsNil(monster) then
					local att_eff = AGameObject.Instantiate(att_effPrefab)
					att_eff.transform.position = Vector3(vec.x, vec.y, 0)
					monster:reduceBloodBar(attack_power)
					-- 怪物
					SpineManager.Play(monster.transform:Find("spine").gameObject, "hit", false)
					AnimateTween.delayCall(1.0, function() 
						UGameObject.DestroyImmediate(att_eff)
					end)
				end
				if not IsNil(lizi) then
					UGameObject.DestroyImmediate(lizi)
					UGameObject.DestroyImmediate(lizi2)
				end
				if not IsNil(Attackitem01) then
					UGameObject.DestroyImmediate(Attackitem01)
				end
			end)
		end
	end)
	SpineManager.RegisterAnimationCallback(spine.gameObject,
    function(obj, name, index)
        if name == "crystal_1_attack" then
            -- 生成攻击粒子
            self.behaviour:DestroyMySelfImmediate()
        elseif name == "crystal_2_attack" then
        	self.behaviour:DestroyMySelfImmediate()
        elseif name == "crystal_3_attack" then
        	self.behaviour:DestroyMySelfImmediate()
        elseif name == "crystal_4_attack" then
        	self.behaviour:DestroyMySelfImmediate()
        elseif name == "crystal_5_attack" then
        	self.behaviour:DestroyMySelfImmediate()
        end
    end,
    function() end)
end
return AttackBehaviour