using System.Management.Instrumentation;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    private Camera mainCamera;
    private DrawFireLine fireLine;
    [SerializeField] private GameObject crosshair;

    private void Start()
    {
        Cursor.visible = false;
        mainCamera = Camera.main;
        crosshair = Instantiate(crosshair, new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0f), Quaternion.identity);
        fireLine = GetComponent<DrawFireLine>();

    }

    private void SetXHair()
    {
        crosshair.transform.position = new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }

    private void Update()
    {
        SetXHair();
        if (Input.GetMouseButton(0))
        {

//            fireLine.DrawLine(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            fireLine.DrawLine(crosshair.transform.position);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (fireLine.rayHit.collider != null)
            {
                GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);

                Vector3 mousePos = crosshair.transform.position;

                newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90));

                Vector3[] bouncesRef = fireLine.GetBouncePositions();

                newBullet.GetComponent<BulletMovementPreCalc>().SetBouncePositions(bouncesRef);

                fireLine.ClearLine();
            }
            
        }

    }

}
