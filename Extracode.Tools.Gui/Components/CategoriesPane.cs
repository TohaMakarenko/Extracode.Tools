using Terminal.Gui;

namespace Extracode.Tools.Gui.Components;

public static class CategoriesPane
{
    public static FrameView Instance { get; private set; }

    private static ListView _categoryListView;
    private static int _categoryListViewItem;

    private static List<string> _categories;
    private static Dictionary<string, BaseCategory> _categoryInstances;
    private static BaseCategory _activeCategory;

    public static FrameView Init()
    {
        Instance = new FrameView("Categories")
        {
            X = 0,
            Y = 1, // for menu
            Width = 25,
            Height = Dim.Fill(1),
            CanFocus = false,
            Shortcut = Key.CtrlMask | Key.C,
            ColorScheme = BaseColorScheme.Scheme
        };
        Instance.Title = $"{Instance.Title} ({Instance.ShortcutTag})";
        Instance.ShortcutAction = () => Instance.SetFocus();
        Instance.Add(InitGetCategoriesListView());
        return Instance;
    }

    private static ListView InitGetCategoriesListView()
    {
        InitCategories();
        _categoryListView = new ListView(_categories)
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(0),
            Height = Dim.Fill(0),
            AllowsMarking = false,
            CanFocus = true,
        };
        _categoryListView.OpenSelectedItem += (a) => { RightPane.Instance.SetFocus(); };
        _categoryListView.SelectedItemChanged += CategoryListListViewSelectedChanged;
        return _categoryListView;
    }

    private static void InitCategories()
    {
        var categoryTypes = typeof(BaseCategory).Assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(BaseCategory)))
            .ToList();
        _categoryInstances = categoryTypes
            .Select(type => (BaseCategory)Activator.CreateInstance(type))
            .ToDictionary(category => category.Name);
        _categories = _categoryInstances.OrderBy(x => x.Value.Order).Select(x => x.Value.Name).ToList();
    }

    private static void CategoryListListViewSelectedChanged(ListViewItemEventArgs e)
    {
        /*if (_categoryListViewItem == _categoryListView.SelectedItem)
            return;*/
        _activeCategory?.Deactivate();
        _categoryListViewItem = _categoryListView.SelectedItem;
        var item = _categories[_categoryListView.SelectedItem];
        _activeCategory = _categoryInstances[item];
        _activeCategory.Activate();
    }
}