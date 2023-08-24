# ricaun.HelixToolkit.Wpf.Revit

[![Revit 2017](https://img.shields.io/badge/Revit-2017+-blue.svg)](../..)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)

## Install

Install the package from [ricaun.HelixToolkit.Wpf.Revit](https://www.nuget.org/packages/ricaun.HelixToolkit.Wpf.Revit/).
```xml
<PackageReference Include="ricaun.HelixToolkit.Wpf.Revit" Version="*" />
```

This package depends on [ricaun.HelixToolkit.Wpf](https://www.nuget.org/packages/ricaun.HelixToolkit.Wpf/).
```xml
<PackageReference Include="ricaun.HelixToolkit.Wpf" Version="*" />
```

## PreviewWindow

The `PreviewWindow` allow to preview geometry in a WPF window using `GeometryObject` from Revit API 

```C#
new PreviewWindow()
    .Add(Line.CreateBound(XYZ.Zero, XYZ.BasisX))
    .Add(Line.CreateBound(XYZ.Zero, XYZ.BasisY))
    .Add(Line.CreateBound(XYZ.Zero, XYZ.BasisZ))
    .ShowDialog();
```

The `PreviewWindow` has some basic methods.
```C#
previewWindow.Clear();
previewWindow.Add(visual3d);
previewWindow.Add(visual3ds);
previewWindow.ZoomExtents();
```

### Revit

The `Element` could be used and the Material or GraphicsStyle will be used to render the geometry.

```C#
new PreviewWindow()
    .Add(element)
    .ShowDialog();
```

The `Document` is used to get the Material or GraphicsStyle color for `GeometryObject`.

```C#
new PreviewWindow()
    .SetDocument(document)
    .Add(geometryObjects)
    .ShowDialog();
```

The `PreviewWindowRevitUtils` has some utils methods to use with `PreviewWindow`.
```C#
previewWindow.SetDocument(document);
previewWindow.Add(element);
previewWindow.Add(elements);
previewWindow.Add(geometryObject);
previewWindow.Add(geometryObjects);
previewWindow.Camera(view);
previewWindow.Camera(lookDirection, upDirection);
```

## Release

* [Latest release](../../releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!