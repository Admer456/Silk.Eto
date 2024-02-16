// SPDX-FileCopyrightText: 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using Silk.NET.Core.Contexts;
using Silk.NET.Windowing;

namespace Silk.Eto
{
	public class EtoNativeSurface : INativeWindow
	{
		public static EtoNativeSurface CreateWin32( nint Hwnd, nint HDC, nint HInstance )
		{
			return new()
			{
				Kind = NativeWindowFlags.Win32,
				Win32 = (Hwnd, HDC, HInstance)
			};
		}

		public static EtoNativeSurface CreateX11( nint Display, nuint Window )
		{
			return new()
			{
				Kind = NativeWindowFlags.X11,
				X11 = (Display, Window)
			};
		}

		public static EtoNativeSurface CreateWayland( nint Display, nint Surface )
		{
			return new()
			{
				Kind = NativeWindowFlags.Wayland,
				Wayland = (Display, Surface)
			};
		}

		public NativeWindowFlags Kind { get; init; }

		public (nint Display, nuint Window)? X11 { get; init; } = null;

		public nint? Cocoa => null;

		public (nint Display, nint Surface)? Wayland { get; init; } = null;

		public nint? WinRT => null;

		public (nint Window, uint Framebuffer, uint Colorbuffer, uint ResolveFramebuffer)? UIKit => null;

		public (nint Hwnd, nint HDC, nint HInstance)? Win32 { get; init; } = null;

		public (nint Display, nint Window)? Vivante => null;

		public (nint Window, nint Surface)? Android => null;

		public nint? Glfw => null;

		public nint? Sdl => null;

		public nint? DXHandle => null;

		public (nint? Display, nint? Surface)? EGL => null;
	}
}
