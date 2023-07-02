using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.MauiForBeginners.ViewModels
{
    public partial class LoginViewModel : ObservableValidator
    {
        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        string login;

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        string password;


        [RelayCommand]
        private void ShowErrors()
        {
            string message = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));

            Shell.Current.DisplayAlert("Validation errors", message, "OK");
        }

    }
}
