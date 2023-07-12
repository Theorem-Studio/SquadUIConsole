using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadManager
{
    internal class Config
    {
        public string Host="";
        public int Port;
        public string Password="";
        const string path = "config.json";
        public static Config GetConfig()
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
        }
    }
}
