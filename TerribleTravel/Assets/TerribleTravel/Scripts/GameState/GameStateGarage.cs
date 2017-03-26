using UnityEngine;
using System.Collections;

public class GameStateGarage : IStateBase {

	private GameStateGarage()
	{}

	private static GameStateGarage m_instance;
	private static object m_lockHelper = new object();
	public static GameStateGarage Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateGarage ();
				}
			}
		}
		return m_instance;
	}
	//
	GarageUI uiCtr;
	public void Enter(GameStateBase owner)
	{
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("GarageScene")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<GarageUI>();
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
		} else if(message.Equals("UseWaterBottle")){
			uiCtr.DoCleanSeed();
		}
	}
}
