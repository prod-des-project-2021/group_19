using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        healthDisplay = GameObject.Find("HealthD");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            health = 0;
        }

        if (collision.gameObject.tag == "Damage")
        {
            health -= 1;
            healthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Health: " + health.ToString();
        }
    }
}
