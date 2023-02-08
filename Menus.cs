using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.FreeDesktop.DBusIme;
using Avalonia.LogicalTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRenderWindow
{
    public static class Menus
    {
        private static string _lastMenuName = "";
        public static void LoadMenu(string menuName, Window parent)
        {
            Grid menuPanel = parent.Find<Grid>("menuPanel");
            Grid menuSelected = parent.Find<Grid>("menu" + menuName);
            if (menuName == "")
            {
                menuPanel.IsVisible = false;
                return;
            }
            if(menuName == _lastMenuName)
            {
                menuPanel.IsVisible = true;
                return;
            }
            foreach(var menu in menuPanel.Children)
            {
                if(menu.Name != menuName && menu.GetType() == typeof(Grid))
                {
                    menu.IsVisible = false;
                }
            }
            menuPanel.Children.Clear();
            menuPanel.IsVisible = true;
            menuPanel.ColumnDefinitions.Clear();
            menuPanel.RowDefinitions.Clear();
            _lastMenuName = menuName;
            switch (menuName)
            {
                case "Nodes":
                    LoadNodes(menuSelected);
                    break;
                case "Settings":
                    LoadSettings(menuSelected);
                    break;

                case "Queue":
                    LoadQueue(menuSelected);
                    break;
            }
        }

        private static void LoadNodes(Grid grid)
        {
            grid.IsVisible = true;
        }

        private static void LoadSettings(Grid grid) 
        {
            grid.IsVisible = true;
        }
        private static void LoadQueue(Grid grid)
        {
            grid.IsVisible = true;
        }
    }
}
