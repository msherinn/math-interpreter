using System;
using System.Collections;
using System.Linq;

namespace DataStructures
{
    //create stack
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

    //create queue
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

    class Program
    {
        //getting token from the string
        public (string, int) GetToken(string arg)
        {
            int i = 0;
            string number = null;
            string token = null;
            while(i < arg.Length)
            {
                if(Char.IsWhiteSpace(arg[i]) == true)
                {
                    i++;
                }
                else if(Char.IsDigit(arg[i]) == true)
                {
                    number += arg[i];
                    i++;
                }

                else
                {
                    if (number == null)
                    {
                        token += arg[i];
                        return (token, i++);
                    }

                    else
                    {
                        return (number, i);
                    }
                }
            }

            return (number, i);
            
        }

        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
        }
    }
}