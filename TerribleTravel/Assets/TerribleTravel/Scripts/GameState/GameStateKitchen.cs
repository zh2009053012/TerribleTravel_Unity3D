using UnityEngine;
using System.Collections;

public class GameStateKitchen : IStateBase {

	private GameStateKitchen()
	{}

	private static GameStateKitchen m_instance;
	private static object m_lockHelper = new object();
	public static GameStateKitchen Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateKitchen ();
				}
			}
		}
		return m_instance;
	}
	//
	GameObject go;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("KitchenScene")as GameObject;
		go = GameObject.Instantiate (prefab);
	}

	public void Execute(GameStateBase owner)
	{

	}

	public void Exit(GameStateBase owner)
	{
		if (null != go) {
			GameObject.Destroy (go);
			go = null;
		}
	}

	public void Message(string message, object[] parameters)
	{
		if (message.Equals ("Icebox")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateIcebox.Instance ());
		} else if (message.Equals ("Clean")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateClean.Instance ());
		} else if (message.Equals ("Out")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateHall.Instance ());
		}
	}
}
