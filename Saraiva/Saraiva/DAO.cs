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

        
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Vetores

        public int[] cpf;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public DateTime[] dataDeNascimento;
        public string[] login;
        public string[] senha;
        public int[] codigo;
        public string[] titulo;
        public DateTime[] ano;
        public string[] editora;
        public double[] valor;
        public int[] quantidadeEstoque;
        public int[] numeroDoCartao;
        public DateTime[] dataDeVenc;
        public int[] cvv;
        public int i;
        public string msg;
        public int contador = 0;

        public DAO()
        {
            

            conexao = new MySqlConnection("server=localhost;DataBase=Saraiva;Uid=root;Password=;Convert Zero DateTime=True;");
            try
            {
                conexao.Open();              
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
                dados = "('" + cpf + "','" + nome + "','" + telefone + "','" + endereco + "', '" + dataDeNascimento.ToString("yyyy-MM-dd")+ "', '" + login + "', '" + senha + "')";
                resultado = "Insert into Cadastro(cpf, nome, telefone, endereco,dataDeNascimento,login,senha) values" + dados;
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Cadastro feito com Sucesso !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo Deu Errado!\n\n" + e);
            }
        }

        public bool AcessarConta(string nomeTabela, string log, string sen)
        {
            PreencherVetor(nomeTabela);
            for (int i = 0; i < contador; i++)
            {
                if ((log == login[i]) && (sen == senha[i]))
                {                    
                    return true;                    
                }
               
            }        
            return false;
        }     

        public void InserirADM(string login, string senha)
        {
            try
            {
                dados = $"('','{login}','{senha}')";
                resultado = "Insert into ADM(codigo,login,senha) values" + dados;
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Cadastro feito com Sucesso !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo Deu Errado!\n\n" + e);
            }
        }       


        public void PreencherVetor(string nomeTabela)
        {
            string query = "select * from " + nomeTabela;

            
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();
            if (nomeTabela == "cadastro")
            {
                login = new string[100];
                senha = new string[100];
                cpf = new int[100];
                nome = new string[100];
                telefone = new string[100];
                endereco = new string[100];
                dataDeNascimento = new DateTime[100];

                for (i = 0; i < 100; i++)
                {
                    cpf[i] = 0;
                    nome[i] = "";
                    telefone[i] = "";
                    endereco[i] = "";
                    dataDeNascimento[i] = new DateTime();                  
                }

                i = 0;
                while (leitura.Read())
                {
                    cpf[i] = (int)Convert.ToInt64(leitura["cpf"]);
                    nome[i] = leitura["nome"] + "";
                    telefone[i] = leitura["telefone"] + "";
                    endereco[i] = leitura["endereco"] + "";
                    dataDeNascimento[i] = DateTime.Parse(leitura["dataDeNascimento"] + "");
                    login[i] = leitura["login"] + "";
                    senha[i] = leitura["senha"] + "";
                    i++;
                    contador++;
                }
                


                leitura.Close();
            }
            else
            {
                
                if(nomeTabela == "ADM" || nomeTabela == "DONO")
                {
                    codigo = new int[100];
                    login = new string[100];
                    senha = new string[100];

                    codigo[i] = 0;
                    login[i] = "";
                    senha[i] = "";

                    i = 0;
                    while (leitura.Read())
                    {
                        codigo[i] = (int)Convert.ToInt64(leitura["codigo"]);
                        login[i] = leitura["login"] + "";
                        senha[i] = leitura["senha"] + "";
                        i++;
                        contador++;
                    }

                    leitura.Close();
                }
                
            }
           
        }



        public void PreencherVetorCartao()
        {
            string query = "select * from cartao";

            cpf = new int[100];
            numeroDoCartao = new int[100];
            dataDeVenc = new DateTime[100];
            cvv = new int[100];          

            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                numeroDoCartao[i] = 0;
                dataDeVenc[i] = new DateTime();
                cvv[i] = 0;
                
            }

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cpf[i] = (int)Convert.ToInt64(leitura["cpf"]);
                numeroDoCartao[i] = (int)Convert.ToInt64(leitura["numeroDoCartao"]);
                dataDeVenc[i] = DateTime.Parse(leitura["dataDeVenc"] + "");
                cvv[i] = (int)Convert.ToInt64(leitura["cvv"]);
                i++;
                contador++;
            }

            leitura.Close();
        }

        public void CartoesdeCreditos(int cpf, int numeroDoCartao, DateTime dataDeVenc, int cvv)
        {
            try
            {
                dados = "('','" + cpf + "','" + numeroDoCartao + "','" + dataDeVenc.ToString("yyyy-MM-dd")+ "','" + cvv + "')";
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
            ano = new DateTime[100];          

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                titulo[i] = "";
                editora[i] = "";
                valor[i] = 0;
                quantidadeEstoque[i] = 0;
                ano[i] = new DateTime();               
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
                ano[i] = DateTime.Parse(leitura["ano"] + "");               
                i++;
                contador++;
            }
            leitura.Close();
        }
 

        public void InserirLivros( string titulo, DateTime ano, string editora, double valor, int quantidadeEstoque)
        {
            try
            {
                dados = "('','" + titulo + "','" + ano.ToString("yyyy-MM-dd") + "','" + editora + "','" + valor+ "','"+ quantidadeEstoque+"')";
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
                    + ", Ano: " + ano[i].ToString("yyyy")
                    + ", Editora: " + editora[i]
                    + ", Valor: " + valor[i]
                    + ",Quantidade em Estoque: "+ quantidadeEstoque[i];
            }
            return msg;
        }
        
      
        public void AtualizarLivrosData(DateTime Data, string campo, int codigo)
        {
            try
            {
                resultado = " update livros set " + campo + " = '" + Data.ToString("yyyy-MM-dd") + "' where codigo = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado atualizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
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
            PreencherVetor("Livros");
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return titulo[i];
                }
            }//fim do for
            return "Codigo não encontrado !!!";
        }//fim do consult titulo

        //public double BuscarValor(int cod)
        //{
           // PreencherVetor();
          //  for (int i = 0; i < contador; i++)
           // {
              //  if (cod == codigo[i])
            //    {
             //       return valor[i];
            //    }
           // }//fim do for
           // return -1;
       // }//fim do consult titulo

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
