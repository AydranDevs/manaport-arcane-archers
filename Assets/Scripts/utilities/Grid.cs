using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid<TGridObject> {

    /* 
    This class creates the grid system used for pathfinding.
    */

    // Grid dimensions
    private int width;
    private int height;

    private Vector3 origin;

    // Size of each grid space
    private float cellSize;

    // Creates a multi-dimensional array 
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Vector3 origin, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject) {

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        // Sets multi-dimensional array to equal height and width set by Grid creator
        gridArray = new TGridObject[width, height];

        // same thing but for debug purposes.
        debugTextArray = new TextMesh[width, height];

        // Cycling through a multi-dimentional array
        for (int x=0; x < gridArray.GetLength(0); x++) {
            for (int y=0; y < gridArray.GetLength(1); y++) {
                debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 7f, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + origin;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - origin).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - origin).y / cellSize);
    }

    // These two are used to set the value of a given gridspace
    public void SetValue(int x, int y, TGridObject value) {
        
        // ignore values that are outside of the grid.
        if(x >= 0 && y >= 0 && x < width && y < height) {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }
    public void SetValue(Vector3 worldPosition, TGridObject value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    // these two are used to get the value of a given gridspace
    public TGridObject GetValue(int x, int y) {
        if(x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        }else {
            return default(TGridObject);
        }
    }
    public TGridObject GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }


}
