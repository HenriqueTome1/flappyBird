using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerControls controls;
    private SpriteRenderer spriteRendere;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float strenght = 100f;

    private Rigidbody2D _rigidbody;

    private void Awake() {
        controls = new PlayerControls();
        controls.Gameplay.Fly.performed += ctx => MovePlayer();
        
        spriteRendere = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        InvokeRepeating("SpriteAnimation", 0.15f, 0.15f);
    }

    private void OnEnable() {
        direction = Vector3.zero;
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;

        _rigidbody.velocity = Vector3.zero;

        controls.Gameplay.Enable();
    }

    private void OnDisable() {
        controls.Gameplay.Disable();
    }

    // Handle input
    private void Update() {
        // if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
        //     MovePlayer();
        // }

        // if (Input.touchCount > 0) {
        //     Touch touch = Input.GetTouch(0);

        //     if (touch.phase == TouchPhase.Began) {
        //         MovePlayer();
        //     }
        // }
    }

    public void MovePlayer() {
        direction = Vector3.up * this.strenght;
        _rigidbody.AddForce(direction);
    }

    public void SpriteAnimation() {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRendere.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle") {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
