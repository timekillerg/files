using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class TransparentController : MonoBehaviour
{
    public float tranparentSpeed;
    private Vector3 endPosition;

    void Start()
    {
        endPosition = transform.position;
        endPosition.z = endPosition.z - 3;
    }

    void Update()
    {
        Color oldColor = gameObject.renderer.material.color;
        Color newColor = new Color(oldColor.r, oldColor.b, oldColor.g, 0);
        gameObject.renderer.material.SetColor("_Color", Color.Lerp(gameObject.renderer.material.color, newColor, tranparentSpeed * Time.deltaTime));
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,endPosition,tranparentSpeed * Time.deltaTime);

        if (gameObject.renderer.material.color.a < 0.01)
            Destroy(gameObject);

    }
}
