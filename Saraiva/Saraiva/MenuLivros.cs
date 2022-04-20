using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saraiva
{
    class MenuLivros
    {
         
        MetododePagamento metododePagamento;
        DAO dao;

        public int opcao;

        public MenuLivros()
        {
            metododePagamento = new MetododePagamento();
            dao = new DAO();
        }

        public void ListadeLivros()
        {
            Console.WriteLine("\n-----Livros Saraiva-----" +
                "\n1. Escolher Livro" +
                "\n2. Finalizar Compra" +
                "\n0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        }

        public void Operacao()
        {
            Console.Clear();
            do
            {             
                ListadeLivros();
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Voltando ao login...");
                        break;
                    case 1:
                        Console.WriteLine(dao.PreencherLivros());

                        Console.WriteLine("\nInforme o codigo do livro deseja");
                        int cod = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\n\nLivro escolhido com Sucesso" +
                                          "\nLivro: " + dao.BuscarLivro(cod));
                        break;
                    case 2:
                        metododePagamento.PagamentoCartão();

                        break;                   
                }
            } while (opcao != 0);
        }

    }
}
