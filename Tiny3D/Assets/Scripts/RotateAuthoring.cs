using UnityEngine;
using Unity.Entities; // required for Baker, IComponentData, etc.
using Unity.Transforms; // for TransformUsageFlags

namespace Tiny3D
{
	public class RotateAuthoring : MonoBehaviour
	{
		public Vector3 rotationSpeed = new Vector3(0, 30f, 0);

		public class RotateAuthoringBaker : Baker<RotateAuthoring>
		{
			public override void Bake(RotateAuthoring authoring)
			{
				Debug.Log("Baking...");
				var entity = GetEntity(TransformUsageFlags.Dynamic);

				AddComponent(entity, new Rotate
				{
					speedX = authoring.rotationSpeed.x,
					speedY = authoring.rotationSpeed.y,
					speedZ = authoring.rotationSpeed.z
				});
			}
		}
	}
}
