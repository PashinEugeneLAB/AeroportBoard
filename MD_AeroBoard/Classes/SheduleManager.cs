using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_AeroBoard
{
    public static class ScheduleManager
    {
        public static System.Timers.Timer Clock = new System.Timers.Timer();
        public static long TaskTime = 0;
        public static ConcurrentQueue<ScheduleItem> CurrentScheduleList = new ConcurrentQueue<ScheduleItem>();
        public static ConcurrentQueue<ScheduleItem> FullScheduleList = new ConcurrentQueue<ScheduleItem>();
        public static int TaskTimeInterval = 100;
        public static int MenuPanelTimeInterval = 10;
        public static string TimeFormat = "HH:mm:ss";
        public static string StartTime = "00:00:00";
        public static string FullScreenText = "Полный экран";
        public static string NormalScreenText = "Обычный размер";

        public static string ShowSettings = "Показать параметры";
        public static string HideSettings = "Скрыть параметры";

        public static double LeftPanelWidthBeforeHide = 0;

        public static double CollapseWidthLeftPanel = 8;

        public static double MenuPanelMinWidth = 70;
        public static double MenuPanelMaxWidth = 200;
        public static double MenuPanelStep = 4;
        public static string GetStartTimeAsString(this ScheduleItem schItem)
        {
            string hour = schItem.StartTimeHour > 9 ? schItem.StartTimeHour.ToString() : $"0{schItem.StartTimeHour}";
            string minute = schItem.StartTimeMinute > 9 ? schItem.StartTimeMinute.ToString() : $"0{schItem.StartTimeMinute}";
            string second = schItem.StartTimeSecond > 9 ? schItem.StartTimeSecond.ToString() : $"0{schItem.StartTimeSecond}"; // Необязательный параметр

            return $"{hour}:{minute}";
        }
    }
}
