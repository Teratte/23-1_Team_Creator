using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None,
    Idle,
    Patrol,
    Attack,
    Death
}

public enum Event
{
    Enter,
    Update,
    Exit
}