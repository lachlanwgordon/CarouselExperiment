using System;
using System.Collections.Generic;
using CarouselExperiment.ViewModels;
using Xamarin.Forms;

namespace CarouselExperiment
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public static new  AppShell Current { get; private set; }

        public AppShellViewModel VM { get => BindingContext as AppShellViewModel; }

        public AppShell()
        {
            InitializeComponent();
            Current = this;
        }
    }
}
