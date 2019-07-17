using System;
using CarouselExperiment.ViewModels;
using System.Collections.Generic;
using CarouselExperiment.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CarouselExperiment.ViewModels
{
    public class CarouselExampleViewModel : BaseViewModel
    {

        public ObservableCollection<Slide> Slides
        {
            get;
            set;
        } = new ObservableCollection<Slide>
        {
            new Slide{Title = "Welcome to my new app", Paragraph="You can use it to do things"},
            new Slide{Title = "This is a page", Paragraph="it's got content"},
            new Slide{Title = "This is a feature", Paragraph="It does stuff"},
            new Slide{Title = "THIS IS A PAGE!", Paragraph="Another page with things in it"},
        };

    }
}