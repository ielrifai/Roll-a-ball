using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePickup : MonoBehaviour
{
    public GameObject pickup;
    public GameObject player;
    public float speed;
    private Rigidbody rb;
    private int counter;
    public Text score;

    Material colour1;
    Material colour2;
    Material colour3;

    float angle = 360f / 8;
    // Use this for initialization
    void Start()
    {

        Vector3 pos = gameObject.transform.position;

        rb = GetComponent<Rigidbody>();

        GameObject Pickup1 = Instantiate(pickup, new Vector3(-0.54f, 0.5f, 6.5f), Quaternion.identity);
        GameObject Pickup2 = Instantiate(pickup, new Vector3(4.6f, 0.5f, 5.7f), Quaternion.identity);
        GameObject Pickup3 = Instantiate(pickup, new Vector3(5.65f, 0.5f, 2f), Quaternion.identity);
        GameObject Pickup4 = Instantiate(pickup, new Vector3(4.8f, 0.5f, -3f), Quaternion.identity);
        GameObject Pickup5 = Instantiate(pickup, new Vector3(-1.8f, 0.5f, -4.5f), Quaternion.identity);
        GameObject Pickup6 = Instantiate(pickup, new Vector3(-6f, 0.5f, -2.15f), Quaternion.identity);
        GameObject Pickup7 = Instantiate(pickup, new Vector3(-6.25f, 0.5f, 2f), Quaternion.identity);
        GameObject Pickup8 = Instantiate(pickup, new Vector3(-4.6f, 0.5f, 5f), Quaternion.identity);


        Pickup1.GetComponent<Renderer>().material.color = Color.green;
        Pickup2.GetComponent<Renderer>().material.color = Color.green;
        Pickup3.GetComponent<Renderer>().material.color = Color.blue;
        Pickup4.GetComponent<Renderer>().material.color = Color.blue;
        Pickup5.GetComponent<Renderer>().material.color = Color.blue;
        Pickup6.GetComponent<Renderer>().material.color = Color.yellow;
        Pickup7.GetComponent<Renderer>().material.color = Color.yellow;
        Pickup8.GetComponent<Renderer>().material.color = Color.yellow;

    }

    void FixedUpdate()
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
            if (other.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                counter += 3;
            }
            else if (other.gameObject.GetComponent<Renderer>().material.color == Color.blue)
            {
                counter += 4;
            }
        }

    }

    void SetCountText()
    {
        score.text = "Score: " + counter.ToString();
    }


}