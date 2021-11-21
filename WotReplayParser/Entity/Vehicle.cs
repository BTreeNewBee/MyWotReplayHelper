using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WotReplayParser.Entity
{
    class Vehicle
    {

        public int wtr { get; set; }

        public string vehicleType { get; set; }

        public int isAlive { get; set; }

        public List<string> personalMissionIDs { get; set; }


        public Hashtable personalMissionInfo { get; set; }

        public string forbidInBattleInvitations { get; set; }

        public string fakeName { get; set; }

        public int maxHealth { get; set; }

        public int igrType { get; set; }

        public string clanAbbrev { get; set; }

        public List<int> ranked { get; set; }

        public int isTeamKiller { get; set; }

        public int team { get; set; }

        public Hashtable events { get; set; }

        public int overriddenBadge { get; set; }

        public string avatarSessionID { get; set; }

        public List<List<string>> badges { get; set; }

        public string name { get; set; }
    }
}
