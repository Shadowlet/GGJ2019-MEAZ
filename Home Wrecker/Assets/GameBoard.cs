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
    private GameObject tmpTile;
    private GameObject[] tmpTiles;
    private int[] tmpTilesxx;
    private int[] tmpTilesyy;
    private int[] vtmpTilesxx;
    private int[] vtmpTilesyy;
    private GameObject[] vtmpTiles;
    private int[] matchTilesxx;
    private int[] matchTilesyy;
    private GameObject matchTiles;
    private int count_tmpTiles = 0;
    private int vcount_tmpTiles = 0;
    private int count_matchTiles = 0;
    void Start()
    {
        tiles = new Gametiles[width, height];
        tileGrid = new GameObject[width, height];
        tileGridStatus = new int[width, height];
        tmpTiles = new GameObject[width * height];
        tmpTilesxx = new int[width * height];
        tmpTilesyy = new int[width * height];
        vtmpTiles = new GameObject[width * height];
        vtmpTilesxx = new int[width * height];
        vtmpTilesyy = new int[width * height];
        matchTilesxx = new int[width * height];
        matchTilesyy = new int[width * height];

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

        Check();
        Debug.Log("match:" + count_matchTiles);
        Debug.Log("xx:" + matchTilesxx[0]);
        Debug.Log("yy:" + matchTilesyy[0]);

        for (int xx = 0; xx < width; xx++)
        {
            for (int yy = 0; yy < height; yy++)
            {
                //Debug.Log("x:" + xx + "y:" + yy + "-" + tileGrid[xx, yy]);
                //Debug.Log(tileGridStatus[xx, yy]);
                //Debug.Log("x:" + xx + "y:" + yy + "-" + tileGrid[xx, yy]);

            }
        }

    }

    private void Check()
    {
        for (int xx = 0; xx < width; xx++)
        {
            for (int yy = height-1; yy >= 0; yy--)
            {
                tmpTile = tileGrid[xx, yy];
                tmpTiles[0] = tmpTile;
                tmpTilesxx[0] = xx;
                tmpTilesyy[0] = yy;
                count_tmpTiles = 1;
                matchTilesxx[0] = xx;
                matchTilesyy[0] = yy;
                matchTiles = tmpTile;
                count_matchTiles = 1;
                Debug.Log("Tile:" + tmpTile+", x:"+xx+", y:"+yy);
                int noMatch = 0;

                while (noMatch == 0)
                {
                    int anyMatch = 0;
                    for (int j = 0; j < count_tmpTiles; j++)
                    {
                        int xxLeft = tmpTilesxx[j] - 1;
                        int xxRight = tmpTilesxx[j] + 1;
                        int yyUp = tmpTilesyy[j] - 1;
                        int yyDown = tmpTilesyy[j] + 1;
                        int ignore = 0;
                        if (xxLeft >= 0 && xxLeft < width)
                        {
                            Debug.Log("K:" + count_matchTiles);
                            Debug.Log("tmp:" + count_tmpTiles);
                            for (int k = 0; k < count_matchTiles; k++)
                            {
                                if (matchTilesxx[k] == xxLeft && matchTilesyy[k] == yy)
                                {
                                    ignore = 1;
                                    Debug.Log("Left_Ignore");
                                }
                            }

                            if (tmpTiles[j] == tileGrid[xxLeft, yy] && ignore == 0)
                            {
                                vtmpTiles[j] = tileGrid[xxLeft, yy];
                                vtmpTilesxx[vcount_tmpTiles] = xxLeft;
                                vtmpTilesyy[vcount_tmpTiles] = yy;
                                vcount_tmpTiles++;
                                anyMatch = 1;
                                matchTilesxx[count_matchTiles] = xxLeft;
                                matchTilesyy[count_matchTiles] = yy;
                                count_matchTiles++;
                                Debug.Log("xxLeft Match");
                            }
                        }
                        if (xxRight >= 0 && xxRight < width)
                        {
                            Debug.Log("K:" + count_matchTiles);
                            Debug.Log("tmp:" + count_tmpTiles);
                            for (int k = 0; k < count_matchTiles; k++)
                            {
                                if (matchTilesxx[k] == xxRight && matchTilesyy[k] == yy)
                                {
                                    ignore = 1;
                                    Debug.Log("Right_Ignore");
                                }
                            }

                            if (tmpTiles[j] == tileGrid[xxRight, yy] && ignore == 0)
                            {
                                vtmpTiles[j] = tileGrid[xxRight, yy];
                                vtmpTilesxx[vcount_tmpTiles] = xxRight;
                                vtmpTilesyy[vcount_tmpTiles] = yy;
                                vcount_tmpTiles++;
                                anyMatch = 1;
                                matchTilesxx[count_matchTiles] = xxRight;
                                matchTilesyy[count_matchTiles] = yy;
                                count_matchTiles++;
                                Debug.Log("xxRight Match");
                            }

                        }
                        if (yyUp >= 0 && yyUp < height)
                        {
                           Debug.Log("K:" + count_matchTiles);
                            Debug.Log("tmp:" + count_tmpTiles);
                            for (int k = 0; k < count_matchTiles; k++)
                            {
                                //Debug.Log("k:" + count_matchTiles);
                                if (matchTilesxx[k] == xx && matchTilesyy[k] == yyUp)
                                {
                                    ignore = 1;
                                    Debug.Log("Up_Ignore");
                                }
                            }
                            if (tmpTiles[j] == tileGrid[xx, yyUp] && ignore == 0)
                            {
                                vtmpTiles[j] = tileGrid[xx, yyUp];
                                //Debug.Log("vcount:" + vcount_tmpTiles);
                                vtmpTilesxx[vcount_tmpTiles] = xx;
                                vtmpTilesyy[vcount_tmpTiles] = yyUp;
                                vcount_tmpTiles++;
                                anyMatch = 1;
                                matchTilesxx[count_matchTiles] = xx;
                                matchTilesyy[count_matchTiles] = yyUp;
                                count_matchTiles++;
                                Debug.Log("yyUp Match");
                            }

                        }
                        if (yyDown >= 0 && yyDown < height)
                        {
                            Debug.Log("K:" + count_matchTiles);
                            Debug.Log("tmp:" + count_tmpTiles);
                            for (int k = 0; k < count_matchTiles; k++)
                            {
                                if (matchTilesxx[k] == xx && matchTilesyy[k] == yyDown)
                                {
                                    ignore = 1;
                                    Debug.Log("Down_Ignore");
                                }
                            }
                            Debug.Log("J:" + j);
                            Debug.Log("xx:" + xx);
                            Debug.Log("yyDown:" + yyDown);


                            if (tmpTiles[j] == tileGrid[xx, yyDown] && ignore == 0)
                            {
                                vtmpTiles[j] = tileGrid[xx, yyDown];
                                vtmpTilesxx[vcount_tmpTiles] = xx;
                                vtmpTilesyy[vcount_tmpTiles] = yyDown;
                                vcount_tmpTiles++;
                                anyMatch = 1;
                                matchTilesxx[count_matchTiles] = xx;
                                matchTilesyy[count_matchTiles] = yyDown;
                                count_matchTiles++;

                                Debug.Log("yyDown_Match:");
                            }

                        }
                    }
                    if (anyMatch == 0)
                    {
                        noMatch = 1;
                        anyMatch = 0; //clear anyMatch
                        tmpTiles = vtmpTiles;
                        count_tmpTiles = vcount_tmpTiles;
                        tmpTilesxx = vtmpTilesxx;
                        tmpTilesyy = vtmpTilesyy;
                        vtmpTiles = new GameObject[width * height];
                        vtmpTilesxx = new int[width * height];
                        vtmpTilesyy = new int[width * height];
                        vcount_tmpTiles = 0;

                    }
                    else
                    {
                        anyMatch = 0; //clear anyMatch
                        tmpTiles = vtmpTiles;
                        count_tmpTiles = vcount_tmpTiles;
                        tmpTilesxx = vtmpTilesxx;
                        tmpTilesyy = vtmpTilesyy;
                        vtmpTiles = new GameObject[width * height];
                        vtmpTilesxx = new int[width * height];
                        vtmpTilesyy = new int[width * height];
                        vcount_tmpTiles = 0;

                        //Debug.Log("anyMatch = 0");

                    }

                }
                if (count_matchTiles > 2)
                {
                    Debug.Log("match tiles:"+matchTiles);
                    Debug.Log("match count:"+count_matchTiles);
                    Debug.Log("return");

                    return;
                }

            }
        }
    }
}