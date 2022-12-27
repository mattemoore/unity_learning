using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float rotationSpeed;
    private Color targetColor;
    Vector3 targetScale;

    float RandomRange(float max) {
        return Random.Range(0, max);
    }

    Color getTargetColor() {
        return new Color(RandomRange(1),RandomRange(1),RandomRange(1),RandomRange(1));
    }

    Vector3 getTargetScale() {
        return Vector3.one * RandomRange(3);
    }
    
    void Start()
    {
        transform.position = new Vector3(RandomRange(5), RandomRange(5), RandomRange(5));
        targetScale = getTargetScale();
        targetColor = getTargetColor();
        rotationSpeed = RandomRange(100);
    }
    
    void Update()
    {
        Material material = Renderer.material;
        if (Renderer.material.color != targetColor)
        {
            material.color = Color.Lerp(material.color, targetColor, 3.0f * Time.deltaTime);

        }
        else {
            targetColor = getTargetColor();
        }

        if (transform.localScale != targetScale) {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 3.0f * Time.deltaTime);
        }
        else {
            targetScale = getTargetScale();
        }
        
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
