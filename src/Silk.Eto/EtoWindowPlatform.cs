﻿// SPDX-FileCopyrightText: 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using Silk.Eto;
using Silk.NET.Windowing;

namespace Elegy.GuiLauncher
{
	public class EtoWindowPlatform : IWindowPlatform
	{
		public bool IsViewOnly => false;

		public bool IsApplicable => true;

		public void ClearContexts()
		{

		}

		public IWindow CreateWindow( WindowOptions opts )
		{
			throw new NotSupportedException();
		}

		public IMonitor GetMainMonitor()
		{
			throw new NotSupportedException();
		}

		public IEnumerable<IMonitor> GetMonitors()
		{
			throw new NotSupportedException();
		}

		public IView GetView( ViewOptions? opts = null )
		{
			throw new NotSupportedException();
		}

		public bool IsSourceOfView( IView view )
		{
			return view is SilkSurface;
		}
	}
}
