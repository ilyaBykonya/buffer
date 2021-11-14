// Вставьте сюда финальное содержимое файла MovingAverageTask.cs
using System;
using BaseTypesSerializator;
using System.Collections.Generic;

namespace Programm
{
	public static class Program
	{

        static void test_1()
        {
            Console.WriteLine("===================================");
            int l = 269488144;
            Console.WriteLine(l);

            byte[] buffer = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l);
            for(int i = 0; i < buffer.Length; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            object k = BaseTypesSerializator.BaseTypesSerializator.DeserializeType(buffer);
            Console.WriteLine(k);
            Console.WriteLine("===================================");
        }
        static void test_2()
        {
            Console.WriteLine("===================================");
            bool l = true;
            Console.WriteLine(l);

            byte[] buffer = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l);
            for (int i = 0; i < buffer.Length; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            object k = BaseTypesSerializator.BaseTypesSerializator.DeserializeType(buffer);
            Console.WriteLine(k);
            Console.WriteLine("===================================");
        }
        static void test_3()
        {
            Console.WriteLine("===================================");
            byte[] l = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for(int i = 0; i < l.Length; ++i)
                Console.Write($"{l[i]} ");
            Console.WriteLine();

            byte[] buffer = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l);
            for (int i = 0; i < buffer.Length; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            byte[] k = (byte[])BaseTypesSerializator.BaseTypesSerializator.DeserializeType(buffer);
            for (int i = 0; i < l.Length; ++i)
                Console.Write($"{k[i]} ");
            Console.WriteLine();
            Console.WriteLine("===================================");
        }
        static void test_4()
        {
            Console.WriteLine("===================================");
            string l = "abcde";
            Console.WriteLine(l);

            byte[] buffer = BaseTypesSerializator.BaseTypesSerializator.SerializeType(l);
            for (int i = 0; i < buffer.Length; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            object k = BaseTypesSerializator.BaseTypesSerializator.DeserializeType(buffer);
            Console.WriteLine(k);
            Console.WriteLine("===================================");
        }
        static void test_5()
        {
            Console.WriteLine("===================================");
            object[] arr = {
                new object[] {
                    1, 2, 3
                },
                "abstd",
                true
            };
            Console.WriteLine(((object[])arr[0])[0]);
            Console.WriteLine(((object[])arr[0])[1]);
            Console.WriteLine(((object[])arr[0])[2]);
            Console.WriteLine(arr[1]);
            Console.WriteLine(arr[2]);

            byte[] buffer = BaseTypesSerializator.BaseTypesSerializator.SerializeType(arr);
            for (int i = 0; i < buffer.Length; ++i)
                Console.Write($"{buffer[i]:X} ");
            Console.WriteLine();

            object[] second_arr = (object[])BaseTypesSerializator.BaseTypesSerializator.DeserializeType(buffer);

            Console.WriteLine(((object[])second_arr[0])[0]);
            Console.WriteLine(((object[])second_arr[0])[1]);
            Console.WriteLine(((object[])second_arr[0])[2]);
            Console.WriteLine(second_arr[1]);
            Console.WriteLine(second_arr[2]);
            Console.WriteLine("===================================");
        }

        static void Main(string[] args)
        {
            test_1();
            test_2();
            test_3();
            test_4();
            test_5();
        }
	}
}
