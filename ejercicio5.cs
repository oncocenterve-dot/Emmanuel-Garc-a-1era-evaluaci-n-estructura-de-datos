using System;
using System.Collections.Generic;

namespace SistemaInventario
{
    /// <summary>
    /// Algoritmo de Simulación de Stock para auditoría de almacén.
    /// Procesa ventas contra inventario y detecta productos en estado crítico.
    /// </summary>
    class SimulacionStock
    {
        static void Main(string[] args)
        {
            // --- Declaración de variables y tipos de datos ---
            int n;
            
            Console.WriteLine("===== SISTEMA DE CONTROL DE STOCK Y ALERTAS =====");
            Console.Write("Ingrese la cantidad de productos en el inventario: ");
            
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Error: Ingrese una cantidad válida.");
                return;
            }

            // Vector 1: Inventario Inicial
            int[] inventarioActual = new int[n];
            // Vector 2: Ventas del día
            int[] ventasDelDia = new int[n];

            // --- Captura de datos de Inventario ---
            Console.WriteLine("\n--- Registro de Stock Inicial ---");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Stock del producto {i}: ");
                inventarioActual[i] = int.Parse(Console.ReadLine());
            }

            // --- Captura de datos de Ventas ---
            Console.WriteLine("\n--- Registro de Ventas del Día ---");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ventas realizadas del producto {i}: ");
                ventasDelDia[i] = int.Parse(Console.ReadLine());
            }

            // --- Procesamiento y Generación de Alertas (Vector 3) ---
            // Usamos una lista para almacenar los índices de productos críticos
            List<int> alertasIndices = new List<int>();

            Console.WriteLine("\nCalculando balance final...");
            for (int i = 0; i < n; i++)
            {
                // Restamos las ventas al inventario
                inventarioActual[i] = inventarioActual[i] - ventasDelDia[i];

                // Verificamos si el saldo es cero o negativo
                if (inventarioActual[i] <= 0)
                {
                    alertasIndices.Add(i); // Guardamos el índice en el tercer vector/lista
                }
            }

            // --- Procedimiento de Salida de Reporte ---
            MostrarReporteCritico(inventarioActual, alertasIndices.ToArray());
        }

        /// <summary>
        /// Genera el reporte final resaltando los productos con falta de stock.
        /// </summary>
        static void MostrarReporteCritico(int[] stockFinal, int[] indicesAlertas)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("       REPORTE DE ESTADO CRÍTICO        ");
            Console.WriteLine("========================================");

            if (indicesAlertas.Length == 0)
            {
                Console.WriteLine("Estado: Stock saludable en todos los productos.");
            }
            else
            {
                Console.WriteLine("ALERTA: Los siguientes productos requieren reposición:");
                foreach (int indice in indicesAlertas)
                {
                    Console.WriteLine($"- Producto ID {indice}: Saldo actual ({stockFinal[indice]})");
                }
            }
            
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Simulación finalizada. Presione cualquier tecla.");
            Console.ReadKey();
        }
    }
}
