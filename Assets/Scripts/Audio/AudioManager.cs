using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Audio;
using System.Threading.Tasks;
using Audio;
using UnityEngine.SceneManagement;


[DefaultExecutionOrder(-1000)]
public class AudioManager : MonoBehaviour
{
    private string m_tag = "AudioManager";
    [Header("BGM")]
    [SerializeField]
    private BGMRequestCollection m_BGMRequests;
    [SerializeField]
    private AudioMixerGroup m_BGMOutput;
    [SerializeField]
    private float m_fadeDuration;

    private AudioSource m_bgm1;
    private AudioSource m_bgm2;

    [Header("SFX")]
    [SerializeField]
    [Range(0, 0.5f)]
    [Tooltip("Randomized Pitch Range")]
    private float m_pitchEffect = 0.1f;

    [SerializeField]
    private AudioMixerGroup m_soundFXOutput;

    [SerializeField]
    private GameObject m_poolObjectPrefab;

    [SerializeField]
    private int m_maxPoolSize;

    [SerializeField]
    private SoundFXRequestCollection m_requests;

    private IObjectPool<GameObject> m_pool;

    private void Awake()
    {
        gameObject.tag = m_tag;

        GameObject[] objs = GameObject.FindGameObjectsWithTag(m_tag);

        if (objs.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        m_pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, m_maxPoolSize, m_maxPoolSize);

        m_bgm1 = gameObject.AddComponent<AudioSource>();
        m_bgm1.spatialBlend = 0.0f;
        m_bgm1.playOnAwake = false;
        m_bgm1.loop = true;
        m_bgm1.outputAudioMixerGroup = m_BGMOutput;

        m_bgm2 = gameObject.AddComponent<AudioSource>();
        m_bgm2.spatialBlend = 0.0f;
        m_bgm2.playOnAwake = false;
        m_bgm2.loop = true;

        m_bgm2.outputAudioMixerGroup = m_BGMOutput;
    }

    public GameObject CreatePooledItem()
    {
        GameObject go = Instantiate(m_poolObjectPrefab);
        AudioSFXObject obj = go.GetComponent<AudioSFXObject>();
        //go.transform.SetParent(transform);
        go.SetActive(true);

        obj.Pool = m_pool;

        return go;
    }

    public void OnTakeFromPool(GameObject _go)
    {
        _go.SetActive(true);
    }

    public void OnReturnedToPool(GameObject _go)
    {
        _go.SetActive(false);
    }

    public void OnDestroyPoolObject(GameObject _go)
    {
        Destroy(_go);
    }

    public void Start()
    {
        m_requests.OnAdd += OnSoundRequest;
        m_BGMRequests.OnAdd += OnBGMRequest;

        SceneManager.activeSceneChanged += ClearPoolOnSceneLoad;
    }

    private void ClearPoolOnSceneLoad(Scene _old, Scene _new)
    {
        m_pool.Clear();
    }

    async void QueueSong(AudioSource _isWaiting, float _isWaitingVolume, AudioSource _isPlaying, float _duration)
    {
        float volumeDuration = 0;
        float volumeDiff = 0;

        float isPlayingVolume = _isPlaying.volume;

        while (volumeDuration < _duration)
        {
            volumeDuration += Time.deltaTime;

            volumeDiff = volumeDuration / _duration;

            _isPlaying.volume = Mathf.Lerp(isPlayingVolume, 0, volumeDiff);
            _isWaiting.volume = Mathf.Lerp(0, _isWaitingVolume, volumeDiff);
            await Task.Yield();
        }

        _isPlaying.Stop();
    }

    private void OnBGMRequest(AudioBGM _request)
    {
        AudioSource isPlaying;
        AudioSource isWaiting;

        if (m_bgm1.timeSamples > m_bgm2.timeSamples)
        {
            isPlaying = m_bgm1;
            isWaiting = m_bgm2;
        }
        else
        {
            isPlaying = m_bgm2;
            isWaiting = m_bgm1;
        }

        if (isPlaying.clip == _request.Music.Song)
        {
            isWaiting.clip = null;
            float fadeDurr = m_fadeDuration * _request.FadeOverride;
            float isWaitingVoll = _request.Music.Volume * _request.VolumeOverride;

            if (fadeDurr < 0.025f)
                fadeDurr = 0.025f;
            QueueSong(isWaiting, isWaitingVoll, isPlaying, fadeDurr);

            m_BGMRequests.Remove(_request);
            return;
        }

        isWaiting.clip = _request.Music.Song;
        isWaiting.volume = 0;
        isWaiting.Play();

        float fadeDur = m_fadeDuration * _request.FadeOverride;
        float isWaitingVol = _request.Music.Volume * _request.VolumeOverride;

        if (fadeDur < 0.025f)
            fadeDur = 0.025f;

        QueueSong(isWaiting, isWaitingVol, isPlaying, fadeDur);

        m_BGMRequests.Remove(_request);
    }
    private void OnSoundRequest(AudioSFX _request)
    {
        AudioSFXObject tmp = m_pool.Get().GetComponent<AudioSFXObject>();
        AudioSource tmpSource = tmp.Source;
        AudioEvent tmpEvent = _request.Sound;

        tmp.transform.position = _request.Position;
        tmp.transform.SetParent(_request.Parent);

        tmp.name = $"{tmpEvent.name}-Sound";

        tmpSource.outputAudioMixerGroup = m_soundFXOutput;

        if (tmpEvent.Clips.Length > 1)
        {
            int rnd = Random.Range(0, tmpEvent.Clips.Length - 1);

            if (rnd == tmpEvent.LastPlayedClip)
                rnd = rnd == 0 ? 1 : tmpEvent.LastPlayedClip - 1;

            tmpEvent.SetLastClipPlayed(rnd);
            tmpSource.clip = tmpEvent.Clips[rnd];
        }
        else
            tmpSource.clip = tmpEvent.Clips[0];

        if (tmpEvent.IsPitchAffected)
            tmpSource.pitch = _request.PitchOverride == 0.0f ? Random.Range(1.0f - m_pitchEffect, 1.0f + m_pitchEffect) : _request.PitchOverride;

        tmpSource.volume = tmpEvent.Volume * _request.VolumeOverride;
        tmpSource.spatialBlend = _request.Is2D ? 0.0f : 1.0f;

        tmpSource.Play();

        m_requests.Remove(_request);
    }
}
