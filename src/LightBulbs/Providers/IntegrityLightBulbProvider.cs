﻿using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using Microsoft.WebTools.Languages.Html.Editor.SuggestedActions;
using Microsoft.WebTools.Languages.Html.Tree.Nodes;
using Microsoft.WebTools.Languages.Html.Tree.Utility;
using Microsoft.WebTools.Languages.Shared.ContentTypes;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace HtmlTools
{
    [Export(typeof(IHtmlSuggestedActionProvider))]
    [ContentType(HtmlContentTypeDefinition.HtmlContentType)]
    [Name("Calculate Integrity Light Bulb Provider")]
    internal class IntegrityLightBulbProvider : IHtmlSuggestedActionProvider
    {
        public IEnumerable<ISuggestedAction> GetSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            return new ISuggestedAction[] {
                new IntegrityLightBulbAction(textView, textBuffer, element)
            };
        }

        public bool HasSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            if (!element.StartTag.Contains(caretPosition))
            {
                return false;
            }

            string url = (element.GetAttribute("src") ?? element.GetAttribute("href") ?? element.GetAttribute("abp-src") ?? element.GetAttribute("abp-href"))?.Value;

            if (string.IsNullOrEmpty(url) || (!url.Contains("://") && !url.StartsWith("//")))
            {
                return false;
            }

            return element.IsElement("style") || element.IsElement("script");
        }
    }
}
