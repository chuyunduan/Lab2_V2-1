using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Lab1_V2
{
    struct DataItem
    {
        public Vector2 Vector { get; set;}
        public Complex Complex { get; set; }

        public DataItem(Vector2 vector, Complex complex)
        {
            Vector = vector;
            Complex = complex;
        }

        public override string ToString()
        {
            return $"Vector: { Vector.X.ToString() },{ Vector.Y.ToString() } | Complex: { Complex.ToString() }\n";
        }

        public string ToString(string format)
        {
            return $"Vector: { Vector.X.ToString(format) }, { Vector.Y.ToString(format) } | Complex: { Complex.ToString(format) }\n";
        }
    }
}
