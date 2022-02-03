using Extracode.Tools.Gui.Components;
using Terminal.Gui;

namespace Extracode.Tools.Gui.Backup;

public class BackupRestoreCategory : BaseCategory
{
    public override string Name => "Backup/restore";
    public override int Order => 1;

    public override void Activate()
    {
        base.Activate();
        var text = new TextView()
        {
            X = 0, 
            Y = 0,
            Width = Dim.Fill (),
            Height = Dim.Fill (),
            ReadOnly = true
        };
        text.Text = "Backup/restore";
        RightPane.Instance.Add(text);
    }
}