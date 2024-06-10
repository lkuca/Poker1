using System.Threading.Tasks;

namespace Poker1
{
    public partial class StatisticsPage : ContentPage
    {
        private DatabaseService _databaseService;

        public StatisticsPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            LoadStatistics();
        }

        private async void LoadStatistics()
        {
            int playerWins = await _databaseService.GetPlayerWinsAsync();
            int pcWins = await _databaseService.GetPcWinsAsync();

            PlayerWinsLabel.Text = $"Player Wins: {playerWins}";
            PcWinsLabel.Text = $"PC Wins: {pcWins}";
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}