using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListLibrary
{
    public class MyLinkedList<T> : ICollection<T>
    {
        private int count;
        private Node<T> head;

        public event EventHandler<ItemAddedEventArgs<T>> ItemAddedEvent;
        public event EventHandler<ItemRemovedEventArgs<T>> ItemRemovedEvent;
        public event EventHandler<ListClearedEventArgs<T>> ListClearedEvent;

        public int Count {
            get { return count; }
        }

        public Node<T> First
        {
            get {
                if (head == null)
                {
                    throw new InvalidOperationException("List contains no elements");
                }

                return head; 
            }
        }

        public Node<T> Last
        {
            get {
                if (head == null)
                {
                    throw new InvalidOperationException("List contains no elements");
                }

                Node<T> last = head;

                while (last.next != null)
                {
                    last = last.next;
                }

                return last;
            }
        }

        public bool IsReadOnly { 
            get;
        }

        public MyLinkedList()
        {
            count = 0;
            head = null;
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            while (head != null)
            {
                Node<T> temp = head;
                head = head.next;
                temp.Invalidate();
            }
            count = 0;
            head = null;

            ListClearedEvent?.Invoke(this, new ListClearedEventArgs<T>());
        }

        public bool Contains(T item)
        {
            return (Find(item) != null);
        }

        public Node<T> AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);

            count++;

            node.next = head;
            node.prev = null;

            if(head != null)
            {
                head.prev = node;
            }

            head = node;

            ItemAddedEvent?.Invoke(this, new ItemAddedEventArgs<T>(item));

            return node;
        }

        public Node<T> AddLast(T item)
        {
            Node<T> node = new Node<T>(item);

            count++;

            node.next = null;

            Node<T> last = head;

            if (head == null)
            {
                node.prev = null;
                head = node;
                ItemAddedEvent?.Invoke(this, new ItemAddedEventArgs<T>(item));
                return node;
            }

            while (last.next != null)
            {
                last = last.next;
            }

            last.next = node;

            node.prev = last;

            ItemAddedEvent?.Invoke(this, new ItemAddedEventArgs<T>(item));

            return node;
        }

        public void RemoveFirst()
        {
            T item;
            if(head == null)
            {
                throw new InvalidOperationException("List contains no elements");
            }

            if(head.next == null)
            {
                item = head.Value;
                head.Invalidate();
                head = null;
            }
            else
            {
                item = head.Value;
                Node<T> temp = head;
                head = temp.next;
                head.prev = null;
                temp.Invalidate();
            }
            count--;

            ItemRemovedEvent?.Invoke(this, new ItemRemovedEventArgs<T>(item));
        }

        public void RemoveLast()
        {
            T item;
            if (head == null)
            {
                throw new InvalidOperationException("List contains no elements");
            }

            if (head.next == null)
            {
                item = head.Value;
                head.Invalidate();
                head = null;
            }
            else
            {
                Node<T> last = Last;
                item = last.Value;
                last.prev.next = null;
                last.Invalidate();
            }
            count--;

            ItemRemovedEvent?.Invoke(this, new ItemRemovedEventArgs<T>(item));
        }

        public Node<T> Find(T item)
        {
            Node<T> node = null;

            Node<T> temp = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            while (temp != null)
            {
                if(c.Equals(temp.value, item))
                {
                    node = temp;
                    break;
                }
                temp = temp.next;
            }

            return node;
        }

        public Node<T> FindLast(T item)
        {
            Node<T> node = null;

            Node<T> temp = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            while (temp != null)
            {
                if (c.Equals(temp.value, item))
                {
                    node = temp;
                }
                temp = temp.next;
            }

            return node;
        }

        public bool Remove(T item)
        {
            Node<T> node = Find(item);

            if (node != null)
            {
                if(node.next != null && node.prev != null)
                {
                    node.next.prev = node.prev;
                    node.prev.next = node.next;
                    node.Invalidate();
                    count--;

                    ItemRemovedEvent?.Invoke(this, new ItemRemovedEventArgs<T>(item));
                }
                else
                {
                    if(node.next == null)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        RemoveFirst();
                    }
                }
                return true;
            }
            else
                return false;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (array.Length - index < count)
            {
                throw new InvalidOperationException("Array has insufficient space");
            }

            Node<T> temp = head;
            while (temp != null)
            {
                array[index] = temp.value;
                index++;
                temp = temp.next;
            }
        }

        public Node<T> AddAfter(Node<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            Node<T> new_node = new Node<T>(item);

            if (node.next != null)
            {
                new_node.next = node.next;
                new_node.prev = node;
                node.next.prev = new_node;
                node.next = new_node;

                count++;

                ItemAddedEvent?.Invoke(this, new ItemAddedEventArgs<T>(item));
            }
            else
            {
                 new_node = AddLast(item);
            }

            return new_node;
        }

        public Node<T> AddBefore(Node<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            Node<T> new_node = new Node<T>(item);

            if (node.prev != null)
            {
                new_node.next = node;
                new_node.prev = node.prev;
                node.prev.next = new_node;
                node.prev = new_node;

                count++;

                ItemAddedEvent?.Invoke(this, new ItemAddedEventArgs<T>(item));
            }
            else
            {
                new_node = AddFirst(item);
            }

            return new_node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (head == null) yield break;

            Node<T> node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Print()
        {
            Console.Write("List: ");
            Node<T> temp = head;
            while (temp != null)
            {
                Console.Write($"{temp.Value}  ");
                temp = temp.next;
            }
            Console.Write($"\n");
            Console.WriteLine($"Count: {count}");
        }
    }

    public class Node<T>
    {
        internal T value;
        internal Node<T> prev = null;
        internal Node<T> next = null;

        public Node(T item)
        {
            value = item;
        }

        public Node()
        {
            value = default(T);
        }

        internal void Invalidate()
        {
            next = null;
            prev = null;
        }

        public Node<T> Next
        {
            get { return next == null ? null : next; }
        }

        public Node<T> Previous
        {
            get { return prev == null ? null : prev; }
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
