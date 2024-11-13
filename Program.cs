using System;
using System.Collections.Generic;

namespace RegresionLinealBenetton
{
    class Program
    {
        static void Main(string[] args)

        // X = 1, 2, 3, 4, 5, 6, 7, 8, 9
        // Y = 2, 4, 6, 8, 10, 12, 14, 16, 18


        {
            // DataSet
            List<double> publicidad = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // X 651, 762, 856, 1063, 1190, 1298, 1421, 1440, 1518
            List<double> ventas = new List<double> { 2, 4, 6, 8, 10, 12, 14, 16, 18 }; // Y 23, 26, 30, 34, 43, 48, 52, 57, 58

            // Calcular los valores óptimos de Beta_0 y Beta_1
            (double beta0, double beta1) = CalcularCoeficientes(publicidad, ventas);
            
            // Ecuación de regresión
            Console.WriteLine($"Ecuación de regresión: y = {beta0:F2} + {beta1:F2}x");

            // Ingresar el valor de publicidad
            Console.Write("Ingrese el valor de publicidad para predecir las ventas: ");
            if (double.TryParse(Console.ReadLine(), out double publicidadIngresada))
            {
                double prediccionVentas = beta0 + beta1 * publicidadIngresada;
                Console.WriteLine($"Ventas estimadas para publicidad de {publicidadIngresada}: {prediccionVentas:F2}");
            }
            else
            {
                Console.WriteLine("Valor ingresado no válido.");
            }
        }

        static (double, double) CalcularCoeficientes(List<double> x, List<double> y)
        {
            int n = x.Count;
            double sumaX = 0, sumaY = 0, sumaXY = 0, sumaX2 = 0;

            for (int i = 0; i < n; i++)
            {
                sumaX += x[i];
                sumaY += y[i];
                sumaXY += x[i] * y[i];
                sumaX2 += x[i] * x[i];
            }

            double beta1 = (n * sumaXY - sumaX * sumaY) / (n * sumaX2 - sumaX * sumaX);
            double beta0 = (sumaY - beta1 * sumaX) / n;

            return (beta0, beta1);
        }
    }
}
