// SPDX-FileCopyrightText: 2018-2020 Eto.Veldrid authors, 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using System.Runtime.InteropServices;

namespace Silk.Eto.Gtk
{
	internal static class GdkInterop
	{
		const string libgdk_name = "libgdk-3.so.0";

		[DllImport( libgdk_name )]
		static public extern IntPtr gdk_x11_display_get_xdisplay( IntPtr gdkDisplay );

		[DllImport( libgdk_name )]
		static public extern int gdk_x11_screen_get_screen_number( IntPtr gdkScreen );

		[DllImport( libgdk_name )]
		static public extern IntPtr gdk_x11_window_get_xid( IntPtr gdkDisplay );

		[DllImport( libgdk_name )]
		static public extern IntPtr gdk_wayland_display_get_wl_display( IntPtr gdkDisplay );

		[DllImport( libgdk_name )]
		static public extern IntPtr gdk_wayland_window_get_wl_surface( IntPtr gdkWindow );
	}
}
