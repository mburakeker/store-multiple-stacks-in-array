In this task, I created ArrayOfStacks<T> with following properties:
  *   Stack<T>[] stackArray
  *   int[] tops as storing the top indexes of each stack
  *   stackCount with the expression of stackArray.Length
Adding a new stack requires resizing so Add(Stack<T> stack) method resizes stackArray and sets the highest index of stackArray to given stack input.
T this[int index] allows you to get the element at given index.
