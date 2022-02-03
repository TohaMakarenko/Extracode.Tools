using Terminal.Gui;

namespace Extracode.Tools.Gui.Components;

public static class RightPane
{
    public static FrameView Instance { get; private set; }

    public static FrameView Init()
    {
        Instance = new FrameView ("Scenarios") {
            X = 25,
            Y = 1, // for menu
            Width = Dim.Fill (),
            Height = Dim.Fill (1),
            CanFocus = true,
            Shortcut = Key.CtrlMask | Key.S,
            ColorScheme = BaseColorScheme.Scheme
        };
        Instance.Title = $"{Instance.Title} ({Instance.ShortcutTag})";
        Instance.ShortcutAction = () => Instance.SetFocus ();
        return Instance;
    }

    public static void ChangeTitle(string newTitle)
    {
        Instance.Title = $"{newTitle} ({Instance.ShortcutTag})";   
    }
}