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
                    Console.WriteLine("Mover las funciones modularmente en el switch");
                    break;
                case "5":
                    consultaespaidisp();
                    break;
                case "6":
                    consultafilesistemtype();
                    break;
                case "7":
                    filesdirectorylist();
                    break;
                case "8":
                    Console.WriteLine("Nom del directori a llegir: ");
                    string directoriallegir = Console.ReadLine();
                    allfilesfromdirectory(directoriallegir);
                    break;
                case "9":
                    Console.WriteLine("Introdueix el nom del directori a crear: ");
                    string newdirectory = Console.ReadLine();
                    createdirectory(newdirectory);
                    break;
                case "10":
                    Console.WriteLine("Introdueix el nom del arxiu a crear: ");
                    string newfile = Console.ReadLine();
                    createfile(newfile);
                    break;
                case "11":
                    Console.WriteLine("Introdueix el nom del arxiu/directori a eliminar: ");
                    string elimina = Console.ReadLine();
                    deletefileordirectory(elimina);
                    break;
                case "12":
                    Console.WriteLine("Introdueix el nom del arxiu a escriure: ");
                    string arxiuallegir = Console.ReadLine();
                    string missatge = Console.ReadLine();
                    writetofile(arxiuallegir,missatge);
                    break;
                case "13":
                    Console.WriteLine("Introdueix el nom del fitxer a moure: ");
                    string filetomove = Console.ReadLine();
                    Console.WriteLine("Introdueix el nou path on guardar l'arxiu: ");
                    string newfilepath = Console.ReadLine();
                    MoveFile(filetomove,newfilepath);
                    break;
                case "14":
                    Console.WriteLine("Nom del arxiu a llegir: ");
                    string arxiullegir = Console.ReadLine();
                    readtextfromfile(arxiullegir);
                    break;
                case "15":
                    Console.WriteLine("Nom del arxiu a llegir tots els bits: ");
                    string arxiullegirbites = Console.ReadLine();
                    readallfromtextfile(arxiullegirbites);
                    break;

            }
            //Crap starts here Kappachungus
            void consultaespaidisp()
            {
                var available_space = fs.GetAvailableFreeSpace(@"0:\");
                Console.WriteLine("Available Free Space: " + available_space);
            }
            void consultafilesistemtype()
            {
                var fs_type = fs.GetFileSystemType(@"0:\");
                Console.WriteLine("File System Type: " + fs_type);
            }
            void filesdirectorylist()
            {
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
            }
            void allfilesfromdirectory(string directoriallegir)
            {
                var directory_list_Read_files = Directory.GetFiles(@"0:\"+directoriallegir);
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
            }
            void createdirectory(string newdirectory)
            {
                try
                {
                    Directory.CreateDirectory(@"0:\"+newdirectory);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            void createfile(string newfile)
            {
                newfile = newfile + ".txt";
                try
                {
                    var file_stream = File.Create(@"0:\"+newfile);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            void deletefileordirectory(string elimina)
            {
                elimina = elimina + ".txt";
                try
                {
                    File.Delete(@"0:\"+elimina);
                    Directory.Delete(@"0:\"+elimina);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            void writetofile(string arxiuallegir,string missatge)
            {
                arxiuallegir = arxiuallegir + ".txt";
                try
                {
                    File.WriteAllText(@"0:\"+arxiuallegir, missatge);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            static void MoveFile(string file, string newpath)
            {
                try
                {
                    File.Copy(file, newpath);
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            void readtextfromfile(string arxiullegir)
            {
                arxiullegir = arxiullegir + ".txt";
                try
                {
                    Console.WriteLine(File.ReadAllText(@"0:\" + arxiullegir));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            void readallfromtextfile(string arxiullegirbites) {
                arxiullegirbites = arxiullegirbites + ".txt";
                try
                {
                    Console.WriteLine(File.ReadAllBytes(@"0:\"+arxiullegirbites));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
