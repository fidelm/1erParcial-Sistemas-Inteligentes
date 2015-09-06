using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_Inteligentes
{
    class matrixState
    {

        private int depth;
        public int[,] currentState;
        public ArrayList previosSteps;
        /// <summary>
        /// Steps:
        ///     0 Up
        ///     1 Down
        ///     2 Left
        ///     3 Right
        /// </summary>


        public matrixState()
        {
            previosSteps = new ArrayList();
            depth = 0;
            currentState = new int[3, 3];
        }

        public matrixState(int n0, int n1, int n2, int n3, 
            int n4, int n5, int n6, int n7, int n8)
        {
            currentState = new int[,]
            {
                {n0,  n1,  n2},
                {n3,  n4,  n5},
                {n6,  n7,  n8}
            };

            previosSteps = new ArrayList();
            depth = 0;
        }

        public void printMatrix()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n\t");
                for (int j = 0; j < 3; j++)
                {
                    int n = currentState[i, j];
                    if (n != 0)
                    {
                        Console.Write(n);
                        if (j != 2)
                            Console.Write("\t");
                    }
                    else
                        Console.Write("-\t");
                }
            }
        }

        public void setDepth(int depth) { this.depth = depth; }

        public int getDepth() { return depth; }

        public bool comparison(matrixState other)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (currentState[i, j] != other.currentState[i, j])
                        return false;
            return true;
        }

        public void setValues(matrixState external)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    external.currentState[i, j] = currentState[i, j];
            external.setDepth(depth);
            external.previosSteps = previosSteps;
        }
    }
}
