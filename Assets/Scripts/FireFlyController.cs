using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireFlyController : MonoBehaviour {

    Queue<MoveQueueItem> moveQueue = new Queue<MoveQueueItem>();
    bool isMoving = false;

    // Use this for initialization
    void Start () {
       // Vector3 newTrans = transform.position + new Vector3(0, 1, 0);
       // MoveQueueItem mqi = new MoveQueueItem(newTrans, 5f);
       // moveQueue.Enqueue(mqi);
	}

    public void EmptyQueue()
    {
        moveQueue.Clear();
        /*foreach (MoveQueueItem qi in moveQueue)  {
            moveQueue.Dequeue();
        }*/
    }

    // Update is called once per frame
    void Update () {
	    // look for items in MoveQueue !!!
        if (isMoving == false && moveQueue.Count != 0)
        {
            MoveQueueItem qi = moveQueue.Dequeue();
            Debug.Log("moving firefly to: " + qi.targetPos+ "; in : "+ qi.timeToMove);
            MoveTo(qi.targetPos, qi.timeToMove);
        }

	}

    public void EnqueueMove(Vector3 targetPosition, float timeToMove)
    {
        MoveQueueItem mqi = new MoveQueueItem(targetPosition, timeToMove);
        moveQueue.Enqueue(mqi);
    }

    public void MoveTo(Vector3 targetPosition, float timeToMove) {
        isMoving = true;
        StartCoroutine(SlowlyMoveTo(transform, targetPosition, timeToMove));
    }

    private IEnumerator SlowlyMoveTo(Transform transform, Vector3 targetPosition, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1) {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, targetPosition, t);
            yield return null;
        }
        isMoving = false;
    }

}
