using UnityEngine;
using System.Collections;

public class GameStateHall : IStateBase {

	private GameStateHall()
	{}

	private static GameStateHall m_instance;
	private static object m_lockHelper = new object();
	public static GameStateHall Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateHall ();
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
		GameObject prefab = Resources.Load ("HallScene")as GameObject;
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
		if (message.Equals ("ClothingRoom")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateNull.Instance ());
		} else if (message.Equals ("Kitchen")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateKitchen.Instance ());
		} else if (message.Equals ("DiningRoom")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateNull.Instance ());
		} else if (message.Equals ("UndergroundGarage")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateNull.Instance ());
		} else if (message.Equals ("SecondFloor")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateSecondFloor.Instance ());
		}
	}
}
