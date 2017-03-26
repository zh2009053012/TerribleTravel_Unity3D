using UnityEngine;
using System.Collections;

public class BalconyUI : MonoBehaviour {

	public void OnOutClick(){
		GameStateManager.Instance().FSM.CurrentState.Message("Out", null);
	}
}
