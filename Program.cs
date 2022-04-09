using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HomeWorkOfLesson4.new1
{
    public class Program
    {
        //List<Coords> list;
        List<Coords>[][,] moves;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            int count = Enum.GetNames(typeof(Figures)).Length;
            moves = new List<Coords>[count][,];
            moves[(int)Figures.Rook] = new List<Coords>[8, 8];
            moves[(int)Figures.Knight] = new List<Coords>[8, 8];
            moves[(int)Figures.Bishop] = new List<Coords>[8, 8];
            moves[(int)Figures.Queen] = new List<Coords>[8, 8];
            moves[(int)Figures.King] = new List<Coords>[8, 8];

            for (int x = 0; x <= 7; x++)
            for (int y = 0; y <= 7; y++)
            {
                moves[(int)Figures.Rook][x, y] = RookMoves(x, y);
                moves[(int)Figures.Knight][x, y] = KnightMoves(x, y);
                moves[(int)Figures.Bishop][x, y] = BishopMoves(x, y);
                moves[(int)Figures.Queen][x, y] = QueenMoves(x, y);
                moves[(int)Figures.King][x, y] = KingMoves(x, y);
            }

            Console.WriteLine("Общее количество ходов для всех фигур: " + motionCount(moves));
            Console.WriteLine("Общее количество ходов для всех фигур c поля A1: " + motionCountFrom0_0(moves));

            minMotionForEachFigures(moves);
        }

        List<Coords> RookMoves(int x, int y)
        {
            List<Coords> list = new List<Coords>(14);

            for (int sx = x - 1; sx >= 0; sx--)
                list.Add(new Coords(sx, y));
            for (int sx = x + 1; sx <= 7; sx++)
                list.Add(new Coords(sx, y));
            for (int sy = y - 1; sy >= 0; sy--)
                list.Add(new Coords(x, sy));
            for (int sy = y + 1; sy <= 7; sy++)
                list.Add(new Coords(x, sy));

            return list;
        }

        List<Coords> KnightMoves(int x, int y)
        {
            List<Coords> list = new List<Coords>();
            if (x - 2 >= 0 && y - 1 >= 0)
                list.Add(new Coords(x - 2, y - 1));
            if (x - 2 >= 0 && y + 1 <= 7)
                list.Add(new Coords(x - 2, y + 1));
            if (x + 2 <= 7 && y - 1 >= 0)
                list.Add(new Coords(x + 2, y - 1));
            if (x + 2 <= 7 && y + 1 <= 7)
                list.Add(new Coords(x + 2, y + 1));

            if (y - 2 >= 0 && x - 1 >= 0)
                list.Add(new Coords(x - 1, y - 2));
            if (y - 2 >= 0 && x + 1 <= 7)
                list.Add(new Coords(x + 1, y - 2));
            if (y + 2 <= 7 && x - 1 >= 0)
                list.Add(new Coords(x + 1, y - 2));
            if (y + 2 <= 7 && x + 1 <= 7)
                list.Add(new Coords(x + 1, y + 2));

            return list;
        }

        List<Coords> BishopMoves(int x, int y)
        {
            List<Coords> list = new List<Coords>();

            int i = x;
            int j = y;

            while (i < 7 && j < 7)
            {
                list.Add(new Coords(i + 1, j + 1));
                i++;
                j++;
            }

            i = x;
            j = y;

            while (i < 7 && j > 0)
            {
                list.Add(new Coords(i + 1, j - 1));
                i++;
                j--;
            }

            i = x;
            j = y;

            while (i > 0 && j < 7)
            {
                list.Add(new Coords(i - 1, j + 1));
                i--;
                j++;
            }

            i = x;
            j = y;

            while (i > 0 && j > 0)
            {
                list.Add(new Coords(i - 1, j - 1));
                i--;
                j--;
            }

            return list;
        }

        List<Coords> QueenMoves(int x, int y)
        {
            List<Coords> list = new List<Coords>();

            for (int sx = x - 1; sx >= 0; sx--)
                list.Add(new Coords(sx, y));
            for (int sx = x + 1; sx <= 7; sx++)
                list.Add(new Coords(sx, y));
            for (int sy = y - 1; sy >= 0; sy--)
                list.Add(new Coords(x, sy));
            for (int sy = y + 1; sy <= 7; sy++)
                list.Add(new Coords(x, sy));

            for (int sx = x - 1, sy = y - 1; sx >= 0 && sy >= 0; sx--, sy--)
                list.Add(new Coords(sx, sy));
            for (int sx = x - 1, sy = y + 1; sx >= 0 && sy <= 7; sx--, sy++)
                list.Add(new Coords(sx, sy));
            for (int sx = x + 1, sy = y - 1; sx <= 7 && sy >= 0; sx++, sy--)
                list.Add(new Coords(sx, sy));
            for (int sx = x + 1, sy = y + 1; sx <= 7 && sy <= 7; sx++, sy++)
                list.Add(new Coords(sx, sy));

            return list;
        }

        List<Coords> KingMoves(int x, int y)
        {
            List<Coords> list = new List<Coords>();

            if (x - 1 >= 0 && y - 1 >= 0)
                list.Add(new Coords(x - 1, y - 1));
            if (x - 1 >= 0 && y + 1 <= 7)
                list.Add(new Coords(x - 1, y + 1));
            if (x + 1 <= 7 && y - 1 >= 0)
                list.Add(new Coords(x + 1, y - 1));
            if (x + 1 <= 7 && y + 1 <= 7)
                list.Add(new Coords(x + 1, y + 1));

            if (x - 1 >= 0)
                list.Add(new Coords(x - 1, y));
            if (x + 1 <= 7)
                list.Add(new Coords(x + 1, y));
            if (y + 1 <= 7)
                list.Add(new Coords(x, y + 1));
            if (y - 1 >= 0)
                list.Add(new Coords(x, y - 1));


            return list;
        }

        int motionCount(List<Coords>[][,] list)
        {
            //Console.WriteLine(list[4].Length);
            //Console.WriteLine(list[4][1,7].Count);

            int motionCount = 0;
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    for (int k = 0; k <= 7; k++)
                    {
                        motionCount += list[i][j, k].Count;
                    }
                }
            }

            //Console.WriteLine(motionCount);

            return motionCount;
        }

        int motionCountFrom0_0(List<Coords>[][,] list)
        {
            int motionCount = 0;
            for (int i = 0; i < list.Length; i++)
            {
                motionCount += list[i][0, 0].Count;
            }

            return motionCount;
        }

        void minMotionForEachFigures(List<Coords>[][,] list)
        {
            Coords[] coords = new Coords[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                int minMotion = 64;
                Coords minMotionCoords = default;

                for (int j = 0; j <= 7; j++)
                {
                    for (int k = 0; k <= 7; k++)
                    {
                        if (list[i][j, k].Count <= minMotion)
                        {
                            minMotion = list[i][j, k].Count;
                            coords[i] = new Coords(j, k);
                        }
                    }
                }
            }
            Console.WriteLine("Для лодьи стартовая ячейка с минимальным количеством ходов: " + coords[0].ToString());
            Console.WriteLine("Для коня стартовая ячейка с минимальным количеством ходов: " + coords[1].ToString());
            Console.WriteLine("Для слона стартовая ячейка с минимальным количеством ходов: " + coords[2].ToString());
            Console.WriteLine("Для королевы стартовая ячейка с минимальным количеством ходов: " + coords[3].ToString());
            Console.WriteLine("Для короля стартовая ячейка с минимальным количеством ходов: " + coords[4].ToString());

            //return coords;
        }

        struct Coords
        {
            public int x;
            public int y;

            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"{x}, {y}";
            }
        }

        enum Figures
        {
            Rook, //лодья
            Knight, //конь
            Bishop, //слон
            Queen, //ферзь
            King, //король
        }
    }
}