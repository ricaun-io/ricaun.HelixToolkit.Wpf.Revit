using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.HelixToolkit.Wpf.Revit.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        static PreviewWindow previewWindow;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;
            View view = uidoc.ActiveView;

            var elements = GetSelectionElements(uiapp);

            if (previewWindow is null)
            {
                previewWindow = new PreviewWindow();
                previewWindow.Closed += (s, e) => previewWindow = null;
            }

            previewWindow.Clear().Add(elements).Camera(view).ZoomExtents();
            previewWindow?.Show();
            previewWindow?.Activate();

            return Result.Succeeded;
        }

        public IEnumerable<Element> GetSelectionElements(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;
            View view = uidoc.ActiveView;
            Selection selection = uidoc.Selection;

            var elements = selection.GetElementIds()
                .Select(id => document.GetElement(id))
                .ToList();

            var subElements = elements.OfType<FamilyInstance>()
                .SelectMany(GetSubElements)
                .ToList();

            elements.AddRange(subElements);

            return elements;
        }

        private IEnumerable<FamilyInstance> GetSubElements(FamilyInstance familyInstance)
        {
            var document = familyInstance.Document;

            var instances = familyInstance.GetSubComponentIds()
                .Select(id => document.GetElement(id) as FamilyInstance)
                .ToList();

            instances.AddRange(instances.SelectMany(GetSubElements));

            return instances;
        }
    }


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
