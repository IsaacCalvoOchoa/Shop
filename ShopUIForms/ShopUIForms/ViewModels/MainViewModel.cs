﻿namespace ShopUIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.Common.Models;
    using ShopUIForms.Views;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;

    public class MainViewModel
    {
        private static MainViewModel instance;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public TokenResponse Token { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public AddProductViewModel AddProduct { get; set; }

        public EditProductViewModel EditProduct { get; set; }

        public ICommand AddProductCommand { get { return new RelayCommand(this.GoAddProduct); } }

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private async void GoAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
    {
        new Menu
        {
            Icon = "ic_action_info",
            PageName = "AboutPage",
            Title = "About"
        },

        new Menu
        {
            Icon = "ic_action_settings",
            PageName = "SetupPage",
            Title = "Setup"
        },

        new Menu
        {
            Icon = "ic_action_logout",
            PageName = "LoginPage",
            Title = "Close session"
        }
    };

            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }


        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
