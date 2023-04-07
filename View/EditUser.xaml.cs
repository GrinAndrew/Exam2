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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser(Users userToEdit)
        {
            InitializeComponent();
            DataContext = new DataBinding();
            DataBinding.SelectedUser = userToEdit;
            DataBinding.UserName = userToEdit.Name;
        }
    }
}
