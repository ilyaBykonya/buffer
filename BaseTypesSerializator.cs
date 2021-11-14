using System;
using System.IO;
using System.Runtime.Serialization;

namespace BaseTypesSerializator
{
    static class BaseTypesSerializator
    {
        public static byte[] SerializeType(object value)
        {
            uint valueSize = GetTypeSize(value) + 4;
            byte[] data = new byte[valueSize + 1];
            var writer = new BinaryWriter(new MemoryStream(data, true), System.Text.Encoding.UTF8);


            writer.Write(BeginMessageCode);
            //BinaryWriter пишет от BigEndian. Так что приходится его разбивать.
            writer.Write((byte)(valueSize >> 24));
            writer.Write((byte)(valueSize >> 16));
            writer.Write((byte)(valueSize >> 8));
            writer.Write((byte)(valueSize >> 0));
            SerializeValue(writer, value);
            return data;
        }
        public static object DeserializeType(byte[] data)
        {
            object result = null;
            var reader = new BinaryReader(new MemoryStream(data, false), System.Text.Encoding.UTF8);
            if (reader.ReadByte() != BeginMessageCode)
                throw new InvalidDataContractException($"Invalid begin message code");

            //Да. Такая страшная запись позволяет восстановить байт. Можно не париться. Это работает.
            uint writtenSize = ((uint)reader.ReadByte() << 24) | ((uint)reader.ReadByte() << 16) | ((uint)reader.ReadByte() << 8) | ((uint)reader.ReadByte());
            if (data.Length != writtenSize + 1)
                throw new OutOfMemoryException($"Invalid data block size. Expected {writtenSize}, but was {data.Length}");
            
            result = DeserializeValue(reader);
            return result;
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
        private static void SerializeValue(BinaryWriter writer, int value)
        {
            //И даже тут обратная запись подкинула ложку дёгтя.
            //Делаем всё тоже самое, что и с размером
            writer.Write((byte)(value >> 24));
            writer.Write((byte)(value >> 16));
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value >> 0));
        }
        private static void SerializeValue(BinaryWriter writer, uint value)
        {
            //И даже тут обратная запись подкинула ложку дёгтя.
            //Делаем всё тоже самое, что и с размером
            writer.Write((byte)(value >> 24));
            writer.Write((byte)(value >> 16));
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value >> 0));
        }
        private static void SerializeValue(BinaryWriter writer, bool value) => writer.Write(value);
        private static void SerializeValue(BinaryWriter writer, string value)
        {
            //C# десериализует строки следующим образом.
            //Выше я установил формат UTF-8, поэтому он
            //обрезает двухбайтовые символы до однобайтовых.
            //C# пишет кол-во символов в поток, потом сами символы. Он не ставит \0
            //Поэтому делаем сие дело руками:
            foreach (char symbol in value)
                writer.Write(symbol);
            writer.Write('\0');
        }
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
        private static int DeserializeValue(BinaryReader reader, int _)
        {
            return ((int)reader.ReadByte() << 24) | ((int)reader.ReadByte() << 16) | ((int)reader.ReadByte() << 8) | ((int)reader.ReadByte());
        }
        private static uint DeserializeValue(BinaryReader reader, uint _)
        {
            return ((uint)reader.ReadByte() << 24) | ((uint)reader.ReadByte() << 16) | ((uint)reader.ReadByte() << 8) | ((uint)reader.ReadByte());
        }
        private static bool DeserializeValue(BinaryReader reader, bool _) => reader.ReadBoolean();
        private static string DeserializeValue(BinaryReader reader, string _)
        {
            //Ну и т.к. мы офигенно записали руками всё, что там было, придётся
            //точно также, руками, читать всё обратно
            string result = String.Empty;
            for (char symbol = reader.ReadChar(); symbol != '\0'; symbol = reader.ReadChar())
                result += symbol;
            return result;
        }
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
        private static uint GetTypeSize(int _) => 5;
        private static uint GetTypeSize(uint _) => 5;
        private static uint GetTypeSize(bool _) => 2;
        private static uint GetTypeSize(string value) => (uint)(value.Length + 2);
        private static uint GetTypeSize(byte[] value) => (uint)value.Length + 2;
        private static uint GetTypeSize(object[] value)
        {
            uint resultSize = 2;
            foreach (var obj in value)
                resultSize += GetTypeSize(obj);

            return resultSize;
        }
    }
}
