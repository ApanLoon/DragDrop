using System;
using UnityEngine;

namespace Items
{
    public abstract class ItemDefinition : ScriptableObject
    {
        public Texture2D Icon;
        public string Name;
        public string Description;
        public Guid Id = Guid.NewGuid();
    }
}

