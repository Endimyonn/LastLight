using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelObject : MonoBehaviour
{
    public GameObject travelTrack;
    private List<TravelNode> waypoints = new List<TravelNode>();

    public float speed;

    private List<GameObject> passengers = new List<GameObject>();

    private float stopDelay;
    private float stopDelayRemaining;

    private int curIndex = 0;
    private int maxIndex;

    private State state;

    private void Start()
    {
        foreach (Transform trackNode in travelTrack.transform)
        {
            waypoints.Add(trackNode.GetComponent<TravelNode>());
        }

        stopDelay = waypoints[0].setObjectDelay;
        stopDelayRemaining = stopDelay;

        maxIndex = waypoints.Count - 1;
        state = State.WaitingForDelay;

    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.WaitingForDelay:
                if (stopDelayRemaining > 0)
                {
                    stopDelayRemaining -= Time.fixedDeltaTime;
                }
                else
                {
                    state = State.Moving;
                }
                break;

            case State.Moving:
                if (transform.position == waypoints[curIndex].transform.position)
                {
                    //set speed and delay
                    if (waypoints[NextIndex()].setObjectSpeed >= 0)
                    {
                        speed = waypoints[NextIndex()].setObjectSpeed;
                    }
                    else
                    {
                        Debug.LogWarning("TravelObject " + gameObject.name + " cannot be set to a speed below 0.");
                    }

                    stopDelay = waypoints[NextIndex()].setObjectDelay;
                    stopDelayRemaining = stopDelay;
                    if (stopDelay > 0)
                    {
                        state = State.WaitingForDelay;
                    }

                    IncrementIndex();

                    //start moving during this frame as to not freeze
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[curIndex].transform.position, speed * Time.fixedDeltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[curIndex].transform.position, speed * Time.fixedDeltaTime);
                }

                foreach (GameObject passenger in passengers)
                {
                    passenger.GetComponent<Rigidbody>().velocity += GetComponent<Rigidbody>().velocity;
                }
                break;
        }
    }

    private void IncrementIndex()
    {
        if (curIndex < maxIndex)
        {
            curIndex++;
        }
        else
        {
            curIndex = 0;
        }
    }

    private int NextIndex()
    {
        if (curIndex < maxIndex)
        {
            return (curIndex + 1);
        }
        else
        {
            return 0;
        }
    }

    public void StartMoving()
    {
        if (state == State.Paused)
        {
            if (stopDelayRemaining > 0)
            {
                state = State.WaitingForDelay;
            }
            else
            {
                state = State.Moving;
            }
        }
    }

    public void StartMovingInstant()
    {
        stopDelayRemaining = 0;
        state = State.Moving;
    }

    public void StopMoving()
    {
        state = State.Paused;
    }



    private enum State
    {
        Paused,
        WaitingForDelay,
        Moving
    }
}