using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker1
{
    public static class DrawCards
    {
        public static void DrawCardOutline(SKCanvas canvas, int x, int y)
        {
            var paint = new SKPaint
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 2
            };

            int width = 100;
            int height = 140;

            float left = x;
            float top = y;
            float right = left + width;
            float bottom = top + height;

            var rect = new SKRect(left, top, right, bottom);
            canvas.DrawRect(rect, paint);
        }

        public static void DrawCardSuitValue(SKCanvas canvas, Card card, int x, int y)
        {
            char cardSuit = ' ';
            SKColor suitColor = SKColors.Black;

            // Determine the suit and color
            switch (card.MySuit)
            {
                case Card.SUIT.HEARTS:
                    cardSuit = '♥';
                    suitColor = SKColors.Red;
                    break;
                case Card.SUIT.DIAMONDS:
                    cardSuit = '♦';
                    suitColor = SKColors.Orange;
                    break;
                case Card.SUIT.CLUBS:
                    cardSuit = '♣';
                    suitColor = SKColors.Blue;
                    break;
                case Card.SUIT.SPADES:
                    cardSuit = '♠';
                    suitColor = SKColors.Black;
                    break;
            }

            // Draw the suit and value
            var paint = new SKPaint
            {
                Color = suitColor,
                TextSize = 24,
                IsAntialias = true
            };

            float posX = x + 10;
            float posY = y + 30;

            canvas.DrawText($"{card.MyValue} {cardSuit}", posX, posY, paint);
        }
    }
}
