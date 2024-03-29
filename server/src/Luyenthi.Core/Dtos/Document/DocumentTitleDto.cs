﻿using Luyenthi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Core.Dtos
{
    public class DocumentTitleDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int NumberDo { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
