using UnityEngine;

public class BulletMovementPreCalc : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Vector3[] bounceTargets;
    private int posInt;
    private float time;
    
    private void Update()
    {

        time += (Time.deltaTime / Vector3.Distance(bounceTargets[posInt], bounceTargets[posInt + 1])) * moveSpeed;

        if (time >= 1)
        {

            time = 0;

            posInt++;

        }

        if (posInt >= bounceTargets.Length - 1)
        {

            Destroy(gameObject);

        }
        else
        {

            transform.position = Vector3.Lerp(bounceTargets[posInt], bounceTargets[posInt + 1], time);

        }

    }

    public void SetBouncePositions(Vector3[] positions)
    {

        bounceTargets = positions;

    }

}
