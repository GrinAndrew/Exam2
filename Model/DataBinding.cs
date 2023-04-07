using Exam2.Model;
using Exam2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Exam2.Model
{
    public class DataBinding : INotifyPropertyChanged
    {
        #region LISTS
        private List<Users> allUsers = DBManager.GetAllUsers();
        public List<Users> AllUsers {
            get { return allUsers; }
            set {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }

        private List<Applications> allApplications = DBManager.GetAllApplications();
        public List<Applications> AllApplications {
            get { return allApplications; }
            set {
                allApplications = value;
                NotifyPropertyChanged("AllApplications");
            }
        }
        private List<Comments> allComments = DBManager.GetAllComments();

        public List<Comments> AllComments {
            get { return allComments; }
            set {
                allComments = value;
                NotifyPropertyChanged("AllComments");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region OPEN WINDOWS
        private Events openeditItem;
        public Events OpenEditItem
        {
            get
            {
                return openeditItem ?? new Events(obj =>
                {
                    int result = 0;
                    if (SelectedTabItem.Name == "CommentsTab" && SelectedComment != null)
                    {
                        OpenEditCommentWindow(SelectedComment);
                    }

                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)
                    {
                        OpenEditUserWindow(SelectedUser);
                    }

                    if (SelectedTabItem.Name == "AppTab" && SelectedApp != null)
                    {
                        OpenEditAppWindow(SelectedApp);
                    }

                    UpdateAllView();
                    InitPropsValues();

                });
            }
        }

        private void ShowMsgBoxWindow(string MsgText)
        {
            MsgBox newMsgWindow = new MsgBox(MsgText);
            newMsgWindow.Owner = Application.Current.MainWindow;
            newMsgWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            newMsgWindow.ShowDialog();

        }
        private void OpenAddNewCommentWindow()
        {
            AddNewComment newCommentWindow = new AddNewComment();
            newCommentWindow.Owner = Application.Current.MainWindow;
            newCommentWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            newCommentWindow.ShowDialog();

        }
        private void OpenAddNewUserWindow()
        {
            AddNewUser newUserWindow = new AddNewUser();
            newUserWindow.Owner = Application.Current.MainWindow;
            newUserWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            newUserWindow.ShowDialog();
        }

        private void OpenAddNewAppWindow()
        {
            AddNewApp newAppWindow = new AddNewApp();
            newAppWindow.Owner = Application.Current.MainWindow;
            newAppWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            newAppWindow.ShowDialog();
        }
        #endregion

        # region OPEN COMMANDS
        private Events openAddNewComment;
        public Events OpenAddNewComment
        {
            get
            {
                return openAddNewComment ?? new Events(obj => { OpenAddNewCommentWindow(); });
            }

        }
        private Events openAddNewUser;

        public Events OpenAddNewUser
        {
            get
            {
                return openAddNewUser ?? new Events(obj => { OpenAddNewUserWindow(); });
            }

        }

        private Events openAddNewApp;
        public Events OpenAddNewApp
        {
            get
            {
                return openAddNewApp ?? new Events(obj => { OpenAddNewAppWindow(); });
            }
        }

        private Events msgBoxWindow;

        public Events MsgBoxWindow(string TextMsg)
        {
            return msgBoxWindow ?? new Events(obj => { ShowMsgBoxWindow(TextMsg); });
        }

        private void OpenEditUserWindow(Users userToEdit)
        {
            EditUser editUserWindow = new EditUser(userToEdit);
            editUserWindow.Owner = Application.Current.MainWindow;
            editUserWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            editUserWindow.ShowDialog();
        }
        private void OpenEditAppWindow(Applications appToEdit)
        {
            EditApp editAppWindow = new EditApp(appToEdit);
            editAppWindow.Owner = Application.Current.MainWindow;
            editAppWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            editAppWindow.ShowDialog();
        }
        private void OpenEditCommentWindow(Comments commentToEdit)
        {
            EditComment editCommentWindow = new EditComment(commentToEdit);
            editCommentWindow.Owner = Application.Current.MainWindow;
            editCommentWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            editCommentWindow.ShowDialog();
        }
        #endregion

        #region UPDATE LIST
        private void UpdateAllView()
        {
            UpdateAllCommentsView();
            UpdateAllUsersView();
            UpdateAllAppView();

        }
        private void UpdateAllUsersView()
        {
            AllUsers = DBManager.GetAllUsers();
            MainWindow.AllUsersView.ItemsSource = null;
            MainWindow.AllUsersView.Items.Clear();
            MainWindow.AllUsersView.ItemsSource = AllUsers;
            MainWindow.AllUsersView.Items.Refresh();

        }

        private void UpdateAllAppView()
        {
            AllApplications = DBManager.GetAllApplications();
            MainWindow.AllAppView.ItemsSource = null;
            MainWindow.AllAppView.Items.Clear();
            MainWindow.AllAppView.ItemsSource = AllApplications;
            MainWindow.AllAppView.Items.Refresh();

        }
        private void UpdateAllCommentsView()
        {
            AllComments = DBManager.GetAllComments();
            MainWindow.AllCommentsView.ItemsSource = null;
            MainWindow.AllCommentsView.Items.Clear();
            MainWindow.AllCommentsView.ItemsSource = AllComments;
            MainWindow.AllCommentsView.Items.Refresh();

        }
        #endregion

        #region COMMON
        public static string? UserName { get; set; }
        public static string? AppName { get; set; }

        public static string? CommentText { get; set; }
        public static Applications? CommentApp { get; set; }
        public static Users? CommentUser { get; set; }
        public static Comments SelectedComment { get; set; }
        public static Users SelectedUser { get; set; }
        public static Applications SelectedApp { get; set; }
        public static TabItem SelectedTabItem { get; set; }

        private void InitPropsValues()
        {
            UserName = null;
            AppName = null;
            CommentText = null;
            CommentApp = null;
            CommentUser = null;
        }
        public void SetBorderRed(Window wnd, string ControlName)
        {
            Control ctrl = wnd.FindName(ControlName) as Control;
            ctrl.BorderBrush = Brushes.Red;
        }
        public void SetBorderBlack(Window wnd, string ControlName)
        {
            Control ctrl = wnd.FindName(ControlName) as Control;
            ctrl.BorderBrush = Brushes.Black;
        }
        #endregion

        #region ADD COMMANDS        
        private Events addNewUser;

        public Events AddNewUser
        {
            get
            {
                return addNewUser ?? new Events(obj =>
                {
                    int Result = 0;
                    Window wnd = (Window)obj;
                    if (UserName == "" | UserName == null)
                    {
                        SetBorderRed(wnd, "txtUserName");
                    }
                    else
                    {
                        Result = DBManager.CreateUser(UserName);
                        if (Result == 1)
                        {
                            ShowMsgBoxWindow("Add new User");
                            UpdateAllView();
                        }
                        else
                            ShowMsgBoxWindow("Error on add new User");

                        InitPropsValues();
                        wnd.Close();

                    }
                });
            }

        }

        private Events addNewApp;
        public Events AddNewApp
        {
            get
            {
                return addNewApp ?? new Events(obj =>
                {
                    int Result = 0;
                    Window wnd = (Window)obj;
                    if (AppName == "" | AppName == null)
                    {
                        SetBorderRed(wnd, "txtAppName");
                    }
                    else
                    {
                        Result = DBManager.CreateApplication(AppName);
                        if (Result == 1)
                        {
                            ShowMsgBoxWindow("Add new Application");
                            UpdateAllView();
                        }
                        else
                            ShowMsgBoxWindow("Error on add new Application");

                        InitPropsValues();
                        wnd.Close();
                    }

                });
            }

        }
        private Events addNewComment;
        public Events AddNewComment
        {
            get
            {
                return addNewComment ?? new Events(obj =>
                {
                    int Result = 0;
                    Window wnd = (Window)obj;
                    if (CommentText == "" | CommentText == null)
                    {
                        SetBorderRed(wnd, "txtComment");
                        Result = -1;
                    }
                    else
                        SetBorderBlack(wnd, "txtComment");

                    if (CommentApp == null)
                    {
                        SetBorderRed(wnd, "AppCombo");
                        Result = -1;
                    }

                    if (CommentUser == null)
                    {
                        SetBorderRed(wnd, "UserCombo");
                        Result = -1;
                    }

                    if (Result == 0)
                    {
                        Result = DBManager.CreateComment(CommentText, CommentUser, CommentApp);
                        if (Result == 1)
                        {
                            ShowMsgBoxWindow("Add new Comment");
                            UpdateAllView();
                        }
                        else
                            ShowMsgBoxWindow("Error on add new Comment");

                        InitPropsValues();
                        wnd.Close();
                    }


                });
            }

        }
        #endregion
        #region DEL COMMANDS
        public Events deleteItem;
        public Events DeleteItem
        {
            get
            {
                return deleteItem ?? new Events(obj =>
                {
                    int result = 0;
                    if (SelectedTabItem.Name == "CommentsTab" && SelectedComment != null)
                    {
                        DBManager.DeleteComment(SelectedComment);
                        result = 1;
                    }

                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)
                    {
                        DBManager.DeleteUser(SelectedUser);
                        result = 1;
                    }

                    if (SelectedTabItem.Name == "AppTab" && SelectedApp != null)
                    {
                        DBManager.DeleteApplication(SelectedApp);
                        result = 1;
                    }

                    if (result == 1)
                    {
                        UpdateAllView();
                        InitPropsValues();
                        ShowMsgBoxWindow("Deleted succesifully");
                    }
                }
                );

            }
        }
        #endregion
        #region EDIT COMMANDS
        private Events editUser;
        public Events EditUser
        {
            get 
            {
                return editUser ?? new Events(obj =>
                {
                    Window wnd = (Window)obj;
                    int result = 0;

                    if(SelectedUser != null && UserName != "" && UserName != null)
                    {
                        result = DBManager.EditeUser(SelectedUser, UserName);
                        if (result == 1)
                        {
                            UpdateAllAppView();
                            ShowMsgBoxWindow("User update");
                            wnd.Close();
                        }
                        InitPropsValues();

                    }
                }
                );
            }
        }

        private Events editApp;
        public Events EditApp
        {
            get
            {
                return editApp ?? new Events(obj =>
                {
                    Window wnd = (Window)obj;
                    int result = 0;

                    if (SelectedApp != null && AppName != "" && AppName != null)
                    {
                        result = DBManager.EditApplication(SelectedApp, AppName);
                        if (result == 1)
                        {
                            UpdateAllAppView();
                            ShowMsgBoxWindow("Application update");
                            wnd.Close();
                        }
                        InitPropsValues();

                    }
                }
                );
            }
        }

        private Events editComment;
        public Events EditComment
        {
            get
            {
                return editComment ?? new Events(obj =>
                {
                    Window wnd = (Window)obj;
                    int result = 0;

                    if (SelectedComment != null && 
                        CommentApp != null && 
                        CommentApp != null &&
                        CommentText != "")
                    {
                        result = DBManager.EditComment(SelectedComment, CommentApp, CommentUser, CommentText);
                        if (result == 1)
                        {
                            UpdateAllAppView();
                            ShowMsgBoxWindow("Comment update");
                            wnd.Close();
                        }
                        InitPropsValues();

                    }
                }
                );
            }
        }


        #endregion
    }
}
