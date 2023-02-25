using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    private int state = 0;
    private int gameState = 0;
    private float owner = -1;
    public int x, y;
    // Use this for initialization
    void Start()
    {
        ChangeColor(Color.gray);
    }

    void OnMouseEnter()
    {
        if (state == 0 && gameState == 0)
            state = 1;
    }

    void OnMouseExit()
    {
        if (state == 1 && gameState == 0)
            state = 0;
    }

    void OnMouseUpAsButton()
    {
        if (gameState == 0 && owner == -1)
            GameObject.Find("TicTacToe").GetComponent<TicTacToe>().PlayerAction(x, y);
    }

    public void ChangeColor(Vector4 c)
    {
        GetComponent<MeshRenderer>().material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        owner = GameObject.Find("TicTacToe").GetComponent<TicTacToe>().GetOwner(x, y);
        gameState = GameObject.Find("TicTacToe").GetComponent<TicTacToe>().GetResult();
        switch (owner)
        {
            case -1:
                if (state == 1)
                    ChangeColor(Color.white);
                else
                    ChangeColor(Color.gray);
                break;
            case 10:
                ChangeColor(Color.green);
                break;
            case -11:
                ChangeColor(Color.red);
                break;
        }
    }
}
