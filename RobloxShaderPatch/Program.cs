using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RobloxShaderPatch
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string FilePath = "";
            string ClientVersion = "";

            Console.Title = "Roblox Shader Patch";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.WriteLine("-    Roblox Shader Patch   -");
            Console.WriteLine("----------------------------");
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This program is meant to work on MaximumADHD's early 2007 client and mid 2007 client.");
            Console.WriteLine("\n");
            Console.WriteLine("Please select the Roblox executable file. (press a key for the file dialog)");
            Console.ReadKey(true);

            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select the Roblox Executable";
                dialog.Filter = "Roblox Main Executable|Roblox.exe";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Checking client version...");
            
            if (GetFileHash(FilePath).ToLower() == hashes.E2007.Unpatched || GetFileHash(FilePath).ToLower() == hashes.E2007.Patched)
            {
                Console.WriteLine("Early 2007 client detected.");
                ClientVersion = "e";
            } else if (GetFileHash(FilePath).ToLower() == hashes.M2007.Unpatched || GetFileHash(FilePath).ToLower() == hashes.M2007.Patched)
            {
                Console.WriteLine("Mid 2007 client detected.");
                ClientVersion = "m";
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n");
                Console.WriteLine("Unknown client version!");
                Console.ReadKey(true);
                Environment.Exit(0);
            }


                Console.WriteLine("\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) Patch");
            Console.WriteLine("2) Unpatch");

            var choice = Console.ReadKey(true).KeyChar.ToString();

            Console.WriteLine("\n");
            if (choice == "1")
            {
                Console.WriteLine("Starting patch...");
                Console.WriteLine("\n");

                if (ClientVersion == "e")
                {
                    Console.WriteLine("Patching depth of field...");
                    patcher.WriteHexAtOffset(FilePath, offsets.E2007.DOF, "01");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Patching bloom...");
                    patcher.WriteHexAtOffset(FilePath, offsets.E2007.BLOOM, "01");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Successfully patched Roblox for shaders!");
                } else if (ClientVersion == "m")
                {
                    Console.WriteLine("Patching depth of field...");
                    patcher.WriteHexAtOffset(FilePath, offsets.M2007.DOF, "01");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Patching bloom...");
                    patcher.WriteHexAtOffset(FilePath, offsets.M2007.BLOOM, "01");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Successfully patched Roblox for shaders!");

                }
            } else if (choice == "2")
            {
                Console.WriteLine("Starting unpatch...");
                Console.WriteLine("\n");

                if (ClientVersion == "e")
                {
                    Console.WriteLine("Unpatching depth of field...");
                    patcher.WriteHexAtOffset(FilePath, offsets.E2007.DOF, "00");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Unpatching bloom...");
                    patcher.WriteHexAtOffset(FilePath, offsets.E2007.BLOOM, "00");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Successfully unpatched Roblox!");
                }
                else if (ClientVersion == "m")
                {
                    Console.WriteLine("Patching depth of field...");
                    patcher.WriteHexAtOffset(FilePath, offsets.M2007.DOF, "00");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Patching bloom...");
                    patcher.WriteHexAtOffset(FilePath, offsets.M2007.BLOOM, "00");
                    Console.WriteLine("Done!");

                    Console.WriteLine("\n");

                    Console.WriteLine("Successfully unpatched Roblox!");

                }
            }
        }
        static string GetFileHash(string path)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = File.OpenRead(path))
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return Convert.ToHexString(hashBytes); // .NET 5+
            }
        }
    }
}