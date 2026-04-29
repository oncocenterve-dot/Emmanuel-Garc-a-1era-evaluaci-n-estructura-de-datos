using System;

namespace AlgoritmosVectores
{
    /// <summary>
    /// Programa diseñado para realizar la inversión de un vector.
    /// Implementa la técnica de intercambio 'in-place' para optimizar el uso de memoria.
    /// </summary>
    class InversionControl
    {
        static void Main(string[] args)
        {
            // --- Declaración de variables y tipos de datos ---
            int n;
            
            Console.WriteLine("===== ALGORITMO DE INVERSIÓN IN-PLACE =====");
            Console.Write("¿Cuántos elementos desea ingresar en el vector?: ");
            
            // Validación de entrada para el tamaño del vector
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Error: Ingrese un tamaño válido.");
                return;
            }

            // Inicialización del vector original
            int[] vectorDatos = new int[n];

            // Lectura de los elementos del vector
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese el valor para la posición [{i}]: ");
                vectorDatos[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nVector original: " + string.Join(", ", vectorDatos));

            // --- Algoritmo de Inversión In-Place ---
            // Solo recorremos hasta la mitad del vector para intercambiar los extremos
            for (int i = 0; i < n / 2; i++)
            {
                // Guardamos el valor actual en una variable temporal
                int temporal = vectorDatos[i];
                
                // Intercambiamos el elemento del inicio con su correspondiente al final
                // La fórmula (n - 1 - i) nos da el índice simétrico
                vectorDatos[i] = vectorDatos[n - 1 - i];
                vectorDatos[n - 1 - i] = temporal;
            }

            // --- Procedimiento de salida ---
            MostrarResultadoFinal(vectorDatos);
        }

        /// <summary>
        /// Muestra el vector ya invertido en la consola.
        /// </summary>
        /// <param name="vector">El vector procesado.</param>
        static void MostrarResultadoFinal(int[] vector)
        {
            Console.WriteLine("Vector invertido: " + string.Join(", ", vector));
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Proceso de inversión completado sin vectores auxiliares.");
            Console.WriteLine("Presione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
