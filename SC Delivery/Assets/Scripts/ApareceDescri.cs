using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceDescri : MonoBehaviour {

    public GameObject balao;
    bool umaVez = false;

    public void ApareceBalao()
    {
        if (!umaVez)
        {
            StartCoroutine("ApareceBalaoDescri");
        }
    }

    public void ParaBalao()
    {
        balao.SetActive(false);
        umaVez = false;        
    }

    IEnumerator ApareceBalaoDescri()
    {
        umaVez = true;
        yield return new WaitForSeconds(1);
        if (!umaVez)
        {            
            yield break;
        }
        if (umaVez) balao.SetActive(true);
    }
}
