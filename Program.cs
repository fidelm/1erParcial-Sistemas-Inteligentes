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
            nodesTree matrix_tree = new nodesTree();
            do
            {
                option = menu();
                switch (option)
                {
                    case 1:
                        // Ingresa el original
                        //setNumbers(matrix_tree, true);
                        matrix_tree.setRoot(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                        origen = true;
                        option = 10;
                        break;
                    case 2:
                        // Ingresa meta
                        //setNumbers(matrix_tree, false);
                        matrix_tree.setGoal(1, 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                        destino = true;
                        option = 10;
                        break;
                    case 3:
                        if (validacion(destino, origen))
                            matrix_tree.printRootGoal();
                        Console.ReadLine();
                        option = 10;
                        break;
                    case 4:
                        // Solucion
                        if (validacion(destino, origen))
                        {
                            matrixState solucion = new matrixState();
                            solucion = matrix_solution(matrix_tree.root, matrix_tree.goal);
                            printSolution(solucion, matrix_tree.goal);
                        }
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
            Console.WriteLine("\t  4.- Solucion");
            Console.WriteLine("\t  5.- Salir");
            Console.Write("\n\t  Opcion: ");
            return int.Parse(Console.ReadLine());
        }

        static void setNumbers(nodesTree tree, bool root)
        {
            int[] n = new int[16];

            Console.WriteLine("\n\tA  B  C  D");
            Console.WriteLine("\tE  F  G  H");
            Console.WriteLine("\tI  J  K  L");
            Console.WriteLine("\tM  N  O  P\n");

            Console.WriteLine("El valor 0 es tomado como EL ELEMENTO VACIO");
            Console.WriteLine("Inserta las letras:");

            char[] letras = {'A', 'B', 'C', 'D','E', 'F', 'G', 'H',
                            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P'};

            for (int i = 0; i < letras.Count(); i++)
            {
                if (i % 4 == 0)
                    Console.Write("\n");
                Console.Write(letras[i] + ": ");
                n[i] = int.Parse(Console.ReadLine());
            }

            if (root)
                tree.setRoot(n[0], n[1], n[2], n[3],
                    n[4], n[5], n[6], n[7], n[8], n[9],
                    n[10], n[11], n[12], n[13], n[14],
                    n[15]);
            else
                tree.setGoal(n[0], n[1], n[2], n[3],
                    n[4], n[5], n[6], n[7], n[8], n[9],
                    n[10], n[11], n[12], n[13], n[14], n[15]);
        }

        static bool validacion(bool destino, bool origen)
        {
            if (!destino && !origen)
                Console.WriteLine("\n\tNo haz marcado un estado inicial ni uno final.");
            if (!destino && origen)
                Console.WriteLine("\n\tNo haz marcado un estado final.");
            if (destino && !origen)
                Console.WriteLine("\n\tNo haz marcado un estado inicial.");
            if (destino && origen)
                return true;
            return false;
        }

        static matrixState matrix_solution(matrixState root, matrixState goal)
        {
            Queue cola = new Queue();
            bool encontrado = false;
            // agregar elemento cola.Enqueue(elemento)
            // retirar elemento de la cola cola.Dequeue();
            matrixState currentState = new matrixState();
            root.setValues(currentState);
            cola.Enqueue(currentState);

            while (!encontrado)
            {
                int x, y;
                bool up, down, right, left;

                x = y = 0;
                up = down = right = left = true;

                // Detect which element is the null one.
                for (int raw = 0; raw < 4; raw++)
                    for (int column = 0; column < 4; column++)
                        if (currentState.currentNumberStates[raw, column] == 0)
                        {
                            x = column; y = raw;
                            break;
                        }

                // Validate movements
                if (x == 0) left = false;
                if (x == 3) right = false;
                if (y == 0) up = false;
                if (y == 3) down = false;

                if (up)
                {
                    matrixState newState = specific_movement(currentState, 0);
                    newState.previosSteps.Add(0);
                    newState.setDepth(newState.getDepth() + 1);
                    cola.Enqueue(newState);
                }
                if (down)
                {
                    matrixState newState = specific_movement(currentState, 1);
                    newState.previosSteps.Add(1);
                    newState.setDepth(newState.getDepth() + 1);
                    cola.Enqueue(newState);
                }
                if (left)
                {
                    matrixState newState = specific_movement(currentState, 2);
                    newState.previosSteps.Add(2);
                    newState.setDepth(newState.getDepth() + 1);
                    cola.Enqueue(newState);
                }
                if (right)
                {
                    matrixState newState = specific_movement(currentState, 3);
                    newState.previosSteps.Add(3);
                    newState.setDepth(newState.getDepth() + 1);
                    cola.Enqueue(newState);
                }
                currentState = (matrixState)cola.Dequeue();
                encontrado = currentState.comparison(goal);
            }
            return currentState;
        }

        static void printSolution(matrixState m_solution, matrixState root)
        {
            ArrayList steps = m_solution.previosSteps;
            matrixState current = new matrixState();
            root.setValues(current);
            current.printMatrix();
            Console.WriteLine("\n");
            foreach (int element in steps)
            {
                /*
                Console.WriteLine(element);
                current = specific_movement(current, element);
                current.printMatrix();
                Console.WriteLine("\n");
                Console.ReadLine();
                 * */
                Console.WriteLine(element);
            }
            Console.ReadLine();

        }

        static matrixState specific_movement(matrixState currentState, int movement)
        {
            matrixState newState = new matrixState();
            currentState.setValues(newState);
            int x = 0, y = 0;
            // Detect which element is the null one.
            for (int raw = 0; raw < 4; raw++)
                for (int column = 0; column < 4; column++)
                    if (currentState.currentNumberStates[raw, column] == 0)
                    {
                        x = column; y = raw;
                        break;
                    }
            switch (movement)
            {
                case 0:
                    // Up
                    newState.currentNumberStates[y, x] = newState.currentNumberStates[y - 1, x];
                    newState.currentNumberStates[y - 1, x] = 0;
                    break;
                case 1:
                    // Down
                    newState.currentNumberStates[y, x] = newState.currentNumberStates[y + 1, x];
                    newState.currentNumberStates[y + 1, x] = 0;
                    break;
                case 2:
                    // Left
                    newState.currentNumberStates[y, x] = newState.currentNumberStates[y, x - 1];
                    newState.currentNumberStates[y, x - 1] = 0;
                    break;
                case 3:
                    // Right
                    newState.currentNumberStates[y, x] = newState.currentNumberStates[y, x + 1];
                    newState.currentNumberStates[y, x + 1] = 0;
                    break;
                default:
                    // Invalid movement
                    break;
            }
            return newState;
        }
    }
}
