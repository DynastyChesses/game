public interface IResourceLoadPipe
{
    /// <summary>
    /// 对于异步的返回任务，对于同步的返回null
    /// </summary>
    /// <param name="context"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    FMTask Handle(IResourcePipelineContext context, out ResourceError error);
}