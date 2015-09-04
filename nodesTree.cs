using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_Inteligentes
{
    class nodesTree
    {
        public matrixState root, goal;

        public nodesTree() {}

        public void setRoot(int n0, int n1, int n2, int n3, 
            int n4, int n5, int n6, int n7, int n8)
        {
           root = new matrixState(n0, n1, n2, n3, n4, n5, n6, n7, n8);
           root.setDepth(0);
        }

        public void setGoal(int n0, int n1, int n2,
            int n3, int n4, int n5, int n6, int n7,
            int n8)
        {
            goal = new matrixState(n0, n1, n2, n3, n4, n5, n6, n7, n8);
        }

        public void printRootGoal()
        {
            Console.WriteLine("Original");
            root.printMatrix();
            Console.WriteLine("\nMeta");
            goal.printMatrix();
        }
    }
}
