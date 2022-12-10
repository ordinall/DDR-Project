using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using TMPro;

public class CpuTimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    private float _time;
    private float[] DeltaTimes = new float[100];
    private void Update()
    {
        for (int i = 0; i < DeltaTimes.Length - 1; i++)
        {
            DeltaTimes[i] = DeltaTimes[i + 1];
        }
        DeltaTimes[DeltaTimes.Length - 1] = Time.deltaTime;
        
        float average = 0;
        for (int i = 0; i < DeltaTimes.Length; i++)
        {
            average += DeltaTimes[i];
        }
        average /= DeltaTimes.Length;
        // update text after a second
        _time += Time.deltaTime;
        if (_time > 1)
        {
            _textMesh.text = $"CPU Time: {average * 1000:0.00} ms";
            _time = 0;
        }
    }
}
