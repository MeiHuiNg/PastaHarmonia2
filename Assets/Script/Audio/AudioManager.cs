using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource DisturbSource;
	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	// Singleton instance.
	public static AudioManager Instance = null;

	[SerializeField] public GameObject shadow;
	[SerializeField] public GameObject warning;
	[SerializeField] public GameObject Rabion;
	[SerializeField] public GameObject Dialogue;

	bool isPlay;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			//Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		//DontDestroyOnLoad(gameObject);
	}
	// Play a single clip through the sound effects source.

	IEnumerator wait()
    {
		yield return new WaitForSeconds(1f);
    }

	IEnumerator Play(List<AudioClip> clips)
	{
        if (!isPlay)
        {
			isPlay = true;
			warning.SetActive(true);
			foreach (var clip in clips)
			{
				//yield return new WaitForSeconds(0.5f);
				EffectsSource.clip = clip;
				EffectsSource.Play();
				yield return new WaitForSeconds(1.5f);
			}
			shadow.SetActive(false);
			warning.SetActive(false);
			isPlay = false;
		}
	}

	IEnumerator Play_disturb(List<AudioClip> clips, AudioClip [] disturb)
	{
		if (!isPlay)
		{
			int num = 0;
			isPlay = true;
			warning.SetActive(true);
			foreach (var clip in clips)
			{
				//yield return new WaitForSeconds(0.5f);
				EffectsSource.clip = clip;
				EffectsSource.volume = 1f;
				EffectsSource.Play();
				Debug.Log(EffectsSource.clip.name);
                if (disturb[num] != null)
                {
					DisturbSource.clip = disturb[num];
					DisturbSource.volume = .25f;
					DisturbSource.Play();
                }
				num++;
				yield return new WaitForSeconds(1.5f);
			}
			Rabion.SetActive(true);
			Dialogue.SetActive(true);
			warning.SetActive(false);
			isPlay = false;
		}
	}

	IEnumerator ReplayQuestion(List<AudioClip> clips)
	{
		if (!isPlay)
		{
			isPlay = true;
			//warning.SetActive(true);
			foreach (var clip in clips)
			{
				//yield return new WaitForSeconds(0.5f);
				EffectsSource.clip = clip;
				EffectsSource.Play();
				yield return new WaitForSeconds(2);
			}
			//shadow.SetActive(false);
			//warning.SetActive(false);
			isPlay = false;
		}

	}

	IEnumerator ReplayQuestion_Disturb(List<AudioClip> clips, AudioClip[] disturb)
	{
		if (!isPlay)
		{
			int numd = 0;
			isPlay = true;
			//warning.SetActive(true);
			foreach (var clip in clips)
			{
				//yield return new WaitForSeconds(0.5f);
				EffectsSource.clip = clip;
				EffectsSource.Play();
				if (disturb[numd] != null)
				{
					DisturbSource.clip = disturb[numd];
					DisturbSource.volume = .25f;
					DisturbSource.Play();
				}
				numd++;
				yield return new WaitForSeconds(2);
			}
			
			//shadow.SetActive(false);
			//warning.SetActive(false);
			isPlay = false;
		}

	}
	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}
	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(List<AudioClip> clips)
	{
			StartCoroutine(Play(clips));
			
	}

	public void RandomSoundEffect_Disturb(List<AudioClip> clips, AudioClip []disturb)
	{
		StartCoroutine(Play_disturb(clips,disturb));

	}

	public void Replay(List<AudioClip> clips)
	{
		StartCoroutine(ReplayQuestion(clips));
	}

	public void Replay_Disturb(List<AudioClip> clips, AudioClip[] disturb)
	{
		StartCoroutine(ReplayQuestion_Disturb(clips, disturb));
	}
}
