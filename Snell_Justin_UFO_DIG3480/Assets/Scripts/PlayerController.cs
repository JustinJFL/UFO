using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private int count;
    private Rigidbody2D rb;
    void Start()
    {
        count = 0;
        setCountText();
        winText.text = "";
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
     Application.Quit();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb.AddForce (movement * speed);
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {        
            other.gameObject.SetActive(false);
            count = count +1;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
            countText.text = "";
        }
    }
}
