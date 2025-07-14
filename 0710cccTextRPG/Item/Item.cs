using System;


namespace _0710cccTextRPG
{
    public enum ItemType
    {
        Weapon,
        Armor
    }
    
    public class Item
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ItemType Type { get; set; }
        public int Power { get; set; }
        public int Price { get; set; }
        public Item() { }

        public Item(string name, string desc, ItemType type, int power, int price)
        {
            Name = name;
            Description = desc;
            Type = type;
            Power = power;
            Price = price;
        }

        public string ItemInfo(bool isEquipped = false)
        {
            if (isEquipped)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[E]");
                Console.ResetColor();
            }
            else
            {
                Console.Write("");
            }
            string stat = Type == ItemType.Weapon ? $"공격력 +{Power}" : $"방어력 +{Power}";
            return $"{Name.PadRight(20)} | <{Type}> | {stat} | {Description} | {Price}G";
        }
    }






    
}

