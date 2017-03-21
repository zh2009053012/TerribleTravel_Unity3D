using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateMenu : IStateBase {

	private GameStateMenu()
	{}

	private static GameStateMenu m_instance;
	private static object m_lockHelper = new object();
	public static GameStateMenu Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateMenu ();
				}
			}
		}
		return m_instance;
	}
	//
	GameMenu m_owner;
	GameObject go;
	public void Enter(GameStateBase owner)
	{
		m_owner = (GameMenu)owner;
		CursorManager.SetCursor (CursorManager.CursorState.DEFAULT);
		GameObject prefab = Resources.Load ("MenuCanvas")as GameObject;
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
		Debug.Log ("exit GameStateMenu");
	}

	public void Message(string message, object[] parameters)
	{
		if (message.Equals ("Play")) {
			SceneManager.LoadScene ("GameScene");
		}
	}
}
