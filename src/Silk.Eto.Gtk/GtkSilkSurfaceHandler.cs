// SPDX-FileCopyrightText: 2018-2020 Eto.Veldrid authors, 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using Eto.Drawing;
using Eto.GtkSharp.Forms;
using Gtk;
using Silk.NET.Core.Contexts;

[assembly: Eto.ExportHandler( typeof( Silk.Eto.SilkSurface ), typeof( Silk.Eto.Gtk.GtkSilkSurfaceHandler ) )]

namespace Silk.Eto.Gtk
{
	public class GtkSilkSurfaceHandler : GtkControl<GtkSilkDrawingArea, SilkSurface, SilkSurface.ICallback>, SilkSurface.IHandler
	{
		public Size RenderSize => Size.Round( (SizeF)Widget.Size * Scale );

		float Scale => Widget.ParentWindow?.LogicalPixelSize ?? 1;

		public GtkSilkSurfaceHandler()
		{
			Control = new GtkSilkDrawingArea();
			Control.Render += Control_InitializeGraphicsBackend;
		}

		public INativeWindow CreateNativeWindow()
		{
			if ( IsWayland() )
			{
				return EtoNativeSurface.CreateWayland(
					GdkInterop.gdk_wayland_display_get_wl_display( Control.Display.Handle ),
					GdkInterop.gdk_wayland_window_get_wl_surface( Control.Window.Handle ) );
			}

			return EtoNativeSurface.CreateX11(
				GdkInterop.gdk_x11_display_get_xdisplay( Control.Display.Handle ),
				(nuint)GdkInterop.gdk_x11_window_get_xid( Control.Window.Handle ) );
		}

		// This seems to be a thorough enough way of checking for Wayland:
		// https://github.com/libsdl-org/SDL/blob/main/src/video/wayland/SDL_waylandmessagebox.c#L144
		static bool IsWayland()
			=> Environment.GetEnvironmentVariable( "WAYLAND_DISPLAY" ) is not null;

		void Control_InitializeGraphicsBackend( object o, RenderArgs args )
		{
			Control.Render -= Control_InitializeGraphicsBackend;
			Control.Render += Control_Render;
			Widget.SizeChanged += Widget_SizeChanged;
		}

		private void Widget_SizeChanged( object sender, EventArgs e ) => Callback.OnResize( Widget, new ResizeEventArgs( RenderSize ) );

		void Control_Render( object o, RenderArgs args ) => Callback.OnDraw( Widget, args );
	}
}
