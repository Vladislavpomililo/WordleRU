using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject audioBackGround;  //Ваш объект с фоновой музыкой
    private AudioSource audioSrc;
    public static float musicVolume;
    public Slider VolValue; //Слайдер если нужна регулировка
    public GameObject[] objs1;

    void Awake()
    {
        objs1 = GameObject.FindGameObjectsWithTag("Audio"); //не забываем задать тег Sound для префаба с музыкой
        if (objs1.Length == 0)
        {
            audioBackGround = Instantiate(audioBackGround); //создаем объект из префаба
            audioBackGround.name = "AudioBackGround";  //необязательно, просто внешний вид улучшает:)
            DontDestroyOnLoad(audioBackGround.gameObject); //Ответ на Ваш вопрос
        }
        else
        {
            audioBackGround = GameObject.Find("AudioBackGround"); //обращаемся к объекту, если он уже существует.
        }
        if (!PlayerPrefs.HasKey("MusicVol"))
        {
            musicVolume = 0.1f;  //тут громкость по умолчанию
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVol"); //сохраненная громкость
            VolValue.value = PlayerPrefs.GetFloat("MusicVol"); //меняем значение слайдера на сохраненную громкость
        }
    }
    void Start()
    {
        audioSrc = audioBackGround.GetComponent<AudioSource>();
    }


    void Update()
    {
        audioSrc.volume = musicVolume;  //устанавливаем громкость при изменении слайдера
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol); //сохраняем громкость
    }

}
