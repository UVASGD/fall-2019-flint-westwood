using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    private Camera mainCamera;
    private DrawFireLine fireLine;

    private void Start()
    {

        mainCamera = Camera.main;

        fireLine = GetComponent<DrawFireLine>();

    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {

            fireLine.DrawLine(mainCamera.ScreenToWorldPoint(Input.mousePosition));

        }

        if (Input.GetMouseButtonUp(0))
        {

            GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);

            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90));

            Vector3[] bouncesRef = fireLine.GetBouncePositions();

            newBullet.GetComponent<BulletMovementPreCalc>().SetBouncePositions(bouncesRef);

            fireLine.ClearLine();

        }

    }

}
