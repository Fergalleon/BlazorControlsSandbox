namespace BlazorControlsSandbox.Models
{
    public class SvgAttributes
    {
        public SvgAttributes(int x, int y, int width, int height, string displayValue)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            DisplayValue = displayValue;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int TextX => X + 30;
        public int TextY => Y + 30;

        public string DisplayValue { get; set; }
    }
}