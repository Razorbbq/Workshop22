using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{
    [SerializeField] bool topHat;
    [SerializeField] GameObject otherHat;
    [SerializeField] GameObject hatCanvas;
    [SerializeField] IntroText text;
    [SerializeField] GameObject activate;
    [SerializeField] string[] textPrompts;
    [SerializeField] AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        activate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(otherHat);
            hatCanvas.SetActive(false);
            transform.parent = collision.transform;
            transform.localPosition = new Vector3(0, 0.55f, 0);
            activate.SetActive(true);
            text.NewTextPrompts(textPrompts, topHat);
            music.Stop();
        }
    }
}
