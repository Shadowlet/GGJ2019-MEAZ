using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public int height;
    public int width;
    public GameObject gameTiles;
    public Gametiles[,] tiles; //this is what holds the prefabs for the tiles
    public GameObject[] Tiles;
    public GameObject[,] tileGrid;
    public int[,] tileGridStatus;
    private int rand_number;

    void Start()
    {
        tiles          = new Gametiles[width,height];
        tileGrid       = new GameObject[width, height];
        tileGridStatus = new int[width, height];
        Board();
    }

    private void Board()
    {
        for (int xx = 0; xx < width; xx++)
        {
            for (int yy = 0; yy < height; yy++)
            {
                Vector2 position = new Vector2(xx, yy);
                rand_number = Random.Range(0, 7);
                Instantiate(Tiles[rand_number], position, Quaternion.identity);
                tileGrid[xx, yy] = Tiles[rand_number];
                tileGridStatus[xx, yy] = 0;
            }
        }
        for (int xx = 0; xx < width; xx++)
        {
            for (int yy = 0; yy < height; yy++)
            {
                Debug.Log("x:"+xx+ "y:"+yy+"-"+tileGrid[xx, yy]);
                Debug.Log(tileGridStatus[xx, yy]);
            }
        }

    }
}
