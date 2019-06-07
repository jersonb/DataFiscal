namespace DataFiscal.Models
{
    public class OrigemImposto : Entidade
    {
        public OrigemImposto()
        {
        }

        public OrigemImposto(string codigo) 
        {
            Codigo = codigo;
            Descricao = "";
        }
    }
}
