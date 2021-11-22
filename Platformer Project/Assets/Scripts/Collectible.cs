using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerStay2D(Collider2D col)
    {
        Debug.Log("we have contact!");
        // SceneManager.LoadScene("EndScreen");
    }

    void onCollisionEnter2D(Collider2D col)
    {
        Debug.Log("we have contact!");
       // SceneManager.LoadScene("EndScreen");
    }
}
