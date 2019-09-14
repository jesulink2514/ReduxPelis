﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduxPelis.Models;
using ReduxPelis.Navigation;
using ReduxPelis.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReduxPelis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Resolve<MovieDetailsPageViewModel>();
        }
    }
}