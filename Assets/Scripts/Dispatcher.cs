using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispatcher : MonoBehaviour {
	public static Dispatcher Instance {
		get {
			return _instance;
		}
	}
		
	static private Dispatcher _instance;
	private List<System.Action> _workList;

	void Awake() {
		_workList = new List<System.Action> ();
		_instance = this;
	}

	// Update is called once per frame
	void Update () {
		foreach(System.Action work in _workList) {
			work ();
		}

		_workList.Clear ();
	}

	public void dispatch(System.Action work) {
		_workList.Add (work);
	}
}
