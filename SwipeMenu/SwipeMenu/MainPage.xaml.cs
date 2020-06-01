using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeMenu
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMenu = GetMenus();
            this.BindingContext = this;
        }

        public List<Menu> MyMenu { get; set; }

        private List<Menu> GetMenus()
        {
            return new List<Menu>
            {
                new Menu{ Name = "Home", Icon = "home.png"},
                new Menu{ Name = "Profile", Icon = "user.png"},
                new Menu{ Name = "Notifications", Icon = "bell.png"},
                new Menu{ Name = "Messages", Icon = "envelope.png"},
                new Menu{ Name = "My Tasks", Icon = "tasks.png"},
            };
        }

        private async void OpenAnimation()
        {
            await swipeContent.ScaleYTo(0.9, 300, Easing.SinOut);
            pancake.CornerRadius = 20;
            await swipeContent.RotateTo(-15, 300, Easing.SinOut);
        }

        private async void CloseAnimation()
        {
            await swipeContent.RotateTo(0, 300, Easing.SinOut);
            pancake.CornerRadius = 0;
            await swipeContent.ScaleYTo(1, 300, Easing.SinOut);
        }

        private void OpenSwipe(object sender, EventArgs e)
        {
            MainSwipeView.Open(OpenSwipeItem.LeftItems);
            OpenAnimation();
        }

        private void CloseSwipe(object sender, EventArgs e)
        {
            MainSwipeView.Close();
            CloseAnimation();
        }

        private void SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            OpenAnimation();
        }

        private void SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (!e.IsOpen)
                CloseAnimation();
        }

        //private void CloseRequested(object sender, EventArgs e)
        //{
        //    CloseAnimation();
        //}
    }

    public class Menu
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
