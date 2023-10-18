using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderVacancy : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private Vacancy vacancy;

    [SerializeField]
    private ColliderVacancyEnum colliderVacancyEnum;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        OnColliderPlayer(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        OnColliderPlayer(other, false);
    }

    private void OnColliderPlayer(Collider other, bool value)
    {
        if (other.CompareTag("ColliderPlayer"))
        {
            switch (colliderVacancyEnum)
            {
                case ColliderVacancyEnum.Front:
                    vacancy.FrontCollider = value;
                    break;
                case ColliderVacancyEnum.Back:
                    vacancy.BackCollider = value;
                    break;
            }
        }
    }
}
