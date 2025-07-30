
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

namespace Tiny3D
{
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public partial struct RotationSystem : ISystem
	{
		public void OnUpdate(ref SystemState state)
		{
			float deltaTime = SystemAPI.Time.DeltaTime;

			foreach (var (transform, rotSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Rotate>>())
			{
				var rotationEuler = new float3(
					math.radians(rotSpeed.ValueRO.speedX * deltaTime),
					math.radians(rotSpeed.ValueRO.speedY * deltaTime),
					math.radians(rotSpeed.ValueRO.speedZ * deltaTime)
				);

				// Apply rotation in XYZ order
				quaternion additionalRotation = quaternion.Euler(rotationEuler);
				transform.ValueRW.Rotation = math.mul(transform.ValueRW.Rotation, additionalRotation);
			}
		}
	}
}
