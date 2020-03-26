using System;
using System.IO;
using System.Text;

namespace Problem3
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Left = this.Right = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(20);
            root.Left = new Node(8);
            root.Right = new Node(22);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(12);
            root.Left.Right.Left = new Node(10);
            root.Left.Right.Right = new Node(14);

            InOrder(root);

            Console.WriteLine();

            PreOrder(root);

            Console.WriteLine();

            StringBuilder sb = new StringBuilder();
            Serialize(root, sb);
            File.WriteAllText(@"tree.txt", sb.ToString());
            Console.WriteLine($"Serialized tree: {sb.ToString()}");


            string treeSer = File.ReadAllText(@"tree.txt");
            Console.WriteLine($"Read tree: {treeSer}");
            string[] readNodes = treeSer.Trim().Split(new char[] { ' ' });


            int[] nodes = Array.ConvertAll(readNodes, n => int.Parse(n));
            int start = 0;
            Node rootDes = DeSerialize(nodes, ref start, nodes.Length);
            InOrder(rootDes);
        }

        // This function constructs a tree from a file pointed by 'fp' 
        private static Node DeSerialize(int[] nodes, ref int start, int end)
        {
            if (nodes == null || nodes.Length == 0)
            {
                return null;
            }

            // Read next item from file. If theere are no more items or next 
            // item is marker, then return 
            int val = nodes[start];

            if (val == -1)
                return null;

            // Else create node with this item and recur for children 
            Node node = new Node(val);
            start++;
            node.Left = DeSerialize(nodes, ref start, end);
            start++;
            node.Right = DeSerialize(nodes, ref start, end);

            return node;
        }

        static void Serialize(Node root, StringBuilder sb)
        {
            // If current node is NULL, store marker 
            if (root == null)
            {
                sb.Append($"-1 ");
                return;
            }

           
            // PreOrder Binary Search Tree.
            // Else, store current node and recur for its children 
            sb.Append($"{root.Data} ");
            Serialize(root.Left, sb);
            Serialize(root.Right, sb);
        }

        static void InOrder(Node root)
        {
            if(root!= null)
            {
                InOrder(root.Left);
                Console.Write($"{root.Data} ");
                InOrder(root.Right);
            }
        }

        static void PreOrder(Node root)
        {
            if(root != null)
            {
                Console.Write($"{root.Data} ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }
    }
}
