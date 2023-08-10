using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnageWeb : MonoBehaviour
{
    public GameObject webC;
    public Transform webDrop;
    public float dropTime = 1f; // Time interval between bomb drops

    public int carnageWebDamage = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("Player")) {
            SpidermanHealth health = GetComponent<SpidermanHealth>();
            if (health != null) {
                health.TakeDamage(carnageWebDamage);
            }
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        StartCoroutine(shootCarnageWebs());
    }

    IEnumerator shootCarnageWebs()
    {
        while (true) {
            yield return new WaitForSeconds(dropTime);
            CarnageBomb();
        }
    }

    void CarnageBomb()
    {
        if (webC && webDrop) {
            Instantiate(webC, webDrop.position, Quaternion.identity);
        }
    }
}

    