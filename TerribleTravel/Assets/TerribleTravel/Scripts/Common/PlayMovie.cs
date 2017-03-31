using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {
	public string LoadSceneName="HomeScene";
	#if UNITY_STANDALONE_WIN
	public MovieTexture movTexture;
	#endif
	private bool isPlayed = false;
	private bool isQuit = false;
	private float startTime = 0;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		#if UNITY_STANDALONE_WIN
		if (null != movTexture) {
			movTexture.loop = false;
			if (null != movTexture.audioClip) {
				audioSource = this.gameObject.AddComponent<AudioSource> ();
				audioSource.clip = movTexture.audioClip;
			}
		}
		Debug.Log ("duration:"+movTexture.duration);
		#else
		UnityEngine.SceneManagement.SceneManager.LoadScene (LoadSceneName);
		#endif
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		#if UNITY_STANDALONE_WIN
		if (null == movTexture || isQuit)
			return;
		float height = movTexture.height / (float)movTexture.width * Screen.width;
		GUI.DrawTexture (new Rect(0, 0.5f*(Screen.height-height), Screen.width, height), movTexture, ScaleMode.StretchToFill);

		if (!movTexture.isPlaying && movTexture.isReadyToPlay) {
			if (null != audioSource)
				audioSource.Play ();
			movTexture.Play ();
			isPlayed = true;
			startTime = Time.time;
			StartCoroutine (StopMovie(movTexture.duration));
		}
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetMouseButtonDown(0)) {
			StopPlayMovie ();
		}
		if (isPlayed && Time.time-startTime-movTexture.duration>=0) {
			//StopPlayMovie ();
		}
		#endif
	}
	IEnumerator StopMovie(float second){
		yield return new WaitForSeconds (second);
		StopPlayMovie ();
	}
	void StopPlayMovie()
	{
		#if UNITY_STANDALONE_WIN
		if (null != audioSource)
			audioSource.Stop();
		movTexture.Stop ();
		isQuit = true;
		UnityEngine.SceneManagement.SceneManager.LoadScene (LoadSceneName);
		#endif
	}
}
