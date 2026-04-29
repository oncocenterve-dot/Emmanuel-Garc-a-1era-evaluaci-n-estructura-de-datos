using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmosTemperatura
{
    /// <summary>
    /// Clase principal para el análisis estadístico de desviaciones térmicas.
    /// Desarrollado para el cálculo de errores residuales en vectores.
    /// </summary>
    class ProgramaAnalisis
    {
        static void Main(string[] args)
        {
            // Declaración de variables iniciales según estándares de tipado
            int cantidadElementos;
            double sumaAcumulada = 0;
            double promedioCalculado;

            Console.WriteLine("----- SISTEMA DE ANÁLISIS DE DESVIACIÓN TÉRMICA -----");
            Console.Write("Indique el número de temperaturas a evaluar: ");
            
            // Validación de entrada para asegurar un entero positivo
            if (!int.TryParse(Console.ReadLine(), out cantidadElementos) || cantidadElementos <= 0)
            {
                Console.WriteLine("Error: La cantidad debe ser un número entero mayor a cero.");
                return;
            }

            // Definición del vector principal para almacenar los datos de entrada
            double[] vectorTemperaturas = new double[cantidadElementos];

            // Proceso de lectura de datos y acumulación para el promedio
            for (int i = 0; i < cantidadElementos; i++)
            {
                Console.Write($"Ingrese el valor de la temperatura {i + 1}: ");
                vectorTemperaturas[i] = Convert.ToDouble(Console.ReadLine());
                sumaAcumulada += vectorTemperaturas[i];
            }

            // Cálculo de la media aritmética (promedio)
            promedioCalculado = sumaAcumulada / cantidadElementos;

            // Declaración del segundo vector para almacenar el error residual
            double[] vectorDesviaciones = new double[cantidadElementos];

            // Algoritmo para calcular la diferencia de cada elemento respecto al promedio
            for (int i = 0; i < cantidadElementos; i++)
            {
                // Error residual = Valor observado - Promedio
                vectorDesviaciones[i] = vectorTemperaturas[i] - promedioCalculado;
            }

            // Llamada al procedimiento de salida de datos
            ImprimirReporte(promedioCalculado, vectorTemperaturas, vectorDesviaciones);
        }

        /// <summary>
        /// Procedimiento encargado de la representación tabular de los resultados.
        /// </summary>
        /// <param name="promedio">El promedio calculado de las muestras.</param>
        /// <param name="datos">El vector de datos originales.</param>
        /// <param name="errores">El vector de errores residuales calculados.</param>
        static void ImprimirReporte(double promedio, double[] datos, double[] errores)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("         REPORTE DE RESULTADOS          ");
            Console.WriteLine("========================================");
            Console.WriteLine($"Promedio General: {promedio:F2}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Muestra | Valor Original | Desviación");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < datos.Length; i++)
            {
                // Se aplica formato de dos decimales para mayor orden visual
                Console.WriteLine($"{i + 1,7} | {datos[i],14:F2} | {errores[i],10:F2}");
            }
            
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Proceso finalizado. Presione cualquier tecla.");
            Console.ReadKey();
        }
    }
}
