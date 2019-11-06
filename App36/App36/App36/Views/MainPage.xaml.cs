using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App36.Models;
using Syncfusion.TreeView.Engine;

namespace App36.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        private void treeView_ItemTapped(object sender, Syncfusion.XForms.TreeView.ItemTappedEventArgs e)
        {

            var TappedNode = e.Node as TreeViewNode;

            Console.WriteLine(TappedNode.Content);


            if (TappedNode.Content is "Menu 1")
            {
                Detail = new NavigationPage(new ItemsPage());
                IsPresented = false;
            }
            else if (TappedNode.Content is "Menu 1.1")
            {
                Detail = new NavigationPage(new AboutPage());
                IsPresented = false;
            }
            else if (TappedNode.Content is "Menu 1.2")
            {
                //...
            }
            else
            {
                //...
            }
        }

    }
}