namespace BlazorControlsSandbox.Components
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Models;

    public static class SvgAttributeExtensions
    {
        public static SvgAttributes GetSelected(this List<SvgAttributes> svgAttributes, Point containerOffset, Point clickPoint)
        {
            return svgAttributes?.FirstOrDefault(svg => svg.IsWithinBoundary(containerOffset, clickPoint));
        }
        private static bool IsWithinBoundary(this SvgAttributes svgAttributes, Point containerOffset, Point clickPoint)
        {
           return IsWithinWidthBoundary(svgAttributes, containerOffset.X, clickPoint.X) && 
                  IsWithinHeightBoundary(svgAttributes, containerOffset.Y,  clickPoint.Y);
        }
        
        private static bool IsWithinWidthBoundary(SvgAttributes svgAttributes, int offsetX, int x)
        {
            return x >= svgAttributes.X &&
                   x <= svgAttributes.X + svgAttributes.Width + offsetX;
        }

        private static bool IsWithinHeightBoundary(SvgAttributes svgAttributes, int offsetY, int y)
        {
            return y >= svgAttributes.Y &&
                   y <= svgAttributes.Y + svgAttributes.Height + offsetY;
        }
    }
}