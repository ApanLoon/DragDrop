using DataObjects;
using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class UiItem : DataDefinitionComponent
    {
        public Texture2D Icon;
        public string Name;
        public string Description;
        public Guid Id = Guid.NewGuid();
    }
}
