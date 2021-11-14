using System;
using System.IO;
using System.Runtime.Serialization;

namespace BaseTypesSerializator
{
    static class BaseTypesSerializator
    {
        public static int SerializeType(object value, byte[] data, int offset)
        {
            uint valueSize = GetTypeSize(value);
            var writer = new BinaryWriter(new MemoryStream(data, offset, data.Length - offset, true));

            writer.Write(BeginMessageCode);
            writer.Write(5 + valueSize);
            SerializeValue(writer, value);
            return (int)(valueSize + 6);
        }
        public static int DeserializeType(out object result, byte[] data, int offset)
        {
            result = null;
            var reader = new BinaryReader(new MemoryStream(data, offset, data.Length - offset, false));
            if (reader.ReadByte() != BeginMessageCode)
                throw new InvalidDataContractException($"Invalid begin message code");

            reader.ReadUInt32();
            result = DeserializeValue(reader);
            return (int)(GetTypeSize(result) + 6);
        }



        private enum DataType: byte
        {
            Int = 0xA0,
            UInt = 0xB0,
            Bool = 0xC0,
            String = 0xD0,
            Array = 0xE0,
            Blob = 0xF0
        }
        private const byte BeginMessageCode = 0x40;

        private static void SerializeValue(BinaryWriter writer, object value)
        {
            writer.Write((byte)GetTypeCode(value));
            if (value is int) SerializeValue(writer, (int)value);
            else if (value is uint) SerializeValue(writer, (uint)value);
            else if (value is bool) SerializeValue(writer, (bool)value);
            else if (value is string) SerializeValue(writer, (string)value);
            else if (value is object[]) SerializeValue(writer, (object[])value);
            else if (value is byte[]) SerializeValue(writer, (byte[])value);
            else throw new InvalidCastException();
        }
        private static void SerializeValue(BinaryWriter writer, int value) => writer.Write(value);
        private static void SerializeValue(BinaryWriter writer, uint value) => writer.Write(value);
        private static void SerializeValue(BinaryWriter writer, bool value) => writer.Write(value);
        private static void SerializeValue(BinaryWriter writer, string value) => writer.Write(value);
        private static void SerializeValue(BinaryWriter writer, byte[] value)
        {
            writer.Write((byte)value.Length);
            writer.Write(value);
        }
        private static void SerializeValue(BinaryWriter writer, object[] value)
        {
            writer.Write((byte)value.Length);
            foreach (var obj in value)
                SerializeValue(writer, obj);
        }

        private static object DeserializeValue(BinaryReader reader)
        {
            return ((DataType)reader.ReadByte()) switch
            {
                DataType.Int => DeserializeValue(reader, default(int)),
                DataType.UInt => DeserializeValue(reader, default(uint)),
                DataType.Bool => DeserializeValue(reader, default(bool)),
                DataType.String => DeserializeValue(reader, default(string)),
                DataType.Blob => DeserializeValue(reader, default(byte[])),
                DataType.Array => DeserializeValue(reader, default(object[])),
                _ => throw new InvalidCastException()
            };
        }
        private static int DeserializeValue(BinaryReader reader, int _) => reader.ReadInt32();
        private static uint DeserializeValue(BinaryReader reader, uint _) => reader.ReadUInt32();
        private static bool DeserializeValue(BinaryReader reader, bool _) => reader.ReadBoolean();
        private static string DeserializeValue(BinaryReader reader, string _) => reader.ReadString();
        private static byte[] DeserializeValue(BinaryReader reader, byte[] _) => reader.ReadBytes(reader.ReadByte());
        private static object[] DeserializeValue(BinaryReader reader, object[] _)
        {
            object[] result = new object[reader.ReadByte()];
            for (int i = 0; i < result.Length; ++i)
                result[i] = DeserializeValue(reader);

            return result;
        }

        private static DataType GetTypeCode(object value)
        {
            if (value is int) return GetTypeCode((int)value);
            else if (value is uint) return GetTypeCode((uint)value);
            else if (value is bool) return GetTypeCode((bool)value);
            else if (value is string) return GetTypeCode((string)value);
            else if (value is object[]) return GetTypeCode((object[])value);
            else if (value is byte[]) return GetTypeCode((byte[])value);
            else throw new InvalidCastException();
        }
        private static DataType GetTypeCode(int _) => DataType.Int;
        private static DataType GetTypeCode(uint _) => DataType.UInt;
        private static DataType GetTypeCode(bool _) => DataType.Bool;
        private static DataType GetTypeCode(string value) => DataType.String;
        private static DataType GetTypeCode(object[] value) => DataType.Array;
        private static DataType GetTypeCode(byte[] value) => DataType.Blob;
        
        private static uint GetTypeSize(object value)
        {
            if (value is int) return GetTypeSize((int)value);
            else if (value is uint) return GetTypeSize((uint)value);
            else if (value is bool) return GetTypeSize((bool)value);
            else if (value is string) return GetTypeSize((string)value);
            else if (value is object[]) return GetTypeSize((object[])value);
            else if (value is byte[]) return GetTypeSize((byte[])value);
            else throw new InvalidCastException();
        }
        private static uint GetTypeSize(int _) => 4;
        private static uint GetTypeSize(uint _) => 4;
        private static uint GetTypeSize(bool _) => 1;
        private static uint GetTypeSize(string value) => (uint)((value.Length + 1) * 2);
        private static uint GetTypeSize(byte[] value) => (uint)value.Length;
        private static uint GetTypeSize(object[] value)
        {
            uint resultSize = 0;
            foreach (var obj in value)
                resultSize += GetTypeSize(obj);

            return resultSize;
        }
    }
}
