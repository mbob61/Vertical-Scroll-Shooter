using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.Rendering;
//using V_AnimationSystem;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
	public static bool isWeb = true;

	public static float? masterVolume = null;
	public static float? soundeffectsVolume = null;
	public static float? musicVolume = null;

	public static float phasedriveEffectRadius = 0;
	
	public static float LetterBoxEffectRadius = 0.3f;
	public static bool LetterBoxEffectOn = false;
	public static bool LetterBoxEffectFinished = false;
	public static bool effectIsOn = false;
	
	public static bool isShakeEnabled = true;
	public static bool laserSight = true;
	public static Color bubbleColour = Color.magenta;
	public static bool rainbowBubbles = false;
	
	public static Vector3 originalCameraPosition;

	public static GameAssets i
	{
		get
		{
			if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("Prefabs/GameAssets"));
			return _i;
			
		}
	}
	
	public SoundAudioClip[] soundAudioClipArray;
	
	[System.Serializable]
	public class SoundAudioClip
	{
		public SoundManager.Sound sound;
		public AudioClip audioClip;
		public SoundManager.PlaybackType type;
		public bool active;
		public float volume;
		public bool reversed;
		public float pitch;
		public bool played;
	}

	public static void SaveSoundForScene()
    {
		masterVolume = AudioListener.volume * 100;
		musicVolume = SoundManager.GetVolume(SoundManager.volumeGroup.Music);
		soundeffectsVolume = SoundManager.GetVolume(SoundManager.volumeGroup.SoundEffects);
	}

	public static void PhasedriveActivateShader()
	{
		if (phasedriveEffectRadius < 2.4f)
		{
			phasedriveEffectRadius += Time.deltaTime * 3;
		}
    }
	public static void PhasedriveDeactivateShader()
    {
		if (phasedriveEffectRadius > 0)
		{
			phasedriveEffectRadius -= Time.deltaTime * 3;
		}
    }
	public static void ResetPhasedriveShader()
    {
		phasedriveEffectRadius = 0;
	}

	public static void MoveToObject()
    {
		effectIsOn = true;
		
		LetterBoxEffectFinished = false;
		LetterBoxEffectOn = true;
    }


	public static void DisableLetterBoxEffect()
    {
		effectIsOn = false;
		LetterBoxEffectOn = false;
    }
}
