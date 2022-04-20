using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão do Banco de Dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no Banco de Dados


namespace Saraiva
{
    class DAO
    {
        //Var

        MenuLivros menuLivros;
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Vetores

        public int[] cpf;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public string[] dataDeNascimento;
        public string[] login;
        public string[] senha;
        public int[] codigo;
        public string[] titulo;
        public string[] ano;
        public string[] editora;
        public double[] valor;
        public int[] quantidadeEstoque;
        public int[] numeroDoCartao;
        public string[] dataDeVenc;
        public int[] cvv;
        public int i;
        public string msg;
        public int contador = 0;

        public DAO()
        {
            //menuLivros = new MenuLivros();

            conexao = new MySqlConnection("server=localhost;DataBase=Saraiva;Uid=root;Password=;");
            try
            {
                conexao.Open();
                Console.WriteLine("Sistema Online");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
                conexao.Close();
            }
        }
        
        public void Inserir(string nome, string telefone, string endereco, string cpf, DateTime dataDeNascimento, string login, string senha)
        {
            try
            {
                dados = "('" + cpf + "','" + nome + "','" + telefone + "','" + endereco + "', '" + dataDeNascimento + "', '" + login + "', '" + senha + "')";
                resultado = "Insert into Cadastro(cpf, nome, telefone, endereco,dataDeNascimento,login,senha) values" + dados;
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linha(s) Afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo Deu Errado!\n\n" + e);
            }
        }

        public void AcessarConta(string log, string sen)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if ((log == login[i]) && (sen == senha[i]))
                {
                    Console.WriteLine("Bem vindo!");
                    menuLivros.Operacao();
                }
                else
                {
                    Console.WriteLine("Login e senha incorretos, digite corretamente.");
                }
            }
        }


        public void PreencherVetor()
        {
            string query = "select * from cadastro";

            cpf = new int[100];
            nome = new string[100];
            telefone = new string[100];
            endereco = new string[100];
            dataDeNascimento = new string[100];
            login = new string[100];
            senha = new string[100];

            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";
                dataDeNascimento[i] = "";
                login[i] = "";
                senha[i] = "";
            }

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cpf[i] = (int)Convert.ToInt64(leitura["cpf"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                dataDeNascimento[i] = leitura["dataDeNascimento"] + "";
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                i++;
                contador++;
            }

            leitura.Close();
        }

        public void PreencherVetorCartao()
        {
            string query = "select * from cartao";

            cpf = new int[100];
            numeroDoCartao = new int[100];
            dataDeVenc = new string[100];
            cvv = new int[100];          

            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                numeroDoCartao[i] = 0;
                dataDeVenc[i] = "";
                cvv[i] = 0;
                
            }

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cpf[i] = (int)Convert.ToInt64(leitura["cpf"]);
                numeroDoCartao[i] = (int)Convert.ToInt64(leitura["numeroDoCartao"]);
                dataDeVenc[i] = leitura["dataDeVenc"] + "";
                cvv[i] = (int)Convert.ToInt64(leitura["cvv"]);
                i++;
                contador++;
            }

            leitura.Close();
        }

        public void CartoesdeCreditos(int cpf, int numeroDoCartao, string dataDeVenc, int cvv)
        {
            try
            {
                dados = "('','" + cpf + "','" + numeroDoCartao + "','" + dataDeVenc + "','" + cvv + "')";
                resultado = "Insert into Cartao(cpf, numeroDoCartao, dataDeVenc, cvv) values" + dados;
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linha(s) Afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo Deu Errado!\n\n" + e);
            }
        }

        public void PreencherVetorLivros()
        {
            string query = "select * from Livros";

            codigo = new int[100];
            titulo = new string[100];
            editora = new string[100];
            valor = new double[100];
            quantidadeEstoque = new int[100];
            ano = new string[100];          

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                editora[i] = "";
                valor[i] = 0;
                quantidadeEstoque[i] = 0;
                ano[i] = "";               
            }

 
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codigo[i] = (int)Convert.ToInt64(leitura["codigo"]);
                titulo[i] = leitura["titulo"] + "";
                editora[i] = leitura["editora"] + "";
                valor[i] = Convert.ToDouble(leitura["valor"]);
                quantidadeEstoque[i] = (int) Convert.ToInt64 (leitura["quantidadeEstoque"]);
                ano[i] = leitura["ano"] + "";               
                i++;
                contador++;
            }
            leitura.Close();
        }
 

        public void InserirLivros( string titulo, string ano, string editora, double valor, int quantidadeEstoque)
        {
            try
            {
                dados = "('','" + titulo + "','" + ano + "','" + editora + "','" + valor+ "','"+ quantidadeEstoque+"')";
                resultado = "Insert into Livros(codigo, titulo, ano, editora, valor, quantidadeEstoque) values" + dados;
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linha(s) Afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo Deu Errado!\n\n" + e);
            }
        }

        public string ConsultarTodosOsLivros()
        {
            
            PreencherVetorLivros();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCódigo: " + codigo[i]
                    + ", Titulo: " + titulo[i]
                    + ", Ano: " + ano[i]
                    + ", Editora: " + editora[i]
                    + ", Valor: " + valor[i]
                    + ",Quantidade em Estoque: "+ quantidadeEstoque[i];
            }
            return msg;
        }
        
      

        public void AtualizarLivros(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = " update livros set " + campo + " = '" + novoDado + "' where codigo = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado atualizado com sucesso!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }

        public string BuscarLivro(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return titulo[i];
                }
            }//fim do for
            return "Codigo não encontrado !!!";
        }//fim do consult titulo

        public double BuscarValor(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return valor[i];
                }
            }//fim do for
            return -1;
        }//fim do consult titulo

        public string PreencherLivros()
        {
            PreencherVetorLivros();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCodigo:" + codigo[i]
                    + " | " + titulo[i]
                    + " | R$" + valor[i];
            }
            return msg;
        }
        public void DeletarLivros(int codigo)
        {
            resultado = "delete from livros where codigo = '" + codigo + "'";
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            Console.WriteLine("Livro excluido com sucesso!");
        }

    }
}
