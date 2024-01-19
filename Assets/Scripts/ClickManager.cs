using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
	[SerializeField] private bool autoClickEnabled;
	public float delay = 1f;

	public float clickPower = 2f;
	public float autoClickPower = 1f;
	public float explosionPower = 10f;
	public float poisonPower = 1f;

	public TextMeshProUGUI scoreText;
    public MonsterManager monsterManager;

	private float score;

    // Start is called before the first frame update
    void Start()
    {
		if (autoClickEnabled){
			StartCoroutine(AutoClick());
		}
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void OnClick(){
		UpdateScore(clickPower, true);
	}

	public void UpdateScore(float value, bool clicked){
		score += value;
        monsterManager.Attack(value, clicked);
		scoreText.text = "Clicks :" + score.ToString();
	}

	private IEnumerator AutoClick() {
		while (autoClickEnabled) {
			UpdateScore(autoClickPower, false);
			yield return new WaitForSeconds(delay);
		} 
		while (!autoClickEnabled) {
			yield return new WaitForSeconds(delay * 5);
		}
	}
}
