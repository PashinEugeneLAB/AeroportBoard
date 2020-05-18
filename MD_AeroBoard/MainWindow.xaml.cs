//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace MD_AeroBoard
//{
//    / <summary>
//    / Логика взаимодействия для MainWindow.xaml
//    / </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MD_AeroBoard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ScheduleManager.Clock.Interval = ScheduleManager.TaskTimeInterval;

            ScheduleManager.Clock.Elapsed += (s, e) =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ScheduleManager.TaskTime += (long)(this.CardSelectTimeInterval.slider.Value * ScheduleManager.TaskTimeInterval);
                }));
                DateTimeOffset dto = DateTimeOffset.FromUnixTimeMilliseconds(ScheduleManager.TaskTime);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.DateTimeValue.Text = dto.ToString(ScheduleManager.TimeFormat).ToString();
                }));
            };

            FlightsManager.FlightsGeneration();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            FromMaxToMinWidth();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            FromMinToMaxWidth();
        }

        private void TitleT_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {

            }
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        UIElement FindUid(DependencyObject parent, string uid)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < count; i++)
            {
                var el = VisualTreeHelper.GetChild(parent, i) as UIElement;
                if (el == null) continue;

                if (el.Uid == uid) return el;

                el = FindUid(el, uid);
                if (el != null) return el;
            }

            if (parent is ContentControl)
            {
                UIElement content = (parent as ContentControl).Content as UIElement;
                if (content != null)
                {
                    if (content.Uid == uid) return content;

                    var el = FindUid(content, uid);
                    if (el != null) return el;
                }
            }
            return null;
        }

        private void btn_Click(object sender, KeyEventArgs e)
        {
            // Определение текущего индекса кнопки
            int index = int.Parse(((System.Windows.Controls.Button)e.Source).Uid);

            foreach (ColumnDefinition cd in GridL.ColumnDefinitions)
                cd.Width = new GridLength(0);

            GridL.ColumnDefinitions[index].Width = new GridLength(ScheduleManager.MenuPanelMaxWidth, GridUnitType.Star);
        }

        private void MenuButton_Click(object sender, MouseButtonEventArgs e)
        {
            // Определение текущего индекса кнопки
            int index = 0;
            try
            {
                index = int.Parse(((System.Windows.Controls.ListViewItem)e.Source).Uid);
            }
            catch { }
            try
            {
                index = int.Parse(((MaterialDesignThemes.Wpf.PackIcon)e.Source).Uid);
            }
            catch { }
            try
            {
                index = int.Parse(((System.Windows.Controls.StackPanel)e.Source).Uid);
            }
            catch { }
            try
            {
                index = int.Parse(((System.Windows.Controls.TextBlock)e.Source).Uid);
            }
            catch { }


            string needIndex = new string(index.ToString().Take(3).ToArray());
            Console.WriteLine($"Menu button [{(FindUid(this.GridMenu, needIndex) as System.Windows.Controls.TextBlock).Text}] was clicked!");

            foreach (ColumnDefinition cd in GridL.ColumnDefinitions)
                cd.Width = new GridLength(0);

            int newIndex = int.Parse(needIndex);

            GridL.ColumnDefinitions[newIndex - 100].Width = new GridLength(ScheduleManager.MenuPanelMaxWidth, GridUnitType.Star);
        }

        private void ButtonCollapse_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonFullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.FullSizeButton.Content = ScheduleManager.NormalScreenText;
            }
            else
            {
                this.FullSizeButton.Content = ScheduleManager.FullScreenText;
            }
        }

        private void TB_PlayStop_Checked(object sender, RoutedEventArgs e)
        {
            GlobalParameters.IsChecked = !GlobalParameters.IsChecked;
            TaskChecking();
        }

        void TaskChecking()
        {
            if (GlobalParameters.IsChecked == true)
            {
                TB_PlayStop.IsChecked = true;
                TB_PlayStopPopUp.IsChecked = true;

                SolidColorBrush br = new SolidColorBrush();
                br.Color = Color.FromArgb(255, 255, 114, 1);
                this.TB_PlayStop.Background = br;
                this.TB_PlayStopPopUp.Background = br;
                this.DateTimeValue.Visibility = Visibility.Visible;
                this.DateTimeValue.Text = ScheduleManager.StartTime;
                ScheduleManager.TaskTime = 0;
                ScheduleManager.Clock.Start();
            }
            else if (GlobalParameters.IsChecked == false)
            {
                TB_PlayStop.IsChecked = false;
                TB_PlayStopPopUp.IsChecked = false;

                SolidColorBrush br = new SolidColorBrush();
                br.Color = Colors.YellowGreen;
                this.TB_PlayStop.Background = br;
                this.TB_PlayStopPopUp.Background = br;
                //this.DateTimeValue.Visibility = Visibility.Hidden;
                this.DateTimeValue.Visibility = Visibility.Visible;
                this.DateTimeValue.Text = "- - : - - : - -";
                ScheduleManager.Clock.Stop();
            }
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsButton.Content.ToString() == ScheduleManager.ShowSettings)
            {
                GridMain.ColumnDefinitions[0].Width = new GridLength(ScheduleManager.LeftPanelWidthBeforeHide);

                //LeftPanel.Visibility = Visibility.Visible;
                OptionsButton.Content = ScheduleManager.HideSettings;

                //GridMain.ColumnDefinitions[0].Width = new GridLength(ScheduleManager.MenuPanelMinWidth);
                //FromMinToMaxWidth();
            }
            else
            {
                //LeftPanel.Visibility = Visibility.Hidden;
                OptionsButton.Content = ScheduleManager.ShowSettings;

                //FromMaxToMinWidth();



                //FromMinToZeroWidth();
                ScheduleManager.LeftPanelWidthBeforeHide = GridMain.ColumnDefinitions[0].Width.Value;
                GridMain.ColumnDefinitions[0].Width = new GridLength(ScheduleManager.CollapseWidthLeftPanel);


            }
        }

        void FromZeroToMinWidth()
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            //btnOpenMenu.Width = 60;


            var tsk = Task.Run(() =>
            {
                System.Timers.Timer t = new System.Timers.Timer();
                t.Interval = ScheduleManager.MenuPanelTimeInterval;
                t.Elapsed += (ss, ee) =>
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (GridMain.ColumnDefinitions[0].Width.Value > 8)
                        {
                            try
                            {
                                GridMain.ColumnDefinitions[0].Width = new GridLength(GridMain.ColumnDefinitions[0].Width.Value - ScheduleManager.MenuPanelStep);
                            }
                            catch
                            {
                                GridMain.ColumnDefinitions[0].Width = new GridLength(8);
                            }
                            Console.WriteLine(GridMain.ColumnDefinitions[0].Width.Value);
                        }
                        else
                        {
                            t.Stop();
                            GridMain.ColumnDefinitions[0].Width = new GridLength(8);
                            t.Dispose();
                        }
                    }));
                };
                t.Start();
            });
        }

        void FromMaxToMinWidth()
        {

            btnCloseMenu.Visibility = Visibility.Collapsed;
            btnOpenMenu.Visibility = Visibility.Visible;

            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = ScheduleManager.MenuPanelTimeInterval;
            t.Elapsed += (ss, ee) =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    if (GridMain.ColumnDefinitions[0].Width.Value > ScheduleManager.MenuPanelMinWidth)
                    {
                        GridMain.ColumnDefinitions[0].Width = new GridLength(GridMain.ColumnDefinitions[0].Width.Value - ScheduleManager.MenuPanelStep);
                        Console.WriteLine(GridMain.ColumnDefinitions[0].Width.Value);
                    }
                    else
                    {
                        t.Stop();
                        GridMain.ColumnDefinitions[0].Width = new GridLength(ScheduleManager.MenuPanelMinWidth);
                        btnCloseMenu.Visibility = Visibility.Collapsed;
                        btnOpenMenu.Visibility = Visibility.Visible;
                        t.Dispose();
                    }
                }));

            };

            t.Start();
        }

        void FromMinToMaxWidth()
        {
            btnCloseMenu.Visibility = Visibility.Visible;
            btnOpenMenu.Visibility = Visibility.Collapsed;

            var tsk = Task.Run(() =>
            {
                System.Timers.Timer t = new System.Timers.Timer();
                t.Interval = ScheduleManager.MenuPanelTimeInterval;
                t.Elapsed += (ss, ee) =>
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (GridMain.ColumnDefinitions[0].Width.Value < ScheduleManager.MenuPanelMaxWidth)
                        {
                            GridMain.ColumnDefinitions[0].Width = new GridLength(GridMain.ColumnDefinitions[0].Width.Value + ScheduleManager.MenuPanelStep);
                            Console.WriteLine(GridMain.ColumnDefinitions[0].Width.Value);
                        }
                        else
                        {
                            t.Stop();
                            GridMain.ColumnDefinitions[0].Width = new GridLength(ScheduleManager.MenuPanelMaxWidth);
                            t.Dispose();
                        }
                    }));
                };
                t.Start();
            });
        }


        void FromMinToZeroWidth()
        {
            btnCloseMenu.Visibility = Visibility.Collapsed;
            btnOpenMenu.Visibility = Visibility.Collapsed;

            var tsk = Task.Run(() =>
            {
                System.Timers.Timer t = new System.Timers.Timer();
                t.Interval = ScheduleManager.MenuPanelTimeInterval;
                t.Elapsed += (ss, ee) =>
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (GridMain.ColumnDefinitions[0].Width.Value < ScheduleManager.MenuPanelMinWidth)
                        {
                            try
                            {
                                GridMain.ColumnDefinitions[0].Width = new GridLength(GridMain.ColumnDefinitions[0].Width.Value + ScheduleManager.MenuPanelStep);
                            }
                            catch { }
                            Console.WriteLine(GridMain.ColumnDefinitions[0].Width.Value);
                        }
                        else
                        {
                            t.Stop();
                            GridMain.ColumnDefinitions[0].Width = new GridLength(ScheduleManager.MenuPanelMinWidth);
                            //btnOpenMenu.Visibility = Visibility.Visible;
                            t.Dispose();
                        }
                    }));
                };
                t.Start();
            });
        }
    }
}