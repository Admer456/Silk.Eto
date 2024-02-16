// SPDX-FileCopyrightText: 2018-2020 Eto.Veldrid authors, 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using Eto;
using Eto.Drawing;
using Eto.Forms;
using Silk.NET.Core.Contexts;
using System.Diagnostics;

namespace Silk.Eto
{
	/// <summary>
	/// A simple control that allows drawing with Veldrid.
	/// </summary>
	[Handler( typeof( SilkSurface.IHandler ) )]
	public partial class SilkSurface : Control, Silk.NET.Windowing.IWindow
	{
		public new interface IHandler : Control.IHandler
		{
			Size RenderSize { get; }
			INativeWindow CreateNativeWindow();
		}

		new IHandler Handler => (IHandler)base.Handler;

		public new interface ICallback : Control.ICallback
		{
			void OnDraw( SilkSurface s, EventArgs e );
			void OnResize( SilkSurface s, ResizeEventArgs e );
		}

		protected new class Callback : Control.Callback, ICallback
		{
			public void OnDraw( SilkSurface s, EventArgs e ) => s?.OnDraw( e );
			public void OnResize( SilkSurface s, ResizeEventArgs e ) => s?.OnResize( e );
		}

		protected override object GetCallback() => new Callback();

		/// <summary>
		/// The render area's size, which may differ from the control's size
		/// (e.g. with high DPI displays).
		/// </summary>
		public Size RenderSize => Handler.RenderSize;
		/// <summary>
		/// The render area's width, which may differ from the control's width
		/// (e.g. with high DPI displays).
		/// </summary>
		public int RenderWidth => RenderSize.Width;
		/// <summary>
		/// The render area's height, which may differ from the control's height
		/// (e.g. with high DPI displays).
		/// </summary>
		public int RenderHeight => RenderSize.Height;

		public const string DrawEvent = "SilkSurface.Draw";
		public const string ResizeEvent = "SilkSurface.Resize";

		public event EventHandler<EventArgs> Draw
		{
			add { Properties.AddHandlerEvent( DrawEvent, value ); }
			remove { Properties.RemoveEvent( DrawEvent, value ); }
		}
		public event EventHandler<ResizeEventArgs> Resize
		{
			add { Properties.AddHandlerEvent( ResizeEvent, value ); }
			remove { Properties.RemoveEvent( ResizeEvent, value ); }
		}

		public SilkSurface()
		{
			mTimer = Stopwatch.StartNew();

			Load += ( sender, e ) =>
			{
				mTimer.Restart();
				mNativeWindow = Handler.CreateNativeWindow();
			};
		}

		protected virtual void OnDraw( EventArgs e ) => Properties.TriggerEvent( DrawEvent, this, e );

		protected virtual void OnResize( ResizeEventArgs e )
		{
			if ( e == null )
				throw new ArgumentNullException( nameof( e ) );

			Properties.TriggerEvent( ResizeEvent, this, e );

			FramebufferResize?.Invoke( new( e.Width, e.Height ) );
		}
		
		public void ForceResizeEvent()
		{
			FramebufferResize?.Invoke( new( Width, Height ) );
		}
	}
}
