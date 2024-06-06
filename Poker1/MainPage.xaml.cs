using SkiaSharp;
using SkiaSharp.Views;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;
using System.Collections.Generic;
namespace Poker1
{
    public partial class MainPage : ContentPage
    {
        private List<Card> hand;
        private List<Card> playerHand;
        private List<Card> pcHand;
        private int playerWins = 0;
        private int pcWins = 0;
        private const float xOffset = 50;
        public Label PlayerNameLabel { get; set; }


        public MainPage(string playerName)
        {
            InitializeComponent();
            hand = new List<Card>();
            playerHand = new List<Card>();
            pcHand = new List<Card>();
            CanvasView.PaintSurface += OnCanvasViewPaintSurface;
            PlayerNameLabel.Text = $"Hello, {playerName}!";
        }

        private void OnDealButtonClicked(object sender, EventArgs e)
        {
            DealHand();
            DetermineWinner();
            CanvasView.InvalidateSurface(); 
        }
        private void OnShowPokerRulesClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PokerRules());
        }

        private void OnCanvasViewPaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Green);


            DrawLabel(canvas, "Community Cards", 10, 40);
            for (int i = 0; i < hand.Count; i++)
            {
                float xPosition = xOffset + i * 120;
                DrawCards.DrawCardOutline(canvas, xPosition, 40);
                DrawCards.DrawCardSuitValue(canvas, hand[i], xPosition, 40);

            }
            DrawLabel(canvas, "Player's Cards", 10, 210);
            for (int i = 0; i < playerHand.Count; i++)
            {
                float xPosition = xOffset + i * 120;
                DrawCards.DrawCardOutline(canvas, xPosition, 220);
                DrawCards.DrawCardSuitValue(canvas, playerHand[i], xPosition, 220);
            }

            // Draw PC's cards
            DrawLabel(canvas, "PC's Cards", 10, 392);
            for (int i = 0; i < pcHand.Count; i++)
            {
                float xPosition = xOffset + i * 120;
                DrawCards.DrawCardOutline(canvas, xPosition, 400);
                DrawCards.DrawCardSuitValue(canvas, pcHand[i], xPosition, 400);
            }

        }
        private void DrawLabel(SKCanvas canvas, string text, float x, float y)
        {
            var textPaint = new SKPaint
            {
                Color = SKColors.Yellow,
                TextSize = 36,
                IsAntialias = true,
                TextAlign = SKTextAlign.Left,
                Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
            };
            canvas.DrawText(text, x, y, textPaint);
        }

        private void DealHand()
        {
            var random = new Random();
            hand.Clear();
            playerHand.Clear();
            pcHand.Clear();

            for (int i = 0; i < 5; i++)
            {
                var suit = (Card.SUIT)random.Next(4);
                var value = random.Next(1, 14).ToString();

                if (value == "1") value = "A";
                else if (value == "11") value = "J";
                else if (value == "12") value = "Q";
                else if (value == "13") value = "K";

                hand.Add(new Card { MySuit = suit, MyValue = value });
            }
            for (int i = 0; i < 2; i++)
            {
                var playerSuit = (Card.SUIT)random.Next(4);
                var playerValue = random.Next(1, 14).ToString();

                if (playerValue == "1") playerValue = "A";
                else if (playerValue == "11") playerValue = "J";
                else if (playerValue == "12") playerValue = "Q";
                else if (playerValue == "13") playerValue = "K";



                playerHand.Add(new Card { MySuit = playerSuit, MyValue = playerValue });

            }
            for (int i = 0; i < 2; i++)
            {
                var pcSuit = (Card.SUIT)random.Next(4);
                var pcValue = random.Next(1, 14).ToString();

                if (pcValue == "1") pcValue = "A";
                else if (pcValue == "11") pcValue = "J";
                else if (pcValue == "12") pcValue = "Q";
                else if (pcValue == "13") pcValue = "K";

                pcHand.Add(new Card { MySuit = pcSuit, MyValue = pcValue });
            }

        }
        private void DetermineWinner()
        {

            int playerScore = EvaluateHand(playerHand);
            int pcScore = EvaluateHand(pcHand);

            if (playerScore > pcScore)
            {
                playerWins++;
                WinnerLabel.Text = "Player Wins!";
            }
            else if (pcScore > playerScore)
            {
                pcWins++;
                WinnerLabel.Text = "PC Wins!";
            }
            else
            {
                WinnerLabel.Text = "It's a Tie!";
            }
            PlayerWinsLabel.Text = $"Player Wins: {playerWins}";
            PcWinsLabel.Text = $"PC Wins: {pcWins}";

        }

        private int EvaluateHand(List<Card> hand)
        {

            int score = 0;
            foreach (var card in hand)
            {
                switch (card.MyValue)
                {
                    case "A":
                        score += 14; 
                        break;
                    case "K":
                        score += 13;
                        break;
                    case "Q":
                        score += 12;
                        break;
                    case "J":
                        score += 11;
                        break;
                    default:
                        score += int.Parse(card.MyValue);
                        break;
                }
            }
            return score;
        }
    }
}


