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

                list.Add(1);
                list.Add(3);
                list.Add(5);
                list.Print();

                list.RemoveFirst();
                list.Print();

                list.Clear();
                list.Print();

                //Console.WriteLine($"Count: {list.Count}");
                /*LinkedList<int> list2 = new LinkedList<int>();
                list2.AddFirst(1);
                LinkedListNode<int> c = list2.Find(4);
                c.Value = 2;*/

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
