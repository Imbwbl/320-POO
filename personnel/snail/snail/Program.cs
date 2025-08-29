

namespace snail
{

    

    internal class Program
    {
        static void Main()
        {
            int life = 0;
            while (life <= 50) {
                Console.SetCursorPosition(life, 0);
                Console.Write();
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(life, 0);
                Console.Write("   ");
                life++;
            }
        }

        
    }
}
