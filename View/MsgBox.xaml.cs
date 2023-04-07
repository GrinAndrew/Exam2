
using System.Windows;


namespace Exam2.View
{
    /// <summary>
    /// Логика взаимодействия для MessageBox.xaml
    /// </summary>
    public partial class MsgBox : Window
    {
        public MsgBox(string MsgPrompt)
        {
            InitializeComponent();
            MsgText.Text = MsgPrompt;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
