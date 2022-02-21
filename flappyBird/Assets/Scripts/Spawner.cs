using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawRate = 1f;    
    public float minHeight = -1f;    
    public float maxHeight = 1f;    

    private void Start() {
        InvokeRepeating("Spawn", spawRate, spawRate);
    }

    private void OnDisable() {
        CancelInvoke("Spawn");
    }

    private void Spawn() {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
