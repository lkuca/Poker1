using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker1
{
    public class DrawCards
    {
        private static readonly SKBitmap heartBitmap;
        private static readonly SKBitmap diamondBitmap;
        private static readonly SKBitmap clubBitmap;
        private static readonly SKBitmap spadeBitmap;
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        static DrawCards()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            heartBitmap = LoadBitmap(@"Resources/Images/hearts1.jpg");
            diamondBitmap = LoadBitmap(@"Resources/Images/diamonds1.png");
            clubBitmap = LoadBitmap(@"Resources/Images/clubs1.jpg");
            spadeBitmap = LoadBitmap(@"Resources/Images/spades1.jpg");



        }
        private static SKBitmap LoadBitmap(string imageName)
        {
            // Construct the path to the image file
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", imageName);

            // Open the file stream and decode the bitmap
            using (var stream = File.OpenRead(imagePath))
            {
                return SKBitmap.Decode(stream);
            }
        }

        public static void DrawCardOutline(SKCanvas canvas, float x, float y, bool highlight = false)
        {
            var paint = new SKPaint
            {
                Color = highlight ? SKColors.Blue : SKColors.White,
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
                TextSize = 34,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
                 Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
            };

            var suitPaint = new SKPaint
            {
                Color = GetSuitColor(card.MySuit),
                TextSize = 100,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)

            };

            // Draw card value at the top-left
            canvas.DrawText(card.MyValue, x + 20, y + 30, textPaint);

            // Draw suit symbol at the center
            var suitBitmap = GetSuitSymbol(card.MySuit);
            if (suitBitmap != null)
            {
                canvas.DrawBitmap(suitBitmap, new SKRect(x + 25, y + 50, x + 75, y + 100));
            }
        }
       
        public static SKBitmap GetSuitSymbol(Card.SUIT suit)
        {
            return suit switch
            {
                Card.SUIT.HEARTS => heartBitmap,
                Card.SUIT.DIAMONDS => diamondBitmap,
                Card.SUIT.CLUBS => clubBitmap,
                Card.SUIT.SPADES => spadeBitmap,
                _ => throw new ArgumentOutOfRangeException()
            };
            //List<string> b = new List<string> { "♥", "♦", "♣", "♠" };
            //return suit switch
            //{
            //    Card.SUIT.HEARTS => b[0].ToString(),
            //    Card.SUIT.DIAMONDS => b[1].ToString(),
            //    Card.SUIT.CLUBS => b[2].ToString(),
            //    Card.SUIT.SPADES => b[3].ToString(),
            //    //Card.SUIT.HEARTS => Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0].ToString(),
            //    //Card.SUIT.DIAMONDS => Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0].ToString(),
            //    //Card.SUIT.CLUBS => Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0].ToString(),
            //    //Card.SUIT.SPADES => Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0].ToString(),
            //    _ => throw new ArgumentOutOfRangeException()
            //} ;
        }

        private static SKColor GetSuitColor(Card.SUIT suit)
        {
            return (suit == Card.SUIT.HEARTS || suit == Card.SUIT.DIAMONDS) ? SKColors.Red : SKColors.Black;
        }

    }
}
