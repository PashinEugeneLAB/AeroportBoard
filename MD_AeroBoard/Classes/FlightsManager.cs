using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_AeroBoard
{
    public static class FlightsManager
    {
        public static Dictionary<FlightType, int> FlightTypeMaxPassengersCount = new Dictionary<FlightType, int>();

        public static void LoadFlightTypeMaxPassengersCount()
        {
            lock (FlightTypeMaxPassengersCount)
            {
                FlightTypeMaxPassengersCount.Clear();

                FlightTypeMaxPassengersCount.Add(FlightType.TU134, 96);
                FlightTypeMaxPassengersCount.Add(FlightType.TU154, 158);
                FlightTypeMaxPassengersCount.Add(FlightType.TU154E, 180);
                FlightTypeMaxPassengersCount.Add(FlightType.TU204, 214);
                FlightTypeMaxPassengersCount.Add(FlightType.SSJ95, 86);
                FlightTypeMaxPassengersCount.Add(FlightType.SSJ95LR, 96);
                FlightTypeMaxPassengersCount.Add(FlightType.IL62, 198);
                FlightTypeMaxPassengersCount.Add(FlightType.IL86, 314);
                FlightTypeMaxPassengersCount.Add(FlightType.IL96, 300);
                FlightTypeMaxPassengersCount.Add(FlightType.IL96M, 435);
                FlightTypeMaxPassengersCount.Add(FlightType.Aerobus310, 183);
                FlightTypeMaxPassengersCount.Add(FlightType.Aerobus320, 149);
                FlightTypeMaxPassengersCount.Add(FlightType.Aerobus330, 440);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing7376, 122);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing7377, 140);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing7378, 175);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing7379ER, 192);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing747, 370);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing767, 252);
                FlightTypeMaxPassengersCount.Add(FlightType.Boeing777, 235);
                FlightTypeMaxPassengersCount.Add(FlightType.Embraer170, 78);
            }
        }

        public static void FlightsGeneration()
        {
            FlightsManager.LoadFlightTypeMaxPassengersCount();

            Random rnd = new Random();
            int FlightCount = rnd.Next(1000, 3000);
            Console.WriteLine(FlightCount);
            for (int i = 0; i < FlightCount; i++)
            {
                int FlightTypeNumber = rnd.Next(1, 22);
                FlightType ft = (FlightType)Enum.GetValues(typeof(FlightType)).GetValue(FlightTypeNumber);

                int MaxPassengersInPlane = 0;
                FlightsManager.FlightTypeMaxPassengersCount.TryGetValue(ft, out MaxPassengersInPlane);
                Console.WriteLine($"{ft.ToString()} - {MaxPassengersInPlane}");

                int TimeHour = rnd.Next(0, 24);
                int TimeMinute = rnd.Next(0, 60);

                int CityNumber = rnd.Next(1, 17);
                CityType cn = (CityType)Enum.GetValues(typeof(CityType)).GetValue(CityNumber);

                int DirectionNumber = rnd.Next(1, 3);
                DirectionType dt = (DirectionType)Enum.GetValues(typeof(DirectionType)).GetValue(DirectionNumber);

                ScheduleItem si = new ScheduleItem();
                si.CityName = cn;
                si.DelayTimeHour = 0;
                si.DelayTimeMinute = 0;
                si.DelayTimeSecond = 0;

                si.DirectionType = dt;
                si.FlightType = ft;
                si.StartTimeHour = TimeHour;
                si.StartTimeMinute = TimeMinute;
                si.StartTimeSecond = 0;

                int AbsentPassengersCount = rnd.Next(1, MaxPassengersInPlane / 3); ;
                si.PassengersCount = MaxPassengersInPlane - AbsentPassengersCount;
                si.MaxPassengersCount = MaxPassengersInPlane;

                ScheduleManager.FullScheduleList.Enqueue(si);
            }

        }
    }
}
