using UnityEngine;
using System.Collections;

public class GameStateOutDoor : IStateBase {


	private GameStateOutDoor()
	{}

	private static GameStateOutDoor m_instance;
	private static object m_lockHelper = new object();
	public static GameStateOutDoor Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateOutDoor ();
				}
			}
		}
		return m_instance;
	}
	//
	GameObject go;
	public void Enter(GameStateBase owner)
	{
		GameObject prefab = Resources.Load ("OutDoorScene")as GameObject;
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

	}
}
