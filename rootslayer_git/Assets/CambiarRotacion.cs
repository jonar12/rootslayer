using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarRotacion : MonoBehaviour
{
	[SerializeField] private Camera camera2;
	[Header("MovimientoCamara")]
	[SerializeField] private Vector3 objetivo;
	
	private void Update()
	{
		objetivo = camera2.ScreenToWorldPoint(Input.mousePosition);
		
		float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
		float anguloGrados = (180/Mathf.PI) * anguloRadianes - 90;
		transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
	}
	
}