using System;
using System.Collections.Generic;
[Serializable]
public class AssetList
{
	public AssetNode[] nodes;

	public AssetNode this[int index]
	{
		get { return nodes[index]; }
	}

	public int nodeCount
	{
		get { return nodes != null ? nodes.Length : 0; }
	}

	[NonSerialized] public Dictionary<string, AssetNode> _nodeMap;

	private void CheckNodeMap()
	{
		if (_nodeMap == null)
		{
			int count = nodeCount;
			_nodeMap = new Dictionary<string, AssetNode>(count);
			for (int i = 0; i < count; ++i)
			{
				_nodeMap.Add(nodes[i].id, nodes[i]);
			}
		}
	}

	public bool TryGetValue(string id, out AssetNode node)
	{
		CheckNodeMap();
		return _nodeMap.TryGetValue(id, out node);
	}

	public bool Contains(string id)
	{
		CheckNodeMap();
		return _nodeMap.ContainsKey(id);
	}

	public AssetNode this[string id]
	{
		get
		{
			CheckNodeMap();
			return _nodeMap[id];
		}
	}
}