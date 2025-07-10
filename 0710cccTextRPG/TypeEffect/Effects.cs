using System;
using System.Threading;

namespace _0710cccTextRPG
{
    public static class Effects
    {
        public static void Ttyyppee(string message, int delay = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
