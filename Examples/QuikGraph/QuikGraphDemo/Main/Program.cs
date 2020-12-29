//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using Algorithms;
using QuikGraph;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.Linq;
using Visualizers;

namespace Main
{
    public class Program
    {
        public static void GraphVisualizerHelper(List<string> nodes, List<List<string>> edges, string filepath)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            if (hasTaggedEdges)
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = CreateDirectedTaggedGraph(nodes, edges);
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Box;
                Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = CreateDirectedGraph(nodes, edges);
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Circle;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.dot);
            }
        }

        public static List<string> DFSVertexRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = CreateDirectedGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> DFSEdgeRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = CreateDirectedGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> DFSEdgePredecessorPathRecorderHelper(List<string> nodes, List<List<string>> edges, string v)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
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
                var g = CreateDirectedGraph(nodes, edges);
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

        public static List<string> DFSEdgePredecessorRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = CreateDirectedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DFSVertexDistanceRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = CreateDirectedGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DFSUndirectedVertexDistanceRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DFSUndirectedVertexPredecessorHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DFSVertexPredecessorHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = CreateDirectedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DFSUndirectedVertexPredecessorPathHelper(List<string> nodes, List<List<string>> edges, string v)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.GetPath(g, v);
                foreach (var n in dfs)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.GetPath(g, int.Parse(v));
                foreach (var n in dfs)
                {
                    results.Add(n.ToString());
                }
            }
            return results;
        }

        public static List<string> DFSVertexPredecessorPathHelper(List<string> nodes, List<List<string>> edges, string v)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
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
                var g = CreateDirectedGraph(nodes, edges);
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

        public static List<string> DFSVertexDiscoverTimeStampRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = CreateDirectedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DFSVertexFinishTimeStampRecorderHelper(List<string> nodes, List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            List<string> results = new List<string>();
            if (hasTaggedEdges)
            {
                var g = CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = CreateDirectedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        private static AdjacencyGraph<int, Edge<int>> CreateDirectedGraph(List<string> nodes, List<List<string>> edges)
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

        private static AdjacencyGraph<string, TaggedEdge<string, string>> CreateDirectedTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }

        private static UndirectedGraph<int, Edge<int>> CreateUndirectedGraph(List<string> nodes, List<List<string>> edges)
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

        private static UndirectedGraph<string, TaggedEdge<string, string>> CreateUndirectedTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new UndirectedGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
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