using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace MaSzyna_Unofficial_Content_Manager
{
    public class ConfigManager
    {
        FileIniDataParser parser;
        public IniData data;
        string configFileName;
        public ConfigManager(string filename)
        {
            parser = new FileIniDataParser();
            configFileName = filename;
            this.data = parser.ReadFile(filename);
        }

        public void saveChanges() 
        {
            parser.WriteFile(configFileName, data);
        }

    }
}
