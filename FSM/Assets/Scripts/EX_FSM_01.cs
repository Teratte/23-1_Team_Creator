using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_FSM_01 : MonoBehaviour
{
    private delegate void StateDelegate(Event _event);

    private State currentState;
    
    private Dictionary<State, StateDelegate> stateMap;
    void Start()
    {
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
                break;
            }
            case Event.Exit:
            {
                Debug.Log("State_Patrol의 Exit!");
                break;
            }
        }
    }
}