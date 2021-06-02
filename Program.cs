using System;

namespace c_sharp_demo
{
    class ListOfInts
    {
        public int Head;
        public ListOfInts Tail;

        public ListOfInts(int value, ListOfInts tail = null)
        {
            Head = value;
            Tail = tail;
        }

        public ListOfInts Push(int value)
        {
            // Return a new list with its head equal to `value`, and its tail equal to *this* list.
            return new ListOfInts(value, this);
        }

        public ListOfInts Pop()
        {
            // Return the list minus its first element.
            return Tail;
        }

        public Tuple<int, ListOfInts> GetAndPop()
        {
            return Tuple.Create(Head, Tail);
        }

        public int Length()
        {
            if (Tail == null)
            {
                return 1;
            }
            return 1 + Tail.Length();
        }

        override public string ToString()
        {
            if (Tail == null)
            {
                return "List(" + Head.ToString() + ")";
            }
            return "List(" + Head.ToString() + ", " + Tail.ToString() + ")";
        }
    }

    class TreeOfInts
    {
        int Node;
        TreeOfInts Left;
        TreeOfInts Right;

        public TreeOfInts(int value, TreeOfInts left = null, TreeOfInts right = null)
        {
            Node = value;
            Left = left;
            Right = right;
        }

        public TreeOfInts RotateRight()
        {
            TreeOfInts newRight = new TreeOfInts(Node, Left.Right, Right);
            return new TreeOfInts(Left.Node, Left.Left, newRight);
        }

        public TreeOfInts RotateLeft()
        {
            TreeOfInts newLeft = new TreeOfInts(Node, Left, Right.Left);
            return new TreeOfInts(Right.Node, newLeft, Right.Right);
        }

        public override string ToString()
        {
            String leftStr = "(empty)";
            String rightStr = "(empty)";
            if (Left != null)
            {
                leftStr = Left.ToString();
            }
            if (Right != null)
            {
                rightStr = Right.ToString();
            }

            return String.Concat("Tree(", Node, ", ", leftStr, ", ", rightStr, ")");
        }

        public void PrettyPrint(int depth = 0)
        {
            string whitespace = new String(' ', depth * 2);
            Console.WriteLine(whitespace + Node.ToString());
            if (Left == null)
            {
                Console.WriteLine(whitespace + "  (empty left)");
            }
            else
            {
                Left.PrettyPrint(depth + 1);
            }
            if (Right == null)
            {
                Console.WriteLine(whitespace + "  (empty right)");
            }
            else
            {
                Right.PrettyPrint(depth + 1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListOfInts list = new ListOfInts(123);
            list = list.Push(567);
            list = list.Push(234);
            list = list.Push(345);
            Console.WriteLine(list.Head);
            Console.WriteLine(list.Length());
            Console.WriteLine(list);
            Console.WriteLine(list.Pop());
            Console.WriteLine("Here's our tree:");
            TreeOfInts tree = new TreeOfInts(
                10,
                new TreeOfInts(
                    5,
                    new TreeOfInts(
                        1,
                        new TreeOfInts(0),
                        new TreeOfInts(
                            3,
                            new TreeOfInts(2)
                        )
                    ),
                    new TreeOfInts(
                        8,
                        new TreeOfInts(7),
                        new TreeOfInts(9)
                    )
                )
            );
            tree.PrettyPrint();
            Console.WriteLine("And here's our tree rotated right once:");
            tree.RotateRight().PrettyPrint();
        }
    }
}
