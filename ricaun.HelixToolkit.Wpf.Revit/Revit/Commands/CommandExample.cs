using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.HelixToolkit.Wpf.Revit.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandExample : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            new PreviewWindow()
                .Add(Line.CreateBound(XYZ.Zero, XYZ.BasisX))
                .Add(Line.CreateBound(XYZ.Zero, XYZ.BasisY))
                .Add(Line.CreateBound(XYZ.Zero, XYZ.BasisZ))
                .ShowDialog();

            return Result.Succeeded;
        }
    }


}
