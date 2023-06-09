﻿using System;
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
using Exam2.Model;

namespace Exam2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllUsersView;
        public static ListView AllAppView;
        public static ListView AllCommentsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataBinding();

            AllUsersView = UsersListView;
            AllAppView = AppListView;
            AllCommentsView = CommentsListView;           

        }

        private void Tab_Loaded(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 0;
        }
    }
}
