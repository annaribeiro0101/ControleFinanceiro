namespace ApiContasAPagar
{
    public class ContasAPagar
    {

        public Guid Id { get; init; }
        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public bool Pago { get; private set; }
        public string DataVencimento { get; set; }


        public ContasAPagar(string nome, double valor, bool pago, string dataVencimento )
        {
            Nome = nome;
            Id = Guid.NewGuid();
            Valor = valor;
            Pago = pago;
            DataVencimento = dataVencimento;
        }
    }
}
