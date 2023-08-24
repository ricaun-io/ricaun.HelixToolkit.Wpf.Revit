using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// ModelVisual3DUtils
    /// </summary>
    public static class ModelVisual3DUtils
    {
        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="model3D"></param>
        /// <returns></returns>
        public static ModelVisual3D ToVisual3D(this Model3D model3D)
        {
            return new ModelVisual3D()
            {
                Content = model3D
            };
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="model3Ds"></param>
        /// <returns></returns>
        public static ModelVisual3D ToVisual3D(this IEnumerable<Model3D> model3Ds)
        {
            var group = new Model3DGroup();

            foreach (var model3D in model3Ds.OfType<Model3D>())
                group.Children.Add(model3D);

            return group.ToVisual3D();
        }

        /// <summary>
        /// ToVisual3D
        /// </summary>
        /// <param name="visual3Ds"></param>
        /// <returns></returns>
        public static ModelVisual3D ToVisual3D(this IEnumerable<Visual3D> visual3Ds)
        {
            var visual = new ModelVisual3D();

            foreach (var visual3D in visual3Ds.OfType<Visual3D>())
            {
                visual.Children.Add(visual3D);
            }

            return visual;
        }
    }
}
