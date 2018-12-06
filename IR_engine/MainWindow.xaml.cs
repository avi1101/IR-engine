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
using System.ComponentModel;
using System.Diagnostics;

namespace IR_engine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private enum months { january, february, march, april, may, june, july, august, september, october, november, december };
        string path = "";
        string IndexPath = "";
        Model m;
        volatile int time = 1;
        volatile string stat = "";

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("START");
            //Model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            //{
            //    if (e.PropertyName == "STATUS")

            //};
            m = new Model();
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
        private void load_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Load_Index.Width = 82;
            Load_Index.Height = 82;
            Load_Index.Foreground = new SolidColorBrush(Colors.Black);
            Load_Index.FontSize = 12;
        }
        private void load_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Load_Index.Width = 85;
            Load_Index.Height = 85;
            Load_Index.Foreground = new SolidColorBrush(Colors.Red);
            Load_Index.FontSize = 13;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            if (Model.isWorking)
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog()) { if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    path = dialog.SelectedPath;
                }
            }
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if(Model.isWorking)
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            //var watch2 = System.Diagnostics.Stopwatch.StartNew();
            test.Content = "";
            if (path.Equals(""))
            {
                path = pathText.Text;
            }
            if (IndexPath.Equals(""))
            {
                IndexPath = IndexPathText.Text;
            }
            if (!path.Equals(""))
            {
                if (!Directory.Exists(IndexPath)) { test.Content = "Index path not a directory"; IndexPath = ""; path = ""; }
                else
                {
                    test.Content = "Working, please wait...";
                    var watch2 = System.Diagnostics.Stopwatch.StartNew();
                    Thread.Sleep(100);
                    //m = new Model(path, stem.IsChecked.Value, IndexPath);
                    m.IndexPath1 = IndexPath;
                    m.Path = path;
                    m.toStem = stem.IsChecked.Value;
                    m.index();
                    //Time();
                    var arrayOfAllKeys = ReadFile.Langs.Keys.ToArray();
                    string a = null;
                    foreach (string x in arrayOfAllKeys)
                    {
                        a = Model.cleanAll(x);
                        if (!a.Equals("") && !a.Equals(" "))
                            Language.Items.Add(a);
                    }
                    watch2.Stop();
                    double time =watch2.ElapsedMilliseconds;
                    time = (time / 1000.0);
                    Console.WriteLine("total run time = " + time + "sec");
                    test.Content = "Process took: "+time+"\n"+"We Indexed "+m.counter+" docs\n"+"We created "+m.indexList.Count+" terms";
                }
            }
            else
            {
                test.Content = "path not provided.";
                IndexPath = ""; path = "";
            }

            
        }

        //private void Time()
        //{
        //    TimeSpan ts = new TimeSpan();
        //    Stopwatch watch = new Stopwatch();

        //    while (Model.isWorking)
        //    {
        //        ts = watch.Elapsed;
        //        test.Content = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        //        Form.Lab.Invoke((MethodInvoker)delegate {
        //            // Running on the UI thread
        //            form.Label.Text = newText;
        //        });
        //        Thread.Sleep(1000);
        //    }
        //}

        private void showDic_Click(object sender, RoutedEventArgs e)
        {
            if (Model.isWorking)
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            if(m == null)
            {
                test.Content = "You need to run the engine first";
                return;
            }
            Window dictionary;
            //if (path == null || path.Equals("") || !File.Exists(path+ "\\index_elad_avi.txt"))
            //    dictionary = new DictionaryList(null);
            //else
            //    dictionary = new DictionaryList(null);
            Dictionary<string, indexTerm> index = m.getDictionary();
            test.Content = index.Count;
            dictionary = new DictionaryList(index);
            dictionary.Show();
        }

        private void BrowseIndex_Click(object sender, RoutedEventArgs e)
        {
            if (Model.isWorking)
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    IndexPath = dialog.SelectedPath;
                }
            }
        }

        private void Load_Index_Click(object sender, RoutedEventArgs e)
        {
            test.Content = "this may take a few minutes";
            if (Model.isWorking || (IndexPathText.Text == "" && IndexPath.Equals("")))
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            string ipt=null;
            if (stem.IsChecked.Value) {ipt = IndexPath.Equals("")? IndexPathText.Text + "\\EnableStem" : IndexPath + "\\EnableStem"; }
            else {ipt = IndexPath.Equals("") ? IndexPathText.Text + "\\DisableStem" : IndexPath + "\\DisableStem"; }
            if (!Directory.Exists(ipt) || !File.Exists(ipt+"\\index.txt"))
                test.Content = "No Index in path";
            else
            {
                m.load_index(ipt);
                test.Content = "Index was succesfully loaded from the file:\n" + ipt + "\\index.txt";
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            IndexPath = IndexPathText.Text;
            path = pathText.Text;
            if (Directory.Exists(IndexPath + "\\DisableStem"))
            {
                Directory.Delete(IndexPath + "\\DisableStem", true);
            }
            if (Directory.Exists(IndexPath + "\\EnableStem"))
            {
                Directory.Delete(IndexPath + "\\EnableStem", true);
            }
            if(Directory.Exists(path + "\\Posting_and_indexes"))
            {
                Directory.Delete(path + "\\Posting_and_indexes", true);
            }
            if (Directory.Exists(path + "\\cityIndex"))
            {
                Directory.Delete(path + "\\cityIndex", true);
            }
            File.Delete(path + "\\city_dictionary.txt");
            File.Delete(path + "\\documents.txt");
            File.Delete(path + "\\postingList.txt");
            m.Memorydump();
        }
    }
}
