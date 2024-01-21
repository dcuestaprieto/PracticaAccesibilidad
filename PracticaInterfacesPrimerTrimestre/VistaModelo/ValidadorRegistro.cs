using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaInterfacesPrimerTrimestre.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.VistaModelo
{
    public partial class ValidadorRegistro : ObservableValidator
    {
        public ObservableCollection<string> Errors { get; set; } = new ObservableCollection<string>();

        private string name;
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string username;
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        [Required(ErrorMessage = "La contraseña es requerida")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "La contraseña debe estar compuesta de mayusculas, minusculas, números y caracteres especiales")]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        [RelayCommand]
        public async void Validar()
        {
            Errors.Clear();
            ValidateAllProperties();
            GetErrors(nameof(Name)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(Username)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));

            if (Errors.Count == 0)
            {
                //después de validar que no haya ningún error, valido que el nombre introducido no exista ya en la base de datos
                if (!App.UsuarioRepositorio.UsernameExists(Username))
                {
                    //si no existe lo añado a la base de datos
                    App.UsuarioRepositorio.Add(new User { Name = this.Name, Username = this.Username, Password = this.Password});
                    VariablesCompartidas.CurrentUser = Username;
                    //TODO cambiar a la vista correcta
                    await AppShell.Current.GoToAsync(nameof(Vista.VistaPerros));
                }
                else
                {
                    //si sí existe añado un error
                    Errors.Add("El usuario ya existe");
                }
            }

        }
        [RelayCommand]
        public async void ChangeToSignInView()
        {
            await AppShell.Current.GoToAsync(nameof(Vista.VistaInicio));
        }

    }
}
