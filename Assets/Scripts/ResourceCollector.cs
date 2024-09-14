using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] GameObject resourceContainerr;
    //[SerializeField] GameObject gameController;
    SpriteRenderer resourceSprite;
    //SpriteRenderer boatSprite;
    bool hasResource = false;

    [SerializeField] AudioClip resourceLoadAudio;
    [SerializeField] AudioClip resourceUnloadAudio;

    ResourceUI resourceUI;

    private void Start()
    {
        resourceSprite = resourceContainerr.GetComponent<SpriteRenderer>();
        //boatSprite = GetComponent<SpriteRenderer>();
        resourceUI = FindObjectOfType<ResourceUI>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Resource" && !hasResource)
        {
            hasResource = true;
            resourceSprite.enabled = true;
            //boatSprite.color = new Color32(120,150,220, 255);
            
            GetComponent<AudioSource>().PlayOneShot(resourceLoadAudio);
            Destroy(other.gameObject);
        }
        else if(other.tag == "Checkpoint" && hasResource)
        {
            //boatSprite.color = Color.white;
            resourceUI.resourceUpdate();
            hasResource =false;
            resourceSprite.enabled = false;
            GetComponent<AudioSource>().PlayOneShot(resourceUnloadAudio);

            if (resourceUI.getResourceNumber() == 0)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }

    public bool getResuorceStatus()
    {
        return hasResource;
    }
}
