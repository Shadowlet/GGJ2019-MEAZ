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

    void Start()
    {
        tiles = new Gametiles[width,height];
        Board();
    }

    private void Update()
    {
        
    }

    private void Board(int[] Map)
    {
        for (int xx = 0; xx < width; xx++)
        {
            for (int yy = 0; yy < height; yy++)
            {
                Vector2 position = new Vector2(xx, yy);
<<<<<<< HEAD

                Map[xx] = Map[yy];
                Instantiate(Tiles[Random.Range(0,7)], position, Quaternion.identity);

                Debug.Log(Map);
            }
        }
                rand_number = Random.Range(0, 7);
                Instantiate(Tiles[rand_number], position, Quaternion.identity);
                tileGrid[xx, yy] = Tiles[rand_number];
                tileGridStatus[xx, yy] = 0;
=======
                Instantiate(Tiles[Random.Range(0,7)], position, Quaternion.identity);
>>>>>>> parent of 0ce953d... Update GameBoard.cs
            }
        }
    }

    private void Sweep()
    {

    }


    


}
