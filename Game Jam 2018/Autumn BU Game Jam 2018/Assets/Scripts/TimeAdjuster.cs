using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdjuster : MonoBehaviour
{

    public MeshRenderer mRenderer;
    public MeshCollider mCollider;
    public GameManager gManager;

    public float adjustAmount;
    public float cooldownTime;

	void Start ()
    {
        gManager = GameObject.FindObjectOfType<GameManager>();
	}

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        mRenderer.enabled = true;
        mCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gManager.AdjustTimeSpeed(adjustAmount);
            mRenderer.enabled = false;
            mCollider.enabled = false;
            StartCoroutine(StartCooldown());
        }
    }
}
