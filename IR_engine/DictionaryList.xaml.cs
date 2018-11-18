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
using System.Windows.Shapes;

namespace IR_engine
{
    /// <summary>
    /// Interaction logic for DictionaryList.xaml
    /// </summary>
    public partial class DictionaryList : Window
    {
        public DictionaryList(Dictionary<string, term> list)
        {
            InitializeComponent();
            dictionary.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            stack.HorizontalAlignment = HorizontalAlignment.Left;
            stack.VerticalAlignment = VerticalAlignment.Top;

            foreach(KeyValuePair<string, term> entery in list) {
                TextBox t = new TextBox();
                t.Text = entery.Value.Phrase + " " + entery.Value.printPosting();
                t.FontSize = 14;
                stack.Children.Add(t);
                
            }
        }


    }
}
