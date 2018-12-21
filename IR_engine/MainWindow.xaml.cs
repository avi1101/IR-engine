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
        string path = "";
        string IndexPath = "";
        Model m;
        bool isDictionaryStemmed;
        bool semantics;

        public MainWindow()
        {
            InitializeComponent();
            semantics = false;
            m = new Model();
            path = "";
            IndexPath = "";
            isDictionaryStemmed = false;
            test.Content = "Welcome to BarvazBarvazGo!\nPlease make sure you have internet connection.";
            model_CB.Items.Add("Select Model");
            model_CB.Items.Add("Costumize");
            model_CB.SelectedIndex = 0;
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
            Load_Index.Width = 100;
            Load_Index.Height = 100;
            Load_Index.Foreground = new SolidColorBrush(Colors.Black);
            Load_Index.FontSize = 12;
        }
        private void load_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Load_Index.Width = 110;
            Load_Index.Height = 110;
            Load_Index.Foreground = new SolidColorBrush(Colors.Red);
            Load_Index.FontSize = 13;
        }

        private void Search_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SearchBtn.Width = 100;
            SearchBtn.Height = 100;
            SearchBtn.Foreground = new SolidColorBrush(Colors.Red);
            SearchBtn.FontSize = 22;
        }

        private void SearchBtn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SearchBtn.Width = 90;
            SearchBtn.Height = 90;
            SearchBtn.Foreground = new SolidColorBrush(Colors.Black);
            SearchBtn.FontSize = 20;
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
                    isDictionaryStemmed = stem.IsChecked.Value;
                    var watch2 = System.Diagnostics.Stopwatch.StartNew();
                    m.IndexPath1 = IndexPath;
                    m.Path = path;
                    m.toStem = stem.IsChecked.Value;
                    Task.Factory.StartNew(()=>m.index());
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
                }
            }
            else
            {
                test.Content = "path not provided.";
                IndexPath = ""; path = "";
            }
        }

        private void showDic_Click(object sender, RoutedEventArgs e)
        {
            if (m == null)
            {
                test.Content = "You need to run the engine first";
                return;
            }
            if (Model.isWorking)
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            Dictionary<string, indexTerm> index = m.getDictionary();
            if (index.Count == 0)
            {
                test.Content = "No index was loaded.\nPlease load the index first";
                return;
            }
            if (isDictionaryStemmed != stem.IsChecked.Value)
            {
                string s = isDictionaryStemmed ? "is" : "isn't";
                test.Content = "The current loaded index " + s + " stemmed.\nin order to load the desired index,\nplease load it first by pressing the 'load index' button.";
                return;
            }
            Window dictionary;
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
            if (Model.isWorking)
            {
                test.Content = "Engine is working, please wait for a completion message to pop up";
                return;
            }
            if((IndexPathText.Text == "" && IndexPath.Equals("")))
            {
                test.Content = "No index path provided.\nPlease input a path to the index.txt file";
                return;
            }
            string ipt=null;
            if (stem.IsChecked.Value) {ipt = IndexPath.Equals("")? IndexPathText.Text + "\\EnableStem" : IndexPath + "\\EnableStem"; }
            else {ipt = IndexPath.Equals("") ? IndexPathText.Text + "\\DisableStem" : IndexPath + "\\DisableStem"; }
            if (!Directory.Exists(ipt) || !File.Exists(ipt+"\\index.txt"))
                test.Content = "No Index in path";
            else
            {
                isDictionaryStemmed = stem.IsChecked.Value;
                m.load_index(ipt);
                test.Content = "Index was succesfully loaded from the file:\n" + ipt + "\\index.txt";
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            if(m != null)
                m.Memorydump();
            if (IndexPath.Equals(""))
            {
                IndexPath = IndexPathText.Text;
            }
            if(IndexPath.Equals(""))
            {
                test.Content = "Memory cleared but posting and index directories\ndid not because there is no path to the directory.\nPlease insert an index directory path for the posting\nfiles to be cleaned.";
                return;
            }
            if (Directory.Exists(IndexPath + "\\DisableStem"))
            {
                Directory.Delete(IndexPath + "\\DisableStem", true);
            }
            if (Directory.Exists(IndexPath + "\\EnableStem"))
            {
                Directory.Delete(IndexPath + "\\EnableStem", true);
            }
            File.Delete(IndexPath + "\\city_dictionary.txt");
            File.Delete(IndexPath + "\\documents.txt");
        }

        private void browseQry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            semantics = semanticsCheckBox.IsChecked.Value;
            if (semantics)
                model_CB.IsEnabled = true;
            else
            {
                model_CB.IsEnabled = false;
                createModel.IsEnabled = false;
            }
        }

        private void model_CB_DropDownClosed(object sender, EventArgs e)
        {
            test.Content = model_CB.SelectedValue;
            if (model_CB.SelectedValue.Equals("Costumize"))
                createModel.IsEnabled = true;
            else
                createModel.IsEnabled = false;
        }
    }
}
