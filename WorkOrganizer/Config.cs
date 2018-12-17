using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using WorkOrganizer.Data;

namespace WorkOrganizer
{
    public static class Config
    {
        private const string Path = ".\\Config.txt";

        public static void Load()
        {
            string[] config = File.ReadAllLines(Path);
            JobType.SetData(config);
        }
    }
}
