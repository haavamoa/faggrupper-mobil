﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsBluePrint.Services;
using FriendsBluePrint.ViewModels;
using Xamarin.Forms;

namespace FriendsBluePrint
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel m_mainViewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            
            //Dependency injection
            BindingContext = m_mainViewModel = mainViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext == m_mainViewModel)
            {
                m_mainViewModel.Initialize();    
            }
        }
    }
}