﻿using Luyenthi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Core.Dtos
{
    public class DocumentCreateDto
    {
        public string Name { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GradeId { get; set; }
        public Guid? ParentId { get; set; }
        public string Description { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
