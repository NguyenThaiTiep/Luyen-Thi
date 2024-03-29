﻿using Luyenthi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Core
{
    public class QuestionInfo
    {
        public QuestionLevel Level { get; set; }
        public QuestionGdocDto question { get; set; }
    }
    public class QuestionGdocDto
    {
        public dynamic Introduction { get; set; }
        public List<OptionQuestionDto> Content { get; set; }
        public dynamic Solve { get; set; }
        public int OrderNumber { get; set; }
        public string CorrectAnswer { get; set; }
        public List<QuestionGdocDto> SubQuestions { get; set; }
        public QuestionType Type { get; set; }

    }
}
