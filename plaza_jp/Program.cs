using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plaza_jp
{
    class Pos
    {
        public int x;
        public int y;

        public static bool TryParsPos(string[] infoString, out Pos pos)
        {
            if (infoString.Length == 1)
            {
                if (int.TryParse(infoString[0], out int inputPos))
                {
                    pos = new Pos { x = inputPos, y = inputPos };
                    return true;
                }
                else
                {
                    pos = null;
                    return false;
                }
            }

            int inputX, inputY;
            if (!int.TryParse(infoString[0], out inputX))
            {
                pos = null;
                return false;
            }

            if (!int.TryParse(infoString[1], out inputY))
            {
                pos = null;
                return false;
            }

            pos = new Pos { x = inputX, y = inputY };
            return true;
        }
    }

    class Program
    {
        static int treasure_num;
        static List<Pos> treasure_posList;
        static int result;

        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out treasure_num))
                    break;
            }

            if (treasure_num < 1 || treasure_num > 1000000)
                return;

            treasure_posList = new List<Pos>();
            for (int i = 0; i < treasure_num; i++)
            {
                string input = Console.ReadLine();
                string[] posInfo = input.Split(' ');
                if (Pos.TryParsPos(posInfo, out Pos inputPos))
                    treasure_posList.Add(inputPos);
            }

            foreach (var pos in treasure_posList)
            {
                Console.WriteLine(string.Format("{0} {1}", pos.x, pos.y));
            }
        }

        static double CulculateDistance(Pos startPos)
        {
            double distance = 0;
            var Pos = FindClosePosition(startPos, out distance);

            return distance;
        }

        static Pos FindClosePosition(Pos curPos, out double shortest)
        {
            shortest = 0;
            Pos closePos = null;
            foreach (var inputPos in treasure_posList)
            {
                var distance = Math.Sqrt(Math.Pow(curPos.x - inputPos.x, 2) + Math.Pow(curPos.y - inputPos.y, 2));

                if (shortest == 0 || shortest > distance)
                {
                    shortest = distance;
                    closePos = inputPos;
                }
            }

            return closePos;
        }
    }
}