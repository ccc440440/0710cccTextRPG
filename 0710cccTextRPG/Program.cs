using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.IO;



namespace _0710cccTextRPG
{

    
    public class MainLessgo
    {

        static void Main(string[] args)
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
                        new Intro().Start();
                        ChoiceLoop_1 = false;
                        break;
                    case "2":
                        PlayerProfile.LoadGame();
                        new MainScene().Start();
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
