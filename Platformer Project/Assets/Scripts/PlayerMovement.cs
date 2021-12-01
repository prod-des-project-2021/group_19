
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private bool grounded;
    public GameObject counter;
    private GameObject[] cnt;
    private int coll;
    
    private void Start()
    {
        counter = GameObject.Find("CollCount");
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
            }

    private void Update()
    {

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if(Input.GetKey(KeyCode.Space) && grounded)
            Jump();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
            {
                print("touching collider!");
                Destroy(collision.gameObject);
                cnt = GameObject.FindGameObjectsWithTag("Collectible");
                coll = cnt.Length - 1;
                counter.GetComponent<UnityEngine.UI.Text>().text = coll.ToString();
                if (coll == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
         //   counter1.Counter();
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}