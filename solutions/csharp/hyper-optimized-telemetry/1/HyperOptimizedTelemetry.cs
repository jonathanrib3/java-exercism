public static class TelemetryBuffer
{
    static byte[] unsignedPrefixes = new byte[] { 8, 4, 2 };
    public static byte[] ToBuffer(long reading)
    {
        if (reading >= 0)
        {
            if (reading <= ushort.MaxValue)
            {
                return BuildBuffer(BitConverter.GetBytes((ushort)reading), false);
            }
            if (reading <= int.MaxValue)
            {
                return BuildBuffer(BitConverter.GetBytes((int)reading), true);
            }
            if (reading <= uint.MaxValue)
            {
                return BuildBuffer(BitConverter.GetBytes((uint)reading), false);
            }
            if (reading <= long.MaxValue)
            {
                return BuildBuffer(BitConverter.GetBytes((long)reading), true);
            }
            return new Byte[] { 0 };
        }
        else
        {
            if (reading >= short.MinValue)
            {
                return BuildBuffer(BitConverter.GetBytes((short)reading), true);
            }
            if (reading >= int.MinValue)
            {
                return BuildBuffer(BitConverter.GetBytes((int)reading), true);
            }
            if (reading >= long.MinValue)
            {
                return BuildBuffer(BitConverter.GetBytes((long)reading), true);
            }
            return new Byte[] { 0 };
        }
    }

    public static byte[] BuildBuffer(byte[] arr, bool signed)
    {
        var newBuffer = new Byte[9];
        int byteCount = arr.Length;
    
        newBuffer[0] = signed ? (byte)(256 - byteCount) : (byte)byteCount;
        for (var i = 0; i < arr.Length; i++)
        {
            newBuffer[i + 1] = arr[i];
        }
    
        return newBuffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        var prefix = buffer[0];
        byte length = IsUnsigned(buffer) ? prefix : (byte)(256 - prefix);
        if (!Array.Exists(unsignedPrefixes, up => up == length))
        {
            return 0;
        }
        var newBuffer = new Byte[length];
        Array.Copy(buffer, 1, newBuffer, 0, length);
   
        (bool signed, byte length, byte[] bufferToConvert) bufferData = (
            signed: !IsUnsigned(buffer),
            length: length,
            bufferToConvert: newBuffer
        );
        return BufferToIntegral(bufferData);
    }

    public static bool IsUnsigned(byte[] buffer)
    {
        foreach(var b in unsignedPrefixes)
        {
            if(b == buffer[0])
            {
                return true;
            }
        }
        return false;
    }

    public static long BufferToIntegral((bool signed, byte length, byte[] bufferToConvert) bufferData)
    {
        switch(bufferData.length)
        {
            case 8 when bufferData.signed == true:
                return BitConverter.ToInt64(bufferData.bufferToConvert, 0);
            case 4 when bufferData.signed == true:
                return BitConverter.ToInt32(bufferData.bufferToConvert, 0);
            case 2 when bufferData.signed == true:
                return BitConverter.ToInt16(bufferData.bufferToConvert, 0);
            case 8 when bufferData.signed == false:
                return (long)BitConverter.ToUInt64(bufferData.bufferToConvert, 0);
            case 4 when bufferData.signed == false:
                return BitConverter.ToUInt32(bufferData.bufferToConvert, 0);
            case 2 when bufferData.signed == false:
                return BitConverter.ToUInt16(bufferData.bufferToConvert, 0);
        }
        return 0;
    }

}
