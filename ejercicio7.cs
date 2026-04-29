using System;

namespace AlgoritmosMatrices
{
    /// <summary>
    /// Programa para realizar la transposición de una matriz de n x m.
    /// Convierte las filas de la matriz original en las columnas de una nueva matriz.
    /// </summary>
    class TransposicionDatos
    {
        static void Main(string[] args)
        {
            // --- Declaración de dimensiones ---
            int n, m;

            Console.WriteLine("===== ALGORITMO DE TRANSPOSICIÓN DE MATRICES =====");
            Console.Write("Ingrese el número de filas (n): ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el número de columnas (m): ");
            m = int.Parse(Console.ReadLine());

            // Matriz original de n x m
            int[,] matrizOriginal = new int[n, m];

            // --- Captura de datos ---
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Elemento [{i},{j}]: ");
                    matrizOriginal[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // --- Algoritmo de Transposición ---
            // La nueva matriz tendrá dimensiones invertidas: m x n
            int[,] matrizTranspuesta = new int[m, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // La fila 'i' y columna 'j' pasa a ser fila 'j' y columna 'i'
                    matrizTranspuesta[j, i] = matrizOriginal[i, j];
                }
            }

            // --- Salida de Resultados ---
            ImprimirMatrices(matrizOriginal, matrizTranspuesta, n, m);
        }

        static void ImprimirMatrices(int[,] original, int[,] transpuesta, int n, int m)
        {
            Console.WriteLine("\nMatriz Original (" + n + "x" + m + "):");
            MostrarMatriz(original, n, m);

            Console.WriteLine("\nMatriz Transpuesta (" + m + "x" + n + "):");
            MostrarMatriz(transpuesta, m, n);

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Proceso completado. Presione cualquier tecla.");
            Console.ReadKey();
        }

        static void MostrarMatriz(int[,] matriz, int filas, int columnas)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
