using UnityEngine;
using System.Collections;

public class StudyRoomUI : MonoBehaviour {

	public void OnOutClick(){
		GameStateManager.Instance().FSM.CurrentState.Message("Out", null);
	}
}
