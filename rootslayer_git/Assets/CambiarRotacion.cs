using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarRotacion : MonoBehaviour
{
	[SerializeField] private Camera camera2;
	[Header("MovimientoCamara")]
		[SerializeField] private Vector3 objetivo;
	
	public Animator animator;
	public float delay = 0.3f;
	private bool attackBlocked;
	
	
	private void Update()
	{
		objetivo = camera2.ScreenToWorldPoint(Input.mousePosition);
		
		float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
		float anguloGrados = (180/Mathf.PI) * anguloRadianes - 90;
		transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
	}
	
	public void Attack()
	{
		if (attackBlocked)
			return;
		animator.SetTrigger("Attack");
		attackBlocked = true;
		StartCoroutine(DelayAttack());
	}
	
	private IEnumerator DelayAttack()
	{
		yield return new WaitForSeconds(delay);
		attackBlocked = false;
	}
}