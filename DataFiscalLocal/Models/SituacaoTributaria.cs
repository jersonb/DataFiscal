namespace DataFiscal.Models
{
    public class SituacaoTributaria : Entidade
    {
        public SituacaoTributaria()
        {
        }
        public SituacaoTributaria(string codigo)
        {
            Codigo = codigo;
            Descricao = "";
           
        }
    }
}
