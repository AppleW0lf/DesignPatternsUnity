using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Scripts.MVVM_Test3.MVVM
{
    public class TextEditorModel
    {
        public string Text { get; set; } = "";
        public List<string> Keywords { get; } = new List<string>() { "if", "else", "for", "while" };

        public event Action<string> OnTextChanged;

        public void SetText(string newText)
        {
            Text = newText;
            OnTextChanged?.Invoke(Text);
        }
    }
}