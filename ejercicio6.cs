using System;

namespace AlgoritmosMatrices
{
    /// <summary>
    /// Algoritmo para la validación de un Cuadrado Mágico de 3x3.
    /// Compara las sumas de filas, columnas y diagonales para verificar la igualdad.
    /// </summary>
    class CuadradoMagico
    {
        static void Main(string[] args)
        {
            // --- Declaración de la matriz y variables de control ---
            int[,] matriz = new int[3, 3];
            int sumaObjetivo = 0;
            bool esMagico = true;

            Console.WriteLine("===== VALIDADOR DE CUADRADO MÁGICO (3x3) =====");
            
            // --- Proceso de lectura de la matriz ---
            for (int fila = 0; fila < 3; fila++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"Ingrese valor para la posición [{fila},{col}]: ");
                    matriz[fila, col] = int.Parse(Console.ReadLine());
                }
            }

            // Calculamos la suma de la primera fila como referencia (Suma Objetivo)
            for (int j = 0; j < 3; j++) sumaObjetivo += matriz[0, j];

            // --- Validación de Filas y Columnas ---
            for (int i = 0; i < 3; i++)
            {
                int sumaFila = 0;
                int sumaColumna = 0;
                for (int j = 0; j < 3; j++)
                {
                    sumaFila += matriz[i, j];
                    sumaColumna += matriz[j, i];
                }

                if (sumaFila != sumaObjetivo || sumaColumna != sumaObjetivo)
                {
                    esMagico = false;
                    break;
                }
            }

            // --- Validación de Diagonales ---
            if (esMagico)
            {
                int diagPrincipal = matriz[0, 0] + matriz[1, 1] + matriz[2, 2];
                int diagSecundaria = matriz[0, 2] + matriz[1, 1] + matriz[2, 0];

                if (diagPrincipal != sumaObjetivo || diagSecundaria != sumaObjetivo)
                {
                    esMagico = false;
                }
            }

            // --- Procedimiento de salida de resultados ---
            MostrarResultado(matriz, esMagico, sumaObjetivo);
        }

        /// <summary>
        /// Imprime la matriz en formato visual y el veredicto final.
        /// </summary>
        static void MostrarResultado(int[,] m, bool magico, int suma)
        {
            Console.WriteLine("\nMatriz Resultante:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(m[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------------------");
            if (magico)
                Console.WriteLine($"¡ES UN CUADRADO MÁGICO! (Suma constante: {suma})");
            else
                Console.WriteLine("NO ES UN CUADRADO MÁGICO.");
            
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
