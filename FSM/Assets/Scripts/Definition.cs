using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None,
    Idle,
    Patrol,
    Chase,
    Attack,
    Death
}

public enum Event
{
    Enter,
    Update,
    Exit
}