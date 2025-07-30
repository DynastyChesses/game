using System.Collections.Generic;
using UnityEngine;

public abstract class SameKindBatchRenderContext:IBatchRenderContext
{
    public virtual bool supportGPUInstance
    {
        get
        {
            return _material.enableInstancing;
        }
    }


    protected Mesh _mesh = null;

    protected Material _material = null;

    abstract protected List<Matrix4x4> batchMatrices
    {
        get;
    }

    abstract protected MaterialPropertyBlock batchMpb
    {
        get;
    }

    protected virtual int layer
    {
        get
        {
            return Layers.DEFAULT;
        }
    }

    public int total
    {
        get;
        set;
    }

    private bool _active = true;

    public bool active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;
        }
    }

    public virtual void OnGPUInstanceRender()
    {
        // TODO
    }

    public virtual void OnNormalRender()
    {
        for (int i = 0; i < total; ++i)
        {
            Graphics.DrawMesh(_mesh, batchMatrices[i], _material, layer, null, 0, GetPerObjectMpb(i), false, false, false);
        }
    }

    protected virtual MaterialPropertyBlock GetPerObjectMpb(int index)
    {
        return null;
    }
}