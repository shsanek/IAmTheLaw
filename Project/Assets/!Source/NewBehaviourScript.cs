using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GameCore;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization

	private RunLoop runLoop;

	void Start () {
		this.runLoop = BaseRunLoopBuilder.Build();
		var button = gameObject.GetComponentInChildren<Button>();
		button.onClick.AddListener(() => {
			print("step");
			runLoop.Step();
		});
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

}