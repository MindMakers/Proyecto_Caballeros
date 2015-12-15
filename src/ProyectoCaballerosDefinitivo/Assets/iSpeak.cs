using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class iSpeak : MonoBehaviour {

	private string[] texto;
    public string id;
	Text text;
	public float delayText = 6;

	// Use this for initialization
	void Awake () {
		text = GameObject.FindGameObjectWithTag ("TextoHablar").GetComponent<Text>();
	}

    
    public void setArrayConver(string[] x)
    {
        texto = x;

    }
	public void OnTriggerCall()
	{
		text.color = new Color (0, 0, 0, 255);
		StartCoroutine ("ponerTexto");

	}

	public void onTriggerFuera(){
		StopCoroutine ("ponerTexto");
		text.color = new Color (0, 0, 0, 0);
	}

	private IEnumerator ponerTexto()
	{
		for (int i = 0; i < texto.Length; i++) {
			text.text = texto [i]; 
			yield return new WaitForSeconds(delayText);
		}
		text.color = new Color (0, 0, 0, 0);
	}
}
