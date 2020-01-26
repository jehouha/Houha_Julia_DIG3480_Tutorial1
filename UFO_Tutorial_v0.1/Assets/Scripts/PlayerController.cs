using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Movement Variables
    
    private Rigidbody2D rb2d;
    public float speed;

    // Score Variables
    
    private int count;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    // Trigger pickups
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    // UI scorekeeper
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You win! Game created by Julia Houha.";
        }
    }

}
