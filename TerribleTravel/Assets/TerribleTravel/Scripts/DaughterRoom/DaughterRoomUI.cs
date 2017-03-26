using UnityEngine;
using System.Collections;

public class DaughterRoomUI : MonoBehaviour {

	public void OnOutClick(){
		GameStateManager.Instance().FSM.CurrentState.Message("Out", null);
	}
}
