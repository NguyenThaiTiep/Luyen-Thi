﻿using Luyenthi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Core.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public dynamic Content { get; set; }
        public dynamic Introduction { get; set; }
        public dynamic Solve { get; set; }
        public int OrderNumber { get; set; }
        public string CorrectAnswer { get; set; }
        public QuestionType Type { get; set; }
        public QuestionStatus Status { get; set; }
        public List<QuestionDto> SubQuestions { get; set; }
    }
}
