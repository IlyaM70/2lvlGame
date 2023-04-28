using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject ScoresPanel;
    [SerializeField] private GameObject YouWinPanel;
    public float speed = 10f;
   public int score = 0;

    Rigidbody2D rb; 


    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        YouWinPanel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        scoreCount.text = "Score:" + score;
    }


    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); 
        float zMove = Input.GetAxisRaw("Vertical"); 

        rb.velocity = new Vector3(xMove,zMove) * speed;


        if (score == 77)
        {
            YouWinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            score++;
            scoreCount.text = "Score:" + score;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameOverPanel.SetActive(true);
            
            ScoresPanel.SetActive(false);
        }
    }
} 

   

