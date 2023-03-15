using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{   

    private Pathfinding pathfinding;
    [SerializeField] private PathfindingVisual pathfindingVisual;
    //[SerializeField] private HeatMapVisual heatMapVisual;
   // [SerializeField] private HeatMapBoolVisual heatMapBoolVisual;
    //[SerializeField] private HeatMapGenericVisual heatMapGenericVisual;
   // private Grid<HeatMapGridObject> grid;
//    private Grid<StringGridObject> stringGrid;
    private void Start()
    {
        //grid = new Grid<HeatMapGridObject>(20, 10, 8f, Vector3.zero, (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
        //stringGrid = new Grid<StringGridObject>(20, 10, 8f, Vector3.zero, (Grid<StringGridObject> g, int x, int y) => new StringGridObject(g, x, y));

        //heatMapVisual.SetGrid(grid);
        //heatMapBoolVisual.SetGrid(grid);
        //heatMapGenericVisual.SetGrid(grid);

        pathfinding = new Pathfinding(10,10);
        pathfindingVisual.SetGrid(pathfinding.GetGrid());

    }

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            Vector3 mouseWorldPostion = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPostion, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null) {
                for (int i = 0; i < path.Count - 1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1)) {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }


        //Vector3 position = UtilsClass.GetMouseWorldPosition();

        /*if (Input.GetMouseButtonDown(0)){
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);
            if (heatMapGridObject != null){
                heatMapGridObject.AddValue(5);
            }
        }*/

        //if (Input.GetKeyDown(KeyCode.A)) { stringGrid.GetGridObject(position).AddLetter("A");}
        //if (Input.GetKeyDown(KeyCode.B)) { stringGrid.GetGridObject(position).AddLetter("B");}
        //if (Input.GetKeyDown(KeyCode.C)) { stringGrid.GetGridObject(position).AddLetter("C");}

       //// if (Input.GetKeyDown(KeyCode.Alpha1)) { stringGrid.GetGridObject(position).AddLetter("1");}
        //if (Input.GetKeyDown(KeyCode.Alpha2)) { stringGrid.GetGridObject(position).AddLetter("2");}
        //if (Input.GetKeyDown(KeyCode.Alpha3)) { stringGrid.GetGridObject(position).AddLetter("3");}
        
    }
}

/*public class HeatMapGridObject{
    private const int MIN = 0;
    private const int MAX = 100;
    private Grid<HeatMapGridObject> grid;
    private int x;
    private int y;
    public int value;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue){
        value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);;
        
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalized(){
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

public class StringGridObject {

    private Grid<StringGridObject> grid;
    private int x;
    private int y;

    private string letters;
    private string numbers;

    public StringGridObject(Grid<StringGridObject> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
        letters = "";
        numbers = "";
    }

    public void AddLetter(string letter){
        letters += letter;
        grid.TriggerGridObjectChanged(x, y);
    }

    public void AddNumber(string number){
        number += number;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return letters + "\n" + numbers;
    }
}*/
