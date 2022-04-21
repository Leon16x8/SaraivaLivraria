using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saraiva
{
    class ADM
    {
        MenuADM menuADM;
        DAO dao;

        public string login;
        public string senha;

        public ADM()
        {
            menuADM = new MenuADM();
            dao = new DAO();       

            this.Login = "ADM";
            this.Senha = "Saraiva@2022";
        }

        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }

        public void Cadastrar(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public void AcessarConta(string login, string senha)
        {
            
            if ((Login == login) && (Senha == senha))
            {
                Console.WriteLine("Logado com Sucesso");
                menuADM.OperacaoADM();
            }
            else
            {
                Console.WriteLine("Login e senha incorretos, digite corretamente.");
                
            }
        }
    }
}
