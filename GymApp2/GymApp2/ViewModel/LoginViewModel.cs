using GymApp.Services;
using GymApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GymApp.ViewModels
{
    public class LoginViewModel : BaseModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }


        }
        //private int _IDUser;
        //public int IDUser
        //{
        //    set
        //    {
        //        this._IDUser = value;
        //        OnPropertyChanged();
        //    }
        //    get
        //    {
        //        return this._IDUser;
        //    }
        //}

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }


        }

        private string _Age;
        public string Age
        {
            set
            {
                this._Age = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Age;
            }


        }

        private string _Height;
        public string Height
        {
            set
            {
                this._Height = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Height;
            }


        }

        private string _Weight;
        public string Weight
        {
            set
            {
                this._Weight = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Weight;
            }


        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }


        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public Command RegisterViewCommand { get; set; }
        public Command LoginViewCommand { get; set; }
 

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
            RegisterViewCommand = new Command(async () => await RegisterViewAsync());
            

        }




        private async Task RegisterViewAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new Reg());
        }

        private async Task RegisterCommandAsync()
        {


            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password, Age, Height, Weight);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "User already exists with this credentials", "OK");
                }

                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

            
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new AppShell());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
