using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public AudioClip scoreSound;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<ScoreManager>().AddScore();
            if (scoreSound != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }
        }
    }
}
