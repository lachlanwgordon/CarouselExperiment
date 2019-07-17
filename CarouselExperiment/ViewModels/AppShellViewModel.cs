using System;

namespace CarouselExperiment.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private bool onBoardingVisible = true;

        public bool OnBoardingVisible
        {
            get => onBoardingVisible;
            set
            {
                onBoardingVisible = value;
                OnPropertyChanged(nameof(OnBoardingVisible));
                OnPropertyChanged(nameof(TabsActive));
            }
        }
        public bool TabsActive { get => !OnBoardingVisible; }


    }
}