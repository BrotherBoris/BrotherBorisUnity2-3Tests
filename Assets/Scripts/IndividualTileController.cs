using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualTileController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject.GetComponent<BoxCollider>());

        Instantiate(ResourceManager.Instance.prefabList[0], this.transform.position + new Vector3(2,0,0), gameObject.transform.rotation);
    }
}
