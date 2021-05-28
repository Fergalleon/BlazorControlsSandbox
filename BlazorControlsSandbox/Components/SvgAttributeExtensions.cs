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
            return svgAttributes.Boundary.Contains(clickPoint);
        }
    }
}