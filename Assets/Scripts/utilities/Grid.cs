using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid {

    /* 
    This class creates the grid system used for pathfinding.
    */

    // Grid dimensions
    private int width;
    private int height;

    // Size of each grid space
    private float cellSize;

    // Creates a multi-dimensional array 
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize) {

        this.width = width;
        this.height = height;

        // Sets multi-dimensional array to equal height and width set by Grid creator
        gridArray = new int[width, height];

        // Cycling through a multi-dimentional array
        for (int x = 0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) {
                UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y), 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize;
    }

}
