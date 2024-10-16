using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace CosmosKernelSuna
{

    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        protected override void BeforeRun()
        {
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine("Welcome to Suna'S.O.S. presented by Pau Fernandez Osuna");
            Console.WriteLine("Benvingut al S.O. que estem desenvolupant en M6, chaval!");
            Console.WriteLine("Type a line of text to get it echoed back.");
            
        }

        protected override void Run()
        {
            Console.WriteLine("Selecciona una opcio:");
            Console.WriteLine("1. Apagar");
            Console.WriteLine("2. Reiniciar");
            Console.WriteLine("3. Help");
            Console.WriteLine("4. About");
            Console.WriteLine("5. Consultar espai disponible");
            Console.WriteLine("6. Consultar file system type");
            Console.WriteLine("7. Get list of files and directories");
            Console.WriteLine("8. Read all files from directory");
            Console.WriteLine("9. Create new directory");
            Console.WriteLine("10. Create new file");
            Console.WriteLine("11. Delete a file or directory");
            Console.WriteLine("12. Write to file");
            Console.WriteLine("13. Move file");
            Console.WriteLine("14. Read text from file");
            Console.WriteLine("15. Read all byes from file");

            string opcio = Console.ReadLine();
            switch (opcio)
            {
                case "1":
                    Sys.Power.Shutdown();
                    break;
                case "2":
                    Sys.Power.Reboot();
                    break;
                case "3":
                    Console.WriteLine("|Pulsa 1 per apagar el equip |\n|Pulsa 2 per reiniciar l'equip|\n|Pulsa 3 per entrar al menú HELP| ");
                    break;
                case "4":
                    Console.WriteLine("La mano arriba cintura sola la media vuelta");
                    break;
                case "5":
                    var available_space = fs.GetAvailableFreeSpace(@"0:\");
                    Console.WriteLine("Available Free Space: " + available_space);
                    break;
                case "6":
                    var fs_type = fs.GetFileSystemType(@"0:\");
                    Console.WriteLine("File System Type: " + fs_type);
                    break;
                case "7":
                    var files_list = Directory.GetFiles(@"0:\");
                    var directory_list = Directory.GetDirectories(@"0:\");
                    foreach (var file in files_list)
                    {
                        Console.WriteLine(file);
                    }
                    foreach (var directory in directory_list)
                    {
                        Console.WriteLine(directory);
                    }
                    break;
                case "8":
                    var directory_list_Read_files = Directory.GetFiles(@"0:\");
                    try
                    {
                        foreach (var file in directory_list_Read_files)
                        {
                            var content = File.ReadAllText(file);

                            Console.WriteLine("File name: " + file);
                            Console.WriteLine("File size: " + content.Length);
                            Console.WriteLine("Content: " + content);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case "9":
                    try
                    {
                        Directory.CreateDirectory(@"0:\testdirectory\");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case "10":
                    try
                    {
                        var file_stream = File.Create(@"0:\testing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case "11":
                    try
                    {
                        File.Delete(@"0:\testing.txt");
                        Directory.Delete(@"0:\testdirectory\");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case "12":
                    try
                    {
                        File.WriteAllText(@"0:\testing.txt", "Learning how to use VFS!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case "13":
                    //static void MoveFile(string file, string newpath)
                    //{
                    //    try
                    //    {
                    //        File.Copy(file, newpath);
                    //        File.Delete(file);
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(ex);
                    //    }
                    //}
                    //MoveFile()
                    break;
                case "14":
                    try
                    {
                        Console.WriteLine(File.ReadAllText(@"0:\testing.txt"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case "15":
                    try
                    {
                        Console.WriteLine(File.ReadAllBytes(@"0:\testing.txt"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;

            }
            
        }
    }
}
