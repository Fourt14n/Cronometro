// See https://aka.ms/new-console-template for more information
using System.Threading;

Menu();


static void Menu(){
    Console.Clear();
    Console.WriteLine("Digite a opção que deseja realizar:");
    Console.WriteLine("1 - Executar o cronômetro");
    Console.WriteLine("2 - Sair do sistema");
    short opcao = Convert.ToInt16(Console.ReadLine());

    switch(opcao){
        case 1: MenuTempo(); break;
        case 2: Console.WriteLine("Fechando o sistema..."); System.Environment.Exit(0); break;
        default: Console.Clear(); Console.WriteLine("Opção inválida!");Thread.Sleep(1000); Menu(); break;
    }
}

static void MenuTempo(){
    Console.Clear();
    Console.WriteLine("Digite a quantidade de tempo para o cronômetro executar");
    Console.WriteLine("Modelo -> 12s ou 2m");
    string tempoExecucaoString = Console.ReadLine().ToLower();

    char grandezaTempo = char.Parse(tempoExecucaoString.Substring(tempoExecucaoString.Length - 1, 1));

    short tempoExecucao = short.Parse(tempoExecucaoString.Substring(0, tempoExecucaoString.Length - 1));

    Start(tempoExecucao, grandezaTempo);
}

static void Start(int time, char grandezaTempo)
{

    switch(grandezaTempo){
        case 's': time *= 1000; break;
        case 'm': time *= 60; break;
        default: Console.WriteLine("Valor inválido!"); Thread.Sleep(1000); MenuTempo(); break;
    }
    int currentTime = 0;

    while (currentTime != time)
    {
        currentTime++;
        Console.Clear();
        Console.WriteLine((currentTime < 60) ? $"{currentTime}s" : $"{currentTime / 60}m e {currentTime % 60}s" );

        // Uma thread é o menor espaço de execução de sistemas, ele é como um bit mas como se fosse janelas de execução, permitindo assim criar várias janelas para rodar simultaneamente enquanto o sistema principal roda, sem deixar o usuário em várias telas de carregamento.

        // No exemplo abaixo eu peço para a thread em execução "dormir", ela espera 1000ms, ou 1s, para voltar a executar.
        Thread.Sleep(1000);


    }
}