using Autodesk.Revit.DB;
using HelixToolkit.Wpf;
using System.Linq;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitVisual3DExtension
    /// </summary>
    public static class RevitVisual3DExtension
    {
        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="geometryElement"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this GeometryElement geometryElement)
        {
            if (geometryElement is null)
                return null;

            return geometryElement
                .OfType<GeometryObject>()
                .Select(e => e.ToVisual3D())
                .ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="geometryInstance"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this GeometryInstance geometryInstance)
        {
            var geometryElement = geometryInstance.GetInstanceGeometry();

            return geometryElement.ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Mesh mesh)
        {
            return mesh
                .ToModel3D()
                .ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Face face)
        {
            return face
                .ToModel3D()
                .ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="visualEdges"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Solid solid, bool visualEdges = false)
        {
            var faces = solid.Faces
                .OfType<Face>()
                .Select(e => e.ToModel3D())
                .ToVisual3D();

            if (visualEdges == false)
                return faces;

            var edges = solid.Edges
                .OfType<Edge>()
                .Select(e => e.ToVisual3D())
                .ToVisual3D();

            return new[] { faces, edges }.ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Edge edge)
        {
            return edge
                .AsCurve()
                .ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Curve curve)
        {
            if (curve.Visibility != Visibility.Visible) return null;

            // Convert to Bound
            if (curve is Line line && line.IsBound == false)
            {
                curve = Line.CreateBound(line.Origin, line.Origin + line.Direction);
                curve.SetGraphicsStyleId(line.GraphicsStyleId);
            }

            var lines = curve.Tessellate().ToLinesVisual3D();

            lines.ApplyGraphicsStyle(curve);

            return lines;
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Point point)
        {
            var points = new PointsVisual3D();
            points.Points.Add(point.Coord.ToPoint3D());

            points.ApplyGraphicsStyle(point);

            return points;
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="polyLine"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this PolyLine polyLine)
        {
            var lines = polyLine.GetCoordinates().ToLinesVisual3D();

            lines.ApplyGraphicsStyle(polyLine);

            return lines;
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this Profile profile)
        {
            return profile
                .Curves
                .OfType<Curve>()
                .Select(ToVisual3D)
                .ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="geometryObject"></param>
        /// <returns></returns>
        public static Visual3D ToVisual3D(this GeometryObject geometryObject)
        {
            switch (geometryObject)
            {
                case GeometryElement geometryElement:
                    return geometryElement.ToVisual3D();
                case GeometryInstance geometryInstance:
                    return geometryInstance.ToVisual3D();
                case Mesh mesh:
                    return mesh.ToVisual3D();
                case Solid solid:
                    return solid.ToVisual3D();
                case Face face:
                    return face.ToVisual3D();
                case Edge edge:
                    return edge.ToVisual3D();
                case Curve curve:
                    return curve.ToVisual3D();
                case Point point:
                    return point.ToVisual3D();
                case PolyLine polyLine:
                    return polyLine.ToVisual3D();
                case Profile profile:
                    return profile.ToVisual3D();
            }
            return null;
        }
    }
}
