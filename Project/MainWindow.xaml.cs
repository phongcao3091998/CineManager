﻿using ProjectVideo.ViewModel;
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

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            this.Width = System.Windows.SystemParameters.WorkArea.Width;
            GridMain.Width = System.Windows.SystemParameters.WorkArea.Width;
            lvFilm.Height = this.Height - 127;
        }

        public MainWindow(string UserName)
        {
            InitializeComponent();
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            this.Width = System.Windows.SystemParameters.WorkArea.Width;
            GridMain.Width = System.Windows.SystemParameters.WorkArea.Width;
            if (UserName != null)
            {
                GuesInfo.Visibility = Visibility.Collapsed;
                if (UserName != "Admin")
                {
                    UserInfo.Visibility = Visibility.Visible;
                    txtFullName.Text = UserName;
                }
                else
                {
                    AdminInfo.Visibility = Visibility.Visible;
                }
            }
            lvFilm.Height = this.Height - 127;
        }
        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[0]);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[1]);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[2]);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            lvFilm.ScrollIntoView(lvFilm.Items[3]);
        }


        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //foreach (var grid in FindVisualChildren<Grid>(this))
            //{
            //    if (grid.Name == "GridInfo")
            //    {
            //        /*   Your code here  */
            //        grid.Visibility = Visibility.Visible;
            //    }
            //}
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            // handle click video move to form play film
            string pathVideo = "";
            var btnClick = (sender) as Button;
            foreach (var textblock in FindVisualChildren<TextBlock>(this))
            {
                if (textblock.Name == "tbVideoPath")
                {
                    if (textblock.Tag.ToString() == btnClick.Tag.ToString()) // search textblock contain ID film and compare with btnClick contain ID film
                    {                                                       // it mean is got the film is pressed
                        pathVideo = textblock.Text;
                        break;
                    }
                }
            }
            PlayVideoForm pvf = new PlayVideoForm(pathVideo, txtFullName.Text);
            pvf.ShowDialog();
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            View.UserInfo usf = new View.UserInfo();
            usf.ShowDialog();
        }

        private void AminTool_Click(object sender, RoutedEventArgs e)
        {
            View.AdminManager adm = new View.AdminManager();
            adm.ShowDialog();
        }

        private void btnMyPlayList_Click(object sender, RoutedEventArgs e)
        {
            MyplayList mpl = new MyplayList(txtFullName.Text);
            mpl.Show();

        }
    }
}
