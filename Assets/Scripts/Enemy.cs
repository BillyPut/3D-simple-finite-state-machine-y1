using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private float nextStateTimer;
    private string stateText;
    Animator anim;
    private Rigidbody rb;
    public float movementSpeed = 1.5f;
    States mystate;

    enum States
    {
        Idle,
        Turn,
        Walk
    }




    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream:Assets/Scripts/Enemy.cs
        state = 0;
=======
<<<<<<< HEAD:Assets/Player.cs
        mystate = States.Idle;
=======
        state = 0;
>>>>>>> 71769a96a19d685d025f495498b0e54c369d6679:Assets/Scripts/Enemy.cs
>>>>>>> Stashed changes:Assets/Player.cs
        nextStateTimer = 2;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessStates();

    }



    // State logic - switch states depending on what logic we want to apply
    void ProcessStates()
    {
        nextStateTimer -= Time.deltaTime;

        if (mystate == States.Idle)
        {
            Idle();

            if( nextStateTimer < 0 )
            {
                mystate = States.Turn;
                nextStateTimer = 1;
            }
        }

        if (mystate == States.Turn)
        {

            Turn();
            if( nextStateTimer < 0 )
            {
                mystate = States.Walk;
                nextStateTimer = 5;
            }

        }

        if (mystate == States.Walk)
        {
            if( nextStateTimer < 0 )
            {
                mystate = States.Idle;
                nextStateTimer = 5;
            }

            Walk();
        }

    }


    // Different AI Update methods
    void Idle()
    {
        print("Idle");
        stateText = "Idle";
        anim.SetBool("walk", false);
    }

    void Turn()
    {
        float randomTurn = Random.Range(0, 5);


        print("Turn");
        stateText = "Turn";
        transform.Rotate(0, randomTurn, 0, Space.World);
    }

    void Walk()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;




        anim.SetBool("walk", true);
        print("Walk");
        stateText = "Walk";
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Border")
        {
            SceneManager.LoadScene("Demo");
        }


    }



    void OnGUI ()
    {
        string content = nextStateTimer.ToString();
        string state = stateText;
        GUILayout.Label($"<color='black'><size=40>State= {state}\n{content}</size></color>");
    }
}

