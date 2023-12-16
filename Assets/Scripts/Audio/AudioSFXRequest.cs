using UnityEngine;
using UnityEngine.UIElements;

namespace Audio
{
    public class AudioSFX
    {
        public AudioEvent Sound { get; }
        public bool Is2D { get; }
        public Vector3 Position { get; }
        public Transform Parent { get; }
        public float PitchOverride { get; }
        public float VolumeOverride { get; }
        private AudioSFX(AudioEvent _sound, bool _is2D = true, Vector3 _position = default, Transform _parent = null, float _pitchOverride = 0.0f, float _volumeOverride = 1.0f)
        {
            Sound = _sound;
            Is2D = _is2D;
            Position = _position;
            Parent = _parent;
            PitchOverride = _pitchOverride;
            VolumeOverride = _volumeOverride;
        }

        /// <summary>
        /// Request a single Audio Sound Event.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_position">Position for the audio event</param>
        /// <param name="_parent">Parent transform for the audio event</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, Vector3 _position, Transform _parent)
        {
            return new AudioSFX(_sound, false, _position, _parent);
        }

        /// <summary>
        /// Request a single non-diegetic Audio Sound Event without volume or custom pitch effects.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound)
        {
            return new AudioSFX(_sound);
        }

        /// <summary>
        /// Request a single non-diegetic Audio Sound Event with volume override.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_volumeOverride">Volume value multiplier</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, float _volumeOverride)
        {
            return new AudioSFX(_sound, true, Vector3.zero, null, 0.0f, _volumeOverride);
        }

        /// <summary>
        /// Request a single diegetic Audio Sound Event with volume and pitch override.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_parent">Parent transform for the audio event</param>
        /// <param name="_pitchOverride">Pitch value override (direct)</param>
        /// <param name="_volumeOverride">Volume value multiplier</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, Transform _parent, float _pitchOverride, float _volumeOverride)
        {
            return new AudioSFX(_sound, false, _parent.position, _parent, _pitchOverride, _volumeOverride);
        }

        /// <summary>
        /// Request a single non-diegetic Audio Sound Event with volume and pitch override.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_pitchOverride">Pitch value override (direct)</param>
        /// <param name="_volumeOverride">Volume value multiplier</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, float _pitchOverride, float _volumeOverride)
        {
            return new AudioSFX(_sound, true, Vector3.zero, null, _pitchOverride, _volumeOverride);
        }
        /// <summary>
        /// Request a single diegetic Audio Sound Event with volume override.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_parent">Parent transform for the audio event</param>
        /// <param name="_volumeOverride">Volume value multiplier</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, Transform _parent, float _volumeOverride)
        {
            return new AudioSFX(_sound, false, _parent.position, _parent, 0.0f, _volumeOverride);
        }
        /// <summary>
        /// Request a single diegetic Audio Sound Event without volume and pitch override.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_parent">Parent transform for the audio event</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, Transform _parent)
        {
            return new AudioSFX(_sound, false, _parent.position, _parent);
        }
        /// <summary>
        /// Request a single diegetic Audio Sound Event without volume and pitch override.
        /// </summary>
        /// <param name="_sound">Requested Sound</param>
        /// <param name="_position">Position for the audio event</param>
        /// <returns></returns>
        public static AudioSFX Request(AudioEvent _sound, Vector3 _position)
        {
            return new AudioSFX(_sound, false, _position);
        }
    }
}
