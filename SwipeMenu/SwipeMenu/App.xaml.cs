using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeMenu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "SwipeView_Experimental" });
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
