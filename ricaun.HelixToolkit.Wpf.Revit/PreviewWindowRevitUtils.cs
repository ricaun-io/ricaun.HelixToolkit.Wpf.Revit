using Autodesk.Revit.DB;
using HelixToolkit.Wpf;
using ricaun.HelixToolkit.Wpf.Revit.Extensions;
using ricaun.HelixToolkit.Wpf.Revit.Utils;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit
{
    /// <summary>
    /// PreviewWindowRevitExtension
    /// </summary>
    public static class PreviewWindowRevitUtils
    {
        /// <summary>
        /// GetVisual3D
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Visual3D GetVisual3D(Element element)
        {
            DocumentUtils.Document = element.Document;
            Options options = new Options()
            {
                DetailLevel = ViewDetailLevel.Fine
            };
            return element.get_Geometry(options).ToVisual3D();
        }

        /// <summary>
        /// SetDocument
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public static PreviewWindow SetDocument(this PreviewWindow previewWindow, Document document)
        {
            DocumentUtils.Document = document;
            return previewWindow;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static PreviewWindow Add(this PreviewWindow previewWindow, Element element)
        {
            previewWindow.Add(GetVisual3D(element));
            return previewWindow;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static PreviewWindow Add(this PreviewWindow previewWindow, IEnumerable<Element> elements)
        {
            foreach (var element in elements)
                previewWindow.Add(element);
            return previewWindow;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="geometryObject"></param>
        /// <returns></returns>
        public static PreviewWindow Add(this PreviewWindow previewWindow, GeometryObject geometryObject)
        {
            previewWindow.Add(geometryObject.ToVisual3D());
            return previewWindow;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="geometryObjects"></param>
        /// <returns></returns>
        public static PreviewWindow Add(this PreviewWindow previewWindow, IEnumerable<GeometryObject> geometryObjects)
        {
            foreach (var geometryObject in geometryObjects)
                previewWindow.Add(geometryObject);
            return previewWindow;
        }

        /// <summary>
        /// Camera
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static PreviewWindow Camera(this PreviewWindow previewWindow, View view)
        {
            previewWindow.Camera(-view.ViewDirection, view.UpDirection);
            return previewWindow;
        }

        /// <summary>
        /// Camera
        /// </summary>
        /// <param name="previewWindow"></param>
        /// <param name="lookDirection"></param>
        /// <param name="upDirection"></param>
        /// <returns></returns>
        public static PreviewWindow Camera(this PreviewWindow previewWindow, XYZ lookDirection, XYZ upDirection)
        {
            previewWindow.HelixViewport3D.Camera.LookDirection = lookDirection.ToVector3D();
            previewWindow.HelixViewport3D.Camera.UpDirection = upDirection.ToVector3D();
            return previewWindow;
        }
    }
}