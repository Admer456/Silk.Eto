using Eto.Drawing;
using Eto.Wpf.Forms;
using Eto.Veldrid.Wpf;
using System;
using Silk.NET.Core.Contexts;
using System.Runtime.InteropServices;

[assembly: Eto.ExportHandler( typeof( Silk.Eto.SilkSurface ), typeof( Silk.Eto.Wpf.WpfSilkSurfaceHandler ) )]

namespace Silk.Eto.Wpf
{
	public class WpfSilkSurfaceHandler : ManualBubbleWindowsFormsHostHandler<WinFormsSilkUserControl, SilkSurface, SilkSurface.ICallback>, SilkSurface.IHandler
	{
		public Size RenderSize => Size.Round( (SizeF)Widget.Size * Scale );

		float Scale => Widget.ParentWindow?.LogicalPixelSize ?? 1;

		public WpfSilkSurfaceHandler() : base( new WinFormsSilkUserControl() )
		{
			Control.Loaded += Control_Loaded;
		}

		public INativeWindow CreateNativeWindow()
		{
			return EtoNativeSurface.CreateWin32(
				WinFormsControl.Handle,
				0,
				Marshal.GetHINSTANCE( typeof( SilkSurface ).Module ) );
		}

		private void Control_Loaded( object sender, System.Windows.RoutedEventArgs e )
		{
			Control.Loaded -= Control_Loaded;
			Widget.SizeChanged += Widget_SizeChanged;

			// Hackity hack!!!
			WinFormsControl.Paint += ( sender, e ) =>
			{
				WinFormsControl.Refresh();
			};
		}

		private void Widget_SizeChanged( object sender, EventArgs e )
		{
			Callback.OnResize( Widget, new ResizeEventArgs( RenderSize ) );
		}

		public override void AttachEvent( string id )
		{
			switch ( id )
			{
				case SilkSurface.DrawEvent:
					WinFormsControl.Paint += ( sender, e ) => Callback.OnDraw( Widget, EventArgs.Empty );
					break;
				default:
					base.AttachEvent( id );
					break;
			}
		}
	}
}
