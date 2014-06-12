using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {
	public Texture2D bitMapArray;
	public Vector2 tilesSize;
	public Vector2 origin;
	public Vector2 corner;
	public GameObject highLighter;
	private Vector2 tileSize;
	private float posZ;
	public int[,] mapArray;
	public Node[,] nodes {get; set;}
	public Vector2[] startNodes;
	public Vector2[] goalNodes;
	public List<Path> paths = new List<Path>();

	void Start () {
		tileSize = new Vector2((float)Vector2.Distance(origin,new Vector2(corner.x,origin.y))/(float)tilesSize.x,
		                       (float)Vector2.Distance(new Vector2(origin.x,corner.y),origin)/(float)tilesSize.y);
		mapArray = parseMap(bitMapArray);
		nodes = buildNodes(mapArray);
		AStar.gridManager = this;
		initializePaths();
		highLighter.SendMessage("isHighlighting",false);
	}
	
	void Update () {

	}

	void OnDrawGizmos () {
		mapArray = parseMap(bitMapArray);
		tileSize = new Vector2((float)Vector2.Distance(origin,new Vector2(corner.x,origin.y))/(float)tilesSize.x,
		                       (float)Vector2.Distance(new Vector2(origin.x,corner.y),origin)/(float)tilesSize.y);
		Gizmos.color = Color.black;
		for(int j=0;j<paths.Count;j++){
			if(paths[j] != null){
				for(int i=0;i<paths[j].Length-1;i++){
					Gizmos.DrawLine(paths[j].getPoint(i),paths[j].getPoint(i+1));
				}
			}
		}
		Gizmos.color = Color.white;
		for(int i=0;i<=tilesSize.x;i++){
			Gizmos.DrawLine(new Vector3(origin.x + i*tileSize.x,origin.y,0),
			                new Vector3(origin.x + i*tileSize.x,corner.y,0));
		}
		for(int i=0;i<=tilesSize.y;i++){
			Gizmos.DrawLine(new Vector3(origin.x,origin.y-(i*tileSize.y),0),
			                new Vector3(corner.x,origin.y-(i*tileSize.y),0));
		}
	}

	int[,] parseMap (Texture2D bitMap) {
		int[,] array = new int[bitMap.width,bitMap.height];
		int x=0;
		int y=0;
		for(int i=0;i<bitMap.width;i++){
			y=0;
			for(int j=bitMap.height-1;j>=0;j--){
				if(bitMap.GetPixel(i,j)==Color.black)
					array[x,y] = 1;
				else 
					array[x,y] = 0;
				y++;
			}
			x++;
		}
		return array;
	}

	Node[,] buildNodes (int[,] map) {
		Node[,] nodes = new Node[bitMapArray.width,bitMapArray.height];
		for(int i=0;i<bitMapArray.width;i++){
			for(int j=0;j<bitMapArray.height;j++){
				nodes[i,j] = new Node(getTileCenter(new Vector2(i,j)));
				if(map[i,j]==0)
					nodes[i,j].markAsObstacle();
			}
		}
		return nodes;
	}
	
	public Vector2 getTileIndex (Vector3 worldPosition) {
		Vector2 tilePos = new Vector2(worldPosition.x-origin.x,worldPosition.y-origin.y);
		return new Vector2((int)(tilePos.x/tileSize.x),-(int)(tilePos.y/tileSize.y));
	}
	
	public Vector2 getTileCenter (Vector2 tileIndex) {
		return new Vector2(origin.x + tileSize.x/2 + tileIndex.x*tileSize.x,
		                   origin.y - tileSize.y/2 - tileIndex.y*tileSize.y);
	}
	
	public Vector2 getTileCenter (Vector3 worldPosition) {
		Vector2 index = getTileIndex(worldPosition);
		return getTileCenter(index);
	}

	public void assignNeighbour (int xIndex, int yIndex, List<Node> neighbours) {
		if(xIndex >= 0 && yIndex >=0 && xIndex < (int)tilesSize.x && yIndex < (int)tilesSize.y){
			Node nodeToAdd = nodes[xIndex,yIndex];
			if(!nodeToAdd.isObstacle)
				neighbours.Add(nodeToAdd);
		}
	}

	public void getNeighbours (Node node, List<Node> neighbours) {
		Vector2 index = getTileIndex(node.position);
		int xIndex = (int)index.x;
		int yIndex = (int)index.y;
		assignNeighbour(xIndex-1,yIndex,neighbours);
		assignNeighbour(xIndex,yIndex+1,neighbours);
		assignNeighbour(xIndex,yIndex-1,neighbours);
		assignNeighbour(xIndex+1,yIndex,neighbours);
	}

	public void highLight (Vector3 worldPosition, bool isMouseDown, int occ) {
		Vector2 index = getTileIndex(worldPosition);
		if(isMouseDown&&checkIndex(index)){
			highLighter.SendMessage("isHighlighting",true);
			highLighter.transform.position = getTileCenter(worldPosition);
			highLighter.SendMessage("setAvailable",(int)mapArray[(int)index.x,(int)index.y]==0&&nodes[(int)index.x, (int)index.y].occupier==occ);
		}else{
			highLighter.SendMessage("isHighlighting",false);
		}
	}

	bool checkIndex(Vector2 index){
		return (index.x>=0&&index.y>=0&&index.x<=bitMapArray.width-1&&index.y<=bitMapArray.height-1);
	}

	void initializePaths(){
		for(int i=0;i<startNodes.Length;i++){
			paths.Add(new Path());
			paths[i].points = AStar.findPath(nodes[(int)startNodes[i].x,(int)startNodes[i].y],nodes[(int)goalNodes[i].x,(int)goalNodes[i].y]);
		}
	}
}
