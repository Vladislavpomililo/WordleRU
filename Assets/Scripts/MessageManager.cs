using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private GameObject errorMessage;
    public static bool errorMessageCheck = false;

    [SerializeField] private float timeShow = 5.0f;
    private float timeCount;

    private void Start()
    {
        timeCount = timeShow;
    }

    private void Update()
    {
        if(errorMessageCheck == true)
        {
            errorMessage.SetActive(true);

            timeCount -= Time.deltaTime;

            if (timeCount <= 0)
            {
                errorMessage.SetActive(false);
                errorMessageCheck = false;
                timeCount = timeShow;
            }
        }
    }
}
