using QuikGraph;
using QuikGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Cycles
{
    public static class EulerianCycles
    {
        public static bool IsEulerian<TVertex>(IUndirectedGraph<TVertex, UndirectedEdge<TVertex>> g)
        {
            var algorithm = new IsEulerianGraphAlgorithm<TVertex, UndirectedEdge<TVertex>>(g);
            return algorithm.IsEulerian();
        }

        public static string Get(IMutableVertexAndEdgeListGraph<int, Edge<int>> g, int root, out ICollection<Edge<int>>[] trails, out Edge<int>[] circuit)
        {
            return ComputeTrails(g, root, (s, t) => new Edge<int>(s, t), out trails, out circuit);
        }

        public static string Get(IMutableVertexAndEdgeListGraph<string, Edge<string>> g, string root, out ICollection<Edge<string>>[] trails, out Edge<string>[] circuit)
        {
            return ComputeTrails(g, root, (s, t) => new Edge<string>(s, t), out trails, out circuit);
        }

        private static string ComputeTrails<TVertex, TEdge>(
                    IMutableVertexAndEdgeListGraph<TVertex, TEdge> g,
                    TVertex root,
                    Func<TVertex, TVertex, TEdge> edgeFactory,
                     out ICollection<TEdge>[] trails,
                     out TEdge[] circuit)
                    where TEdge : IEdge<TVertex>
        {
            trails = new ICollection<TEdge>[0];
            circuit = new TEdge[0];

            int circuitCount = EulerianTrailAlgorithm<TVertex, TEdge>.ComputeEulerianPathCount(g);
            if (circuitCount == 0)
                return "No Eulerian path found.";

            var algorithm = new EulerianTrailAlgorithm<TVertex, TEdge>(g);
            algorithm.AddTemporaryEdges((s, t) => edgeFactory(s, t));

            algorithm.Compute();
            try
            {
                trails = algorithm.Trails(root).ToArray();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

            algorithm.RemoveTemporaryEdges();
            circuit = algorithm.Circuit;
            return null;
        }
    }
}
