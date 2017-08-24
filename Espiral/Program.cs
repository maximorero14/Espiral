using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Espiral
{
    /*
     * Maximiliano Alexis Morero
     * 24/07/06
     * http://maximorero.herokuapp.com/blog/espiral
     * 
     */

    class Program
    {
        /*
            Funcion de numeros primos
        */
        static int esPrimo(int number)
        {
            if (number <= 3 && number > 1)
                return 1;
            else if (number % 2 == 0 || number % 3 == 0)
                return 0;
            else
            {
                int i;
                for (i = 5; i * i <= number; i += 6)
                {
                    if (number % i == 0 || number % (i + 2) == 0)
                        return 0;
                }
                return 1;
            }
        }


        static void Main(string[] args)
        {

            int ultimoNumeroDiegonal = 1;

            double porcentaje = 100.0f;
            /*Comenzamos con una matriz de orden 3*/
            int orden = 3;

            int vuelta = 2;
            int cantidadPrimos = 0;

            /*Como empezamos con la matriz de orden 3 la cantidad de numeros en la diagonal son 5*/
            int cantidadNumerosDiagonal = 5;

            while (porcentaje > 10.0)
            {
                /*Creamos los 4 nuevos numeros de la nueva orden*/
                int[] diagonalNueva = new int[4];
                diagonalNueva[0] = vuelta;
                diagonalNueva[1] = vuelta;
                diagonalNueva[2] = vuelta;
                diagonalNueva[3] = vuelta;
                vuelta += 2;
                for (int j = 0; j < 4; j++)
                {
                    diagonalNueva[j] += ultimoNumeroDiegonal;
                    ultimoNumeroDiegonal = diagonalNueva[j];
                    if (esPrimo(diagonalNueva[j]) == 1)
                    {
                        cantidadPrimos++;
                    }
                }
                /*Calculamos el neuvo pocentaje de primos*/
                porcentaje = ((double)cantidadPrimos / (double)cantidadNumerosDiagonal) * 100.0;

                /*Preparamos las variables par auna nueva orden*/
                cantidadNumerosDiagonal += 4;
                orden += 2;
            }

            Console.WriteLine("CANTIDAD PRIMOS: " + cantidadPrimos);
            Console.WriteLine("CANTIDAD DIAGONAL: " + (cantidadNumerosDiagonal));
            Console.WriteLine("PORCENTAJE: " + porcentaje);
            Console.WriteLine();
            Console.WriteLine("-*********************************************-");
            Console.WriteLine("ORDEN: " + (orden));
            Console.WriteLine("-*********************************************-");
            Console.ReadLine();
        }
    }
}
