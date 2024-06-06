using Microsoft.Maui.Controls;

namespace Poker1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new NameEntryPage());
        }


        public void GoToMainPage(string playerName)
        {
            MainPage = new MainPage(playerName);
        }
    }
}
