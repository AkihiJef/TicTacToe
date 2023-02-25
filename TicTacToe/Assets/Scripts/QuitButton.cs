using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{

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
        Application.Quit();
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
