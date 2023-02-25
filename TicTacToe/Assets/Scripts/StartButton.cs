using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public int gameOn = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor(Color.gray);
    }

    void OnMouseEnter()
    {
        ChangeColor(Color.white);
    }

    void OnMouseExit()
    {
        ChangeColor(Color.gray);
    }

    void OnMouseUpAsButton()
    {
        GameObject.Find("TicTacToe").GetComponent<TicTacToe>().ShowBoard();
        gameOn = 1;
    }

    public void ChangeColor(Vector4 c)
    {
        GetComponent<MeshRenderer>().material.color = c;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
