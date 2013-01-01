using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Responses.Negotiation;
using NancyDemo.Csharp.Responses;

namespace NancyDemo.Csharp.Processors
{
    public class PdfProcessor : IResponseProcessor
    {
        private static readonly IEnumerable<Tuple<string, MediaRange>> extensionMappings =
            new[] { new Tuple<string, MediaRange>("pdf", MediaRange.FromString("application/pdf")) };

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            if (IsExactPdfContentType(requestedMediaRange))
            {
                return new ProcessorMatch
                    {
                        ModelResult = MatchResult.DontCare,
                        RequestedContentTypeResult = MatchResult.ExactMatch
                    };
            }

            return new ProcessorMatch
            {
                ModelResult = MatchResult.DontCare,
                RequestedContentTypeResult = MatchResult.NoMatch
            };
        }

        private static bool IsExactPdfContentType(MediaRange requestedContentType)
        {
            if (requestedContentType.Type.IsWildcard && requestedContentType.Subtype.IsWildcard)
            {
                return true;
            }

            return requestedContentType.Matches("application/pdf");
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new PdfResponse(model);
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { return extensionMappings; }
        }
    }
}