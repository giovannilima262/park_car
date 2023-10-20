using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Inspector Variables
    [SerializeField]
    private GameObject hitObject;
    #endregion
    void OnCollisionEnter(Collision other)
    {
        hitObject.transform.position = other.contacts[0].point;
        hitObject.SetActive(true);
    }
}
