using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CarouselExperiment.Models;
using CarouselExperiment.Views;
using System.Collections.Generic;

namespace CarouselExperiment.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public bool OnboardingVisible
        {
            get => AppShell.Current.VM.OnBoardingVisible;
            set
            {
                AppShell.Current.VM.OnBoardingVisible = value;
                OnPropertyChanged(nameof(OnboardingVisible));
                OnPropertyChanged(nameof(ButtonEnabled));
            }
        }

        public bool ButtonEnabled { get => AppShell.Current.VM.OnBoardingVisible; }

        public ObservableCollection<Slide> Slides
        {
            get;
            set;
        } = new ObservableCollection<Slide>
        {
            new Slide{Title = "Welcome to Onboarding", Paragraph="This app demonstrates how to use the new Carousel View to show an Onboarding Flow"},
            new Slide{Title = "Tabs", Paragraph="You can change between pages using the tabs at the bottom of the screen"},
            new Slide{Title = "Items", Paragraph="The first page of the app contains a list of items.\nClick any items for details."},
            new Slide{Title = "Details", Paragraph="Each item has more information on it's details page, click back when you're done."},
            new Slide{Title = "New Item", Paragraph="On the list page you can click 'Add' to create another item."},
            new Slide{Title = "About", Paragraph="The about page has details of the developers of this app"},
            new Slide{Title = "That's all", Paragraph="Great, you're ready to start using the app!"},
        };

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}