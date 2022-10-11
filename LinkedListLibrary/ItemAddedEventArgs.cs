using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLibrary
{
    public class ItemAddedEventArgs<T>: EventArgs
    {
        public T item { get;}
        public DateTime time { get;}

        public ItemAddedEventArgs(T _item)
        {
            item = _item;
            time = DateTime.Now;
        }
    }
}
