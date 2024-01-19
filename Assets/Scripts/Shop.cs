using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
	[SerializeField] ClickManager clickManager;

	public TextMeshProUGUI clickPowerText,
				autoClickPowerText,
				poisonPowerText,
				explosionPowerText;

	private int clickLevel,
				autoClickLevel,
				poisonLevel,
				explosionLevel;

    // Start is called before the first frame update
    void Start()
    {
		clickLevel = 1;
		autoClickLevel = 1;
		poisonLevel = 1;
		explosionLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void UpgradeClick(){
		clickManager.clickPower *= 2f;
		clickLevel++;
		clickPowerText.text = "Click Power \nlvl " + clickLevel.ToString();
	}

	public void UpgradeAutoClick(){
		clickManager.autoClickPower *= 2f;
		autoClickLevel++;
		autoClickPowerText.text = "Auto Click Power \nlvl " + autoClickLevel.ToString();
	}

	public void UpgradePoison(){
		clickManager.poisonPower *= 2f;
		poisonLevel++;
		poisonPowerText.text = "Poison Power \nlvl " + poisonLevel.ToString();
	}

	public void UpgradeExplosion(){
		clickManager.explosionPower *= 2f;
		explosionLevel++;
		explosionPowerText.text = "Explosion Power \nlvl " + explosionLevel.ToString();
	}
}
