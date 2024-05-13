using System;
using System.Collections.Generic;
using System.Text;
using _03_manipulation_hospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();
Reserva reserva = null;


void MostrarMenu()
{
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1. Cadastrar Pessoa");
    Console.WriteLine("2. Cadastrar Suíte");
    Console.WriteLine("3. Ver Quantidade de Hóspedes");
    Console.WriteLine("4. Calcular Valor da Diária");
    Console.WriteLine("5. Fazer Reserva");
    Console.WriteLine("6. Sair");
    Console.WriteLine("============");
}

// Loop do menu
bool executando = true;
while (executando)
{
    MostrarMenu();
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            Console.Write("Digite o nome da pessoa: ");
            string nomePessoa = Console.ReadLine();
            Pessoa novaPessoa = new Pessoa(nomePessoa);
            hospedes.Add(novaPessoa);
            Console.WriteLine("Pessoa cadastrada com sucesso!");
            break;

        case "2":
            Console.Write("Digite o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();
            Console.Write("Digite a capacidade da suíte: ");
            int capacidadeSuite = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da diária da suíte: ");
            decimal valorDiariaSuite = decimal.Parse(Console.ReadLine());
            Suite novaSuite = new Suite(tipoSuite, capacidadeSuite, valorDiariaSuite);
            suites.Add(novaSuite);
            Console.WriteLine("Suíte cadastrada com sucesso!");
            break;

        case "3":
            if (reserva != null)
            {
                Console.WriteLine($"Quantidade de Hóspedes na Reserva: {reserva.ObterQuantidadeHospedes()}");
            }
            else
            {
                Console.WriteLine("Nenhuma reserva realizada ainda.");
            }
            break;

        case "4":
            if (reserva != null)
            {
                Console.WriteLine($"Valor da Diária: {reserva.CalcularValorDiaria():C}");
            }
            else
            {
                Console.WriteLine("Nenhuma reserva realizada ainda.");
            }
            break;

        case "5":
            if (hospedes.Count == 0)
            {
                Console.WriteLine("Não é possível fazer uma reserva sem hóspedes cadastrados.");
            }
            else if (suites.Count == 0)
            {
                Console.WriteLine("Não é possível fazer uma reserva sem suítes cadastradas.");
            }
            else
            {
                Console.WriteLine("Reserva em andamento...");
                Console.Write("Digite o número de dias da reserva: ");
                int diasReserva = int.Parse(Console.ReadLine());

                reserva = new Reserva(diasReserva);
                reserva.CadastrarSuite(suites[0]);
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("Reserva realizada com sucesso!");
            }
            break;

        case "6":
            Console.WriteLine("Saindo do programa...");
            executando = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine(); 
}
