public interface IBundleFileMapper
{
    SearchPath searchPath { get; }

    void GetFileInfo(string relativePath, out string mappingRelativePath, out int offset);
}