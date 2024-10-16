using Cosmos.HAL;
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
            Console.WriteLine("Welcome to Suna'S.O.S. presented by Pau Fernandez Osuna");
            Console.WriteLine("Benvingut al S.O. que estem desenvolupant en M6, chaval!");
            Console.WriteLine("Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            Console.WriteLine("Selecciona una opcio:");
            Console.WriteLine("1. Apagar");
            Console.WriteLine("2. Reiniciar");

            string opcio = Console.ReadLine();
            switch (opcio)
            {
                case "1":
                    Sys.Power.Shutdown();
                    break;
                case "2":
                    Sys.Power.Reboot();
                    break;
            }
            
        }
    }
}
