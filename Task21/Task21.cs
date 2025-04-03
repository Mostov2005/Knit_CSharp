using System;
using System.IO;


namespace Knit_CSharp
{
    class Task21
    {
        public void Run()
        {
            String inputFile1 = "C:\\Users\\Mostov\\Knit_CSharp\\Task21\\input1.txt";
            String inputFile2 = "C:\\Users\\Mostov\\Knit_CSharp\\Task21\\input2.txt";
            String inputFile3 = "C:\\Users\\Mostov\\Knit_CSharp\\Task21\\input3.txt";

            string inputData = File.ReadAllText(inputFile3);
            string[] numbers = inputData.Split(new[] { ';', '.', ' ', '_', ',', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            System.Console.WriteLine(string.Join(", ", numbers));

            BinaryTree tree = new BinaryTree();

            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int value))
                    tree.Add(value);
            }

            tree.Preorder();
            System.Console.WriteLine();
            tree.Postorder();
            System.Console.WriteLine();
            tree.Inorder();
            System.Console.WriteLine();

            System.Console.WriteLine(tree.CountNodesWithOneChild());
        }
    }
}