using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    private float borderLeft;
    
    private void Start() {
        borderLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;   
    }

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < borderLeft) {
            Destroy(gameObject);
        }
    }
}
