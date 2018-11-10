using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace IR_engine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum months { january, february, march, april, may, june, july, august, september, october, november, december };
        string path=null;
        public MainWindow()
        {
            InitializeComponent();
            

        }

        /// <summary>
        /// mouse enter event for the RUN button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Run.Width = 110;
            Run.Height = 110;
            Run.Foreground = new SolidColorBrush(Colors.Red);
            Run.FontSize = 38;
        }
        /// <summary>
        /// mouse leave event for the RUN button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Run.Width = 100;
            Run.Height = 100;
            Run.Foreground = new SolidColorBrush(Colors.Black);
            Run.FontSize = 36;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog()) { if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    path = dialog.SelectedPath;
                }
            }
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (path == null)
            {
                
            }
            else
            {
                Model m = new Model(path,false);
            }

        }
    }
}
