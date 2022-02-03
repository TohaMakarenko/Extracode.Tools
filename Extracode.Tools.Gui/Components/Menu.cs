using Terminal.Gui;

namespace Extracode.Tools.Gui.Components;

public static class Menu
{
    public static MenuBar Instance { get; private set; }

    public static MenuBar Init()
    {
        Instance = new MenuBar (new MenuBarItem [] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => Application.RequestStop(), null, null, Key.Q | Key.CtrlMask)
            }),
        });
        return Instance;
    }
}