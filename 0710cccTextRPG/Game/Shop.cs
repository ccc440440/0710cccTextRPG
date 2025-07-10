using System;
using System.Collections.Generic;
using System.Numerics;

namespace _0710cccTextRPG
{
    public class Shop
    {
        private List<Item> shopItems = new List<Item>()
        {
            new Item("낡은 빗자루", "쉽게 볼 수 있는 낡은 빗자루입니다.", ItemType.Weapon, 2, 300),
            new Item("곤색 앞치마", "은은하게 세제와 락스의 냄새가 납니다.", ItemType.Armor, 5, 500),
            new Item("중국산 청소기", "테X에서 구매한 제품치곤 쓸만합니다.", ItemType.Weapon, 7, 800),
            new Item("촌스러운 앞치마", "청소의 고수가 된 기분입니다.", ItemType.Armor, 8, 2000),
            new Item("적당한 밀대", "봉 가운데가 비어있어 아주 가볍습니다.", ItemType.Weapon, 10, 5000),
            new Item("고무장갑", "아주 기본에 충실합니다.", ItemType.Armor, 15, 39800),
            new Item("방역복", "이렇게까지 해야할까요?", ItemType.Armor, 23, 100000),
            new Item("충전식 진공청소기", "Tyson", ItemType.Weapon, 30, 250000)
        };

        public void Enter()
        {
            var player = PlayerProfile.Instance;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  어서오세요~ 다이쏘입니다~");
                Thread.Sleep(100);
                Console.WriteLine();
                Console.WriteLine("  [아이템 목록] ");

                foreach (var item in shopItems)
                {
                    bool alreadyOwned = PlayerProfile.Instance.Inventory.Exists(x => x.Name == item.Name);
                    string info = item.ItemInfo(false);

                    if (alreadyOwned)
                        info = info.Replace($"{item.Price}G", "*구매완료*".PadLeft(8));
                    else
                        info = info.Replace($"{item.Price}G", $"{item.Price} G".PadLeft(8));

                    Console.WriteLine($"- {info}");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"  현재 소지금: {player.PlayerGold} G");
                Console.WriteLine("");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.Write("선택: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        BuyMenu();
                        break;
                    case "2":
                        SellMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void BuyMenu()
        {
            Console.Clear();
            Console.WriteLine("  [아이템 구매]");
            for (int i = 0; i < shopItems.Count; i++)
            {
                bool alreadyOwned = PlayerProfile.Instance.Inventory.Exists(x => x.Name == shopItems[i].Name);
                string info = shopItems[i].ItemInfo(false);
                string priceTag = alreadyOwned ? "구매완료".PadLeft(8) : $"{shopItems[i].Price} G".PadLeft(8);
                info = info.Replace($"{shopItems[i].Price}G", priceTag);

                Console.WriteLine($"{i + 1}. {info}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"  현재 소지금: {PlayerProfile.Instance.PlayerGold} G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.Write("\n구매할 아이템 번호 선택: ");
            string input = Console.ReadLine();

            if (input == "0") return;

            if (int.TryParse(input, out int index) && index >= 1 && index <= shopItems.Count)
            {
                var item = shopItems[index - 1];

                if (PlayerProfile.Instance.Inventory.Exists(x => x.Name == item.Name))
                {
                    Console.WriteLine("\n이미 소지하고 있는 아이템이다.");
                }
                else if (PlayerProfile.Instance.PlayerGold < item.Price)
                {
                    Console.WriteLine("\n소지금이 부족하다.");
                }
                else
                {
                    PlayerProfile.Instance.PlayerGold -= item.Price;
                    PlayerProfile.Instance.Inventory.Add(item);
                    Console.WriteLine($"\n{item.Name}을(를) 구매했다!");
                    PlayerProfile.Instance.SaveGame();
                }
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.");
            }
            Console.WriteLine();
            Console.WriteLine(" [아무 키나 눌러서 돌아가기]");
            Console.ReadKey();
        }

        private void SellMenu()
        {
            var inventory = PlayerProfile.Instance.Inventory;
            if (inventory.Count == 0)
            {
                Console.WriteLine("\n판매할 수 있는 아이템이 없다.");
                Console.WriteLine();
                Console.WriteLine(" [아무 키나 눌러서 돌아가기]");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("  [아이템 판매]");
            for (int i = 0; i < inventory.Count; i++)
            {
                var item = inventory[i];
                int sellPrice = (int)(item.Price * 0.85f);
                Console.WriteLine($"{i + 1}. {item.ItemInfo()} (판매가: {sellPrice} G)");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"  현재 소지금: {PlayerProfile.Instance.PlayerGold} G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("판매할 아이템 번호 선택: ");
            string input = Console.ReadLine();

            if (input == "0") return;

            if (int.TryParse(input, out int index) && index >= 1 && index <= inventory.Count)
            {
                var item = inventory[index - 1];
                int sellPrice = (int)(item.Price * 0.85);

                if (item == PlayerProfile.Instance.EquippedWeapon)
                {
                    PlayerProfile.Instance.EquippedWeapon = null;
                    PlayerProfile.Instance.StatsF5();
                }
                else if (item == PlayerProfile.Instance.EquippedArmor)
                {
                    PlayerProfile.Instance.EquippedArmor = null;
                    PlayerProfile.Instance.StatsF5();
                }

                PlayerProfile.Instance.PlayerGold += sellPrice;
                inventory.RemoveAt(index - 1);

                Console.WriteLine();
                Console.WriteLine($"{item.Name}을(를) 판매했다 (+{sellPrice} G)");
                PlayerProfile.Instance.SaveGame();
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.");
            }

            Console.WriteLine();
            Console.WriteLine(" [아무 키나 눌러서 돌아가기]");
            Console.ReadKey();
        }
    }
}
