﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Core.Dtos
{
    public class UnitDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<TemplateQuestionDto> TemplateQuestions { get; set; }
    }
}
