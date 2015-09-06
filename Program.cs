using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_Inteligentes
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool origen = false, destino = false;
            BAmplitud busqueda_amplitud = new BAmplitud();
            matrixState matrix_origin = new matrixState(),
                        matrix_goal   = new matrixState();
            do
            {
                option = menu();
                switch (option)
                {
                    case 1:
                        // Ingresa el original
                        matrix_origin = new matrixState(0, 1, 2, 3, 4, 5, 6, 7, 8);
                        busqueda_amplitud.setOrigin(matrix_origin);
                        origen = true;
                        break;
                    case 2:
                        // Ingresa meta
                        matrix_goal = new matrixState(1, 2, 0, 3, 4, 5, 6, 7, 8);
                        busqueda_amplitud.setDestiny(matrix_goal);
                        destino = true;                        
                        break;
                    case 3:
                        // Mostrar origen y destino
                        if (origen)
                        {
                            Console.WriteLine("\n\tOrigen:");
                            matrix_origin.printMatrix();
                        }
                        if (destino)
                        {
                            Console.WriteLine("\n\tDestino:");
                            matrix_goal.printMatrix();
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        // Solucion
                        if (origen && destino)
                        {
                            Console.WriteLine("\n\n\t   Busqueda por amplitud");
                            busqueda_amplitud.calculate_steps(20);
                            matrixState auxiliar = new matrixState();
                            matrix_origin.setValues(auxiliar);
                            busqueda_amplitud.goTroughtMovements(auxiliar, busqueda_amplitud.solucion(), true);
                            Console.WriteLine("\n\n\tCantidad optima de movimientos: " +
                                busqueda_amplitud.solucion().Count);
                            Console.WriteLine("\n");
                        }
                        else 
                        {
                            if (!origen)
                                Console.WriteLine("\n  No se ha establecido origen");
                            if (!destino)
                                Console.WriteLine("\n  No se ha establecido destino");
                        }
                        Console.ReadLine();
                        break;                       
                    case 7:
                        //Salir
                        Console.WriteLine("\n\n\t ... Haz elegido salir ...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadLine();
                        break;
                }
            } while (option != 7);
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("\n\tOperaciones");
            Console.WriteLine("\t  1.- Ingresar original");
            Console.WriteLine("\t  2.- Ingresar meta");
            Console.WriteLine("\t  3.- Mostrar origen y destino");
            Console.WriteLine("\t  4.- Solucion - busqueda amplitud");
            Console.WriteLine("\t  5.- Solucion - busqueda profundidad");
            Console.WriteLine("\t  6.- Solucion - busqueda A*");
            Console.WriteLine("\t  7.- Salir");
            Console.Write("\n\t  Opcion: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch 
            {
                return 0;
            }
        }
    }
}
