using UnityEngine;
using System.Collections;

public class GameStateClothing : IStateBase {

	private GameStateClothing()
	{}

	private static GameStateClothing m_instance;
	private static object m_lockHelper = new object();
	public static GameStateClothing Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateClothing ();
				}
			}
		}
		return m_instance;
	}
	//
	ClothingUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("ClothingScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<ClothingUI> ();
		uiCtr.Init (GameData.HasHead);
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
			GameStateManager.Instance ().FSM.ChangeState (GameStateHall.Instance ());
		} else if (message.Equals ("ShowHeadAniOver")) {
			GameData.HasHead = true;
			CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
			GameStateManager.Instance ().FSM.GlobalState.Message ("GetHead", null);
		} 
	}
}
