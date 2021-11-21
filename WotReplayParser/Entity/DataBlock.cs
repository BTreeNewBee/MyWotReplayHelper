using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WotReplayParser.Entity
{
    class DataBlock
    {
        public string playerVehicle { get; set; }

        public string clientVersionFromXml { get; set; }

        public Dictionary<string, Vehicle> vehicles { get; set; }

        public string clientVersionFromExe { get; set; }

        public string regionCode { get; set; }

        public int playerID { get; set; }

        public string serverName { get; set; }

        public string mapDisplayName { get; set; }

        public ServerSettings serverSettings { get; set; }

        public string dateTime { get; set; }

        public string mapName { get; set; }

        public string gameplayID { get; set; }

        public int battleType { get; set; }

        public string hasMods { get; set; }

        public string playerName { get; set; }
    }
}
