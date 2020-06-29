using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonuseShop : MonoBehaviour
{
	public MainScreen Score;    //Счет
	public Button Bonuse1;      //Бонус 1
	public Button Bonuse2;      //Бонус 2

	void Start() //Убрать интерактивнось всех кнопок
	{
		Bonuse1.interactable = false;
		Bonuse2.interactable = false;
	}
	void Update()
	{

	}
}
