using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.TreeProblem
{
    static public class TreeProblem
    {
        public static int CountLeafAfterRemove(int []ar,int removeNode)
        {
            int []notLeafNode = new int[ar.Length];
            for(int i=1;i<ar.Length;i++)
            {
                if (ar[ar[i]] == int.MinValue)
                {
                    ar[i] = int.MinValue;
                }
                if (ar[i] == removeNode || i == removeNode)
                {
                    notLeafNode[i] = 1;
                }
                else
                {
                    notLeafNode[ar[i]] = 1;
                }
            }

            return notLeafNode.Count(x => x != 1);
        }
    }
}
