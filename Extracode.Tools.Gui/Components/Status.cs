using Terminal.Gui;

namespace Extracode.Tools.Gui.Components;

public static class Status
{
    public static StatusBar Instance { get; private set; }

    public static StatusBar Init()
    {
        Instance = new StatusBar () {
            Visible = true,
        };
        return Instance;
    }
}