using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Graphics;

namespace Poker1
{
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
            CanvasView.InvalidateSurface(); 
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Green);

            for (int i = 0; i < hand.Count; i++)
            {
                DrawCards.DrawCardOutline(canvas, i * 120, 0);

                DrawCardImage(canvas, hand[i], i * 120, 0);
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


        public static class CardImages
        {
            public static List<string> ImagePaths = new List<string>
            {
                "ace_club.jpg",
                "ace_diamond.jpg",
                "ace_heart.jpg",
                "ace_spade.jpg",

                "eight_club.jpg",
                "eight_diamond.jpg",
                "eight_heart.jpg",
                "eight_spade.jpg",

                "five_club.jpg",
                "five_diamond.jpg",
                "five_heart.jpg",
                "five_spade.jpg", 

                "four_club.jpg",
                "four_diamond.jpg",
                "four_heart.jpg",
                "four_spade.jpg", 

                "nine_club.jpg",
                "nine_diamond.jpg",
                "nine_heart.jpg",
                "nine_spade.jpg",

                "seven_club.jpg",
                "seven_diamond.jpg",
                "seven_heart.jpg",
                "seven_spade.jpg", 

                "three_club.jpg",
                "three_diamond.jpg",
                "three_heart.jpg",
                "three_spade.jpg", 


                "ten_club.jpg",
                "ten_diamond.jpg",
                "ten_heart.jpg",
                "ten_spade.jpg",

                "queen_club.jpg",
                "queen_diamond.jpg",
                "queen_heart.jpg",
                "queen_spade.jpg", 

                "king_club.jpg",
                "king_diamond.jpg",
                "king_heart.jpg",
                "king_spade.jpg",


                "jack_club.jpg",
                "jack_diamond.jpg",
                "jack_heart.jpg",
                "jack_spade.jpg",
            };
        }

        private void DrawCardImage(SKCanvas canvas, Card card, int x, int y)
        {
            string imagePath = Path.Combine("Resources", $"{card.MyValue}{card.MySuit}.jpg");
            if (File.Exists(imagePath))
            {
                using var image = SKBitmap.Decode(imagePath);

                float cardWidth = 100; 
                float cardHeight = 150; 

                var destRect = SKRect.Create(x, y, cardWidth, cardHeight);

                canvas.DrawBitmap(image, destRect);
            }
        }

    }
}
