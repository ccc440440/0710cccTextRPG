using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Net.Security;


namespace _0710cccTextRPG
{
    public class PlayerProfile
    {
        private static PlayerProfile real_instance = new PlayerProfile();
        public static PlayerProfile Instance => real_instance;
        public int Level { get; set; } = 1;
        public int PlayerExp { get; set; } = 0;
        public int RequiredExp { get; set; } = 0;
        public string? PlayerName { get; set; } = "";
        public string? Classs { get; set; } = "";
        public float AttackPower { get; set; } = 10.0f;
        public float ArmorClass { get; set; } = 5.0f;
        public float BaseAttackPower { get; private set; } = 10.0f;
        public float BaseArmorClass { get; private set; } = 5.0f;
        public float MaxHP { get; set; } = 100.0f;
        public float HP { get; set; } = 100.0f;
        public int PlayerGold { get; set; } = 1500;
        public List<Item> Inventory { get; set; } = new List<Item>();
        public Item? EquippedWeapon { get; set; }
        public Item? EquippedArmor { get; set; }

        public void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine("*************** 상태창 ***************");
            Console.WriteLine($" 레 벨  : {Level} (EXP: {PlayerExp} / {RequiredExp})");
            Console.WriteLine($" 이 름  : {PlayerName}");
            Console.WriteLine($" 클래스 : {Classs}");
            Console.WriteLine($" 공격력 : {AttackPower}");
            Console.WriteLine($" 방어력 : {ArmorClass}");
            Console.WriteLine($" 체 력  : {HP} / {MaxHP}");
            Console.WriteLine($" 소지금 : {PlayerGold} G");
            Console.WriteLine();
            Console.WriteLine($" 무 기  : {(EquippedWeapon?.Name ?? "없음")}");
            Console.WriteLine($" 방어구 : {(EquippedArmor?.Name ?? "없음")}");
            Console.WriteLine("**************************************");
            Console.WriteLine();
            Console.WriteLine(" [아무 키나 눌러서 돌아가기]");
            Console.ReadKey();
        }

        public void ShowInventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("********************** 인벤토리 **********************");
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Item item = Inventory[i];
                    bool isEquipped = item == EquippedWeapon || item == EquippedArmor;
                    Console.WriteLine(item.ItemInfo(isEquipped));
                }
                Console.WriteLine("*****************************************************");
                Console.WriteLine();
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.Write("선택: ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                  ManageEquipments();
                }
                else if (input == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }

            }
        }

        public void Exp_LevelUp(int expGained)
        {
            PlayerExp += expGained;
            RequiredExp = Level * 5;

            while (PlayerExp >= RequiredExp)
            {
                PlayerExp -= RequiredExp;
                Level++;
                BaseAttackPower += 0.5f;
                BaseArmorClass += 1.0f;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  [레벨업] Lv.{Level}이 되었다! 공격력과 방어력이 증가했다. 더 청소에 능숙해진 것이다...");
                Console.ResetColor();
                RequiredExp = Level * 5;
            }
            StatsF5();
        }


        public void ManageEquipments()
        {
            bool MEloop = true;
            while (MEloop)
            {
                Console.Clear();
                Console.WriteLine("********************** 장착관리 **********************");
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Item item = Inventory[i];
                    bool isEquipped = item == EquippedWeapon || item == EquippedArmor;
                    Console.Write($"{i + 1}. ");
                    Console.WriteLine(item.ItemInfo(isEquipped));
                }
                Console.WriteLine("*****************************************************");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.Write("장착할 도구의 번호를 선택: ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    MEloop = false;
                    break;
                }

                if (int.TryParse(input, out int index) && index >= 1 && index <= Inventory.Count)
                {
                    Item selectedItem = Inventory[index - 1];

                    if (selectedItem.Type == ItemType.Weapon)
                    {
                        EquippedWeapon = selectedItem;
                        Console.WriteLine($"\n[무기] {selectedItem.Name}을(를) 장착했다.");
                        StatsF5();
                    }
                    else if (selectedItem.Type == ItemType.Armor)
                    {
                        EquippedArmor = selectedItem;
                        Console.WriteLine($"\n[방어구] {selectedItem.Name}을(를) 장착했다.");
                        StatsF5();
                    }
                    else
                    {
                        Console.WriteLine("장착할 수 없는 아이템이다.");
                    }
                    Console.WriteLine();
                    Console.WriteLine(" [아무 키나 눌러서 돌아가기]");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }
        public void StatsF5()
        {
            AttackPower = BaseAttackPower;
            ArmorClass = BaseArmorClass;

            if (EquippedWeapon != null)
                AttackPower += EquippedWeapon.Power;

            if (EquippedArmor != null)
                ArmorClass += EquippedArmor.Power;
        }





        public void SaveGame()
        {
            var saveData = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("save.json", saveData);
        }

        public static void LoadGame()
        {
            if (!File.Exists("save.json"))
            {
                Console.WriteLine("저장된 데이터가 없습니다.");
                return;
            }

            string saveData = File.ReadAllText("save.json");
            var loadedProfile = JsonSerializer.Deserialize<PlayerProfile>(saveData);
            Instance.PlayerName = loadedProfile.PlayerName;
            Instance.Classs = loadedProfile.Classs;
            Instance.Level = loadedProfile.Level;
            Instance.PlayerExp = loadedProfile.PlayerExp;
            Instance.AttackPower = loadedProfile.AttackPower;
            Instance.ArmorClass = loadedProfile.ArmorClass;
            Instance.HP = loadedProfile.HP;
            Instance.MaxHP = loadedProfile.MaxHP;
            Instance.PlayerGold = loadedProfile.PlayerGold;
            Instance.Inventory = loadedProfile.Inventory;
            Instance.EquippedWeapon = loadedProfile.EquippedWeapon;
            Instance.EquippedArmor = loadedProfile.EquippedArmor;
        }
    }
}