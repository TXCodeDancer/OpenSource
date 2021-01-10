using QuikGraph;
using QuikGraph.Algorithms.TSP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.TravelingSalesmanProblem
{
    internal class tsp
    {
        public BidirectionalGraph<string, EquatableEdge<string>> Graph { get; } = new BidirectionalGraph<string, EquatableEdge<string>>();

        private readonly Dictionary<EquatableEdge<string>, double> _weightsDict = new Dictionary<EquatableEdge<string>, double>();

        public tsp AddVertex(string vertex)
        {
            Graph.AddVertex(vertex);
            return this;
        }

        public tsp AddVertex(int vertex)
        {
            Graph.AddVertex(vertex.ToString());
            return this;
        }

        public tsp AddUndirectedEdge(string source, string target, double weight)
        {
            AddDirectedEdge(source, target, weight);
            AddDirectedEdge(target, source, weight);
            return this;
        }

        public tsp AddUndirectedEdge(int source, int target, double weight)
        {
            return AddUndirectedEdge(source.ToString(), target.ToString(), weight);
        }

        public tsp AddDirectedEdge(string source, string target, double weight)
        {
            var edge = new EquatableEdge<string>(source, target);
            if (!_weightsDict.ContainsKey(edge))
            {
                Graph.AddEdge(edge);
                _weightsDict.Add(edge, weight);
            }

            return this;
        }

        public tsp AddDirectedEdge(int source, int target, double weight)
        {
            return AddDirectedEdge(source.ToString(), target.ToString(), weight);
        }

        public Func<EquatableEdge<string>, double> GetWeightsFunc()
        {
            return edge => _weightsDict[edge];
        }
    }

    internal class results
    {
        public BidirectionalGraph<string, TaggedEdge<string, string>> Graph { get; } = new BidirectionalGraph<string, TaggedEdge<string, string>>();

        private readonly Dictionary<TaggedEdge<string, string>, double> _weightsDict = new Dictionary<TaggedEdge<string, string>, double>();

        public results AddVertex(string vertex)
        {
            Graph.AddVertex(vertex);
            return this;
        }

        public results AddVertex(int vertex)
        {
            Graph.AddVertex(vertex.ToString());
            return this;
        }

        public results AddUndirectedEdge(string source, string target, double weight)
        {
            AddDirectedEdge(source, target, weight);
            AddDirectedEdge(target, source, weight);
            return this;
        }

        public results AddUndirectedEdge(int source, int target, double weight)
        {
            return AddUndirectedEdge(source.ToString(), target.ToString(), weight);
        }

        public results AddDirectedEdge(string source, string target, double weight)
        {
            var edge = new TaggedEdge<string, string>(source, target, weight.ToString());
            if (!_weightsDict.ContainsKey(edge))
            {
                Graph.AddEdge(edge);
                _weightsDict.Add(edge, weight);
            }

            return this;
        }

        public results AddDirectedEdge(int source, int target, double weight)
        {
            return AddDirectedEdge(source.ToString(), target.ToString(), weight);
        }

        public Func<TaggedEdge<string, string>, double> GetWeightsFunc()
        {
            return edge => _weightsDict[edge];
        }
    }

    public static class TravelingSalesmanProblem
    {
        public static double GetCost(AdjacencyGraph<int, Edge<int>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddDirectedEdge(e.Source, e.Target, 1.0);
            }

            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, tsp.GetWeightsFunc());

            algorithm.Compute();
            return algorithm.BestCost;
        }

        public static double GetCost(AdjacencyGraph<string, TaggedEdge<string, string>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddDirectedEdge(e.Source, e.Target, double.Parse(e.Tag));
            }

            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, tsp.GetWeightsFunc());

            algorithm.Compute();
            return algorithm.BestCost;
        }

        public static double GetCost(UndirectedGraph<int, Edge<int>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddUndirectedEdge(e.Source, e.Target, 1.0);
            }

            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, tsp.GetWeightsFunc());

            algorithm.Compute();
            return algorithm.BestCost;
        }

        public static double GetCost(UndirectedGraph<string, TaggedEdge<string, string>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddUndirectedEdge(e.Source, e.Target, double.Parse(e.Tag));
            }

            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, tsp.GetWeightsFunc());

            algorithm.Compute();
            return algorithm.BestCost;
        }

        public static BidirectionalGraph<string, EquatableEdge<string>> GetPath(AdjacencyGraph<int, Edge<int>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddDirectedEdge(e.Source, e.Target, 1.0);
            }

            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, tsp.GetWeightsFunc());

            algorithm.Compute();
            return algorithm.ResultPath;
        }

        public static BidirectionalGraph<string, TaggedEdge<string, string>> GetPath(AdjacencyGraph<string, TaggedEdge<string, string>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddDirectedEdge(e.Source, e.Target, double.Parse(e.Tag));
            }

            var weightFunc = tsp.GetWeightsFunc();
            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, weightFunc);

            algorithm.Compute();

            var path = algorithm.ResultPath;
            if (path != null)
            {
                var results = new results();
                foreach (var v in path.Vertices)
                {
                    results.AddVertex(v);
                }
                foreach (var e in path.Edges)
                {
                    results.AddDirectedEdge(e.Source, e.Target, weightFunc(e));
                }
                return results.Graph;
            }
            else
                return null;
        }

        public static BidirectionalGraph<string, EquatableEdge<string>> GetPath(UndirectedGraph<int, Edge<int>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddUndirectedEdge(e.Source, e.Target, 1.0);
            }

            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, tsp.GetWeightsFunc());

            algorithm.Compute();
            return algorithm.ResultPath;
        }

        public static BidirectionalGraph<string, TaggedEdge<string, string>> GetPath(UndirectedGraph<string, TaggedEdge<string, string>> graph)
        {
            var tsp = new tsp();
            foreach (var v in graph.Vertices)
            {
                tsp.AddVertex(v);
            }
            foreach (var e in graph.Edges)
            {
                tsp.AddUndirectedEdge(e.Source, e.Target, double.Parse(e.Tag));
            }

            var weightFunc = tsp.GetWeightsFunc();
            var algorithm = new TSP<string, EquatableEdge<string>, BidirectionalGraph<string, EquatableEdge<string>>>(tsp.Graph, weightFunc);

            algorithm.Compute();

            var path = algorithm.ResultPath;
            if (path != null)
            {
                var results = new results();
                foreach (var v in path.Vertices)
                {
                    results.AddVertex(v);
                }
                foreach (var e in path.Edges)
                {
                    results.AddDirectedEdge(e.Source, e.Target, weightFunc(e));
                }
                return results.Graph;
            }
            else
                return null;
        }
    }
}
