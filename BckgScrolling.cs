using UnityEngine;

public class BckgScrolling : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate() // Alterado de FixedUpdate para LateUpdate
    {
        float distance = (cam.transform.position.x * parallaxEffect);
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length) // Corrigido para mover para tr�s corretamente
        {
            startPos -= length;
        }
    }
}