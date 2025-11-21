using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioPlayByMaterial : MonoBehaviour
{
    // Material types
    public enum CurrentMaterial
    {
        Grass,
        Gravel,
        Metal
    }
    
    [System.Serializable]
    public struct AudioType
    {
        public AudioClip[] audioClip;
    }
    
    [SerializeField] private AudioSource audioSource;
    public CurrentMaterial currentMaterial; //should be updated by another script that keeps track of the current material
    [NonReorderable] public AudioType[] audioSoundType;

    // Choose a number in your UnityEvent to set to material when player lands on UnityEventOnTrigger-collider
    public void SetMaterial(int materialNumber)
    {
        currentMaterial = (CurrentMaterial)materialNumber;
    }

    // Specify the material group from the active value of currentMaterial. Play this method from Animator with Animation Events
    public void PlaySoundFromGroup()
    {
        PlayAudioClip((int)currentMaterial);
    }
    
    // Randomize which AudioClip will be played in the specified material-group
    public void PlayAudioClip(int index)
    {
        Debug.Log("Play Audio");
        audioSource.clip = audioSoundType[index].audioClip[Random.Range(0, audioSoundType[index].audioClip.Length)];
        audioSource.Play();
    }
}
