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
		public IReadOnlyList<Key> SupportedKeys => throw new NotImplementedException();

		public string ClipboardText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string Name => throw new NotImplementedException();

		public int Index => throw new NotImplementedException();

		public bool IsConnected => throw new NotImplementedException();

		public event Action<IKeyboard, Key, int>? KeyDown;
		public event Action<IKeyboard, Key, int>? KeyUp;
		public event Action<IKeyboard, char>? KeyChar;

		public void BeginInput()
		{
			throw new NotImplementedException();
		}

		public void EndInput()
		{
			throw new NotImplementedException();
		}

		public bool IsKeyPressed( Key key )
		{
			throw new NotImplementedException();
		}

		public bool IsScancodePressed( int scancode )
		{
			throw new NotImplementedException();
		}
	}

	public class EtoMouse : IMouse
	{
		public IReadOnlyList<MouseButton> SupportedButtons => throw new NotImplementedException();

		public IReadOnlyList<ScrollWheel> ScrollWheels => throw new NotImplementedException();

		public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public ICursor Cursor => throw new NotImplementedException();

		public int DoubleClickTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int DoubleClickRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
		IKeyboard[] mKeyboards;
		IMouse[] mMice;

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
