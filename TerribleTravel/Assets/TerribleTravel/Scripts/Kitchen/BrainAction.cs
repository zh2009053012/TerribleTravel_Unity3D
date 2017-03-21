using UnityEngine;
using System.Collections;

public class BrainAction : ActionBase {
	public IceboxUI uiCtr;
	public override void Play ()
	{
		base.Play ();
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowBrain", null);
	}
	public void ShowBrainAniOver(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("ShowBrainAniOver", null);
	}
}
