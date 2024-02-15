using Gtk;

namespace Silk.Eto.Gtk
{
	public class GtkSilkDrawingArea : GLArea
	{
		public GtkSilkDrawingArea()
		{
			CanFocus = true;

			// Veldrid technically supports as low as OpenGL 3.0, but the full
			// complement of features is only available with 3.3 and higher.
			SetRequiredVersion( 3, 3 );

			HasDepthBuffer = false;
			HasStencilBuffer = false;
		}
	}
}
