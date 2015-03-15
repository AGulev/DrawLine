using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent (typeof (EdgeCollider2D), typeof(LineRenderer))] 
public class DrawLine : MonoBehaviour 
{
	private LineRenderer line;
	private bool isMousePressed;
	private List<Vector2> poinsOfLine;
	private Vector3 mousePos;
	private EdgeCollider2D collider;

	void Awake()
	{
		//кэшируем компоненты
		line = gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount(0);
		isMousePressed = false;
		poinsOfLine = new List<Vector2>();
		collider = gameObject.GetComponent<EdgeCollider2D> ();
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			//если нажата кнопка мыши
			isMousePressed = true;
			//удаляем отрисовку линии
			line.SetVertexCount(0);
			//чистим сохраненные точки
			poinsOfLine.Clear();
			//отключаем физику
			collider.enabled = false;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			isMousePressed = false;
		}
		if(isMousePressed)
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z=0;
			// ограничение, которое позволяет рисовать только слева направо
			if (poinsOfLine.Count > 0 && mousePos.x < poinsOfLine[poinsOfLine.Count - 1].x)
			{
				return;
			}
			//сохраняем текущее расположение мыши
			poinsOfLine.Add (mousePos);
			//передаем точки для отрисовки в linerenderer
			line.SetVertexCount (poinsOfLine.Count);
			line.SetPosition (poinsOfLine.Count - 1, (Vector3)poinsOfLine [poinsOfLine.Count - 1]);
			if (poinsOfLine.Count > 1)
			{
				//создаем физику по нашим точкам
				collider.points = poinsOfLine.ToArray();
				collider.enabled = true;
			}
		}
	}
}