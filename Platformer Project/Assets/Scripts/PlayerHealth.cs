using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public Image healthDisplay;
    public AudioSource damageSound;
    public AudioSource deathSound;

    public Sprite hearts0;
    public Sprite hearts1;
    public Sprite hearts2;
    public Sprite hearts3;

    [SerializeField] private float _time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

        
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
            health -= 1;
            if (health > 0)
            {
                damageSound.Play();
            }
            else
            {
                deathSound.Play();
            }
            
            switch (health)
            {
                case 3:
                    healthDisplay.sprite = hearts3;
                break;

                case 2:
                    healthDisplay.sprite = hearts2;
                break;

                case 1:
                    healthDisplay.sprite = hearts1;
                break;

                case 0:
                    healthDisplay.sprite = hearts0;
                break;
            }
        }
    }

    public void RestartScene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
