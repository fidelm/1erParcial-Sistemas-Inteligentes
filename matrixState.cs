using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_Inteligentes
{
    class matrixState {

        private int depth;
        public int[,] currentState;

        public matrixState(int n0, int n1, int n2,
            int n3, int n4, int n5, int n6, int n7,
            int n8, int n9, int n10, int n11, int n12,
            int n13, int n14, int n15)
        {
            currentState = new int[,]
            {
                {n0,  n1,  n2,  n3 },
                {n4,  n5,  n6,  n7 },
                {n8,  n9,  n10, n11},
                {n12, n13, n14, n15}
            };
        }

        public void printMatrix()
        { 
            for(int i = 0; i< 4; i++)
            {
                Console.Write("\n\t");
                for(int j = 0; j<4; j++)
                {
                    int n = currentState[i,j];
                    if (n != 0)
                    {
                        Console.Write(n);
                        if (j != 3)
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
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (currentState[i, j] != other.currentState[i, j])
                        return false;
            return true;
        }
    }
}
