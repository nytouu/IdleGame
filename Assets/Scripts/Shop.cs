using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
	[SerializeField] private ClickManager clickManager;
	private AudioSource audioSource;

	public int money;

	public TextMeshProUGUI clickPowerText,
				autoClickPowerText,
				poisonPowerText,
				explosionPowerText;

	private int clickLevel,
				autoClickLevel,
				poisonLevel,
				explosionLevel;

	private int clickPrice,
				autoClickPrice,
				poisonPrice,
				explosionPrice;


	[SerializeField] TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
		clickLevel = 1;
		autoClickLevel = 1;
		poisonLevel = 1;
		explosionLevel = 1;

		clickPrice = 20;
		autoClickPrice = 20;
		poisonPrice = 20;
		explosionPrice = 20;

		audioSource = GetComponent<AudioSource>();
    }

	// TODO: factoriser
	public void UpgradeClick(){
		if (money >= clickPrice){
			money -= clickPrice;

			clickManager.clickPower *= 2f;
			clickLevel++;
			clickPrice *= 2;

			moneyText.text = "Gold: " + money;
			clickPowerText.text = "Click Power \nlvl " + clickLevel.ToString() + "\n" + clickPrice + " Gold";
			audioSource.Play();
		}
	}

	public void UpgradeAutoClick(){
		if (money >= autoClickPrice){
			money -= autoClickPrice;

			clickManager.autoClickPower *= 2f;
			autoClickLevel++;
			autoClickPrice *= 2;

			moneyText.text = "Gold: " + money;
			autoClickPowerText.text = "Auto Click Power \nlvl " + autoClickLevel.ToString() + "\n" + autoClickPrice + " Gold";
			audioSource.Play();
		}
	}

	public void UpgradePoison(){
		if (money >= poisonPrice) {
			money -= poisonPrice;

			clickManager.poisonPower *= 2f;
			poisonLevel++;
			poisonPrice *= 2;

			moneyText.text = "Gold: " + money;
			poisonPowerText.text = "Poison Power \nlvl " + poisonLevel.ToString() + "\n" + poisonPrice + " Gold";
			audioSource.Play();
		}
	}

	public void UpgradeExplosion(){
		if (money >= explosionPrice){
			money -= explosionPrice;

			clickManager.explosionPower *= 2f;
			explosionLevel++;
			explosionPrice *= 2;

			moneyText.text = "Gold: " + money;
			explosionPowerText.text = "Explosion Power \nlvl " + explosionLevel.ToString() + "\n" + explosionPrice + " Gold";
			audioSource.Play();
		}
	}
}
