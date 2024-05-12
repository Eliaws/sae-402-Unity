using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    public ParticleSystem particles;
    public string nextLevelName;
    public AudioClip audioClip;

    [Header("Broadcast event channels")]
    public StringEventChannel onLevelEnded;
    public PlaySoundAtEventChannel sfxAudioChannel;

    private bool hasBeenTriggered = false;

    public class ExampleClass : MonoBehaviour
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !hasBeenTriggered)
        {
            hasBeenTriggered = true;
            if (nextLevelName != null)
            {
                particles.Play();
                sfxAudioChannel.Raise(audioClip, transform.position);
                SceneManager.LoadScene(nextLevelName);
            } else {
                Debug.LogError("Level missing");
            }
        }
    }

   
}
