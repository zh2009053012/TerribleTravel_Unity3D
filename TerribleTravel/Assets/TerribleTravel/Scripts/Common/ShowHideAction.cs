using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHideAction : ActionBase {
	public GameObject m_next;
	public GameObject m_show;
	public GameObject m_hide;
	public override void Play (int eventID)
	{
		if (m_isPlaying) {
			return;
		} else {
			m_isPlaying = true;
		}
		if (m_next != null) {
			m_next.SetActive (true);
		}
		if (null != m_show) {
			m_show.SetActive (true);
		}
		if (null != m_hide) {
			m_hide.SetActive (false);
		}
		GetComponent<Image> ().raycastTarget = false;
		NotifyActionOverEvent();
	}
}
