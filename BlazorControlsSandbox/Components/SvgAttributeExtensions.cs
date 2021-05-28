namespace BlazorControlsSandbox.Components
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Models;

    public static class SvgAttributeExtensions
    {
        public static SvgAttributes GetSelected(this List<SvgAttributes> svgAttributes, Point clickPoint)
        {
            return svgAttributes?.FirstOrDefault(svg => svg.IsWithinBoundary(clickPoint));
        }
        private static bool IsWithinBoundary(this SvgAttributes svgAttributes, Point clickPoint)
        {
            return IsWithinWidthBoundary(svgAttributes, clickPoint.X) &&
                   IsWithinHeightBoundary(svgAttributes, clickPoint.Y);
        }

        private static bool IsWithinWidthBoundary(SvgAttributes svgAttributes, int x)
        {
            return x >= svgAttributes.X &&
                   x <= svgAttributes.X + svgAttributes.Width;
        }

        private static bool IsWithinHeightBoundary(SvgAttributes svgAttributes, int y)
        {
            return y >= svgAttributes.Y &&
                   y <= svgAttributes.Y + svgAttributes.Height;
        }
    }
}