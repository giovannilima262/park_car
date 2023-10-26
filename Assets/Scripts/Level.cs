using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private TextMeshProUGUI textCountVacancies;
    [SerializeField]
    private GameObject checkImageFinish;
    [SerializeField]
    private List<Vacancy> vacancies;
    [SerializeField]
    private Transform arrowTransform;
    [SerializeField]
    private Image imageTimer;
    [SerializeField]
    private GameObject gameControllerCanvas;
    #endregion

    #region Private Variables
    private int currentVacancyIndex = 0;
    private Vector3 currentVacancyPosition;
    private bool isLevelComplete;
    #endregion

    #region Private Variables
    private GameManager gameManager;
    #endregion

    private void Start()
    {
        gameControllerCanvas.SetActive(true);
        gameManager = GameManager.Instance;
        UpdateTextCountVacancies();
        arrowTransform.localScale = Vector3.zero;
        imageTimer.transform.localScale = Vector3.zero;
        arrowTransform.DOScale(Vector3.one, 1f);
        for (int i = 0; i < vacancies.Count; i++)
        {
            vacancies[i].TextMeshProUGUI.text = (i + 1).ToString();
        }
    }

    void Update()
    {
        ArrowLookAtNextVacancy();
        ValidateNextVacancy();
        UpdateImageTimer();
        imageTimer.transform.LookAt(Camera.main.transform);
    }

    private void UpdateImageTimer()
    {
        if (currentVacancyIndex >= vacancies.Count) return;

        if (vacancies[currentVacancyIndex].FrontCollider && vacancies[currentVacancyIndex].BackCollider)
        {
            if (vacancies[currentVacancyIndex].IsVacancyComplete) return;
            arrowTransform.DOScale(Vector3.zero, .5f);
            imageTimer.transform.DOScale(Vector3.one, .5f);
            imageTimer.fillAmount = 1f - (vacancies[currentVacancyIndex].TimerAux / vacancies[currentVacancyIndex].Timer);
        }
        else if (imageTimer.transform.localScale != Vector3.zero)
        {
            arrowTransform.DOScale(Vector3.one, .5f);
            imageTimer.transform.DOScale(Vector3.zero, .5f);
        }
    }

    private void ArrowLookAtNextVacancy()
    {
        if (currentVacancyIndex >= vacancies.Count) return;
        currentVacancyPosition = vacancies[currentVacancyIndex].transform.position;
        arrowTransform.LookAt(new Vector3(currentVacancyPosition.x, currentVacancyPosition.y + arrowTransform.position.y, currentVacancyPosition.z));

    }

    private void ValidateNextVacancy()
    {
        if (currentVacancyIndex < vacancies.Count)
        {
            if (vacancies[currentVacancyIndex].IsVacancyComplete)
            {
                currentVacancyIndex++;
                UpdateTextCountVacancies();
                arrowTransform.DOScale(Vector3.one, .5f);
                imageTimer.transform.DOScale(Vector3.zero, .5f);
            }
        }
        else if (!isLevelComplete)
        {
            arrowTransform.DOScale(Vector3.zero, .5f);
            imageTimer.transform.DOScale(Vector3.zero, .5f);
            isLevelComplete = true;
            gameControllerCanvas.SetActive(false);
            gameManager.OnLevelComplete();
        }
    }

    private void UpdateTextCountVacancies()
    {
        if (currentVacancyIndex >= vacancies.Count)
        {
            textCountVacancies.text = "0";
            checkImageFinish.SetActive(true);
            textCountVacancies.gameObject.SetActive(false);
            return;
        }
        textCountVacancies.text = (vacancies.Count - currentVacancyIndex).ToString();
        checkImageFinish.SetActive(false);
        textCountVacancies.gameObject.SetActive(true);
    }

    public void OnLevelFailed()
    {
        gameControllerCanvas.SetActive(false);
    }

}
