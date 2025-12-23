using System;
using _Core.Scripts.ScriptableObjects.Texts;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Core.Scripts.Objects.Collectable.Text_for_objects
{
    public abstract class ThoughtTextGeneral : MonoBehaviour
    {
        [SerializeField] protected TextMeshPro _thoughtText;
        [SerializeField] protected ThoughtsTextData _thoughtTextData;

        protected void Start()
        {
            int randomIndex = Random.Range(0, 3);
            RandomText(randomIndex);
        }

        protected abstract void RandomText(int randomIndex);

    }
}