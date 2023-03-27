using UnityEngine;

public class CameraFollow2D : MonoBehaviour {

	[SerializeField] private Transform target;

	[SerializeField] private float cameraSmooth = 1f;
	[SerializeField] private float cameraZ = -10f;

	[SerializeField] private bool useFixedUpdate;

	[Header("Horizontal bounds")]
	[SerializeField] private bool hasHorizontalBounds;
	[SerializeField] private float minX, maxX;

	[Header("Vertical bounds")]
	[SerializeField] private bool hasVerticalBounds;
	[SerializeField] private float minY, maxY;

	private void FixedUpdate() {
		if (useFixedUpdate)
			FollowTarget(Time.deltaTime);
	}

	private void LateUpdate() {
		if (!useFixedUpdate)
			FollowTarget(Time.fixedDeltaTime);
	}

	private void FollowTarget(float deltaTime) {
		Vector3 targetVector = Vector3.forward * cameraZ + target.position;

		targetVector = Vector3.Lerp(transform.position, targetVector, cameraSmooth * deltaTime);

		if (hasHorizontalBounds)
			targetVector.x = Mathf.Clamp(targetVector.x, minX, maxX);

		if (hasVerticalBounds)
			targetVector.y = Mathf.Clamp(targetVector.y, minY, maxY);

		transform.position = targetVector;
	}
}