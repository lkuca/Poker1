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
        public static void DrawCardOutline(SKCanvas canvas, float x, float y)
        {
            var paint = new SKPaint
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Fill,
                IsAntialias = true
            };

            var rect = new SKRect(x, y, x + 100, y + 150); // Card size: 100x150
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
                 Typeface = SKTypeface.FromFamilyName("Arial Unicode MS", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
            };

            var suitPaint = new SKPaint
            {
                Color = GetSuitColor(card.MySuit),
                TextSize = 40,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromFamilyName("Arial Unicode MS", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)

            };

            // Draw card value at the top-left
            canvas.DrawText(card.MyValue, x + 20, y + 30, textPaint);

            // Draw suit symbol at the center
            var suitSymbol = GetSuitSymbol(card.MySuit);
            canvas.DrawText(suitSymbol, x + 50, y + 90, suitPaint);
        }

        private static string GetSuitSymbol(Card.SUIT suit)
        {
            return suit switch
            {

                Card.SUIT.HEARTS => Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0].ToString(),
                Card.SUIT.DIAMONDS => Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0].ToString(),
                Card.SUIT.CLUBS => Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0].ToString(),
                Card.SUIT.SPADES => Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0].ToString(),
                _ => throw new ArgumentOutOfRangeException()
            } ;
        }

        private static SKColor GetSuitColor(Card.SUIT suit)
        {
            return (suit == Card.SUIT.HEARTS || suit == Card.SUIT.DIAMONDS) ? SKColors.Red : SKColors.Black;
        }
    }
}
