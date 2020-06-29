using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyShop : MonoBehaviour
{
	public MainScreen Score;    //Счет
	public Button Destroy1;     //Предмет 1
	public Button Destroy2;     //Предмет 2

	void Start() //Убрать интерактивнось всех кнопок
	{
		Destroy1.interactable = false;
		Destroy2.interactable = false;
	}
	void Update() //Проверка на значение счета, после которого кнопка становится активной
	{
		if (Score.score >= 10)
		{
			Destroy1.interactable = true;
		}
		if (Score.score >= 50)
		{
			Destroy2.interactable = true;
		}
	}
	public void ClickOnDestroy1()//При покупке Предмета1
	{
		Score.damage = 2;
		Score.score -= 50;
		if (Destroy1.interactable == true)//Включение интерактивности
		{
			Destroy1.interactable = false;
		}
	}
	public void ClickOnDestroy2()//При покупке Предмета2
	{
		Score.damage = 3;
		Score.score -= 100;
		if (Destroy2.interactable == true)
		{
			Destroy2.interactable = false;
		}
	}
}
