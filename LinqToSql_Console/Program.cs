using System;

// Pesquisa sobre LINQ to SQL feita com base no livro;
//  'C# 5.0 com Visual Studio 2012 Curso Completo' do autor;
//  'Henrique Loureiro'.
//   Cap: 8 (LINQ)
// Foi escolhido o modo de aplicação console, de modo a estudar
// o LINQ to SQL da maneira menos burocrática possível.

namespace LinqToSql_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            _Funcionario func = new _Funcionario();
            func.ListarTabela();
            func.AlterarDadosFuncionario(16);
            func.ExcluirDadosFuncionario(16);
            Console.ReadLine();
        }
    }
}
