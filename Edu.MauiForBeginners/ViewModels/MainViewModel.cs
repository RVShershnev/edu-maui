using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.MauiForBeginners.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity { get; set; }
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
            this.connectivity = Connectivity.Current; 
        }

        [ObservableProperty]
        ObservableCollection<string> _items;


        [ObservableProperty]
        string _text;

        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Uh Oh", "No Internet", "OK");
                return;
            }

            Items.Add(Text);
            Text = string.Empty;
        }


        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}", true);
        }
    }
}
