using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private GameObject hitObject;
    #endregion

    #region Private Variables
    private GameManager gameManager;
    #endregion

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void OnCollisionEnter(Collision other)
    {
        hitObject.transform.position = other.contacts[0].point;
        hitObject.SetActive(true);
        gameManager.OnFoul();
        gameManager.AudioSourceVacancyComplete.Play();
    }
}
