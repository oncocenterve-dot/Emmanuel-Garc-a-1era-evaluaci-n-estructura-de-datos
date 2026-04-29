using System;

namespace AuditoriaContable
{
    /// <summary>
    /// Algoritmo de Mapa de Auditoría (Filtro de Umbral).
    /// Procesa una matriz contable y elimina el 'ruido' reemplazando valores
    /// menores al umbral por cero.
    /// </summary>
    class FiltroAuditoria
    {
        static void Main(string[] args)
        {
            // --- Configuración de la matriz ---
            int filas = 4;
            int columnas = 3;
            double[,] hojaContable = new double[filas, columnas];
            double umbral;

            Console.WriteLine("===== SISTEMA DE FILTRADO DE AUDITORÍA =====");

            // --- Captura de Datos ---
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write($"Ingrese valor contable para [{i},{j}]: ");
                    hojaContable[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.Write("\nIngrese el valor UMITE (Umbral) para la limpieza: ");
            if (!double.TryParse(Console.ReadLine(), out umbral))
            {
                Console.WriteLine("Error: Umbral no válido.");
                return;
            }

            // --- Proceso de Filtrado (Capa de Negocio) ---
            // Creamos una nueva matriz para no destruir los datos originales
            double[,] matrizLimpia = new double[filas, columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Lógica del filtro: si es mayor al umbral se mantiene, sino es cero
                    if (hojaContable[i, j] > umbral)
                    {
                        matrizLimpia[i, j] = hojaContable[i, j];
                    }
                    else
                    {
                        matrizLimpia[i, j] = 0;
                    }
                }
            }

            // --- Salida de Resultados ---
            MostrarResultados(hojaContable, matrizLimpia, filas, columnas, umbral);
        }

        static void MostrarResultados(double[,] original, double[,] limpia, int f, int c, double u)
        {
            Console.WriteLine("\n--- Matriz Original ---");
            ImprimirMatriz(original, f, c);

            Console.WriteLine($"\n--- Matriz Filtrada (Valores > {u}) ---");
            ImprimirMatriz(limpia, f, c);

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Limpieza de ruido completada con éxito.");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void ImprimirMatriz(double[,] m, int filas, int columnas)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(m[i, j].ToString("F2") + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
