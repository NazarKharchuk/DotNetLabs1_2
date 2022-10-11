using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLibrary
{
    public class ListClearedEventArgs<T> : EventArgs
    {
        public DateTime time { get; }

        public ListClearedEventArgs()
        {
            time = DateTime.Now;
        }
    }
}
