This little library lets you use [Silk.NET](https://github.com/dotnet/Silk.NET) with [Eto.Forms](https://github.com/picoe/Eto), in case you need such a crazy thing. Based on [Eto.Veldrid](https://github.com/picoe/Eto.Veldrid).

You get a `SilkSurface` control which implements Silk's `IWindow`, enabling you to render into it with [Veldrid](https://github.com/veldrid/veldrid) or other things.  
Silk already provided an excellent abstract API for windows & input, and I wanted to integrate Eto into my game engine project, so this seemed like a logical enough thing to do.
