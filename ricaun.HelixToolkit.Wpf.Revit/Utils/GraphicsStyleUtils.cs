using Autodesk.Revit.DB;

namespace ricaun.HelixToolkit.Wpf.Revit.Utils
{
    /// <summary>
    /// GraphicsStyleUtils
    /// </summary>
    public static class GraphicsStyleUtils
    {
        /// <summary>
        /// GetLineColor
        /// </summary>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Color GetLineColor(ElementId graphicsStyleId)
        {
            return GetLineColor(DocumentUtils.Document, graphicsStyleId);
        }
        /// <summary>
        /// GetLinePattern
        /// </summary>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static LinePattern GetLinePattern(ElementId graphicsStyleId)
        {
            return GetLinePattern(DocumentUtils.Document, graphicsStyleId);
        }
        /// <summary>
        /// GetLineColor
        /// </summary>
        /// <param name="document"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Color GetLineColor(Document document, ElementId graphicsStyleId)
        {
            try
            {
                if (graphicsStyleId != ElementId.InvalidElementId)
                {
                    GraphicsStyle graphicsStyle = document.GetElement(graphicsStyleId) as GraphicsStyle;

                    return graphicsStyle.GraphicsStyleCategory.LineColor;
                }
            }
            catch { }
            return null;
        }

        /// <summary>
        /// GetLinePattern
        /// </summary>
        /// <param name="document"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static LinePattern GetLinePattern(Document document, ElementId graphicsStyleId)
        {
            try
            {
                if (graphicsStyleId != ElementId.InvalidElementId)
                {
                    GraphicsStyle graphicsStyle = document.GetElement(graphicsStyleId) as GraphicsStyle;

                    var linePatternId = graphicsStyle.GraphicsStyleCategory.GetLinePatternId(GraphicsStyleType.Projection);
                    var linePattern = LinePatternElement.GetLinePattern(document, linePatternId);

                    return linePattern;
                }
            }
            catch { }
            return null;
        }

    }
}
