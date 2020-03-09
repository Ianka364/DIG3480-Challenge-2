using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    Animator anim;
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    public Text winText;
    private int scoreValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.D))
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            musicSource.Stop();
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            musicSource.Stop();
            anim.SetInteger("State", 0);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 3);
     
        }
        if (scoreValue==4)
        {
            winText.text = "You Win!";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));


    }
}
