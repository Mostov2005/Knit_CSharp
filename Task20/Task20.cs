using System;
using System.IO;


namespace Knit_CSharp
{
    class Task20
    {
        public void Run()
        {
            String inputFile = "C:\\Users\\Mostov\\Knit_CSharp\\Task20\\input20_2.txt";
            String outputFile = "C:\\Users\\Mostov\\Knit_CSharp\\Task20\\output20.txt";

            SinglyLinkedList list = new SinglyLinkedList();


            string inputData = File.ReadAllText(inputFile);
            string[] numbers = inputData.Split(new[] { ';', '.', ' ', '_', ',', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int value))
                    list.AddToTail(value);
            }
            // list.PrintList();

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                Console.SetOut(writer);
                list.PrintList();
                list.RemoveDuplicates();
                list.PrintList();
            }
        }
    }
}