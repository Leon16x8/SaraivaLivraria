using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Saraiva
{
    class ControlCliente
    {
        MenuADM adm;
        DAO dao;
        MenuLivros menuLivros;

        public int opcao;
        public int ano;
        public int anoNascimento;
        public int diferenca;

        public ControlCliente()
        {
            menuLivros = new MenuLivros();  
            adm = new MenuADM();
            dao = new DAO();
        }


        public void MenuSaraiva()
        {
            Console.WriteLine("\n-------Saraiva-------" +
                "\nEscolha uma das opções:" +
                "\n1. Cadastro Cliente" +      
                "\n2. Login Cliente" +
                "\n3. Login ADM" +
                "\n4. Acesso ao DONO" +
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

                        dao.PreencherVetor("cadastro");
                        do
                        {
                            Console.WriteLine("Login: ");
                            login = Console.ReadLine();
                            Console.WriteLine("Senha: ");
                            senha = Console.ReadLine();
                            if (dao.AcessarConta("cadastro", login, senha) == true)
                            {
                                menuLivros.Operacao();
                            }
                            Console.WriteLine("Login e senha incorretos, digite corretamente.");
                        } while (dao.AcessarConta("cadastro", login, senha) == false);
                        break;

                    case 3:
                        dao.PreencherVetor("ADM");
                        do
                        {
                            Console.WriteLine("LoginADM: ");
                            login = Console.ReadLine();
                            Console.WriteLine("SenhaADM: ");
                            senha = Console.ReadLine();
                            if (dao.AcessarConta("ADM", login, senha) == true)
                            {
                                adm.OperacaoADM();                               
                            }
                            Console.WriteLine("Login e senha incorretos, digite corretamente.");
                        } while (dao.AcessarConta("ADM", login, senha) == false);
                        break;

                    case 4:
                        dao.PreencherVetor("ADM");
                        do
                        {
                            Console.WriteLine("LoginADM: ");
                            login = Console.ReadLine();
                            Console.WriteLine("SenhaADM: ");
                            senha = Console.ReadLine();
                            if (dao.AcessarConta("ADM", login, senha) == true)
                            {
                                adm.OperacaoADM();
                            }
                            Console.WriteLine("Login e senha incorretos, digite corretamente.");
                        } while (dao.AcessarConta("ADM", login, senha) == false);
                        break;
                }



            } while (opcao != 0);

        }

    }
}
