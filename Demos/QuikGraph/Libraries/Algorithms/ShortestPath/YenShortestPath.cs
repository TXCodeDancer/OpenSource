using QuikGraph;
using QuikGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.ShortestPath
{
    public static class YenShortestPath
    {
        public static (YenShortestPathsAlgorithm<int>.SortedPath, string) Get(AdjacencyGraph<int, EquatableTaggedEdge<int, double>> graph, int root, int target)
        {
            int k = int.MaxValue;
            var algorithm = new YenShortestPathsAlgorithm<int>(graph, root, target, k);

            YenShortestPathsAlgorithm<int>.SortedPath shortest = new YenShortestPathsAlgorithm<int>.SortedPath();
            var shortestDistance = double.MaxValue;
            try
            {
                var paths = algorithm.Execute().ToArray();
                foreach (var path in paths)
                {
                    double sum = 0;
                    foreach (var e in path)
                    {
                        sum += e.Tag;
                    }
                    if (sum < shortestDistance)
                    {
                        shortest = path;
                        shortestDistance = sum;
                    }
                }
                return (shortest, null);
            }
            catch (System.Exception ex)
            {
                return (shortest, ex.Message);
            }
        }

        public static (YenShortestPathsAlgorithm<string>.SortedPath, string) Get(AdjacencyGraph<string, EquatableTaggedEdge<string, double>> graph, string root, string target)
        {
            int k = int.MaxValue;
            var algorithm = new YenShortestPathsAlgorithm<string>(graph, root, target, k);

            YenShortestPathsAlgorithm<string>.SortedPath shortest = new YenShortestPathsAlgorithm<string>.SortedPath();
            var shortestDistance = double.MaxValue;
            try
            {
                var paths = algorithm.Execute().ToArray();
                foreach (var path in paths)
                {
                    double sum = 0;
                    foreach (var e in path)
                    {
                        sum += e.Tag;
                    }
                    if (sum < shortestDistance)
                    {
                        shortest = path;
                        shortestDistance = sum;
                    }
                }
                return (shortest, null);
            }
            catch (System.Exception ex)
            {
                return (shortest, ex.Message);
            }
        }

        public static (YenShortestPathsAlgorithm<int>.SortedPath[], string) GetAll(AdjacencyGraph<int, EquatableTaggedEdge<int, double>> graph, int root, int target)
        {
            int k = int.MaxValue;
            var algorithm = new YenShortestPathsAlgorithm<int>(graph, root, target, k);
            try
            {
                var paths = algorithm.Execute().ToArray();
                return (paths, null);
            }
            catch (System.Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public static (YenShortestPathsAlgorithm<string>.SortedPath[], string) GetAll(AdjacencyGraph<string, EquatableTaggedEdge<string, double>> graph, string root, string target)
        {
            int k = int.MaxValue;
            var algorithm = new YenShortestPathsAlgorithm<string>(graph, root, target, k);
            try
            {
                var paths = algorithm.Execute().ToArray();
                return (paths, null);
            }
            catch (System.Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}