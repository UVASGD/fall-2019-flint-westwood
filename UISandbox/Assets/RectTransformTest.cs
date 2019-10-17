using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectTransformTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Anchored Position" + this.GetComponent<RectTransform>().anchoredPosition);
        
        // Images
        GameObject imageHolder;
        Image myImage;
        RectTransform imageTransform;

        imageHolder = new GameObject();
        imageHolder.transform.parent = this.transform;
        myImage = imageHolder.AddComponent<Image>();

        imageTransform = imageHolder.GetComponent<RectTransform>();
        imageTransform.anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        Debug.Log(imageTransform.anchoredPosition);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
