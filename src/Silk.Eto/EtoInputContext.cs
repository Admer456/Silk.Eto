// SPDX-FileCopyrightText: 2024-present Silk.Eto contributors
// SPDX-License-Identifier: MIT

using Silk.NET.Core.Contexts;
using Silk.NET.Input;
using Silk.NET.Windowing;
using System.Numerics;

namespace Silk.Eto
{
	public class EtoKeyboard : IKeyboard
	{
		public IReadOnlyList<Key> SupportedKeys => Array.Empty<Key>();

		public string ClipboardText { get; set; } = string.Empty;

		public string Name => "Basic keyboard";

		public int Index => 0;

		public bool IsConnected => true;

		public event Action<IKeyboard, Key, int>? KeyDown;
		public event Action<IKeyboard, Key, int>? KeyUp;
		public event Action<IKeyboard, char>? KeyChar;

		public void BeginInput()
		{
		}

		public void EndInput()
		{
		}

		// TODO: implement keyboard
		public bool IsKeyPressed( Key key ) => false;
		public bool IsScancodePressed( int scancode ) => false;
	}

	public class EtoMouse : IMouse
	{
		public IReadOnlyList<MouseButton> SupportedButtons => Array.Empty<MouseButton>();

		public IReadOnlyList<ScrollWheel> ScrollWheels => Array.Empty<ScrollWheel>();

		public Vector2 Position { get; set; } = Vector2.Zero;

		public ICursor Cursor => throw new NotImplementedException();

		public int DoubleClickTime { get; set; } = 10;
		public int DoubleClickRange { get; set; } = 10;

		public string Name => "Mouse";

		public int Index => 0;

		public bool IsConnected => true;

		public event Action<IMouse, MouseButton> MouseDown;
		public event Action<IMouse, MouseButton> MouseUp;
		public event Action<IMouse, MouseButton, Vector2> Click;
		public event Action<IMouse, MouseButton, Vector2> DoubleClick;
		public event Action<IMouse, Vector2> MouseMove;
		public event Action<IMouse, ScrollWheel> Scroll;

		public bool IsButtonPressed( MouseButton btn )
		{
			return false;
		}
	}

	public class EtoInputContext : IInputContext
	{
		SilkSurface mSurface;
		IKeyboard[] mKeyboards = [new EtoKeyboard()];
		IMouse[] mMice = [new EtoMouse()];

		public EtoInputContext( SilkSurface surface )
		{
			mSurface = surface;
		}

		public nint Handle => mSurface.Handle;

		public IReadOnlyList<IGamepad> Gamepads => Array.Empty<IGamepad>();

		public IReadOnlyList<IJoystick> Joysticks => Array.Empty<IJoystick>();

		public IReadOnlyList<IKeyboard> Keyboards => mKeyboards;

		public IReadOnlyList<IMouse> Mice => mMice;

		public IReadOnlyList<IInputDevice> OtherDevices => Array.Empty<IInputDevice>();

		public event Action<IInputDevice, bool>? ConnectionChanged;

		public void Dispose()
		{

		}
	}
}
