﻿using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPages : ContentPage
    {
        public ResultPages(List<Cabinet> cabinets)
        {
            InitializeComponent();
        }
    }
}