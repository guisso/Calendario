using System;

namespace Calendario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Objeto gerador do calendário
            Calendario calendario = new Calendario();

            // Entrada e validação do MÊS
            do
            {
                Console.Write("Digite o MÊS desejado: ");
                try
                {
                    // Exceções ocorrem quando valores não numéricos são inseridos
                    calendario.Mes = Convert.ToByte(Console.ReadLine());

                    // Para valores numéricos válidos, verifica-se a faixa
                    if (!calendario.IsMesValido())
                    {
                        throw new Exception("Mês inválido.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(
                          "\n-----------------------------------------"
                        + "\n  O MÊS deve seguir o formato numérico,  "
                        + "\n  tal como '3' para março,               "
                        + "\n  e, portanto, deve ser de 1 a 12.       "
                        + "\n-----------------------------------------\n");
                }
                
            } while (!calendario.IsMesValido());
            
            // Entrada e validação do ANO
            do
            {
                Console.Write("Digite o ANO desejado: ");
                try
                {
                    // Exceções ocorrem quando valores não numéricos são inseridos
                    calendario.Ano = Convert.ToUInt16(Console.ReadLine());

                    // Para valores numéricos válidos, verifica-se a faixa
                    if (!calendario.IsAnoValido())
                    {
                        throw new Exception("Ano inválido.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(
                          "\n-------------------------------------------"
                        + "\n  O ANO deve seguir o formato numérico,    "
                        + "\n  tal como '2022', e deve ser de 1 a 9999. "
                        + "\n-------------------------------------------\n");
                }
                
            } while (!calendario.IsAnoValido());

            Console.WriteLine("\n" + calendario.GerarCalendario());
            Console.ReadLine();
        }
    }
}
