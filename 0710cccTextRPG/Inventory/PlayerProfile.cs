using System;
using System.Collections.Generic;

namespace _0710cccTextRPG
{ 
    public class PlayerProfile
    {
        public static int PlayerExp { get; set; } = 0;
        public static int Level { get; set; } = 1;
        public static string? PlayerName { get; set; }
        public static string? Classs { get; set; }
        public static float AttackPower { get; set; } = 10.0f;
        public static float ArmorClass { get; set; } = 5.0f;
        public static float HP { get; set; } = 100.0f;
        public static int PlayerGold { get; set; } = 1500;
    }
}