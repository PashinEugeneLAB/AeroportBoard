using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_AeroBoard
{
    public class ScheduleItem
    {
        public FlightType FlightType { get; set; } = FlightType.Unknown;
        public DirectionType DirectionType { get; set; } = DirectionType.Unknown;
        public CityType CityName { get; set; }
        public int StartTimeHour { get; set; }
        public int StartTimeMinute { get; set; }
        public int StartTimeSecond { get; set; } // Необязательный параметр
        public int DelayTimeHour { get; set; }
        public int DelayTimeMinute { get; set; }
        public int DelayTimeSecond { get; set; } // Необязательный параметр
        public int PassengersCount { get; set; }
        public int MaxPassengersCount { get; set; }

        public string GetStartTimeAsString()
        {
            string hour = StartTimeHour > 9 ? StartTimeHour.ToString() : $"0{StartTimeHour}";
            string minute = StartTimeMinute > 9 ? StartTimeMinute.ToString() : $"0{StartTimeMinute}";
            string second = StartTimeSecond > 9 ? StartTimeSecond.ToString() : $"0{StartTimeSecond}"; // Необязательный параметр

            return $"{hour}:{minute}";
        }
    }
}
