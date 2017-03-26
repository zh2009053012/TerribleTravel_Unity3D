using UnityEngine;
using System.Collections;

public class BathRoomUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnOutClick(){
		GameStateManager.Instance().FSM.CurrentState.Message("Out", null);
	}
}
