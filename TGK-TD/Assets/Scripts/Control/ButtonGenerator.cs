using UnityEngine;
using System.Collections;

public class ButtonGenerator : MonoBehaviour {

	public PauseButton pauseButton;
	public InventoryButtonUI[] inventoryButton;
	public PlayerStats ps;
<<<<<<< HEAD
	private GridManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("Map").GetComponent<GridManager>();
=======
	public GridManager gm;

	// Use this for initialization
	void Start () {
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
		Instantiate(pauseButton);
		for(int i=0;i<inventoryButton.Length;i++){
			inventoryButton[i].slot=i;
			inventoryButton[i].GetComponent<DraggedButton>().ps = ps;
			inventoryButton[i].GetComponent<DraggedButton>().gridManager = gm;
			Instantiate(inventoryButton[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
