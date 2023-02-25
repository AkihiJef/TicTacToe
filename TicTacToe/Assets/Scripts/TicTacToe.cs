using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TicTacToe : MonoBehaviour
{
    public GameObject mainUICamera;
    public GameObject boardCamera;
    public GameObject board;
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject tieUI;
    private Vector3[,] box = new Vector3[3, 3];
    private int total = 0;
    private int result = 0;

    void Start()
    {
        Debug.Log("Hello world!");
        //ShowMainUI();
        ShowBoard();
        BoardInit();
    }

    public void BoardInit()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
                box[x, y] = new Vector3(-1, 0, 0);
        }
        total = 0;
        result = 0;
    }

    public void ShowBoard()
    {
        mainUICamera.SetActive(false);
        boardCamera.SetActive(true);
        board.SetActive(true);
    }

    public void ShowMainUI()
    {
        mainUICamera.SetActive(true);
        boardCamera.SetActive(false);
        board.SetActive(false);
    }

    private int CheckWin(int x, int y, int player)
    {
        if (box[x, y].y == player * 3)
            return player;
        total += 1;
        if (total == 9)
            return -1;
        return 0;
    }

    private void BoardUpdate()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                BoxUpdate(i, j);
    }

    private void BoxUpdate(int x, int y)
    {
        float[] row = { 0, 0, 0, 0 };
        float sum = 0;
        for (int i = 0; i < 3; i++)
        {
            row[0] += box[x, i].x;
            row[1] += box[i, y].x;
            if (x == y)
                row[2] += box[i, i].x;
            if (x + y == 2)
                row[3] += box[i, 2 - i].x;
        }
        for (int i = 0; i < 4; i++)
        {
            row[i] = Math.Abs(row[i]);
            if (box[x, y].y < row[i])
                box[x, y].y = row[i];
            sum += row[i];
        }
        box[x, y].z = sum;
    }


    public void GameOver(int winner)
    {
        if (winner == -1)
            tieUI.SetActive(true);
        if (winner == 10)
            winUI.SetActive(true);
        if (winner == 11)
            loseUI.SetActive(true);
    }

    private void AiAction(int x, int y)
    {
        int targetX = -1, targetY = -1;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (box[i, j].x == -1)
                {
                    if (targetX == -1)
                    {
                        targetX = i;
                        targetY = j;
                    }
                    else if (box[i, j].y > box[targetX, targetY].y)
                    {
                        targetX = i;
                        targetY = j;
                    }
                    else if (box[i, j].y == box[targetX, targetY].y && box[i, j].z > box[targetX, targetY].z)
                    {
                        targetX = i;
                        targetY = j;
                    }
                }
            }
        }

        box[targetX, targetY].x = -11;
        BoardUpdate();
        Debug.Log(box[targetX, targetY].y);

        result = CheckWin(targetX, targetY, 11);
        if (result != 0)
            GameOver(result);
    }

    public void PlayerAction(int x, int y)
    {
        box[x, y].x = 10;
        BoardUpdate();
        result = CheckWin(x, y, 10);
        if (result != 0)
            GameOver(result);
        else
            AiAction(x, y);

    }

    public int GetResult()
    {
        return result;
    }

    public float GetOwner(int x, int y)
    {
        return box[x, y].x;
    }

    void Update()
    {

        /*
        if (Input.GetKeyDown("f"))
        {
            ShowBoard();
        }
        if (Input.GetKeyDown("a"))
        {
            ShowMainUI();
        }*/
    }
}
