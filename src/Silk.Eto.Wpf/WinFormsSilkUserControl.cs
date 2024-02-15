
using System.Windows.Forms;

namespace Eto.Veldrid.Wpf
{
	public class WinFormsSilkUserControl : UserControl
	{
		public WinFormsSilkUserControl()
		{
			SetStyle( ControlStyles.Opaque, true );
			SetStyle( ControlStyles.UserPaint, true );
			SetStyle( ControlStyles.AllPaintingInWmPaint, true );
			DoubleBuffered = false;
		}
	}
}
