using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

		lst_produtos.ItemsSource = lista; 
	}

    protected async override void OnAppearing()
    {
		List<Produto> tmp = await App.Db.GetAll();

		tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());

		}catch (Exception ex)
		{
			DisplayAlert("ops", ex.Message, "OK");
		}
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		string q = e.NewTextValue;

		lista.Clear(); 

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		double soma = lista.Sum(i => i.Total);

		string msg = $"O total é{soma:C}";

		DisplayAlert("Total de Produtos ", msg, "OK"); 
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {

        var menuItem = (MenuItem)sender;

        var produto = (Produto)menuItem.BindingContext;

        bool confirmacao = await DisplayAlert("Confirmar",
        $"Você tem certeza que deseja remover o produto '{produto.Descricao}'?",
        "Sim",
        "Não");

        if (confirmacao)
        {
            lista.Remove(produto);

            await App.Db.Delete(produto.Id);

            await DisplayAlert("Sucesso", "Produto removido com sucesso.", "OK");
        }

    }

 private async void SliderPreco_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double precoMax = e.NewValue; // Obtém o valor máximo do preço selecionado pelo usuário

        lista.Clear(); // Limpa a lista antes de exibir os resultados filtrados

        List<Produto> tmp = await App.Db.GetAll(); // Busca todos os produtos no banco de dados

        var filtrados = tmp.Where(p => p.Preco <= precoMax).ToList(); // Filtra os produtos pelo preço máximo

        filtrados.ForEach(i => lista.Add(i)); // Atualiza a lista com os produtos filtrados
    }
}