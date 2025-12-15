using System;

namespace RobloxShaderPatch
{
    internal class patcher
    {
        public static void WriteHexAtOffset(string filePath, long offset, string hexBytes)
        {
            hexBytes = hexBytes.Replace(" ", "");
            if (hexBytes.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even length.");

            byte[] bytes = new byte[hexBytes.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexBytes.Substring(i * 2, 2), 16);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
