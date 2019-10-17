using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject uiBullet, uiHeart;
    [SerializeField] private ScriptableWeapon currentWeapon;
    [SerializeField] private FloatVar playerHealth;
    [SerializeField] private GameObject bulletField, healthField;
    private List<GameObject> uiBullets;
    [SerializeField] GameObject _player;
    void Start()
    {
//        Vector3 screenPos = GetWorldPositionFromCanvas(bulletField.transform.position, Camera.main,
//            GameObject.FindObjectOfType<Canvas>());
        uiBullets = new List<GameObject>();

        float offset = uiBullet.GetComponent<RectTransform>().rect.width * 0.75f;
        for (int i = 1; i <= currentWeapon.ammoCount; i++)
        {
            GameObject bulletClone = Instantiate(uiBullet, bulletField.transform, false) as GameObject;
            uiBullets.Add(bulletClone);
            bulletClone.GetComponent<RectTransform>().Translate(new Vector3(offset * i, 0f, 0f));
        }
    }

    void HandleShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentWeapon.ammoCount != 0)
            {
                uiBullets[currentWeapon.ammoCount - 1].GetComponent<Animator>().SetBool("isFiring", true);
                currentWeapon.ammoCount--;
            }
        }
        
    }

    Vector3 GetWorldPositionFromCanvas(Vector3 _worldPos, Camera _cam, Canvas _canvas)
    {
        Vector2 posOnScreen = _cam.ScreenToWorldPoint(_worldPos);
        float scaleFactor = _canvas.scaleFactor;
        return new Vector3(posOnScreen.x / scaleFactor, posOnScreen.y / scaleFactor, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }
}
