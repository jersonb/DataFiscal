namespace DataFiscal.Models
{
    public class NomenclaturaComum : Entidade
    {
        public NomenclaturaComum()
        {
        }

        public NomenclaturaComum(string codigo)
        {
            Codigo = codigo;
            Descricao = "";
        }
    }
}
