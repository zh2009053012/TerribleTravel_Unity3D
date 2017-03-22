using UnityEngine;
using System.Collections;

public class DiningUI : MonoBehaviour {
	public GameObject Picture;
	public GameObject PictureHit;
	public AudioClip pictureAudio;
	public void Init(bool haveEye){
		if (haveEye) {
			PictureHit.SetActive (false);
		}
	}

	public void OnOutClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Out", null);
	}
	public void OnTableClick(){
		GameStateManager.Instance ().FSM.CurrentState.Message ("Table", null);
	}
	public void OnPictureClick(){
		Picture.SetActive (true);
		AudioManager.Instance.PlayAudio (pictureAudio, false);
	}
}
