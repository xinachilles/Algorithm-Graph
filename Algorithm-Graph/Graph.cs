using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Algorithm_Heap;

namespace Algorithm_Graph
{
    public enum GraphState
    {
        Unvisited, Visited, Visiting
    }

    public class GraphNode<T>
    {
        private Dictionary<GraphNode<T>, int> costs;
        private List<GraphNode<T>> neighbors;
        //public T Value { get; set; }
        public GraphState State { get; set; }
        public GraphNode() { }
        //public GraphNode(T v)
        //{
        //    Value = v;
        //}

        //public GraphNode(T v, List<GraphNode<T>> n)
        //{

        //    Value = v;
        //    neighbors = n;

        //}



        public List<GraphNode<T>> Neighbors
        {
            get
            {
                if (neighbors == null)
                {
                    neighbors = new List<GraphNode<T>>();
                }
                return neighbors;
            }
        }

        // store the w(u,v)
        public Dictionary<GraphNode<T>, int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new Dictionary<GraphNode<T>, int>();

                return costs;
            }
        }

    }

    public class Edge<T, E>
    {
        public GraphNode<T> Start { get; set; }
        public GraphNode<E> End { get; set; }


        public Edge(GraphNode<T> from, GraphNode<E> to)
        {
            this.Start = from;
            this.End = to;

        }


    }
    public class Graph<T> where T:IComparable<T>
    {

        private List<GraphNode<T>> nodeSet;
        private List<Edge<T, T>> edgeSet = new List<Edge<T, T>>();
        private Dictionary<GraphNode<T>, int> d = new Dictionary<GraphNode<T>, int>();//shortest-path estimate
        private Dictionary<GraphNode<T>, GraphNode<T>> predecessor = new Dictionary<GraphNode<T>, GraphNode<T>>();
        public Graph() : this(null) { }
        public Graph(List<GraphNode<T>> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new List<GraphNode<T>>();
            else
                this.nodeSet = nodeSet;
        }

        public List<GraphNode<T>> Nodes
        {
            get
            {
                return nodeSet;
            }
        }

        public List<Edge<T, T>> Edges
        {
            get
            {
                return edgeSet;
            }

        }

        # region Graph function
        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
        }

        //public void AddNode(T value)
        //{
        //    // adds a node to the graph
        //    nodeSet.Add(new GraphNode<T>(value));
        //}

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(to, cost);
            edgeSet.Add(new Edge<T, T>(from, to));
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            to.Neighbors.Add(from);

            from.Costs.Add(to, cost);
            to.Costs.Add(from, cost);

            edgeSet.Add(new Edge<T, T>(from, to));
        }

        public bool Contains(GraphNode<T> value)
        {
            return nodeSet.Contains(value);

        }

        public bool Remove(GraphNode<T> value)
        {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FirstOrDefault(s => s == value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    //gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }



        public int Count
        {
            get { return nodeSet.Count; }
        }
        #endregion

        #region breath-first-search

        #region 4.2
        //4.2 Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
        public bool BFSSearch(GraphNode<T> start, GraphNode<T> end)
        {
            // operates as Queue
            Queue<GraphNode<T>> q = new Queue<GraphNode<T>>();
            foreach (GraphNode<T> item in Nodes)
            {
                item.State = GraphState.Unvisited;
            }

            start.State = GraphState.Visiting;
            q.Enqueue(start);

            while (q.Count == 0)
            {
                GraphNode<T> u = q.Dequeue(); // i.e., dequeueQ
                if (u != null)
                {
                    foreach (GraphNode<T> v in u.Neighbors)
                    {
                        if (v.State == GraphState.Unvisited)
                        {
                            if (v == end)
                            {
                                return true;
                            }
                            else
                            {
                                v.State = GraphState.Visiting;

                                q.Enqueue(v);
                            }
                        }
                    }
                    u.State = GraphState.Visited;
                }
            }
            return false;
        }
        #endregion
        #endregion

        #region depth-first-search

        public void DFS()
        {
            foreach (GraphNode<T> item in Nodes)
            {
                item.State = GraphState.Unvisited;
            }

            foreach (GraphNode<T> item in Nodes)
            {
                if (item.State == GraphState.Unvisited)
                {
                    DFSVisting(item);
                }

            }



        }

        public void DFSVisting(GraphNode<T> u)
        {
            u.State = GraphState.Visiting;
            //  time ← time +1
            //  d[u] time
            foreach (GraphNode<T> item in u.Neighbors)
            {

                if (item.State == GraphState.Unvisited)
                {

                    DFSVisting(item);
                }

                u.State = GraphState.Visited;
                //9  f [u] ▹ time ← time +1
            }
        }

        #endregion
        // u->v
        private void Relax(GraphNode<T> u, GraphNode<T> v, int w)
        {
            if (d[v] > d[u] + w)
            {
                d[v] = d[u] + w;
                predecessor[v] = u;

            }
        }


        private void Relax(GraphNode<T> u, GraphNode<T> v, int w, Heap<int> q )
        {
            if (d[v] > d[u] + w)
            {
                
                int n = d[u] + w;
                if (q.Contains(d[v]) == true)
                {
                    q.Remove(d[v]);
                    q.Insert(n);
                }

                d[v] = n;
                predecessor[v] = u;

                

            }
        }

        private void InitalizeSingleSource(GraphNode<T> s) {
            foreach (GraphNode<T> item in Nodes)
            {
                d[item] = int.MaxValue;
                predecessor[item] = null;
            }

            d[s] = 0;
        
        }

        #region Bellman-Ford algorithm
        //The Bellman-Ford algorithm solves the single-source shortest-paths problem in the general case in which edge weights may be negative. 
        //Given a weighted, directed graph G = (V, E) with source s and 
        //weight function w : E → R, 
        //the Bellman-Ford algorithm returns a boolean value indicating whether or not there is a negative-weight cycle that is reachable from the source. 
        //If there is such a cycle, the algorithm indicates that no solution exists. 
        //If there is no such cycle, the algorithm produces the shortest paths and their weights
        //#region Bellman-Ford algorithm

        public bool BellmanFord(GraphNode<T> s)
        {
            InitalizeSingleSource(s);
            foreach (GraphNode<T> item in Nodes)
            {
                foreach (GraphNode<T> i in item.Neighbors)
                {
                    Relax(item, i, item.Costs[i]);
                }
            }

            foreach (Edge<T, T> item in edgeSet)
            {
                if (d[item.End] > d[item.Start] + item.Start.Costs[item.End])
                {
                    return false;
                }
            }

            return true;
        }

        
     

        #endregion
        //u->v
        
        #region Dijkstra


        public void Dijkstra(GraphNode<T> s)
        {
            InitalizeSingleSource(s);
           
            // List<GraphNode<T>> s = new List<GraphNode<T>>();
           
            int[] a = d.Values.ToArray();
            Heap<int> q = new Heap<int>(a,false);
            while (q.Count >0)
            {

                int smallest = q.ExtractMin();
                GraphNode<T> u = d.First(x => x.Value == smallest).Key;
               
                foreach (GraphNode<T> item in u.Neighbors)
                {
                    Relax(u, item, u.Costs[item], q);
                }


               


            }
        }
        #endregion
    }
}
