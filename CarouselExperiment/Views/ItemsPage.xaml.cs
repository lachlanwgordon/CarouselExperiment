using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CarouselExperiment.Models;
using CarouselExperiment.Views;
using CarouselExperiment.ViewModels;

namespace CarouselExperiment.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        public void HelpClicked(object sender, EventArgs e)
        {
            TheCarousel.ScrollTo(0, animate: false);
            viewModel.OnboardingVisible = true;
        }

        public void NextClicked(object sender, EventArgs e)
        {
            var slide = ((sender as View).BindingContext as Slide);
            var index = viewModel.Slides.IndexOf(slide);

            if (index < viewModel.Slides.Count - 1)
            {
                TheCarousel.ScrollTo(index + 1);
            }
            else
            {
                viewModel.OnboardingVisible = false;
            }


        }

        public void BackClicked(object sender, EventArgs e)
        {
            var slide = ((sender as View).BindingContext as Slide);
            var index = viewModel.Slides.IndexOf(slide);
            if (index > 0)
            {
                TheCarousel.ScrollTo(index - 1);
            }
        }

        public void DoneClicked(object sender, EventArgs e)
        {
            viewModel.OnboardingVisible = false;
        }

        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);

            viewModel.OnboardingVisible = true;
        }
    }
}