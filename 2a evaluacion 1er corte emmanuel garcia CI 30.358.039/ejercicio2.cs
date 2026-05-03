using System;
using System.Globalization;

namespace StoreDiscountSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set professional console appearance
            Console.Title = "Calculadora de Descuentos de Almacén";
            CultureInfo customCulture = new CultureInfo("es-MX");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("================================================");
            Console.WriteLine("         SISTEMA DE DESCUENTOS DE ALMACÉN       ");
            Console.WriteLine("================================================\n");
            Console.ResetColor();

            try
            {
                // 1. Input: Total purchase amount
                Console.Write("Ingrese el monto total de la compra ($): ");
                double totalPurchase = double.Parse(Console.ReadLine());

                // 2. Constants for business logic
                const double DiscountThreshold = 1000.00;
                const double DiscountRate = 0.20; // 20%
                
                double finalAmount = totalPurchase;
                double appliedDiscount = 0;

                // 3. Logic: Apply discount only if purchase exceeds $1000
                if (totalPurchase > DiscountThreshold)
                {
                    appliedDiscount = totalPurchase * DiscountRate;
                    finalAmount = totalPurchase - appliedDiscount;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡Felicidades! Su compra califica para un 20% de descuento.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nEl monto no supera los $1,000. No se aplica descuento.");
                }
                Console.ResetColor();

                // 4. Output: Detailed receipt
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Monto original:   {totalPurchase.ToString("C2", customCulture)}");
                Console.WriteLine($"Descuento (20%): -{appliedDiscount.ToString("C2", customCulture)}");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"TOTAL A PAGAR:    {finalAmount.ToString("C2", customCulture)}");
                Console.WriteLine("------------------------------------------------");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Por favor, ingrese un monto numérico válido.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
