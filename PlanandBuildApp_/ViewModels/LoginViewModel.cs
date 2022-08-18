using PlanandBuildApp_.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PlanandBuildApp_.Services;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace PlanandBuildApp_.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string User_name;
        public string Username_
        {
            get { return this.User_name; }
            set
            {
                this.User_name = value;
                OnPropertyChanged();
            }
        }

        private string Pass_word;
        public string Password_
        {
            get { return this.Pass_word; }
            set
            {
                this.Pass_word = value;
                OnPropertyChanged();
            }
        }

        private bool Is_Busy;
        public bool IsBusy
        {
            get { return this.Is_Busy; }
            set
            {
                this.Is_Busy = value;
                OnPropertyChanged();
            }
        }

        private bool _Result;
        public bool Result
        {
            get { return this._Result; }
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
        }
        public Command Register_Command { get; set; }
        public Command Login_Command { get; set; }

        public LoginViewModel()
        {
            Login_Command = new Command(async () => await LoginCommandAsync_());
            Register_Command = new Command(async () => await RegisterCommandAsync_());
        }

        //login button function
        private async Task LoginCommandAsync_()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserServiceLogin();
                Result = await userService.LoginUser(Username_, Password_);
                if (Result)
                {
                    Preferences.Set("Username", Username_);
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//PlanPage");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Incorrect Details", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        //register button function 
        private async Task RegisterCommandAsync_()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserServiceLogin();
                Result = await userService.RegisterUser(Username_, Password_);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "New User Registered", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User Already Exists", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
