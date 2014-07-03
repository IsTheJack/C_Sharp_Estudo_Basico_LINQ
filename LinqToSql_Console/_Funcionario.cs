using System;
using System.Linq;

namespace LinqToSql_Console
{
    class _Funcionario
    {
        DepartamentosFuncionariosDataContext dc;
        
        // Lista todos os campos da tabela Funcionarios
        public void ListarTabela()
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios select Funcionarios;
                foreach (var func in lista)
                {
                    Console.WriteLine("ID: {0}.", func.Id);
                    Console.WriteLine("Nome: {0}.", func.Nome);
                    Console.WriteLine("Departamento: {0}.", func.Departamento);
                    Console.WriteLine();
                }
            }
        }

        // Lista ordenando por nome, usando 'orderby'
        public void OrdenarTabela()
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            orderby Funcionarios.Nome select Funcionarios;
                foreach (var func in lista)
                {
                    Console.WriteLine("ID: {0}.", func.Id);
                    Console.WriteLine("Nome: {0}.", func.Nome);
                    Console.WriteLine("Departamento: {0}.", func.Departamento);
                    Console.WriteLine();
                }
            }
        }

        // Escreve na tela a quantidade de registros na tabela
        public void ContarRegistros()
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios select Funcionarios;
                Console.WriteLine("Total de registros igual à {0}.", lista.Count());
                Console.WriteLine();
            }
        }

        // Pesquisa: Retorna os campos com base na string passada como parâmetro (podem ser DF, DC e DRH)
        public void PesquisaPorDepartamento(string departamento)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            where Funcionarios.Departamento == departamento
                            select Funcionarios;

                foreach (var func in lista)
                {
                    Console.WriteLine("ID: {0}.", func.Id);
                    Console.WriteLine("Nome: {0}.", func.Nome);
                    Console.WriteLine("Departamento: {0}.", func.Departamento);
                    Console.WriteLine();
                }
            }
        }

        // Pesquisa: Inicio de Cadeia (Tabelta.Campo.StartsWith(stringDePesquisa))
        public void PesquisaInicio(string stringDePesquisa)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            where Funcionarios.Nome.StartsWith(stringDePesquisa)
                            select Funcionarios;

                foreach (var func in lista)
                {
                    Console.WriteLine("ID: {0}.", func.Id);
                    Console.WriteLine("Nome: {0}.", func.Nome);
                    Console.WriteLine("Departamento: {0}.", func.Departamento);
                    Console.WriteLine();
                }
            }
        }

        // Pesquisa: Qualquer parte da Cadeia (Tabelta.Campo.Contains(stringDePesquisa))
        public void PesquisaQualquer(string stringDePesquisa)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            where Funcionarios.Nome.Contains(stringDePesquisa)
                            select Funcionarios;

                foreach (var func in lista)
                {
                    Console.WriteLine("ID: {0}.", func.Id);
                    Console.WriteLine("Nome: {0}.", func.Nome);
                    Console.WriteLine("Departamento: {0}.", func.Departamento);
                    Console.WriteLine();
                }
            }
        }

        // Agrupando informações usando 'group  'by
        // Neste exemplo, agrupou-se a informação contida na tabela 'Funcionarios'
        // de modo a ser possível apresentar o nº total de funcionários por
        // departamento. O agrupamento dos dados é feito usando a cláusula
        // 'group' 'by' à expressão de consulta e de uma nova seleção 'select' e 'new'
        // tendo como referência o campo identificador do departamento 'key' e a sua
        // respectiva contagem.
        public void AgruparQuantidade()
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            group Funcionarios by Funcionarios.Departamento into c
                            select new
                            {
                                Departamento = c.Key, Contagem = c.Count()
                            };

                foreach (var c in lista)
                {
                    Console.WriteLine("{0} ({1}).", c.Departamento, c.Contagem);
                }
            }
        }

        // Overload do método AgruparQuantidade()
        // Parâmetro de entrada para aplicação de critérios de consulta. (Usando where)
        public void AgruparQuantidade(int quantidade)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            group Funcionarios by Funcionarios.Departamento into c
                            where c.Count() >= quantidade
                            select new
                            {
                                Departamento = c.Key,
                                Contagem = c.Count()
                            };

                foreach (var c in lista)
                {
                    Console.WriteLine("{0} ({1}).", c.Departamento, c.Contagem);
                }
            }
        }

        // Junção de dados de Tabelas
        // Para relacionar duas tabelas no LINQ, é usado a palavra chave 'join'
        // que estabelece a ligação entre elas usando a palavra chave 'on'.
        public void JuntarDadosTabelas()
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                var lista = from Funcionarios in dc.Funcionarios
                            join Departamentos in dc.Departamentos
                            on Funcionarios.Departamento equals Departamentos.Sigla
                            select new
                            {
                                Funcionarios.Id, Funcionarios.Nome, Departamentos.Departamento1
                            };

                foreach (var c in lista)
                {
                    Console.WriteLine("ID: {0}.", c.Id);
                    Console.WriteLine("Nome: {0}.", c.Nome);
                    Console.WriteLine("Departamento: {0}.", c.Departamento1);
                    Console.WriteLine();
                }
            }
        }

        // Manipulação de dados: Inserção de dados
        // Para adicionar registros à tabela, basta invocar o método 'InsertSubmit'
        // e confirmar a operação usando o método 'SubmitChanges'.
        public void InserirFuncionario(string nome, string departamento)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                Funcionarios fun = new Funcionarios();
                fun.Nome = nome;
                fun.Departamento = departamento;
                dc.Funcionarios.InsertOnSubmit(fun);
                dc.SubmitChanges();
                
                //Obtenção de listagem
                ListarTabela();
            }
        }

        // Manipulação de dados: Alteração de Registros 
        // Para garantir que tenha capturado um registro único usa-se
        // objeto = pesquisa.Single();
        public void AlterarDadosFuncionario(int id)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                Funcionarios fun = new Funcionarios();
                var pesquisa = from Funcionarios in dc.Funcionarios
                               where Funcionarios.Id == id
                               select Funcionarios;
                fun = pesquisa.Single();

                Console.WriteLine("Funcionario: {0}. Departamento: {1}", fun.Nome, fun.Departamento);
                Console.WriteLine("Escreva o novo nome:");
                fun.Nome = Console.ReadLine();
                Console.WriteLine("Escreva o novo Departamento:");
                fun.Departamento = Console.ReadLine();

                dc.SubmitChanges();
                ListarTabela();
            }
        }

        // Manipulação de dados: Eliminação de registros
        public void ExcluirDadosFuncionario(int id)
        {
            using (dc = new DepartamentosFuncionariosDataContext())
            {
                Funcionarios fun = new Funcionarios();
                var pesquisa = from Funcionarios in dc.Funcionarios
                               where Funcionarios.Id == id
                               select Funcionarios;
                fun = pesquisa.Single();

                dc.Funcionarios.DeleteOnSubmit(fun);
                dc.SubmitChanges();

                //Listar Tabela
                ListarTabela();
            }
        }
    }
}
