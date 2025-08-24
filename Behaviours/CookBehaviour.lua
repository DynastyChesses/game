local CookBehaviour = class(BaseBehaviour, "CookBehaviour")
local ConstData = require "Game.Data.LocalData.ConstData"
function CookBehaviour:Click(data)
	if self.clickend then
		return
	end
    if not self.behaviour then
        return
    end
    if self.behaviour.notClick then
        return
    end
    -- 音效 + 震动
    -- App:applyFunc(ConstData.Sound,  "PlaySoundAndVibrate", "tap")
	self.mapData = ClientData:GetInstance():MapData()
	self.clickend = true
    local Outputs = {}
    if self.behaviour.current_output and #self.behaviour.current_output == 0 then
        self.behaviour.current_output = nil
    end
    if not self.behaviour.current_output then
        Outputs = App:applyFunc(ConstData.Award, "awardDetail", self.behaviour.data.TreasureAward) 
    else
        Outputs = self.behaviour.current_output
    end

    if App:applyFunc(ConstData.DCAuxiliaryTool, "IsFirstCook") and App:applyFunc(ConstData.DCAuxiliaryTool, "EleCountCheck", "Runes01") == 0 then 
        App:applyFunc(ConstData.DCAuxiliaryTool, "RecordDataTutorial", "Free_01_use_food")
    end
    local args = {}
    if self.behaviour.tag == "Food_Cook_Teach" then 
        args.tags = {}
        args.tags["Runes01"] = "Food_Cook_Teach"
        args.tags["Coin01_01"] = ""
        App:applyFunc(ConstData.WbBi, "DurationEnd", DCData.new_guide, "step_14_free_02_use_food", {step = "step_14_free_02_use_food"})
        App:applyFunc(ConstData.WbBi, "DurationStart", DCData.new_guide, "step_15_free_02_use_runes")
    end
	App:applyFunc(ConstData.Element, "generateObjectByOutput2", self.behaviour, Outputs, function(isFinish, generateAward) 
        if isFinish then
            self.behaviour:DestroyMySelf()
        else
            self.clickend = false
        end
        if generateAward then 
            App:applyFunc(ConstData.DCAuxiliaryTool, "RecordResItem", "get_item_diamond", "UseFood", generateAward)
            App:applyFunc(ConstData.DCAuxiliaryTool, "RecordResItem", "get_item_coin", "UseFood", generateAward)
        end
	end, true, nil, nil, args)
	self.behaviour.dialogClick = true
	self.behaviour:delayedCall(1.0, function() 
		self.behaviour.dialogClick = false
	end)
end
return CookBehaviour