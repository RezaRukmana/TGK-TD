using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar {
	public static PriorityQueue closedList, openList;
	public static GridManager gridManager;

	private static float heuristicEstimateCost(Node curNode, Node goalNode) {
		Vector3 vecCost = goalNode.position - curNode.position;
		return vecCost.magnitude;
	}

	public static List<Node> findPath(Node start, Node goal) {
		openList = new PriorityQueue();
		openList.Push(start);
		start.nodeTotalCost = 0.0f;
		start.estimatedCost = heuristicEstimateCost(start,goal);

		closedList = new PriorityQueue();
		Node node = null;

		while (openList.Length != 0) {
			node = openList.First();

			if(node.position == goal.position){
				return calculatePath(node);
			}

			List<Node> neighbours = new List<Node>();
			gridManager.getNeighbours(node,neighbours);
			for(int i=0;i<neighbours.Count;i++){
				Node neighbour = neighbours[i];

				if(!closedList.Contains(neighbour)){
					float cost = heuristicEstimateCost(node,neighbour);
					float totalCost = node.nodeTotalCost + cost;
					float neighbourEstCost = heuristicEstimateCost(neighbour,goal);
					neighbour.nodeTotalCost = totalCost;
					neighbour.parent = node;
					neighbour.estimatedCost = totalCost + neighbourEstCost;
					if(!openList.Contains(neighbour)){
						openList.Push(neighbour);
					}
				}

			}
			closedList.Push(node);
			openList.Remove(node);
		}
		if (node.position != goal.position) {
			Debug.LogError("Goal Not Found");
			return null;
		}
		return calculatePath(node);
	}

	private static List<Node> calculatePath(Node node) {
		List<Node> path = new List<Node>();
		while(node != null) {
			path.Add(node);
			node = node.parent;
		}
		path.Reverse();
		return path;
	}
}
