using System;

namespace WotReplayParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse parse = new Parse();
            parse.parse(@"C:\Games\World_of_Tanks_RU\replays\20210727_2047_france-F97_ELC_EVEN_90_45_north_america.wotreplay");
        }
    }
}
