using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.ComponentModel;

namespace NewRenderWindow
{
    public partial class MainWindow : Window
    {
        public ListBox MenuOptions;

        public Grid MenuPanel;
        public ListBoxItem MenuName;
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.AttachDevTools();
            InitializeMenu();
            this.Find<ListBox>("menuOptions").SelectionChanged += (a, b) =>
            {
                if (b.AddedItems.Count > 0)
                {
                    MenuName = b.AddedItems[0] as ListBoxItem;
                    if (MenuName != null)
                    {
                        Grid menu = this.Find<Grid>("menu" + MenuName);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(menu)));
                    }
                }
            };
        }

        private void InitializeMenu()
        {
            MenuOptions = this.Find<ListBox>("menuOptions");
            MenuOptions.SelectedIndex = 0;
            //Menus.LoadMenu(((ListBoxItem)MenuOptions.SelectedItem).Name, this);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MenuOptions)));
        }
    }
}
