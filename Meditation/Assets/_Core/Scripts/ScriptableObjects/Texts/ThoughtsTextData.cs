using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace _Core.Scripts.ScriptableObjects.Texts
{
    [CreateAssetMenu(fileName = "ThoughtsTextData", menuName = "ScriptableObjects/TextThoughts")]
    public class ThoughtsTextData: ScriptableObject
    {
        public string thoughtTextOne;
        public string thoughtTextTwo;
        public string thoughtTextThree;
    }
}