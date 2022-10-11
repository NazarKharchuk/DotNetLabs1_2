using System;
using LinkedListLibrary;
using System.Collections.Generic;

namespace Lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab1");

            try
            {
                MyLinkedList<int> list = new MyLinkedList<int>();
                list.ItemAddedEvent += ItemAddedHandler;
                list.ItemRemovedEvent += ItemRemovedHandler;
                list.ListClearedEvent += ListClearedHandler;

                Console.WriteLine("\t\tTest: Add");
                list.Add(3);
                list.Print();

                Console.WriteLine("\n\t\tTest: AddFirst");
                list.AddFirst(1);
                list.Print();

                Console.WriteLine("\n\t\tTest: AddLast");
                list.AddLast(5);
                list.Print();

                Console.WriteLine("\n\t\tTest: First & Value");
                list.First.Value = 2;
                list.Print();

                Console.WriteLine("\n\t\tTest: Last & Value");
                list.Last.Value = 4;
                list.Print();

                Console.WriteLine("\n\t\tTest: AddBefore & Last");
                list.AddBefore(list.First, 1);
                list.Print();

                Console.WriteLine("\n\t\tTest: AddAfter & Last");
                list.AddAfter(list.Last, 5);
                list.Print();

                Console.WriteLine("\n\t\tTest: RemoveFirst");
                list.RemoveFirst();
                list.Print();

                Console.WriteLine("\n\t\tTest: RemoveLast");
                list.RemoveLast();
                list.Print();

                Console.WriteLine("\n\t\tTest: Remove");
                list.Remove(3);
                list.Print();

                Console.WriteLine("\n\t\tTest: Find & Value");
                Node<int> fn = list.Find(2);
                if (fn != null) fn.Value = 22;
                fn = list.Find(4);
                if (fn != null) fn.Value = 44;
                list.Print();

                Console.WriteLine("\n\t\tTest: Clear");
                list.Clear();
                list.Print();

                Console.WriteLine("\n\t\tTest: Contains");
                Console.WriteLine(list.Contains(1));
                list.Print();
                list.Add(1);
                Console.WriteLine(list.Contains(1));
                list.Print();

                Console.WriteLine("\n\t\tTest: CopyTo");
                list.Add(2);
                list.Add(3);
                list.Add(4);
                list.Print();

                int[] ar = new int[4];

                list.CopyTo(ar, 0);

                Console.Write($"Array: ");
                foreach (int i in ar)
                {
                    Console.Write($"{i}  ");
                }

                Console.WriteLine("\n\t\tTest: FindLast");
                list.Add(1);
                list.Print();
                list.FindLast(1).Value = 5;
                list.Print();



            }
            catch(Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.ResetColor();
            }


        }

        static void ItemAddedHandler(object sender, ItemAddedEventArgs<int> e)
        {
            Console.WriteLine("Item {0} added at {1}.", e.item, e.time);
        }

        static void ItemRemovedHandler(object sender, ItemRemovedEventArgs<int> e)
        {
            Console.WriteLine("Item {0} removed at {1}.", e.item, e.time);
        }

        static void ListClearedHandler(object sender, ListClearedEventArgs<int> e)
        {
            Console.WriteLine("List is cleared at {0}.", e.time);
        }
    }
}
