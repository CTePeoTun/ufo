#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.Sound
{
	public class SoundEditor  {

		[MenuItem("Settings/Sound/Add Sound To Buttons On Scene")]
		private static void AddSfxButton()
		{
			int counter = 0;
			Button[] btns = (Button[]) Resources.FindObjectsOfTypeAll (typeof(Button));
			foreach (var btn in btns) {
				if (!btn.gameObject.GetComponent<SfxClick> ()) {
					btn.gameObject.AddComponent <SfxClick> ();
					counter++;
				}
			}
			Debug.Log ("SFX has been added to Button " + counter);
		}

		[MenuItem("Settings/Sound/Add Sound To Toggle On Scene")]
		private static void AddSfxToggle()
		{
			int counter = 0;
			Toggle[] btns = (Toggle[]) Resources.FindObjectsOfTypeAll (typeof(Toggle));
			foreach (var btn in btns) {
				if (!btn.gameObject.GetComponent<SfxClick> ()) {
					btn.gameObject.AddComponent <SfxClick> ();
					counter++;
				}
			}
			Debug.Log ("SFX has been added to Toggle " + counter);
		}
	}
}
#endif