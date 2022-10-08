using System;

namespace GetDataGenerics
{
    interface IMyList<T>
    {
        void Add(T item);
        T this[int index] { get; }
        int CountArray { get; }
    }
    class List<T> : IMyList<T>
    {
        private T[] array;
        public List()
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

    internal class Program
    {
        private static void AddElementsArray(IMyList<int> list)
        {
            while (true)
            {
                Console.WriteLine("Enter \"exit\" to exit.");
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
        private static int FindElement(IMyList<int> list)
        {
            Console.Write("Enter the element to find: ");
            return list[Convert.ToInt32(Console.ReadLine())];
        }
        private static int PrintLengthArray(IMyList<int> list)
        {
            Console.Write("Elements int array: ");
            return list.CountArray;
        }

        static void Main(string[] args)
        {
            IMyList<int> list = new List<int>();

            AddElementsArray(list);

            Console.WriteLine(new string('-', 50));

            Console.WriteLine(FindElement(list));

            Console.WriteLine(new string('-', 50));

            Console.WriteLine(PrintLengthArray(list));
        }
    }
}
