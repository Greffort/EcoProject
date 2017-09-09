using System;
using System.Collections.Generic;
using System.Text;

/*
  copyright s-hull.org 2011
  released under the contributors beerware license

  contributors: Phil Atkin, Dr Sinclair.
*/
namespace EcoProject
{
    public class Vertex
    {
        public float x { set; get; }

        public float y {set; get; }

        public Vector Vector = new Vector();

        public float xVector
        {
            set { Vector.x = value; }
            get { return Vector.x; }
        }

        public float yVector
        {
            set { Vector.y = value; }
            get { return Vector.y; }
        }




        public Vertex()
        {
            this.x = new float();
            this.y = new float();
        }

        public Vertex(float x, float y) 
        {
            this.x = x; this.y = y;
          

        }

        public float distance2To(Vertex other)
        {
            float dx = x - other.x;
            float dy = y - other.y;
            return dx * dx + dy * dy;
        }

        public float distanceTo(Vertex other)
        {
            return (float)Math.Sqrt(distance2To(other));
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
        public override bool Equals(object obj)
        {
            Vertex vobj = obj as Vertex;
            if(vobj == null)
                return false;

            if (this.x == vobj.x)
            {
                if (this.y == vobj.y) return true;
                else
                { return false; }

            }
            else return false;
        }
    }

}
