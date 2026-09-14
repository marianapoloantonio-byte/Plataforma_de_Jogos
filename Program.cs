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

// Metodo para exibir os dados do usuario (nao exibe a senha)
    public void ExibirDados()
    {
        Console.WriteLine($"Seu ID: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Email: {Email}");

    }
}

// ===============================================================================

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

// Metodo para exibir informaçoes do jogo
    public void ExibirInformacoes()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Preço: {Preco}");
        Console.WriteLine($"Categoria: {Categoria.Nome}");
    }

    // Metodo para listar todos os jogos
    public static void ListarJogos(List<Jogo> jogos)
    {
        foreach (Jogo jogo in jogos)
        {
            jogo.ExibirInformacoes();
            Console.WriteLine("---------------------");
        }
    }

    // Faz a busca do jogo pelo ID
    public static void BuscarJogo(List<Jogo> jogos, int id)
    {
        foreach (Jogo jogo in jogos)
        {
            if (jogo.Id == id)
            {
                jogo.ExibirInformacoes();
                return;
            }
        }

    Console.WriteLine("Jogo não encontrado.");
    }

}

// ===============================================================================

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

// ===============================================================================

class Biblioteca
{
    public List<Jogo> Jogos = new List<Jogo>();

    // adiciona um jogo na biblioteca
    public void AdicionarJogo(Jogo jogo)
    {
        Jogos.Add(jogo);
    }

    // coloca um foreach para listar os jogos
    public void ListarJogos()
    {
            foreach(Jogo jogo in Jogos)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"ID: {jogo.Id}");
            Console.WriteLine($"Nome: {jogo.Nome}");
            Console.WriteLine($"Categoria: {jogo.Categoria.Nome}");
            Console.WriteLine("---------------------");
        }
    }
}

// ===============================================================================

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
        
        // Verifica se o usuario ainda nao tem o jogo
        foreach (Jogo jogo in Usuario.Biblioteca.Jogos)
        {
            if (jogo.Id == Jogo.Id)
            {
                Console.WriteLine("Você já possui esse jogo na sua biblioteca!");
                return;
            }
        }

        // Verifica se o jogo tem direito ao desconto
        if (Jogo.Preco > 100)
        {
            ValorPago = Jogo.Preco * 0.90;
            Console.WriteLine("Você recebeu 10% de desconto!");
        }else{
            ValorPago = Jogo.Preco;
        }

        Usuario.Biblioteca.AdicionarJogo(Jogo);

        Console.WriteLine("Compra realizada com sucesso!");
        Console.WriteLine($"Jogo {Jogo.Nome} ja disponivel na biblioteca.");
        Console.WriteLine($"Valor pago: R$ {ValorPago}");
        
    }
}

