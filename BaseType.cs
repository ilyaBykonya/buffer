using System.IO;
using System.Runtime.Serialization;

namespace BinarySerializableTypes
{
    public abstract partial class BaseType
    {
        public enum DataType: byte
        {
            Int = 0xA0,
            UInt = 0xB0,
            Bool = 0xC0,
            String = 0xD0,
            Array = 0xE0,
            Blob = 0xF0
        }
        public const byte BeginMessageCode = 0x40;
        public DataType TypeCode { get; }
        public BaseType(DataType type)
        {
            TypeCode = type;
        }


        public abstract uint TypeBinarySize();
        public abstract void SerializeValue(BinaryWriter writer);
        public abstract void DeserializeValue(BinaryReader reader);

        protected static void AssertBeginMessageCode(byte readedByte)
        {
            if (readedByte != BeginMessageCode)
                throw new InvalidDataContractException($"Invalid begin message code: expected {BeginMessageCode}, but was {readedByte}");
        }
    }

    class TypeInt: BaseType
    {
        public int Value = 0;
        public TypeInt(int value = 0)
        :base(DataType.Int)
        {
            Value = value;
        }

        public override uint TypeBinarySize()
        {
            return 5;
        }
        public override void SerializeValue(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void DeserializeValue(BinaryReader reader)
        {
            Value = reader.ReadInt32();
        }
    }
    class TypeUInt: BaseType
    {
        public uint Value = 0;
        public TypeUInt(uint value = 0)
        :base(DataType.UInt)
        {
            Value = value;
        }

        public override uint TypeBinarySize()
        {
            return 5;
        }
        public override void SerializeValue(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void DeserializeValue(BinaryReader reader)
        {
            Value = reader.ReadUInt32();
        }
    }
    class TypeBool : BaseType
    {
        public bool Value = false;
        public TypeBool(bool value = false)
        :base(DataType.Bool)
        {
            Value = value;
        }

        public override uint TypeBinarySize()
        {
            return 2;
        }
        public override void SerializeValue(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void DeserializeValue(BinaryReader reader)
        {
            Value = reader.ReadBoolean();
        }
    } 
    class TypeString : BaseType
    {
        public string Value;
        public TypeString(string value = null)
        :base(DataType.String)
        {
            Value = value;
        }

        public override uint TypeBinarySize()
        {
            return (uint)(Value.Length * 2 + 3);
        }
        public override void SerializeValue(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void DeserializeValue(BinaryReader reader)
        {
            Value = reader.ReadString();
        }
    }
    class TypeArray : BaseType
    {
        public BaseType[] Value;
        public TypeArray(BaseType[] value = null)
        :base(DataType.Array)
        {
            Value = value;
        }


        public override uint TypeBinarySize()
        {
            uint resultSize = 1;
            foreach (BaseType element in Value)
                resultSize += element.TypeBinarySize();

            return resultSize;
        }
        public override void SerializeValue(BinaryWriter writer)
        {
            writer.Write((byte)Value.Length);
            foreach (BaseType element in Value)
            {
                writer.Write((byte)element.TypeCode);
                element.SerializeValue(writer);
            }
        }
        public override void DeserializeValue(BinaryReader reader)
        {
            Value = new BaseType[reader.ReadByte()];
            for(byte i = 0; i < Value.Length; ++i)
            {
                Value[i] = CreateType((DataType)reader.ReadByte());
                Value[i].DeserializeValue(reader);
            }
        }
    }
    class TypeBlob : BaseType
    {
        public byte[] Value;
        public TypeBlob(byte[] value = null)
        :base(DataType.Blob)
        {
            Value = value;
        }

        public override uint TypeBinarySize()
        {
            return (uint)(1 + Value.Length);
        }
        public override void SerializeValue(BinaryWriter writer)
        {
            writer.Write(Value);
        }
        public override void DeserializeValue(BinaryReader reader)
        {
            Value = reader.ReadBytes(reader.ReadByte());
        }
    }
}
