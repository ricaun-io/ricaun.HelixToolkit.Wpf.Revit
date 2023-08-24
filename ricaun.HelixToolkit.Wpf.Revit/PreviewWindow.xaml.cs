using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit
{
    /// <summary>
    /// PreviewWindow
    /// </summary>
    public partial class PreviewWindow : Window
    {
        /// <summary>
        /// PreviewWindow
        /// </summary>
        /// <param name="title"></param>
        public PreviewWindow(string title = null)
        {
            InitializeComponent();
            InitializeWindow();

            Title = title ?? "Helix Toolkit Preview";

            this.PreviewKeyDown += (s, e) =>
            {
                if (e.Key == System.Windows.Input.Key.Escape) Close();
                else if (e.Key == System.Windows.Input.Key.E) ZoomExtents();
            };

            Clear();
        }

        /// <summary>
        /// HelixViewport3D
        /// </summary>
        public HelixViewport3D HelixViewport3D;

        /// <summary>
        /// Clear
        /// </summary>
        public PreviewWindow Clear()
        {
            if (HelixViewport3D is null)
            {
                HelixViewport3D = new HelixViewport3D();
                HelixViewport3D.ZoomExtentsWhenLoaded = true;
                Main.Children.Add(HelixViewport3D);
            }
            HelixViewport3D.Children.Clear();
            Add(new DefaultLights());
            return this;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="visual"></param>
        public PreviewWindow Add(Visual3D visual)
        {
            if (visual is null) return this;
            HelixViewport3D?.Children.Add(visual);
            return this;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="visuals"></param>
        public PreviewWindow Add(IEnumerable<Visual3D> visuals)
        {
            foreach (var visual in visuals)
            {
                Add(visual);
            }
            return this;
        }

        /// <summary>
        /// ZoomExtents
        /// </summary>
        public PreviewWindow ZoomExtents()
        {
            HelixViewport3D?.ZoomExtents();
            return this;
        }

        #region InitializeWindow
        private void InitializeWindow()
        {
            this.MinHeight = 640;
            this.MinWidth = 640;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
        #endregion
    }
}