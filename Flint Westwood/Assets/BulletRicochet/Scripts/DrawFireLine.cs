using UnityEngine;
using System.Collections.Generic;

public class DrawFireLine : MonoBehaviour
{

    [SerializeField] private GameObject dash;
    [SerializeField] private int bounces;
    [SerializeField] private float spaceBetweenDashes;
    [SerializeField] private float lineMaxDistance;
    [SerializeField] private float bounceOffset;
    [SerializeField] private float movementPerSecond;
    [SerializeField] private LayerMask lineHitLayer;

    private List<GameObject> dashPool;
    private Vector3[] bouncePositions;
    private float moveTimer;

    private void Start()
    {

        dashPool = new List<GameObject>();

        bouncePositions = new Vector3[bounces + 2];

    }

    public void DrawLine(Vector3 mousePosition)
    {

        int dashIndex = 0;

        moveTimer += Time.deltaTime;

        if (movementPerSecond * moveTimer > spaceBetweenDashes)
        {

            moveTimer = 0;

        }

        Vector3 rayStartPoint = transform.position;

        Vector3 rayDirection = mousePosition - transform.position;

        bouncePositions[0] = rayStartPoint;

        for (int i = 0; i <= bounces; i++)
        {

            Ray2D dashRay = new Ray2D(rayStartPoint, rayDirection);

            RaycastHit2D rayHit = Physics2D.Raycast(rayStartPoint, rayDirection, lineMaxDistance, lineHitLayer);

            float distanceToEnd = Vector3.Distance(rayStartPoint, rayHit.point);

            for (float j = 0; j < distanceToEnd; j += spaceBetweenDashes)
            {

                if (dashPool.Count <= dashIndex)
                {

                    dashPool.Add(Instantiate(dash));

                }

                dashPool[dashIndex].transform.position = dashRay.GetPoint(j + (movementPerSecond * moveTimer));

                dashPool[dashIndex].transform.right = (dashPool[dashIndex].transform.position - new Vector3(rayHit.point.x, rayHit.point.y, 0)).normalized;

                dashPool[dashIndex].SetActive(true);

                dashIndex++;

            }

            Debug.DrawLine(rayStartPoint, rayHit.point);

            Vector3 newDirection = Vector3.Reflect(rayDirection, rayHit.normal);

            rayDirection = newDirection;

            rayStartPoint = rayHit.point + (rayHit.normal * bounceOffset);

            bouncePositions[i + 1] = rayHit.point;

        }

        for (int k = dashIndex; k < dashPool.Count; k++)
        {

            dashPool[k].SetActive(false);

        }

    }

    public void ClearLine()
    {

        for (int i = 0; i < dashPool.Count; i++)
        {

            dashPool[i].SetActive(false);

        }

    }

    public Vector3[] GetBouncePositions()
    {

        Vector3[] newBouncePositions = new Vector3[bouncePositions.Length];

        for (int i = 0; i < bouncePositions.Length; i++)
        {

            newBouncePositions[i] = bouncePositions[i];

        }

        return newBouncePositions;

    }

}
