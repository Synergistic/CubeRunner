using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour {
	
	public Transform prefab;

	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public float minGap, maxGap;
	public float[] possibleBlockHeights;

	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;

	
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		for(int i = 0; i < numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = startPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
	}
	
	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < Runner.distanceTraveled){
			Recycle();
		}
	}
	
	private void Recycle () {
		//Pick Random Size
		Vector3 scale = new Vector3 (1f, (float)Random.Range (1, 3), 1f);

		nextPosition += new Vector3(Random.Range(minGap, maxGap), 0f, 0f);

		if (scale.y == 1f)
			nextPosition.y = possibleBlockHeights [Random.Range (0, 2)];
		else
			nextPosition.y = possibleBlockHeights [Random.Range (2, 4)];

		Vector3 position = nextPosition;

		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		objectQueue.Enqueue(o);

	}
}