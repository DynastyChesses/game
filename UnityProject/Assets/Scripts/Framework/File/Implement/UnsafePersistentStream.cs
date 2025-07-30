#if !UNITY_WEBGL || UNITY_EDITOR
using System;
using System.IO;

public unsafe class UnsafePersistentStream:Stream, IUnsafeStream
{
    private IntPtr _fd;
    private long _length;
    private long _position;
    
    public UnsafePersistentStream(IntPtr fd, long length)
    {
        this._fd = fd;
        this._length = length;
    }
    
    public override void Close()
    {
        if (_fd != IntPtr.Zero)
        {
            DefaultNativeIO.closePersistentFile(_fd);
            _fd = IntPtr.Zero;
        }

        this._length = 0;
        this._position = 0;
        base.Close();
    }


    public override void Flush()
    {
        if (_fd != IntPtr.Zero)
        {
            DefaultNativeIO.flushPersistentFile(_fd);
        }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (_fd == IntPtr.Zero)
        {
            return 0;
        }
        fixed (byte* ptr = &buffer[offset])
        {
            var readBytes = DefaultNativeIO.readPersistentFile(_fd, new IntPtr(ptr), (int)_position, count, out var error);
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
        if (_fd != IntPtr.Zero)
        {
            _length = value;
            DefaultNativeIO.setPersistentFileLength(_fd, (int) value);
        }
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        if (_fd == IntPtr.Zero)
        {
            return;
        }

        fixed (byte* ptr = &buffer[offset])
        {
            int writeBytes = DefaultNativeIO.writePersistentFile(_fd, new IntPtr(ptr), (int) Position, count);
            Position += writeBytes;

        }
    }

    public override bool CanRead => true;
    public override bool CanSeek => true;
    public override bool CanWrite => true;
    public override long Length => _length;
    public override long Position {
        get => _position;
        set => _position = value;
    }
    public int Read(byte* buffer, int offset, int count)
    {
        if (_fd == IntPtr.Zero)
        {
            return 0;
        }
        var readBytes = DefaultNativeIO.readPersistentFile(_fd, new IntPtr(buffer + offset), (int)_position, count, out var error);
        Position += readBytes;
        return readBytes;
    }

    public void Write(byte* buffer, int offset, int count)
    {
        if (_fd == IntPtr.Zero)
        {
            return;
        }

        int writeBytes = DefaultNativeIO.writePersistentFile(_fd, new IntPtr(buffer + offset), (int) Position, count);
        Position += writeBytes;
    }
}
#endif