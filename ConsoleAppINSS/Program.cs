using INSS;
using System;

namespace ConsoleAppINSS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" SIMULADOR DE CÁLCULO DE DESCANTO DO INSS\n");
            Console.ResetColor();
            do
            {
                ICalculadorInss calculador = new CalculadorInss();
                int ano;
                do
                {
                    Console.Write(" Ano: ");
                } while (!int.TryParse(Console.ReadLine(), out ano));
                decimal salario;
                do
                {
                    Console.Write(" Salario: ");
                } while (!decimal.TryParse(Console.ReadLine(), out salario));
                Console.WriteLine($" Desconto R${calculador.CalcularDesconto(new DateTime(ano, 1, 1), salario)}\n");
            } while (true);
        }       
    }
}
