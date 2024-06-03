using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;
using System.Collections.Generic;
namespace Poker1;

public partial class MainPage : ContentPage
{
    private List<Card> hand;
    private List<Card> playerHand;
    private List<Card> pcHand;

    public MainPage()
    {
        InitializeComponent();
        hand = new List<Card>();
        playerHand = new List<Card>();
        pcHand = new List<Card>();
        CanvasView.PaintSurface += OnCanvasViewPaintSurface;
    }

    private void OnDealButtonClicked(object sender, EventArgs e)
    {
        DealHand();
        CanvasView.InvalidateSurface(); // Request the canvas to be redrawn
    }

    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.Green);

        for (int i = 0; i < hand.Count; i++)
        {
            DrawCards.DrawCardOutline(canvas, i * 120, 0);
            DrawCards.DrawCardSuitValue(canvas, hand[i], i * 120, 0);
            
        }
        for (int i = 0; i < playerHand.Count; i++)
        {
            DrawCards.DrawCardOutline(canvas, i * 120, 150);
            DrawCards.DrawCardSuitValue(canvas, playerHand[i], i * 120, 150);
        }

        // Draw PC's cards
        for (int i = 0; i < pcHand.Count; i++)
        {
            DrawCards.DrawCardOutline(canvas, i * 120, 300);
            DrawCards.DrawCardSuitValue(canvas, pcHand[i], i * 120, 300);
        }
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
}

