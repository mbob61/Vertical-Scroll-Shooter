using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 0.5f;
    [SerializeField] private GameObject sliderObject;
    [SerializeField] private GameObject effectsSliderObject;
    [SerializeField] private GameObject musicSliderObject;

    private Vector3 titleBlocksPos;

    private Slider slider;
    private Slider effectsSlider;
    private Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            titleBlocksPos = Camera.main.ViewportToWorldPoint(new Vector3(0.35f, 0.5f, Camera.main.nearClipPlane)); 
        }
        if(SceneManager.GetActiveScene().name == "Options")
        {
            slider = sliderObject.GetComponent<Slider>();
            effectsSlider = effectsSliderObject.GetComponent<Slider>();
            musicSlider = musicSliderObject.GetComponent<Slider>();

            slider.value = SoundManager.GetMasterVolume();
            effectsSlider.value = SoundManager.GetVolume(SoundManager.volumeGroup.SoundEffects);
            musicSlider.value = SoundManager.GetVolume(SoundManager.volumeGroup.Music);


        }
        SoundManager.PlaySound(SoundManager.Sound.music, true);
        if (GameObject.Find("SceneTransition(Clone)") != null)
        {
            transition = GameObject.Find("SceneTransition(Clone)").GetComponentInChildren<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadOptions()
    {
        StartCoroutine(LoadScene("Options"));
    }
    public void LoadCredits()
    {
        StartCoroutine(LoadScene("Credits"));
    }

    public void LoadGame()
    {
        StartCoroutine(LoadScene("Game"));
    }

        public void LoadMainMenu()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }

    public void LoadLevelSelect()
    {
        StartCoroutine(LoadScene("LevelSelect"));
    }

    public void TryAgain()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex +1 < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            LoadCredits();
        }
    }

    public void ChangeMasterVolume()
    {
        AudioListener.volume = slider.value;
    }

    public void ChangeSoundEffects()
    {
        SoundManager.SetVolume(effectsSlider.value, SoundManager.volumeGroup.SoundEffects);
    }

    public void ChangeMusicVolume()
    {
        SoundManager.SetVolume(musicSlider.value, SoundManager.volumeGroup.Music);
    }


    IEnumerator LoadScene(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

    IEnumerator LoadScene(int scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
