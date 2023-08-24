using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace ricaun.HelixToolkit.Wpf.Revit.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("ricaun.HelixToolkit.Wpf.Revit");
            ribbonPanel.CreatePushButton<Commands.Command>()
                .SetLargeImage(Properties.Resources.ricaun.GetBitmapSource());
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}