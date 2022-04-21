using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saraiva
{
    class MetododePagamento
    {
        DAO dao;
       
        private int cartão;
        private string dataDeVenc;
        private int cvv;
        private string nomeDoTitular;


        public MetododePagamento()
        {
            this.Cartão = 0;
            this.DataDeVenc = "";
            this.Cvv = 0;
            this.NomeDoTitular = "";
            dao = new DAO();
        }
       

        public int Cartão { get => cartão; set => cartão = value; }
        public string DataDeVenc { get => dataDeVenc; set => dataDeVenc = value; }
        public int Cvv { get => cvv; set => cvv = value; }
        public string NomeDoTitular { get => nomeDoTitular; set => nomeDoTitular = value; }


        public void Pagamentoo(int cartão, string dataDeVenc, int cvv, string nomeDoTitular)
        {
            Cartão = cartão;
            DataDeVenc = dataDeVenc;
            Cvv = cvv;
            NomeDoTitular = nomeDoTitular;
        }

        public void PagamentoCartão()
        {
            Console.WriteLine("Digite seu CPF");
            int cpf = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Nome Do Titular");
            Console.ReadLine();
            Console.WriteLine("Digite o numero do Cartão:");
            int numeroDoCartao = Convert.ToInt32(Console.ReadLine());     
            Console.WriteLine("Digite o CVV:");
            DateTime dataDeVenc = Convert.ToDateTime(Console.ReadLine());           
            Console.WriteLine("Digite a Data de Vencimento");
            int cvv = Convert.ToInt32(Console.ReadLine());
            dao.CartoesdeCreditos(cpf, numeroDoCartao, dataDeVenc, cvv);

            Console.WriteLine("Compra Efetuada com Sucesso");
        }    
    }
}
