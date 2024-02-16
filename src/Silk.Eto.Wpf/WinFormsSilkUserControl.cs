// SPDX-FileCopyrightText: 2018-2020 Eto.Veldrid authors, 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

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
