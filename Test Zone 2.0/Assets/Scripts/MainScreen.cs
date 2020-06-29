using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainScreen : MonoBehaviour
{
	#region Все переменые
	public GameObject Canvas;		//Основной канвас
	public GameObject Tup;			//Кнопка с часами
	public Text Counter;			//Счетчик
	public float score = 0;			//Общий счет
	public float bonus = 1;			//Прибавляемый бонус
	public float strength = 2;		//Прочность часов
	public float damage = 1;		//Урон
	public float bonuseIfCrash = 2; //Бонус при доламывании часов
	public GameObject FlyTextParent, FlyTextPrefab;         //Родитель текстов и Префаб
	private int FlyNum;										//Величина массива
	private FlyScale[] FlyTextPool = new FlyScale[30];      //Массив вылетающих текстов
	#endregion
	void Start()
	{
        #region Загрузки данных
        score = PlayerPrefs.GetFloat("Score+", score);  //Загружает счет
		bonus = PlayerPrefs.GetFloat("Bonuse+", bonus); //Загружает бонус
		strength = PlayerPrefs.GetFloat("Strength+", strength); //Загружает прочность
		damage = PlayerPrefs.GetFloat("Damage+", damage); //Загружает урон
		bonuseIfCrash = PlayerPrefs.GetFloat("BonuseIfCrash+", bonuseIfCrash); //Загружает урон при доламывании
        #endregion
        Counter.text = "Счет: " + score;
		for (int i = 0; i < FlyTextPool.Length; i++) //Заполнение массива Префабами вылетающего текста
		{
			FlyTextPool[i] = Instantiate(FlyTextPrefab, FlyTextParent.transform).GetComponent<FlyScale>();
		}
	}
	void Update()
    {
		Counter.text = "Счет: " + score;
		#region Сохранение Данных
		PlayerPrefs.SetFloat("Score+", score); //Сохраняет счет
		PlayerPrefs.SetFloat("Bonuse+", bonus); //Сохраняет бонус
		PlayerPrefs.SetFloat("Strength+", strength); //Сохраняет прочность
		PlayerPrefs.SetFloat("Damage+", damage); //Сохраняет урон
		PlayerPrefs.SetFloat("BonuseIfCrash+", bonuseIfCrash); //Сохраняет урон при доламывании
		#endregion

	}
	private void Accept(float STG, float DMG, float BNS)//Получение новых значений из др Скриптов
	{
		strength = STG;
		damage = DMG;
		bonus = BNS;
	}
	public void OnMouseDown()//При нажатии на "Часы"
	{
		strength -= damage; //Снятие ХП
		if (strength > 0)   //Проверка на то последний это удар или нет
		{//Если не последний:
			score += bonus;                         //+бонус
			Counter.GetComponent<Text>().text = "Счёт: " + score;
			FlyTextPool[FlyNum].StartMotion(bonus); //Добавление в окно вылетающего текста цифры
			if (FlyNum == FlyTextPool.Length - 1)   //Танцы с правильным заполнением массива
			{
				FlyNum = 0;
			}
			else
				FlyNum++;
		}
		else
		{//Если последний:
			strength = 2;
			score += bonuseIfCrash;
			FlyTextPool[FlyNum].StartMotion(bonuseIfCrash);
			if (FlyNum == FlyTextPool.Length - 1)
			{
				Counter.GetComponent<Text>().text = "Счёт: " + score;
				FlyTextPool[FlyNum].StartMotion(bonuseIfCrash);
				if (FlyNum == FlyTextPool.Length - 1)
				{
					FlyNum = 0;
				}
				else
					FlyNum++;
				Destroy(gameObject, 0.01f);
				Instantiate(Tup, Canvas.transform);
			}
		}
	}
}
