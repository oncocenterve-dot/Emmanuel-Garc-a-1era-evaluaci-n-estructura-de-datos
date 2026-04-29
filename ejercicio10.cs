using System;

namespace AlgoritmosMatrices
{
    /// <summary>
    /// Algoritmo para el cálculo y comparación de las diagonales de una matriz n x n.
    /// Identifica la suma de la diagonal principal y la secundaria.
    /// </summary>
    class DiagonalesMatriz
    {
        static void Main(string[] args)
        {
            // --- Declaración de variables ---
            int n;
            int sumaPrincipal = 0;
            int sumaSecundaria = 0;

            Console.WriteLine("===== ANÁLISIS DE DIAGONALES EN MATRIZ CUADRADA =====");
            Console.Write("Ingrese el tamaño (n) de la matriz cuadrada: ");
            
            if (!int.Parse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Error: El tamaño debe ser un entero positivo.");
                return;
            }

            int[,] matriz = new int[n, n];

            // --- Captura de datos ---
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Ingrese valor para [{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // --- Cálculo de Diagonales ---
            for (int i = 0; i < n; i++)
            {
                // Diagonal Principal: Los índices fila y columna son iguales (i, i)
                sumaPrincipal += matriz[i, i];

                // Diagonal Secundaria: La suma de los índices es siempre (n - 1)
                sumaSecundaria += matriz[i, n - 1 - i];
            }

            // --- Salida de Resultados y Comparación ---
            MostrarReporteFinal(sumaPrincipal, sumaSecundaria);
        }

        static void MostrarReporteFinal(int principal, int secundaria)
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"Suma Diagonal Principal: {principal}");
            Console.WriteLine($"Suma Diagonal Secundaria: {secundaria}");
            Console.WriteLine("-------------------------------------------");

            if (principal > secundaria)
            {
                Console.WriteLine("RESULTADO: La Diagonal Principal es mayor.");
            }
            else if (secundaria > principal)
            {
                Console.WriteLine("RESULTADO: La Diagonal Secundaria es mayor.");
            }
            else
            {
                Console.WriteLine("RESULTADO: Ambas diagonales son iguales.");
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Presione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
