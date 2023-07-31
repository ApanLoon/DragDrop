
using System;
using UnityEngine;

namespace DataObjects
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataComponentEditorAttribute : Attribute
    {
        public Type For { get; set; }
    }
}
