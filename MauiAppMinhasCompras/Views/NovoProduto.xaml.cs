using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    public async void ToolbarItem_Clicked(object sender, EventArgs e)


    {
        try
		{
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro inserido", "OK");
			await Navigation.PopAsync();


		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}