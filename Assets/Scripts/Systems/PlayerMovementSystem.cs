using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerMovementSystem : ComponentSystem 
{
	private struct Filter
	{
		public Transform Transform;
		public PlayerMovementComponent PlayerMovementComponent;
	}
	
	protected override void OnUpdate()
	{
		var dt = Time.deltaTime;
		foreach (var entity in GetEntities<Filter>())
		{
			entity.Transform.Translate(new Vector3(entity.PlayerMovementComponent.Horizontal, entity.PlayerMovementComponent.Vertical,0)*entity.PlayerMovementComponent.speed*dt,Space.World);


			entity.Transform.rotation = entity.PlayerMovementComponent.Rotation;
		}
	}
}
