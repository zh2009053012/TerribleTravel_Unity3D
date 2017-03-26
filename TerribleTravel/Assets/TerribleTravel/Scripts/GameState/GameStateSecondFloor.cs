using UnityEngine;
using System.Collections;

public class GameStateSecondFloor : IStateBase {

	private GameStateSecondFloor()
	{}

	private static GameStateSecondFloor m_instance;
	private static object m_lockHelper = new object();
	public static GameStateSecondFloor Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateSecondFloor ();
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
		GameObject prefab = Resources.Load ("SecondFloorScene")as GameObject;
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
		if (message.Equals ("Balcony")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateBalcony.Instance ());
		} else if (message.Equals ("Study")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateStudyRoom.Instance ());
		} else if (message.Equals ("DaughterRoom")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateDaughterRoom.Instance ());
		} else if (message.Equals ("BathRoom")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateBathRoom.Instance ());
		} else if (message.Equals ("MainBedRoom")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateMainRoom.Instance ());
		} else if (message.Equals ("Out")) {
			GameStateManager.Instance ().FSM.ChangeState (GameStateHall.Instance ());
		}
	}
}
