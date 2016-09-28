# 3DPong

Multiplatform C# 3D Ping Pong created using Unity

Features control support for mouse, keyboard, XBox controllers and tap gestures (On Mobile)

Runs on Windows, Mac, Linux, Android and iOS

Features player vs player, player vs AI or AI vs AI

Contains a console used for controlling the world.

# Controls

On Windows, Linux and Mac, the supported controls are:
- Keyboard (WASD or Left/Right/Up/Down, Escape to pause/open console)
- XBox Controller (Left joystick to move, Start to pause/open console)
- Mouse (Move mouse to use, Escape to pause/open console)

On Android, iOS and Windows phone, the supported controls are:
- Tap/move your finger to move your character
- Tap the "Pause" button to pause the game/bring up the console

# Pause/Settings

The pause/settings page has five options.

The first is a drop down for Player One's control scheme. On desktop this is defaulted to keyboard/XBox controller, while on Mobile this is set to mouse
The second is a drop down for Player Two's control scheme. This is defaulted to AI. To change it to be player two, you simply change this to their prefered control scheme
The third is a Restart Game button. This will reset the game.
The fourth is a Resume button. This will unpause the game. Alternatively, you can click Escape on the keyboard or start on the XBox controller as well
The fifth is a console

# Console

The console follows a specific syntax which is "[Name] [Attribute] [Value]".
Note: Not all names support all attributes, and not all attributes support all values. The general rule of thumb is ball supports speed/color, Rules supports MaxScore.
Everything else only supports color.

Valid names are:
- Background (Supports Color Attribute)
- LeftWall   (Supports Color Attribute)
- RightWall  (Supports Color Attribute)
- Ceiling    (Supports Color Attribute)
- Floor      (Supports Color Attribute)
- Ball       (Supports Color Attribute and Speed Attribute)
- PlayerOne  (Supports Color Attribute)
- PlayerTwo  (Supports Color Attribute)
- Rules      (Supports MaxScore Attribute)

Valid attributes are:
- Color      (Supports "Red", "Blue", "Green", "Black", "White", 6 character RGB and 8 character RGBA)
- Speed		 (Supports "Fast", "Slow", and any integer value. This changes the minimum speed relative to current minimum speed)
- MaxScore   (Supports any integer value above 0)

Valid values are:
- Red
- Green
- Blue
- Black
- White
- 6 character RGB (e.g. FF00FF)
- 8 character RGBA (e.g. FF00FFAA)
- Slow
- Fast
- Integer values

Example commands are as follows:
Background Color Red
LeftWall Color FF00FF
Ball Color FF00FFAA
Ball Speed Slow
Ball Speed -5
Rules MaxScore 10