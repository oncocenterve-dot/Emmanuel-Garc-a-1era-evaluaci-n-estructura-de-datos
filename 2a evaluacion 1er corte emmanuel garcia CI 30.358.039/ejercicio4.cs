using System;
using System.Globalization;

namespace ShirtStoreDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración visual de la consola
            Console.Title = "Calculadora de Descuento en Camisas";
            CultureInfo customCulture = new CultureInfo("es-MX");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("================================================");
            Console.WriteLine("          SISTEMA DE VENTAS: CAMISAS            ");
            Console.WriteLine("================================================\n");
            Console.ResetColor();

            try
            {
                // 1. Entrada de datos: Cantidad y Precio unitario
                Console.Write("Ingrese la cantidad de camisas compradas: ");
                int shirtQuantity = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el precio unitario de la camisa ($): ");
                double unitPrice = double.Parse(Console.ReadLine());

                // 2. Procesamiento inicial
                double subtotal = shirtQuantity * unitPrice;
                double discountPercentage = 0;

                // 3. Lógica: Aplicar descuento según la cantidad
                // Si son 3 o más -> 20%, si son menos de 3 -> 10%
                if (shirtQuantity >= 3)
                {
                    discountPercentage = 0.20;
                }
                else
                {
                    discountPercentage = 0.10;
                }

                double totalDiscount = subtotal * discountPercentage;
                double finalTotal = subtotal - totalDiscount;

                // 4. Salida de resultados
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine($"Subtotal:             {subtotal.ToString("C2", customCulture)}");
                Console.WriteLine($"Descuento aplicado:   {discountPercentage * 100}%");
                Console.WriteLine($"Monto descontado:    -{totalDiscount.ToString("C2", customCulture)}");
                Console.WriteLine("------------------------------------------------");
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"TOTAL A PAGAR:        {finalTotal.ToString("C2", customCulture)}");
                Console.ResetColor();
                Console.WriteLine("------------------------------------------------");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Por favor, ingrese valores válidos.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
