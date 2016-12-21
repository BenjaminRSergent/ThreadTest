using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispatcher : MonoBehaviour {
	public static Dispatcher Instance {
		get {
			return _instance;
		}
	}

	public delegate void Callback(int num); 

	static private Dispatcher _instance;
	private List<System.Action> _workList;

	void Awake() {
		_workList = new List<System.Action> ();
		_instance = this;
	}

	// Update is called once per frame
	void Update () {
		List<System.Action> workListCpy;
		lock (_workList) {
			workListCpy = new List<System.Action> (_workList);
			_workList.Clear ();
		}

		foreach(System.Action work in workListCpy) {
			work ();
		}

	}

	public void dispatch(System.Action work) {
		lock (_workList) {
			_workList.Add (work);
		}
	}
}
