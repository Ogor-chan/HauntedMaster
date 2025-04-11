using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusE
{
    strength,
    weakness,
    armored,
    rip,
    burn,
    stun,
    mud,
    bleed
}

public class StatusEffects
{
    public StatusE status;
    public int stack;

    public StatusEffects(StatusE myStatus, int Stack)
    {
        status = myStatus;
        stack = Stack;
    }
}
