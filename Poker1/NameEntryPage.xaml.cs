using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace Poker1
{
    public partial class NameEntryPage : ContentPage
    {
        public Entry NameEntry { get; set; }
        public NameEntryPage()
        {
            InitializeComponent();
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            string playerName = nimi.Text;
            if (!string.IsNullOrEmpty(playerName))
            {
                ((App)App.Current).GoToMainPage(playerName);
            }
        }
    }
}
