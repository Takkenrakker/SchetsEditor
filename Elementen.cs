using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SchetsEditor
{

    public interface IElement : IEquatable<IElement>
    {
        bool CollideCheck(int px, int py);
    }

    public class ElementenLijst : List<IElement>
    {
        private List<IElement> elementenLijst;
        
        public ElementenLijst()
        {
            elementenLijst = new List<IElement>();
        }

    }
    public class Element : IElement
    {
        public Brush color;
        Rectangle BoundingBox;
        Point start;
        Point end;

        public Element(Rectangle boundingBox, Brush colorr)
        {
            BoundingBox = boundingBox;
            color = colorr;
        }
        public Element(Point p1, Point p2, Brush colorr)
        {
            start = p1;
            end = p2;
        }
        public virtual bool CollideCheck(int px, int py)
        {
            return false;
        }
        public bool Equals(IElement other)
        {
            return true;
        }
        public Brush Color
        {
            get
            {
                return color;
            }
        }
        public Rectangle BoxRect
        {
            get
            {
                return BoundingBox;
            }
        }
        public Point Start
        {
            get
            {
                return start;
            }
        }
        public Point End
        {
            get
            {
                return end;
            }
        }
    }
    public class LineElement : Element
    {
        //Brush color;
        Point start;
        Point end;
        public LineElement(Point p1, Point p2, Brush colorr) : base(p1, p2, colorr)
        {
            start = p1;
            end = p2;
            color = colorr;
        }
        public override bool CollideCheck(int px, int py)
        {
            return true;
        }
       /* Brush Color
        {
            get
            {
                return color;
            }
        }*/
        Point Start
        {
            get
            {
                return start;
            }
        }
        Point End
        {
            get
            {
                return end;
            }
        }
    }
    public class BoxElement : Element
    {
        Brush color;
        Rectangle BoundingBox;
        public BoxElement(Rectangle boundingBox, Brush colorr) : base(boundingBox, colorr)
        {
            BoundingBox = boundingBox;
            color = colorr;
        }
        public override bool CollideCheck(int px, int py)
        {
            if (px <= BoundingBox.X + BoundingBox.Width && py <= BoundingBox.Y + BoundingBox.Height)
                if (px >= BoundingBox.X && py >= BoundingBox.Y)
                    return true;
            return false;
        }
        public Rectangle BoxRect
        {
            get
            {
                return BoundingBox;
            }
        }
        public Brush Color
        {
            get
            {
                return color;
            }
        }
    }
    public class FillBoxElement : BoxElement
    {
        public FillBoxElement(Rectangle boundingBox, Brush color) : base(boundingBox, color)
        {

        }
    }
    
    public class CirkelElement : BoxElement
    {
        Rectangle BoundingBox;
        public CirkelElement(Rectangle boundingBox, Brush color) : base (boundingBox, color)
        {
            BoundingBox = boundingBox;
        }

        public override bool CollideCheck(int px, int py)
        {
            double cx = BoundingBox.X + (BoundingBox.Width / 2);
            double cy = BoundingBox.Y + (BoundingBox.Height / 2);
            if ((Math.Pow(px - cx, 2) / (Math.Pow(BoundingBox.Width / 2, 2))) + (Math.Pow(py - cy, 2) / (Math.Pow(BoundingBox.Height / 2, 2))) <= 1)
                return true;
            return false;
        }
    }
    public class VolCirkelElement : CirkelElement
    {
        Rectangle BoundingBox;
        public VolCirkelElement(Rectangle boundingBox, Brush color) : base(boundingBox, color)
        {
            BoundingBox = boundingBox;
        }
    }
}
