using System.Collections;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{

    public float movementSpeed = 10f;

    private Transform wayPoint;
    private int actualWayPoint;

    private void Start() {

        actualWayPoint = 0;
        wayPoint = (Transform) WayPointsArray.points[actualWayPoint];

    }

    private void Update() {

        Vector3 positionWayPoint = wayPoint.position - transform.position;

        transform.Translate(positionWayPoint.normalized * movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoint.position) <= 0.2f) {

            actualWayPoint++;

            if (actualWayPoint >= WayPointsArray.points.Count) {
                StartCoroutine(AutoDestruction()); ;
                return;
            }

            wayPoint = (Transform) WayPointsArray.points[actualWayPoint];

        }

    }

    private IEnumerator AutoDestruction() {

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }

}
