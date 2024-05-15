

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.OpenXR;

namespace Qualcomm.Snapdragon.Spaces.Samples
{
    public class PassthroughHelper : MonoBehaviour
    {
        private BaseRuntimeFeature _baseRuntimeFeature;
        public void Start()
        {
            _baseRuntimeFeature = OpenXRSettings.Instance.GetFeature<BaseRuntimeFeature>();
        }

        public void OnEnable()
        {
            StartCoroutine(EnablePassthroough());
        }

        private IEnumerator EnablePassthroough()
        {
            yield return new WaitForSeconds(1.0f);
            if (_baseRuntimeFeature.IsPassthroughSupported())
                _baseRuntimeFeature.SetPassthroughEnabled(true);
        }
    }
}
