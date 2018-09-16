using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerInputSystem : ComponentSystem 
{
	private struct Filter
	{
		public PlayerMovementComponent PlayerMovementComponent;
		public Transform Transform;
	}
	
	protected override void OnUpdate()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		var mx = Input.mousePosition.x;
		var my = Input.mousePosition.y;
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mx,my,0));

		foreach (var entity in GetEntities<Filter>())
		{
			entity.PlayerMovementComponent.Horizontal = h;
			entity.PlayerMovementComponent.Vertical = v;

       		entity.PlayerMovementComponent.Rotation =  Quaternion.Euler (new Vector3(0f,0f,AngleBetweenTwoPoints(entity.Transform.position, mouseWorldPosition)+90));

		}
	}

	private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
}
