using System;
using System.Globalization;

namespace InvestmentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set console title and professional appearance
            Console.Title = "Calculadora de Intereses de Inversión";
            
            // Using a specific culture to ensure currency symbols look right
            CultureInfo customCulture = new CultureInfo("es-MX"); 

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================================");
            Console.WriteLine("       CALCULADORA DE INTERESES BANCARIOS       ");
            Console.WriteLine("================================================\n");
            Console.ResetColor();

            try
            {
                // 1. Input: Capital and Interest Rate
                Console.Write("Ingrese la cantidad total a invertir ($): ");
                double initialCapital = double.Parse(Console.ReadLine());

                Console.Write("Ingrese la tasa de interés mensual (ejemplo: 2 para 2%): ");
                double interestRatePercentage = double.Parse(Console.ReadLine());

                // 2. Processing: Calculate interest
                // Formula: Interest = Capital * (Rate / 100)
                double generatedInterest = initialCapital * (interestRatePercentage / 100);
                double finalBalance = initialCapital;

                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine($"Intereses generados: {generatedInterest.ToString("C2", customCulture)}");

                // 3. Logic: Reinvestment condition (Threshold: $7,000)
                const double ReinvestmentThreshold = 7000;

                if (generatedInterest > ReinvestmentThreshold)
                {
                    finalBalance += generatedInterest;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Estado: Los intereses exceden $7,000. Se han reinvertido.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Estado: Intereses menores a $7,000. No se aplica reinversión.");
                }
                Console.ResetColor();

                // 4. Output: Final Balance
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Saldo final en la cuenta: {finalBalance.ToString("C2", customCulture)}");
                Console.WriteLine("------------------------------------------------");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Por favor, ingrese valores numéricos válidos.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
