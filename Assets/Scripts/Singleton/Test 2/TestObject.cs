using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Singleton.Test_2
{
    public class TestObject : MonoBehaviour
    {
        public IDataProvider dataProvider;

        public interface IDataProvider
        {
            List<MyComplexData> GetData();
        }

        public void AccessData()
        {
            List<MyComplexData> data = dataProvider.GetData();
            for (int i = 0; i < data.Count; i++)
            {
                MyComplexData item = data[i];
                item.value1 += Mathf.Sin(item.value2);
                item.value2 *= Mathf.Cos(item.value1);
                item.value3 = Vector3.RotateTowards(item.value3, Vector3.up, 0.1f, 0.1f);
                item.value4 = Quaternion.Lerp(item.value4, Quaternion.identity, 0.05f);
                data[i] = item;
            }
        }
    }

    public struct MyComplexData
    {
        public float value1;
        public float value2;
        public Vector3 value3;
        public Quaternion value4;

        public MyComplexData(float v1, float v2, Vector3 v3, Quaternion v4)
        {
            value1 = v1;
            value2 = v2;
            value3 = v3;
            value4 = v4;
        }
    }
}