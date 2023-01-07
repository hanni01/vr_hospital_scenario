using GoogleSheetsToUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Localization manager.
	/// </summary>
    public static class LocalizationManager
    {
		/// <summary>
		/// Fired when localization changed.
		/// </summary>
        public static event Action LocalizationChanged = () => { };

        private static List<string> isRead = new List<string>();
        private static readonly Dictionary<string, Dictionary<string, string>> Dictionary = new Dictionary<string, Dictionary<string, string>>();
        private static string _language = "English";

        private static Action m_Callback;
        private static string m_LocalizeSheet;
        private static string[] m_SheetNames;
        private static int m_ReadCount = 0;

        /// <summary>
        /// Get or set language.
        /// </summary>
        public static string Language
        {
            get { return _language; }
            set { _language = value; LocalizationChanged(); }
        }

		/// <summary>
		/// Set default language.
		/// </summary>
        public static void AutoLanguage()
        {
            //var lang = NBUtil.GetSharedData().GetPlayerPrefabString("language");
            //정해진 언어가 없을 경우, 시스템 언어를 따릅니다.
            //if (string.IsNullOrEmpty(lang))
            //{
            //    switch (Application.systemLanguage)
            //    {
            //        case SystemLanguage.Korean:
            //            lang = "Korean";
            //            break;
            //        default:
            //            lang = "English";
            //            break;
            //    }
            //}
            //NBUtil.SetLanguage(lang);
            //NBUtil.SetLanguage("Korean");
        }

		/// <summary>
		/// Read localization spreadsheets.
		/// </summary>
		public static void Read(string path = "Localization")
        {
            //계속 새로 읽게 수정.
            //if (isRead.Contains(path)) return;
            //isRead.Add(path);
            //if (Dictionary.Count > 0) return;

            var textAssets = Resources.LoadAll<TextAsset>(path);

            foreach (var textAsset in textAssets)
            {
                var text = ReplaceMarkers(textAsset.text);
                var matches = Regex.Matches(text, "\"[\\s\\S]+?\"");

                foreach (Match match in matches)
                {
					text = text.Replace(match.Value, match.Value.Replace("\"", null).Replace(",", "[comma]").Replace("\n", "[newline]"));
                }

                var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
				var languages = lines[0].Split(',').Select(i => i.Trim()).ToList();

				for (var i = 1; i < languages.Count; i++)
                {
                    if (!Dictionary.ContainsKey(languages[i]))
                    {
                        Dictionary.Add(languages[i], new Dictionary<string, string>());
                    }
                }
				
                for (var i = 1; i < lines.Length; i++)
                {
					var columns = lines[i].Split(',').Select(j => j.Trim()).Select(j => j.Replace("[comma]", ",").Replace("[newline]", "\n")).ToList();
					var key = columns[0];

                    for (var j = 1; j < languages.Count; j++)
                    {
                        //NBDebug.Log(key + " : " + columns[j]);
                        //if (Dictionary[languages[j]][key] != null) continue;
                        Dictionary[languages[j]].Add(key, columns[j]);
                    }
                }
            }

            AutoLanguage();
        }

        private static string ChangeText(this string text)
        {
            return text.Replace("[comma]", ",").Replace("[newline]", "\n").Trim();
        }

        private static void ReadLocalizeSheet(int idx)
        {
            if(idx < m_SheetNames.Length)
            {
                //NBDebug.Log("ReadLocalizeSheet : " + m_SheetNames[idx]);
                //if (isRead.Contains(m_SheetNames[idx]))
                //{
                //    ReadLocalizeSheet(++m_ReadCount);
                //    return;
                //}
                //
                //isRead.Add(m_SheetNames[idx]);
                SpreadsheetManager.ReadPublicSpreadsheet(new GSTU_Search(m_LocalizeSheet, m_SheetNames[idx]), ReadGoogleSheet);

            }
            else
            {
                AutoLanguage();
                m_Callback?.Invoke();
            }
        }

        public static void LocalizationSetting(string url, string[] sheets, Action callback, bool reset = true)
        {
            //if (!string.IsNullOrEmpty(m_LocalizeSheet))
            //    callback?.Invoke();
            //else
            {
                if (reset && Dictionary != null)
                {
                    Dictionary.Clear();
                }

                m_LocalizeSheet = url;
                m_SheetNames = sheets;
                m_Callback = callback;

                m_ReadCount = 0;
                ReadLocalizeSheet(m_ReadCount);
            }
        }


        private static void ReadGoogleSheet(GstuSpreadSheet sheet)
        {
            string STRING_KEYS = "Key";
            var languages = new List<string>();
            for (var i = 1; i < sheet.rows[STRING_KEYS].Count; i++)
            {
                if (!Dictionary.ContainsKey(sheet.rows[STRING_KEYS][i].value))
                {
                    Dictionary.Add(sheet.rows[STRING_KEYS][i].value, new Dictionary<string, string>());
                }
                languages.Add(sheet.rows[STRING_KEYS][i].value);
            }

            //NBDebug.Log(sheet.Cells.Count);
            //NBDebug.Log(sheet.columns[STRING_KEYS].Count);
            for (int i = 1; i < sheet.columns[STRING_KEYS].Count; i++)
            {
                var key = sheet.columns[STRING_KEYS][i].value;

                //NBDebug.Log(key);
                for (var j = 0; j < languages.Count; j++)
                {
                    if (sheet[key, languages[j]] == null)
                        Dictionary[languages[j]].Add(key, string.Empty);
                    else
                    {
                        if (Dictionary[languages[j]].ContainsKey(key))
                            Dictionary[languages[j]][key] = sheet[key, languages[j]].value.ChangeText();
                        else
                            Dictionary[languages[j]].Add(key, sheet[key, languages[j]].value.ChangeText());
                    }
                }
            }

            ReadLocalizeSheet(++m_ReadCount);
        }

		/// <summary>
		/// Get localized value by localization key.
		/// </summary>
        public static string Localize(string localizationKey)
        {
            if (!Dictionary.ContainsKey(Language)) return localizationKey;
            if (!Dictionary[Language].ContainsKey(localizationKey)) return localizationKey;
            //if (!Dictionary.ContainsKey(Language)) throw new KeyNotFoundException("Language not found: " + Language);
            //if (!Dictionary[Language].ContainsKey(localizationKey)) throw new KeyNotFoundException("Translation not found: " + localizationKey);

            return Dictionary[Language][localizationKey];
        }

        /// <summary>
        /// Get localized value by localization key.
        /// </summary>
        public static string Localize(string localizationKey, string language)
        {
            if (!Dictionary.ContainsKey(language)) return localizationKey;
            if (!Dictionary[language].ContainsKey(localizationKey)) return localizationKey;
            //if (!Dictionary.ContainsKey(Language)) throw new KeyNotFoundException("Language not found: " + Language);
            //if (!Dictionary[Language].ContainsKey(localizationKey)) throw new KeyNotFoundException("Translation not found: " + localizationKey);

            return Dictionary[language][localizationKey];
        }

        /// <summary>
        /// Get localized value by localization key.
        /// </summary>
        public static string Localize(string localizationKey, params object[] args)
        {
            var pattern = Localize(localizationKey);

            return string.Format(pattern, args);
        }

        private static string ReplaceMarkers(string text)
        {
            return text.Replace("[Newline]", "\n");
        }
    }
}
 