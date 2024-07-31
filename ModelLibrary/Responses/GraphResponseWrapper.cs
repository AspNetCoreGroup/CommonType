﻿using System;
namespace ModelLibrary.Responses
{
    public class GraphResponseWrapper
    {
        public bool RequestCompleted { get; set; }

        public double CompletionPercentage { get; set; }

        public string? GraphJSON { get; set; }
    }
}