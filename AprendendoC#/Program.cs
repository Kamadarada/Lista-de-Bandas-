

using System.Diagnostics;
using System.Xml;


//List<string> ListaBandas = new List<string> {"Nirvana" , "beatles", "RHCP " };
Dictionary<string, List<float>> bandasRegistradas = new Dictionary<string, List<float>>();
bandasRegistradas.Add("Linkin Park", new List<float> { 10, 8, 6 });
bandasRegistradas.Add("Nirvana", new List<float>());

void exibiLogo()
{
    
    string logo = (@"

███████╗██╗██████╗░░██████╗████████╗  ██████╗░██████╗░░█████╗░░░░░░██╗███████╗░█████╗░████████╗
██╔════╝██║██╔══██╗██╔════╝╚══██╔══╝  ██╔══██╗██╔══██╗██╔══██╗░░░░░██║██╔════╝██╔══██╗╚══██╔══╝
█████╗░░██║██████╔╝╚█████╗░░░░██║░░░  ██████╔╝██████╔╝██║░░██║░░░░░██║█████╗░░██║░░╚═╝░░░██║░░░
██╔══╝░░██║██╔══██╗░╚═══██╗░░░██║░░░  ██╔═══╝░██╔══██╗██║░░██║██╗░░██║██╔══╝░░██║░░██╗░░░██║░░░
██║░░░░░██║██║░░██║██████╔╝░░░██║░░░  ██║░░░░░██║░░██║╚█████╔╝╚█████╔╝███████╗╚█████╔╝░░░██║░░░
╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░  ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚════╝░╚══════╝░╚════╝░░░░╚═╝░░░

");
    Console.WriteLine(logo);

    // Função de senha para acesso ao sistema 

    /*
    string credencialDono = ("Felipe Kamada");
    int credencial = 25082004; 
    Console.Write("Insira sua credencial:  ");
    string senhaCredencial = Console.ReadLine()!;
    int senhaConvertida = int.Parse(senhaCredencial);
    if (senhaConvertida == credencial)
    {
        Console.WriteLine("\nSeja bem - vindo {0}!\n ", credencialDono);
    }
    else
    {
        Console.Write("\nCredencial inválida - Acesso negado.\n");
        Environment.Exit(1);// exit
    }*/

}
void exibiMenu()
{
    Console.WriteLine("1. Inserir banda");
    Console.WriteLine("2. Listar bandas");
    Console.WriteLine("3. Avaliar banda");
    Console.WriteLine("4. média de uma banda");
    Console.WriteLine("0. Sair");

    Console.Write("\nSelecione sua opção: ");
    string opcSelecionada = Console.ReadLine()!;
    int convertSelecionada = int.Parse(opcSelecionada);
    switch (convertSelecionada)
    {
        case 1:
            RegistrarBanda();

            break;

        case 2:
            ListarBandas();
            break;

        case 3:
            avaliarBanda();
            break;

        case 4:
            mediaBandas();
            break;

        case 0:
            Console.WriteLine("\nAté a próxima !");
            break;

        default:
            Console.WriteLine("Opção não existe ! ");
            break;
    }

}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Registro das bandas");
    Console.WriteLine("Bandas existentes: ");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"- {banda}");
    }
    Console.Write("\nDigite o nome da banda a ser registrada: ");
    string NomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(NomeBanda, new List<float>());
    Console.Write($"\nA banda {NomeBanda} foi registrada com sucesso! ");
    Console.Clear();
    exibiInicio();
}
void ListarBandas()
{
    Console.Clear();
    ExibirTituloOpcao("Listando bandas registradas: ");
    //for para listar as bandas existentes
    /*for(int i = 0; i < ListaBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {ListaBandas[i]}");
    }*/
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"- {banda}");
    }

    retorna();
}
void avaliarBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Avaliar banda\n");
    //digite qual banda deseja avaliar
    //buscar banda no dicionario >> atribuir nota
    // nao existir >> voltar ao menu principal 
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"- {banda}");
    }

    Console.Write("\nQual das bandas você deseja avaliar? :  ");
    string bandaAvaliada = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(bandaAvaliada))
    {
        Console.Write($"\nCom qual nota deseja avaliar {bandaAvaliada} : ");
        float notaAvaliada = float.Parse(Console.ReadLine()!);
        bandasRegistradas[bandaAvaliada].Add(notaAvaliada);
        Console.WriteLine($"\n{bandaAvaliada} foi avaliada em nota {notaAvaliada} com sucesso! ");
        Thread.Sleep(3000);
        Console.Clear();
        exibiInicio();


    }
    else
    {
        Console.WriteLine($"\nA banda {bandaAvaliada} não está inserida na lista de bandas!");
        Console.Write("\nPressione qualquer -1 para menu principal e -2 para buscar novamente: ");
        string escolha = Console.ReadLine()!;
        int escolhaConv = int.Parse(escolha);
        if(escolhaConv == 1)
        {
            Console.Clear();
            exibiInicio();
        }
        else if (escolhaConv == 2)
        {
            avaliarBanda();
        }
        else
        {
            Thread.Sleep(2000);
            Console.Clear();
            exibiInicio();


        }
        Console.Clear();
        exibiInicio();
    }
}
void mediaBandas()
{
    Console.Clear();
    ExibirTituloOpcao("Média das bandas");
    Console.WriteLine("Bandas existentes: ");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"- {banda}");
    }
    Console.Write("De qual banda você quer ver as médias? : ");
    string bandaDesejada = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(bandaDesejada)){
        double mediaBandaDesejada = bandasRegistradas[bandaDesejada].Average();
        Console.WriteLine($"\nA média de {bandaDesejada} foi de {mediaBandaDesejada}");
    }
    else
    {
        Console.WriteLine($"A banda {bandaDesejada} não existe!");
        Thread.Sleep(3000);
        Console.Clear();
        exibiInicio();
    }
}
void ExibirTituloOpcao(string titulo)
{
    int qtdeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");

}
void exibiInicio()
{
    exibiLogo();
    exibiMenu();
}
void retorna()
{
    Console.Write("\nPressione qualquer tecla para retornar ao menu principal ");
    Console.ReadKey();
    Console.Clear();
    exibiInicio();
}

exibiInicio();
