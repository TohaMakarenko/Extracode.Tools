using Extracode.Tools.Gui.Components;
using Terminal.Gui;

namespace Extracode.Tools.Gui;

public static class Program
{
    private static Toplevel _top;
    private static MenuBar _menu;
    private static FrameView _leftPane;
    private static FrameView _rightPane;
    private static StatusBar _statusBar;
    
    public static void Main(string[] args)
    {
        Application.Init();
        InitTop();
        Application.Run();
    }

    private static void InitTop()
    {
        _top = Application.Top;
        _top.Add (Menu.Init());
        _top.Add (CategoriesPane.Init());
        _top.Add (RightPane.Init());
        _top.Add (Status.Init());
    }
}