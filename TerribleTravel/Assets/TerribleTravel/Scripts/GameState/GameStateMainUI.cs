using UnityEngine;
using System.Collections;

public class GameStateMainUI : IStateBase {

	private GameStateMainUI()
	{}

	private static GameStateMainUI m_instance;
	private static object m_lockHelper = new object();
	public static GameStateMainUI Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateMainUI ();
				}
			}
		}
		return m_instance;
	}
	//
	MainUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		GameObject prefab = Resources.Load ("MainUICanvas")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<MainUI> ();
		uiCtr.HideAll ();

	}

	public void Execute(GameStateBase owner)
	{

	}

	public void Exit(GameStateBase owner)
	{
		if (null != uiCtr) {
			GameObject.Destroy (uiCtr.gameObject);
			uiCtr = null;
		}
	}

	public void Message(string message, object[] parameters)
	{
		Debug.Log ("GameStateMainUI::Message:"+message);
		if (message.Equals ("GetBrain")) {
			uiCtr.ShowBrain (true);
		} else if (message.Equals ("GetStomach")) {
			uiCtr.ShowStomath (true);
		} else if (message.Equals ("GetEye")) {
			uiCtr.ShowEye (true);
		} else if (message.Equals ("GetHead")) {
			uiCtr.ShowHead (true);
		}
	}
}
