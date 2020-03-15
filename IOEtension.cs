using System.Text;
using System;
using System.IO;

namespace IOExtension
{
    public static class IOExtension
    {
        public static string ReadUTF8String(this BinaryReader reader)
        {
            return Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
        }

        public static string ReadUTF8StringLen(this BinaryReader reader, int length)
        {
            return Encoding.UTF8.GetString(reader.ReadBytes(length));
        }

        public static void writeUTF8String(this BinaryWriter writer, string str)
        {
            writer.Write(Encoding.UTF8.GetBytes(str));
        }

        public static void Align(this BinaryReader reader, int align)
        {
            while(reader.BaseStream.Position % align != 0)
                reader.BaseStream.Position++;
        }

        public static void Skip(this BinaryReader reader, int count)
        {
            reader.BaseStream.Position += count;
        }
    }
}
