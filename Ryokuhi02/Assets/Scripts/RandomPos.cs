using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
  
    private Vector3 ranPos;
    [SerializeField]
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomSetPos(Vector3 changeObj)
    {
        changeObj = new Vector3(Random.Range(10, 100), 1, Random.Range(20, 100));
    }
    public void TestStr(string str)
    {
        str = "hakkenn";
    }
   
}
