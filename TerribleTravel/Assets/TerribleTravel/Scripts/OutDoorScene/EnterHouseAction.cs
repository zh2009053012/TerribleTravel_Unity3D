﻿using UnityEngine;
using System.Collections;

public class EnterHouseAction : ActionBase {

	// Use this for initialization
	void Start () {
	
	}
	
	public override void Play(int eventID){
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		//
		NotifyActionOverEvent ();
	}
}
