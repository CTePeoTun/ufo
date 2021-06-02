using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.Sound
{
	public class SfxClick : MonoBehaviour, IPointerClickHandler
	{

		public void OnPointerClick(PointerEventData data)
		{
			SoundManager.Instance.PlaySound (0);
		}
	}
}
