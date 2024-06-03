using SkiaSharp;
using System;

namespace Poker1
{
    public static class DrawCards
    {
        public static void DrawCardOutline(SKCanvas canvas, float x, float y)
        {
            var paint = new SKPaint
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Fill,
                IsAntialias = true
            };

            var rect = new SKRect(x, y, x + 100, y + 150); 
            canvas.DrawRect(rect, paint);

            paint.Color = SKColors.Black;
            paint.Style = SKPaintStyle.Stroke;
            paint.StrokeWidth = 2;
            canvas.DrawRect(rect, paint);
        }

        public static void DrawCardSuitValue(SKCanvas canvas, Card card, float x, float y)
        {
            var textPaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 24,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
            };

            var suitPaint = new SKPaint
            {
                Color = GetSuitColor(card.MySuit),
                TextSize = 40,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
            };

            
            canvas.DrawText(card.MyValue, x + 20, y + 30, textPaint);

            
            var suitSymbol = GetSuitSymbol(card.MySuit);
            canvas.DrawText(suitSymbol, x + 50, y + 90, suitPaint);
        }

        private static string GetSuitSymbol(Card.SUIT suit)
        {
            return suit switch
            {
                Card.SUIT.heart => "\u2665", // ♥
                Card.SUIT.diamond => "\u2666", // ♦
                Card.SUIT.club => "\u2663", // ♣
                Card.SUIT.spade => "\u2660", // ♠
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static SKColor GetSuitColor(Card.SUIT suit)
        {
            return (suit == Card.SUIT.heart || suit == Card.SUIT.diamond) ? SKColors.Red : SKColors.Black;
        }
    }

}
