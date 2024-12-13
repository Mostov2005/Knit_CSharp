using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


public class Task1_1
{
    public void Run()
    {
        char charCode = Convert.ToChar(Console.Read());   // Читает код символа (тип int)
        System.Console.WriteLine(charCode);

        double x = Math.E;
        Console.WriteLine("E={0,20}", x);
        Console.WriteLine("E={0,10}", x);
    }
}



