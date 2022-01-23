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
}
