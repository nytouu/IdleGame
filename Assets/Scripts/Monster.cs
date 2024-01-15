using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster", order = 1)]
public class Monster : ScriptableObject
{
	public string displayName;
	public float hp;
	public Sprite texture;
}
