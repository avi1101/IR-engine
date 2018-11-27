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
        string path;
        string IndexPath;
        Model m;
        double time = 0;
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("START");
            path = "";
            IndexPath = "";
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
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            test.Content = "";
            if (path == null)
            {
                path = pathText.Text;
            }
            if (!path.Equals(""))
            {
                m = new Model(path, stem.IsChecked.Value, IndexPath);
                m.index();
            }
            else
                test.Content = "path not provided.";
            watch2.Stop();
            time = time + watch2.ElapsedMilliseconds;
            time = (time / 1000.0) / 60.0;
            Console.WriteLine("total run time = " + time);
            test.Content = time;
        }

        private void showDic_Click(object sender, RoutedEventArgs e)
        {
            Window dictionary;
            //if (path == null || path.Equals("") || !File.Exists(path+ "\\index_elad_avi.txt"))
            //    dictionary = new DictionaryList(null);
            //else
            //    dictionary = new DictionaryList(null);
            Dictionary<string, term> index = m.getDictionary();
            dictionary = new DictionaryList(index);
            dictionary.Show();
        }

        private void BrowseIndex_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
            }
        }
    }
}
