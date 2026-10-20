using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // Reads files O.o
    public class FileReader
    {
        private string path;
        public FileReader(string path)
        {
            this.path = Path.Combine(AppContext.BaseDirectory + path);
            bool PathExists = File.Exists(this.path);
            if (!PathExists)
            {
                throw new FileNotFoundException(this.path);
            }
        }
        public string[] ReadAllLines()
        {
            return File.ReadAllLines(path);
        }
    }
}
