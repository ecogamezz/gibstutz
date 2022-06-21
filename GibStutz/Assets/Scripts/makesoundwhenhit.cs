using UnityEngine;
using System.Collections;

public class makesoundwhenhit : MonoBehaviour
{
    [SerializeField] AudioSource gunAudioSource;
    [SerializeField] AudioClip impactsound;
    public void makesound()
    {
        gunAudioSource.PlayOneShot(impactsound);
    }
}