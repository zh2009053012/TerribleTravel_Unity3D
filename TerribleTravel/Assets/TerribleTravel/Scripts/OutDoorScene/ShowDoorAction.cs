using UnityEngine;
using System.Collections;

public class ShowDoorAction : ActionBase {
	public GameObject OutDoorCanvas;
	public GameObject DoorCanvas;
	public ParticleSystem LensWetness;
	public ParticleSystem BigRainSystem;
	public ParticleSystem SmallRainSystem;
	public ParticleSystem CloudSystem;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Play(int eventID){
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		Debug.Log ("play");
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		if (null != OutDoorCanvas) {
			OutDoorCanvas.gameObject.SetActive (false);
		}
		if (null != DoorCanvas) {
			DoorCanvas.gameObject.SetActive (true);
		}
		if (null != LensWetness) {
			LensWetness.loop = false;
		}
		if (null != BigRainSystem) {
			BigRainSystem.loop = false;
		}
		if (null != SmallRainSystem) {
			SmallRainSystem.gameObject.SetActive (true);
		}
		if (null != CloudSystem) {
			CloudSystem.loop = false;
		}
		NotifyActionOverEvent ();
	}
}
