using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Models
{
    public class Question
    {
        public string Text { get; set; }  // "Какой тип шкафа вам необходим?"
        public List<string> Options { get; set; }  // ["Напольный", "Настенный", "19\""]
        public string SelectedOption { get; set; }
    }
}
