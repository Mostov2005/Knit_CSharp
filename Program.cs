using System;

namespace MyfirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вызов метода из File1.cs
            Class1 file1 = new Class1();
            file1.Run();
            
            // Вызов метода из File2.cs
            // Class2 file2 = new Class2();
            // file2.Run();
        }
    }
}
