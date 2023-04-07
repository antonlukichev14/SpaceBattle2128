using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class Vector2
    {
        public int x;
        public int y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static int Distance(Vector2 first, Vector2 second)
        {
            //Возвращает дистанцию между двумя векторами.

            return (int)Math.Sqrt(Math.Pow(first.x - second.x, 2) + Math.Pow(first.y - second.y, 2));
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(int a, Vector2 b)
        {
            return new Vector2(a * b.x, a * b.y);
        }

        public static Vector2 operator /(int a, Vector2 b)
        {
            return new Vector2(b.x / a, b.y / a);
        }
    }
}
