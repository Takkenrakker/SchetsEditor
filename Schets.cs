using System;
using System.Collections.Generic;
using System.Drawing;

namespace SchetsEditor
{
    public class Schets
    {
        private Bitmap bitmap;
        
        public Schets()
        {
            bitmap = new Bitmap(1, 1);
        }
        public Graphics BitmapGraphics
        {
            get { return Graphics.FromImage(bitmap); }
        }
        public void VeranderAfmeting(Size sz)
        {
            if (sz.Width > bitmap.Size.Width || sz.Height > bitmap.Size.Height)
            {
                Bitmap nieuw = new Bitmap( Math.Max(sz.Width,  bitmap.Size.Width)
                                         , Math.Max(sz.Height, bitmap.Size.Height)
                                         );
                Graphics gr = Graphics.FromImage(nieuw);
                gr.FillRectangle(Brushes.White, 0, 0, sz.Width, sz.Height);
                gr.DrawImage(bitmap, 0, 0);
                bitmap = nieuw;
            }
        }
        public void Teken(Graphics gr, ElementenLijst e)
        {
            Schoon();
            Graphics bg = Graphics.FromImage(bitmap);
            foreach(Element b in e)
            {
                if (b.GetType() == typeof(VolCirkelElement))
                {
                    bg.FillEllipse(b.Color, b.BoxRect);
                    break;
                }
                if (b.GetType() == typeof(CirkelElement))
                {
                    bg.DrawEllipse(TweepuntTool.MaakPen(b.Color, 3), b.BoxRect);
                    break;
                }
                if (b.GetType() == typeof(FillBoxElement))
                {
                    bg.FillRectangle(b.Color, b.BoxRect);
                    break;
                }
                if (b.GetType() == typeof(BoxElement))
                {
                    bg.DrawRectangle(TweepuntTool.MaakPen(b.Color, 3), b.BoxRect);
                    break;
                }
                if (b.GetType() == typeof(LineElement))
                {
                    bg.DrawLine(TweepuntTool.MaakPen(b.Color, 3), b.Start, b.End);
                    break;
                }
            }

            gr.DrawImage(bitmap, 0, 0);
        }
        public void Schoon()
        {
            Graphics gr = Graphics.FromImage(bitmap);
            gr.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
        }
        public void Roteer()
        {
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
    }
}
