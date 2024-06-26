﻿// SPDX-FileCopyrightText: 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using Eto.Forms;
using Silk.NET.Input;
using Silk.NET.Windowing;

namespace Silk.Eto
{
	public class EtoInputPlatform : IInputPlatform
	{
		public IInputContext CreateInput( IView view )
			=> new EtoInputContext( view as SilkSurface ?? throw new Exception( "Provided view was not a SilkSurface" ) );

		public bool IsApplicable( IView view )
			=> view is Control;
	}
}
