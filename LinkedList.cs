using System;

namespace CodePuzzle
{
    // Write an application that would return a user definable element from the tail (or end) of a singly linked list of integers
    // 
    // For example, given the list 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10 -> 11
    // your application would return 8 if the user wants to see the 5th element

    class LinkedListNode
    {
        public int Value;
        public LinkedListNode Next;
        public LinkedListNode(int value)
        {
            Value = value;
            Next = null;
        }
    }

    internal class LinkedList : iCodePuzzle
    {
        public void run()
        {
            LinkedListNode linkedListHead = GenerateRandomList(10);

            Console.WriteLine("Generated Linked List: ");
            PrintLinkedList(linkedListHead);
            Console.WriteLine();

            Console.WriteLine("From the tail, which element number do you wish to see?");
            try
            {
                int numberInput = Convert.ToInt32(Console.ReadLine());
                int nthElementFromTail = getElementFromTail(numberInput, linkedListHead);

                Console.WriteLine($"Element {numberInput} from behind is: {nthElementFromTail}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid element number from tail - must be a number");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Invalid element number from tail - input number too large");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintLinkedList(LinkedListNode head)
        {
            LinkedListNode linkedListCurrent = head;

            while (linkedListCurrent.Next != null)
            {
                string format = ", ";
                if (linkedListCurrent.Next.Next == null)
                {
                    format = "\n";
                }
                Console.Write(linkedListCurrent.Value + format);
                linkedListCurrent = linkedListCurrent.Next;
            }
        }

        private LinkedListNode GenerateRandomList(int length)
        {
            Random random = new Random();

            LinkedListNode head = null;
            LinkedListNode current = null;

            for (int i = 0; i <= length; i++)
            {
                LinkedListNode next = new LinkedListNode(random.Next(int.MinValue, int.MaxValue));
                if (current == null)
                {
                    head = next;
                }
                else
                {
                    current.Next = next;
                }
                current = next;
            }

            return head;
        }

        private int getElementFromTail(int nthElementFromTail, LinkedListNode head)
        {
            // Return node element value where
            // The node element is the nth element behind the last node 

            LinkedListNode current = head;
            LinkedListNode lookAhead = head;

            if (nthElementFromTail <= 0)
            {
                throw new Exception("Invalid element number from tail - must be more than 0");
            }

            for (int i = 0; i < nthElementFromTail; i++)
            {
                if (lookAhead.Next == null)
                {
                    throw new Exception("Invalid element number from tail - exceeded maximum element number available");
                }

                lookAhead = lookAhead.Next;
            }

            while (lookAhead.Next != null)
            {
                current = current.Next;
                lookAhead = lookAhead.Next;
            }

            return current.Value;
        }
        
    }
}
