using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernelSuna
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Welcome to Suna's Cosmos S.O. presented by Pau Fernandez Osuna");
            Console.WriteLine("Benvingut al S.O. que estem desenvolupant en M6, chaval!");
            Console.WriteLine("Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
