using MauiAPPUTN.Models;

namespace MauiAPPUTN;

public partial class Productos : ContentPage
{
    private string ApiUrlProd = "https://appwebutn1.azurewebsites.net/api/Productos";
    public Productos()
	{
		InitializeComponent();
	}

    private void cmdCreateProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
            string.IsNullOrWhiteSpace(txtExistencia.Text) ||
            string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ||
            string.IsNullOrWhiteSpace(txtIVA.Text) ||
            string.IsNullOrWhiteSpace(txtClasificacionID.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        var prod = APIConsumer.Crud<Producto>.Create(ApiUrlProd, new Producto
        {
            Id = 0,
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
        if (prod != null)
        {
            DisplayAlert("Éxito", "Producto Creado con exito", "OK");
            txtIdProducto.Text = prod.Id.ToString();
        }
    }
    private void cmdLeerProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del producto que desea buscar.", "OK");
            return;
        }
        var (prod, found) = APIConsumer.Crud<Producto>.Read_ById(ApiUrlProd, int.Parse(txtIdProducto.Text));
        if (found)  
        {
            txtIdProducto.Text = prod.Id.ToString();
            txtNombreProducto.Text = prod.Nombre.ToString();
            txtExistencia.Text = prod.Existencia.ToString();
            txtPrecioUnitario.Text = prod.PrecioUnitario.ToString();
            txtIVA.Text = prod.IVA.ToString();
            txtClasificacionID.Text = prod.ClasificacionId.ToString();
        }
        else
        {
            DisplayAlert("Error", "No existe el producto", "OK");
        }
    }

    private void cmdUpdateProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text) ||
            string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
            string.IsNullOrWhiteSpace(txtExistencia.Text) ||
            string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ||
            string.IsNullOrWhiteSpace(txtIVA.Text) ||
            string.IsNullOrWhiteSpace(txtClasificacionID.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Producto>.Update(ApiUrlProd, int.Parse(txtIdProducto.Text), new Producto
        {
            Id = int.Parse(txtIdProducto.Text),
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
        if (!success)
        {
            DisplayAlert("Error", "Actualización fallida. El producto no existe.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Producto actualizado correctamente.", "OK");
        }
    }

    private void cmdDeleteProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del producto que desea eliminar.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Producto>.Delete(ApiUrlProd, int.Parse(txtIdProducto.Text));
        if (!success)
        {
            DisplayAlert("Error", "Producto no encontrado para eliminar.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Producto eliminado correctamente.", "OK");
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtExistencia.Text = "";
            txtPrecioUnitario.Text = "";
            txtIVA.Text = "";
            txtClasificacionID.Text = "";

        }
    }


    private void cmdRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clasificaciones());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}