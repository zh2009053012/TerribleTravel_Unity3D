using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateStart : IStateBase {

	private GameStateStart()
	{}

	private static GameStateStart m_instance;
	private static object m_lockHelper = new object();
	public static GameStateStart Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateStart ();
				}
			}
		}
		return m_instance;
	}
	//
	GameStart m_owner;
	GameObject go;
	public void Enter(GameStateBase owner)
	{
		m_owner = (GameStart)owner;
		EventConfig.Config();
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("StartCanvas")as GameObject;
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
		if (message.Equals ("Play")) {
			SceneManager.LoadScene ("Scene1");
		}
	}
}
