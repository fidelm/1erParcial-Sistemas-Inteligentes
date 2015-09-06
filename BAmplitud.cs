using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_Inteligentes.repoGit
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
                goTroughtMovements(current, currentMovements);
                if (current.comparison(goal))
                {
                    solved = true;
                    posible = true;
                    steps = currentMovements;
                }
                else 
                {
                    foreach (int movement in available_movements(current))
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
        ArrayList available_movements(matrixState ma) 
        {
            ArrayList alternatives = new ArrayList();
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    if (ma.currentNumberStates[fila, columna] == 0)
                    {
                        if (fila != 0)      alternatives.Add(2);
                        if (fila != 2)      alternatives.Add(3);
                        if (columna != 0)   alternatives.Add(0);
                        if (columna != 2)   alternatives.Add(1);
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

        void goTroughtMovements(matrixState ma, ArrayList moves)
        {
            for (int i = 0; i < moves.Count; i++)
                makeMovement(ma, (int)moves[i]);
        }

        public ArrayList solucion()
        {
            return steps;
        }
    }
}
