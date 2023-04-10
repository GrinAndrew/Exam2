using Exam2.Model;
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

namespace Exam2.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewComment.xaml
    /// </summary>
    public partial class AddNewComment : Window
    {
        public AddNewComment()
        {
            InitializeComponent();
            DataContext = new DataBinding();
        }

    }
}
