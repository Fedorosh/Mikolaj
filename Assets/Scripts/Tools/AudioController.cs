using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource playerSource;

    [SerializeField] List<AudioClip> playerClips = new List<AudioClip>();

    private void PlayPlayerSound(AudioClip clip)
    {
        if (playerSource.isPlaying) playerSource.Stop();

        playerSource.PlayOneShot(clip);
    }

    public void PlayDeathSound()
    {
        PlayPlayerSound(playerClips[0]);
    }

    public void PlayJumpSound()
    {
        PlayPlayerSound(playerClips[1]);
    }

    public void PlayWinSound()
    {
        PlayPlayerSound(playerClips[2]);
    }

}
