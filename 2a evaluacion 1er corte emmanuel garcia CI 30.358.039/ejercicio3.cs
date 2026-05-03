using System;

namespace DigitCounterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Contador de Dígitos Repetidos";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================================");
            Console.WriteLine("      CONTEO DE FRECUENCIA DE DÍGITOS          ");
            Console.WriteLine("================================================\n");
            Console.ResetColor();

            try
            {
                // Entrada de datos
                Console.Write("Ingrese un número entero: ");
                long inputNumber = Math.Abs(long.Parse(Console.ReadLine())); // Math.Abs para manejar negativos

                // 1. Llamada a la FUNCIÓN para obtener las frecuencias
                int[] frequencies = GetDigitFrequencies(inputNumber);

                // 2. Llamada al PROCEDIMIENTO para mostrar resultados
                DisplayResults(frequencies);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Por favor, ingrese un número entero válido.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // FUNCIÓN: Recibe un número y devuelve un array con el conteo (0-9)
        // Cumple con la condición: Tiene parámetros y retorna un valor
        static int[] GetDigitFrequencies(long number)
        {
            int[] digitCounts = new int[10]; // Estructura estática para almacenar del 0 al 9

            if (number == 0)
            {
                digitCounts[0] = 1;
                return digitCounts;
            }

            while (number > 0)
            {
                int lastDigit = (int)(number % 10); // Obtenemos el último dígito
                digitCounts[lastDigit]++;           // Aumentamos el contador en esa posición
                number /= 10;                       // Eliminamos el último dígito
            }

            return digitCounts;
        }

        // PROCEDIMIENTO: Recibe el array y lo imprime en consola
        // Cumple con la condición: Tiene parámetros y es 'void' (no retorna valor)
        static void DisplayResults(int[] counts)
        {
            Console.WriteLine("\nResultados del análisis:");
            Console.WriteLine("------------------------------------------------");
            bool hasRepetitions = false;

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine($"Dígito {i}: se repite {counts[i]} vez/veces.");
                    hasRepetitions = true;
                }
            }

            if (!hasRepetitions)
            {
                Console.WriteLine("No se encontraron dígitos.");
            }
            Console.WriteLine("------------------------------------------------");
        }
    }
}
