
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpspeed = 5;
    private Rigidbody2D body;
    private bool grounded;
    public GameObject counter;
    private GameObject[] cnt;
    private int coll;
    public AudioSource jumpSound;
    public AudioSource collectibleSound;
    
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
        body.velocity = new Vector2(body.velocity.x, jumpspeed);
        jumpSound.Play();
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
            grounded = true;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
            {
                print("touching collider!");
                Destroy(collision.gameObject);
                collectibleSound.Play();
                cnt = GameObject.FindGameObjectsWithTag("Collectible");
                coll = cnt.Length - 1;
                counter.GetComponent<UnityEngine.UI.Text>().text = coll.ToString();
                if (coll == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    
                    if (SceneManager.GetActiveScene().buildIndex == 2)
                    {
                        Cursor.visible = true;
                    }
                }
            }
         //   counter1.Counter();
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}