using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        if (transform.position.x <  -10)
        {
            Destroy(gameObject);
        }
    }
}
