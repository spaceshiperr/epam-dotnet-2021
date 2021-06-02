using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsLibrary
{
    public class Stack<T> : IEnumerable<T>
    {
        public Stack()
        {
            list = new LinkedList<T>();
        }

        public Stack(T item)
        {
            list = new LinkedList<T>();
            Push(item);
        }

        public Stack(ICollection<T> collection)
        {
            list = new LinkedList<T>();
            foreach (var item in collection)
                Push(item);
        }

        public int Count
        {
            get { return list.Count; }
        }

        private LinkedList<T> list { get; set; }

        public void Clear()
        {
            list.Clear();
        }

        public void Push(T item)
        {
            list.AddLast(item);
        }

        public T Pop()
        {
            if (list.Count == 0)
                throw new InvalidOperationException(nameof(list) + ": the stack is empty!");

            var last = list.Last.Value;
            list.RemoveLast();

            return last;
        }

        public T Peek()
        {
            if (list.Count == 0)
                throw new InvalidOperationException(nameof(list) + ": the stack is empty!");

            return list.Last.Value;
        }
        
        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()  
        {  
            return GetEnumerator();  
        } 

        public T[] ToArray()
        {
            return list.ToArray();
        }
    }
}
