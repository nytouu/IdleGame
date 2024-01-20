using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttacks : MonoBehaviour
{
	[SerializeField] ClickManager clickManager;
	[SerializeField] Button explosionButton;
	[SerializeField] Button poisonButton;

	private bool poisonEnabled;
	private int poisonCounter;
	
	public int poisonDuration;

	public float explosionCooldown;
	private bool explosionEnabled;
	private float nextExplosion;

    // Start is called before the first frame update
    void Start()
    {
		poisonEnabled = false;
		poisonCounter = 0;

		explosionEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time > nextExplosion){
			explosionButton.interactable = true;
		}

    }

	public void Explosion(){
		if (Time.time > nextExplosion){
			clickManager.UpdateScore(clickManager.explosionPower, true);
			explosionEnabled = true;
			explosionButton.interactable = false;
			nextExplosion = Time.time + explosionCooldown;
		}
	}

	public void Poison(){
		poisonEnabled = true;
		poisonButton.interactable = false;
		StartCoroutine(PoisonCoroutine());
	}

	private IEnumerator PoisonCoroutine() {
		while (poisonEnabled) {
			clickManager.UpdateScore(clickManager.poisonPower, false);

			poisonCounter++;
			if (poisonCounter >= poisonDuration * 2f){
				poisonCounter = 0;
				poisonButton.interactable = true;
				poisonEnabled = false;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
