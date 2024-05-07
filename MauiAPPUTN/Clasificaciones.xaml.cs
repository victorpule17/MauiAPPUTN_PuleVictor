using MauiAPPUTN.Models;
namespace MauiAPPUTN;

public partial class Clasificaciones : ContentPage
{
    private string ApiUrl = "https://appwebutn1.azurewebsites.net/api/Clasificaciones";
    public Clasificaciones()
	{
		InitializeComponent();
	}
    private void cmdCrear_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtClasificacion.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        var resultado = APIConsumer.Crud<Clasificacion>.Create(ApiUrl, new Clasificacion
        {
            Id = 0,
            Descripcion = txtClasificacion.Text
        });

        if (resultado != null)
        {
            DisplayAlert("�xito", "Clasificaci�n Creada con exito", "OK");
            txtIdClasificacion.Text = resultado.Id.ToString();
        }
    }

    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdClasificacion.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la clasificaci�n que desea buscar.", "OK");
            return;
        }
        var (clasificacion, found) = APIConsumer.Crud<Clasificacion>.Read_ById(ApiUrl, int.Parse(txtIdClasificacion.Text));
        if (found)
        {
            txtIdClasificacion.Text = clasificacion.Id.ToString();
            txtClasificacion.Text = clasificacion.Descripcion;
        }
        else
        {
            DisplayAlert("Error", "Clasificaci�n no encontrada", "OK");
            txtIdClasificacion.Text = "";
            txtClasificacion.Text = "";
        }
    }

    private void cmdActualizar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtClasificacion.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Clasificacion>.Update(ApiUrl, int.Parse(txtIdClasificacion.Text), new Clasificacion
        {
            Id = int.Parse(txtIdClasificacion.Text),
            Descripcion = txtClasificacion.Text
        });
        if (!success)
        {
            DisplayAlert("Error", "Actualizaci�n fallida. La clasificaci�n no existe o no pudo actualizarse.", "OK");
        }
        else
        {
            DisplayAlert("�xito", "Clasificaci�n actualizada correctamente.", "OK");
        }
    }

    private void cmdEliminar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdClasificacion.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la clasificaci�n que desea eliminar.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Clasificacion>.Delete(ApiUrl, int.Parse(txtIdClasificacion.Text));
        if (!success)
        {
            DisplayAlert("Error", "Eliminar fallido. La clasificaci�n no existe o no pudo eliminarse.", "OK");
        }
        else
        {
            DisplayAlert("�xito", "Clasificaci�n eliminada correctamente.", "OK");
            txtIdClasificacion.Text = "";
            txtClasificacion.Text = "";
        }
    }

    private void cmdNext_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Productos());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}