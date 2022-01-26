using System;
using System.Collections;
using System.Collections.Generic;

namespace ShuntingYard
{
    //create stack
    public class AlStack
    {
        public readonly ArrayList stack = new();

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

        public void Clear()
        {
            stack.Clear();
        }
    }

    //create queue
    public class AlQueue
    {
        public readonly ArrayList queue = new();

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
        //removing whitespaces
        static string RemoveWhiteSpaces(string arg)
        {
            int i = 0;
            string expressionStripped = "";
            while (i < arg.Length)
            {
                expressionStripped += Char.IsWhiteSpace(arg[i]) != true ? arg[i] : "";
                i++;
            }

            return expressionStripped;
        }

        //getting token from the string
        static (string, int) GetToken(string arg)
        {
            int i = 0;
            string number = "";
            string token = "";
            while (i < arg.Length)
            {
                if (Char.IsDigit(arg[i]) == true)
                {
                    number += arg[i];
                    i++;
                }

                else
                {
                    if (number == "")
                    {
                        token += arg[i];
                        return (token, i++);
                    }

                    else
                    {
                        return (number, i++);
                    }
                }
            }

            return (number, i++);
            
        }

        static void Main(string[] args)
        {
            var OPERATOR_PRECEDENCE = new Dictionary<string, int>()
            {
                {"(", 2},
                {")", 2},
                {"+", 2},
                {"-", 2},
                {"*", 3},
                {"/", 3},
                {"^", 4}
            };

            AlStack rpnStack = new();
            AlQueue rpnOutput = new();

            string expression = Console.ReadLine();
            expression = RemoveWhiteSpaces(expression);

            int i = 0;
            while (i < expression.Length)
            {
               (var token, var j) = GetToken(expression.Substring(i));
                i = i + j;
                long number = 0;

                if (long.TryParse(token, out number))
                {
                    rpnOutput.Append(token);
                }

                else
                {
                    if (rpnStack.Size() == 0)
                    {
                        rpnStack.Push(token);
                    }

                    else if (token == ")")
                    {
                        while (rpnStack.stack[0] != "(")
                        {
                            rpnOutput.Append(rpnStack.Pop());
                        }
                        rpnStack.Pop();
                    }

                    else if (token == "(" || OPERATOR_PRECEDENCE[token] == 2)
                    {
                        rpnStack.Push(token);
                    }

                    else if (OPERATOR_PRECEDENCE[token] > OPERATOR_PRECEDENCE[rpnStack.stack[0]])
                    {
                        rpnStack.Push(token);
                    }

                    else if (OPERATOR_PRECEDENCE[token] == 4 && OPERATOR_PRECEDENCE[rpnStack.stack[0]] == 4)
                    {
                        rpnStack.Push(token);
                    }

                    else if (OPERATOR_PRECEDENCE[token] == OPERATOR_PRECEDENCE[rpnStack.stack[0]])
                    {
                        rpnOutput.Append(rpnStack.Pop());
                        rpnStack.Push(token);
                    }
                    
                }

            }

            while (rpnStack.Size() > 0)
            {
                rpnOutput.Append(rpnStack.Pop());
            }
            
            Console.WriteLine(rpnOutput);

            rpnStack.Clear();

            while (rpnOutput.Size() > 0)
            {
                long number = 0;
                string token = rpnOutput.Pop();
                if (long.TryParse(token, out number))
                {
                    rpnStack.Push(token);
                }

                else
                {
                    int b = rpnStack.Pop();
                    int a = rpnStack.Pop();
                    int result = 0;

                    if (token == "+")
                    {
                        result = a + b;
                    }

                    else if (token == "-")
                    {
                        result = a - b;
                    }

                    else if (token == "*")
                    {
                        result = a * b;
                    }

                    else if (token == "/") 
                    {
                        result = a / b;
                    }

                    else if (token == "^")
                    {
                        result = a ** b;
                    }

                    rpnStack.Push(result);
                }
            }

            int result = rpnStack.Pop();
            Console.WriteLine(result)
        }
    }
}