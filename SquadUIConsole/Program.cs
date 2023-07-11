using LibRcon;
using System.Text;

namespace SquadUIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mc = new Rcon("43.248.191.107", 10046, "2023071101");
            while (true)
            {
                Console.WriteLine(mc.Command(Console.ReadLine()));
            }
        }
    }
}