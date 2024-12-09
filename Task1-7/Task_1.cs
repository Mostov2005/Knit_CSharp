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
        System.Console.Write("a= ");
        int firstNumber = Convert.ToInt32(System.Console.ReadLine());
        System.Console.Write("a= ");
        int secondNumber = Convert.ToInt32(System.Console.ReadLine());

        summ(firstNumber, secondNumber);
        // System.Console.WriteLine(s);

        }
    public void summ(int a, int b){
        System.Console.WriteLine(a + b);
    }

    }


