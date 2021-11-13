// Вставьте сюда финальное содержимое файла MovingAverageTask.cs
using System;
using BinarySerializableTypes;
using System.Collections.Generic;

namespace yield
{
	public static class Program
	{
        static void PrintInt(TypeInt value)
        {
            Console.WriteLine(value.Value);
            value.Value = 10;
            Console.WriteLine(value.Value);
        }
        static void test_1()
        {
            Console.WriteLine("===================================");
            TypeInt x = new TypeInt(15);
            Console.WriteLine(x.Value);

            byte[] buffer = new byte[1000];
            int offset = x.SerializeType(buffer, 0);
            for(int i = 0; i < offset; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            x.DeserializeType(buffer, 0);
            Console.WriteLine(x.Value);
            Console.WriteLine("===================================");
        }
        static void test_2()
        {
            Console.WriteLine("===================================");
            TypeString x = new TypeString("Hello, world");
            Console.WriteLine(x.Value);

            byte[] buffer = new byte[1000];
            int offset = x.SerializeType(buffer, 0);
            for (int i = 0; i < offset; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            x.DeserializeType(buffer, 0);
            Console.WriteLine(x.Value);
            Console.WriteLine("===================================");
        }
        static void test_3()
        {
            Console.WriteLine("===================================");
            TypeArray x = new TypeArray(new BaseType[]{ new TypeInt(42), new TypeBool(true), new TypeString("FooBar") });

            Console.WriteLine(((TypeInt)x.Value[0]).Value);
            Console.WriteLine(((TypeBool)x.Value[1]).Value);
            Console.WriteLine(((TypeString)x.Value[2]).Value);

            byte[] buffer = new byte[1000];
            int offset = x.SerializeType(buffer, 0);
            for (int i = 0; i < offset; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            x.DeserializeType(buffer, 0);

            Console.WriteLine(((TypeInt)x.Value[0]).Value);
            Console.WriteLine(((TypeBool)x.Value[1]).Value);
            Console.WriteLine(((TypeString)x.Value[2]).Value);
            Console.WriteLine("===================================");
        }

        static void Main(string[] args)
        {
            test_1();
            test_2();
            test_3();
        }
	}
}
