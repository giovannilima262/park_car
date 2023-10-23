using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vacancy : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private int timer = 3;
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    #endregion

    #region Private Variables
    private bool frontCollider;
    private bool backCollider;
    private bool isVacancyComplete;
    private float timerAux;
    #endregion

    #region Properties
    public bool FrontCollider { get => frontCollider; set => frontCollider = value; }
    public bool BackCollider { get => backCollider; set => backCollider = value; }
    public bool IsVacancyComplete { get => isVacancyComplete; }
    public float TimerAux { get => timerAux; }
    public int Timer { get => timer; }
    public TextMeshProUGUI TextMeshProUGUI { get => textMeshProUGUI; }
    #endregion

    private void Start()
    {
        timerAux = timer;
    }

    private void Update()
    {
        if (frontCollider && backCollider && !isVacancyComplete)
        {
            timerAux -= Time.deltaTime;
            if (timerAux <= 0)
            {
                isVacancyComplete = true;
                Debug.Log("Vacancy Complete");
            }
        }
        else
        {
            timerAux = timer;
        }
    }



}
