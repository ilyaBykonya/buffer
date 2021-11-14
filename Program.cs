// Вставьте сюда финальное содержимое файла MovingAverageTask.cs
using System;
using BaseTypesSerializator;
using BinarySerializableTypes;
using System.Collections.Generic;

namespace Programm
{
	public static class Program
	{

        static void test_1()
        {
            Console.WriteLine("===================================");
            int l = 14;
            Console.WriteLine(l);

            byte[] buffer = new byte[1000];
            int newOffset = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l, buffer, 0);
            for(int i = 0; i < newOffset; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            BaseTypesSerializator.BaseTypesSerializator.DeserializeType(out object k, buffer, 0);
            Console.WriteLine(k);
            Console.WriteLine("===================================");
        }
        static void test_2()
        {
            Console.WriteLine("===================================");
            string l = "Hello, world";
            Console.WriteLine(l);

            byte[] buffer = new byte[1000];
            int newOffset = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l, buffer, 0);
            for (int i = 0; i < newOffset; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            BaseTypesSerializator.BaseTypesSerializator.DeserializeType(out object k, buffer, 0);
            Console.WriteLine(k);
            Console.WriteLine("===================================");
        }
        static void test_3()
        {
            Console.WriteLine("===================================");
            object[] l = new object[3] { 42, true, "FooBar" };
            for (int i = 0; i < 3; ++i)
                Console.Write($"{l[i]:X} ");
            Console.WriteLine();

            byte[] buffer = new byte[1000];
            int newOffset = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l, buffer, 0);
            for (int i = 0; i < newOffset; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            BaseTypesSerializator.BaseTypesSerializator.DeserializeType(out object k, buffer, 0);
            for (int i = 0; i < 3; ++i)
                Console.Write($"{l[i]:X} ");
            Console.WriteLine();
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
