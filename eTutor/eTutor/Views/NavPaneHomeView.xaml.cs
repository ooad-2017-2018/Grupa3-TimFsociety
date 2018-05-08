using eTutor.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace eTutor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavPaneHomeView : Page
    {
        public NavPaneHomeView()
        {
            this.InitializeComponent();
            content_frame.Navigate(typeof(DashboardView));
            BackButton.Visibility = Visibility.Collapsed;
            TitleTextBlock.Text = "Dashboard";
            Dashboard.IsSelected = true;
            if (NavPaneHomeViewModel.isUserStudent())
            {
                AddCourse.Visibility = Visibility.Collapsed;
            }
            else
            {
                SearchCourse.Visibility = Visibility.Collapsed;
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            nav_pane_split_view.IsPaneOpen = !nav_pane_split_view.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (content_frame.CanGoBack)
            {
                content_frame.GoBack();
                Dashboard.IsSelected = true;
            }
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dashboard.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;
                content_frame.Navigate(typeof(DashboardView));
                TitleTextBlock.Text = "Dashboard";
            }
            else if (EditAccountInfo.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                content_frame.Navigate(typeof(EditAccountView));
                TitleTextBlock.Text = "Edit account information";
            }
            else if(SearchCourse.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                content_frame.Navigate(typeof(SearchCoursesView));
                TitleTextBlock.Text = "Search Courses";
            }
            else if(AddCourse.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                content_frame.Navigate(typeof(AddCourseView));
                TitleTextBlock.Text = "Add Course";

            }
            else if(Feedback.IsSelected)
            {
                //implement feedback
            }
        }

    }
}
