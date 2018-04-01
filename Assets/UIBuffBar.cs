using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BuffUI
{
	public SkillData data;
	public GameObject ui;
}
public class UIBuffBar : MonoBehaviour {

	public GameObject buffPrefab;
	public List<BuffUI> buffSkills;

	// Use this for initialization
	public void AddBuff (SkillData data) {
		var buff = Instantiate(buffPrefab, transform);
		buff.GetComponentInChildren<Image>().sprite = data.skilImage;
		buff.GetComponentInChildren<Text>().text = data.buffLength.ToString();
		var ui = new BuffUI();
		ui.data = data;
		ui.ui = buff;
		buffSkills.Add(ui);
	}
	
	public void UpdateBuffs () {
		List<BuffUI> deleted = new List<BuffUI>();
		foreach(BuffUI bui in buffSkills)
		{
			bui.data.buffLength -= 1;
			if(bui.data.buffLength <= 0)
			{
				Destroy(bui.ui);
				Destroy(bui.data);
				deleted.Add(bui);
			}
			bui.ui.GetComponentInChildren<Text>().text = bui.data.buffLength.ToString();
		}
		buffSkills.RemoveAll(item => deleted.Contains(item));
	}
}
