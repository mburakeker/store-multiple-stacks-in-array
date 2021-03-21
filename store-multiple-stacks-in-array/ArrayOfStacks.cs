using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace store_multiple_stacks_in_array
{
    class ArrayOfStacks<T>
    {
        private Stack<T>[] stackArray;
        private int[] tops;
        private int stackCount => stackArray.Length;
        public ArrayOfStacks()
        {
            stackArray = new Stack<T>[0];
            tops = new int[0];
        }
        public void Push(T item)
        {
            stackArray[stackCount].Push(item);
            tops[stackCount]++;
        }
        public void Push(T item,int stackIndex)
        {
            stackArray[stackIndex].Push(item);
            tops[stackIndex]++;
            if (stackIndex < stackCount-1)
            {
                tops[stackCount]++; 
            }
        }
        public T Pop()
        {
            T value = stackArray[stackCount].Pop();
            if(stackArray[stackCount].Count == 0)
            {
                stackArray = stackArray.RemoveAt(stackCount);
                tops.RemoveAt(stackCount);
            }
            tops[stackCount]--;
            return value;
        }
        public T Pop(int stackIndex)
        {
            T value = stackArray[stackIndex].Pop();
            if (stackArray[stackIndex].Count == 0)
            {
                stackArray = stackArray.RemoveAt(stackIndex);
                tops.RemoveAt(stackIndex);
            }
            tops[stackIndex]--;
            if (stackIndex < stackCount - 1)
            {
                tops[stackIndex+1]--;
            }
            return value;
        }
        public T Peek()
        {
            return stackArray[stackCount].Peek();
        }
        public T Peek(int stackIndex)
        {
            return stackArray[stackIndex].Peek();
        }
        public void Add(Stack<T> stack)
        {
            Array.Resize(ref stackArray, stackArray.Length + 1);
            stackArray[stackArray.Length - 1] = stack;
            int top = stack.Count;
            int stackArrayCount = stackCount;
            Array.Resize(ref tops, tops.Length + 1);
            if (stackArrayCount > 1)
            {
                tops[tops.Length- 1] = tops[tops.Length - 2] + top;
            }
            else
            {
                tops[tops.Length - 1] = top;
            }
        }
        public T this[int index]
        {
            get
            {
                int _stackCount = stackCount;
                if (_stackCount == 0)
                {
                    throw new NullReferenceException("No stack found");
                }

                int stackIndex = 0;
                for (int i = 0; i< _stackCount; i++)
                {
                    if (index > tops[i])
                        stackIndex = i+1;
                }

                return stackArray[stackIndex].ElementAt(tops[stackIndex] - index - 1);
            }
        }
    }
    
}
