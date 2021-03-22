using System;
using System.Management;

namespace Hotfix_KB5000802_Remover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building KB table:....");
            const string query = "SELECT HotFixID FROM Win32_QuickFixEngineering";
            var search = new ManagementObjectSearcher(query);
            var collection = search.Get();

            foreach (ManagementObject quickFix in collection)
            {
                Console.WriteLine(quickFix["HotFixID"].ToString());
                if (quickFix["HotFixID"].ToString() == "KB5000802")
                {
                    Console.WriteLine("Found it! Initializing removal procedure...");
                    string strCmdUninstall;
                    strCmdUninstall = "/C wusa.exe /uninstall /kb:5000802";
                    System.Diagnostics.Process.Start("CMD.exe", strCmdUninstall);
                } 
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("KB5000802 not found.... Live long and prosper!");
        }
    }
}
