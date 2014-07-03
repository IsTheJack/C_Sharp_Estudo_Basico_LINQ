C_Sharp_Estudo_Basico_LINQ
==========================

Estudo básico de LINQ to SQL usando uma aplicação console em C# no Visual Studio Express 2013.


Sobre a Pesquisa:
=================

Pesquisa sobre LINQ to SQL feita com base no livro;
'C# 5.0 com Visual Studio 2012 Curso Completo' do autor;
'Henrique Loureiro'.
Cap: 8 (LINQ)
Foi escolhido o modo de aplicação console, de modo a estudar
o LINQ to SQL da maneira menos burocrática possível.

De acordo com a documentação da microsoft:
  LINQ (Language INtegrated Query) é um conjunto de recursos introduzidos no Visual Studio 2008 
  que amplia os poderosos recursos de consulta para a sintaxe da linguagem C# e Visual Basic. 
  LINQ proporciona padrões intuitivos para o desenvolvimento queries para consulta e atualização 
  de dados além de poder ser extendida para dar suporte a qualquer tipo de banco de dados. 
  O Visual Studio inclui assemblies provedores de LINQ que permitem o uso do LINQ com coleções 
  do .NET Framework, bancos de dados do SQL Server, conjuntos de dados ADO.NET e documentos XML.
  
Ou seja, LINQ é uma forma de consultar, manusear e atualizar uma base de dados. :)


Sumário do Arquivo '_Funcionario.cs':
======================================

Classe feita com ênfase na didática, não com regras de negócio relacionadas a funcionários.
Essa classe foi dividida em 12 métodos, com o intuito de explorar algumas das funcionalidades
do LINQ. Os métodos são:

1 - ListarTabela();

2 - OrdenarTabela();

3 - ContarRegistros();

4 - PesquisaPorDepartamento(string departamento);

5 - PesquisaInicio(string stringDePesquisa);

6 - PesquisaQualquer(string stringDePesquisa);

7 - AgruparQuantidade();

8 - AgruparQuantidade(int quantidade);

9 - JuntarDadosTabelas();

10 - InserirFuncionario(string nome, string departamento);

11 - AlterarDadosFuncionario(int id);

12 - ExcluirDadosFuncionario(int id);


Com os respectivos objetivos:

1 - Obtenção de toda a informação presente em uma tabela.

2 - Ordenação de uma listagem.

3 - Contagem da quantidade de registros existentes em uma tabela.

4 - Pesquisa: Aplicação de critérios usando a palavra-chave 'where'.

5 - Pesquisa: Pesquisando a partir do início de uma string usando o método 'StartsWith()'.

6 - Pesquisa: Pesquisando a partir de qualquer parte de uma string usando o méodo 'Contains()'.

7 - Agrupamento de informação: No exemplo agrupa-se informações da tabela funcionário de modo a
    apresentar o número total de funcionários por departamento, usando as palavras-chave 'group' e 'by'.
    
8 - Agrupamento de informação: Overload do método 7, porém utiliza critérios de pesquisa usando 'where'.

9 - Junção de Tabelas: Relacionando duas tabelas diferentes usando a palavra-chave 'join'.

10 - Manipulação de dados: Inserção de registros em uma tabela.

11 - Manipulação de dados: Alteração de registros em uma tabela.

11 - Manipulação de dados: Eliminação de registros em uma tabela.


Sobre:
======

Pesquisa feita por Roberto Oliveira (robertooliveiraestudo@gmail.com).
Dicas sobre melhoria de didática, boas práticas e documentação do código serão 
extremamente bem vindas.

O material aqui apresentado pode ser alterado / publicado sem pedido de permissão.
Créditos ao trabalho não é obrigatório, porém é visto como uma grande cortesia.

