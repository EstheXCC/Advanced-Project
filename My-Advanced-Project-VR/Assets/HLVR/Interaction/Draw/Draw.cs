using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public int width;
    public int height;
    Texture2D m_DrawingBoard;
    public Penpoint penpoint;
    public MeshRenderer DrawingBoard;
    bool recordStartPos=true;
    Vector3 starPos;
    private void Start() 
    {
        m_DrawingBoard = new Texture2D(width,height);//创建画本贴图
        DrawingBoard.material.SetTexture("www", m_DrawingBoard);
     //   DrawingBoard.material.mainTexture = m_DrawingBoard;
        penpoint.penPointColor = new Color32[width*height];
        for (int i = 0; i < penpoint.penPointColor.Length; i++)
        {
            penpoint.penPointColor[i] = Color.white;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) DrawContent();
        //else recordStartPos = true;
    }
    void DrawContent()//绘制内容
    {
        m_DrawingBoard.SetPixels32(Mathf.Abs(Mathf.FloorToInt(PenPosition().x)), Mathf.Abs(Mathf.FloorToInt(PenPosition().y)), penpoint.penPointSize, penpoint.penPointSize,penpoint.penPointColor);
        if (recordStartPos)
        {
            starPos = new Vector3(PenPosition().x, PenPosition().y);
            recordStartPos = false;
        }
        //for (int i = 1; i < 60; i++)
        //{

        //    Vector2 poslerp = Vector2.Lerp(starPos, new Vector2(PenPosition().x, PenPosition().y), 1f / i);
        //    print(poslerp);
        //    // starPos = new Vector3(Mathf.FloorToInt(PenPosition().x), Mathf.FloorToInt(PenPosition().y));
        //    m_DrawingBoard.SetPixels32(Mathf.FloorToInt(poslerp.x), Mathf.FloorToInt(poslerp.y), penpoint.penPointSize, penpoint.penPointSize, penpoint.penPointColor);
        //}

        m_DrawingBoard.Apply();
    }
    RaycastHit hit;
    Vector2 PenPosition()
    {
        if (Physics.Raycast(RayPen(), out hit))
            return new Vector2(hit.textureCoord.x, hit.textureCoord.y)* width;
        else return new Vector2(0,0);
    }

    Ray RayPen()
    {
       return Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10));
    }

}

[System.Serializable]
public struct Penpoint 
{
    public int penPointSize;

    public Color32[] penPointColor;
}
