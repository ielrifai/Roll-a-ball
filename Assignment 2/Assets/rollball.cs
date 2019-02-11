using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollBall : MonoBehaviour
{


    public float speed;

    private Rigidbody rb;

    private int counter;

    public Text score;


    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        // This allows us to get input from the user
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // We can create a vector 3 object to represent 3D space and control it based on that
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // We can add a force to the rigid body
        rb.AddForce(movement * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            Destroy(other.gameObject);
            ++counter;
            SetCountText();

        }
    }
    void SetCountText()
    {
        score.text = "Score: " + counter.ToString();
    }
}
