using System;
using System.Collections.Generic;

namespace AuditoriaProductos
{
    /// <summary>
    /// Algoritmo diseñado para la validación de integridad en bases de datos.
    /// Detecta códigos de productos duplicados y reporta su ubicación exacta.
    /// </summary>
    class ValidadorIntegridad
    {
        static void Main(string[] args)
        {
            // --- Declaración de variables y tipos de datos ---
            int cantidad;
            
            Console.WriteLine("===== SISTEMA DE AUDITORÍA DE PRODUCTOS =====");
            Console.Write("Ingrese la cantidad de productos a registrar: ");
            
            // Validación de entrada para el tamaño del vector
            if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Error: Ingrese un número entero válido.");
                return;
            }

            // Definición del vector de códigos (usamos string por si el código tiene letras)
            string[] codigos = new string[cantidad];

            // --- Proceso de captura de datos ---
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese el código del producto en la posición [{i}]: ");
                codigos[i] = Console.ReadLine();
            }

            // --- Algoritmo de detección de duplicados ---
            Console.WriteLine("\nIniciando escaneo de integridad...");
            bool seEncontraronDuplicados = false;

            // Comparamos cada elemento con los que le siguen en el vector
            for (int i = 0; i < codigos.Length; i++)
            {
                for (int j = i + 1; j < codigos.Length; j++)
                {
                    // Si encontramos una coincidencia exacta
                    if (codigos[i] == codigos[j])
                    {
                        Console.WriteLine($"ALERTA: Código '{codigos[i]}' duplicado en posiciones {i} y {j}.");
                        seEncontraronDuplicados = true;
                    }
                }
            }

            // --- Procedimiento de salida final ---
            FinalizarReporte(seEncontraronDuplicados);
        }

        /// <summary>
        /// Muestra el resultado final de la auditoría.
        /// </summary>
        static void FinalizarReporte(bool huboErrores)
        {
            Console.WriteLine("---------------------------------------------");
            if (huboErrores)
            {
                Console.WriteLine("ESTADO: Se detectaron inconsistencias en el vector.");
            }
            else
            {
                Console.WriteLine("ESTADO: Integridad verificada. No hay duplicados.");
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Presione cualquier tecla para cerrar el reporte.");
            Console.ReadKey();
        }
    }
}
