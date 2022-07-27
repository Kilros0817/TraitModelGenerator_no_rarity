using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace JsonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"F:\freelancer\clients\Vulcan\KawaiiClub\traits";
            string[] direcotryL = Directory.GetDirectories(root);

            string outfile = "out.txt";

            foreach (string traitD in direcotryL)
            {
                string traitName = new DirectoryInfo(traitD).Name;
                string[] dirL = Directory.GetDirectories(traitD);
                List<string> imageDataL = new List<string>();
                string[] fileL = Directory.GetFiles(traitD);
                foreach (string file in fileL)
                {
                    imageDataL.Add(Path.GetFileNameWithoutExtension(file));
                }

                string output = JsonConvert.SerializeObject(imageDataL, Formatting.Indented);
                File.AppendAllText(outfile, $"{traitName}_data = {output}\n\n");
            }
        }
    }
}
