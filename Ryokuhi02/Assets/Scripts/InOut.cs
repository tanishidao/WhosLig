using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOut : MonoBehaviour
{
    public GameObject[] RamPos;
    private Vector3 jumppos;
    private int poss;

    void Start()
    {
        //  randomPos = GetComponent<RandomPos>();
        transform.position = RamPos[0].transform.position;
    }

    // Update is called once per frame
   
    private void OnTriggerEnter(Collider other)
    {
        poss++;
        if (poss >= RamPos.Length)
        {
            poss = 0;
        }
       
        transform.position = RamPos[poss].transform.position;
        Debug.Log("“ü‚Á‚½");
       

        // randomPos.RandomSetPos(this.transform.position);


    }
}
