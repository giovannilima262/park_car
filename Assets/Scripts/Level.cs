using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private List<Transform> vacancyTransforms;

    [SerializeField]
    private Transform arrowTransform;
    #endregion

    #region Private Variables
    private int currentVacancyIndex = 0;
    private Vector3 currentVacancyPosition;
    #endregion

    void Update()
    {
        ArrowLookAtNextVacancy();
    }

    private void ArrowLookAtNextVacancy()
    {
        if (currentVacancyIndex < vacancyTransforms.Count)
        {
            currentVacancyPosition = vacancyTransforms[currentVacancyIndex].position;
            arrowTransform.LookAt(new Vector3(currentVacancyPosition.x, currentVacancyPosition.y + arrowTransform.position.y, currentVacancyPosition.z));
        }
    }

}
