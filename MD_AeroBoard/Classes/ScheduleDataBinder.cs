using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MD_AeroBoard
{
    public class ScheduleListDataSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is ScheduleItem)
            {
                var taskitem = (ScheduleItem)item;
                var window = Application.Current.Windows[0]; // MainWindow;
                if (taskitem.FlightType == FlightType.Unknown)
                    return window.FindResource("ScheduleArrival") as DataTemplate;
                else
                    return window.FindResource("ScheduleDeparture") as DataTemplate;
            }

            return null;
        }
    }


    //public class Measures : ObservableCollection<MeasureResult>
    //{

    //    public Measures()
    //    {
    //        Bitmap b1 = UsingTaskListDataTemplateSelector.Properties.Resources._2;
    //        Bitmap b2 = UsingTaskListDataTemplateSelector.Properties.Resources._3;

    //        Add(new MeasureResult()
    //        {
    //            taskCurrentFrameDone = 1,
    //            taskFramesCount = 3,
    //            taskImage = ConvertToBitmapImage(b1),
    //            taskNum = 1,
    //            taskRecognizedItemsCount = 44,
    //            taskRegionsCount = 44,
    //            taskTimeElapse = 2400,
    //            type = MeasureResultType.OK
    //        });

    //        Add(new MeasureResult()
    //        {
    //            taskCurrentFrameDone = 1,
    //            taskFramesCount = 3,
    //            taskImage = ConvertToBitmapImage(b2),
    //            taskNum = 2,
    //            taskRecognizedItemsCount = 43,
    //            taskRegionsCount = 44,
    //            taskTimeElapse = 6400,
    //            type = MeasureResultType.NG
    //        });
    //    }

    //}

}
