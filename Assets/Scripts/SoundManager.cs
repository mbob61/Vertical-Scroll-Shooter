using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
	private static float currentVolumeMusic = 1;
	private static float currentVolumeEffects = 1;
	private static SoundManager instance;
	private static bool pitchChanged = false;
	public float instanceVolume = 1;
	public enum Sound{
		music,
		hit,
		playerFire,
		enemyFire,
		explosion,
		heal
	}

	public enum PlaybackType
    {
		none,
		stopStart,
		waitToFinish,
		playOnce
    }
	public enum volumeGroup
    {
		Music,
		SoundEffects
    }

	private static Dictionary<Sound, float> soundTimerDictionary;
	
	public static void Initialize()
	{
		soundTimerDictionary = new Dictionary<Sound, float>();
	}
	
	
	public static void PlaySound(Sound sound) 
	{
		if (IsClipActive(sound))
		{
			if ((GetClipPlaybackType(sound) == PlaybackType.playOnce && SoundPlayedOnce(sound)))
			{
			}
			else
			{
				if (GetClipPlaybackType(sound) == PlaybackType.waitToFinish)
				{
					if (SoundAlreadyPlaying(sound))
					{
						GameObject soundGameObject = new GameObject("Sound");
						soundGameObject.tag = "SoundEffects";
						soundGameObject.name = sound.ToString();
						AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
						soundGameObject.AddComponent<AudioLowPassFilter>();
						soundGameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = 2000;
						soundGameObject.GetComponent<AudioLowPassFilter>().enabled = pitchChanged;

						if (GetClipPlaybackType(sound) == PlaybackType.stopStart)
						{
							StopSoundsAlreadyPlaying(sound);
						}
						audioSource.clip = GetAudioClip(sound);
						audioSource.volume = currentVolumeEffects * GetClipVolume(sound);
						audioSource.pitch += GetClipPitch(sound);
						audioSource.Play();

						UnityEngine.Object.Destroy(soundGameObject, audioSource.clip.length);
					}
				}
				else
				{

					GameObject soundGameObject = new GameObject("Sound");
					soundGameObject.tag = "SoundEffects";
					soundGameObject.name = sound.ToString();
					AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
					soundGameObject.AddComponent<AudioLowPassFilter>();
					soundGameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = 2000;
					soundGameObject.GetComponent<AudioLowPassFilter>().enabled = pitchChanged;


					if (GetClipPlaybackType(sound) == PlaybackType.stopStart)
					{
						StopSoundsAlreadyPlaying(sound);
					}
					audioSource.clip = GetAudioClip(sound);
					audioSource.volume = currentVolumeEffects * GetClipVolume(sound);

					if (GetClipIsReversed(sound))
					{
						soundGameObject.GetComponent<AudioSource>().pitch = -1;// soundGameObject.GetComponent<AudioSource>().pitch;
						soundGameObject.GetComponent<AudioSource>().timeSamples = soundGameObject.GetComponent<AudioSource>().clip.samples - 1;
					}
					audioSource.pitch += GetClipPitch(sound);
					audioSource.Play();
					if (GetClipPlaybackType(sound) == PlaybackType.playOnce)
					{
						SetSoundPlayedOnce(sound);
					}
					UnityEngine.Object.Destroy(soundGameObject, audioSource.clip.length);

				}
			}
		}
	}

	public static void PlaySound(Sound sound, float timeToPlay)
	{
		if (IsClipActive(sound))
		{
			if ((GetClipPlaybackType(sound) == PlaybackType.playOnce && SoundPlayedOnce(sound)))
			{
			}
			else
			{
				if (GetClipPlaybackType(sound) == PlaybackType.waitToFinish)
				{
					if (SoundAlreadyPlaying(sound))
					{
						GameObject soundGameObject = new GameObject("Sound");
						soundGameObject.tag = "SoundEffects";
						soundGameObject.name = sound.ToString();
						AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
						soundGameObject.AddComponent<AudioLowPassFilter>();
						soundGameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = 2000;
						soundGameObject.GetComponent<AudioLowPassFilter>().enabled = pitchChanged;

						if (GetClipPlaybackType(sound) == PlaybackType.stopStart)
						{
							StopSoundsAlreadyPlaying(sound);
						}
						audioSource.clip = GetAudioClip(sound);
						audioSource.volume = currentVolumeEffects * GetClipVolume(sound);
						audioSource.pitch += GetClipPitch(sound);
						audioSource.Play();

						UnityEngine.Object.Destroy(soundGameObject, timeToPlay);
					}
				}
				else
				{

					GameObject soundGameObject = new GameObject("Sound");
					soundGameObject.tag = "SoundEffects";
					soundGameObject.name = sound.ToString();
					AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
					soundGameObject.AddComponent<AudioLowPassFilter>();
					soundGameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = 2000;
					soundGameObject.GetComponent<AudioLowPassFilter>().enabled = pitchChanged;


					if (GetClipPlaybackType(sound) == PlaybackType.stopStart)
					{
						StopSoundsAlreadyPlaying(sound);
					}
					audioSource.clip = GetAudioClip(sound);
					audioSource.volume = currentVolumeEffects * GetClipVolume(sound);

					if (GetClipIsReversed(sound))
					{
						soundGameObject.GetComponent<AudioSource>().pitch = -1;// soundGameObject.GetComponent<AudioSource>().pitch;
						soundGameObject.GetComponent<AudioSource>().timeSamples = soundGameObject.GetComponent<AudioSource>().clip.samples - 1;
					}
					audioSource.pitch += GetClipPitch(sound);
					audioSource.Play();
					if (GetClipPlaybackType(sound) == PlaybackType.playOnce)
					{
						SetSoundPlayedOnce(sound);
					}
					UnityEngine.Object.Destroy(soundGameObject, timeToPlay);

				}
			}
		}
	}

	public static void PlaySound(Sound sound, bool isLoop)
	{
		if (IsClipActive(sound))
		{
			if (CanPlaySound(sound) && SoundAlreadyPlaying(sound))
			{
				GameObject soundGameObject = new GameObject("Sound");
				soundGameObject.name = sound.ToString();
				AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
				soundGameObject.AddComponent<AudioLowPassFilter>();
				soundGameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = 2000;
				soundGameObject.GetComponent<AudioLowPassFilter>().enabled = pitchChanged;
				//if (sound == Sound.enemyChainGun)
				//{
				//	soundGameObject.name = "enemyChainGun";
				//	soundGameObject.tag = "enemyChainGun";

				//}
				//else
				//{
				
                soundGameObject.tag = "Music";
                DontDestroyOnLoad(soundGameObject);
                //}
                audioSource.loop = isLoop;



				//Set below property to true to ignore the pausing of sounds.
				audioSource.ignoreListenerPause = true;
				//audioSource.volume = globalVolume;
				audioSource.clip = GetAudioClip(sound);
				//if (sound != Sound.enemyChainGun)
				//{
				//	audioSource.volume = 0;
				//}

				if (GetClipIsReversed(sound))
				{
					soundGameObject.GetComponent<AudioSource>().pitch = -1;// soundGameObject.GetComponent<AudioSource>().pitch;
					soundGameObject.GetComponent<AudioSource>().timeSamples = soundGameObject.GetComponent<AudioSource>().clip.samples - 1;
				}
				audioSource.volume = currentVolumeMusic * GetClipVolume(sound);
				audioSource.Play();

				if (!instance)
				{
					instance = FindObjectOfType<SoundManager>();

					if (!instance)
					{
						instance = new GameObject("SoundManager").AddComponent<SoundManager>();
					}
				}
				//if (sound != Sound.enemyChainGun)
				//{
				//	instance.StartCoroutine(startFade(audioSource, 3.0f, currentVolumeMusic));
				//}
			}
		}
	}

	public static void EndSound(Sound sound)
	{
		//if (sound == Sound.enemyChainGun)
		//{
		//GameObject obj = GameObject.FindGameObjectWithTag("enemyChainGun");
		GameObject obj = GameObject.Find(sound.ToString());

		if (obj != null)
        {
            Destroy(obj);
        }
    
}

	private static IEnumerator startFade(AudioSource audioSource, float duration, float targetVolume)
	{
		float currentTime = 0;
		float start = audioSource.volume;
		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
			yield return null;
		}
		yield break;
	}


	private static bool SoundAlreadyPlaying(Sound sound)
	{
		GameObject obj = GameObject.Find(sound.ToString());
			if (obj != null)
			{
				return false;
			}
			else
            {
				return true;
            }
    }

	private static void StopSoundsAlreadyPlaying(Sound sound)
	{
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == sound.ToString()))
        {
            obj.GetComponent<AudioSource>().Stop();

        }
    }
	public static void PauseSound()
	{
		AudioListener.pause = true;
	}
	
	public static void UnpauseSound(Sound sound)
	{
		AudioListener.pause = false;
	}
	
	public static void SetVolume(float volume, volumeGroup group)
	{
        if (group == volumeGroup.Music)
        {
            currentVolumeMusic = volume;
        }
        else if (group == volumeGroup.SoundEffects)
        {
            currentVolumeEffects = volume;
        }


        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(group.ToString()))
        {
			obj.GetComponent<AudioSource>().volume = volume * GetClipVolume(obj.name);
        }
    }
	public static void SetVolume(float volume)
	{
		AudioListener.volume = volume;
	}
	public static float GetVolume(volumeGroup group)
    {
		if(group == volumeGroup.Music)
        {
			return currentVolumeMusic;
        }
		else if(group == volumeGroup.SoundEffects)
        {
			return currentVolumeEffects;
        }
		else
        {
			return 1;
        }
    }
	public static float GetMasterVolume()
	{
		return AudioListener.volume;
	}
	
	private static bool CanPlaySound(Sound sound)
	{
		//	switch(sound){
		//		default:
		//			return true;
		//		case Sound.playerMove:
		//			if(soundTimerDictionary.ContainsKey(sound))
		//			{
		//				float lastTimePlayed = soundTimerDictionary[sound];
		//				float playerMoveTimerMax = 3f;
		//				if(lastTimePlayed + playerMoveTimerMax < Time.time)
		//				{
		//					soundTimerDictionary[sound] = Time.time;
		//					return true;
		//				}
		//				else
		//				{
		//					return false;
		//				}
		//			}
		//			else
		//			{
		//				return true;
		//			}

		//		//break;
		//}

		return true;
	}
	
	private static AudioClip GetAudioClip(Sound sound)
	{
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if(soundAudioClip.sound == sound)
			{
				return soundAudioClip.audioClip;
			}
		}
		Debug.LogError("Sound " + sound + " not found!");
		return null;
	}

	private static bool IsClipActive(Sound sound)
    {
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				return soundAudioClip.active;
			}
		}
		return false;
	}

	private static PlaybackType GetClipPlaybackType(Sound sound)
	{
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				return soundAudioClip.type;
			}
		}

		return PlaybackType.none;
	}

	private static bool SoundPlayedOnce(Sound sound)
    {
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				return soundAudioClip.played;
			}
		}
		return false;
    }

	private static void SetSoundPlayedOnce(Sound sound)
    {
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				soundAudioClip.played = true;
			}
		}
	}

	public static void ResetSoundPlayedOnce(Sound sound)
    {
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				soundAudioClip.played = false;
			}
		}
	}

	private static float GetClipPitch(Sound sound)
    {
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				return soundAudioClip.pitch;
			}
		}
		return 0;
	}

	private static float GetClipVolume(Sound sound)
    {
		foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
			if (soundAudioClip.sound == sound)
			{
				return soundAudioClip.volume;
			}
		}
		return 1;
    }

	private static float GetClipVolume(string sound)
	{
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound.ToString() == sound)
			{
				return soundAudioClip.volume;
			}
		}
		return 1;
	}

	private static bool GetClipIsReversed(Sound sound)
	{
		foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
		{
			if (soundAudioClip.sound == sound)
			{
				return soundAudioClip.reversed;
			}
		}
		return false;
	}

	public static void LowerPitch()
    {
		pitchChanged = true;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag(volumeGroup.Music.ToString()))
		{
			obj.GetComponent<AudioLowPassFilter>().enabled = true;
		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag(volumeGroup.SoundEffects.ToString()))
		{
			obj.GetComponent<AudioLowPassFilter>().enabled = true;
		}
	}
	public static void IncreasePitch()
    {
		pitchChanged = false;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag(volumeGroup.Music.ToString()))
		{
			obj.GetComponent<AudioLowPassFilter>().enabled = false;
		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag(volumeGroup.SoundEffects.ToString()))
		{
			obj.GetComponent<AudioLowPassFilter>().enabled = false;
		}
	}
}
