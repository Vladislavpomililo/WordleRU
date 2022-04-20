using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject audioBackGround;  //��� ������ � ������� �������
    private AudioSource audioSrc;
    public static float musicVolume;
    public Slider VolValue; //������� ���� ����� �����������
    public GameObject[] objs1;

    void Awake()
    {
        objs1 = GameObject.FindGameObjectsWithTag("Audio"); //�� �������� ������ ��� Sound ��� ������� � �������
        if (objs1.Length == 0)
        {
            audioBackGround = Instantiate(audioBackGround); //������� ������ �� �������
            audioBackGround.name = "AudioBackGround";  //�������������, ������ ������� ��� ��������:)
            DontDestroyOnLoad(audioBackGround.gameObject); //����� �� ��� ������
        }
        else
        {
            audioBackGround = GameObject.Find("AudioBackGround"); //���������� � �������, ���� �� ��� ����������.
        }
        if (!PlayerPrefs.HasKey("MusicVol"))
        {
            musicVolume = 0.1f;  //��� ��������� �� ���������
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVol"); //����������� ���������
            VolValue.value = PlayerPrefs.GetFloat("MusicVol"); //������ �������� �������� �� ����������� ���������
        }
    }
    void Start()
    {
        audioSrc = audioBackGround.GetComponent<AudioSource>();
    }


    void Update()
    {
        audioSrc.volume = musicVolume;  //������������� ��������� ��� ��������� ��������
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol); //��������� ���������
    }

}
