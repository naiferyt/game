using System;
using UnityEngine;

public class AgeGatePopup : UghPublisher
{
	private enum MathOperation
	{
		Add = 0,
		Subtract = 1,
		Multiply = 2,
		Divide = 3
	}

	public UghButton button;

	public GameObject enabler;

	private int[] numbers;

	private MathOperation[] operators;

	private int answer;

	private string userInput;

	private string GetOperatorSymbol(MathOperation op)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private int ExecuteOperator(int a, int b, MathOperation op)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void CalcAnswer()
	{
	}

	private void SetupButton(UghButton b, string label, Action callback)
	{
	}

	private void SetupProblem()
	{
	}

	private void AddCharacterToAnswer(string c)
	{
	}

	private void TestAnswer()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
