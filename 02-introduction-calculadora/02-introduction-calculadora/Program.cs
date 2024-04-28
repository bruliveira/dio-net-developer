
using _02_introduction_calculadora.Models;

Calculadora calculadora = new Calculadora();

while (true)
{
    Console.WriteLine("\n---------- CALCULADORA ----------");
    Console.WriteLine("1-Soma\n2-Subtração\n3-Multiplicação\n4-Divisão\n5-Potência\n6-Sair\n");
    int op = int.Parse(Console.ReadLine());

    if (op == 6)
    {
        Console.WriteLine("Que pena! Até mais...");
        break;
    }
     
    Console.Write("Digite o primeiro número: ");
    int numero1 = int.Parse(Console.ReadLine());
    Console.Write("Digite o segundo número: ");
    int numero2 = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            Console.WriteLine($"-> Resultado da soma: {calculadora.Somar(numero1, numero2)}");
            break;
        case 2:
            Console.WriteLine($"-> Resultado da subtração: {calculadora.Subtrair(numero1, numero2)}");
            break;
        case 3:
            Console.WriteLine($"-> Resultado da multiplicação: {calculadora.Multiplicar(numero1, numero2)}");
            break;
        case 4:
            // Verifica se o divisor é zero para evitar divisão por zero
            if (numero2 != 0)
            {
                Console.WriteLine($"-> Resultado da divisão: {calculadora.Dividir(numero1, numero2)}");
            }
            else
            {
                Console.WriteLine("Erro: Divisão por zero não é permitida.");
            }
            break;
        case 5:
            Console.WriteLine($"-> Resultado da potência: {calculadora.Potencia(numero1, numero2)}");
            break;
        default:
            Console.WriteLine("Opção inválida! Tente novamente.");
            break;
    }
}



