﻿using Luyenthi.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Domain
{
    public class LevelQuestion:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int OrderNumber { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<TemplateQuestionGenerate> QuestionGenerates { get; set; }
    }
}
