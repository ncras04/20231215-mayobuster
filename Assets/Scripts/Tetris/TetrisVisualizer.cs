using Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    [System.Serializable]
    public struct CharToSprite
    {
        public char Character => character;
        public Sprite Sprite => sprite;

        [SerializeField]
        private char character;
        [SerializeField]
        private Sprite sprite;

        public CharToSprite(char character, Sprite sprite)
        {
            this.character = character;
            this.sprite = sprite;
        }
    }

    public class TetrisVisualizer : MonoBehaviour
    {
        [SerializeField]
        private TetrisProvider provider = null;
        [SerializeField]
        private List<CharToSprite> sprites = new List<CharToSprite>()
        {
            new CharToSprite('I', null),
            new CharToSprite('J', null),
            new CharToSprite('L', null),
            new CharToSprite('O', null),
            new CharToSprite('S', null),
            new CharToSprite('Z', null),
            new CharToSprite('T', null)
        };
        [SerializeField]
        private Canvas canvas = null;
        [SerializeField]
        private TetrisImage imagePrefab = null;

        private Dictionary<char, Sprite> charToSprite = new Dictionary<char, Sprite>();
        private ObjectPool<TetrisImage> imagePool = null;

        private int spriteSize = 0;

        private void Awake()
        {
            foreach (CharToSprite item in sprites)
            {
                charToSprite.Add(item.Character, item.Sprite);
            }
        }

        private void Start()
        {
            if (charToSprite.Count == 0)
            {
                Debug.LogError("No sprites to use for tetris!", this);
                return;
            }
            imagePool = new ObjectPool<TetrisImage>(imagePrefab, (provider.Width * provider.Height) / 10);
            // Set sprite size to match canvas size
            SetSpriteSize();

            provider.OnBoardUpdated += VisualizeBoardState;
        }

        private void SetSpriteSize()
        {
            int width = Screen.width;
            int height = Screen.height;

            int spriteWidth = width / provider.Width;
            int spriteHeight = height / provider.Height;

            // sprites must be square at the end
            spriteSize = Mathf.Min(spriteWidth, spriteHeight);
        }

        private void VisualizeBoardState(char[,] _board)
        {
            imagePool.ForceReleaseAll();

            for (int x = 0; x < provider.Width; x++)
            {
                for (int y = 0; y < provider.Height; y++)
                {
                    if (!charToSprite.ContainsKey(_board[x, y]))
                        continue;

                    TetrisImage image = imagePool.Acquire();
                    image.transform.SetParent(canvas.transform, false);
                    image.Position = new Vector2Int((int)(spriteSize * 0.5f) + x * spriteSize, Screen.height - (int)(spriteSize * 0.5f) - y * spriteSize);
                    image.Sprite = charToSprite[_board[x, y]];
                    image.Size = spriteSize;
                }
            }
        }
    }
}
