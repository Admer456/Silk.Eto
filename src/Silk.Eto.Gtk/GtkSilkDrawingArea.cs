// SPDX-FileCopyrightText: 2018-2020 Eto.Veldrid authors, 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

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
