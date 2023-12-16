using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Tetris
{
    public class TetrisImage : MonoBehaviour, IPoolObject
    {
        public Vector2Int Position 
        { 
            get => position; 
            set
            {
                if (position == value) 
                    return;

                position = value;
                transform.position = new Vector3(position.x, position.y, 0);
            }
        }
        public int Size 
        { 
            get => size;
            set
            {
                if (size == value)
                    return;
                size = value;
                RectTransform rectTransform = (RectTransform)transform;
                rectTransform.sizeDelta = new Vector2(size, size);
            }
        }
        public Sprite Sprite 
        { 
            get => sprite;
            set
            {
                if (sprite == value) 
                    return; 
                
                sprite = value;
                image.sprite = sprite;
            }
        }

        [SerializeField]
        private Image image = null;

        private int size = 0;
        private Vector2Int position = Vector2Int.zero;
        private Sprite sprite = null;

        public void Acquire()
        {
        }

        public void Reclaim()
        {
            Position = new Vector2Int(-Screen.width * 5, 0);
        }
    }
}