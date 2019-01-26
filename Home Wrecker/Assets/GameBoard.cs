using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public int height;
    public int width;
    public GameObject gameTiles;
    public Gametiles[,] tiles; //this is what holds the prefabs for the tiles
    public int[] array;

    void Start()
    {
        tiles = new Gametiles[width,height];
        Board(); 
    }

    private void Board()
    {
        for (int xx = 0; xx < width; xx++)
        {
            for (int yy = 0; yy < height; yy++)
            {
                Vector2 position = new Vector2(xx, yy);
                Instantiate(gameTiles, position, Quaternion.identity);
            }
        }
    }
}
