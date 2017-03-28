using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour {
	public delegate void MessageCallbackEvent();

	public Text m_messageText;
	public Image m_bg;
	public Image m_maskImage;
	private float m_showTime;
	private bool m_isHitClose = true;
	private MessageCallbackEvent m_callback;

	private static GameObject prefab;
	public static MessageUI AutoShowMessage(string msg, bool hasMask, MessageCallbackEvent e, float showTime){
		//Debug.Log("msg uui");
		if(null == prefab)
			prefab = Resources.Load ("MessageCanvas")as GameObject;
		GameObject go = GameObject.Instantiate (prefab);
		MessageUI uiCtr = go.GetComponent<MessageUI> ();
		uiCtr.ShowMessage (msg, hasMask, e, showTime);
		return uiCtr;
	}

	public void Init()
	{
		m_messageText.text = "";
		m_callback = null;
		this.gameObject.SetActive(false);
	}
	public void ShowMessage(string message, bool hasMask, MessageCallbackEvent e, float showTime=3)
	{
		m_maskImage.gameObject.SetActive (hasMask);
		m_callback = e;
		m_isHitClose = false;
		//m_messageText.color = Color.white;
		SetMessage(message);
		this.gameObject.SetActive(true);

		StartCoroutine(Hide(showTime));
	}
	public void ShowMessage(string message, bool hasMask, float showTime=3)
	{
		m_maskImage.gameObject.SetActive (hasMask);
		m_callback = null;
		m_isHitClose = true;
		//m_messageText.color = Color.white;
		SetMessage(message);
		this.gameObject.SetActive(true);
		StartCoroutine(Hide(showTime));
//		AutoDestroy adCtr = this.gameObject.AddComponent<AutoDestroy> ();
//		adCtr.AutoDestroyAfterSeconds (showTime);
	}
	public void ShowMessage(string message, Color color, float showTime, bool isHitClose, MessageCallbackEvent e)
	{
		m_maskImage.gameObject.SetActive (true);
		m_callback = e;
		m_isHitClose = isHitClose;
		m_messageText.color = color;
		SetMessage(message);
		this.gameObject.SetActive(true);
		StartCoroutine(Hide(showTime));
//		AutoDestroy adCtr = this.gameObject.AddComponent<AutoDestroy> ();
//		adCtr.AutoDestroyAfterSeconds (showTime);
	}

	private void SetMessage(string message)
	{
		//m_maskImage.gameObject.SetActive (true);
		m_messageText.text = message;
		float width = m_messageText.preferredWidth;
		m_messageText.rectTransform.sizeDelta = new Vector2(width, m_messageText.rectTransform.sizeDelta.y);
		m_bg.rectTransform.sizeDelta = new Vector2(width+100, m_bg.rectTransform.sizeDelta.y+40);
	}

	private IEnumerator Hide(float time)
	{
		yield return new WaitForSeconds(time);
		Hide();
	}
	private void Hide()
	{
		if(this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(false);
			if(null != m_callback)
			{
				m_callback.Invoke();
				m_callback = null;
			}
		}
	}

	public void OnCloseBtnClick()
	{
		if(m_isHitClose)
		{
			Hide();
		}
	}
	
}
