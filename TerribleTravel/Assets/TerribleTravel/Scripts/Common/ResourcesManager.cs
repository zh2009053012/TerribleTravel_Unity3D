using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesManager : MonoBehaviour {
	private static ResourcesManager m_instance;
	public static ResourcesManager Instance{
		get{
			if (null == m_instance) {
				m_instance = GameObject.FindObjectOfType<ResourcesManager> ()as ResourcesManager;
				if (null == m_instance) {
					GameObject prefab = Resources.Load ("ResourcesLoadCanvas")as GameObject;
					GameObject go = GameObject.Instantiate (prefab);
					m_instance = go.GetComponent<ResourcesManager> ();
				}
			}
			return m_instance;
		}
	}

	void Awake(){
		DontDestroyOnLoad (this);
	}

	//
	[SerializeField]
	protected  GameObject m_imageBG;
	//
	public class LoadParameter{
		public string path;
		public System.Action<Object> callback;
		public LoadParameter(){
			path = "";
			callback = null;
		}
		public LoadParameter(string path, System.Action<Object> callback){
			this.path = path;
			this.callback = callback;
		}
	}
	protected List<LoadParameter> m_list = new List<LoadParameter> ();
	protected bool m_isLoading = false;

	public void Load(string path, System.Action<Object> callback){
		if (m_isLoading) {
			m_list.Add (new LoadParameter (path, callback));
		} else {
			m_isLoading = true;
			m_imageBG.SetActive (true);
			StartCoroutine(DoLoad(path, callback));
		}
	}
	IEnumerator DoLoad(string path, System.Action<Object> callback){
		ResourceRequest req = Resources.LoadAsync<Object>(path);
		yield return req;
		if(null != callback){
			callback.Invoke (req.asset);
		}
		//
		if (m_list.Count > 0) {
			LoadParameter lp = m_list [0];
			m_list.RemoveAt (0);
			StartCoroutine (DoLoad (lp.path, lp.callback));
		} else {
			m_isLoading = false;
			m_imageBG.SetActive (false);
		}
	}
}
