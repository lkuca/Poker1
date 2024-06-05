namespace Poker1;

public partial class PokerRules : ContentPage
{
	public PokerRules()
	{
		InitializeComponent();
	}
    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}