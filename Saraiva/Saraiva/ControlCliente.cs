using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Saraiva
{
    class ControlCliente
    {
        ADM adm;
        DAO dao;

        public int opcao;
        public int ano;
        public int anoNascimento;
        public int diferenca;

        public ControlCliente()
        {
            adm = new ADM();
            dao = new DAO();
        }


        public void MenuSaraiva()
        {
            Console.WriteLine("\n-------Saraiva-------" +
                "\nEscolha uma das opções:" +
                "\n1. Cadastro Cliente" +
                "\n2. Login Cliente" +
                "\n3. Login ADM" +
                "\n0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());

        }


        public void Operacao()
        {

            do
            {
                MenuSaraiva();


                switch (opcao)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Obrigado !!!");
                        break;

                    case 1:
                        Console.WriteLine("Login: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Senha: ");
                        string senha = Console.ReadLine();
                        Console.WriteLine("Nome Completo: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("CPF: ");
                        string cpf = Console.ReadLine();
                        Console.WriteLine("Endereço: ");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("Data de Nascimento");
                        DateTime dataDeNascimento = Convert.ToDateTime(Console.ReadLine());
                        DateTime hoje = DateTime.Now;
                        ano = Convert.ToInt32(hoje.Year);
                        anoNascimento = Convert.ToInt32(dataDeNascimento.Year);
                        diferenca = ano - 18;
                        if (anoNascimento >= diferenca)
                        {
                            Console.WriteLine("CADASTRO APENAS PARA MAIOR DE 18 ANOS");
                            break;
                        }
                        Console.WriteLine("Telefone: ");
                        string telefone = Console.ReadLine();

                        dao.Inserir(nome, telefone, endereco, cpf, dataDeNascimento, login, senha);

                        Console.WriteLine("Cadastrado com Sucesso");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Login: ");
                        login = Console.ReadLine();
                        Console.WriteLine("Senha: ");
                        senha = Console.ReadLine();

                        dao.AcessarConta(login, senha);
                        break;

                    case 3:
                        Console.WriteLine("Login ADM: ");
                        login = Console.ReadLine();
                        Console.WriteLine("Senha ADM: ");
                        senha = Console.ReadLine();

                        adm.AcessarConta(login, senha);
                        break;
                }

            } while (opcao != 0);

        }

    }
}
