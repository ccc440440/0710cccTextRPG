using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;

namespace _0710cccTextRPG
{
    public class Intro
    {
        public void Start()
        {
            var player = PlayerProfile.Instance;
            Thread.Sleep(300);
            Effects.Ttyyppee("  들리는가?");
            Console.WriteLine();

            bool ChoiceLoop_1 = true;
            bool ChoiceLoop_2 = true;

            while (ChoiceLoop_1)
            {
                Console.WriteLine();
                Console.WriteLine("1. 네 잘들립니다.");
                Console.WriteLine("2. 안들리는데용?");
                Console.Write("선택: ");
                string input_intro_1 = Console.ReadLine();

                switch (input_intro_1)
                {
                    case "1":
                        Console.WriteLine();
                        Effects.Ttyyppee("  좋아. 자네의 이름을 알려주게.");
                        Console.WriteLine();
                        Console.WriteLine();
                        ChoiceLoop_1 = false;
                        break;

                    case "2":
                        Console.WriteLine();
                        Effects.Ttyyppee("  ...읽", 200);
                        Effects.Ttyyppee(", 읽히는가?");
                        Console.WriteLine();

                        while (ChoiceLoop_2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("1. 네 잘읽힙니다.");
                            Console.WriteLine("2. 안읽히는데용?");
                            Console.Write("선택: ");
                            string input_intro_2 = Console.ReadLine();

                            switch (input_intro_2)
                            {
                                case "1":
                                    Console.WriteLine();
                                    Effects.Ttyyppee("  좋아. 자네의 이름을 알려주게.");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    ChoiceLoop_2 = false;
                                    ChoiceLoop_1 = false;
                                    break;

                                case "2":
                                    Console.WriteLine();
                                    Effects.Ttyyppee("  ...");
                                    Thread.Sleep(1100);
                                    Effects.Ttyyppee("  그냥 자네의 이름을 알려주게...");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    ChoiceLoop_2 = false;
                                    ChoiceLoop_1 = false;
                                    break;

                                default:
                                    Console.WriteLine("잘못된 입력입니다.");
                                    break;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }

            Console.Write("나는... :");
            string input_Name = Console.ReadLine();
            player.PlayerName = input_Name;
            Console.WriteLine();
            Console.Clear();

            Effects.Ttyyppee($"  오, {input_Name}. 나와 이름이 같군. 반갑네.");
            Console.WriteLine();
            Thread.Sleep(200);
            Effects.Ttyyppee("  자네의 클래스를 고르게나.");
            Console.WriteLine();
            Thread.Sleep(200);

            ChoiceLoop_1 = true;
            while (ChoiceLoop_1)
            {
                Console.WriteLine();
                Console.WriteLine("1. 쓸기맨");
                Console.WriteLine("2. 닦기맨");
                Console.WriteLine("3. 분리수거맨");
                Thread.Sleep(300);
                Console.WriteLine();
                Console.Write("선택: ");

                string input_Classs = Console.ReadLine();

                switch (input_Classs)
                {
                    case "1":
                        player.Classs = "쓸기맨";
                        Effects.Ttyyppee("  쓸기맨이라...");
                        Thread.Sleep(200);
                        Effects.Ttyyppee("전열을 맡아 청소를 이끄는 중요한 역할이지.");
                        Console.WriteLine();
                        Thread.Sleep(200);
                        ChoiceLoop_1 = false;
                        break;

                    case "2":
                        player.Classs = "닦기맨";
                        Effects.Ttyyppee("  닦기맨이라...");
                        Thread.Sleep(200);
                        Effects.Ttyyppee("후열을 맡아 청소를 마무리하는 중요한 역할이지.");
                        Console.WriteLine();
                        Thread.Sleep(200);
                        ChoiceLoop_1 = false;
                        Console.WriteLine();
                        break;

                    case "3":
                        player.Classs = "분리수거맨";
                        Effects.Ttyyppee("  분리수거맨이라...");
                        Thread.Sleep(200);
                        Effects.Ttyyppee("환경과 자원을 생각하는 중요한 역할이지.");
                        Console.WriteLine();
                        Thread.Sleep(200);
                        ChoiceLoop_1 = false;
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

                Console.WriteLine();
            }
            Thread.Sleep(100);
            Console.WriteLine();
            Effects.Ttyyppee("  좋아. 그럼 거두절미하고,");
            Thread.Sleep(200);
            Console.WriteLine();
            Effects.Ttyyppee(" 바로 청소를 시작하도록 하지.");
            Thread.Sleep(400);
            new MainScene().Start();
        }
    }
}
