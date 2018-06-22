using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppDesktopDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString();

            Console.WriteLine("Running");
            string[] directories = Directory.GetDirectories(path + "/Local/Whatsapp");
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            for (int i = 0; i < directories.Length; i++)
            {
                string directory = directories[i];
                if(directory.Contains("app-"))
                {
                    string versionnumber = directory.Split('-')[1];
                    string[] numbers = versionnumber.Split('.');
                    for(int j = 0; j < numbers.Length; j++)
                    {
                        if (j == 0 && v1 < int.Parse(numbers[j]))
                        {
                            v1 = int.Parse(numbers[j]);
                        }
                        else if (j == 1 && v2 < int.Parse(numbers[j]))
                        {
                            v2 = int.Parse(numbers[j]);
                        }
                        else if (j == 2 && v3 < int.Parse(numbers[j]))
                        {
                            v3 = int.Parse(numbers[j]);
                        }
                    }
                }
            }

            for(int i = 0; i < directories.Length; i++)
            {
                if (!directories[i].Contains("app-" + v1 + "." + v2 + "." + v3) && !directories[i].Contains("packages"))
                {
                    Directory.Delete(directories[i]);
                }
            }
        }
    }
}
