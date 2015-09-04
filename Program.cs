using System;
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
             nodesTree matrix_tree = new nodesTree();
            do
            {
                option = menu();
                switch (option)
                {
                    case 1:
                        // Ingresa el original
                        setNumbers(matrix_tree, true);
                        origen = true;
                        option = 10;
                        break;
                    case 2:
                        // Ingresa meta
                        setNumbers(matrix_tree, false);
                        destino = true;
                        option = 10;
                        break;
                    case 3:
                        if (!destino && !origen)
                            Console.WriteLine("\n\tNo haz marcado un estado inicial ni uno final.");
                        if (!destino && origen)
                            Console.WriteLine("\n\tNo haz marcado un estado final.");
                        if (destino && !origen)
                            Console.WriteLine("\n\tNo haz marcado un estado inicial.");
                        if (destino && origen)
                            matrix_tree.printRootGoal();
                        Console.ReadLine();
                        option = 10;
                        break;
                    case 4:
                        // Cantidad de pasos
                        option = 10;
                        break;
                    case 5:

                        //Salir
                        Console.WriteLine("\t ... Haz elegido salir ...");
                        Console.ReadLine();
                        option = 0;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadLine();
                        option = 10;
                        break;
                }
            } while (option == 10);
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("\n\tOperaciones");
            Console.WriteLine("\t  1.- Ingresar original");
            Console.WriteLine("\t  2.- Ingresar meta");
            Console.WriteLine("\t  3.- Mostrar origen y destino");
            Console.WriteLine("\t  4.- Cantidad de pasos para llegar a meta");
            Console.WriteLine("\t  5.- Salir");
            Console.Write("\n\t  Opcion: ");
            return int.Parse(Console.ReadLine());
        }

        static void setNumbers(nodesTree tree, bool root)
        {
            int[] n = new int[16];

            Console.WriteLine("\n\tA  B  C  D");
            Console.WriteLine(  "\tE  F  G  H");
            Console.WriteLine(  "\tI  J  K  L");
            Console.WriteLine(  "\tM  N  O  P\n");

            Console.WriteLine("El valor 0 es tomado como EL ELEMENTO VACIO");
            Console.WriteLine("Inserta las letras:");

            char[] letras = {'A', 'B', 'C', 'D','E', 'F', 'G', 'H',
                            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P'};

            for (int i = 0; i < letras.Count(); i++)
            {
                if (i % 4 == 0)
                    Console.Write("\n");
                Console.Write(letras[i]+": ");
                n[i] = int.Parse(Console.ReadLine());
            }

            if (root)
                tree.setRoot(n[0], n[1], n[2], n[3],
                    n[4], n[5], n[6], n[7], n[8], n[9],
                    n[10], n[11], n[12], n[13], n[14],
                    n[15]);
            else
                tree.setGoal(  n[0], n[1], n[2], n[3],
                    n [4], n [5], n [6], n [7], n [8], n [9],
                    n[10], n[11], n[12], n[13], n[14], n[15]);
        }
    }
}
