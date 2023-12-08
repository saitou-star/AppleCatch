using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
