﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SuperScrollView
{
    [System.Serializable]
    public class ItemPrefabConfData
    {
        public GameObject mItemPrefab = null;
        public float mPadding = 0;
        public int mInitCreateCount = 0;
        public float mStartPosOffset = 0;
    }


    public class LoopListViewInitParam
    {
        // all the default values
        public float mDistanceForRecycle0 = 300; //mDistanceForRecycle0 should be larger than mDistanceForNew0
        public float mDistanceForNew0 = 200;
        public float mDistanceForRecycle1 = 300;//mDistanceForRecycle1 should be larger than mDistanceForNew1
        public float mDistanceForNew1 = 200;
        public float mSmoothDumpRate = 0.3f;
        public float mSnapFinishThreshold = 0.01f;
        public float mSnapVecThreshold = 145;
        public float mItemDefaultWithPaddingSize = 20;//item's default size (with padding)

        public static LoopListViewInitParam CopyDefaultInitParam()
        {
            return new LoopListViewInitParam();
        }
    }


    [ExecuteInEditMode]
    public class LoopListView2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        class SnapData
        {
            public SnapStatus mSnapStatus = SnapStatus.NoTargetSet;
            public int mSnapTargetIndex = 0;
            public float mTargetSnapVal = 0;
            public float mCurSnapVal = 0;
            public bool mIsForceSnapTo = false;
            public bool mIsTempTarget = false;
            public int mTempTargetIndex = -1;
            public float mMoveMaxAbsVec = -1;
            public void Clear()
            {
                mSnapStatus = SnapStatus.NoTargetSet;
                mTempTargetIndex = -1;
                mIsForceSnapTo = false;
                mMoveMaxAbsVec = -1;
            }
        }

        Dictionary<string, ItemPool> mItemPoolDict = new Dictionary<string, ItemPool>();
        List<ItemPool> mItemPoolList = new List<ItemPool>();
        [SerializeField]
        List<ItemPrefabConfData> mItemPrefabDataList = new List<ItemPrefabConfData>();

        [SerializeField]
        private ListItemArrangeType mArrangeType = ListItemArrangeType.TopToBottom;
        public ListItemArrangeType ArrangeType { get { return mArrangeType; } set { mArrangeType = value; } }

        List<LoopListViewItem2> mItemList = new List<LoopListViewItem2>();
        RectTransform mContainerTrans;
        ScrollRect mScrollRect = null;
        RectTransform mScrollRectTransform = null;
        RectTransform mViewPortRectTransform = null;
        float mItemDefaultWithPaddingSize = 20;
        int mItemTotalCount = 0;
        bool mIsVertList = false;
        System.Func<LoopListView2, int, LoopListViewItem2> mOnGetItemByIndex;
        Vector3[] mItemWorldCorners = new Vector3[4];
        Vector3[] mViewPortRectLocalCorners = new Vector3[4];
        int mCurReadyMinItemIndex = 0;
        int mCurReadyMaxItemIndex = 0;
        bool mNeedCheckNextMinItem = true;
        bool mNeedCheckNextMaxItem = true;
        ItemPosMgr mItemPosMgr = null;
        float mDistanceForRecycle0 = 300;
        float mDistanceForNew0 = 200;
        float mDistanceForRecycle1 = 300;
        float mDistanceForNew1 = 200;
        [SerializeField]
        bool mSupportScrollBar = true;
        bool mIsDraging = false;
        PointerEventData mPointerEventData = null;
        public System.Action mOnBeginDragAction = null;
        public System.Action mOnDragingAction = null;
        public System.Action mOnEndDragAction = null;
        int mLastItemIndex = 0;
        float mLastItemPadding = 0;
        float mSmoothDumpVel = 0;
        float mSmoothDumpRate = 0.3f;
        float mSnapFinishThreshold = 0.1f;
        float mSnapVecThreshold = 145;
        float mSnapMoveDefaultMaxAbsVec = 3400f;
        [SerializeField]
        bool mItemSnapEnable = false;


        Vector3 mLastFrameContainerPos = Vector3.zero;
        public System.Action<LoopListView2,LoopListViewItem2> mOnSnapItemFinished = null;
        public System.Action<LoopListView2, LoopListViewItem2> mOnSnapNearestChanged = null;
        int mCurSnapNearestItemIndex = -1;
        Vector2 mAdjustedVec;
        bool mNeedAdjustVec = false;
        int mLeftSnapUpdateExtraCount = 1;
        [SerializeField]
        Vector2 mViewPortSnapPivot = Vector2.zero;
        [SerializeField]
        Vector2 mItemSnapPivot = Vector2.zero;
        ClickEventListener mScrollBarClickEventListener = null;
        SnapData mCurSnapData = new SnapData();
        Vector3 mLastSnapCheckPos = Vector3.zero;
        bool mListViewInited = false;
        int mListUpdateCheckFrameCount = 0;
        public System.Action<LoopListView2> OnListViewStart = null;

        public List<ItemPrefabConfData> ItemPrefabDataList
        {
            get
            {
                return mItemPrefabDataList;
            }
        }

        public List<LoopListViewItem2> ItemList
        {
            get
            {
                return mItemList;
            }
        }

        public bool IsVertList
        {
            get
            {
                return mIsVertList;
            }
        }
        public int ItemTotalCount
        {
            get
            {
                return mItemTotalCount;
            }
        }

        public RectTransform ContainerTrans
        {
            get
            {
                return mContainerTrans;
            }
        }

        public ScrollRect ScrollRect
        {
            get
            {
                return mScrollRect;
            }
        }

        public bool IsDraging
        {
            get
            {
                return mIsDraging;
            }
        }

        public bool ItemSnapEnable
        {
            get {return mItemSnapEnable;}
            set { mItemSnapEnable = value; }
        }

        public bool SupportScrollBar
        {
            get { return mSupportScrollBar; }
            set { mSupportScrollBar = value; }
        }

        public float SnapMoveDefaultMaxAbsVec
        {
            get { return mSnapMoveDefaultMaxAbsVec; }
            set { mSnapMoveDefaultMaxAbsVec = value; }
        }

        public ItemPrefabConfData GetItemPrefabConfData(string prefabName)
        {
            foreach (ItemPrefabConfData data in mItemPrefabDataList)
            {
                if (data.mItemPrefab == null)
                {
                    Debug.LogError("A item prefab is null ");
                    continue;
                }
                if (prefabName == data.mItemPrefab.name)
                {
                    return data;
                }

            }
            return null;
        }
        public void InitArabicItemPrefabData()
        {
            foreach (ItemPrefabConfData data in mItemPrefabDataList)
            {
                data.mStartPosOffset = -data.mStartPosOffset;
            }
        }

        public void OnItemPrefabChanged(string prefabName)
        {
            ItemPrefabConfData data = GetItemPrefabConfData(prefabName);
            if(data == null)
            {
                return;
            }
            ItemPool pool = null;
            if (mItemPoolDict.TryGetValue(prefabName, out pool) == false)
            {
                return;
            }
            int firstItemIndex = -1;
            Vector3 pos = Vector3.zero;
            if(mItemList.Count > 0)
            {
                firstItemIndex = mItemList[0].ItemIndex;
                pos = mItemList[0].CachedRectTransform.anchoredPosition3D;
            }
            RecycleAllItem();
            ClearAllTmpRecycledItem();
            pool.DestroyAllItem();
            pool.Init(data.mItemPrefab, data.mPadding, data.mStartPosOffset, data.mInitCreateCount, mContainerTrans);
            if(firstItemIndex >= 0)
            {
                RefreshAllShownItemWithFirstIndexAndPos(firstItemIndex, pos);
            }
        }

        void InitComponentRef()
        {
            mScrollRect = gameObject.GetComponent<ScrollRect>();
            if (mScrollRect == null)
            {
                Debug.LogError("ListView Init Failed! ScrollRect component not found!");
                return;
            }
            
            mScrollRectTransform = mScrollRect.GetComponent<RectTransform>();
            mContainerTrans = mScrollRect.content;
            mViewPortRectTransform = mScrollRect.viewport;
            if (mViewPortRectTransform == null)
            {
                mViewPortRectTransform = mScrollRectTransform;
            }
            if (mScrollRect.horizontalScrollbarVisibility == ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport && mScrollRect.horizontalScrollbar != null)
            {
                Debug.LogError("ScrollRect.horizontalScrollbarVisibility cannot be set to AutoHideAndExpandViewport");
            }
            if (mScrollRect.verticalScrollbarVisibility == ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport && mScrollRect.verticalScrollbar != null)
            {
                Debug.LogError("ScrollRect.verticalScrollbarVisibility cannot be set to AutoHideAndExpandViewport");
            }
        }

        /*
        InitListView method is to initiate the LoopListView2 component. There are 3 parameters:
        itemTotalCount: the total item count in the listview. If this parameter is set -1, then means there are infinite items, and scrollbar would not be supported, 
            and the ItemIndex can be from –MaxInt to +MaxInt. If this parameter is set a value >=0 , then the ItemIndex can only be from 0 to itemTotalCount -1.
        onGetItemByIndex: when a item is getting in the scrollrect viewport, and this Action will be called with the item’ index as a parameter, 
            to let you create the item and update its content.
        */
        public void InitListView(int itemTotalCount,
            System.Func<LoopListView2, int, LoopListViewItem2> onGetItemByIndex,
            LoopListViewInitParam initParam = null)
        {
            if(mListViewInited == true)
            {
                Debug.LogError("LoopListView2.InitListView method can be called only once.");
            }
            
            if(initParam != null)
            {
                mDistanceForRecycle0 = initParam.mDistanceForRecycle0;
                mDistanceForNew0 = initParam.mDistanceForNew0;
                mDistanceForRecycle1 = initParam.mDistanceForRecycle1;
                mDistanceForNew1 = initParam.mDistanceForNew1;
                mSmoothDumpRate = initParam.mSmoothDumpRate;
                mSnapFinishThreshold = initParam.mSnapFinishThreshold;
                mSnapVecThreshold = initParam.mSnapVecThreshold;
                mItemDefaultWithPaddingSize = initParam.mItemDefaultWithPaddingSize;
            }
            if(mDistanceForRecycle0 <= mDistanceForNew0)
            {
                Debug.LogError("mDistanceForRecycle0 should be bigger than mDistanceForNew0");
            }
            if (mDistanceForRecycle1 <= mDistanceForNew1)
            {
                Debug.LogError("mDistanceForRecycle1 should be bigger than mDistanceForNew1");
            }

            InitComponentRef();

            mCurSnapData.Clear();
            mItemPosMgr = new ItemPosMgr(mItemDefaultWithPaddingSize);
            mIsVertList = (mArrangeType == ListItemArrangeType.TopToBottom || mArrangeType == ListItemArrangeType.BottomToTop);
            mScrollRect.horizontal = !mIsVertList;
            mScrollRect.vertical = mIsVertList;
            SetScrollbarListener();
            AdjustPivot(mViewPortRectTransform);
            AdjustAnchor(mContainerTrans);
            AdjustContainerPivot(mContainerTrans);
            InitItemPool();
            mOnGetItemByIndex = onGetItemByIndex;
            ResetListView();
            //SetListItemCount(itemTotalCount, true);
            mCurSnapData.Clear();
            mItemTotalCount = itemTotalCount;
            if (mItemTotalCount < 0)
            {
                mSupportScrollBar = false;
            }
            if (mSupportScrollBar)
            {
                mItemPosMgr.SetItemMaxCount(mItemTotalCount);
            }
            else
            {
                mItemPosMgr.SetItemMaxCount(0);
            }
            mCurReadyMaxItemIndex = 0;
            mCurReadyMinItemIndex = 0;
            mLeftSnapUpdateExtraCount = 1;
            mNeedCheckNextMaxItem = true;
            mNeedCheckNextMinItem = true;
            UpdateContentSize();

            mListViewInited = true;
        }

        void Start()
        {
            if(OnListViewStart != null)
            {
                OnListViewStart(this);
            }
        }

        void SetScrollbarListener()
        {
            mScrollBarClickEventListener = null;
            Scrollbar curScrollBar = null;
            if (mIsVertList && mScrollRect.verticalScrollbar != null)
            {
                curScrollBar = mScrollRect.verticalScrollbar;

            }
            if (!mIsVertList && mScrollRect.horizontalScrollbar != null)
            {
                curScrollBar = mScrollRect.horizontalScrollbar;
            }
            if(curScrollBar == null)
            {
                return;
            }
            ClickEventListener listener = ClickEventListener.Get(curScrollBar.gameObject);
            mScrollBarClickEventListener = listener;
            listener.SetPointerUpHandler(OnPointerUpInScrollBar);
            listener.SetPointerDownHandler(OnPointerDownInScrollBar);
        }

        void OnPointerDownInScrollBar(GameObject obj)
        {
            mCurSnapData.Clear();
        }

        void OnPointerUpInScrollBar(GameObject obj)
        {
            ForceSnapUpdateCheck();
        }

        public void ResetListView(bool resetPos = true)
        {
            mViewPortRectTransform?.GetLocalCorners(mViewPortRectLocalCorners);
            if(resetPos)
            {
                mContainerTrans.anchoredPosition3D = Vector3.zero;
            }
            ForceSnapUpdateCheck();
        }


        /*
        This method may use to set the item total count of the scrollview at runtime. 
        If this parameter is set -1, then means there are infinite items,
        and scrollbar would not be supported, and the ItemIndex can be from –MaxInt to +MaxInt. 
        If this parameter is set a value >=0 , then the ItemIndex can only be from 0 to itemTotalCount -1.  
        If resetPos is set false, then the scrollrect’s content position will not changed after this method finished.
        */
        public void SetListItemCount(int itemCount, bool resetPos = true)
        {
            if(itemCount == mItemTotalCount)
            {
                return;
            }
            mCurSnapData.Clear();
            mItemTotalCount = itemCount;
            if (mItemTotalCount < 0)
            {
                mSupportScrollBar = false;
            }
            if (mSupportScrollBar)
            {
                mItemPosMgr.SetItemMaxCount(mItemTotalCount);
            }
            else
            {
                mItemPosMgr.SetItemMaxCount(0);
            }
            if (mItemTotalCount == 0)
            {
                mCurReadyMaxItemIndex = 0;
                mCurReadyMinItemIndex = 0;
                mNeedCheckNextMaxItem = false;
                mNeedCheckNextMinItem = false;
                RecycleAllItem();
                ClearAllTmpRecycledItem();
                UpdateContentSize();
                return;
            }
            if(mCurReadyMaxItemIndex >= mItemTotalCount)
            {
                mCurReadyMaxItemIndex = mItemTotalCount - 1;
            }
            mLeftSnapUpdateExtraCount = 1;
            mNeedCheckNextMaxItem = true;
            mNeedCheckNextMinItem = true;
            if (resetPos)
            {
                MovePanelToItemIndex(0, 0);
                return;
            }
            if (mItemList.Count == 0)
            {
                MovePanelToItemIndex(0, 0);
                return;
            }
            int maxItemIndex = mItemTotalCount - 1;
            int lastItemIndex = mItemList[mItemList.Count - 1].ItemIndex;
            if (lastItemIndex <= maxItemIndex)
            {
                UpdateContentSize();
                UpdateAllShownItemsPos();
                return;
            }
            MovePanelToItemIndex(maxItemIndex, 0);

        }

        //To get the visible item by itemIndex. If the item is not visible, then this method return null.
        public LoopListViewItem2 GetShownItemByItemIndex(int itemIndex)
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return null;
            }
            if (itemIndex < mItemList[0].ItemIndex || itemIndex > mItemList[count - 1].ItemIndex)
            {
                return null;
            }
            int i = itemIndex - mItemList[0].ItemIndex;
            return mItemList[i];
        }


        public LoopListViewItem2 GetShownItemNearestItemIndex(int itemIndex)
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return null;
            }
            if (itemIndex < mItemList[0].ItemIndex )
            {
                return mItemList[0];
            }
            if (itemIndex > mItemList[count - 1].ItemIndex)
            {
                return mItemList[count - 1];
            }
            int i = itemIndex - mItemList[0].ItemIndex;
            return mItemList[i];
        }

        public int ShownItemCount
        {
            get
            {
                return mItemList.Count;
            }
        }

        public float ViewPortSize
        {
            get
            {
                if (mIsVertList)
                {
                    return mViewPortRectTransform.rect.height;
                }
                else
                {
                    return mViewPortRectTransform.rect.width;
                }
            }
        }

        public float ViewPortWidth
        {
            get { return mViewPortRectTransform.rect.width; }
        }
        public float ViewPortHeight
        {
            get { return mViewPortRectTransform.rect.height; }
        }


        /*
         All visible items is stored in a List<LoopListViewItem2> , which is named mItemList;
         this method is to get the visible item by the index in visible items list. The parameter index is from 0 to mItemList.Count.
        */
        public LoopListViewItem2 GetShownItemByIndex(int index)
        {
            int count = mItemList.Count;
            if(index < 0 || index >= count)
            {
                return null;
            }
            return mItemList[index];
        }

        public LoopListViewItem2 GetShownItemByIndexWithoutCheck(int index)
        {
            return mItemList[index];
        }

        public int GetIndexInShownItemList(LoopListViewItem2 item)
        {
            if(item == null)
            {
                return -1;
            }
            int count = mItemList.Count;
            if (count == 0)
            {
                return -1;
            }
            for (int i = 0; i < count; ++i)
            {
                if (mItemList[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }


        public void DoActionForEachShownItem(System.Action<LoopListViewItem2,object> action,object param)
        {
            if(action == null)
            {
                return;
            }
            int count = mItemList.Count;
            if(count == 0)
            {
                return;
            }
            for (int i = 0; i < count; ++i)
            {
                action(mItemList[i],param);
            }
        }


        public LoopListViewItem2 NewListViewItem(string itemPrefabName)
        {
            ItemPool pool = null;
            if (mItemPoolDict.TryGetValue(itemPrefabName, out pool) == false)
            {
                return null;
            }
            LoopListViewItem2 item = pool.GetItem();
            RectTransform rf = item.GetComponent<RectTransform>();
            rf.SetParent(mContainerTrans);
            rf.localScale = Vector3.one;
            rf.anchoredPosition3D = Vector3.zero;
            rf.localEulerAngles = Vector3.zero;
            item.ParentListView = this;
            return item;
        }

        /*
        For a vertical scrollrect, when a visible item’s height changed at runtime, then this method should be called to let the LoopListView2 component reposition all visible items’ position.
        For a horizontal scrollrect, when a visible item’s width changed at runtime, then this method should be called to let the LoopListView2 component reposition all visible items’ position.
        */
        public void OnItemSizeChanged(int itemIndex)
        {
            LoopListViewItem2 item = GetShownItemByItemIndex(itemIndex);
            if (item == null)
            {
                return;
            }
            if (mSupportScrollBar)
            {
                if (mIsVertList)
                {
                    SetItemSize(itemIndex, item.CachedRectTransform.rect.height, item.Padding);
                }
                else
                {
                    SetItemSize(itemIndex, item.CachedRectTransform.rect.width, item.Padding);
                }
            }
            UpdateContentSize();
            UpdateAllShownItemsPos();
        }


        /*
        To update a item by itemIndex.if the itemIndex-th item is not visible, then this method will do nothing.
        Otherwise this method will first call onGetItemByIndex(itemIndex) to get a updated item and then reposition all visible items'position. 
        */
        public void RefreshItemByItemIndex(int itemIndex)
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            if (itemIndex < mItemList[0].ItemIndex || itemIndex > mItemList[count - 1].ItemIndex)
            {
                return;
            }
            int firstItemIndex = mItemList[0].ItemIndex;
            int i = itemIndex - firstItemIndex;
            LoopListViewItem2 curItem = mItemList[i];
            Vector3 pos = curItem.CachedRectTransform.anchoredPosition3D;
            RecycleItemTmp(curItem);
            LoopListViewItem2 newItem = GetNewItemByIndex(itemIndex);
            if (newItem == null)
            {
                RefreshAllShownItemWithFirstIndex(firstItemIndex);
                return;
            }
            mItemList[i] = newItem;
            if(mIsVertList)
            {
                pos.x = newItem.StartPosOffset;
            }
            else
            {
                pos.y = newItem.StartPosOffset;
            }
            newItem.CachedRectTransform.anchoredPosition3D = pos;
            OnItemSizeChanged(itemIndex);
            ClearAllTmpRecycledItem();
        }

        //snap move will finish at once.
        public void FinishSnapImmediately()
        {
            UpdateSnapMove(true);
        }

        /*
        This method will move the scrollrect content’s position to ( the positon of itemIndex-th item + offset ),
        and offset is from 0 to scrollrect viewport size. 
        */
        public void MovePanelToItemIndex(int itemIndex, float offset)
        {
            mScrollRect.StopMovement();
            mCurSnapData.Clear();
            if (mItemTotalCount == 0)
            {
                return;
            }
            if(itemIndex < 0 && mItemTotalCount > 0)
            {
                return;
            }
            if (mItemTotalCount > 0 && itemIndex >= mItemTotalCount)
            {
                itemIndex = mItemTotalCount - 1;
            }
            if (offset < 0)
            {
                offset = 0;
            }
            Vector3 pos = Vector3.zero;
            float viewPortSize = ViewPortSize;
            if (offset > viewPortSize)
            {
                offset = viewPortSize;
            }
            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                float containerPos = mContainerTrans.anchoredPosition3D.y;
                if (containerPos < 0)
                {
                    containerPos = 0;
                }
                pos.y = -containerPos - offset;
            }
            else if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                float containerPos = mContainerTrans.anchoredPosition3D.y;
                if (containerPos > 0)
                {
                    containerPos = 0;
                }
                pos.y = -containerPos + offset;
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                float containerPos = mContainerTrans.anchoredPosition3D.x;
                if (containerPos > 0)
                {
                    containerPos = 0;
                }
                pos.x = -containerPos + offset;
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                float containerPos = mContainerTrans.anchoredPosition3D.x;
                if (containerPos < 0)
                {
                    containerPos = 0;
                }
                pos.x = -containerPos - offset;
            }

            RecycleAllItem();
            LoopListViewItem2 newItem = GetNewItemByIndex(itemIndex);
            if (newItem == null)
            {
                ClearAllTmpRecycledItem();
                return;
            }
            if (mIsVertList)
            {
                pos.x = newItem.StartPosOffset;
            }
            else
            {
                pos.y = newItem.StartPosOffset;
            }
            newItem.CachedRectTransform.anchoredPosition3D = pos;
            if (mSupportScrollBar)
            {
                if (mIsVertList)
                {
                    SetItemSize(itemIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                }
                else
                {
                    SetItemSize(itemIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                }
            }
            mItemList.Add(newItem);
            UpdateContentSize();
            UpdateListView(viewPortSize + 100, viewPortSize + 100, viewPortSize, viewPortSize);
            AdjustPanelPos();
            ClearAllTmpRecycledItem();
            ForceSnapUpdateCheck();
            UpdateSnapMove(false,true);
        }

        //update all visible items.
        public void RefreshAllShownItem()
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            RefreshAllShownItemWithFirstIndex(mItemList[0].ItemIndex);
        }


        public void RefreshAllShownItemWithFirstIndex(int firstItemIndex)
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            LoopListViewItem2 firstItem = mItemList[0];
            Vector3 pos = firstItem.CachedRectTransform.anchoredPosition3D;
            RecycleAllItem();
            for (int i = 0; i < count; ++i)
            {
                int curIndex = firstItemIndex + i;
                LoopListViewItem2 newItem = GetNewItemByIndex(curIndex);
                if (newItem == null)
                {
                    break;
                }
                if (mIsVertList)
                {
                    pos.x = newItem.StartPosOffset;
                }
                else
                {
                    pos.y = newItem.StartPosOffset;
                }
                newItem.CachedRectTransform.anchoredPosition3D = pos;
                if (mSupportScrollBar)
                {
                    if (mIsVertList)
                    {
                        SetItemSize(curIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                    }
                    else
                    {
                        SetItemSize(curIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                    }
                }

                mItemList.Add(newItem);
            }
            UpdateContentSize();
            UpdateAllShownItemsPos();
            ClearAllTmpRecycledItem();
        }


        public void RefreshAllShownItemWithFirstIndexAndPos(int firstItemIndex, Vector3 pos)
        {
            RecycleAllItem();
            LoopListViewItem2 newItem = GetNewItemByIndex(firstItemIndex);
            if (newItem == null)
            {
                return;
            }
            if (mIsVertList)
            {
                pos.x = newItem.StartPosOffset;
            }
            else
            {
                pos.y = newItem.StartPosOffset;
            }
            newItem.CachedRectTransform.anchoredPosition3D = pos;
            if (mSupportScrollBar)
            {
                if (mIsVertList)
                {
                    SetItemSize(firstItemIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                }
                else
                {
                    SetItemSize(firstItemIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                }
            }
            mItemList.Add(newItem);
            UpdateContentSize();
            UpdateAllShownItemsPos();
            UpdateListView(mDistanceForRecycle0, mDistanceForRecycle1, mDistanceForNew0, mDistanceForNew1);
            ClearAllTmpRecycledItem();
        }


        void RecycleItemTmp(LoopListViewItem2 item)
        {
            if (item == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(item.ItemPrefabName))
            {
                return;
            }
            ItemPool pool = null;
            if (mItemPoolDict.TryGetValue(item.ItemPrefabName, out pool) == false)
            {
                return;
            }
            pool.RecycleItem(item);

        }


        void ClearAllTmpRecycledItem()
        {
            int count = mItemPoolList.Count;
            for(int i = 0;i<count;++i)
            {
                mItemPoolList[i].ClearTmpRecycledItem();
            }
        }


        void RecycleAllItem()
        {
            // foreach (LoopListViewItem2 item in mItemList)
            // {
            //     RecycleItemTmp(item);
            // }

            for (int i = mItemList.Count - 1; i >= 0; i--)
            {
                RecycleItemTmp(mItemList[i]);
            }
            
            mItemList.Clear();
        }


        void AdjustContainerPivot(RectTransform rtf)
        {
            Vector2 pivot = rtf.pivot;
            if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                pivot.y = 0;
            }
            else if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                pivot.y = 1;
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                pivot.x = 0;
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                pivot.x = 1;
            }
            rtf.pivot = pivot;
        }


        void AdjustPivot(RectTransform rtf)
        {
            Vector2 pivot = rtf.pivot;

            if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                pivot.y = 0;
            }
            else if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                pivot.y = 1;
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                pivot.x = 0;
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                pivot.x = 1;
            }
            rtf.pivot = pivot;
        }

        void AdjustContainerAnchor(RectTransform rtf)
        {
            Vector2 anchorMin = rtf.anchorMin;
            Vector2 anchorMax = rtf.anchorMax;
            if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                anchorMin.y = 0;
                anchorMax.y = 0;
            }
            else if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                anchorMin.y = 1;
                anchorMax.y = 1;
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                anchorMin.x = 0;
                anchorMax.x = 0;
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                anchorMin.x = 1;
                anchorMax.x = 1;
            }
            rtf.anchorMin = anchorMin;
            rtf.anchorMax = anchorMax;
        }


        void AdjustAnchor(RectTransform rtf)
        {
            Vector2 anchorMin = rtf.anchorMin;
            Vector2 anchorMax = rtf.anchorMax;
            if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                anchorMin.y = 0;
                anchorMax.y = 0;
            }
            else if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                anchorMin.y = 1;
                anchorMax.y = 1;
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                anchorMin.x = 0;
                anchorMax.x = 0;
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                anchorMin.x = 1;
                anchorMax.x = 1;
            }
            rtf.anchorMin = anchorMin;
            rtf.anchorMax = anchorMax;
        }

        void InitItemPool()
        {
            foreach (ItemPrefabConfData data in mItemPrefabDataList)
            {
                if (data.mItemPrefab == null)
                {
                    Debug.LogError("A item prefab is null ");
                    continue;
                }
                string prefabName = data.mItemPrefab.name;
                if (mItemPoolDict.ContainsKey(prefabName))
                {
                    Debug.LogError("A item prefab with name " + prefabName + " has existed!");
                    continue;
                }
                RectTransform rtf = data.mItemPrefab.GetComponent<RectTransform>();
                if (rtf == null)
                {
                    Debug.LogError("RectTransform component is not found in the prefab " + prefabName);
                    continue;
                }
                AdjustAnchor(rtf);
                AdjustPivot(rtf);
                LoopListViewItem2 tItem = data.mItemPrefab.GetComponent<LoopListViewItem2>();
                if (tItem == null)
                {
                    data.mItemPrefab.AddComponent<LoopListViewItem2>();
                }
                ItemPool pool = new ItemPool();
                pool.Init(data.mItemPrefab, data.mPadding,data.mStartPosOffset, data.mInitCreateCount, mContainerTrans);
                mItemPoolDict.Add(prefabName, pool);
                mItemPoolList.Add(pool);
            }
        }



        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }
            mIsDraging = true;
            CacheDragPointerEventData(eventData);
            mCurSnapData.Clear();
            if(mOnBeginDragAction != null)
            {
                mOnBeginDragAction();
            }
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }
            mIsDraging = false;
            mPointerEventData = null;
            if (mOnEndDragAction != null)
            {
                mOnEndDragAction();
            }
            ForceSnapUpdateCheck();
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }
            CacheDragPointerEventData(eventData);
            if (mOnDragingAction != null)
            {
                mOnDragingAction();
            }
        }

        void CacheDragPointerEventData(PointerEventData eventData)
        {
            if (mPointerEventData == null)
            {
                mPointerEventData = new PointerEventData(EventSystem.current);
            }
            mPointerEventData.button = eventData.button;
            mPointerEventData.position = eventData.position;
            mPointerEventData.pointerPressRaycast = eventData.pointerPressRaycast;
            mPointerEventData.pointerCurrentRaycast = eventData.pointerCurrentRaycast;
        }

        LoopListViewItem2 GetNewItemByIndex(int index)
        {
            if(mSupportScrollBar && index < 0)
            {
                return null;
            }
            if(mItemTotalCount > 0 && index >= mItemTotalCount)
            {
                return null;
            }
            LoopListViewItem2 newItem = mOnGetItemByIndex(this, index);
            if (newItem == null)
            {
                return null;
            }
            newItem.ItemIndex = index;
            newItem.ItemCreatedCheckFrameCount = mListUpdateCheckFrameCount;
            return newItem;
        }


        void SetItemSize(int itemIndex, float itemSize,float padding)
        {
            mItemPosMgr.SetItemSize(itemIndex, itemSize+padding);
            if(itemIndex >= mLastItemIndex)
            {
                mLastItemIndex = itemIndex;
                mLastItemPadding = padding;
            }
        }

        bool GetPlusItemIndexAndPosAtGivenPos(float pos, ref int index, ref float itemPos)
        {
            return mItemPosMgr.GetItemIndexAndPosAtGivenPos(pos, ref index, ref itemPos);
        }


        float GetItemPos(int itemIndex)
        {
            return mItemPosMgr.GetItemPos(itemIndex);
        }

      
        public Vector3 GetItemCornerPosInViewPort(LoopListViewItem2 item, ItemCornerEnum corner = ItemCornerEnum.LeftBottom)
        {
            item.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
            return mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[(int)corner]);
        }
       

        void AdjustPanelPos()
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            UpdateAllShownItemsPos();
            float viewPortSize = ViewPortSize;
            float contentSize = GetContentPanelSize();
            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                if (contentSize <= viewPortSize)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.y = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(mItemList[0].StartPosOffset,0,0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 topPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                if (topPos0.y < mViewPortRectLocalCorners[1].y)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.y = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(mItemList[0].StartPosOffset, 0, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 downPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);
                float d = downPos1.y - mViewPortRectLocalCorners[0].y;
                if (d > 0)
                {
                    Vector3 pos = mItemList[0].CachedRectTransform.anchoredPosition3D;
                    pos.y = pos.y - d;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = pos;
                    UpdateAllShownItemsPos();
                    return;
                }
            }
            else if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                if (contentSize <= viewPortSize)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.y = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(mItemList[0].StartPosOffset, 0, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 downPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);
                if (downPos0.y > mViewPortRectLocalCorners[0].y)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.y = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(mItemList[0].StartPosOffset, 0, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 topPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                float d = mViewPortRectLocalCorners[1].y - topPos1.y;
                if (d > 0)
                {
                    Vector3 pos = mItemList[0].CachedRectTransform.anchoredPosition3D;
                    pos.y = pos.y + d;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = pos;
                    UpdateAllShownItemsPos();
                    return;
                }
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                if (contentSize <= viewPortSize)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.x = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(0,mItemList[0].StartPosOffset, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 leftPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                if (leftPos0.x > mViewPortRectLocalCorners[1].x)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.x = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(0, mItemList[0].StartPosOffset, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 rightPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);
                float d = mViewPortRectLocalCorners[2].x - rightPos1.x;
                if (d > 0)
                {
                    Vector3 pos = mItemList[0].CachedRectTransform.anchoredPosition3D;
                    pos.x = pos.x + d;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = pos;
                    UpdateAllShownItemsPos();
                    return;
                }
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                if (contentSize <= viewPortSize)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.x = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(0, mItemList[0].StartPosOffset, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 rightPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);
                if (rightPos0.x < mViewPortRectLocalCorners[2].x)
                {
                    Vector3 pos = mContainerTrans.anchoredPosition3D;
                    pos.x = 0;
                    mContainerTrans.anchoredPosition3D = pos;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = new Vector3(0, mItemList[0].StartPosOffset, 0);
                    UpdateAllShownItemsPos();
                    return;
                }
                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 leftPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                float d = leftPos1.x - mViewPortRectLocalCorners[1].x;
                if (d > 0)
                {
                    Vector3 pos = mItemList[0].CachedRectTransform.anchoredPosition3D;
                    pos.x = pos.x - d;
                    mItemList[0].CachedRectTransform.anchoredPosition3D = pos;
                    UpdateAllShownItemsPos();
                    return;
                }
            }



        }


        void Update()
        {
            if(mListViewInited == false)
            {
                return;
            }
            if(mNeedAdjustVec)
            {
                mNeedAdjustVec = false;
                if(mIsVertList)
                {
                    if(mScrollRect.velocity.y * mAdjustedVec.y > 0)
                    {
                        mScrollRect.velocity = mAdjustedVec;
                    }
                }
                else
                {
                    if (mScrollRect.velocity.x * mAdjustedVec.x > 0)
                    {
                        mScrollRect.velocity = mAdjustedVec;
                    }
                }
                
            }
            if (mSupportScrollBar && mItemPosMgr!= null)
            {
                mItemPosMgr.Update(false);
            }
            UpdateSnapMove();
            UpdateListView(mDistanceForRecycle0, mDistanceForRecycle1, mDistanceForNew0, mDistanceForNew1);
            ClearAllTmpRecycledItem();
            mLastFrameContainerPos = mContainerTrans.anchoredPosition3D;
        }

        //update snap move. if immediate is set true, then the snap move will finish at once.
        void UpdateSnapMove(bool immediate = false, bool forceSendEvent = false)
        {
            if (mItemSnapEnable == false)
            {
                return;
            }
            if (mIsVertList)
            {
                UpdateSnapVertical(immediate,forceSendEvent);
            }
            else
            {
                UpdateSnapHorizontal(immediate,forceSendEvent);
            }
        }



        public void UpdateAllShownItemSnapData()
        {
            if (mItemSnapEnable == false)
            {
                return;
            }
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            Vector3 pos = mContainerTrans.anchoredPosition3D;
            LoopListViewItem2 tViewItem0 = mItemList[0];
            tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
            float start = 0;
            float end = 0;
            float itemSnapCenter = 0;
            float snapCenter = 0;
            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                snapCenter = -(1 - mViewPortSnapPivot.y) * mViewPortRectTransform.rect.height;
                Vector3 topPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                start = topPos1.y;
                end = start - tViewItem0.ItemSizeWithPadding;
                itemSnapCenter = start - tViewItem0.ItemSize * (1 - mItemSnapPivot.y);
                for (int i = 0; i < count; ++i)
                {
                    mItemList[i].DistanceWithViewPortSnapCenter = snapCenter - itemSnapCenter;
                    if ((i + 1) < count)
                    {
                        start = end;
                        end = end - mItemList[i + 1].ItemSizeWithPadding;
                        itemSnapCenter = start - mItemList[i + 1].ItemSize * (1 - mItemSnapPivot.y);
                    }
                }
            }
            else if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                snapCenter = mViewPortSnapPivot.y * mViewPortRectTransform.rect.height;
                Vector3 bottomPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);
                start = bottomPos1.y;
                end = start + tViewItem0.ItemSizeWithPadding;
                itemSnapCenter = start + tViewItem0.ItemSize * mItemSnapPivot.y;
                for (int i = 0; i < count; ++i)
                {
                    mItemList[i].DistanceWithViewPortSnapCenter = snapCenter - itemSnapCenter;
                    if ((i + 1) < count)
                    {
                        start = end;
                        end = end + mItemList[i + 1].ItemSizeWithPadding;
                        itemSnapCenter = start + mItemList[i + 1].ItemSize * mItemSnapPivot.y;
                    }
                }
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                snapCenter = -(1 - mViewPortSnapPivot.x) * mViewPortRectTransform.rect.width;
                Vector3 rightPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);
                start = rightPos1.x;
                end = start - tViewItem0.ItemSizeWithPadding;
                itemSnapCenter = start - tViewItem0.ItemSize * (1 - mItemSnapPivot.x);
                for (int i = 0; i < count; ++i)
                {
                    mItemList[i].DistanceWithViewPortSnapCenter = snapCenter - itemSnapCenter;
                    if ((i + 1) < count)
                    {
                        start = end;
                        end = end - mItemList[i + 1].ItemSizeWithPadding;
                        itemSnapCenter = start - mItemList[i + 1].ItemSize * (1 - mItemSnapPivot.x);
                    }
                }
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                snapCenter = mViewPortSnapPivot.x * mViewPortRectTransform.rect.width;
                Vector3 leftPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                start = leftPos1.x;
                end = start + tViewItem0.ItemSizeWithPadding;
                itemSnapCenter = start + tViewItem0.ItemSize * mItemSnapPivot.x;
                for (int i = 0; i < count; ++i)
                {
                    mItemList[i].DistanceWithViewPortSnapCenter = snapCenter - itemSnapCenter;
                    if ((i + 1) < count)
                    {
                        start = end;
                        end = end + mItemList[i + 1].ItemSizeWithPadding;
                        itemSnapCenter = start + mItemList[i + 1].ItemSize * mItemSnapPivot.x;
                    }
                }
            }
        }



        void UpdateSnapVertical(bool immediate = false, bool forceSendEvent = false)
        {
            if(mItemSnapEnable == false)
            {
                return;
            }
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            Vector3 pos = mContainerTrans.anchoredPosition3D;
            bool needCheck = (pos.y != mLastSnapCheckPos.y);
            mLastSnapCheckPos = pos;
            if (!needCheck)
            {
                if (mLeftSnapUpdateExtraCount > 0)
                {
                    mLeftSnapUpdateExtraCount--;
                    needCheck = true;
                }
            }
            if (needCheck)
            {
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                int curIndex = -1;
                float start = 0;
                float end = 0;
                float itemSnapCenter = 0;
                float curMinDist = float.MaxValue;
                float curDist = 0;
                float curDistAbs = 0;
                float snapCenter = 0; 
                if (mArrangeType == ListItemArrangeType.TopToBottom)
                {
                    snapCenter = -(1 - mViewPortSnapPivot.y) * mViewPortRectTransform.rect.height;
                    Vector3 topPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                    start = topPos1.y;
                    end = start - tViewItem0.ItemSizeWithPadding;
                    itemSnapCenter = start - tViewItem0.ItemSize * (1-mItemSnapPivot.y);
                    for (int i = 0; i < count; ++i)
                    {
                        curDist = snapCenter - itemSnapCenter;
                        curDistAbs = Mathf.Abs(curDist);
                        if (curDistAbs < curMinDist)
                        {
                            curMinDist = curDistAbs;
                            curIndex = i;
                        }
                        else
                        {
                            break;
                        }
                        
                        if ((i + 1) < count)
                        {
                            start = end;
                            end = end - mItemList[i + 1].ItemSizeWithPadding;
                            itemSnapCenter = start - mItemList[i + 1].ItemSize * (1 - mItemSnapPivot.y);
                        }
                    }
                }
                else if(mArrangeType == ListItemArrangeType.BottomToTop)
                {
                    snapCenter = mViewPortSnapPivot.y * mViewPortRectTransform.rect.height;
                    Vector3 bottomPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);
                    start = bottomPos1.y;
                    end = start + tViewItem0.ItemSizeWithPadding;
                    itemSnapCenter = start + tViewItem0.ItemSize * mItemSnapPivot.y;
                    for (int i = 0; i < count; ++i)
                    {
                        curDist = snapCenter - itemSnapCenter;
                        curDistAbs = Mathf.Abs(curDist);
                        if (curDistAbs < curMinDist)
                        {
                            curMinDist = curDistAbs;
                            curIndex = i;
                        }
                        else
                        {
                            break;
                        }

                        if ((i + 1) < count)
                        {
                            start = end;
                            end = end + mItemList[i + 1].ItemSizeWithPadding;
                            itemSnapCenter = start + mItemList[i + 1].ItemSize *  mItemSnapPivot.y;
                        }
                    }
                }

                if (curIndex >= 0)
                {
                    int oldNearestItemIndex = mCurSnapNearestItemIndex;
                    mCurSnapNearestItemIndex = mItemList[curIndex].ItemIndex;
                    if (forceSendEvent || mItemList[curIndex].ItemIndex != oldNearestItemIndex)
                    {
                        if (mOnSnapNearestChanged != null)
                        {
                            mOnSnapNearestChanged(this,mItemList[curIndex]);
                        }
                    }
                }
                else
                {
                    mCurSnapNearestItemIndex = -1;
                }
            }
            if (CanSnap() == false)
            {
                ClearSnapData();
                return;
            }
            float v = Mathf.Abs(mScrollRect.velocity.y);
            UpdateCurSnapData();
            if (mCurSnapData.mSnapStatus != SnapStatus.SnapMoving)
            {
                return;
            }
            if (v > 0)
            {
                mScrollRect.StopMovement();
            }
            float old = mCurSnapData.mCurSnapVal;
            if(mCurSnapData.mIsTempTarget == false)
            {
                if(mSmoothDumpVel * mCurSnapData.mTargetSnapVal < 0)
                {
                    mSmoothDumpVel = 0;
                }
                mCurSnapData.mCurSnapVal = Mathf.SmoothDamp(mCurSnapData.mCurSnapVal, mCurSnapData.mTargetSnapVal, ref mSmoothDumpVel, mSmoothDumpRate);
            }
            else
            {
                float maxAbsVec = mCurSnapData.mMoveMaxAbsVec;
                if(maxAbsVec <= 0)
                {
                    maxAbsVec = mSnapMoveDefaultMaxAbsVec;
                }
                mSmoothDumpVel = maxAbsVec * Mathf.Sign(mCurSnapData.mTargetSnapVal);
                mCurSnapData.mCurSnapVal = Mathf.MoveTowards(mCurSnapData.mCurSnapVal, mCurSnapData.mTargetSnapVal, maxAbsVec * Time.unscaledDeltaTime);
            }
            float dt = mCurSnapData.mCurSnapVal - old;
                
            if (immediate || Mathf.Abs(mCurSnapData.mTargetSnapVal - mCurSnapData.mCurSnapVal) < mSnapFinishThreshold)
            {
                pos.y = pos.y + mCurSnapData.mTargetSnapVal - old;
                mCurSnapData.mSnapStatus = SnapStatus.SnapMoveFinish;
                if (mOnSnapItemFinished != null)
                {
                    LoopListViewItem2 targetItem = GetShownItemByItemIndex(mCurSnapNearestItemIndex);
                    if(targetItem != null)
                    {
                        mOnSnapItemFinished(this,targetItem);
                    }
                }
            }
            else
            {
                pos.y = pos.y + dt;
            }

            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                float maxY = mViewPortRectLocalCorners[0].y + mContainerTrans.rect.height;
                pos.y = Mathf.Clamp(pos.y, 0, maxY);
                mContainerTrans.anchoredPosition3D = pos;
            }
            else if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                float minY = mViewPortRectLocalCorners[1].y - mContainerTrans.rect.height;
                pos.y = Mathf.Clamp(pos.y, minY, 0);
                mContainerTrans.anchoredPosition3D = pos;
            }

        }

        void UpdateCurSnapData()
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                mCurSnapData.Clear();
                return;
            }

            if (mCurSnapData.mSnapStatus == SnapStatus.SnapMoveFinish)
            {
                if (mCurSnapData.mSnapTargetIndex == mCurSnapNearestItemIndex)
                {
                    return;
                }
                mCurSnapData.mSnapStatus = SnapStatus.NoTargetSet;
            }
            if (mCurSnapData.mSnapStatus == SnapStatus.SnapMoving)
            {
                if(mCurSnapData.mIsForceSnapTo)
                {
                    if (mCurSnapData.mIsTempTarget == true)
                    {
                        LoopListViewItem2 targetItem = GetShownItemNearestItemIndex(mCurSnapData.mSnapTargetIndex);
                        if (targetItem == null)
                        {
                            mCurSnapData.Clear();
                            return;
                        }
                        if (targetItem.ItemIndex == mCurSnapData.mSnapTargetIndex)
                        {
                            UpdateAllShownItemSnapData();
                            mCurSnapData.mTargetSnapVal = targetItem.DistanceWithViewPortSnapCenter;
                            mCurSnapData.mCurSnapVal = 0;
                            mCurSnapData.mIsTempTarget = false;
                            mCurSnapData.mSnapStatus = SnapStatus.SnapMoving;
                            return;
                        }
                        if (mCurSnapData.mTempTargetIndex != targetItem.ItemIndex)
                        {
                            UpdateAllShownItemSnapData();
                            mCurSnapData.mTargetSnapVal = targetItem.DistanceWithViewPortSnapCenter;
                            mCurSnapData.mCurSnapVal = 0;
                            mCurSnapData.mSnapStatus = SnapStatus.SnapMoving;
                            mCurSnapData.mIsTempTarget = true;
                            mCurSnapData.mTempTargetIndex = targetItem.ItemIndex;
                            return;
                        }
                    }
                    return;
                }
                if ((mCurSnapData.mSnapTargetIndex == mCurSnapNearestItemIndex))
                {
                    return;
                }
                mCurSnapData.mSnapStatus = SnapStatus.NoTargetSet;
            }
            if (mCurSnapData.mSnapStatus == SnapStatus.NoTargetSet)
            {
                LoopListViewItem2 nearestItem = GetShownItemByItemIndex(mCurSnapNearestItemIndex);
                if (nearestItem == null)
                {
                    return;
                }
                mCurSnapData.mSnapTargetIndex = mCurSnapNearestItemIndex;
                mCurSnapData.mSnapStatus = SnapStatus.TargetHasSet;
                mCurSnapData.mIsForceSnapTo = false;
            }
            if (mCurSnapData.mSnapStatus == SnapStatus.TargetHasSet)
            {
                LoopListViewItem2 targetItem = GetShownItemNearestItemIndex(mCurSnapData.mSnapTargetIndex);
                if (targetItem == null)
                {
                    mCurSnapData.Clear();
                    return;
                }
                if(targetItem.ItemIndex == mCurSnapData.mSnapTargetIndex)
                {
                    UpdateAllShownItemSnapData();
                    mCurSnapData.mTargetSnapVal = targetItem.DistanceWithViewPortSnapCenter;
                    mCurSnapData.mCurSnapVal = 0;
                    mCurSnapData.mIsTempTarget = false;
                    mCurSnapData.mSnapStatus = SnapStatus.SnapMoving;
                }
                else
                {
                    UpdateAllShownItemSnapData();
                    mCurSnapData.mTargetSnapVal = targetItem.DistanceWithViewPortSnapCenter;
                    mCurSnapData.mCurSnapVal = 0;
                    mCurSnapData.mSnapStatus = SnapStatus.SnapMoving;
                    mCurSnapData.mIsTempTarget = true;
                    mCurSnapData.mTempTargetIndex = targetItem.ItemIndex;
                }
                
            }

        }
        //Clear current snap target and then the LoopScrollView2 will auto snap to the CurSnapNearestItemIndex.
        public void ClearSnapData()
        {
            mCurSnapData.Clear();
        }

        //moveMaxAbsVec param is the max abs snap move speed, if the value <= 0 then LoopListView2 would use SnapMoveDefaultMaxAbsVec
        public void SetSnapTargetItemIndex(int itemIndex,float moveMaxAbsVec = -1)
        {
            if(mItemTotalCount > 0)
            {
                if(itemIndex >= mItemTotalCount)
                {
                    itemIndex = mItemTotalCount - 1;
                }
                if(itemIndex < 0)
                {
                    itemIndex = 0;
                }
            }
            mScrollRect.StopMovement();
            mCurSnapData.mSnapTargetIndex = itemIndex;
            mCurSnapData.mSnapStatus = SnapStatus.TargetHasSet;
            mCurSnapData.mIsForceSnapTo = true;
            mCurSnapData.mMoveMaxAbsVec = moveMaxAbsVec;
        }

        //Get the nearest item index with the viewport snap point.
        public int CurSnapNearestItemIndex
        {
            get{ return mCurSnapNearestItemIndex; }
        }

        public void ForceSnapUpdateCheck()
        {
            if(mLeftSnapUpdateExtraCount <= 0)
            {
                mLeftSnapUpdateExtraCount = 1;
            }
        }

        void UpdateSnapHorizontal(bool immediate = false, bool forceSendEvent = false)
        {
            if (mItemSnapEnable == false)
            {
                return;
            }
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            Vector3 pos = mContainerTrans.anchoredPosition3D;
            bool needCheck = (pos.x != mLastSnapCheckPos.x);
            mLastSnapCheckPos = pos;
            if (!needCheck)
            {
                if(mLeftSnapUpdateExtraCount > 0)
                {
                    mLeftSnapUpdateExtraCount--;
                    needCheck = true;
                }
            }
            if (needCheck)
            {
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                int curIndex = -1;
                float start = 0;
                float end = 0;
                float itemSnapCenter = 0;
                float curMinDist = float.MaxValue;
                float curDist = 0;
                float curDistAbs = 0;
                float snapCenter = 0;
                if (mArrangeType == ListItemArrangeType.RightToLeft)
                {
                    snapCenter = -(1 - mViewPortSnapPivot.x) * mViewPortRectTransform.rect.width;
                    Vector3 rightPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);
                    start = rightPos1.x;
                    end = start - tViewItem0.ItemSizeWithPadding;
                    itemSnapCenter = start - tViewItem0.ItemSize * (1 - mItemSnapPivot.x);
                    for (int i = 0; i < count; ++i)
                    {
                        curDist = snapCenter - itemSnapCenter;
                        curDistAbs = Mathf.Abs(curDist);
                        if (curDistAbs < curMinDist)
                        {
                            curMinDist = curDistAbs;
                            curIndex = i;
                        }
                        else
                        {
                            break;
                        }

                        if ((i + 1) < count)
                        {
                            start = end;
                            end = end - mItemList[i + 1].ItemSizeWithPadding;
                            itemSnapCenter = start - mItemList[i + 1].ItemSize * (1 - mItemSnapPivot.x);
                        }
                    }
                }
                else if (mArrangeType == ListItemArrangeType.LeftToRight)
                {
                    snapCenter = mViewPortSnapPivot.x * mViewPortRectTransform.rect.width;
                    Vector3 leftPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                    start = leftPos1.x;
                    end = start + tViewItem0.ItemSizeWithPadding;
                    itemSnapCenter = start + tViewItem0.ItemSize * mItemSnapPivot.x;
                    for (int i = 0; i < count; ++i)
                    {
                        curDist = snapCenter - itemSnapCenter;
                        curDistAbs = Mathf.Abs(curDist);
                        if (curDistAbs < curMinDist)
                        {
                            curMinDist = curDistAbs;
                            curIndex = i;
                        }
                        else
                        {
                            break;
                        }

                        if ((i + 1) < count)
                        {
                            start = end;
                            end = end + mItemList[i + 1].ItemSizeWithPadding;
                            itemSnapCenter = start + mItemList[i + 1].ItemSize * mItemSnapPivot.x;
                        }
                    }
                }


                if (curIndex >= 0)
                {
                    int oldNearestItemIndex = mCurSnapNearestItemIndex;
                    mCurSnapNearestItemIndex = mItemList[curIndex].ItemIndex;
                    if (forceSendEvent || mItemList[curIndex].ItemIndex != oldNearestItemIndex)
                    {
                        if (mOnSnapNearestChanged != null)
                        {
                            mOnSnapNearestChanged(this, mItemList[curIndex]);
                        }
                    }
                }
                else
                {
                    mCurSnapNearestItemIndex = -1;
                }
            }
            if (CanSnap() == false)
            {
                ClearSnapData();
                return;
            }
            float v = Mathf.Abs(mScrollRect.velocity.x);
            UpdateCurSnapData();
            if(mCurSnapData.mSnapStatus != SnapStatus.SnapMoving)
            {
                return;
            }
            if (v > 0)
            {
                mScrollRect.StopMovement();
            }
            float old = mCurSnapData.mCurSnapVal;
            if (mCurSnapData.mIsTempTarget == false)
            {
                if (mSmoothDumpVel * mCurSnapData.mTargetSnapVal < 0)
                {
                    mSmoothDumpVel = 0;
                }
                mCurSnapData.mCurSnapVal = Mathf.SmoothDamp(mCurSnapData.mCurSnapVal, mCurSnapData.mTargetSnapVal, ref mSmoothDumpVel, mSmoothDumpRate);
            }
            else
            {
                float maxAbsVec = mCurSnapData.mMoveMaxAbsVec;
                if (maxAbsVec <= 0)
                {
                    maxAbsVec = mSnapMoveDefaultMaxAbsVec;
                }
                mSmoothDumpVel = maxAbsVec * Mathf.Sign(mCurSnapData.mTargetSnapVal);
                mCurSnapData.mCurSnapVal = Mathf.MoveTowards(mCurSnapData.mCurSnapVal, mCurSnapData.mTargetSnapVal, maxAbsVec * Time.unscaledDeltaTime);
            }
            float dt = mCurSnapData.mCurSnapVal - old;

            if (immediate || Mathf.Abs(mCurSnapData.mTargetSnapVal - mCurSnapData.mCurSnapVal) < mSnapFinishThreshold)
            {
                pos.x = pos.x + mCurSnapData.mTargetSnapVal - old;
                mCurSnapData.mSnapStatus = SnapStatus.SnapMoveFinish;
                if (mOnSnapItemFinished != null)
                {
                    LoopListViewItem2 targetItem = GetShownItemByItemIndex(mCurSnapNearestItemIndex);
                    if (targetItem != null)
                    {
                        mOnSnapItemFinished(this, targetItem);
                    }
                }
            }
            else
            {
                pos.x = pos.x + dt;
            }
                
            if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                float minX = mViewPortRectLocalCorners[2].x - mContainerTrans.rect.width;
                pos.x = Mathf.Clamp(pos.x, minX, 0);
                mContainerTrans.anchoredPosition3D = pos;
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                float maxX = mViewPortRectLocalCorners[1].x + mContainerTrans.rect.width;
                pos.x = Mathf.Clamp(pos.x, 0, maxX);
                mContainerTrans.anchoredPosition3D = pos;
            }
        }

        bool CanSnap()
        {
            if (mIsDraging)
            {
                return false;
            }
            if (mScrollBarClickEventListener != null)
            {
                if (mScrollBarClickEventListener.IsPressd)
                {
                    return false;
                }
            }

            if (mIsVertList)
            {
                if(mContainerTrans.rect.height <= ViewPortHeight)
                {
                    return false;
                }
            }
            else
            {
                if (mContainerTrans.rect.width <= ViewPortWidth)
                {
                    return false;
                }
            }

            float v = 0;
            if (mIsVertList)
            {
                v = Mathf.Abs(mScrollRect.velocity.y);
            }
            else
            {
                v = Mathf.Abs(mScrollRect.velocity.x);
            }
            if (v > mSnapVecThreshold)
            {
                return false;
            }
            float diff = 3;
            Vector3 pos = mContainerTrans.anchoredPosition3D;
            if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                float minX = mViewPortRectLocalCorners[2].x - mContainerTrans.rect.width;
                if (pos.x < (minX - diff) || pos.x > diff)
                {
                    return false;
                }
            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                float maxX = mViewPortRectLocalCorners[1].x + mContainerTrans.rect.width;
                if (pos.x > (maxX + diff) || pos.x < -diff)
                {
                    return false;
                }
            }
            else if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                float maxY = mViewPortRectLocalCorners[0].y + mContainerTrans.rect.height;
                if (pos.y > (maxY + diff) || pos.y < -diff)
                {
                    return false;
                }
            }
            else if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                float minY = mViewPortRectLocalCorners[1].y - mContainerTrans.rect.height;
                if (pos.y < (minY - diff) || pos.y > diff)
                {
                    return false;
                }
            }
            return true;
        }



        public void UpdateListView(float distanceForRecycle0, float distanceForRecycle1, float distanceForNew0, float distanceForNew1)
        {
            mListUpdateCheckFrameCount++;
            if (mIsVertList)
            {
                bool needContinueCheck = true;
                int checkCount = 0;
                int maxCount = 9999;
                while (needContinueCheck)
                {
                    checkCount++;
                    if(checkCount >= maxCount)
                    {
                        Debug.LogError("UpdateListView Vertical while loop " + checkCount + " times! something is wrong!");
                        break;
                    }
                    needContinueCheck = UpdateForVertList(distanceForRecycle0, distanceForRecycle1, distanceForNew0, distanceForNew1);
                }
            }
            else
            {
                bool needContinueCheck = true;
                int checkCount = 0;
                int maxCount = 9999;
                while (needContinueCheck)
                {
                    checkCount++;
                    if (checkCount >= maxCount)
                    {
                        Debug.LogError("UpdateListView  Horizontal while loop " + checkCount + " times! something is wrong!");
                        break;
                    }
                    needContinueCheck = UpdateForHorizontalList(distanceForRecycle0, distanceForRecycle1, distanceForNew0, distanceForNew1);
                }
            }

        }



        bool UpdateForVertList(float distanceForRecycle0,float distanceForRecycle1,float distanceForNew0, float distanceForNew1)
        {
            if (mItemTotalCount == 0)
            {
                if(mItemList.Count > 0)
                {
                    RecycleAllItem();
                }
                return false;
            }
            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                int itemListCount = mItemList.Count;
                if (itemListCount == 0)
                {
                    float curY = mContainerTrans.anchoredPosition3D.y;
                    if (curY < 0)
                    {
                        curY = 0;
                    }
                    int index = 0;
                    float pos = -curY;
                    if (mSupportScrollBar)
                    {
                        if( GetPlusItemIndexAndPosAtGivenPos(curY, ref index, ref pos) == false)
                        {
                            return false;
                        }
                        pos = -pos;
                    }
                    LoopListViewItem2 newItem = GetNewItemByIndex(index);
                    if (newItem == null)
                    {
                        return false;
                    }
                    if (mSupportScrollBar)
                    {
                        SetItemSize(index, newItem.CachedRectTransform.rect.height, newItem.Padding);
                    }
                    mItemList.Add(newItem);
                    newItem.CachedRectTransform.anchoredPosition3D = new Vector3(newItem.StartPosOffset, pos, 0);
                    UpdateContentSize();
                    return true;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 topPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 downPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);

                if (!mIsDraging && tViewItem0.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && downPos0.y - mViewPortRectLocalCorners[1].y > distanceForRecycle0)
                {
                    mItemList.RemoveAt(0);
                    RecycleItemTmp(tViewItem0);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }

                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 topPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 downPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);
                if (!mIsDraging && tViewItem1.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && mViewPortRectLocalCorners[0].y - topPos1.y > distanceForRecycle1)
                {
                    mItemList.RemoveAt(mItemList.Count - 1);
                    RecycleItemTmp(tViewItem1);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }



                if (mViewPortRectLocalCorners[0].y - downPos1.y < distanceForNew1)
                {
                    if(tViewItem1.ItemIndex > mCurReadyMaxItemIndex)
                    {
                        mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                        mNeedCheckNextMaxItem = true;
                    }
                    int nIndex = tViewItem1.ItemIndex + 1;
                    if (nIndex <= mCurReadyMaxItemIndex || mNeedCheckNextMaxItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                            mNeedCheckNextMaxItem = false;
                            CheckIfNeedUpdataItemPos();
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                            }
                            mItemList.Add(newItem);
                            float y = tViewItem1.CachedRectTransform.anchoredPosition3D.y - tViewItem1.CachedRectTransform.rect.height - tViewItem1.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(newItem.StartPosOffset, y, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();

                            if (nIndex > mCurReadyMaxItemIndex)
                            {
                                mCurReadyMaxItemIndex = nIndex;
                            }
                            return true;
                        }
                        
                    }

                }

                if (topPos0.y - mViewPortRectLocalCorners[1].y < distanceForNew0)
                {
                    if(tViewItem0.ItemIndex < mCurReadyMinItemIndex)
                    {
                        mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                        mNeedCheckNextMinItem = true;
                    }
                    int nIndex = tViewItem0.ItemIndex - 1;
                    if (nIndex >= mCurReadyMinItemIndex || mNeedCheckNextMinItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                            mNeedCheckNextMinItem = false;
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                            }
                            mItemList.Insert(0, newItem);
                            float y = tViewItem0.CachedRectTransform.anchoredPosition3D.y + newItem.CachedRectTransform.rect.height + newItem.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(newItem.StartPosOffset, y, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();
                            if (nIndex < mCurReadyMinItemIndex)
                            {
                                mCurReadyMinItemIndex = nIndex;
                            }
                            return true;
                        }
                        
                    }

                }

            }
            else
            {
                
                if (mItemList.Count == 0)
                {
                    float curY = mContainerTrans.anchoredPosition3D.y;
                    if (curY > 0)
                    {
                        curY = 0;
                    }
                    int index = 0;
                    float pos = -curY;
                    if (mSupportScrollBar)
                    {
                        if(GetPlusItemIndexAndPosAtGivenPos(-curY, ref index, ref pos) == false)
                        {
                            return false;
                        }
                    }
                    LoopListViewItem2 newItem = GetNewItemByIndex(index);
                    if (newItem == null)
                    {
                        return false;
                    }
                    if (mSupportScrollBar)
                    {
                        SetItemSize(index, newItem.CachedRectTransform.rect.height, newItem.Padding);
                    }
                    mItemList.Add(newItem);
                    newItem.CachedRectTransform.anchoredPosition3D = new Vector3(newItem.StartPosOffset, pos, 0);
                    UpdateContentSize();
                    return true;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 topPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 downPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);

                if (!mIsDraging && tViewItem0.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && mViewPortRectLocalCorners[0].y - topPos0.y > distanceForRecycle0)
                {
                    mItemList.RemoveAt(0);
                    RecycleItemTmp(tViewItem0);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }

                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 topPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 downPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[0]);
                if (!mIsDraging && tViewItem1.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                     && downPos1.y - mViewPortRectLocalCorners[1].y > distanceForRecycle1)
                {
                    mItemList.RemoveAt(mItemList.Count - 1);
                    RecycleItemTmp(tViewItem1);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }

                if (topPos1.y - mViewPortRectLocalCorners[1].y < distanceForNew1)
                {
                    if (tViewItem1.ItemIndex > mCurReadyMaxItemIndex)
                    {
                        mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                        mNeedCheckNextMaxItem = true;
                    }
                    int nIndex = tViewItem1.ItemIndex + 1;
                    if (nIndex <= mCurReadyMaxItemIndex || mNeedCheckNextMaxItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mNeedCheckNextMaxItem = false;
                            CheckIfNeedUpdataItemPos();
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                            }
                            mItemList.Add(newItem);
                            float y = tViewItem1.CachedRectTransform.anchoredPosition3D.y + tViewItem1.CachedRectTransform.rect.height + tViewItem1.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(newItem.StartPosOffset, y, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();
                            if (nIndex > mCurReadyMaxItemIndex)
                            {
                                mCurReadyMaxItemIndex = nIndex;
                            }
                            return true;
                        }
                        
                    }

                }


                if (mViewPortRectLocalCorners[0].y - downPos0.y < distanceForNew0)
                {
                    if (tViewItem0.ItemIndex < mCurReadyMinItemIndex)
                    {
                        mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                        mNeedCheckNextMinItem = true;
                    }
                    int nIndex = tViewItem0.ItemIndex - 1;
                    if (nIndex >= mCurReadyMinItemIndex || mNeedCheckNextMinItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mNeedCheckNextMinItem = false;
                            return false;
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.height, newItem.Padding);
                            }
                            mItemList.Insert(0, newItem);
                            float y = tViewItem0.CachedRectTransform.anchoredPosition3D.y - newItem.CachedRectTransform.rect.height - newItem.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(newItem.StartPosOffset, y, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();
                            if (nIndex < mCurReadyMinItemIndex)
                            {
                                mCurReadyMinItemIndex = nIndex;
                            }
                            return true;
                        }
                        
                    }
                }


            }

            return false;

        }





        bool UpdateForHorizontalList(float distanceForRecycle0, float distanceForRecycle1, float distanceForNew0, float distanceForNew1)
        {
            if (mItemTotalCount == 0)
            {
                if (mItemList.Count > 0)
                {
                    RecycleAllItem();
                }
                return false;
            }
            if (mArrangeType == ListItemArrangeType.LeftToRight)
            {

                if (mItemList.Count == 0)
                {
                    float curX = mContainerTrans.anchoredPosition3D.x;
                    if (curX > 0)
                    {
                        curX = 0;
                    }
                    int index = 0;
                    float pos = -curX;
                    if (mSupportScrollBar)
                    {
                        if(GetPlusItemIndexAndPosAtGivenPos(-curX, ref index, ref pos) == false)
                        {
                            return false;
                        }
                    }
                    LoopListViewItem2 newItem = GetNewItemByIndex(index);
                    if (newItem == null)
                    {
                        return false;
                    }
                    if (mSupportScrollBar)
                    {
                        SetItemSize(index, newItem.CachedRectTransform.rect.width, newItem.Padding);
                    }
                    mItemList.Add(newItem);
                    newItem.CachedRectTransform.anchoredPosition3D = new Vector3(pos, newItem.StartPosOffset, 0);
                    UpdateContentSize();
                    return true;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 leftPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 rightPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);

                if (!mIsDraging && tViewItem0.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && mViewPortRectLocalCorners[1].x - rightPos0.x > distanceForRecycle0)
                {
                    mItemList.RemoveAt(0);
                    RecycleItemTmp(tViewItem0);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }

                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 leftPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 rightPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);
                if (!mIsDraging && tViewItem1.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && leftPos1.x - mViewPortRectLocalCorners[2].x> distanceForRecycle1)
                {
                    mItemList.RemoveAt(mItemList.Count - 1);
                    RecycleItemTmp(tViewItem1);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }



                if (rightPos1.x - mViewPortRectLocalCorners[2].x < distanceForNew1)
                {
                    if (tViewItem1.ItemIndex > mCurReadyMaxItemIndex)
                    {
                        mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                        mNeedCheckNextMaxItem = true;
                    }
                    int nIndex = tViewItem1.ItemIndex + 1;
                    if (nIndex <= mCurReadyMaxItemIndex || mNeedCheckNextMaxItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                            mNeedCheckNextMaxItem = false;
                            CheckIfNeedUpdataItemPos();
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                            }
                            mItemList.Add(newItem);
                            float x = tViewItem1.CachedRectTransform.anchoredPosition3D.x + tViewItem1.CachedRectTransform.rect.width + tViewItem1.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(x, newItem.StartPosOffset, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();

                            if (nIndex > mCurReadyMaxItemIndex)
                            {
                                mCurReadyMaxItemIndex = nIndex;
                            }
                            return true;
                        }

                    }

                }

                if ( mViewPortRectLocalCorners[1].x - leftPos0.x < distanceForNew0)
                {
                    if (tViewItem0.ItemIndex < mCurReadyMinItemIndex)
                    {
                        mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                        mNeedCheckNextMinItem = true;
                    }
                    int nIndex = tViewItem0.ItemIndex - 1;
                    if (nIndex >= mCurReadyMinItemIndex || mNeedCheckNextMinItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                            mNeedCheckNextMinItem = false;
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                            }
                            mItemList.Insert(0, newItem);
                            float x = tViewItem0.CachedRectTransform.anchoredPosition3D.x - newItem.CachedRectTransform.rect.width - newItem.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(x, newItem.StartPosOffset, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();
                            if (nIndex < mCurReadyMinItemIndex)
                            {
                                mCurReadyMinItemIndex = nIndex;
                            }
                            return true;
                        }

                    }

                }

            }
            else
            {

                if (mItemList.Count == 0)
                {
                    float curX = mContainerTrans.anchoredPosition3D.x;
                    if (curX < 0)
                    {
                        curX = 0;
                    }
                    int index = 0;
                    float pos = -curX;
                    if (mSupportScrollBar)
                    {
                        if(GetPlusItemIndexAndPosAtGivenPos(curX, ref index, ref pos) == false)
                        {
                            return false;
                        }
                        pos = -pos;
                    }
                    LoopListViewItem2 newItem = GetNewItemByIndex(index);
                    if (newItem == null)
                    {
                        return false;
                    }
                    if (mSupportScrollBar)
                    {
                        SetItemSize(index, newItem.CachedRectTransform.rect.width, newItem.Padding);
                    }
                    mItemList.Add(newItem);
                    newItem.CachedRectTransform.anchoredPosition3D = new Vector3(pos, newItem.StartPosOffset, 0);
                    UpdateContentSize();
                    return true;
                }
                LoopListViewItem2 tViewItem0 = mItemList[0];
                tViewItem0.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 leftPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 rightPos0 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);

                if (!mIsDraging && tViewItem0.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && leftPos0.x > distanceForRecycle0)
                {
                    mItemList.RemoveAt(0);
                    RecycleItemTmp(tViewItem0);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }

                LoopListViewItem2 tViewItem1 = mItemList[mItemList.Count - 1];
                tViewItem1.CachedRectTransform.GetWorldCorners(mItemWorldCorners);
                Vector3 leftPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[1]);
                Vector3 rightPos1 = mViewPortRectTransform.InverseTransformPoint(mItemWorldCorners[2]);
                if (!mIsDraging && tViewItem1.ItemCreatedCheckFrameCount != mListUpdateCheckFrameCount
                    && mViewPortRectLocalCorners[1].x - (rightPos1.x  + ViewPortWidth) > distanceForRecycle1)
                {
                    mItemList.RemoveAt(mItemList.Count - 1);
                    RecycleItemTmp(tViewItem1);
                    if (!mSupportScrollBar)
                    {
                        UpdateContentSize();
                        CheckIfNeedUpdataItemPos();
                    }
                    return true;
                }



                if (mViewPortRectLocalCorners[1].x - (leftPos1.x + ViewPortWidth)  < distanceForNew1)
                {
                    if (tViewItem1.ItemIndex > mCurReadyMaxItemIndex)
                    {
                        mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                        mNeedCheckNextMaxItem = true;
                    }
                    int nIndex = tViewItem1.ItemIndex + 1;
                    if (nIndex <= mCurReadyMaxItemIndex || mNeedCheckNextMaxItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mCurReadyMaxItemIndex = tViewItem1.ItemIndex;
                            mNeedCheckNextMaxItem = false;
                            CheckIfNeedUpdataItemPos();
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                            }
                            mItemList.Add(newItem);
                            float x = tViewItem1.CachedRectTransform.anchoredPosition3D.x - tViewItem1.CachedRectTransform.rect.width - tViewItem1.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(x, newItem.StartPosOffset, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();

                            if (nIndex > mCurReadyMaxItemIndex)
                            {
                                mCurReadyMaxItemIndex = nIndex;
                            }
                            return true;
                        }

                    }

                }

                if (rightPos0.x + ViewPortWidth  - mViewPortRectLocalCorners[2].x < distanceForNew0)
                {
                    if (tViewItem0.ItemIndex < mCurReadyMinItemIndex)
                    {
                        mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                        mNeedCheckNextMinItem = true;
                    }
                    int nIndex = tViewItem0.ItemIndex - 1;
                    if (nIndex >= mCurReadyMinItemIndex || mNeedCheckNextMinItem)
                    {
                        LoopListViewItem2 newItem = GetNewItemByIndex(nIndex);
                        if (newItem == null)
                        {
                            mCurReadyMinItemIndex = tViewItem0.ItemIndex;
                            mNeedCheckNextMinItem = false;
                        }
                        else
                        {
                            if (mSupportScrollBar)
                            {
                                SetItemSize(nIndex, newItem.CachedRectTransform.rect.width, newItem.Padding);
                            }
                            mItemList.Insert(0, newItem);
                            float x = tViewItem0.CachedRectTransform.anchoredPosition3D.x + newItem.CachedRectTransform.rect.width + newItem.Padding;
                            newItem.CachedRectTransform.anchoredPosition3D = new Vector3(x, newItem.StartPosOffset, 0);
                            UpdateContentSize();
                            CheckIfNeedUpdataItemPos();
                            if (nIndex < mCurReadyMinItemIndex)
                            {
                                mCurReadyMinItemIndex = nIndex;
                            }
                            return true;
                        }

                    }

                }

            }

            return false;

        }






        float GetContentPanelSize()
        {
            if (mSupportScrollBar)
            {
                float tTotalSize = mItemPosMgr.mTotalSize > 0 ? (mItemPosMgr.mTotalSize - mLastItemPadding) : 0;
                if(tTotalSize < 0)
                {
                    tTotalSize = 0;
                }
                return tTotalSize;
            }
            int count = mItemList.Count;
            if (count == 0)
            {
                return 0;
            }
            if (count == 1)
            {
                return mItemList[0].ItemSize;
            }
            if (count == 2)
            {
                return mItemList[0].ItemSizeWithPadding + mItemList[1].ItemSize;
            }
            float s = 0;
            for (int i = 0; i < count - 1; ++i)
            {
                s += mItemList[i].ItemSizeWithPadding;
            }
            s += mItemList[count - 1].ItemSize;
            return s;
        }


        void CheckIfNeedUpdataItemPos()
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }
            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                LoopListViewItem2 firstItem = mItemList[0];
                LoopListViewItem2 lastItem = mItemList[mItemList.Count - 1];
                float viewMaxY = GetContentPanelSize();
                if (firstItem.TopY > 0 || (firstItem.ItemIndex == mCurReadyMinItemIndex && firstItem.TopY != 0))
                {
                    UpdateAllShownItemsPos();
                    return;
                }
                if ((-lastItem.BottomY) > viewMaxY || (lastItem.ItemIndex == mCurReadyMaxItemIndex && (-lastItem.BottomY) != viewMaxY))
                {
                    UpdateAllShownItemsPos();
                    return;
                }

            }
            else if (mArrangeType == ListItemArrangeType.BottomToTop)
            {
                LoopListViewItem2 firstItem = mItemList[0];
                LoopListViewItem2 lastItem = mItemList[mItemList.Count - 1];
                float viewMaxY = GetContentPanelSize();
                if (firstItem.BottomY < 0 || (firstItem.ItemIndex == mCurReadyMinItemIndex && firstItem.BottomY != 0))
                {
                    UpdateAllShownItemsPos();
                    return;
                }
                if (lastItem.TopY > viewMaxY || (lastItem.ItemIndex == mCurReadyMaxItemIndex && lastItem.TopY != viewMaxY))
                {
                    UpdateAllShownItemsPos();
                    return;
                }
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                LoopListViewItem2 firstItem = mItemList[0];
                LoopListViewItem2 lastItem = mItemList[mItemList.Count - 1];
                float viewMaxX = GetContentPanelSize();
                if (firstItem.LeftX < 0 || (firstItem.ItemIndex == mCurReadyMinItemIndex && firstItem.LeftX != 0))
                {
                    UpdateAllShownItemsPos();
                    return;
                }
                if ((lastItem.RightX) > viewMaxX || (lastItem.ItemIndex == mCurReadyMaxItemIndex && lastItem.RightX != viewMaxX))
                {
                    UpdateAllShownItemsPos();
                    return;
                }

            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                LoopListViewItem2 firstItem = mItemList[0];
                LoopListViewItem2 lastItem = mItemList[mItemList.Count - 1];
                float viewMaxX = GetContentPanelSize();
                if (firstItem.RightX > 0 || (firstItem.ItemIndex == mCurReadyMinItemIndex && firstItem.RightX != 0))
                {
                    UpdateAllShownItemsPos();
                    return;
                }
                if ((-lastItem.LeftX) > viewMaxX || (lastItem.ItemIndex == mCurReadyMaxItemIndex && (-lastItem.LeftX) != viewMaxX))
                {
                    UpdateAllShownItemsPos();
                    return;
                }

            }

        }


        void UpdateAllShownItemsPos()
        {
            int count = mItemList.Count;
            if (count == 0)
            {
                return;
            }

            mAdjustedVec = (mContainerTrans.anchoredPosition3D - mLastFrameContainerPos) / Time.unscaledDeltaTime;

            if (mArrangeType == ListItemArrangeType.TopToBottom)
            {
                float pos = 0;
                if (mSupportScrollBar)
                {
                    pos = -GetItemPos(mItemList[0].ItemIndex);
                }
                float pos1 = mItemList[0].CachedRectTransform.anchoredPosition3D.y;
                float d = pos - pos1;
                float curY = pos;
                for (int i = 0; i < count; ++i)
                {
                    LoopListViewItem2 item = mItemList[i];
                    item.CachedRectTransform.anchoredPosition3D = new Vector3(item.StartPosOffset, curY, 0);
                    curY = curY - item.CachedRectTransform.rect.height - item.Padding;
                }
                if(d != 0)
                {
                    Vector2 p = mContainerTrans.anchoredPosition3D;
                    p.y = p.y - d;
                    mContainerTrans.anchoredPosition3D = p;
                }
                
            }
            else if(mArrangeType == ListItemArrangeType.BottomToTop)
            {
                float pos = 0;
                if (mSupportScrollBar)
                {
                    pos = GetItemPos(mItemList[0].ItemIndex);
                }
                float pos1 = mItemList[0].CachedRectTransform.anchoredPosition3D.y;
                float d = pos - pos1;
                float curY = pos;
                for (int i = 0; i < count; ++i)
                {
                    LoopListViewItem2 item = mItemList[i];
                    item.CachedRectTransform.anchoredPosition3D = new Vector3(item.StartPosOffset, curY, 0);
                    curY = curY + item.CachedRectTransform.rect.height + item.Padding;
                }
                if(d != 0)
                {
                    Vector3 p = mContainerTrans.anchoredPosition3D;
                    p.y = p.y - d;
                    mContainerTrans.anchoredPosition3D = p;
                }
            }
            else if (mArrangeType == ListItemArrangeType.LeftToRight)
            {
                float pos = 0;
                if (mSupportScrollBar)
                {
                    pos = GetItemPos(mItemList[0].ItemIndex);
                }
                float pos1 = mItemList[0].CachedRectTransform.anchoredPosition3D.x;
                float d = pos - pos1;
                float curX = pos;
                for (int i = 0; i < count; ++i)
                {
                    LoopListViewItem2 item = mItemList[i];
                    item.CachedRectTransform.anchoredPosition3D = new Vector3(curX, item.StartPosOffset, 0);
                    curX = curX + item.CachedRectTransform.rect.width + item.Padding;
                }
                if (d != 0)
                {
                    Vector3 p = mContainerTrans.anchoredPosition3D;
                    p.x = p.x - d;
                    mContainerTrans.anchoredPosition3D = p;
                }

            }
            else if (mArrangeType == ListItemArrangeType.RightToLeft)
            {
                float pos = 0;
                if (mSupportScrollBar)
                {
                    pos = -GetItemPos(mItemList[0].ItemIndex);
                }
                float pos1 = mItemList[0].CachedRectTransform.anchoredPosition3D.x;
                float d = pos - pos1;
                float curX = pos;
                for (int i = 0; i < count; ++i)
                {
                    LoopListViewItem2 item = mItemList[i];
                    item.CachedRectTransform.anchoredPosition3D = new Vector3(curX, item.StartPosOffset, 0);
                    curX = curX - item.CachedRectTransform.rect.width - item.Padding;
                }
                if (d != 0)
                {
                    Vector3 p = mContainerTrans.anchoredPosition3D;
                    p.x = p.x - d;
                    mContainerTrans.anchoredPosition3D = p;
                }

            }
            if (mIsDraging)
            {
                mScrollRect.OnBeginDrag(mPointerEventData);
                mScrollRect.Rebuild(CanvasUpdate.PostLayout);
                mScrollRect.velocity = mAdjustedVec;
                mNeedAdjustVec = true;
            }
        }
        void UpdateContentSize()
        {
            float size = GetContentPanelSize();
            if (mIsVertList)
            {
                if(mContainerTrans.rect.height != size)
                {
                    mContainerTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
                }
            }
            else
            {
                if(mContainerTrans.rect.width != size)
                {
                    mContainerTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
                }
            }
        }

        /// <summary>
        /// 重新创建用于预览的item
        /// </summary>
        /// <param name="addCount"></param>
        public void RecreatePreviewItems(int addCount)
        {
            if (mItemPrefabDataList.Count == 0 || Application.isPlaying) return;

            RemovePreviewItems();
            if (addCount <= 0)  return;
            InitItemPool();

            var itemIndex = mItemList.Count;
            addCount = Mathf.Max(addCount, 0);
            for (int i = 0; i < addCount; i++)
            {
                foreach ( var v in mItemPrefabDataList)
                {
                    var item = NewListViewItem(v.mItemPrefab.name);
                    item.ItemIndex = itemIndex++;
                    mItemList.Add(item);
                }
            }
            UpdateAllShownItemsPos();
        }

        void RemovePreviewItems()
        {
            RecycleAllItem();
            ClearAllTmpRecycledItem();
            foreach (var v in mItemPoolDict)
                v.Value.DestroyAllItem();
            mItemPoolDict?.Clear();
        }
        
        void OnEnable()
        {
            // 编辑时预览
#if UNITY_EDITOR
            if (!Application.isPlaying)
                InitComponentRef();
#endif
        }
        void OnDisable()
        {
            // 自动移除预览
#if UNITY_EDITOR
            if (!Application.isPlaying)
                RemovePreviewItems();
#endif
        }

        private void OnDestroy()
        {
            mOnDragingAction = null;
            mOnBeginDragAction = null;
            mOnEndDragAction = null;
            mOnSnapItemFinished = null;
            mOnSnapNearestChanged = null;
            mOnGetItemByIndex = null;
        }
    }

}
