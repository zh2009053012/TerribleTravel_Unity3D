using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	public GameObject Stomach;
	public GameObject Brain;
	public GameObject Eye;
	public GameObject Head;
	public void HideAll(){
		ShowStomath (false);
		ShowBrain (false);
		ShowEye (false);
		ShowHead (false);
	}
	public void ShowStomath(bool isShow){
		Stomach.SetActive (isShow);
	}
	public void ShowBrain(bool isShow){
		Brain.SetActive (isShow);
	}
	public void ShowEye(bool isShow){
		Eye.SetActive (isShow);
	}
	public void ShowHead(bool isShow){
		Head.SetActive (isShow);
	}
}
