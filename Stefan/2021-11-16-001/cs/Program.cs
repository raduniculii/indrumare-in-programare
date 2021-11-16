using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace test
{
    class Program
    {
        static void Draw7Led(Graphics graphics, Brush brush, int startX, int startY, int position, int thickness, int totalWidth, int totalHeight)
        {
            int widthPlusSpacing = totalWidth + totalWidth/2 - thickness;
            int realStartX = startX + position*widthPlusSpacing;
            int vSpacing = (totalHeight - 3*thickness ) / 2;

            graphics.FillRectangles(brush, new Rectangle[]{
                new Rectangle(realStartX, startY, totalWidth - 2*thickness, thickness)
                , new Rectangle(realStartX, startY + vSpacing, totalWidth - 2*thickness, thickness)
                , new Rectangle(realStartX, startY + vSpacing*2, totalWidth - 2*thickness, thickness)

                , new Rectangle(realStartX - thickness, startY + thickness, thickness, vSpacing - thickness)
                , new Rectangle(realStartX + totalWidth - 2*thickness, startY + thickness, thickness, vSpacing - thickness)

                , new Rectangle(realStartX - thickness, startY + thickness + vSpacing, thickness, vSpacing - thickness)
                , new Rectangle(realStartX + totalWidth - 2*thickness, startY + thickness + vSpacing, thickness, vSpacing - thickness)
            });
        }

        static void Main(string[] args)
        {
            int widthInSquares = 10;
            int heightInSquares = 20;
            int fullScreenBorderWidth = 2;
            int fullScreenPadding = 2;
            Color fullScreenBorderColor = Color.FromArgb(0, 0, 0);

            int squareSpacing = 1;
            int squareSize = 14;
            int squareBorderWidth = 2;
            int squarePaddingWidth = 2;

            Color lcdOnColor = Color.FromArgb(80, 80, 80);
            Color lcdOffColor = Color.FromArgb(30, lcdOnColor);
            Color screenColor = Color.FromArgb(146, 148, 135);

            string projectRoot = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "../../../../.."));

            var width = (squareSize + squareSpacing) * widthInSquares + squareSpacing + fullScreenBorderWidth * 2 + fullScreenPadding * 2 + (squareSize + squareSpacing) * 6;
            var height = 2*(fullScreenBorderWidth + fullScreenPadding) + squareSpacing + heightInSquares * (squareSize + squareSpacing);

            using(var bmp = new Bitmap(squareSize, squareSize))
            {
                using(var gr = Graphics.FromImage(bmp))
                {
                    Brush screenBrush = new SolidBrush(screenColor);
                    Brush screenOnLcdOnBrush = new SolidBrush(lcdOnColor);

                    gr.FillRectangle(screenOnLcdOnBrush, 0, 0, squareSize, squareSize);
                    gr.FillRectangle(screenBrush, squareBorderWidth, squareBorderWidth, squareSize - 2*squareBorderWidth, squareSize - 2*squareBorderWidth);
                    gr.FillRectangle(screenOnLcdOnBrush, squareBorderWidth + squarePaddingWidth, squareBorderWidth + squarePaddingWidth, squareSize - 2*(squareBorderWidth + squarePaddingWidth), squareSize - 2*(squareBorderWidth + squarePaddingWidth));
                    bmp.Save($@"{projectRoot}\resurse\imagini\SquareOn.bmp", ImageFormat.Bmp);
                }
            }

            using(var bmp = new Bitmap(width, height))
            {
                using(var gr = Graphics.FromImage(bmp))
                {
                    Brush screenBrush = new SolidBrush(screenColor);
                    gr.FillRectangle(screenBrush, 0, 0, width, height);
                    gr.DrawRectangle(new Pen(fullScreenBorderColor, fullScreenBorderWidth), fullScreenPadding, fullScreenPadding, (squareSize + squareSpacing) * widthInSquares + squareSpacing + fullScreenBorderWidth * 2, 2*fullScreenBorderWidth + squareSpacing + heightInSquares * (squareSize + squareSpacing));
                    bmp.Save($@"{projectRoot}\resurse\imagini\ScreenOff.bmp", ImageFormat.Bmp);

                    Brush screenOnLcdOffBrush = new SolidBrush(lcdOffColor);
                    Brush screenOnLcdOnBrush = new SolidBrush(lcdOnColor);
                    IList<dynamic> screens = new dynamic[]{
                        new { brush = screenOnLcdOffBrush, file = "ScreenOn" }
                        , new { brush = screenOnLcdOnBrush, file = "ScreenOnLcdOn" }
                    };

                    foreach (var screen in screens)
                    {
                        int startX = fullScreenPadding + fullScreenBorderWidth + squareSpacing;
                        int startY = fullScreenPadding + fullScreenBorderWidth + squareSpacing;
                        for(int col = 0; col < widthInSquares; col++)
                        {
                            for(int row = 0; row < heightInSquares; row++)
                            {
                                gr.FillRectangle(screen.brush, startX + (squareSpacing + squareSize) * col, startY + (squareSpacing + squareSize) * row, squareSize, squareSize);
                                gr.FillRectangle(screenBrush, startX + (squareSpacing + squareSize) * col + squareBorderWidth, startY + (squareSpacing + squareSize) * row + squareBorderWidth, squareSize - 2*squareBorderWidth, squareSize - 2*squareBorderWidth);
                                gr.FillRectangle(screen.brush, startX + (squareSpacing + squareSize) * col + squareBorderWidth + squarePaddingWidth, startY + (squareSpacing + squareSize) * row + squareBorderWidth + squarePaddingWidth, squareSize - 2*(squareBorderWidth + squarePaddingWidth), squareSize - 2*(squareBorderWidth + squarePaddingWidth));
                            }
                        }

                        for(int lcdNo = 0; lcdNo < 6; lcdNo++)
                        {
                            Draw7Led(gr, screen.brush
                                , startX: (squareSize + squareSpacing) * (widthInSquares + 1) + 2*squareSpacing
                                , startY: fullScreenPadding + fullScreenBorderWidth + (squareSpacing + squarePaddingWidth)*2
                                , position: lcdNo
                                , thickness: squareBorderWidth
                                , totalWidth: squareSize - 2*squareBorderWidth
                                , totalHeight: squareSize * 2
                            );
                        }

                        gr.DrawString(
                            "SCORE"
                            , new Font(new FontFamily("Arial"), 12, FontStyle.Regular, GraphicsUnit.Pixel)
                            , screen.brush
                            , (squareSize + squareSpacing) * (widthInSquares + 1) + 2*squareSpacing + (squareSize - 2*squareBorderWidth)
                            , squareSize * 3
                        );
                        
                        bmp.Save($@"{projectRoot}\resurse\imagini\{screen.file}.bmp", ImageFormat.Bmp);
                    }
                }
            }
            
            Console.WriteLine("C# merge!");
        }
    }
}
