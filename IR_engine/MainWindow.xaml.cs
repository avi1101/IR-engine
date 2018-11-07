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

namespace IR_engine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// mouse enter event for the RUN button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_MouseEnter(object sender, MouseEventArgs e)
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
        private void Run_MouseLeave(object sender, MouseEventArgs e)
        {
            Run.Width = 100;
            Run.Height = 100;
            Run.Foreground = new SolidColorBrush(Colors.Black);
            Run.FontSize = 36;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
