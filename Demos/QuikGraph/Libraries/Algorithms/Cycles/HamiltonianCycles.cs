using QuikGraph;
using QuikGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Cycles
{
    public static class HamiltonianCycles
    {
        public static bool IsHamiltonian<TVertex>(IUndirectedGraph<TVertex, UndirectedEdge<TVertex>> g)
        {
            var algorithm = new IsHamiltonianGraphAlgorithm<TVertex, UndirectedEdge<TVertex>>(g);
            return algorithm.IsHamiltonian();
        }
    }
}
