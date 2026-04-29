using System;
using System.Collections.Generic;

namespace AlgoritmosSeleccion
{
    /// <summary>
    /// Programa que implementa una Criba de Selección.
    /// Organiza un vector moviendo números pares al inicio e impares al final.
    /// </summary>
    class CribaSeleccion
    {
        static void Main(string[] args)
        {
            // --- Declaración de variables y tipos de datos ---
            int tamano = 20;
            int[] vectorOriginal = new int[tamano];
            Random aleatorio = new Random();

            Console.WriteLine("===== ALGORITMO DE CRIBA DE SELECCIÓN (20 ELEMENTOS) =====");
            
            // Llenado del vector con números aleatorios entre 1 y 100
            for (int i = 0; i < tamano; i++)
            {
                vectorOriginal[i] = aleatorio.Next(1, 101);
            }

            Console.WriteLine("\nVector Generado Aleatoriamente:");
            Console.WriteLine(string.Join(", ", vectorOriginal));

            // --- Proceso de Clasificación (Criba) ---
            // Usamos listas temporales para asegurar que se mantenga el orden original
            List<int> pares = new List<int>();
            List<int> impares = new List<int>();

            foreach (int numero in vectorOriginal)
            {
                // Verificamos si el número es par usando el operador residuo (%)
                if (numero % 2 == 0)
                {
                    pares.Add(numero);
                }
                else
                {
                    impares.Add(numero);
                }
            }

            // Combinamos ambas listas para obtener el resultado final
            int[] vectorResultado = new int[tamano];
            pares.CopyTo(vectorResultado, 0);
            impares.CopyTo(vectorResultado, pares.Count);

            // --- Procedimiento de salida de resultados ---
            MostrarReporteFinal(vectorResultado, pares.Count, impares.Count);
        }

        /// <summary>
        /// Muestra el vector organizado y un resumen del conteo de elementos.
        /// </summary>
        static void MostrarReporteFinal(int[] resultado, int totalPares, int totalImpares)
        {
            Console.WriteLine("\nVector Organizado (Pares primero, Impares después):");
            Console.WriteLine(string.Join(", ", resultado));
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Resumen: Se detectaron {totalPares} pares y {totalImpares} impares.");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Presione cualquier tecla para finalizar el programa...");
            Console.ReadKey();
        }
    }
}
