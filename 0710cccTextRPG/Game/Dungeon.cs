using System;
using System.Numerics;
using System.Threading;

namespace _0710cccTextRPG
{
    public class Dungeon
    {
        public void EnterDungeon()
        {
            bool loop = true;
            while (loop)
            {
                var player = PlayerProfile.Instance;
                Console.Clear();
                if (player.HP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Effects.Ttyyppee("  자네 체력이 0이군! 더 이상의 청소는 무리야. 휴식을 취하게.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("  [아무 키나 눌러서 나가기]");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("  좋아, 어딜 청소 할 텐가?");
                Console.WriteLine("1. 방 청소         (권장 방어력: 5)");
                Console.WriteLine("2. 거실 청소       (권장 방어력: 8)");
                Console.WriteLine("3. 싹 다  대 청 소 (권장 방어력: 12)");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine($"  공격력 : {player.AttackPower}");
                Console.WriteLine($"  방어력 : {player.ArmorClass}");
                Console.WriteLine($"  소지금 : {player.PlayerGold} G");
                Console.WriteLine($"  현재 체력 : {player.HP} / {player.MaxHP}");
                Console.Write("선택: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CleanRoom("방 청소", 5f, 1000);
                        break;
                    case "2":
                        CleanRoom("거실 청소", 8f, 1700);
                        break;
                    case "3":
                        CleanRoom("대청소", 12f, 2500);
                        break;
                    case "0":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CleanRoom(string name, float requiredAC, int baseGold)
        {
            var player = PlayerProfile.Instance;
            Random rand = new Random();

            Console.Clear();
            Console.Write($"  [{name}]를 해본다");
            Effects.Ttyyppee("...", 500);
            Console.WriteLine();
            Thread.Sleep(500);

            float hpLoss = 0;

            if (player.ArmorClass < requiredAC)
            {
                int lucky = rand.Next(1, 101);  // 1~100
                if (lucky <= 40)
                {
                    hpLoss = player.MaxHP * 0.5f;
                    player.HP -= hpLoss;
                    if (player.HP < 0) player.HP = 0;


                    Effects.Ttyyppee("  자네 청소가 형편없군... 때론 도구탓도 해보게나.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($" - 체력 {hpLoss} 감소    현재 체력: {player.HP} / {player.MaxHP}");
                    Console.WriteLine();
                    Console.WriteLine("  [아무 키나 눌러서 돌아가기]");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("  청소 완료!");
            int baseDamage = rand.Next(20, 36);
            int acDiff = (int)(requiredAC - player.ArmorClass);
            int finalDamage = baseDamage + acDiff;
            if (finalDamage < 1) finalDamage = 1;

            player.HP -= finalDamage;
            if (player.HP < 0) player.HP = 0;

            Console.WriteLine($"- 체력 {finalDamage} 감소 | 현재 체력: {player.HP} / {player.MaxHP}");

            int bonusPercentMin = (int)player.AttackPower;
            int bonusPercentMax = (int)(player.AttackPower * 2);
            int bonusPercent = rand.Next(bonusPercentMin, bonusPercentMax + 1);
            int bonusGold = baseGold * bonusPercent / 100;
            int totalGold = baseGold + bonusGold;

            player.PlayerGold += totalGold;
            PlayerProfile.Instance.Exp_LevelUp(5);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" 기본 보상: {baseGold} G");
            Console.WriteLine($" 공격력 뽀나쓰 ({bonusPercent}%): {bonusGold} G");
            Console.WriteLine($" 총 보상: {totalGold} G");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"  현재 소지금: {player.PlayerGold} G");
            Console.WriteLine($"  현재 체력: {player.HP} / {player.MaxHP}");
            Console.WriteLine();
            PlayerProfile.Instance.SaveGame();
            Console.WriteLine("  [아무 키나 눌러서 돌아가기]");
            Console.ReadKey();
        }
    }
}