// ============================= MAIN ================================
class Program
{
    static void Main(string[] args)
    {

        // --- Listas
        List<Usuario> usuarios = new List<Usuario>();
        List<Jogo> jogos = new List<Jogo>();
        List<Compra> compras = new List<Compra>();
        Usuario usuarioLogado = null;

        // Categorias já estao pré-definidas
        List<Categoria> categorias = new List<Categoria>();
        categorias.Add(new Categoria(1, "RPG"));
        categorias.Add(new Categoria(2, "Aventura"));
        categorias.Add(new Categoria(3, "Terror"));

        // Cria os objetos dos jogos
        Jogo jogo1 = new Jogo(1, "Resident Evil 2", 169, categorias[2]);
        Jogo jogo2 = new Jogo(2, "The Last of Us", 199, categorias[2]);
        Jogo jogo3 = new Jogo(3, "The Witcher 3", 85, categorias[0]);
        Jogo jogo4 = new Jogo(4, "A Plague Tale", 140, categorias[1]);
        Jogo jogo5 = new Jogo(5, "Life is Strange", 110, categorias[1]);
        // adiciona os jogos na lista
        jogos.Add(jogo1);
        jogos.Add(jogo2);
        jogos.Add(jogo3);
        jogos.Add(jogo4);
        jogos.Add(jogo5);
       

        Console.WriteLine("=================================");
        Console.WriteLine("|      PLATAFORMA DE JOGOS      |");
        Console.WriteLine("=================================");

    

        int EscMenu;
        int proximoIdUsuario = 1;
        int proximoIdCompra = 1;

        // ------------ LOOP PARA O MENU ------------
        do
        {
            // ----- Exibe o Menu inicial de login
            Console.WriteLine("----------- MENU -----------");
            Console.WriteLine("| 1. Cadastrar Usuario    |");
            Console.WriteLine("| 2. Login                |");
            Console.WriteLine("| 0. Sair                 |");

            Console.Write("Escolha: ");
            EscMenu = int.Parse(Console.ReadLine());

            // Verifica qual foi a escolha do usuario e executa
            switch(EscMenu)
            {
                // Cadastrar usuario
                case 1:
                    Console.Write("Digite um nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite um e-mail: ");
                    string email = Console.ReadLine();

                    Console.Write("Digite uma senha: ");
                    string senha = Console.ReadLine();  

                    // Verifica se a senha tem no minimo 4 caracteres
                    while (senha.Length < 4)
                    {
                        Console.WriteLine("A senha deve ter no minimo 4 caracteres!");
                        Console.Write("Digite uma senha: ");
                        senha = Console.ReadLine();
                    }

                    // --- Cria um objeto usuario
                    Usuario usuario = new Usuario(proximoIdUsuario, nome, email, senha);
                    // --- Adiciona usuario na lista 
                    usuarios.Add(usuario);

                    Console.WriteLine("Usuario cadastrado com sucesso!");
                    Console.WriteLine($"Seu ID é: {usuario.Id}");
                    Console.WriteLine("Guarde esse ID para fazer login.");

                    proximoIdUsuario++;
                    break;

                // Login
                case 2:
                    Console.Write("Digite seu ID: ");
                    int idLogin = int.Parse(Console.ReadLine());

                    Console.Write("Digite sua senha: ");
                    string senhaLogin = Console.ReadLine();

                    // Percorre a lista de usuarios e verifica ID e senha
                    foreach (Usuario usuarioLogin in usuarios)
                    {
                        if (usuarioLogin.Id == idLogin && usuarioLogin.Senha == senhaLogin)
                        {
                            usuarioLogado = usuarioLogin;
                            Console.WriteLine($"Login realizado com sucesso! Bem-vindo(a), {usuarioLogado.Nome}!");
                            break;
                        }
                    }

                    if (usuarioLogado == null)
                    {
                        Console.WriteLine("ID ou senha incorretos!");
                    }
                    break;

                case 0:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("[ERRO] Escolha um número válido!");
                    break;
            }

        }while (EscMenu != 0 && usuarioLogado == null);

        // Esse if verifica se o usuario esta logado, se nn estiver, o menu nao aparece
        if (usuarioLogado !=null)
        {
            // ---------- LOOP PARA MENU PRINCIPAL
            do
            {
                Console.WriteLine("----------- MENU -----------");
                Console.WriteLine("| 1. Listar Jogos         |");
                Console.WriteLine("| 2. Buscar Jogo          |");
                Console.WriteLine("| 3. Comprar Jogo         |");
                Console.WriteLine("| 4. Ver minha biblioteca |");
                Console.WriteLine("| 0. Sair                 |");

                Console.Write("Escolha: ");
                EscMenu = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (EscMenu)
                {
                    // Listar jogos
                    case 1:
                        // Chama o metodo da classe jogos
                        Jogo.ListarJogos(jogos);
                        break;

                    // Buscar Jogo
                    case 2:
                        Console.Write("Digite o ID do jogo: ");
                        int idBusca = int.Parse(Console.ReadLine());

                        Jogo.BuscarJogo(jogos, idBusca);
                        break;  

                    // Comprar jogo
                    case 3:
                        // Metodo para listar jogos
                        Jogo.ListarJogos(jogos);
                        
                        Console.Write("Digite o ID do jogo que deseja comprar: ");
                        int idJogo = int.Parse(Console.ReadLine());

                        // Percorre a lista de jogos ate achar o ID digitado
                        foreach (Jogo jogoCompra in jogos)
                        {
                            if (jogoCompra.Id == idJogo)
                            {
                                Compra compra = new Compra(proximoIdCompra, usuarioLogado, jogoCompra);

                                compras.Add(compra);

                                compra.FinalizarCompra();

                                proximoIdCompra++;
                                break;
                            }
                        }
                        break;
                    
                    // Ver biblioteca
                    case 4:
                        usuarioLogado.Biblioteca.ListarJogos();
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("[ERRO] Escolha um número válido!");
                        break;
                }

            } while (EscMenu != 0);
        }

    }
           
}
