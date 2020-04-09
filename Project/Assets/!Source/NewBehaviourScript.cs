using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GameCore;
using ParametersConstant;

public class NewBehaviourScript : MyBaseMonoBehaviour
{

	// Use this for initialization

	private RunLoop runLoop;
	private Text bornText;
	private Text deadText;
	private Text peoplsText;

	void Start () {
		this.runLoop = BaseRunLoopBuilder.Build();
		this.bornText = this.GetComponent<Text>("bornPeoplsText");
		this.deadText = this.GetComponent<Text>("deadPeoplsText");
		this.peoplsText = this.GetComponent<Text>("peoplsText");

		var button = this.GetComponent<Button>("myButton");

		button.onClick.AddListener(() => {
			print("step");
			runLoop.Step();
			this.Show();
		});
	}
	
	void Show()
	{
		this.peoplsText.text = $"Всего { this.runLoop.context.storage.Fetch<DoubleValueContainer>(GlobalBaseKey.numberOfPeopls).value}";
		this.bornText.text = $"Родилось { this.runLoop.context.storage.Fetch<DoubleValueContainer>(GlobalBaseKey.numberOfBirths).value}";
		this.deadText.text = $"Умерло { this.runLoop.context.storage.Fetch<DoubleValueContainer>(GlobalBaseKey.numberOfDeaths).value}";
	}
	// Update is called once per frame
	void Update ()
    {

	}

}

public class MyBaseMonoBehaviour: MonoBehaviour
{

	public ResultType GetComponent<ResultType>(string identifier) where ResultType: MonoBehaviour
	{
		var companant = this.gameObject.GetComponent<ResultType>();
		if (companant != null)
		{
			return companant;
		}
		var companants = gameObject.GetComponentsInChildren<ResultType>();
		foreach (var companent in companants)
		{
			if (companent.name == identifier)
			{
				return companent;
			}
		}
		return null;
	}

}
