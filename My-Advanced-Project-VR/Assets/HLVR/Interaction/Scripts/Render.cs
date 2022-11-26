using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HLVR.Interaction
{
    public static class Render 
    {
        /// <summary>
        /// �����߶���Ⱦ
        /// </summary>
        /// <param name="line">lineRender����</param>
        /// <param name="starPoint">�����߶ε���ʼ��</param>
        /// <param name="endPoint">�����߶ε��յ�</param>
        /// <param name="starWidth">�����߶ε���ʼ���</param>
        /// <param name="endWidth">�����߶εĽ�β���</param>
        /// <param name="material">�߶εĲ�����</param>
        /// <param name="starColor">�����߶ε���ʼ��ɫ</param>
        /// <param name="endColor">�����߶εĽ�β��ɫ</param>
        public static void RenderTwoPointSegment(LineRenderer line,Vector3 starPoint,Vector3 endPoint,float starWidth,float endWidth,Material material, Gradient gradientColor)//�����߶���Ⱦ
        {
            line.SetPosition(0,starPoint);
            line.SetPosition(1,endPoint);
            line.startWidth = starWidth;
            line.endWidth = endWidth;
            line.material = material;
            line.colorGradient = gradientColor;
        }
        /// <summary>
        /// ����߶���Ⱦ
        /// </summary>
        /// <param name="line">lineRender����</param>
        /// <param name="points">����߶εĹ��ɵ�����</param>
        /// <param name="starWidth">�����߶ε���ʼ���</param>
        /// <param name="endWidth">�����߶εĽ�β���</param>
        /// <param name="material">�߶εĲ�����</param>
        /// <param name="starColor">�����߶ε���ʼ��ɫ</param>
        /// <param name="endColor">�����߶εĽ�β��ɫ</param>
        public static void RenderMultiPointSegment(LineRenderer line,Vector3[] points, float starWidth, float endWidth, Material material,Gradient gradientColor)//����߶���Ⱦ
        {
            line.SetPositions(points);
            line.startWidth = starWidth;
            line.endWidth = endWidth;
            line.material = material;
            line.colorGradient = gradientColor;
           
        }


        public static void LineRenderState(LineRenderer line ,bool state)
        {
            line.enabled = state;
        }

    }
}

