
using System.Windows;


namespace Exam2.View
{
    /// <summary>
    /// Логика взаимодействия для MessageBox.xaml
    /// </summary>
    public partial class MsgBoxOKCancel : Window
    {
        private string messageBoxTitle;
        private int msgBoxReturn = 0;
        public string MessageBoxTitle 
        {
            get 
            { 
                return messageBoxTitle; 
            } 
        }
        public int MsgBoxReturn
        {
            get
            {
                return msgBoxReturn;
            }
        }

        public MsgBoxOKCancel(string MsgPrompt, string MsgTitle)
        {
            InitializeComponent();
            this.Title = MsgTitle;
            MsgText.Text = MsgPrompt;
            messageBoxTitle = MsgTitle;
        }
        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            msgBoxReturn = 1;
            this.Close();
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            msgBoxReturn = 0;
            this.Close();
        }

    }
}
