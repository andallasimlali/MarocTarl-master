﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Choice
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

}