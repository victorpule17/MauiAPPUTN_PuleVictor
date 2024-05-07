namespace MauiAPPUTN;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void cmdClasificaiones_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clasificaciones());
    }

    private void cmdProductos_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Productos());
    }

    private void cmdCerrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}