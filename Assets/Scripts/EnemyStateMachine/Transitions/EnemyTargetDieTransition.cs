using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetDieTransition : Transition
{
    private void Update()
    {
        if (Target == null)
        {
            NeedTransite = true;
        }
    }
}
