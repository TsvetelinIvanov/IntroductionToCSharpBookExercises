using Magnum.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03ShortestPathBetweenJunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> mapData = new Queue<string>(File.ReadAllLines("map.txt"));
            Dictionary<string, int> junctionsIndices;
            List<Junction> cityMap = MakeCityMap(mapData, out junctionsIndices);
            AssociateJunctionsToConnectionComponents(cityMap);
            Queue<RequestedPath> queries = GetQueries(mapData, cityMap, junctionsIndices);
            if (cityMap.Count == 0 || queries.Count == 0)
            {
                return;
            }

            Dictionary<string, Dictionary<string, PathDetails>> dijkstraQueries = CreateDijkstraQueries(queries);
            ExecuteDijkstraQueries(dijkstraQueries, cityMap, junctionsIndices);
            string result = GetResult(queries, dijkstraQueries);
            Console.WriteLine(result);
        }

        private static List<Junction> MakeCityMap(Queue<string> mapData, out Dictionary<string, int> junctionsIndices)
        {
            junctionsIndices = new Dictionary<string, int>();
            List<Junction> cityMap = new List<Junction>();
            string line = mapData.Dequeue();
            while (line != string.Empty)
            {
                string[] streetInfo = line.Split();
                AddStreet(streetInfo, cityMap, junctionsIndices);
                line = mapData.Dequeue();
            }

            return cityMap;
        }

        private static void AddStreet(string[] streetInfo, List<Junction> cityMap, Dictionary<string, int> junctionsIndices)
        {
            string firstStreetName = streetInfo[0];
            string secondStreetName = streetInfo[1];

            int firstJunctionIndex = ProcessJunctionIndex(firstStreetName, cityMap, junctionsIndices);
            int secondJunctionIndex = ProcessJunctionIndex(secondStreetName, cityMap, junctionsIndices);

            int distance = int.Parse(streetInfo[2]);
            cityMap[firstJunctionIndex].Children.Add(cityMap[secondJunctionIndex], distance);
            cityMap[secondJunctionIndex].Children.Add(cityMap[firstJunctionIndex], distance);
        }

        private static int ProcessJunctionIndex(string junctionName, List<Junction> cityMap, Dictionary<string, int> junctionsIndices)
        {
            int index;
            if (!junctionsIndices.ContainsKey(junctionName))
            {
                cityMap.Add(new Junction(junctionName));
                index = cityMap.Count - 1;
                junctionsIndices.Add(junctionName, index);
            }
            else
            {
                index = junctionsIndices[junctionName];
            }

            return index;
        }


        private static void AssociateJunctionsToConnectionComponents(List<Junction> cityMap)
        {
            HashSet<Junction> junctions = new HashSet<Junction>();
            foreach (Junction junction in cityMap)
            {
                junctions.Add(junction);
            }

            int connectionComponentId = 0;
            while (junctions.Count > 0)
            {
                DepthFirstSearch(junctions.First(), junctions, connectionComponentId);
                connectionComponentId++;
            }
        }

        private static void DepthFirstSearch(Junction currentJunction, HashSet<Junction> junctions, int connectionComponentId)
        {
            currentJunction.ConnectionComponentId = connectionComponentId;
            junctions.Remove(currentJunction);
            foreach (Junction junction in currentJunction.Children.Keys)
            {
                if (junctions.Contains(junction))
                {
                    DepthFirstSearch(junction, junctions, connectionComponentId);
                }
            }
        }


        private static Queue<RequestedPath> GetQueries(Queue<string> mapData, List<Junction> cityMap, Dictionary<string, int> junctionsIndices)
        {
            Queue<RequestedPath> queries = new Queue<RequestedPath>();
            HashSet<string> startingJunctionNames = new HashSet<string>();
            while (mapData.Count > 0)
            {
                string line = mapData.Dequeue();
                string[] junctionNames = line.Split();
                string startJunctionName = junctionNames[0];
                string finishJunctionName = junctionNames[1];

                AddQuery(startJunctionName, finishJunctionName, queries, startingJunctionNames, cityMap, junctionsIndices);
            }

            return queries;
        }

        private static void AddQuery(string startJunctionName, string finishJunctionName, Queue<RequestedPath> queries, HashSet<string> startingJunctionNames, List<Junction> cityMap, Dictionary<string, int> junctionsIndices)
        {
            if (startJunctionName.Equals(finishJunctionName))
            {
                queries.Enqueue(new RequestedPath(startJunctionName, finishJunctionName, true, true, false));
            }
            else if (!cityMap[junctionsIndices[startJunctionName]].ConnectionComponentId.Equals(cityMap[junctionsIndices[finishJunctionName]].ConnectionComponentId))
            {
                queries.Enqueue(new RequestedPath(startJunctionName, finishJunctionName, false, false, false));
            }
            else if (startingJunctionNames.Contains(startJunctionName))
            {
                queries.Enqueue(new RequestedPath(startJunctionName, finishJunctionName, true, false, false));
            }
            else if (startingJunctionNames.Contains(finishJunctionName))
            {
                queries.Enqueue(new RequestedPath(finishJunctionName, startJunctionName, true, false, true));
            }
            else
            {
                int comparison = startJunctionName.CompareTo(finishJunctionName);
                if (comparison == -1)
                {
                    startingJunctionNames.Add(startJunctionName);
                    queries.Enqueue(new RequestedPath(startJunctionName, finishJunctionName, true, false, false));
                }
                else
                {
                    startingJunctionNames.Add(finishJunctionName);
                    queries.Enqueue(new RequestedPath(finishJunctionName, startJunctionName, true, false, true));
                }
            }
        }


        private static Dictionary<string, Dictionary<string, PathDetails>> CreateDijkstraQueries(Queue<RequestedPath> queries)
        {
            Dictionary<string, Dictionary<string, PathDetails>> dijkstraQueries = new Dictionary<string, Dictionary<string, PathDetails>>();
            foreach (RequestedPath requestedPath in queries)
            {
                if (!requestedPath.AreEqual && requestedPath.AreInTheSameComponent)
                {
                    if (dijkstraQueries.ContainsKey(requestedPath.Start) && !dijkstraQueries[requestedPath.Start].ContainsKey(requestedPath.Destination))
                    {
                        dijkstraQueries[requestedPath.Start].Add(requestedPath.Destination, new PathDetails(requestedPath.AreReversed));

                    }
                    else
                    {
                        dijkstraQueries.Add(requestedPath.Start, new Dictionary<string, PathDetails>());
                        dijkstraQueries[requestedPath.Start].Add(requestedPath.Destination, new PathDetails(requestedPath.AreReversed));
                    }
                }
            }

            return dijkstraQueries;
        }


        private static void ExecuteDijkstraQueries(Dictionary<string, Dictionary<string, PathDetails>> dijkstraQueries, List<Junction> cityMap, Dictionary<string, int> junctionsIndices)
        {
            foreach (KeyValuePair<string, Dictionary<string, PathDetails>> query in dijkstraQueries)
            {
                int startJunctionIndex = junctionsIndices[query.Key];
                UseDijkstraAlgorithm(cityMap[startJunctionIndex]);
                cityMap[startJunctionIndex].Previous = null;
                foreach (KeyValuePair<string, PathDetails> startingJunction in query.Value)
                {
                    int destinationJunctionIndex = junctionsIndices[startingJunction.Key];
                    startingJunction.Value.Cost = cityMap[destinationJunctionIndex].Cost;
                    startingJunction.Value.Road = ExtactRoad(cityMap[destinationJunctionIndex], startingJunction.Value.IsReversed);
                }

                ResetJunctionCostAndPrevious(cityMap);
            }
        }

        private static void UseDijkstraAlgorithm(Junction startJunction)
        {
            OrderedBag<Junction> junctions = new OrderedBag<Junction>();
            startJunction.Cost = 0;
            junctions.Add(startJunction);
            while (junctions.Count > 0)
            {
                Junction currentJunction = junctions.RemoveFirst();
                currentJunction.IsVisited = true;
                foreach (Junction child in currentJunction.Children.Keys)
                {
                    if (!child.IsVisited)
                    {
                        if (child.Cost > currentJunction.Cost + currentJunction.Children[child])
                        {
                            child.Previous = currentJunction;
                            child.Cost = currentJunction.Cost + currentJunction.Children[child];
                            junctions.Add(child);
                        }
                    }
                }
            }
        }

        private static string ExtactRoad(Junction junction, bool isReversed)
        {
            StringBuilder roadBuilder = new StringBuilder();
            if (isReversed == true)
            {
                Queue<string> path = new Queue<string>();
                while (junction.Previous != null)
                {
                    path.Enqueue(junction.Name);
                    junction = junction.Previous;
                }

                path.Enqueue(junction.Name);
                while (path.Count > 0)
                {
                    roadBuilder.Append(path.Dequeue());
                }
            }
            else
            {
                Stack<string> path = new Stack<string>();
                while (junction.Previous != null)
                {
                    path.Push(junction.Name);
                    junction = junction.Previous;
                }

                path.Push(junction.Name);
                while (path.Count > 0)
                {
                    roadBuilder.Append(path.Pop());
                }
            }

            return roadBuilder.ToString();
        }

        private static void ResetJunctionCostAndPrevious(List<Junction> cityMap)
        {
            if (cityMap == null)
            {
                throw new ArgumentNullException("Cannot reset empty city map!");
            }

            foreach (Junction junction in cityMap)
            {
                junction.ResetCostAndPrevious();
            }
        }


        private static string GetResult(Queue<RequestedPath> queries, Dictionary<string, Dictionary<string, PathDetails>> dijkstraQueries)
        {
            StringBuilder resultBuilder = new StringBuilder();
            while (queries.Count > 0)
            {
                RequestedPath query = queries.Dequeue();
                if (query.AreEqual)
                {
                    resultBuilder.AppendLine("0");                    
                }
                else if (!query.AreInTheSameComponent)
                {
                    resultBuilder.AppendLine("No path!");                    
                }
                else
                {
                    int cost = dijkstraQueries[query.Start][query.Destination].Cost;
                    string road = dijkstraQueries[query.Start][query.Destination].Road;
                    resultBuilder.AppendLine(cost + " " + road);                    
                }
            }

            return resultBuilder.ToString().TrimEnd();
        }
    }
}
