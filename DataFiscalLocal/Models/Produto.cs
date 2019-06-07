namespace DataFiscal.Models
{
    public class Produto : Entidade
    {
        public Produto()
        {
        }
        public Produto(string codigo)
        {
            Codigo = codigo;
            Descricao = "";
        }
    }
}
