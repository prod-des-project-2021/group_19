using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{

    int coll = 19;
    public GameObject display;   


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] cnt = GameObject.FindGameObjectsWithTag("Collectible");
        coll = cnt.Length;
        display.GetComponent<UnityEngine.UI.Text>().text = coll.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
