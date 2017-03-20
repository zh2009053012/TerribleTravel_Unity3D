using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour {

	public void PlayBtnClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Play", null);
	}
}
