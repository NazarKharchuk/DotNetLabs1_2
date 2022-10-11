using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLibrary
{
    public class ItemRemovedEventArgs<T> : EventArgs
    {
        public T item { get; }
        public DateTime time { get; }

        public ItemRemovedEventArgs(T _item)
        {
            item = _item;
            time = DateTime.Now;
        }
    }
}
