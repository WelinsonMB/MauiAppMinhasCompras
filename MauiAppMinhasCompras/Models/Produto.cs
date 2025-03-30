using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {

        string _descricao;
 

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

                _descricao = value;
            }
        }

        private double _quantidade;

        public double Quantidade
        {
            get => _quantidade;
            set
            {
                if (value == 0) 
                    {
                    throw new Exception("Por favor, preencha uma quantidade valída");
                }

                _quantidade = value; 
            }
        }

        private double _preco;
        public double Preco 
        { 
            get => _preco;
            set 
            {
                if (value == 0) 
                {
                    throw new Exception("Por favor, preencha um valor válido");
                }

                _preco = value; 
            } 
        }
        public double Total { get => Quantidade * Preco; }

    }
}
