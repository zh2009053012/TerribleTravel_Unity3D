using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GameStateMainUI : IStateBase {

	private GameStateMainUI()
	{}

	private static GameStateMainUI m_instance;
	private static object m_lockHelper = new object();
	public static GameStateMainUI Instance()
	{
		if (null == m_instance) {
			lock (m_lockHelper) {
				if (null == m_instance) {
					m_instance = new GameStateMainUI ();
				}
			}
		}
		return m_instance;
	}
	//
	MainUI uiCtr;
	ToolItemUI curSelCtr;
	string m_curEnter="";
	public void Enter(GameStateBase owner)
	{
		GameObject prefab = Resources.Load ("MainUICanvas")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		uiCtr = go.GetComponent<MainUI> ();
		uiCtr.HideAll ();

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
		Debug.Log ("GameStateMainUI::Message:"+message);
		if (message.Equals ("GetBrain")) {
			uiCtr.ShowBrain (true);
		} else if (message.Equals ("GetStomach")) {
			uiCtr.ShowStomath (true);
		} else if (message.Equals ("GetEye")) {
			uiCtr.ShowEye (true);
		} else if (message.Equals ("GetHead")) {
			uiCtr.ShowHead (true);
		} else if(message.Equals("GetFinger")){
			uiCtr.ShowFinger(true);
		} else if(message.Equals("GetHeart")){
			uiCtr.ShowHeart(true);
		} else if(message.Equals("GetCoin")){
			uiCtr.ShowCoin(true);
		}else if(message.Equals("GetLung")){
			uiCtr.ShowLung(true);
		}else if(message.Equals("GetSeed")){
			uiCtr.ShowSeed(true);
		} else if(message.Equals("GetWaterBottle")){
			uiCtr.ShowWaterBottle(true);
		} else if(message.Equals("TryUseWaterBottle")){
			Debug.Log ("key:"+curSelCtr.key+" curEnter:"+m_curEnter);
//			if(curSelCtr.key.Equals(m_curEnter)){
//				curSelCtr.Reset();
//				GameData.HasWaterBottle = false;
//				uiCtr.ShowWaterBottle(false);
//				GameStateManager.Instance().FSM.CurrentState.Message("UseWaterBottle", null);
//			}else{
//				curSelCtr.Reset();
//			}
			if (CheckPointerOverGameObject (curSelCtr.key)) {
				curSelCtr.Reset();
				GameData.HasWaterBottle = false;
				uiCtr.ShowWaterBottle(false);
				GameStateManager.Instance().FSM.CurrentState.Message("UseWaterBottle", null);
			} else {
				curSelCtr.Reset();
			}
			//
			curSelCtr = null;
		} else if(message.Equals("SelectToolItem")){
			if(null != curSelCtr){
				curSelCtr.Reset();
			}
			curSelCtr = (ToolItemUI)parameters[0];
		} else if(message.Equals("EnterTarget")){
			m_curEnter = (string)parameters[0];
		}else if(message.Equals("ExitTarget")){
			m_curEnter = "";
		}
	}
	bool CheckPointerOverGameObject(string key){
		PointerEventData eventData = new PointerEventData (EventSystem.current);
		eventData.position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult> ();
		EventSystem.current.RaycastAll (eventData, results);
		Debug.Log ("CheckPointerOverGameObject:"+results.Count);
		foreach (RaycastResult item in results) {
			EventController ctr = item.gameObject.GetComponent<EventController> ();
			Debug.Log (item.gameObject.name);
			if (null != ctr && !string.IsNullOrEmpty(EventConfig.GetEventData(ctr.ID).m_key)) {
				return EventConfig.GetEventData (ctr.ID).m_key.Equals (curSelCtr.key);
			}
		}
		return false;
	}
}
