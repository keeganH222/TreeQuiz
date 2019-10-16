using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(5);
            Node<int>.AddToTree(root, 4);
            Node<int>.AddToTree(root, 3);
            Node<int>.AddToTree(root, 4);
            Node<int>.AddToTree(root, 7);
            Node<int>.AddToTree(root, 6);
            Node<int>.AddToTree(root, 8);
            Node<int> CalcTree = new Node<int>(26);
            Node<int>.BuildSimpleTree(CalcTree, 10, "left");
            Node<int>.BuildSimpleTree(CalcTree, 3, "right");
            Node<int>.BuildSimpleTree(CalcTree, 4, "left");
            Node<int>.BuildSimpleTree(CalcTree, 6, "right");
            Node<int>.BuildSimpleTree(CalcTree, 3, "left");
            Console.WriteLine("Sum of a BT is " + (SumOfBT(root,0) - root.data));
            PrintLevelByLevelWithQueue(CalcTree);
            IsThisACalculationTree(CalcTree);
            var check = IsThisACalculationTree(CalcTree);
            //PrintLevelByLevelWithQueue(CalcTree);
            Console.WriteLine(check);
            Console.ReadLine();
        }
        static bool IsThisACalculationTree(Node<int> root)
        {
            if(root == null || (root.left == null && root.right == null))
            {
                    return true;
            }
            //Does not work, Canno't properly get sum of a tree
            int rootsSum = SumOfBT(root, 0);
            if (root.data == (SumOfBT(root, 0) - root.data))
            {
                if(root.left != null)
                {
                    IsThisACalculationTree(root.left);
                }
                if(root.right != null)
                {
                    IsThisACalculationTree(root.right);
                }
            }
            return false;
        }
        static int SumOfBT(Node<int> root, int sum)
        {
            if (root == null)
            {
                return sum;
            }
            int sumOfBoth = 0;
            sumOfBoth += SumOfBT(root.left, root.data);
            //tree adds the root again due to stack, Don't quite know how to prevent this.
            sumOfBoth += SumOfBT(root.right, root.data);
            return sumOfBoth;
                //(SumOfBT(root.left, root.data) + SumOfBT(root.right, root.data));
        }
        static void PrintLevelByLevelWithQueue(Node<int> root)
        {
            Queue<Node<int>> que = new Queue<Node<int>>();
            Node<int> current = root;
            que.Enqueue(current);
            while (que.Count > 0)
            {
                    current = que.Dequeue();
                    if (current.left != null)
                    {
                        que.Enqueue(current.left);
                    }
                    if (current.right != null)
                    {
                        que.Enqueue(current.right);
                    }
                    Console.WriteLine(current.data);
            }
        }
    }
}
