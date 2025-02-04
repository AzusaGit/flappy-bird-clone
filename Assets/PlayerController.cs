using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioClip failSound;
    private AudioSource audioSource;
    public static PlayerController instance;

    public float flapStrength = 5f;
    public bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipes"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 5f;
            flapStrength = 0f;

            if (failSound != null)
            {
                audioSource.PlayOneShot(failSound);
            }

            FindFirstObjectByType<GameLogic>().ShowGameOver();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Flap()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapStrength);
    }
}
