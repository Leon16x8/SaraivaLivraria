using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saraiva
{
    class MenuADM
    {
        public int opcao;
        DAO dao;

        public MenuADM()
        {
            opcao = 0;
            dao = new DAO();
        }
        public void ListaADM()
        {
            Console.WriteLine("\n-----ADM Saraiva-----" +
                "\n0.Sair" +
                "\n1.Adicionar livros" +
                "\n2.Consultar estoque" +
                "\n3.Buscar livros" +
                "\n4.Atualizar dado de livro" +
                "\n5.Excluir livro");

            opcao = Convert.ToInt32(Console.ReadLine());
        }

        public void OperacaoADM()
        {
            Console.Clear();
            do
            {
                ListaADM();

                switch (opcao)
                {
                    case 0:

                        Console.WriteLine("Voltando ao menu principal...");
                        break;
                        
                    case 1:

                        Console.WriteLine("Informe o titulo do livro: ");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Informe o ano do livro:");
                        string ano = Console.ReadLine();
                        Console.WriteLine("Informe a editora do livro: ");
                        string editora = Console.ReadLine();
                        Console.WriteLine("Informe o valor do livro: ");
                        double valor = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Informe a quantidade de mesmo em estoque: ");
                        int quantidadeEstoque = (int)Convert.ToInt64(Console.ReadLine());

                        dao.InserirLivros(titulo, ano, editora, valor, quantidadeEstoque);
                        break;

                    case 2:
                        Console.WriteLine(dao.ConsultarTodosOsLivros());
                        break;

                    case 3:
                        Console.WriteLine(dao.PreencherLivros());

                        Console.WriteLine("\nInforme o codigo do livro deseja");
                        int cod = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\n\nLivro escolhido com Sucesso" +
                                          "\nLivro: " + dao.BuscarLivro(cod));                                                     
                        break;

                    case 4:
                        Console.WriteLine("Informe o campo a ser atualizado: ");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Informe o novo dado: ");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Informe o codigo do produto a ser atualizado: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        dao.AtualizarLivros(campo, novoDado, codigo);
                        break;

                    case 5:
                        Console.WriteLine("Informe o código do livro que deseja excluir: ");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        dao.DeletarLivros(codigo);
                        break;

                }
            } while (opcao != 0);
        }
    }
}

