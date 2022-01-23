using System;
using System.Collections;

namespace DataStructures
{
    public class AlStack
    {
        readonly ArrayList stack = new();

        public void Push(string element)
        {
            stack.Insert(0, element);
        }

        public string Pop()
        {
            string element = (string)stack[0];
            stack.RemoveAt(0);
            return element;
        }

        public int Size()
        {
            return stack.Count;
        }
    }

    public class AlQueue
    {
        readonly ArrayList queue = new();

        public void Append(string element)
        {
            queue.Add(element);
        }

        public string Pop()
        {
            string element = (string)queue[0];
            queue.RemoveAt(0);
            return element;
        }

        public int Size()
        {
            return queue.Count;
        }
    }
}
