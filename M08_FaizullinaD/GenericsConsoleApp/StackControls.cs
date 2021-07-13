using System;

namespace GenericsConsoleApp
{
    public class StackControls
    {
        private static GenericsLibrary.Stack<object> stack;

        public static void RunStack()
        {
            PrintStackCommands();
            do
            {
                try
                {
                    Console.Write("Enter the command: ");
                    var command = Console.ReadLine();

                    if (command == "0")
                        break;
                    else if (command == "1")
                        CreateEmptyStack();
                    else if (command == "2")
                        CreateOneItemStack();
                    else if (command == "3")
                        CreateStackFromCollection();
                    else if (command == "4")
                        StackPush();
                    else if (command == "5")
                        StackPop();
                    else if (command == "6")
                        StackPeek();
                    else if (command == "7")
                        StackCount();
                    else if (command == "8")
                        StackContains();
                    else if (command == "9")
                        StackPrint();
                    else if (command == "10")
                        StackClear();
                    else
                    {
                        Console.WriteLine("Wrong command number, try again!");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            while (true);
        }

        private static void PrintStackCommands()
        {
            Console.WriteLine("Enter the operation:");
            Console.WriteLine("1. Create an empty stack");
            Console.WriteLine("2. Create a stack with one item");
            Console.WriteLine("3. Create a stack from a collection of items");
            Console.WriteLine("4. Push item");
            Console.WriteLine("5. Pop item");
            Console.WriteLine("6. Peek item");
            Console.WriteLine("7. Get item count");
            Console.WriteLine("8. Check if stack contains item");
            Console.WriteLine("9. Print stack items");
            Console.WriteLine("10. Clear the stack");
            Console.WriteLine("0. Exit");
        }

        private static void CreateEmptyStack()
        {
            stack = new GenericsLibrary.Stack<object>();
            Console.WriteLine("Empty stack successfully created");
        }

        private static void CreateOneItemStack()
        {
            Console.WriteLine("Enter the item:");
            var item = Console.ReadLine();

            stack = new GenericsLibrary.Stack<object>(item);
            Console.WriteLine("One item stack successfully created");
        }

        private static void CreateStackFromCollection()
        {
            Console.WriteLine("Enter a collection of items separated by spaces");
            var items = Console.ReadLine().Split();

            stack = new GenericsLibrary.Stack<object>(items);
            Console.WriteLine("Stack from collection successfully created");
        }

        private static void StackPush()
        {
            CheckStackIsNull();

            Console.WriteLine("Enter the item:");
            var item = Console.ReadLine();

            stack.Push(item);
            Console.WriteLine("Item successfully pushed");
        }

        private static void StackPop()
        {
            CheckStackIsNullOrEmpty();

            var last = stack.Pop();
            Console.WriteLine("The last item was " + last);
        }

        private static void StackPeek()
        {
            CheckStackIsNullOrEmpty();

            var last = stack.Peek();
            Console.WriteLine("The last item is " + last);
        }

        private static void StackCount()
        {
            CheckStackIsNull();

            var count = stack.Count;

            Console.WriteLine("The stack couunt is " + count);
        }
        
        private static void StackContains()
        {
            CheckStackIsNull();

            Console.WriteLine("Enter the item you're searching for:");
            var item = Console.ReadLine();

            var hasItem = stack.Contains(item);

            if (hasItem)
                Console.WriteLine("The stack does contain this item");
            else
                Console.WriteLine("The stack does not contain this item");
        }

        private static void StackPrint()
        {
            CheckStackIsNullOrEmpty();

            var array = stack.ToArray();
            Console.Write("Current items: ");
            FibonacciNumbersControls.PrintArray(array);
        }

        private static void StackClear()
        {
            if (stack is null)
                stack = new GenericsLibrary.Stack<object>();
            else
                stack.Clear();
            Console.WriteLine("The stack has been successfully cleared");
        }

        private static void CheckStackIsNull()
        {
            if (stack is null)
                throw new InvalidOperationException("Invalid operation, the stack hasn't been created yet");
        }

        private static void CheckStackIsNullOrEmpty()
        {
            if (stack is null || stack.Count == 0)
                throw new InvalidOperationException("Invalid operation, the stack is empty or not created yet!");

        }
    }
}