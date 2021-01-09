using QuikGraph;
using QuikGraph.Algorithms.TSP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.TravelingSalesmanProblem
{
    public static class TravelingSalesmanProblem
    {
        public static (double, string) Get(BidirectionalGraph<int, EquatableEdge<int>> graph)
        {
            Func<EquatableEdge<int>, double> Weights = e => 1.0;
            var algorithm = new TSP<int, EquatableEdge<int>, BidirectionalGraph<int, EquatableEdge<int>>>(graph, Weights);

            try
            {
                algorithm.Compute();
                return (algorithm.BestCost, null);
            }
            catch (System.Exception ex)
            {
                return (double.PositiveInfinity, ex.Message);
            }
        }

        // Note QuickGraph edge type TaggedEquatableEdge is not currently supported by QuikGraph, using weightDict as a parameter is a workaround.
        public static (double, string) Get(BidirectionalGraph<string, EquatableEdge<string>> graph, Dictionary<EquatableEdge<string>, double> weightDict)
        {
            Func<EquatableEdge<string>, double> Weights = e => weightDict[e];
            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(graph, Weights);

            try
            {
                algorithm.Compute();
                return (algorithm.BestCost, null);
            }
            catch (System.Exception ex)
            {
                return (double.PositiveInfinity, ex.Message);
            }
        }
    }
}
