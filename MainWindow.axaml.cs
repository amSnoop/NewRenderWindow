using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.ComponentModel;

namespace NewRenderWindow
{
    public partial class MainWindow : Window
    {

        public Button NodesButton, SettingsButton, QueueButton;
        public List<Button> MenuButtons;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitilizeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            NodesButton = this.Find<Button>("Nodes");
            SettingsButton = this.Find<Button>("Settings");
            QueueButton = this.Find<Button>("Queue");
            MenuButtons = new List<Button> { NodesButton, SettingsButton, QueueButton };
        }

        public void OnClickCommand(Button b)
        {
            foreach(var button in MenuButtons)
            {
                if (b != button)
                {
                    b.Classes.Remove(":checked");
                    b.Classes.Add(":unchecked");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(b)));
                }
            }
        }
    }
}
