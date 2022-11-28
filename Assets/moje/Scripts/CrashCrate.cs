using UnityEngine;

public class CrashCrate : MonoBehaviour
{
    [Header("Whole Create")]
    public MeshRenderer wholeCrate;
    public BoxCollider boxCollider;
    [Header("Fractured Create")]
    public GameObject fracturedCrate;
    [Header("Audio")]
    public AudioSource crashAudioClip;
    [ContextMenu("Test")]
    public void Test()
    {
        wholeCrate.enabled = false;
        boxCollider.enabled = false;
        fracturedCrate.SetActive(true);
    }
        public void DestroyChest()
    {
        wholeCrate.enabled = false;
        boxCollider.enabled = false;
        fracturedCrate.SetActive(true);
        crashAudioClip.Play();
        Invoke("DestroySelf", 5.0f);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

    
