using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolItemUI : MonoBehaviour {
	public string key = "WaterBottle";
	private bool m_isEnter=false;
	private bool m_isFollow = false;
	private RectTransform m_rectTrans;
	private Transform m_parent;
	public RectTransform m_root;
	public void OnEnter(){
		m_isEnter = true;
	}
	public void OnExit(){
		m_isEnter = false;
	}

	// Use this for initialization
	void Start () {
		m_rectTrans = GetComponent<RectTransform>();
		m_parent = this.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Debug.Log(m_isEnter);
		}
		if(m_isEnter && Input.GetMouseButtonDown(0)){
			this.transform.parent = m_parent.parent;
			Debug.Log("down");
			m_rectTrans.anchorMin = new Vector2(0.5f, 0.5f);
			m_rectTrans.anchorMax = new Vector2(0.5f, 0.5f);
			m_isFollow = true;
			this.GetComponent<Image>().raycastTarget = false;
			//
			object[] p = new object[1];
			p[0] =(object)this;
			GameStateManager.Instance().FSM.GlobalState.Message("SelectToolItem", p);
		}
		if(m_isFollow && Input.GetMouseButtonUp(0)){
			
			GameStateManager.Instance().FSM.GlobalState.Message("TryUseWaterBottle", null);
		}
		if(m_isFollow){
			Follow();
		}
	}
	public void Reset(){
		Debug.Log("reset");
		m_isFollow = false;
		m_isEnter = false;
		this.transform.parent = m_parent;
		this.GetComponent<Image>().raycastTarget = true;
	}
	void Follow(){
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
		Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
		Vector2 sp = new Vector2(screenPos.x, screenPos.y);
		Vector2 aPos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			m_root, sp, null, out aPos);
		m_rectTrans.anchoredPosition = aPos;
	}
}
