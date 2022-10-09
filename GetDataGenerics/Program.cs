using System;

namespace GetDataGenerics
{
    interface IList<T>
    {
        void Add(T item);
        T this[int index] { get; }
        int CountArray { get; }
    }
    class MyList<T> : IList<T>
    {
        private T[] array;
        public MyList()
        {
            array = new T[0];
        }
        public void Add(T element)

        {
            Array.Resize<T>(ref array, array.Length + 1);
            array[array.Length - 1] = element;
        }
        public T this[int index]
        {
            get => array[index];
        }
        public int CountArray { get => array.Length; }
    }
    static class MyClass
    {
        public static T[] GetArray<T>(this IList<T> list)
        {
            T[] sourceArray = new T[list.CountArray];
            for (int i = 0; i < list.CountArray; i++)
            {
                sourceArray[i] = list[i];
            }
            return sourceArray;
        }
    }
    internal class Program
    {
        private static void AddElementsArray(IList<int> list)
        {
            Console.WriteLine("Enter \"exit\" to exit.");
            while (true)
            {
                Console.Write("Enter the element to array: ");
                string cont = Console.ReadLine();
                if (cont == "exit")
                {
                    break;
                }
                else
                {
                    int value = Convert.ToInt32(cont);
                    list.Add(value);
                }
            }
        }
        private static int FindElement(IList<int> list)
        {
            Console.Write("Enter the element to find: ");
            return list[Convert.ToInt32(Console.ReadLine())];
        }
        private static int PrintLengthArray(IList<int> list)
        {
            Console.Write("Elements int array: ");
            return list.CountArray;
        }

        static void Main(string[] args)
        {
            IList<int> list = new MyList<int>();

            AddElementsArray(list);

            Console.WriteLine(new string('-', 50));

            Console.WriteLine(FindElement(list));

            Console.WriteLine(new string('-', 50));

            Console.WriteLine(PrintLengthArray(list));

            Console.WriteLine(new string('-', 50));

            int[] sourceArray = MyClass.GetArray(list);
            Console.Write("All elements in array: ");
            foreach (var item in sourceArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}
