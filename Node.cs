using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeQuiz
{
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }
        public Node(T data)
        {
            this.data = data;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        public static Node<int> BuildSimpleTree(Node<int> root, int newData, string branch)
        {
            if (root == null)
            {
                Node<int> newNode = new Node<int>(newData);
                return newNode;
            }
            if (branch.ToLower() == "left")
            {
                root.left = BuildSimpleTree(root.left, newData, branch);
            }
            else
            {
                root.right = BuildSimpleTree(root.right, newData, branch);
            }
            return root;
        }
        public static Node<int> AddToTree(Node<int> root, int newData)
        {
            if (root == null)
            {
                Node<int> newNode = new Node<int>(newData);
                return newNode;
            }
            else if (newData < root.data)
            {
                root.left = AddToTree(root.left, newData);
            }
            else if (newData >= root.data)
            {
                root.right = AddToTree(root.right, newData);
            }
            return root;
        }
    }
}
