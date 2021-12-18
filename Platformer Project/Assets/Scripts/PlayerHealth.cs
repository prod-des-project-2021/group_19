using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public GameObject healthDisplay;
    public AudioSource damageSound;
    public AudioSource deathSound;

    [SerializeField] private float _time = 0.5f;

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
            Invoke("RestartScene", _time);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            health = 0;
            deathSound.Play();
        }

        if (collision.gameObject.tag == "Damage")
        {
            if (health > 0)
                {
                    damageSound.Play();
                }
                else
                {
                    deathSound.Play();
                } 
        }      
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage" && health > 0)
        {
            health -= 1;
            healthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Health: " + health.ToString();
        }
    }

    public void RestartScene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
