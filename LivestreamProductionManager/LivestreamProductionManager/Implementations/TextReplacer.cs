using LivestreamProductionManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivestreamProductionManager.Implementations
{
    public class TextReplacer : ITextReplacer
    {
        public string ReplaceIdAndValue(string template, string id, string value)
        {
            if (string.IsNullOrEmpty(template))
            {
                throw new ArgumentException(nameof(template));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }
            if (value == null)
            {
                throw new ArgumentException(nameof(value));
            }

            try
            {
                return template.Replace("IDPLACEHOLDER", id).Replace("VALUEPLACEHOLDER", value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string ReplaceIdAndValueForPlayerName(string template, string id, string playerSponsor, string playerName)
        {
            if (string.IsNullOrEmpty(template))
            {
                throw new ArgumentException(nameof(template));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            try
            {
                string playerFullName;
                if (string.IsNullOrEmpty(playerName))
                {
                    playerName = "???";
                }

                if (string.IsNullOrEmpty(playerSponsor))
                {
                    playerFullName = playerName;
                }
                else
                {
                    playerFullName = $"{playerSponsor} | {playerName}";
                }

                return template.Replace("IDPLACEHOLDER", id).Replace("VALUEPLACEHOLDER", playerFullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string ReplaceIdAndValueForPlayerNames(string template, string idTemplate, List<string> playerSponsors, List<string> playerNames)
        {
            if (string.IsNullOrEmpty(template))
            {
                throw new ArgumentException(nameof(template));
            }
            if (string.IsNullOrEmpty(idTemplate))
            {
                throw new ArgumentException(nameof(idTemplate));
            }

            try
            {
                var cssStringBuilder = new StringBuilder();
                for (int i = 0; i < playerNames.Count; i++)
                {
                    cssStringBuilder.AppendLine(ReplaceIdAndValueForPlayerName(template, idTemplate.Replace("*", $"{i + 1}"), playerSponsors[i], playerNames[i]));
                }

                return cssStringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string ReplaceIdAndValueForTeam(string template, string idTemplate, List<string> values)
        {
            if (string.IsNullOrEmpty(template))
            {
                throw new ArgumentException(nameof(template));
            }
            if (string.IsNullOrEmpty(idTemplate))
            {
                throw new ArgumentException(nameof(idTemplate));
            }
            if (values == null)
            {
                throw new ArgumentException(nameof(values));
            }

            try
            {
                var cssStringBuilder = new StringBuilder();
                for (int i = 0; i < values.Count; i++)
                {
                    cssStringBuilder.AppendLine(ReplaceIdAndValue(template, idTemplate.Replace("*", $"{i+1}"), values[i]));
                }

                return cssStringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
