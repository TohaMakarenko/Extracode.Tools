using Extracode.Tools.Gui.Components;

namespace Extracode.Tools.Gui;

public abstract class BaseCategory
{
    public abstract string Name { get; }
    public abstract int Order { get; }

    public virtual void Activate()
    {
        RightPane.ChangeTitle(Name);
    }

    public virtual void Deactivate()
    {
        RightPane.Instance.RemoveAll();
    }
}