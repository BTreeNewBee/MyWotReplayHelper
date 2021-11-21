using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WotReplayParser.Entity
{
    class ServerSettings
    {
        public Hashtable battle_royale_config { get; set; }

        //public List<String> roaming { get; set; }

        public SpgRedesignFeatures spgRedesignFeatures { get; set; }
        public string isPotapovQuestEnabled { get; set; }

        public Hashtable ranked_config { get; set; }
    }


    public class ArenaObject
    {

        public int maxTeamsInArena { get; set; }

        public List<List<int>> minQueueSize { get; set; }

        public string enableAdvanced123Protection { get; set; }

        public int maxPlayersInTeam { get; set; }

        public int maxTimeInQueue { get; set; }
    }

    public class SpawnObject
    {

    public int spawnKeyPointsPerSector { get; set; }

    public int spawnSectorsAmount { get; set; }

    public List<string> placementStrategies { get; set; }

    public int spawnKeyPointsChooseTime { get; set; }
}



    public class TurretSettings
    {

        public @default @default { get; set; }
    }

    public class ConeVisibility
    {

        public TurretSettings turretSettings { get; set; }
    }




public class @default
{

    public double angle { get; set; }

    public int time { get; set; }
}





}
