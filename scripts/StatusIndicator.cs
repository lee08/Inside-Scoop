using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

	[SerializeField]
	private RectTransform healthBarrect;
	[SerializeField]
	private Text healthText;

	void Start() {
		if (healthBarrect == null) {
			Debug.LogError ("no healthbarobject referenced");

		}
		if (healthText == null) {
			Debug.LogError ("no health text referenced");

		}

	}

	public void SetHealth(float _cur, float _max) {
		float _value = (float)_cur / _max;
		healthBarrect.localScale = new Vector3 (_value, healthBarrect.localScale.y, healthBarrect.localScale.z);
		healthText.text = _cur + "/" + _max + "HP";
	}

}
