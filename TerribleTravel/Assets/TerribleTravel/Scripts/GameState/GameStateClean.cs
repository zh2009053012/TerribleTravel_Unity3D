using UnityEngine;
using System.Collections;

public class GameStateClean : IStateBase {

	private GameStateClean()
	{}

	private static GameStateClean m_instance;
	private static object m_lockHelper = new object();
	public static GameStateClean Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateClean ();
				}
			}
		}
		return m_instance;
	}
	//
	CleanUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("CleanScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<CleanUI> ();
		uiCtr.Init (GameData.HasStomach);
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
		if (message.Equals ("Out")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateKitchen.Instance ());
		} else if (message.Equals ("ShowStomachAniOver")) {
			GameData.HasStomach = true;
			GameStateManager.Instance ().FSM.GlobalState.Message ("GetStomach", null);
		}
	}
}
