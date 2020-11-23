using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //1
            try
            {
                V2DataOnGrid grid = new V2DataOnGrid("infofile.txt");
                Console.WriteLine(grid.ToLongString("n"));
            }
            catch (Exception ex)//4
            {
                Console.WriteLine(ex.Message);
            }

            //3
            try
            {
                V2MainCollection mainCollection = new V2MainCollection();
                mainCollection.AddDefaults();
                Console.WriteLine(mainCollection.ToLongString("n"));
                
                Console.WriteLine($"Average V2MainCollection: { mainCollection.Avg.ToString() }\n");

                Console.WriteLine($"Near average: { mainCollection.NearAvg.ToString() }\n");

                Console.WriteLine("Vector2:");
                foreach (Vector2 v in mainCollection.Vectors)
                {
                    Console.WriteLine(v.ToString());
                }
            }
            catch (Exception ex)//4
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
