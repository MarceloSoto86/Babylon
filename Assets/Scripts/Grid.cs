using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize = 10;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width= width;
        this.height= height;

        gridArray = new int[width,height];
        debugTextArray= new TextMesh[width,height];

        for(int x = 0; x < gridArray.GetLength(0);x++)
        {
            for(int y = 0; y < gridArray.GetLength(1);y++)
            {
                debugTextArray[x,y] = CreateWorldText(gridArray[x,y].ToString(),null,GetWorldPosition(x,y) + new Vector3(cellSize,cellSize) * 0.5f,30,Color.white,TextAnchor.MiddleCenter,TextAlignment.Center,10);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x+1,y),Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 1, 56);
    }

    public static TextMesh CreateWorldText(string text, object value, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor,TextAlignment textAlignment,int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
       // transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }



    public void SetValue(int x, int y, int value)
    {
        if(x >0 && y >0 && x < width && y < height) 
        { 
        gridArray[x,y] = value;
            debugTextArray[x,y].text = gridArray[x,y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition,int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

}
