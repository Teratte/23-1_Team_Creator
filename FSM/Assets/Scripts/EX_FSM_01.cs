using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_FSM_01 : MonoBehaviour
{
    private delegate void StateDelegate(Event _event);

    private State currentState;
 
    public float Speed = 3.0f;
    public float patrolRange = 1.0f;
    private bool Forward = true;

    private Rigidbody2D Rgby;

    private Dictionary<State, StateDelegate> stateMap;
    void Start()
    {
        Rgby = GetComponent<Rigidbody2D>();
        InitializeFSM();
        ChangeState(State.Idle);
        StartCoroutine(UpdateState()); //Update안에 넣어도 되는데, 너무 자주 불리면 예제 로그 보기 어려워서 따로 만듦
        StartCoroutine(TestCode_Change2Patrol()); //2초뒤에 Patrol로 천이
    }

    IEnumerator TestCode_Change2Patrol()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        ChangeState(State.Patrol);
    }
    
    void InitializeFSM()
    {
        stateMap = new Dictionary<State, StateDelegate>();
        stateMap.Add(State.Idle, new StateDelegate(State_Idle));
        stateMap.Add(State.Patrol, new StateDelegate(State_Patrol));
        stateMap.Add(State.Chase, new StateDelegate(State_Chase));
        stateMap.Add(State.Attack, new StateDelegate(State_Attack));
        stateMap.Add(State.Death, new StateDelegate(State_Death));
    }

    IEnumerator UpdateState()
    {
        while (true)
        {
            if (stateMap.ContainsKey(currentState))
            {
                stateMap[currentState](Event.Update);
            }

            yield return new WaitForSecondsRealtime(1.0f);   
        }
    }

    void ChangeState(State NextState)
    {
        if (stateMap.ContainsKey(currentState))
        {
            stateMap[currentState](Event.Exit);
        }

        currentState = NextState;
        
        if (stateMap.ContainsKey(currentState))
        {
            stateMap[currentState](Event.Enter);
        }
    }
    
    void State_Idle(Event _event)
    {
        switch (_event)
        {
            case Event.Enter:
            {
                Debug.Log("State_Idle의 Enter!");
                break;   
            }
            case Event.Update:
            {
                Debug.Log("State_Idle의 Update!");
                break;   
            }
            case Event.Exit:
            {
                Debug.Log("State_Idle의 Exits!");
                break;   
            }
        }
    }
    
    void State_Patrol(Event _event)
    {
        switch (_event)
        {
            case Event.Enter:
            {
                Debug.Log("State_Patrol의 Enter!");
                break;   
            }
                break;
            case Event.Update:
            {
                Debug.Log("State_Patrol의 Update!");
                float moveDirection = Forward ? 1.0f : -1.0f;

                Rgby.velocity = new Vector2(Rgby.velocity.x, moveDirection * Speed);

                if (transform.position.y >= patrolRange)
                {
                    Forward = false;
                }
                else if (transform.position.y <= -patrolRange)
                {
                    Forward = true;
                }
                break;
            }
            case Event.Exit:
            {
                Debug.Log("State_Patrol의 Exit!");
                break;
            }
        }
    }
    void State_Chase(Event _event)
    {
        switch (_event)
        {
            case Event.Enter:
                {
                    Debug.Log("State_Chase의 Enter!");
                    break;
                }
            case Event.Update:
                {
                    Debug.Log("State_Chase의 Update!");
                    break;
                }
            case Event.Exit:
                {
                    Debug.Log("State_Chase의 Exits!");
                    break;
                }
        }
    }
    void State_Attack(Event _event)
    {
        switch (_event)
        {
            case Event.Enter:
                {
                    Debug.Log("State_Attack의 Enter!");
                    break;
                }
            case Event.Update:
                {
                    Debug.Log("State_Attack의 Update!");
                    break;
                }
            case Event.Exit:
                {
                    Debug.Log("State_Attack의 Exits!");
                    break;
                }
        }
    }
    void State_Death(Event _event)
    {
        switch (_event)
        {
            case Event.Enter:
                {
                    Debug.Log("State_Death의 Enter!");
                    break;
                }
            case Event.Update:
                {
                    Debug.Log("State_Death의 Update!");
                    break;
                }
            case Event.Exit:
                {
                    Debug.Log("State_Death의 Exits!");
                    break;
                }
        }
    }
}
