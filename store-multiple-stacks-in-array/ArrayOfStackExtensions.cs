using System;
using System.Collections.Generic;
using System.Text;

namespace store_multiple_stacks_in_array
{
    public static class ArrayOfStackExtensions
    {
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        public static int FindIndex<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            int index = 0;
            foreach (var item in items)
            {
                if (predicate(item)) break;
                index++;
            }
            return index;
        }
        public static Stack<T> SetElement<T>(this Stack<T> stack, T newItem, int index)
        {

            var temp = new Stack<T>();
            var newIndex = stack.Count - index;
            while (stack.Count > newIndex)
            {
                temp.Push(stack.Pop());
            }
            stack.Pop();
            temp.Push(newItem);

            while (temp.Count > 0)
                stack.Push(temp.Pop());
            return stack;
        }
    }
}
