namespace BlazorControlsSandbox.Models
{
    using System.Drawing;

    public class SvgAttributes
    {
        public SvgAttributes(Rectangle boundary, string displayValue)
        {
            Boundary = boundary;
            DisplayValue = displayValue;
        }

        public Rectangle Boundary { get; set; }
        
        public Point TextPosition => new Point(Boundary.Left + 30, Boundary.Top + 30);

        public string DisplayValue { get; set; }

        public void MoveTo(int newX, int newY)
        {
            MoveTo(new Point(newX, newY));
        }

        public void MoveTo(Point newPoint)
        {
            var size = Boundary.Size;
            Boundary = new Rectangle(newPoint, size);
        }

        public int X => Boundary.X;
        public int Y => Boundary.Y;
        public int Width => Boundary.Width;
        public int Height => Boundary.Height;
    }
}