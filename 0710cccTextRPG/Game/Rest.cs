using System;
using System.Threading;

namespace _0710cccTextRPG
{
    public class Rest
    {
        public void ShowRestMenu()
        {
            var player = PlayerProfile.Instance;
            bool RestLoop = true;

            while (RestLoop)
            {
                Console.Clear();
                Console.WriteLine("***************** 휴식하기 *****************");
                Console.WriteLine();
                Console.WriteLine("     500 G를 내고 잠깐 쉴까? (체력이 회복된다.)");
                Console.WriteLine();
                Console.WriteLine($"              (보유 골드 : {player.PlayerGold} G)");
                Console.WriteLine("********************************************");
                Console.WriteLine();
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("선택 : ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (player.PlayerGold >= 500)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Effects.Ttyyppee("  …스으으읍…", 60); Thread.Sleep(800);
                            Console.WriteLine();
                            Effects.Ttyyppee("  …후~~~", 60); Thread.Sleep(600);
                            Console.WriteLine();

                            player.PlayerGold -= 500;
                            player.HP = player.MaxHP;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine($"  체력이 회복되었다. ({player.HP} / {player.MaxHP})");
                            Console.WriteLine($"  500 G를 지불했다. 현재 소지금: {player.PlayerGold} G");
                            Console.ResetColor();
                            PlayerProfile.Instance.SaveGame();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine("  골드가 부족하다. (필요: 500 G)");
                            Console.WriteLine($"  현재 소지금: {player.PlayerGold} G");
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                        Console.WriteLine(" [아무 키나 눌러서 돌아가기]");
                        Console.ReadKey();
                        RestLoop = false;
                        break;

                    case "0":
                        RestLoop = false;
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                        Thread.Sleep(50);
                        break;
                }
            }
        }
    }
}