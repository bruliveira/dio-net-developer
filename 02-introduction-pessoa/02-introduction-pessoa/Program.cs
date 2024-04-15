
using _02_introduction_pessoa.Models;

Pessoa pessoa1 = new Pessoa();

pessoa1.Nome = "Mariana";
pessoa1.Idade = 20;

// Pelo contrutor
Pessoa pessoa2 = new Pessoa("Breno", 15);


Console.WriteLine("INFORMAÇÕES PESSOAS\n-> Vamos lá\n");
pessoa1.Apresentar();
pessoa2.Apresentar();

Console.WriteLine($"Olá {pessoa1.Nome} você tem {pessoa1.Idade} anos");