using UnityEngine;
using System.Collections;

public class SimpleCameraMoving : MonoBehaviour 
{
	//Делаем так, что бы наше private поле было видно в инспекторе
	[SerializeField]
	private Transform Hero;
	
	private Vector2 _startPoint;

	void Awake()
	{
		//Запоминаем начальное положение героя
		_startPoint = Hero.position;
	}
	
	void Update () 
	{
		//двигаем камеру за героем, 
		//сохраняя положение героя относительно камеры
		transform.position = new Vector3( Hero.position.x - _startPoint.x/2, 
		                                 transform.position.y, transform.position.z);
	}
}
