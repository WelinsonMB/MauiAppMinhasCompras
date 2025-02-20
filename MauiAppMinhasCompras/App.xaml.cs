namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            //MainPage = newAppShell()/
            MainPage = new NavigationPage(new Views.ListaProduto());
        }

    }
}