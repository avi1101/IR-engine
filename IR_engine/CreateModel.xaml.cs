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
    /// Interaction logic for CreateModel.xaml
    /// </summary>
    public partial class CreateModel : Window
    {
        public CreateModel()
        {
            InitializeComponent();
            Label l = new Label();
            l.Content = "- Please note that training a model takes a much longer than the engine.\n"
                + "- a reminder that we included a pre-trained models, you may use them.\n"
                + "- Default values are recommended, it may take time even so.\n"
                + "- If you wish to train a model note that efficient training requires values that\n"
                + "  may cause the training proccess to take too long";
            gb.Content = l;
        }
    }
}
