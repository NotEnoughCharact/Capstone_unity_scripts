using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_game : MonoBehaviour
{
    public bool ended = false;
    private int counter = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ended)
        {
            if(counter == 250)
            {
                Application.Quit();
            }
            counter++;
            //Debug.Log(counter);
        }
    }
}
