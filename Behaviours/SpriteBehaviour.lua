local SpriteBehaviour = class(BaseBehaviour, "SpriteBehaviour")

function SpriteBehaviour:init(...)
	local param = {...}
	self.element = param[1]
	if (not TEST_MODE) then 
		self:OnBecameInvisible() -- 自行先调用一次关闭的方法
	end
end

function SpriteBehaviour:OnBecameVisible()
	if (not self.element) then 
		return
	end
	self.element:LeaveGo(true)
end

function SpriteBehaviour:OnBecameInvisible()
	if (not self.element) then 
		return
	end
	self.element:LeaveGo(false)
end

return SpriteBehaviour