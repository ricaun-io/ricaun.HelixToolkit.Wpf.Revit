using Autodesk.Revit.DB;
using HelixToolkit.Wpf;
using System.Collections.Generic;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitLinesVisual3DExtension
    /// </summary>
    public static class RevitLinesVisual3DExtension
    {
        /// <summary>
        /// ToLinesVisual3D
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static LinesVisual3D ToLinesVisual3D(this IList<XYZ> points)
        {
            var lines = new LinesVisual3D();

            foreach (var point in points)
            {
                lines.Points.Add(point.ToPoint3D());
                lines.Points.Add(point.ToPoint3D());
            }

            lines.Points.RemoveAt(lines.Points.Count - 1);
            lines.Points.RemoveAt(0);

            return lines;
        }
    }
}
