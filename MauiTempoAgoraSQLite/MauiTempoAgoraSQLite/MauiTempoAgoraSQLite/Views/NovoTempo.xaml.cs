using MauiTempoAgoraSQLite.Models;

using SQLite;
namespace MauiTempoAgoraSQLite.Views;

public partial class NovoTempo : ContentPage
{
	public NovoTempo()
	{
		InitializeComponent();
	}
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Tempo t = new Tempo()

            {
               lon = txt_LON.Text,
                lat =  txt_LAT.Text,
                speed = txt_VENTANIA.Text,
                temp_max = txt_TEMMAX.Text,
                temp_min = txt_TEMMIN.Text,
                sunrise = txt_AMANHECER.Text,
                sunset = txt_PORDOSOL.Text,
                description= txt_DESCRICAO.Text,
                main = txt_MAIN.Text,
                visibility = txt_VISIBILIDADE.Text,

            };



            await App.Db.Insert(t);
            await DisplayAlert("Sucesso!", "Registro inserido", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}