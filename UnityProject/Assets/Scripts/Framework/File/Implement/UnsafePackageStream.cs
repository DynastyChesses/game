#if !UNITY_WEBGL || UNITY_EDITOR
using System;
using System.IO;

public interface IUnsafeStream
{
    unsafe int Read(byte* buffer, int offset, int count);

    unsafe void Write(byte* buffer, int offset, int count);
}

public unsafe class UnsafePackageStream:Stream, IUnsafeStream
{
    private IntPtr _fd;
    private long _length;
    private long _position;
    
    public UnsafePackageStream(IntPtr fd, long length)
    {
        this._fd = fd;
        this._length = length;
    }

    public override void Close()
    {
        if (_fd != IntPtr.Zero)
        {
            DefaultNativeIO.closePackageFile(_fd);
            _fd = IntPtr.Zero;
        }

        this._length = 0;
        this._position = 0;
        base.Close();
    }

    public override void Flush()
    {
        
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (_fd == IntPtr.Zero)
        {
            return 0;
        }
        fixed (byte* ptr = &buffer[offset])
        {
            var readBytes = DefaultNativeIO.readPackageFile(_fd, new IntPtr(ptr), (int)_position, count, out var error);
            Position += readBytes;
            return readBytes;
        }       
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        switch (origin)
        {
            case SeekOrigin.Begin:
                _position = offset;
                break;
            case SeekOrigin.Current:
                _position += offset;
                break;
            case SeekOrigin.End:
                _position = Length + offset;
                break;
        }

        return Position;
    }

    public override void SetLength(long value)
    {
        throw new System.NotImplementedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new System.NotImplementedException();
    }

    public override bool CanRead => true;

    public override bool CanSeek => true;

    public override bool CanWrite => false;

    public override long Length => _length;

    public override long Position 
    {
        get => _position;
        set => _position = value;
    }
    
    public int Read(byte* buffer, int offset, int count)
    {
        if (_fd == IntPtr.Zero)
        {
            return 0;
        }
        var readBytes = DefaultNativeIO.readPackageFile(_fd, new IntPtr(buffer + offset), (int)_position, count, out var error);
        Position += readBytes;
        return readBytes;
    }

    public virtual void Write(byte* buffer, int offset, int count)
    {
        throw new System.NotImplementedException();
    }
}
#endif