using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;

namespace _0710cccTextRPG
{
    public class MainScene
    {
        public void Start()

        {
           while(true)
           {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"  {PlayerProfile.Instance.PlayerName}, 뭘하겠나?");
                Console.WriteLine();
                Console.WriteLine(" 1.  내 상태 보기");
                Console.WriteLine(" 2.  인벤토리");
                Console.WriteLine(" 3.  다이쏘(상점)");
                Console.WriteLine(" 4. *청소ㅎㅎ*");
                Console.WriteLine(" 5.  휴식");
                Console.WriteLine();
                bool ChoiceLoop_1 = true;
                while (ChoiceLoop_1)
                {
                    Console.Write("선택: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            PlayerProfile.Instance.ShowStatus();
                            ChoiceLoop_1 = false;
                            break;
                        case "2":
                            PlayerProfile.Instance.ShowInventory();
                            ChoiceLoop_1 = false;
                            break;
                        case "3":
                            new Shop().Enter();
                            ChoiceLoop_1 = false;
                            break;
                        case "4":
                            new Dungeon().EnterDungeon();
                            ChoiceLoop_1 = false;
                            break;
                        case "5":
                            new Rest().ShowRestMenu();
                            ChoiceLoop_1 = false;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
            
        }
    }
}
