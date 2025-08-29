enum MOVEMENT
{
    NONE,
    HAUT,
    BAS,
    GAUCHE,
    DROITE,
}

namespace snail
{
    class Pos
    {
        public int x;
        public int y;

        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Snail
    {
        public int _life = 50;
        public MOVEMENT _movement;
        public Pos _pos = new Pos(0, 0);
        private Pos _oldPos = new Pos(0, 0);
        public float _speed = 300.0f;

        public Snail(int life, MOVEMENT movement)
        {
            this._life = life;
            this._movement = movement;
        }

        public void MoveSnail()
        {
            switch(this._movement)
            {
                case MOVEMENT.NONE:
                    return;
                case MOVEMENT.HAUT:
                    if (this._pos.y == 1)
                    this._movement = MOVEMENT.BAS;
                    this._pos.y--;
                    break;
                case MOVEMENT.BAS:
                    if (this._pos.y == Console.WindowHeight - DrawSnail().Length - 1)
                    this._movement = MOVEMENT.HAUT;
                    this._pos.y++;
                    break;
                case MOVEMENT.GAUCHE:
                    if (this._pos.x == 1)
                    this._movement = MOVEMENT.DROITE;
                    this._pos.x--;
                    break;
                case MOVEMENT.DROITE:
                    if (this._pos.x == Console.WindowWidth - DrawSnail().Length - 1)
                    this._movement = MOVEMENT.GAUCHE;
                    this._pos.x++;
                    break;
            }
        }

        public string ClearSnail(string String)
        {
            string result = "";
            if (this._movement == MOVEMENT.HAUT || this._movement == MOVEMENT.BAS)
            {
                for (int i = 0; i < String.Length; i++)
                {
                    result += " \n";
                }
            }
            if (this._movement == MOVEMENT.GAUCHE || this._movement == MOVEMENT.DROITE)
            {
                for (int i = 0; i < String.Length; i++)
                {
                    result += " ";
                }
            }
            return result;
        }

        public string DrawSnail()
        {   
            switch (this._movement)
            {
                case MOVEMENT.NONE:
                    return "_@_ö";
                case MOVEMENT.HAUT:
                    return "v\n@\n|";
                case MOVEMENT.BAS:
                    return "|\n@\n^";
                case MOVEMENT.GAUCHE:
                    return ">@-";
                case MOVEMENT.DROITE:
                    return "-@<";
                default:
                    return "";
            }
        }

        public void turn()
        {
            string snailDessin = this.DrawSnail();
            Console.SetCursorPosition(this._oldPos.x, this._oldPos.y);
            Console.Write(this.ClearSnail(snailDessin));
            this.MoveSnail();
            Console.SetCursorPosition(this._pos.x, this._pos.y);
            Console.Write(snailDessin);
            int freq = (int)Math.Round(1000 / this._speed);
            Thread.Sleep(freq);
            this._oldPos = this._pos;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Snail snail1 = new Snail(50, MOVEMENT.DROITE);
            Snail snail2 = new Snail(20, MOVEMENT.BAS);
            List<Snail> snails = new List<Snail> { snail1, snail2 };
            while (true)
            {
                foreach (var snail in snails)
                {
                    snail.turn();
                }
            }
        }
    }
}
