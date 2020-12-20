using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Lab1_V2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //1
            try
            {
                /* Файл региона по умолчанию - 'def-infofile ', 
                 * и можно автоматически выбрать'Russia'-'ru-RU'или 'China' - 'zh-CN'
                 * в зависимости от версии хост - системы.
                 */
                V2DataOnGrid grid = new V2DataOnGrid($"..\\..\\..\\def-infofile.txt");

                CultureInfo CI = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
                CultureInfo CIen = new CultureInfo("en-US");
                CultureInfo CIru = new CultureInfo("ru-RU");
                CultureInfo CIzh = new CultureInfo("zh-CN");

                if ((CI == CIru) || (CI == CIzh))
                    grid = new V2DataOnGrid($"..\\..\\..\\{CI}-infofile.txt");

                Console.WriteLine($"Local OS version is : {System.Threading.Thread.CurrentThread.CurrentCulture.DisplayName} \nOpen info file is '{CI}-infofile.txt'");

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
