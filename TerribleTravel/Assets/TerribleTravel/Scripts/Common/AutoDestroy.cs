using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public void AutoDestroyAfterSeconds(float second)
	{
		StartCoroutine (DestroyAfterSecond (second));
	}
	IEnumerator DestroyAfterSecond(float second)
	{
		yield return new WaitForSeconds (second);
		GameObject.Destroy (this.gameObject);
	}
}
