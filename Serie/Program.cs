﻿using System;
using Serie.Classes;

namespace Serie.Classes
{
    class Program
    {
         
		
	     static SerieRepositorio repositorio = new SerieRepositorio();

		 static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)

        { 
			
		

			string filmeOuSerie = opcaoInicial();

            switch (filmeOuSerie)
				{
				case "1":
									
                     string opcaoSerie = opcaoUsuarioSerie();

		                 while (opcaoSerie.ToUpper() != "X")
		                   {
				             switch (opcaoSerie)
				               {
					             case "1":
						             ListarSeries();
						         break;

					             case "2":
					 	             InserirSerie();
						         break;

					             case "3":
						             AtualizarSerie();
						         break;

					             case "4":
						             ExcluirSerie();
						         break;

					             case "5":
						             VisualizarSerie();
						         break;

								 case "6":
						             opcaoInicial();
									 
						         break;

					             case "C":
						             Console.Clear();
						         break;

					             default:
						             throw new ArgumentOutOfRangeException();
				                 }

				             opcaoSerie = opcaoUsuarioSerie();
				
			                 }

                 break;
             

			     case "2":
             
                 string opcaoFilme = opcaoUsuarioFilme();

		                 while (opcaoFilme.ToUpper() != "X")
		                   {

				             switch (opcaoFilme)
				               {
					             case "1":
						             ListarFilme();
						         break;

					             case "2":
					 	             InserirFilme();
						         break;

					             case "3":
						             AtualizarFilme();
						         break;

					             case "4":
						             ExcluirFilme();
						         break;

					             case "5":
						             VisualizarFilme();
						         break;

								 case "6":
						             opcaoInicial();
						         break;

					             case "C":
						             Console.Clear();
						           break;

					             default:
						             throw new ArgumentOutOfRangeException();
				                 }


				                opcaoFilme = opcaoUsuarioFilme();

						     }


			      break;

			     }

        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

		 private static void ExcluirFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioFilme.Exclui(indiceFilme);
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioFilme.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do Filme ");
			int indiceFilme = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
		}
        private static void ListarFilme()
		{
			Console.WriteLine("Listar Filme");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Filme cadastrada.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo Filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Insere(novoFilme);
		}

		private static string opcaoInicial(){

			Console.WriteLine("Gostaria de navegar por Séries ou Filmes? ");
			Console.WriteLine("Insira a opção desejada: ");
			Console.WriteLine("1 - Séries ");
			Console.WriteLine("2 - Filmes ");

			string filmeOuSerie = Console.ReadLine().ToUpper();
			Console.WriteLine();

			return filmeOuSerie;
		}

        private static string opcaoUsuarioSerie()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("6- Voltar para tela inicial");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoSerie = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoSerie;
		}
		private static string opcaoUsuarioFilme()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Filmes");
			Console.WriteLine("2- Inserir nova Filme");
			Console.WriteLine("3- Atualizar Filme");
			Console.WriteLine("4- Excluir Filme");
			Console.WriteLine("5- Visualizar Filme");
			Console.WriteLine("6- Voltar para tela inicial");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoFilme = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoFilme;
		}
    }
}

