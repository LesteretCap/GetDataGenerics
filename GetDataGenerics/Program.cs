using System;

namespace GetDataGenerics
{
    interface IMyList<T>
    {
        void AddElement(T item);
        T PrintElement { get; set; }
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
        public T PrintElement { get; set; }
        public void AddElement(T PrintElement)
        {
            Array.Resize<T>(ref array, array.Length + 1);
            array[array.Length - 1] = PrintElement;
        }

        public T this[int index]
        {
            get => array[index];
        }
        public int CountArray { get => array.Length; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IMyList<int> list = new List<int>();

            AddElementaArray(list);

            Console.WriteLine(new string('-', 50));

            FindElement(list);

            Console.WriteLine(new string('-', 50));

            ElementsInArray(list);
        }

        private static void ElementsInArray(IMyList<int> list)
        {
            Console.Write("Elements int array: ");
            Console.Write(list.CountArray);
        }

        private static void FindElement(IMyList<int> list)
        {
            Console.Write("Enter the element to find: ");
            Console.WriteLine(list[Convert.ToInt32(Console.ReadLine())]);
        }

        private static void AddElementaArray(IMyList<int> list)
        {
            bool exit = true;
            while (exit)
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
                    list.PrintElement = value;
                    list.AddElement(list.PrintElement);
                }
            }
        }
    }
}
