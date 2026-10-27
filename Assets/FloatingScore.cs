using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingScore : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float disappearSpeed = 3f;
    public float lifeTime = 0.6f;

    private TextMeshPro textMesh;
    private Color textColor;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        if (textMesh != null)
        {
            textColor = textMesh.color;
        }
    }

    void Update()
    {
        // Yukarý doðru hareket et
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            // Þeffaflaþarak kaybol
            textColor.a -= disappearSpeed * Time.deltaTime;
            if (textMesh != null)
            {
                textMesh.color = textColor;
            }

            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}