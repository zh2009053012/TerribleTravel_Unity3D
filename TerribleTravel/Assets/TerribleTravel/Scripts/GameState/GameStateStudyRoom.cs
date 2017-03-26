using UnityEngine;
using System.Collections;

public class GameStateStudyRoom : IStateBase {


	private GameStateStudyRoom()
	{}

	private static GameStateStudyRoom m_instance;
	private static object m_lockHelper = new object();
	public static GameStateStudyRoom Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateStudyRoom ();
				}
			}
		}
		return m_instance;
	}
	//
	StudyRoomUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("StudyRoomScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<StudyRoomUI> ();

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
			GameStateManager.Instance ().FSM.ChangeState (GameStateSecondFloor.Instance ());
		} 
	}
}
