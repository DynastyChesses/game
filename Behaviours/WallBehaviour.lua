local WallBehaviour = class(BaseBehaviour, "WallBehaviour")
-- TODO
function WallBehaviour:Serialize()
	-- 只序列化动态数据
	local ret = {}
	ret['cellId'] = self.cellId
	-- name
	ret['name'] = self.name
	-- X
	ret['X'] = self.X
	-- Y
	ret['Y'] = self.Y
	-- status
	ret['status'] = self.status
	if self.originParam then
		ret['originParam'] = self.originParam
	end
	if self.totalBlood then
		ret['totalBlood'] = self.totalBlood
	end
	return ret
end
return WallBehaviour