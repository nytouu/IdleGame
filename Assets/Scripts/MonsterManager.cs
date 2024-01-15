using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
	private Monster currentMonster;
	private float xp, increment;

	[SerializeField] Image monsterImage; 
	[SerializeField] TextMeshProUGUI xpText; 
	[SerializeField] TextMeshProUGUI monsterText; 
	[SerializeField] Camera mainCamera;

	public List<Monster> monsterList;
	public Color firstColor;
	public Color secondColor;

    // Start is called before the first frame update
    void Start()
    {
		Spawn();
		xp = 0;
		increment = 1;
    }

	public void Attack(float power) {
		if (currentMonster) {
			currentMonster.hp -= power;
			if (currentMonster.hp <= 0) {
				UpdateXp(xp += increment);
				increment *= 1.5f;

				Spawn();
			}
		}
	}

	public void Spawn(){
		Monster selected = GetFromList();
		currentMonster = ScriptableObject.CreateInstance<Monster>();

		currentMonster.hp = selected.hp;
		currentMonster.texture = selected.texture;
		currentMonster.displayName = selected.displayName;

		monsterText.text = selected.displayName;
		monsterImage.sprite = selected.texture;
	}

	public Monster GetFromList(){
		int i = Random.Range(0, monsterList.Count);
		return monsterList[i];
	}

	private void UpdateXp(float value){
		xp += value;
		xpText.text = xp.ToString();

		if (xp > 1000){
			mainCamera.backgroundColor = secondColor;
		} else if (xp > 100){
			mainCamera.backgroundColor = firstColor;
		}
	}
}
