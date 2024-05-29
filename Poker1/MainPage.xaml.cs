using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;
using System.Collections.Generic;
namespace Poker1;

public partial class MainPage : ContentPage
{
    private List<Card> hand;

    public MainPage()
    {
        InitializeComponent();
        hand = new List<Card>();
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
    }

    private void DealHand()
    {
        var random = new Random();
        hand.Clear();

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
    }
}

