using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float nextStateTimer;
    private int state;
    private string stateText;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        nextStateTimer = 2;

        anim = GetComponent<Animator>();
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

        if( state == 0 )
        {
            Idle();

            if( nextStateTimer < 0 )
            {
                state = 1;
                nextStateTimer = 2;
            }
        }

        if( state == 1 )
        {

            Turn();
            if( nextStateTimer < 0 )
            {
                state = 2;
                nextStateTimer = 10;
            }

        }

        if( state == 2 )
        {
            if( nextStateTimer < 0 )
            {
                state = 0;
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
        print("Turn");
        stateText = "Turn";
    }

    void Walk()
    {
        anim.SetBool("walk", true);
        print("Walk");
        stateText = "Walk";
    }





    void OnGUI ()
    {
        string content = nextStateTimer.ToString();
        string state = stateText;
        GUILayout.Label($"<color='black'><size=40>State= {state}\n{content}</size></color>");
    }
}

