using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private int count, score, lives;
    public Text winText, scoreText, livesText, countText;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetCountText();
        winText.text = "";
    }

    void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            score = score + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);

            lives = lives -1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        livesText.text ="Lives: " + lives.ToString();
        scoreText.text ="Score: " + score.ToString();
        countText.text ="Count: " + count.ToString();

        if (count == 12)
        {
            transform.position = new Vector3(50.33f, 0.5f, -5.62f);
        }
        if (count == 20)
        {
            winText.text ="You win! \nThis game was made by MAS";
        }
        if (lives == 0)
        {
            Destroy(this.gameObject);
            winText.text ="You Lose! \nThis game was made by MAS";
        }
    }
}