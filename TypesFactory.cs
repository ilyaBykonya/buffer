using System;
using System.IO;

namespace BinarySerializableTypes
{
    public partial class BaseType
    {
        public static BaseType CreateType(DataType type)
        {
            //Высокопонтовый switch
            return type switch
            {
                DataType.Int => new TypeInt(),
                DataType.UInt => new TypeUInt(),
                DataType.Bool => new TypeBool(),
                DataType.String => new TypeString(),
                DataType.Array => new TypeArray(),
                DataType.Blob => new TypeBlob(),
                _ => throw new InvalidCastException(),
                //Строчка выше -- а-ля default
            };
        }

        public int SerializeType(byte[] data, int offset)
        {
            uint valueSize = TypeBinarySize();
            var writer = new BinaryWriter(new MemoryStream(data, offset, data.Length - offset, true));

            writer.Write(BeginMessageCode);
            writer.Write(4 + valueSize);
            writer.Write((byte)TypeCode);
            SerializeValue(writer);
            return (int)(valueSize + 5);
        }
        public int DeserializeType(byte[] data, int offset)
        {
            var reader = new BinaryReader(new MemoryStream(data, offset, data.Length - offset, false));
            AssertBeginMessageCode(reader.ReadByte());
            reader.ReadUInt32();
            reader.ReadByte();
            DeserializeValue(reader);
            return (int)(TypeBinarySize() + 5);
        }
    }
}
