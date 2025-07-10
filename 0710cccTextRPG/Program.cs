using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;



namespace _0710cccTextRPG
{
    public class MainTitle
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine();
            Console.WriteLine("             - 청소는 해도해도 끝이 없다 -             ");
            Console.WriteLine();
            Console.WriteLine("                               made by 2주차의 김정민  ");
            Console.WriteLine("*******************************************************");
            Thread.Sleep(400);

            bool ChoiceLoop_1 = true;
            while (ChoiceLoop_1)
            {
                Console.WriteLine();
                Console.WriteLine("1. 새 청소");
                Console.WriteLine("2. 마저 청소");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        NewGameIntro();
                        ChoiceLoop_1 = false;
                        break;
                    case "2":

                        ChoiceLoop_1 = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }


        }
        static void Ttyyppee(string message, int delay = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
        public static void NewGameIntro()
        {
            PlayerProfile player = new PlayerProfile();
            Thread.Sleep(300);
            Ttyyppee("  들리는가?"); Console.WriteLine();
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
                        Ttyyppee("  좋다. 자네의 이름을 알려다오."); Console.WriteLine();
                        Console.WriteLine();
                        ChoiceLoop_1 = false;
                        break;
                    case "2":
                        Console.WriteLine();
                        Ttyyppee("  ...읽", 200); Ttyyppee(", 읽히는가?"); Console.WriteLine();
                        while (ChoiceLoop_2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("1. 네 잘읽힙니다.");
                            Console.WriteLine("2. 안읽히는데용?");
                            string input_intro_2 = Console.ReadLine();
                            switch (input_intro_2)
                            {
                                case "1":
                                    Console.WriteLine();
                                    Ttyyppee("  좋다. 자네의 이름을 알려다오."); Console.WriteLine();
                                    Console.WriteLine();
                                    ChoiceLoop_2 = false;
                                    ChoiceLoop_1 = false;
                                    break;
                                case "2":
                                    Console.WriteLine();
                                    Ttyyppee("  ..."); Thread.Sleep(1100);
                                    Ttyyppee("  그냥 자네의 이름을 알려다오."); Console.WriteLine();
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
            PlayerProfile.PlayerName = input_Name;
            Console.WriteLine();
            Ttyyppee($"  오, {input_Name}. 나와 이름이 같군. 반갑네."); Console.WriteLine(); Thread.Sleep(200);
            Ttyyppee("  자네의 클래스를 고르게나."); Console.WriteLine(); Thread.Sleep(200);

            ChoiceLoop_1 = true;
            while (ChoiceLoop_1)
            {
                Console.WriteLine();
                Console.WriteLine("1. 쓸기맨");
                Console.WriteLine("2. 닦기맨");
                Console.WriteLine("3. 분리수거맨"); Thread.Sleep(300);
                Console.WriteLine();
                Console.Write("나는... :");

                string input_Classs = Console.ReadLine();
                switch (input_Classs)
                {
                    case "1":
                        PlayerProfile.Classs = "쓸기맨";
                        Ttyyppee("  쓸기맨이라..."); Thread.Sleep(200); Ttyyppee("전열을 맡아 청소를 이끄는 중요한 역할이지"); Console.WriteLine(); Thread.Sleep(200);
                        ChoiceLoop_1 = false;
                        break;
                    case "2":
                        PlayerProfile.Classs = "닦기맨";
                        Ttyyppee("  닦기맨이라..."); Thread.Sleep(200); Ttyyppee("후열을 맡아 청소를 마무리하는 중요한 역할이지"); Console.WriteLine(); Thread.Sleep(200);
                        ChoiceLoop_1 = false;
                        Console.WriteLine("");
                        break;
                    case "3":
                        PlayerProfile.Classs = "분리수거맨";
                        Ttyyppee("  분리수거맨이라..."); Thread.Sleep(200); Ttyyppee("환경과 자원을 생각하는 중요한 역할이지"); Console.WriteLine(); Thread.Sleep(200);
                        ChoiceLoop_1 = false;
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
                Console.WriteLine("");
            }
            Ttyyppee("  그럼 거두절미하고,"); Thread.Sleep(300); Ttyyppee("  바로 청소를 시작하도록 하지.");


        }
    }
}
