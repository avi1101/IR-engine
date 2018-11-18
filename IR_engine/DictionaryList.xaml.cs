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
        public DictionaryList(List<Tuple<string, string>> list)
        {
            InitializeComponent();
            dictionary.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            stack.HorizontalAlignment = HorizontalAlignment.Left;
            stack.VerticalAlignment = VerticalAlignment.Top;

            for (int i = 0; i < 400; i++) {
                TextBox t = new TextBox();
                t.Text = "line " + i + "dfdfsdfdsfdsfsdfsdfsdfdsfsdfsdfsdfsdfsdfdsfdsf";
                t.FontSize = 24;
                stack.Children.Add(t);
                
            }
        }


    }
}
