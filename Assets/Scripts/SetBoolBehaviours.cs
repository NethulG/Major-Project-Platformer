using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolBehaviours : StateMachineBehaviour
{
    public string boolName;
    public bool valueEnter, valueExit;
    public bool updateStateMachine;
    public bool updateState;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateState)
        {
            animator.SetBool(boolName, valueEnter);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateState)
        {
            animator.SetBool(boolName, valueExit);
        }
    }

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateStateMachine) // ensures the bools only change when the statemachine is entered
            animator.SetBool(boolName, valueEnter);
        
        
    }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateStateMachine)
            animator.SetBool(boolName, valueExit);
    }
}
