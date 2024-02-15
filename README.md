# Silk.Eto glue

This little library lets you use [Silk.NET](https://github.com/dotnet/Silk.NET) with [Eto.Forms](https://github.com/picoe/Eto), in case you need such a crazy thing. Based on [Eto.Veldrid](https://github.com/picoe/Eto.Veldrid).

You get a `SilkSurface` control which implements Silk's `IWindow`, enabling you to render into it with [Veldrid](https://github.com/veldrid/veldrid) or other things.  
Silk already provided an excellent abstract API for windows & input, and I wanted to integrate Eto into my game engine project, so this seemed like a logical enough thing to do.

## Important notes

Veldrid support matrix:
* 👍 - works
* ❓ - to be tested
* 🛠 - work in progress
* 🚫 - incompatible
* 💔 - not planned

|Platform            |Vulkan|DirectX 11|
|:------------------:|:----:|:--------:|
|Windows (WPF)       |👍    |❓        |
|Windows (WinForms)  |❓    |❓        |
|Linux (GTK, X11)    |❓    |🚫        |
|Linux (GTK, Wayland)|❓    |🚫        |

OpenGL is not planned as I don't use it in my projects.

Unfortunately I don't own a Mac, so that is not supported. As such, Metal is not supported.

# Licence
MIT licence, read [it here](LICENSE.md) and check out [the authors](AUTHORS.md).

This work is not affiliated with the Silk.NET project nor the Eto.Forms project. Contact me if changing the name is necessary.
