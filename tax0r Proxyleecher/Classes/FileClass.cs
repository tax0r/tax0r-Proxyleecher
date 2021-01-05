using System.IO;

namespace tax0r_Proxyleecher.Classes
{
    class FileClass
    {

        public string Name(int amount)
        {
            return "proxies (" + amount + ").txt";
        }

        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }

        public void Save(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

    }
}
