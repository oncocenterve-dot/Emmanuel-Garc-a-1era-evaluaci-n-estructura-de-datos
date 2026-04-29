using System;

namespace AlgoritmosMatrices
{
    /// <summary>
    /// Algoritmo para la multiplicación de dos matrices A y B.
    /// Incluye validación de compatibilidad (Columnas A == Filas B).
    /// </summary>
    class MultiplicacionMatrices
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== MULTIPLICACIÓN DE MATRICES (PRODUCTO PUNTO) =====");

            // --- Dimensiones de Matriz A ---
            Console.Write("Filas de Matriz A: ");
            int filasA = int.Parse(Console.ReadLine());
            Console.Write("Columnas de Matriz A: ");
            int colsA = int.Parse(Console.ReadLine());

            // --- Dimensiones de Matriz B ---
            Console.Write("Filas de Matriz B: ");
            int filasB = int.Parse(Console.ReadLine());
            Console.Write("Columnas de Matriz B: ");
            int colsB = int.Parse(Console.ReadLine());

            // --- Validación de Compatibilidad ---
            if (colsA != filasB)
            {
                Console.WriteLine("\nERROR: Las matrices no son compatibles.");
                Console.WriteLine("El número de columnas de A debe ser igual al de filas de B.");
                return;
            }

            // Inicialización de matrices
            int[,] matrizA = new int[filasA, colsA];
            int[,] matrizB = new int[filasB, colsB];
            int[,] matrizResultado = new int[filasA, colsB];

            // --- Captura de datos ---
            Console.WriteLine("\n--- Llenado de Matriz A ---");
            LlenarMatriz(matrizA, filasA, colsA);

            Console.WriteLine("\n--- Llenado de Matriz B ---");
            LlenarMatriz(matrizB, filasB, colsB);

            // --- Algoritmo de Multiplicación ---
            for (int i = 0; i < filasA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    matrizResultado[i, j] = 0;
                    for (int k = 0; k < colsA; k++) // o filasB, son iguales
                    {
                        // Fórmula: Sumatoria de A[i,k] * B[k,j]
                        matrizResultado[i, j] += matrizA[i, k] * matrizB[k, j];
                    }
                }
            }

            // --- Salida de Resultados ---
            ImprimirResultadoFinal(matrizA, matrizB, matrizResultado, filasA, colsA, filasB, colsB);
        }

        static void LlenarMatriz(int[,] matriz, int f, int c)
        {
            for (int i = 0; i < f; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"Posición [{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void ImprimirResultadoFinal(int[,] a, int[,] b, int[,] res, int fA, int cA, int fB, int cB)
        {
            Console.WriteLine("\nResultado de A x B:");
            for (int i = 0; i < fA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    Console.Write(res[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
