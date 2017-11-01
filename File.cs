using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Files
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> allFiles = new List<string>();
            for (int i = 0; i < n; i++)
            {
                allFiles.Add(Console.ReadLine());
            }

            string filter = Console.ReadLine();
            var filterParts = filter.Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
            var filterExt = "."+filterParts[0];
            var filterRoot = filterParts[1]+@"\";

            Dictionary<string, long> fileSize = new Dictionary<string, long>();
            foreach (var f in allFiles)
            {
                var filePlusSize = f.Split(';');
                var size = long.Parse(filePlusSize[1]);
                var path = filePlusSize[0];

                if (path.StartsWith(filterRoot) && path.EndsWith(filterExt))
                {
                    var tokens = path.Split('\\');
                    var fileName = tokens.Last();
                    fileSize[fileName] = size;
                }
            }
            bool isEmpty = (fileSize.Count == 0);
            if (isEmpty)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var item in fileSize.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value} KB");
                }
            }
        }
    }
}
