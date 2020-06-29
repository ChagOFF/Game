using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyScale : MonoBehaviour
{
	private bool move;      //Создание движения
	private Vector2 rand;   //Рандомный вектор
	void Update()
	{
		if (!move) return; //Проверка на то, чтобы текст двигался
		transform.Translate(rand * Time.deltaTime); //Перемещение текста в случайном направлении
	}
	public void StartMotion(float Score) //Задает всю инфу тексту
	{
		transform.localPosition = Vector2.zero;                         //Начальная позиция текста по нулям
		GetComponent<Text>().text = "+" + Score;                        //То что выводит текст
		rand = new Vector2(Random.Range(-4, 4), Random.Range(-3, 3));   //Задает случайное направление тексту
		move = true;
		//GetComponent<Animation>().Play();
	}
	public void StopMotion()
	{
		move = false;
	}
}
