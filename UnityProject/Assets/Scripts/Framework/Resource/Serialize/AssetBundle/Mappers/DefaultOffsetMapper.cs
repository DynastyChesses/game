using System.Collections.Generic;
using System.IO;

public class DefaultOffsetMapper:IBundleFileMapper
{
    private string[] _fragmentPathList;

    private Dictionary<string, long> _offsetTable;

    private SearchPath _searchPath;
    
    public DefaultOffsetMapper(SearchPath searchPath, string[] fragmentsList, byte[] offsetTableBytes)
    {
        _searchPath = searchPath;
        _fragmentPathList = fragmentsList;
        if (fragmentsList == null && offsetTableBytes == null)
        {
            _offsetTable = new Dictionary<string, long>();
            return;
        }
        using (MemoryStream ms = new MemoryStream(offsetTableBytes))
        using (BinaryReader br = new BinaryReader(ms))
        {
            var count = br.ReadInt32();
            _offsetTable = new Dictionary<string, long>(count);
            for (int i = 0; i < count; ++i)
            {
                var key = br.ReadString();
                var val = br.ReadInt64();
                _offsetTable.Add(key, val);
            }
        }
    }


    public SearchPath searchPath => _searchPath;

    /// <summary>
    /// 查找bundle在合并大bundle中的偏移
    /// </summary>
    /// <param name="relativePath"></param>
    /// <param name="mappingRelativePath"></param>
    /// <param name="offset">-1表示没找到</param>
    public void GetFileInfo(string relativePath, out string mappingRelativePath, out int offset)
    {
        mappingRelativePath = relativePath;
        offset = -1;    // 默认-1表示查找失败
        if (!_offsetTable.TryGetValue(relativePath, out var rawInfo))
        {
            return;
        }

        if (rawInfo != -1)
        {
            offset = (int) (rawInfo & 0xffffffff);
            int fragmentIndex = (int) (rawInfo >> 32);
            if (_fragmentPathList != null)
                mappingRelativePath = _fragmentPathList[fragmentIndex];                
        }
    }
}