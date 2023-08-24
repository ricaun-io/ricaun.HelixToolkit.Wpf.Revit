using Autodesk.Revit.DB;

namespace ricaun.HelixToolkit.Wpf.Revit.Utils
{
    /// <summary>
    /// MaterialUtils
    /// </summary>
    public static class MaterialUtils
    {
        /// <summary>
        /// GetMaterialColorWithTransparency
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public static ColorWithTransparency GetMaterialColorWithTransparency(ElementId materialId)
        {
            return GetMaterialColorWithTransparency(DocumentUtils.Document, materialId);
        }

        /// <summary>
        /// GetMaterialColorWithTransparency
        /// </summary>
        /// <param name="document"></param>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public static ColorWithTransparency GetMaterialColorWithTransparency(Document document, ElementId materialId)
        {
            try
            {
                if (materialId != ElementId.InvalidElementId)
                {
                    var material = document.GetElement(materialId) as Autodesk.Revit.DB.Material;

                    if (material is null) return null;

                    var colorMaterial = material.Color;
                    var transparency0To255 = (uint)((1.0 - material.Transparency / 100.0) * 255.0);

                    return new ColorWithTransparency(colorMaterial.Red, colorMaterial.Green, colorMaterial.Blue, transparency0To255);
                }
            }
            catch { }
            return null;
        }
    }
}
