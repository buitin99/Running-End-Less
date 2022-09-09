using UnityEngine;

public class RestartRunning : StateMachineBehaviour
{
	static int s_DeadHash = Animator.StringToHash("Dead");

    public static bool isTrigger;

    public static RestartRunning Instance;

    private void Awake() {
        //Tin Custom
		if (Instance == null)
		{
			Instance = this;
        }	
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // We don't restart if we go toward the death state
        if (animator.GetBool(s_DeadHash))
            return;

           isTrigger = !isTrigger;
        TrackManager.instance.StartMove();
    }

    public bool CheckIsRest()
    {
        return isTrigger;
    }

}
