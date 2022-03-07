using System;

namespace WotReplayParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse parse = new Parse();
            //parse.parse(@"C:\Games\World_of_Tanks_RU\未完成.wotreplay");
            parse.parse(@"C:\Games\World_of_Tanks_RU\已完成.wotreplay");


        }
    }
}
