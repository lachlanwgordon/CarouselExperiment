using Xamarin.Forms;
using System.Windows.Input;
using System;

namespace CarouselExperiment.Models
{
    public class Slide
    {
        public ICommand HideOneBoarding
        {
            get
            {
                return new Command(() =>
                {
                    throw new NotImplementedException();
                });
            }
        }

        public string Paragraph
        {
            get;
            set;
        }

        public string Title { get; set; }
        public string ImageSource { get; set; }

    }
}