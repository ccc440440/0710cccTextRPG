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
        public string Name;
        public ItemType Type;
        public int Power;
        public string Description;
        public int Price;

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
            return $"{Name.PadRight(14)} | <{Type}> | {stat} | {Description} | {Price}G";
        }
    }







}

