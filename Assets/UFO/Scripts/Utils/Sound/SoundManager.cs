using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Utils.Sound
{
	public class SoundManager : SingletonGameobject<SoundManager> {

		public AudioSource SoundAudioSource => soundSource;

        [SerializeField] private AudioSource soundSource = null;
		[SerializeField] private AudioSource musicSource = null;

		[SerializeField] private AudioClip[] sound = null;

		protected override void Awake()
		{
			isDontDestroyOnLoad = true;
			base.Awake();
		}

		private void Start()
		{
			PlayMusic ();
		}


		public void PlaySound(int id)
		{
			if (id < sound.Length) {
				if (sound [id]) {
					soundSource.clip = sound [id];
					soundSource.Play ();
				}
			}
		}

		public void PlaySound(int id, Action callback)
		{
			PlaySound(id);
			StartCoroutine(WaitForSound(callback));
		}

		public void PlaySound(AudioClip clip)
		{
			soundSource.clip = clip;
			soundSource.Play();
		}

		public void PlaySound(AudioClip clip, Action callback)
		{
			soundSource.clip = clip;
			soundSource.Play();
			StartCoroutine(WaitForSound(callback));
		}


		public void StopSound()
		{
			soundSource.Stop();
			StopAllCoroutines();
		}

		private IEnumerator WaitForSound(Action callback)
		{
			yield return new WaitUntil(() => (soundSource.isPlaying == false && isApplicationPaused == false));
			callback?.Invoke();
		}

		public void PlayMusic()
		{
			musicSource.Play ();
		}

		public void PauseMusic()
		{
			musicSource.Pause ();
		}

        private void OnEnable()
        {
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Debug.Log("Stop Corountine On Scene Loaded");
			StopAllCoroutines();
		}

		private bool isApplicationPaused = false;

		private void OnApplicationFocus(bool hasFocus)
		{
			isApplicationPaused = !hasFocus;
			//Debug.Log(isApplicationPaused);
		}
	}
}
