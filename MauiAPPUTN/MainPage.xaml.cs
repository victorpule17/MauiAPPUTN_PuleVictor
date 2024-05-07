using MauiAPPUTN.Models;

namespace MauiAPPUTN
{
    public partial class MainPage : ContentPage
    {
        private string ApiUrl = "https://utnusuariosapi.azurewebsites.net/api/Usuarios";
        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdLogin_Clicked(object sender, EventArgs e)
        {
            var nombre = txtUsuario.Text;
            var contrasena = txtContrasenia.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                DisplayAlert("Error", "Por favor ingrese nombre y contraseña.", "OK");
                return;
            }
            var credenciales = APIConsumer.Crud<Usuario>.LeerCredenciales(ApiUrl);
            if (credenciales != null && credenciales.Any(c => c.nombre == nombre && c.contrasena == contrasena))
            {
                DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
                Navigation.PushAsync(new Menu());
            }
            else
            {
                DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
    }
}
