using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MD_AeroBoard
{
    /// <summary>
    /// Логика взаимодействия для ucChoiceFile.xaml
    /// </summary>
    public partial class ucChoiceFile : System.Windows.Controls.UserControl
    {
        public ucChoiceFile()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new  OpenFileDialog();
            ofd.Filter = "Файлы рейсов (*.xml)|*.xml";

            DialogResult dr = ofd.ShowDialog();

            if (dr== DialogResult.OK)
            {
                this.SourceFile.Text = ofd.FileName;
            }
        }
    }
}
