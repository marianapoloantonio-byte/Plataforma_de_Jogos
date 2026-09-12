using System;

using System.Collections.Generic;

using System.Linq;

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

    // Método para exibir os dados do usuário
    // A senha não é exibida por segurança
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

    // Método para exibir as informações do jogo
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

    public Categoria(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

class Biblioteca
{
    public List<Jogo> Jogos = new List<Jogo>();

    // Adiciona um jogo na biblioteca do usuário
    public void AdicionarJogo(Jogo jogo)
    {
        Jogos.Add(jogo);
    }

    // Percorre a lista de jogos e exibe cada jogo
    public void ListarJogos()
    {
        foreach (Jogo jogo in Jogos)
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

    // Finaliza a compra e adiciona o jogo
    // na biblioteca do usuário
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
        // --- Listas para armazenar os objetos do sistema ---

        List<Usuario> usuarios = new List<Usuario>();

        List<Jogo> jogos = new List<Jogo>();

        List<Categoria> categorias = new List<Categoria>();

        List<Compra> compras = new List<Compra>();


        // NOVO:
        // Guarda qual usuário está utilizando o sistema no momento.
        // Inicialmente é null porque nenhum usuário foi cadastrado.
        Usuario usuarioAtual = null;


        Console.WriteLine("=================================");

        Console.WriteLine("|       PLATAFORMA DE JOGOS      |");

        Console.WriteLine("=================================");


        int EscMenu;

        int proximoIdUsuario = 1;

        int proximoIdJogo = 1;


        // ------------ LOOP PARA O MENU ------------

        do
        {
            // NOVO:
            // Verifica se existe um usuário selecionado.
            // Se existir, mostra o nome dele no menu.
            if (usuarioAtual != null)
            {
                Console.WriteLine($"Usuário: {usuarioAtual.Nome}");
            }
            else
            {
                Console.WriteLine("Usuário: Nenhum usuário selecionado");
            }


            // ----- Exibe o Menu -----

            Console.WriteLine("----------- MENU -----------");

            Console.WriteLine("| 1. Cadastrar Usuario     |");

            Console.WriteLine("| 2. Cadastrar Jogo       |");

            Console.WriteLine("| 3. Listar Jogos         |");

            Console.WriteLine("| 4. Comprar Jogo         |");

            Console.WriteLine("| 5. Ver minha biblioteca |");

            Console.WriteLine("| 6. Remover jogo         |");

            Console.WriteLine("| 0. Sair                 |");

            Console.Write("Escolha: ");

            EscMenu = int.Parse(Console.ReadLine());


            // Verifica qual foi a escolha do usuário
            // e executa a opção correspondente

            switch (EscMenu)
            {
                case 1:

                    // ================================
                    // NOVO: VALIDAÇÃO DO NOME
                    // ================================

                    string nome;

                    // O do/while faz o programa pedir o nome
                    // novamente enquanto ele for inválido
                    do
                    {
                        Console.Write("Digite um nome: ");

                        nome = Console.ReadLine();


                        // Chama o método NomeValido para verificar
                        // se o nome possui somente letras
                        if (!NomeValido(nome))
                        {
                            Console.WriteLine(
                                "ERRO! O nome deve conter apenas letras."
                            );
                        }

                    } while (!NomeValido(nome));


                    Console.Write("Digite um e-mail: ");

                    string email = Console.ReadLine();


                    Console.Write("Digite uma senha: ");

                    string senha = Console.ReadLine();


                    // Cria um objeto Usuario
                    Usuario usuario = new Usuario(
                        proximoIdUsuario,
                        nome,
                        email,
                        senha
                    );


                    // Adiciona o usuário na lista
                    usuarios.Add(usuario);


                    // NOVO:
                    // Define o usuário que acabou de ser cadastrado
                    // como o usuário atual do sistema
                    usuarioAtual = usuario;


                    Console.WriteLine(
                        "Usuario cadastrado com sucesso!"
                    );


                    // Aumenta o ID para o próximo usuário
                    proximoIdUsuario++;

                    break;


                case 2:

                    Console.Write("Digite o nome do jogo: ");

                    string nomeJogo = Console.ReadLine();


                    Console.Write("Digite o preço do jogo: ");

                    double preco = double.Parse(
                        Console.ReadLine()
                    );


                    Console.Write("Digite a categoria do jogo: ");

                    string nomeCategoria = Console.ReadLine();


                    Categoria categoria = new Categoria(
                        1,
                        nomeCategoria
                    );


                    Jogo jogo = new Jogo(
                        proximoIdJogo,
                        nomeJogo,
                        preco,
                        categoria
                    );


                    // Adiciona o jogo na lista de jogos
                    jogos.Add(jogo);


                    Console.WriteLine(
                        "Jogo cadastrado com sucesso!"
                    );


                    // Aumenta o ID para o próximo jogo
                    proximoIdJogo++;

                    break;


                case 3:

                    // ================================
                    // NOVO: LISTAR JOGOS
                    // ================================


                    // Count verifica quantos jogos existem na lista.
                    // Se for igual a 0, significa que nenhum jogo
                    // foi cadastrado.
                    if (jogos.Count == 0)
                    {
                        Console.WriteLine(
                            "Nenhum jogo cadastrado!"
                        );
                    }

                    else
                    {
                        // foreach percorre todos os jogos
                        // existentes dentro da lista "jogos"
                        foreach (Jogo jogoLista in jogos)
                        {
                            // Chama o método que exibe
                            // as informações de cada jogo
                            jogoLista.ExibirInformacoes();

                            Console.WriteLine("----------------");
                        }
                    }

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

                    Console.WriteLine(
                        "[ERRO] Escolha um número válido!"
                    );

                    break;
            }

        } while (EscMenu != 0);
    }


    // ==========================================
    // NOVO: MÉTODO PARA VALIDAR O NOME
    // ==========================================

    static bool NomeValido(string nome)
    {
        // Percorre cada caractere digitado no nome
        foreach (char letra in nome)
        {
            // char.IsLetter verifica se o caractere
            // atual é uma letra.
            //
            // O ! significa "não".
            //
            // Portanto:
            // !char.IsLetter(letra)
            // significa que o caractere NÃO é uma letra.

            if (!char.IsLetter(letra))
            {
                // Se encontrar número, símbolo ou outro
                // caractere inválido, retorna false
                return false;
            }
        }


        // Se percorreu todo o nome e encontrou
        // somente letras, retorna true
        return true;
    }
}
