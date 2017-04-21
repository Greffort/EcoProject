using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EcoProject
{
    public class Vector
    {
        public float x, y;

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector()
        {
            this.x = new float();
            this.y = new float();
        }

        public Vector(Vertex point1, Vertex point2)
        {
            this.x = point2.x - point1.x;
            this.y = point2.y - point1.y;
        }

        public static Vector operator +(Vector obj1, Vector obj2)
        {
            Vector objresult;

            float x = obj1.x + obj2.x;
            float y = obj1.y + obj2.y;

            objresult = new Vector(x, y);

            return objresult;

        }

        public static float operator *(Vector obj1, Vector obj2)
        {

            float scalar = obj1.x * obj2.x + obj1.y * obj2.y;

            return scalar;

        }
        public static Vector operator *(float num, Vector obj1)
        {

            obj1.x *= num;
            obj1.y *= num;

            return obj1;

        }

        public static Vector operator !(Vector obj1) //нормальный вектор
        {
            Vector objresult;

            float x = (-1) * obj1.y;
            float y = obj1.x;

            objresult = new Vector(x, y);

            return objresult;
        }

    }
}
