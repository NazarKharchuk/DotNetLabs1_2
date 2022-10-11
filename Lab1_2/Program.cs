﻿using System;
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

                list.Add(1);
                list.Add(3);
                list.Add(5);
                list.Print();

                foreach(int i in list.Reverse)
                {
                    Console.WriteLine(i);
                }

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
    }
}
