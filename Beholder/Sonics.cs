using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messagesorting;

namespace sonics
{
    public class sonicCrackDetect
    {
        public void analyzeCracks(sonicDatagramImpl dataSonic)
        {
            Console.WriteLine(dataSonic.id + "; " + dataSonic.value);
        }
    }

}