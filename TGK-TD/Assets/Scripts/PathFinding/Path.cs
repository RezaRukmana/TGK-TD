using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path {
	public bool isDebug = true;
	public float radius = 0.1f;
	public List<Node> points = new List<Node>();

	public float Length {
		get{return points.Count;}
	}
	
	public Vector3 getPoint(int index) {
		return points[index].position;
	}
}
