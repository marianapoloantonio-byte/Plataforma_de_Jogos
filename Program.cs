using System;
using System.Collections.Generic;

class Usuario
{
    public int Id;
    public string Nome;
    public string Email;
    public string Senha;
    public Biblioteca Biblioteca;

// -------- Construtor --------
    public Usuario(int id, string nome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;

        Biblioteca = new Biblioteca();
    }

// !!!!!!!!!!!!!! FAZ ESSE Metodo para exibir os dados do usuario (nao exibe a senha)
    public void ExibirDados()
    {
        Console.WriteLine($"Seu ID: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Email: {Email}");
    }
}

class Jogo
{
    public int Id;
    public string Nome;
    public double Preco;
    public Categoria Categoria;

// -------- Construtor --------
    public Jogo(int id, string nome, double preco, Categoria categoria)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }
// !!!!!!!!!!!!!!!!!!! FAZ ESSE (Metodo para exibir informaçoes do jogo)
    public void ExibirInformacoes()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Preço: {Preco}");
        Console.WriteLine($"Categoria: {Categoria.Nome}");

    }
}

class Categoria
{
    public int Id;
    public string Nome;

// -------- Construtor --------
    public Categoria(int id, string nome){
        Id = id;
        Nome = nome;
    }

}

class Biblioteca
{
    public List<Jogo> Jogos = new List<Jogo>();

    // !!!!!!!!!!!!!!!!!!!!!!!! FAZ ESSE (adiciona um jogo na biblioteca) !!!!!!!!!!!!!!!!!
    public void AdicionarJogo(Jogo jogo)
    {
         Jogos.Add(jogo);
    }

    // !!!!!!!!!!!!!!!!!!!!! FAZ ESSE TBM (coloca um foreach para listar os jogos) !!!!!!!!
    public void ListarJogos()
    {
            foreach(Jogo jogo in Jogos)
        {
            jogo.ExibirInformacoes();
        }
    }
}

class Compra
{
    public int Id;
    public Usuario Usuario;
    public Jogo Jogo;
    public double ValorPago;

// -------- Construtor --------
    public Compra(int id, Usuario usuario, Jogo jogo)
    {
        Id = id;
        Usuario = usuario;
        Jogo = jogo;
    }

// Metodo para finalizar a compra e adicionar o jogo na biblioteca do usuario
    public void FinalizarCompra()
    {
        ValorPago = Jogo.Preco;

        Usuario.Biblioteca.AdicionarJogo(Jogo);
        Console.WriteLine("Compra realizada com sucesso!");
    }
}

// ===================== MAIN ========================
class Program
{
    static void Main(string[] args)
    {

        // --- Listas
        List<Usuario> usuarios = new List<Usuario>();
        List<Jogo> jogos = new List<Jogo>();
        List<Categoria> categorias = new List<Categoria>();
        List<Compra> compras = new List<Compra>();

        Console.WriteLine("=================================");
        Console.WriteLine("|      PLATAFORMA DE JOGOS      |");
        Console.WriteLine("=================================");

        int EscMenu;
        int proximoIdUsuario = 1;

        // ------------ LOOP PARA O MENU ------------
        do{
            
            // ----- Exibe o Menu
            Console.WriteLine("----------- MENU -----------");
            Console.WriteLine("| 1. Cadastrar Usuario    |");
            Console.WriteLine("| 2. Cadastrar Jogo       |");
            Console.WriteLine("| 3. Listar Jogos         |");
            Console.WriteLine("| 4. Comprar Jogo         |");
            Console.WriteLine("| 5. Ver minha biblioteca |");
            Console.WriteLine("| 6. Remover jogo         |");
            Console.WriteLine("| 0. Sair                 |");

            Console.Write("Escolha: ");
            EscMenu = int.Parse(Console.ReadLine());


            // Verifica qual foi a escolha do usuario e executa
            switch(EscMenu)
            {
                case 1:
                    Console.Write("Digite um nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite um e-mail: ");
                    string email = Console.ReadLine();

                    Console.Write("Digite uma senha: ");
                    string senha = Console.ReadLine();  

                    // --- Cria um objeto usuario
                    Usuario usuario = new Usuario(proximoIdUsuario, nome, email, senha);
                    // --- Adiciona usuario na lista 
                    usuarios.Add(usuario);

                    Console.WriteLine("Usuario cadastrado com sucesso!");

                    proximoIdUsuario++;
                    break;

                case 2:
                    
                    break;

                case 3:
                    
                    break;

                case 4:
                    
                    break;

                case 5:
                    
                    break;

                case 6:
                    
                    break;

                case 0:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("[ERRO] Escolha um número válido!");
                    break;
            }

        }while (EscMenu != 0);

    }
}
