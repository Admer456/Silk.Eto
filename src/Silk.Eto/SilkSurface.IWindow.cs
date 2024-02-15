using Eto.Drawing;
using Eto.Forms;
using Silk.NET.Core;
using Silk.NET.Core.Contexts;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using System.Diagnostics;

namespace Silk.Eto
{
	public partial class SilkSurface : Control, IWindow
	{
		Vector2D<int> IWindowProperties.Size { get => new( Size.Width, Size.Height ); set => Size = new( value.X, value.Y ); }
		Vector2D<int> IViewProperties.Size => ((IWindowProperties)this).Size;
		bool IView.IsClosing => IsClosing;
		IWindowHost? IWindow.Parent => null;

		private Stopwatch mTimer;
		private INativeWindow mNativeWindow;

		public IMonitor? Monitor { get => null; set { } }

		public bool IsClosing { get => false; set { } }

		public Rectangle<int> BorderSize => throw new NotSupportedException();

		public bool IsVisible { get => Visible; set => Visible = value; }
		public Vector2D<int> Position { get => new( Location.X, Location.Y ); set { } }
		public string Title { get; set; } = string.Empty;
		public NET.Windowing.WindowState WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public WindowBorder WindowBorder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool TransparentFramebuffer => false;

		public bool TopMost { get => false; set { } }

		public IGLContext? SharedContext => null;

		public string? WindowClass => null;

		public nint Handle => 0;

		public double Time => mTimer.Elapsed.TotalSeconds;

		public Vector2D<int> FramebufferSize => ((IWindowProperties)this).Size;

		public bool IsInitialized => true;

		public bool ShouldSwapAutomatically { get => false; set { } }
		public bool IsEventDriven { get => true; set { } }
		public bool IsContextControlDisabled { get => false; set { } }


		// TODO: Cache the display rate of the current monitor
		public double FramesPerSecond { get => 60.0; set { } }
		public double UpdatesPerSecond { get => 60.0; set { } }

		public GraphicsAPI API { get; private set; }

		public bool VSync { get => false; set { } }

		public VideoMode VideoMode => default;

		public int? PreferredDepthBufferBits => null;

		public int? PreferredStencilBufferBits => null;

		public Vector4D<int>? PreferredBitDepth => Vector4D<int>.One * 8;

		public int? Samples => 1;

		public IGLContext? GLContext => null;

		public IVkSurface? VkSurface => null;

		public INativeWindow? Native => mNativeWindow;

		public event Action<Vector2D<int>>? Move;
		public event Action<NET.Windowing.WindowState>? StateChanged;
		public event Action<string[]>? FileDrop;
		public event Action<Vector2D<int>>? FramebufferResize;
		public event Action? Closing;
		public event Action<bool>? FocusChanged;
		public event Action<double>? Update;
		public event Action<double>? Render;

		event Action<Vector2D<int>>? IView.Resize
		{
			add => Resize += ( sender, e ) =>
			{
				if ( value is not null ) value( new( e.Width, e.Height ) );
			};

			remove => Resize -= ( sender, e ) =>
			{
				if ( value is not null ) value( new( e.Width, e.Height ) );
			};
		}

		event Action? IView.Load
		{
			add => Load += ( sender, e ) =>
			{
				if ( value is not null ) value();
			};

			remove => Load -= ( sender, e ) =>
			{
				if ( value is not null ) value();
			};
		}

		public void SetWindowIcon( ReadOnlySpan<RawImage> icons )
		{
		}

		public IWindow CreateWindow( WindowOptions opts )
		{
			throw new NotImplementedException();
		}

		void IView.Initialize()
		{
		}

		public void DoRender()
		{
		}

		public void DoUpdate()
		{
		}

		public void DoEvents()
		{
		}

		public void ContinueEvents()
		{
		}

		public void Reset()
		{
		}

		public void Close()
		{
		}

		public Vector2D<int> PointToClient( Vector2D<int> point )
		{
			return point;
		}

		public Vector2D<int> PointToScreen( Vector2D<int> point )
		{
			return point;
		}

		public Vector2D<int> PointToFramebuffer( Vector2D<int> point )
		{
			return point;
		}

		public object Invoke( Delegate d, params object[] args )
		{
			return default;
		}

		public void Run( Action onFrame )
		{

		}
	}
}
