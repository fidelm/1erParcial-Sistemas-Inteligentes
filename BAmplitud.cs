using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_Inteligentes
{
    class BAmplitud
    {
        private matrixState origin, goal;
        private ArrayList steps;
        private bool solved, posible;
        public BAmplitud() {
            origin  = new matrixState();
            goal    = new matrixState();
            steps   = new ArrayList();
            solved  = false;   posible = true;
        }

        // Reference the local origin to the original location in memory
        public void setOrigin(matrixState origin)
        {
            this.origin = origin;
            solved = false;    posible = true;
        }

        // Reference the local goal to the destiny location in memory
        public void setDestiny(matrixState destiny)
        {
            destiny.setValues(goal);
            solved = false; posible = true;
        }

        public bool calculate_steps(int maxDepth)
        {
            Queue posibilidades_cola  = new Queue();
            ArrayList calculatedSteps = new ArrayList();
            matrixState current = new matrixState();

            posibilidades_cola.Enqueue(calculatedSteps);
            while(!solved)
            {
                origin.setValues(current);
                ArrayList currentMovements = (ArrayList) posibilidades_cola.Dequeue();
                
                goTroughtMovements(current, currentMovements, false);
                if (current.comparison(goal))
                {
                    solved = true;
                    posible = true;
                    steps = currentMovements;
                }
                else 
                {
                    int last = 10;
                    if (currentMovements.Count != 0)
                        last = (int)currentMovements[currentMovements.Count - 1];

                    foreach (int movement in available_movements(current, last))
                    {
                        ArrayList currentMovesPlus1 = new ArrayList();
                        copyArrays(currentMovements, currentMovesPlus1);
                        currentMovesPlus1.Add(movement);
                        posibilidades_cola.Enqueue(currentMovesPlus1);
                    }


                }
                if (currentMovements.Count > maxDepth)
                {
                    posible = false;
                    solved = true;
                }
            }
            return posible;            
        }


        /// <summary>
        /// Steps:
        ///     0 Up
        ///     1 Down
        ///     2 Left
        ///     3 Right
        /// </summary>
        ArrayList available_movements(matrixState ma, int last) 
        {
            ArrayList alternatives = new ArrayList();
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    if (ma.currentNumberStates[fila, columna] == 0)
                    {
                        // up
                        if (fila != 0 && last != 1)      alternatives.Add(0);
                        //Down
                        if (fila != 2 && last != 0)      alternatives.Add(1);
                        // Left
                        if (columna != 0 && last != 3)   alternatives.Add(2);
                        // Right
                        if (columna != 2 && last != 2)   alternatives.Add(3);
                    }
            return alternatives;
        }

        void copyArrays(ArrayList origen, ArrayList copia) 
        {
            for (int i = 0; i < origen.Count; i++)
                copia.Add(origen[i]);
        }

        void makeMovement(matrixState ma, int movement)
        {
            int raw = 0, column = 0;
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    if (ma.currentNumberStates[fila, columna] == 0)
                    {
                        raw = fila;
                        column = columna;
                    }
            switch (movement)
            {
                case 0:
                    // Up
                    ma.currentNumberStates[raw, column] = ma.currentNumberStates[raw-1, column];
                    ma.currentNumberStates[raw-1, column] = 0;
                    break;
                case 1:
                    // Down
                    ma.currentNumberStates[raw, column] = ma.currentNumberStates[raw+1, column];
                    ma.currentNumberStates[raw+1, column] = 0;
                    break;
                case 2:
                    // Left
                    ma.currentNumberStates[raw, column] = ma.currentNumberStates[raw, column-1];
                    ma.currentNumberStates[raw, column-1] = 0;
                    break;
                case 3:
                    // Right
                    ma.currentNumberStates[raw, column] = ma.currentNumberStates[raw, column+1];
                    ma.currentNumberStates[raw, column+1] = 0;
                    break;
                default:
                    // imposible
                    break;
            }
        }

        public void goTroughtMovements(matrixState ma, ArrayList moves, bool print)
        {
            if (print)
            {
                Console.WriteLine("\n");
                ma.printMatrix();
            }
            for (int i = 0; i < moves.Count; i++)
            {
                makeMovement(ma, (int)moves[i]);
                if (print)
                {
                    Console.WriteLine("\n");
                    ma.printMatrix();
                }
            }
        }

        public ArrayList solucion()
        {
            return steps;
        }
    }
}
