using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	public GameObject Stomach;
	public GameObject Brain;
	public GameObject Eye;
	public GameObject Head;
	public GameObject Finger;
	public GameObject Heart;
	public GameObject Coin;
	public GameObject Lung;
	public GameObject Seed;
	public GameObject WaterBottle;

	void Update(){
		
	}

	public void HideAll(){
		ShowStomath (false);
		ShowBrain (false);
		ShowEye (false);
		ShowHead (false);
		ShowFinger(false);
		ShowHeart(false);
		ShowCoin(false);
		ShowLung(false);
		ShowSeed(false);
		ShowWaterBottle(false);
	}
	public void ShowWaterBottle(bool isShow){
		WaterBottle.SetActive(isShow);
	}
	public void ShowSeed(bool isShow){
		Seed.SetActive(isShow);
	}
	public void ShowLung(bool isShow){
		Lung.SetActive(isShow);
	}
	public void ShowCoin(bool isShow){
		Coin.SetActive(isShow);
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
	public void ShowFinger(bool isShow){
		Finger.SetActive(isShow);
	}
	public void ShowHeart(bool isShow){
		Heart.SetActive(isShow);
	}
}
