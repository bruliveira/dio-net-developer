using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_introduction_calculadora.Models
{
    public class Calculadora
    {

        public int Somar(int numero1, int numero2)
        {
            return (numero1 + numero2);
        }
        public int Subtrair(int numero1, int numero2)
        {
            return (numero1 - numero2);
        }
        public int Multiplicar(int numero1, int numero2)
        {
            return (numero1 * numero2);
        }
        public int Dividir(int numero1, int numero2)
        {
            return (numero1 / numero2);
        }
        public double Potencia(double numero1, double numero2) 
        {
            return Math.Pow(numero1, numero2);
        }

    }
}
