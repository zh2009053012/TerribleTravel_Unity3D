using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComputerCtr : MonoBehaviour {
	public Text m_numText;
	public GameObject m_lockGO;
	public GameObject m_unlockGO;
	public GameObject m_inputNumGO;
	public GameObject m_inputChar;
	public GameObject m_inputFieldHit;
	public GameObject m_closeComputerGO;
	public GameObject m_openComputerGO;
	public AudioClip m_unlockAudioClicp;
	public AudioClip m_inputAudioClicp;

	void OnEnable(){
		m_inputChar.SetActive(true);
		m_numText.text = "";
		m_inputFieldHit.SetActive(true);
		m_inputNumGO.SetActive(false);
	}
	MessageUI uiCtr;
	public void OnLockClick(){
		AudioManager.Instance.PlayAudio(m_unlockAudioClicp, false);
		if(m_numText.text.Equals("0607"))
		{
			m_lockGO.SetActive(false);
			m_unlockGO.SetActive(true);
			StartCoroutine(UnlockOver(m_unlockAudioClicp.length));
		}else{
			m_numText.text = "";
			m_inputChar.SetActive(true);
			uiCtr = MessageUI.AutoShowMessage("密码一定是重要的东西", true, ()=>{
				if(null != uiCtr){
					GameObject.Destroy(uiCtr.gameObject);
					uiCtr = null;
				}
			}, 2);
		}
	}
	IEnumerator UnlockOver(float second){
		yield return new WaitForSeconds(second);
		m_openComputerGO.SetActive(true);
		m_closeComputerGO.SetActive(false);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
	public void OnInputFieldClick(){
		m_inputFieldHit.SetActive(false);
		m_inputNumGO.SetActive(true);
		CursorManager.SetCursor(CursorManager.CursorState.DEFAULT);
	}
	public void OnNum0Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "0";
		m_inputChar.SetActive(false);
	}
	public void OnNum1Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "1";
		m_inputChar.SetActive(false);
	}
	public void OnNum2Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "2";
		m_inputChar.SetActive(false);
	}
	public void OnNum3Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "3";
		m_inputChar.SetActive(false);
	}
	public void OnNum4Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "4";
		m_inputChar.SetActive(false);
	}
	public void OnNum5Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "5";
		m_inputChar.SetActive(false);
	}
	public void OnNum6Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "6";
		m_inputChar.SetActive(false);
	}
	public void OnNum7Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "7";
		m_inputChar.SetActive(false);
	}
	public void OnNum8Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "8";
		m_inputChar.SetActive(false);
	}
	public void OnNum9Click(){
		AudioManager.Instance.PlayAudio(m_inputAudioClicp, false);
		m_numText.text += "9";
		m_inputChar.SetActive(false);
	}
	public void OnFileClick(){
		Application.Quit();
	}
}
