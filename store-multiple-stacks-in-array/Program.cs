using System;
using System.Collections.Generic;

namespace store_multiple_stacks_in_array
{
    class Program
    {
        private static Random rng;
        static void Main(string[] args)
        {
            rng = new Random();
            var arrayOfStacks = new ArrayOfStacks<SampleModel>();
            var stack = new Stack<SampleModel>();
            for (int i = 0; i < 15; i++)
            {
                var sampleModel = new SampleModel(Guid.NewGuid());
                if (i == 13)
                {
                    Console.WriteLine($"13th element of first stack is Id: {sampleModel.Id}");
                }
                stack.Push(sampleModel);
            }
            arrayOfStacks.Add(stack);
            stack = new Stack<SampleModel>();
            for (int i = 0; i < 22; i++)
            {
                var sampleModel = new SampleModel(Guid.NewGuid());
                if (i == 17)
                {
                    Console.WriteLine($"32nd element of second stack is  Id: {sampleModel.Id}");
                }
                stack.Push(sampleModel);
            }
            arrayOfStacks.Add(stack);
            stack = new Stack<SampleModel>();
            for (int i = 0; i < 13; i++)
            {
                var sampleModel = new SampleModel(Guid.NewGuid());
                if (i == 6)
                {
                    Console.WriteLine($"42th element of third stack is  Id: {sampleModel.Id}");
                }
                stack.Push(sampleModel);
            }
            arrayOfStacks.Add(stack);
            Console.WriteLine("Fetching 13th, 32nd and 45th elements from arrayOfStacks");
            Console.WriteLine(arrayOfStacks[13].Id);
            Console.WriteLine(arrayOfStacks[32].Id);
            Console.WriteLine(arrayOfStacks[42].Id);
        }
        public class SampleModel
        {
            public SampleModel(Guid id)
            {
                Id = id;
            }
            public Guid Id { get; set; }
        }
    }
}
