using UnityEngine;
using System.Collections;

public class ItemRebounce : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetBool("Grounded"))
        {
            UnityEngine.Random rnd = new UnityEngine.Random();
            //animator.GetComponentInParent<Rigidbody>().AddForce(new Vector3(rnd.RandomRange(-1.0f, 1.0f), rnd.RandomRange(-20.0f, 20.0f), rnd.RandomRange(-1.0f, 1.0f));
            animator.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0f, 20f, 0f));
            animator.SetBool("Grounded", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
