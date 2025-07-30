using System;
using System.Collections.Generic;
using System.Linq;
using HotUpdate.osP1.Enum;
using osP1.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HotUpdate.osP1
{
    public partial class BoxProduction
    {
        private List<BattleContainer> GetUnlockContainer(int usedBullet)
        {
            //解锁 并且 没用完
            var list = _containerUnlock.Where(pair =>
                    pair.Value <= usedBullet && _containerRemainSlidingWindow.ContainsKey(pair.Key) &&
                    _containerRemainSlidingWindow[pair.Key] != 0)
                .Select(pair => pair.Key).ToList();

            //最多解锁6个，如果大于6个，打乱并取前6个
            return list.Count <= 6 ? list : list.Shuffle().Take(6).ToList();
        }

        private readonly List<List<float>> _trendModifier = new List<List<float>>
        {
            new List<float>() { 1f },
            new List<float>() { 1f, 1f },
            new List<float>() { 0.75f, 1.05f, 1.2f },
            new List<float>() { 0.6f, 0.8f, 1.2f, 1.4f },
            new List<float>() { 0.5f, 0.75f, 1f, 1.25f, 1.5f },
            new List<float>() { 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.5f }
        };

        #region weight

        private float CalTrendModifier(int unlockColorNum, int index)
        {
            return _trendModifier[unlockColorNum - 1][index];
        }

        private float CalRandomModifier()
        {
            return RandomHelper.RandomFloat(0.5f, 1.5f);
        }

        private float CalRemainModifier(BattleContainer container)
        {
            return _containerRemainSlidingWindow[container] / (float)_containerRemainSlidingWindow.Values.Average();
        }

        private float CalDifficultModifier(float serialNum, float serialNumMax, float serialNumAvg)
        {
            return 1f + _maxP * K / (serialNumMax - serialNumAvg) * (serialNum - serialNumAvg);
        }

        private Dictionary<BattleContainer, float> CalWeightUltimate(List<BattleContainer> unlockContainerList)
        {
            //此处最多6个
            var unlockContainerNum = unlockContainerList.Count;

            //等于1的时候，后续的计算会出现问题（除以0问题），由于是计算权重，所以随便返回一个数即可，故这里返回1
            if (unlockContainerNum == 1)
                return new Dictionary<BattleContainer, float>()
                {
                    { unlockContainerList[0], 1f }
                };

            //step 基础权重
            var weightBase = new float[unlockContainerNum];
            for (var i = 0; i < unlockContainerNum; i++)
            {
                var temp = (float)_bulletSegmentLength / unlockContainerNum;
                weightBase[i] = temp * CalTrendModifier(unlockContainerNum, i) * CalRandomModifier() * 1000f;
            }

            //step 分配颜色
            var weightBaseAssigned = new Dictionary<BattleContainer, float>();
            var tempList = unlockContainerList.ToList();
            tempList.Shuffle();
            for (var i = 0; i < weightBase.Length; i++)
            {
                var container = tempList[i];
                var weight = weightBase[i];
                weightBaseAssigned[container] = weight;
            }

            //step remain修正
            var weightRemain = new Dictionary<BattleContainer, float>();
            foreach (var container in weightBaseAssigned.Keys)
            {
                weightRemain[container] = weightBaseAssigned[container] * CalRemainModifier(container);
            }

            //step 排序 weiRemain
            var sortedList = weightRemain.OrderBy(pair => pair.Value).ToList();
            var serialNumSum = sortedList.Count * (sortedList.Count + 1) / 2f; //序号总和
            var serialNumAvg = serialNumSum / sortedList.Count; //平均序号
            var serialNumMax = sortedList.Count; //最大序号
            var serialNum = 0;

            //step difficult修正
            var weightDifficult = new Dictionary<BattleContainer, float>();
            foreach (var (container, weight) in sortedList)
            {
                serialNum++;
                weightDifficult[container] = weight * CalDifficultModifier(serialNum, serialNumMax, serialNumAvg);
            }

            //step 最终权重
            var weightUltimate = new Dictionary<BattleContainer, float>();
            foreach (var container in weightDifficult.Keys)
            {
                weightUltimate[container] = weightDifficult[container];
            }

            return weightUltimate;
        }

        #endregion

        private Dictionary<BattleContainer, int> CalContainerNum(Dictionary<BattleContainer, float> weightUltimate)
        {
            var weightSum = weightUltimate.Sum(pair => pair.Value);

            //step 预分配
            var preallocation = new Dictionary<BattleContainer, int>();
            foreach (var container in weightUltimate.Keys)
            {
                var num = Mathf.RoundToInt(weightUltimate[container] / weightSum * _bulletSegmentLength);
                //特殊处理，num取整为0时，分配一个
                preallocation[container] = num == 0 ? 1 : num;
            }

            //step 排序预分配
            var sortedPreallocation = preallocation.OrderBy(pair => pair.Value).ToList();

            //step 真分配 和余量进行比较，取最小，tempRemain用于下一步修正
            var tempRemain = new Dictionary<BattleContainer, int>();
            var allocation = new Dictionary<BattleContainer, int>();
            for (int i = 0; i < sortedPreallocation.Count; i++)
            {
                var (container, num) = sortedPreallocation[i];
                var remain = _containerRemainSlidingWindow[container];
                if (num <= remain)
                {
                    allocation[container] = num;
                    tempRemain[container] = remain - num;
                }
                else
                {
                    allocation[container] = remain;
                    tempRemain[container] = 0;
                    //多出的小球数量会加到下一个颜色的预分配数量中
                    if (i == sortedPreallocation.Count - 1)
                        continue;

                    var delta = num - remain;
                    var (nextContainer, nextNum) = sortedPreallocation[i + 1];
                    nextNum += delta;
                    sortedPreallocation[i + 1] = new KeyValuePair<BattleContainer, int>(nextContainer, nextNum);
                }
            }

            //step 不等于 _bulletSegmentLength 的修正
            var allocatedNum = allocation.Values.Sum();
            if (allocatedNum > _bulletSegmentLength) //多是因为 预分配按四舍五入，四舍五入为0 需要分配1个
            {
                var delta = allocatedNum - _bulletSegmentLength;

                var sortedList = allocation.OrderBy(pair => pair.Value).ToList();
                //每次肯定能减至少一个，delta次就减少delta个
                var count = delta;
                for (int i = 0; i < count; i++)
                {
                    for (int j = sortedList.Count - 1; j >= 0; j--)
                    {
                        var (container, num) = sortedList[j];
                        if (delta > 0 && allocation[container] > 1)
                        {
                            allocation[container] -= 1;
                            delta--;
                        }
                    }
                }

                if (delta > 0)
                    Debug.LogError("分配超过 _bulletSegmentLength(20) 个以上，但是削减成 20 个时失败");
            }
            else if (allocatedNum < _bulletSegmentLength) //少是因为 真实分配的时候，remain不足了
            {
                //尽可能补充
                var delta = _bulletSegmentLength - allocatedNum;

                tempRemain = tempRemain.Where(pair => pair.Value > 0)
                    .ToDictionary(pair => pair.Key, pair => pair.Value); //还有剩余的
                var remainSum = tempRemain.Sum(pair => pair.Value);

                if (delta <= remainSum) //肯定能填满
                {
                    var count = delta;
                    var keys = tempRemain.Keys.ToList().Shuffle();

                    for (int i = 0; i < count; i++)
                    {
                        foreach (var container in keys)
                        {
                            if (delta > 0 && tempRemain[container] > 0)
                            {
                                tempRemain[container] -= 1;
                                allocation[container] += 1;
                                delta--;
                            }
                        }
                    }
                }
                else //填不满，尽可能补充
                {
                    //给remain里的都加上呗，反正也超不过20个
                    foreach (var container in tempRemain.Keys)
                    {
                        allocation[container] += tempRemain[container];
                    }
                }
            }

            return allocation;
        }

        private Dictionary<int, int> RandomBoxType(Dictionary<int, float> boxWeight, int boxSegmentLength)
        {
            var list = boxWeight.ToList();
            var slotNum = list.Select(pair => pair.Key).ToList();
            var weight = list.Select(pair => pair.Value).ToList();
            var rangeList = RandomHelper.Weight2Range(weight);

            var ret = new Dictionary<int, int>();
            for (int i = 0; i < boxSegmentLength; i++)
            {
                var randomNum = RandomHelper.RandomFloat(0f, 1f);

                for (var j = 0; j < rangeList.Count; j++)
                {
                    var (lowerLimit, upperLimit) = rangeList[j];

                    if (lowerLimit <= randomNum && randomNum <= upperLimit)
                    {
                        if (ret.ContainsKey(slotNum[j]))
                            ret[slotNum[j]] += 1;
                        else
                            ret[slotNum[j]] = 1;

                        break;
                    }
                }
            }

            return ret;
        }

        private List<Box4Container> ArrangeBox(Dictionary<int, int> boxType)
        {
            var ret = new List<Box4Container>();
            foreach (var (slotNum, num) in boxType) // slotNum 个槽的箱子有 num 个，例如: 2 个槽的箱子有 3 个
            {
                for (int i = 0; i < num; i++)
                {
                    var tempBox = new Box4Container
                    {
                        SlotNum = slotNum,
                        Bullets = new List<(BattleContainer, int)>()
                    };
                    ret.Add(tempBox);
                }
            }

            return ret.Shuffle();
        }

        #region connection

        private int RandomSameConnectionNum(int slotSum, int unlockContainerNum, bool isBrickArrangement = false)
        {
            //step 连接总数
            var connection = slotSum - 1;

            //不随机的连接，不同连接
            var nonrandomConnection = unlockContainerNum;

            //随机的连接，不同连接 or 相同连接
            var randomConnection = connection - nonrandomConnection;

            var sameConnection = 0;
            for (int i = 0; i < randomConnection; i++)
            {
                var randomNum = Random.Range(0f, 1f);
                if (randomNum <= (isBrickArrangement ? _brickPSame : P)) //P 是 PSame
                    sameConnection++;
            }

            //var maxConnection = containerNum.Sum(pair => pair.Value - 1);

            return sameConnection;
        }

        private Dictionary<BattleContainer, float> CalWeightAssignSameConnection(
            Dictionary<BattleContainer, int> containerNum)
        {
            var slotWeightSameConnection = new Dictionary<BattleContainer, float>();
            foreach (var container in containerNum.Keys)
            {
                var num = containerNum[container];
                slotWeightSameConnection[container] = num == 1 ? 0f : num; //只有一个，则权重为0，为0则不分配连接
            }


            var weightSum = slotWeightSameConnection.Values.Sum();
            if (weightSum != 0f) //如果等于0了，说明 container 都不能被赋予 相同连接，所以直接返回就行
            {
                foreach (var container in containerNum.Keys)
                {
                    slotWeightSameConnection[container] /= weightSum;
                }
            }

            return slotWeightSameConnection;
        }

        private Dictionary<BattleContainer, int> AssignSameConnection(
            Dictionary<BattleContainer, float> weightSameConnection, int sameConnectionNum,
            Dictionary<BattleContainer, int> containerNum)
        {
            var weightSameConnectionList = weightSameConnection.ToList();
            var keys = weightSameConnectionList.Select(pair => pair.Key).ToList();
            var values = weightSameConnectionList.Select(pair => pair.Value).ToList();


            var range = RandomHelper.Weight2Range(values);


            var containerSameConnection = new Dictionary<BattleContainer, int>();
            foreach (var container in keys)
            {
                containerSameConnection[container] = 0;
            }

            //有几个 相同连接 就随机几次
            for (var i = 0; i < sameConnectionNum; i++)
            {
                var randomNum = RandomHelper.RandomFloat(0f, 1f);


                for (var j = 0; j < keys.Count; j++)
                {
                    var key = keys[j];
                    var (lowerLimit, upperLimit) = range[j];
                    if (lowerLimit <= randomNum && randomNum <= upperLimit)
                    {
                        containerSameConnection[key]++;
                        break;
                    }
                }
            }

            //分配连接时，如果超过了容器能得到的最大连接，则取小
            foreach (var container in containerNum.Keys)
            {
                var maxConnection = containerNum[container] - 1;
                containerSameConnection[container] = Mathf.Min(maxConnection, containerSameConnection[container]);
            }

            return containerSameConnection;
        }

        #endregion

        #region placeholder

        private Dictionary<BattleContainer, int> RandomPlaceholder(int slotSum,
            Dictionary<BattleContainer, int> containerSameConnection, Dictionary<BattleContainer, int> containerNum)
        {
            var placeHolder = new Dictionary<BattleContainer, int>();
            //每个container，至少分配（连接数 + 1）个槽
            foreach (var key in containerSameConnection.Keys)
            {
                var sameConnection = containerSameConnection[key];

                var leastAssign = sameConnection + 1;
                placeHolder[key] = leastAssign;
                slotSum -= leastAssign;

                if (slotSum < 0)
                    Debug.LogError("至少分配 (连接数 + 1) 槽的时候，槽不够了");
            }

            //先遍历到的 key 有优势，因为此时 slotSum 更容易剩余，所以进行 keys 的打乱
            var keys = containerSameConnection.Keys.ToList().Shuffle();

            foreach (var key in keys)
            {
                //排除掉 0个 和 1个 连接，因为上一步已经分配完了
                if (containerSameConnection[key] == 0 || containerSameConnection[key] == 1)
                    continue;

                var sameConnection = containerSameConnection[key];

                var lowerLimit = sameConnection + 1; //相同连接 至少占用 sameConnection + 1 个
                var upperLimit = sameConnection * 2; //相同连接 最多占用 sameConnection * 2 个

                var leastAssign = sameConnection + 1;
                var prepareAssign = RandomHelper.RandomInt(lowerLimit, upperLimit);
                var deltaAssign = prepareAssign - leastAssign;

                deltaAssign = Mathf.Min(deltaAssign, slotSum);
                slotSum -= deltaAssign;
                placeHolder[key] += deltaAssign;
            }

            //分配占位时，如果超过了容器能得到的最大占位，则取小
            foreach (var container in containerNum.Keys)
            {
                placeHolder[container] = Mathf.Min(placeHolder[container], containerNum[container]);
            }

            return placeHolder;
        }

        private Dictionary<BattleContainer, List<int>> RandomPlaceholderGroup(
            Dictionary<BattleContainer, int> containerSameConnection, Dictionary<BattleContainer, int> placeholder)
        {
            var placeholderGroup = new Dictionary<BattleContainer, List<int>>();
            foreach (var key in containerSameConnection.Keys)
            {
                var connectionNum = containerSameConnection[key];
                var placeholderNum = placeholder[key];
                var groupNum = placeholderNum - connectionNum; //例如，5个占位，3个连接，相减得出，需要分2组，X-X-X，X-X

                if (groupNum < 0)
                    Debug.LogError("需要分，负数个组");


                placeholderGroup[key] = new List<int>();
                if (placeholderNum == 1) //1个槽，0个连接
                {
                    placeholderGroup[key].Add(1);
                }
                else
                {
                    //每组先分配 两个占位
                    for (var i = 0; i < groupNum; i++)
                    {
                        placeholderGroup[key].Add(2);
                    }

                    //剩余占位，每组至少分配两个占位，所以分配了 groupNum * 2 个
                    var remainPlaceholderNum = placeholderNum - groupNum * 2;
                    var upperLimit = placeholderGroup[key].Count - 1;
                    for (int i = 0; i < remainPlaceholderNum; i++)
                    {
                        var randomNum = RandomHelper.RandomInt(0, upperLimit);
                        placeholderGroup[key][randomNum] += 1;
                    }
                }
            }

            return placeholderGroup;
        }

        #endregion

        private BattleContainer[] AssignContainer2Slot(int slotNum,
            Dictionary<BattleContainer, List<int>> placeholderGroup, Dictionary<BattleContainer, int> containerNum)
        {
            var keys = placeholderGroup.Keys.ToList();
            var remainNum = slotNum - placeholderGroup.Sum(pair => pair.Value.Sum());
            const int magicNumber = -2;

            var row = keys.Count + 1;
            var col = Mathf.Max(placeholderGroup.Values.Max(list => list.Count), remainNum);

            //step 准备矩阵
            var placeholderGroupMatrix = new List<List<int>>();
            var containerMatrix = new List<List<BattleContainer>>();
            var IsChosenMatrix = new List<List<bool>>();
            for (int i = 0; i < row; i++)
            {
                var listGroup = new List<int>();
                var listContainer = new List<BattleContainer>();
                var listIsChosen = new List<bool>();
                if (i == row - 1) //random container 行
                {
                    for (var j = 0; j < col; j++)
                    {
                        if (j < remainNum)
                        {
                            listGroup.Add(1);
                            listContainer.Add(BattleContainer.None);
                            listIsChosen.Add(false);
                        }
                        else
                        {
                            listGroup.Add(magicNumber);
                            listContainer.Add(BattleContainer.None);
                            listIsChosen.Add(true);
                        }
                    }
                }
                else // placeholderGroup 行
                {
                    var count = placeholderGroup[keys[i]].Count;
                    for (var j = 0; j < col; j++)
                    {
                        if (j < count)
                        {
                            listGroup.Add(placeholderGroup[keys[i]][j]);
                            listContainer.Add(keys[i]);
                            listIsChosen.Add(false);
                        }
                        else
                        {
                            listGroup.Add(magicNumber);
                            listContainer.Add(BattleContainer.None);
                            listIsChosen.Add(true);
                        }
                    }
                }

                placeholderGroupMatrix.Add(listGroup);
                containerMatrix.Add(listContainer);
                IsChosenMatrix.Add(listIsChosen);
            }

            //step 排列
            var choiceSum = placeholderGroup.Sum(pair => pair.Value.Count);
            var slot = new BattleContainer[slotNum];
            var currentSlotIndex = 0;
            var randomIndexList = Enumerable.Range(0, row * col).ToList().Shuffle();
            var lastContainer = BattleContainer.None;

            bool HasOtherChoice(int rowIndex)
            {
                var ret = false;
                for (int i = 0; i < row; i++)
                {
                    if (i == rowIndex)
                        continue;

                    if (IsChosenMatrix[i].Any(val => val == false))
                    {
                        ret = true;
                        break;
                    }
                }

                return ret;
            }

            //重复 row * col 次
            for (int time = 0; time < row * col; time++)
            {
                foreach (var index in randomIndexList)
                {
                    var currentRow = index / col;
                    var currentCol = index % col;
                    if (IsChosenMatrix[currentRow][currentCol])
                        continue; //使用过就跳过

                    var container = containerMatrix[currentRow][currentCol];


                    if (lastContainer == container && lastContainer != BattleContainer.None &&
                        HasOtherChoice(currentRow)) //None此处代表随机 container，所以两个随机 container 可以挨着，如果没有其他选择了则只能选该相同
                        continue;

                    var num = placeholderGroupMatrix[currentRow][currentCol];


                    for (int i = 0; i < num; i++)
                    {
                        slot[currentSlotIndex + i] = container;
                    }


                    currentSlotIndex += num;

                    IsChosenMatrix[currentRow][currentCol] = true;
                    lastContainer = container;
                }
            }


            //step 赋值 none
            var remainContainer = containerNum.ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var (container, placeholderList) in placeholderGroup)
            {
                //每个placeholder至少放一个，还剩多少
                remainContainer[container] -= placeholderList.Sum();
                if (remainContainer[container] == 0)
                    remainContainer.Remove(container);
            }

            for (int i = 0; i < slot.Length; i++)
            {
                if (slot[i] != BattleContainer.None)
                    continue;

                var left = (i - 1 < 0) ? BattleContainer.None : slot[i - 1];
                var right = (i + 1 >= slot.Length) ? BattleContainer.None : slot[i + 1];


                //因为只剩下了 不同 连接，所以需要去除相同的选项
                var temp = new Dictionary<BattleContainer, int>(remainContainer);
                if (left != BattleContainer.None && temp.ContainsKey(left))
                    temp.Remove(left);
                if (right != BattleContainer.None && temp.ContainsKey(right))
                    temp.Remove(right);

                if (temp.Count > 0)
                {
                    var upperLimit = temp.Count - 1;
                    var randomIndex = RandomHelper.RandomInt(0, upperLimit);
                    var randomKey = temp.Keys.ElementAt(randomIndex);


                    slot[i] = randomKey;

                    remainContainer[randomKey] -= 1;
                    if (remainContainer[randomKey] == 0)
                        remainContainer.Remove(randomKey);
                }
                else
                {
                    if (remainContainer.Count >
                        0) //temp为空，但是remainContainer还有，此时处于一种情况：没有其他选择 -> 随机分配一个，牺牲 连接性 换取 分配完整性
                    {
                        var upperLimit = remainContainer.Count - 1;
                        var randomIndex = RandomHelper.RandomInt(0, upperLimit);
                        var randomKey = remainContainer.Keys.ElementAt(randomIndex);

                        slot[i] = randomKey;

                        remainContainer[randomKey] -= 1;
                        if (remainContainer[randomKey] == 0)
                            remainContainer.Remove(randomKey);
                    }
                    else //temp 和 remainContainer 都没了，此时才是真的不能分配
                    {
                    }
                }
            }

            //一般是最后一次分配不足20个时，进行数组处理，其他情况暂时LogErr
            var bulletNum = containerNum.Sum(pair => pair.Value);
            if (bulletNum <= _bulletSegmentLength)
                slot = slot.Where(container => container != BattleContainer.None).ToArray();
            else
                Debug.LogError("其余情况分配不足 20 个");

            return slot;
        }

        private (BattleContainer, int)[] AssignNumber2Slot(
            Dictionary<BattleContainer, int> containerNum, BattleContainer[] slot)
        {
            var slotWithNum = new (BattleContainer, int)[slot.Length];
            for (var i = 0; i < slotWithNum.Length; i++)
            {
                slotWithNum[i] = (slot[i], 0);
            }

            //先各分配一个
            var remainContainer = containerNum.ToDictionary(pair => pair.Key, pair => pair.Value);
            for (var i = 0; i < slotWithNum.Length; i++)
            {
                var (container, num) = slotWithNum[i];
                if (!remainContainer.ContainsKey(container))
                {
                    Debug.LogError("key用完了");
                    continue;
                }

                remainContainer[container] -= 1;
                if (remainContainer[container] == 0)
                    remainContainer.Remove(container);

                slotWithNum[i].Item2 += 1;
            }

            //消耗完 remainContainer
            var remainNum = remainContainer.Sum(pair => pair.Value);
            for (var i = 0; i < remainNum; i++)
            {
                var keys = remainContainer.Keys.ToList();
                var randomKey = keys[RandomHelper.RandomInt(0, keys.Count - 1)];

                remainContainer[randomKey] -= 1;
                if (remainContainer[randomKey] == 0)
                    remainContainer.Remove(randomKey);

                var indexList = new List<int>();
                for (var j = 0; j < slotWithNum.Length; j++)
                {
                    if (slotWithNum[j].Item1 == randomKey)
                    {
                        indexList.Add(j);
                    }
                }

                var randomIndex = indexList[RandomHelper.RandomInt(0, indexList.Count - 1)];
                slotWithNum[randomIndex].Item2 += 1;
            }

            return slotWithNum;
        }

        private List<Box4Container> AssignSlot2Box((BattleContainer, int)[] slotWithNum, List<Box4Container> boxList)
        {
            var currentIndex = 0;
            foreach (var tempBox in boxList)
            {
                for (int i = 0; i < tempBox.SlotNum; i++)
                {
                    var currentSlot = slotWithNum[currentIndex++];
                    tempBox.Bullets.Add(currentSlot);
                    if (currentIndex >= slotWithNum.Length) //slot 用完了
                    {
                        break;
                    }
                }

                if (currentIndex >= slotWithNum.Length) //slot 用完了
                {
                    break;
                }
            }

            return boxList.Where(box4Container => box4Container.Bullets.Count != 0).ToList();
        }
    }
}