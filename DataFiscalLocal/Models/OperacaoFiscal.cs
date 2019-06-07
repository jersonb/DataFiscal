namespace DataFiscal.Models
{
    public class OperacaoFiscal : Entidade
    {
        public OperacaoFiscal()
        {
        }
        public OperacaoFiscal(string codigo)
        {
            Codigo = codigo;
            Descricao = "";
        }
    }
}
