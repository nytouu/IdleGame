using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
	[SerializeField] private bool autoClickEnabled;
	[SerializeField] private float clickPower = 2;
	[SerializeField] private float autoClickPower = 1f;
	public float delay = 1f;

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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			UpdateScore(clickPower);
		}
    }

	public void UpdateScore(float value){
		score += value;
        monsterManager.Attack(value);
		scoreText.text = score.ToString();
	}

	private IEnumerator AutoClick() {
		while (autoClickEnabled) {
			UpdateScore(autoClickPower);
			yield return new WaitForSeconds(delay);
		} 
		while (!autoClickEnabled) {
			yield return new WaitForSeconds(delay * 5);
		}
	}
}
