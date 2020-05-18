using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_AeroBoard
{
    public static class GlobalParameters
    {
        public static long TimeArrival { get; set; } = 10 * 60 * 60;
        public static long TimeInPlane { get; set; } = 20 * 60 * 60;
        public static long TimeDelay { get; set; } = 30 * 60 * 60;
        public static bool IsChecked { get; set; } = false;
    }
}
