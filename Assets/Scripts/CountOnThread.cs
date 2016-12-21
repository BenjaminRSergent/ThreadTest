using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class CountOnThread : MonoBehaviour {
	public bool useNative = true;
	private Text _text;

	Dispatcher.Callback cntCallback;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		cntCallback = new Dispatcher.Callback(ShowCount);
		NativeWrapper.StartThread (cntCallback);
	}

	void OnDestroy() {
		NativeWrapper.StopThread ();
	}

	void ShowCount(int cnt) {
		Debug.Log ("Got native callback with " + cnt);
		Dispatcher.Instance.dispatch(() => _text.text = "" + cnt);		
	}
}
