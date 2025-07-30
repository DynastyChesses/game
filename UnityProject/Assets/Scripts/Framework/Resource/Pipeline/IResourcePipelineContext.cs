using System;
public interface IResourcePipelineContext
{
    Type type { get; }
    void Add(IResourcePipelineCallback callback);
    void Remove(IResourcePipelineCallback callback);
}

