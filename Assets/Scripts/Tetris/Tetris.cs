using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Security;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using System.Linq;
using UnityEditor.Timeline.Actions;

public class Tetris : MonoBehaviour
{

    [SerializeField]
    private int width = 10;
    [SerializeField]
    private int height = 20;
    private char[,] board;
    Tetris()
    {
        board = new char[width, height];
    }

    struct Direction
    {
        public int x;
        public int y;
    }

    struct Field
    {
        public int x;
        public int y;
    }
    struct Part
    {
        public Field[] fields;
    }

    private Part? currentPart;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2)
        {
            onTick();
            time = 0;
        }

        if (Input.GetKeyDown("left"))
        {
            var left = new Direction { x = -1, y = 0 };
            if (canMovePart(left))
            {
                movePart(left);
            }
        }
        if (Input.GetKeyDown("right"))
        {
            var right = new Direction { x = 1, y = 0 };
            if (canMovePart(right))
            {
                movePart(right);
            }
        }
        if(Input.GetKeyDown("up"))
        {
            rotate(true);
        }
        if (Input.GetKeyDown("down"))
        {
            rotate(false);
        }
    }

    void onTick()
    {
        if (currentPart == null)
        {
            var posibleParts = new char[] { 'I', 'J', 'L', 'O', 'S', 'Z', 'T' };
            currentPart = createNewPart(posibleParts[UnityEngine.Random.Range(0, posibleParts.Length)]);
        }
        var down = new Direction { x = 0, y = 1 };
        if (canMovePart(down))
        {
            movePart(down);
        }
        else
        {
            currentPart = null;
        }
    }

    Part? createNewPart(char c)
    {
        Func<Part?> partCreator =() =>
        {
            switch (c)
            {
                case 'I': return new Part { fields = new Field[] { new Field { x = 2, y = 0 }, new Field { x = 3, y = 0 }, new Field { x = 4, y = 0 }, new Field { x = 5, y = 0 } } };
                case 'J': return new Part { fields = new Field[] { new Field { x = 2, y = 0 }, new Field { x = 3, y = 0 }, new Field { x = 4, y = 0 }, new Field { x = 4, y = 1 } } };
                case 'L': return new Part { fields = new Field[] { new Field { x = 3, y = 1 }, new Field { x = 3, y = 0 }, new Field { x = 4, y = 0 }, new Field { x = 5, y = 0 } } };
                case 'O': return new Part { fields = new Field[] { new Field { x = 3, y = 1 }, new Field { x = 3, y = 0 }, new Field { x = 4, y = 0 }, new Field { x = 4, y = 1 } } };
                case 'S': return new Part { fields = new Field[] { new Field { x = 2, y = 1 }, new Field { x = 3, y = 1 }, new Field { x = 4, y = 0 }, new Field { x = 3, y = 0 } } };
                case 'Z': return new Part { fields = new Field[] { new Field { x = 2, y = 0 }, new Field { x = 3, y = 0 }, new Field { x = 4, y = 1 }, new Field { x = 3, y = 1 } } };
                case 'T': return new Part { fields = new Field[] { new Field { x = 2, y = 0 }, new Field { x = 3, y = 0 }, new Field { x = 4, y = 0 }, new Field { x = 3, y = 1 } } };
            }
            return null;
        };
        currentPart = partCreator();
        if (currentPart != null)
        {
            Array.ForEach(currentPart.Value.fields, field => board[field.x, field.y] = c);
        }
        return currentPart;
    }

    void movePart(Direction dir)
    {
        if (currentPart != null)
        {
            char currentChar = board[currentPart.Value.fields[0].x, currentPart.Value.fields[0].y];
            Array.ForEach(currentPart.Value.fields, field => board[field.x, field.y] = (char)0);
            currentPart = new Part { fields = currentPart.Value.fields.Select(field => new Field { x = field.x + dir.x, y = field.y + dir.y }).ToArray() };
            Array.ForEach(currentPart.Value.fields, field => board[field.x, field.y] = currentChar);
        }
    }

    bool canMovePart(Direction dir)
    {
        if (currentPart != null)
        {
            return !Array.Exists(currentPart.Value.fields, field => blockingField(currentPart.Value, new Field { x = field.x + dir.x, y = field.y + dir.y }));
        }
        return false;
    }

    void rotate(bool left)
    {
        if (currentPart != null)
        {
            var newPos =left ? calcPosRotatedLeft(currentPart.Value.fields) : calcPosRotatedRight(currentPart.Value.fields);
            foreach (var it in currentPart.Value.fields.Select((Value, Index) => new { Value, Index }))
            {
                if (blockingField(currentPart.Value, newPos[it.Index]))
                {
                    return;
                }
            }
            char currentChar = board[currentPart.Value.fields[0].x, currentPart.Value.fields[0].y];
            Array.ForEach(currentPart.Value.fields, field => board[field.x, field.y] = (char)0);
            currentPart = new Part { fields = newPos };
            Array.ForEach(currentPart.Value.fields, field => board[field.x, field.y] = currentChar);
        }
    }

    Field[] calcPosRotatedLeft(Field[] startPos)
    {
        var vec = startPos.Select(field => new Vector2Int { x = field.x, y = field.y }).ToArray();

        var dif = vec[1] - vec[0];
        vec[0] = vec[1] + new Vector2Int { x = -dif.y, y = dif.x };

         dif = vec[1] - vec[2];
        vec[2] = vec[1] + new Vector2Int { x = -dif.y, y = dif.x };

         dif = vec[1] - vec[3];
        vec[3] = vec[1] + new Vector2Int { x = -dif.y, y = dif.x };


        return vec.Select(field => new Field { x = field.x, y = field.y }).ToArray(); ;
    }
    Field[] calcPosRotatedRight(Field[] startPos)
    {
        var vec = startPos.Select(field => new Vector2Int { x = field.x, y = field.y }).ToArray();

        var dif = vec[1] - vec[0];
        vec[0] = vec[1] + new Vector2Int { x = dif.y, y = dif.x };

        dif = vec[1] - vec[2];
        vec[2] = vec[1] + new Vector2Int { x = dif.y, y = dif.x };

        dif = vec[1] - vec[3];
        vec[3] = vec[1] + new Vector2Int { x = dif.y, y = dif.x };


        return vec.Select(field => new Field { x = field.x, y = field.y }).ToArray(); ;
    }


    bool blockingField(Part part, Field fieldToTest)
    {
        return isOutsideBoard(fieldToTest) || !isSamePart(part, fieldToTest) && !isFreeField(fieldToTest);
    }

    bool isOutsideBoard(Field fieldToTest)
    {
        return fieldToTest.x < 0 || fieldToTest.x >= width
            || fieldToTest.y < 0 || fieldToTest.y >= height;
    }

    bool isSamePart(Part part, Field fieldToTest)
    {
        return Array.Exists(part.fields, element => element.x == fieldToTest.x && element.y == fieldToTest.y);
    }

    bool isFreeField(Field fieldToTest)
    {
        return board[fieldToTest.x, fieldToTest.y] == 0;
    }

    private void OnDrawGizmos()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Gizmos.color  = getColor(board[x, y]);
                Gizmos.DrawCube(new Vector3(x+0.5f, 0, y+0.5f), Vector3.one);
            }
        }
    }

    Color getColor(char c)
    {
        switch (c)
        {
            case 'I': return Color.red;
            case 'J': return Color.yellow;
            case 'L': return Color.black;
            case 'O': return Color.green;
            case 'S': return Color.cyan;
            case 'Z': return Color.blue;
            case 'T': return Color.white;
        }
        return Color.gray;
    }
}
