//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using Algorithms.ConnectedComponents;
using Algorithms.MaximumFlow;
using Algorithms.MinimumSpanningTree;
using Algorithms.Observers;
using QuikGraph;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.Linq;
using Visualizers;

namespace Main
{
    public class Graph
    {
        public static bool hasTags(List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;
            return hasTaggedEdges;
        }

        public static AdjacencyGraph<int, Edge<int>> CreateDirectedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<int, Edge<int>>();
            List<int> intNodes = new List<int>();
            foreach (var v in nodes)
            {
                intNodes.Add(int.Parse(v));
            }

            g.AddVertexRange(intNodes);
            foreach (var e in edges)
            {
                g.AddEdge(new Edge<int>(int.Parse(e[0]), int.Parse(e[1])));
            }

            return g;
        }

        public static AdjacencyGraph<string, TaggedEdge<string, string>> CreateDirectedTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }

        public static AdjacencyGraph<string, EquatableTaggedEdge<string, double>> CreateDirectedEquatableTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, EquatableTaggedEdge<string, double>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new EquatableTaggedEdge<string, double>(e[0], e[1], double.Parse(e[2])));
            }

            return g;
        }

        public static UndirectedGraph<int, Edge<int>> CreateUndirectedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new UndirectedGraph<int, Edge<int>>();
            List<int> intNodes = new List<int>();
            foreach (var v in nodes)
            {
                intNodes.Add(int.Parse(v));
            }

            g.AddVertexRange(intNodes);
            foreach (var e in edges)
            {
                g.AddEdge(new Edge<int>(int.Parse(e[0]), int.Parse(e[1])));
            }

            return g;
        }

        public static UndirectedGraph<string, TaggedEdge<string, string>> CreateUndirectedTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new UndirectedGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }
    }

    public class Program
    {
        public static void GraphVisualizerHelper(List<string> nodes, List<List<string>> edges, string filepath)
        {
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Box;
                Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Circle;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.dot);
            }
        }

        public static List<string> WeaklyConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> EdmondsKarpMaxFlowHelper(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateDirectedEquatableTaggedGraph(nodes, edges);
                var ans = EdmondsKarpMaxFlow.Get(g, source, sink);
                results.Add($"{ans}");
            }
            return results;
        }

        public static List<string> EdmondsKarpMaxFlowPredecessorsHelper(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateDirectedEquatableTaggedGraph(nodes, edges);
                var ans = EdmondsKarpMaxFlow.GetPredecessors(g, source, sink);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> EdmondsKarpMaxFlowResidualCapacitiesHelper(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateDirectedEquatableTaggedGraph(nodes, edges);
                var ans = EdmondsKarpMaxFlow.GetResidualCapacities(g, source, sink);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> StronglyConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = StronglyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = StronglyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> StronglyConnectedComponentsGraphHelper(List<string> nodes, List<List<string>> edges, string filepath)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = StronglyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{filepath}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Box;
                    Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{filepath}_{i}", ImageLayout.circo);
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = StronglyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{filepath}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Circle;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{filepath}_{i}", ImageLayout.dot);
                }
            }
            return results;
        }

        public static List<string> WeaklyConnectedComponentsGraphHelper(List<string> nodes, List<List<string>> edges, string outputFile)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{outputFile}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Box;
                    Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{outputFile}_{i}", ImageLayout.circo);
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{outputFile}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Circle;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{outputFile}_{i}", ImageLayout.dot);
                }
            }
            return results;
        }

        public static List<string> IncrementalConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = IncrementalConnectedComponents.Get(g);
                var key = ans.Key;
                results.Add($"Components {key}:");
                var dict = ans.Value;
                foreach (var d in dict)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = IncrementalConnectedComponents.Get(g);
                var key = ans.Key;
                results.Add($"Components {key}:");
                var dict = ans.Value;
                foreach (var d in dict)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> ConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = ConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = ConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> EdgeObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> EdgePredecessorPathObserverHelper(List<string> nodes, List<List<string>> edges, string v)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.GetAllPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Edge Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.GetAllPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Edge Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> EdgePredecessorObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexDistanceObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedVertexDistanceObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedVertexPredecessorObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexPredecessorObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedVertexPredecessorPathObserverHelper(List<string> nodes, List<List<string>> edges, string v)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.GetPath(g, v);
                foreach (var n in dfs)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.GetPath(g, int.Parse(v));
                foreach (var n in dfs)
                {
                    results.Add(n.ToString());
                }
            }
            return results;
        }

        public static List<string> VertexPredecessorPathObserverHelper(List<string> nodes, List<List<string>> edges, string v)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.GetAllPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Edge Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.GetAllPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Edge Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> VertexDiscoverTimeStampObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexFinishTimeStampObserverHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> KruskalMinimumSpanningTreeEdgeHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetEdges(g);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetEdges(g);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            return results;
        }

        public static List<string> KruskalMinimumSpanningTreeCostHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetCost(g);
                results.Add(ans.ToString());
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetCost(g);
                results.Add(ans.ToString());
            }
            return results;
        }

        private static void Main()
        {
            string filepath = @"ManualInput";
            var nodes = Console.ReadLine().Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"
            List<List<string>> edges = new List<List<string>>();
            string edge;
            while ((edge = Console.ReadLine()) != null && edge != "")
            {
                edges.Add(edge.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            GraphVisualizerHelper(nodes, edges, filepath);
        }
    }
}