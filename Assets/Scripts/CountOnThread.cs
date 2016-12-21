using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class CountOnThread : MonoBehaviour {
	Thread countThread;
	Text text;
	bool done = false;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		countThread = new Thread (new ThreadStart (ThreadLoop));
		countThread.Start ();
	}

	void OnDestroy() {
		done = true;
	}

	void ThreadLoop() {
		int cnt = 0;
		while(!done) {
			cnt++;
			Dispatcher.Instance.dispatch(() => text.text = "" + cnt);

			Thread.Sleep (500);
			Debug.Log ("Cnt is " + cnt);
		}

	}

}
