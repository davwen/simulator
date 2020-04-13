using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using UnityEngine;

public class Languages
{
    public enum languages { Afrikaans, Albanian, Amharic, Arabic, Armenian, Assamese, Azerbaijani, Basque, Bengali, Breton, Bulgarian, Burmese, Byelorussian, Cambodian, Catalan, Chinese, Croatian, Czech, Danish, Dutch, English, Estonian, Faroese, Finnish, French, Frisian, Gaelic, Galician, Georgian, German, Greek, Greenlandic, Gujarati, Hausa, Hindi, Hungarian, Icelandic, Irish, Italian, Japanese, Kannada, Kazakh, Kinyarwanda, Kirghiz, Korean, Laothian, Lettish, Lithuanian, Macedonian, Malay, Malayalam, Maltese, Marathi, Mongolian, Nepali, Norwegian, Oriya, Afan, Pushto, Persian, Polish, Portuguese, Punjabi, Romance, Romanian, Russian, Serbian, Sesotho, Setswana, Singhalese, Slovak, Slovenian, Somali, Spanish, Swahili, Swedish, Tajik, Tamil, Tegulu, Thai, Tibetan, Tsonga, Turkish, Turkmen, Ukrainian, Urdu, Uzbek, Vietnamese, Welsh, Yoruba, Zulu };

    public string getISO(languages cultureEnum)
    {
        string output = "";

        switch (cultureEnum)
        {
            case languages.Afrikaans: output = "AF"; break;
            case languages.Albanian: output = "SQ"; break;
            case languages.Amharic: output = "AM"; break;
            case languages.Arabic: output = "AR"; break;
            case languages.Armenian: output = "HY"; break;
            case languages.Assamese: output = "AS"; break;
            case languages.Azerbaijani: output = "AZ"; break;
            case languages.Basque: output = "EU"; break;
            case languages.Bengali: output = "BN"; break;
            case languages.Breton: output = "BR"; break;
            case languages.Bulgarian: output = "BG"; break;
            case languages.Burmese: output = "MY"; break;
            case languages.Byelorussian: output = "BE"; break;
            case languages.Cambodian: output = "KM"; break;
            case languages.Catalan: output = "CA"; break;
            case languages.Chinese: output = "ZH"; break;
            case languages.Croatian: output = "HR"; break;
            case languages.Czech: output = "CS"; break;
            case languages.Danish: output = "DA"; break;
            case languages.Dutch: output = "NL"; break;
            case languages.English: output = "EN"; break;
            case languages.Estonian: output = "ET"; break;
            case languages.Faroese: output = "FO"; break;
            case languages.Finnish: output = "FI"; break;
            case languages.French: output = "FR"; break;
            case languages.Frisian: output = "FY"; break;
            case languages.Gaelic: output = "GD"; break;
            case languages.Galician: output = "GL"; break;
            case languages.Georgian: output = "KA"; break;
            case languages.German: output = "DE"; break;
            case languages.Greek: output = "EL"; break;
            case languages.Greenlandic: output = "KL"; break;
            case languages.Gujarati: output = "GU"; break;
            case languages.Hausa: output = "HA"; break;
            case languages.Hindi: output = "HI"; break;
            case languages.Hungarian: output = "HU"; break;
            case languages.Icelandic: output = "IS"; break;
            case languages.Irish: output = "GA"; break;
            case languages.Italian: output = "IT"; break;
            case languages.Japanese: output = "JA"; break;
            case languages.Kannada: output = "KN"; break;
            case languages.Kazakh: output = "KK"; break;
            case languages.Kinyarwanda: output = "RW"; break;
            case languages.Kirghiz: output = "KY"; break;
            case languages.Korean: output = "KO"; break;
            case languages.Laothian: output = "LO"; break;
            case languages.Lettish: output = "LV"; break;
            case languages.Lithuanian: output = "LT"; break;
            case languages.Macedonian: output = "MK"; break;
            case languages.Malay: output = "MS"; break;
            case languages.Malayalam: output = "ML"; break;
            case languages.Maltese: output = "MT"; break;
            case languages.Marathi: output = "MR"; break;
            case languages.Mongolian: output = "MN"; break;
            case languages.Nepali: output = "NE"; break;
            case languages.Norwegian: output = "NO"; break;;
            case languages.Oriya: output = "OR"; break;
            case languages.Afan: output = "OM"; break;
            case languages.Pushto: output = "PS"; break;
            case languages.Persian: output = "FA"; break;
            case languages.Polish: output = "PL"; break;
            case languages.Portuguese: output = "PT"; break;
            case languages.Punjabi: output = "PA"; break;
            case languages.Romance: output = "RM"; break;
            case languages.Romanian: output = "RO"; break;
            case languages.Russian: output = "RU"; break;
            case languages.Serbian: output = "SR"; break;
            case languages.Sesotho: output = "ST"; break;
            case languages.Setswana: output = "TN"; break;
            case languages.Singhalese: output = "SI"; break;
            case languages.Slovak: output = "SK"; break;
            case languages.Slovenian: output = "SL"; break;
            case languages.Somali: output = "SO"; break;
            case languages.Spanish: output = "ES"; break;
            case languages.Swahili: output = "SW"; break;
            case languages.Swedish: output = "SV"; break;
            case languages.Tajik: output = "TG"; break;
            case languages.Tamil: output = "TA"; break;
            case languages.Tegulu: output = "TE"; break;
            case languages.Thai: output = "TH"; break;
            case languages.Tibetan: output = "BO"; break;
            case languages.Tsonga: output = "TS"; break;
            case languages.Turkish: output = "TR"; break;
            case languages.Turkmen: output = "TK"; break;
            case languages.Ukrainian: output = "UK"; break;
            case languages.Urdu: output = "UR"; break;
            case languages.Uzbek: output = "UZ"; break;
            case languages.Vietnamese: output = "VI"; break;
            case languages.Welsh: output = "CY"; break;
            case languages.Yoruba: output = "YO"; break;
            case languages.Zulu: output = "ZU"; break;

        }

        return output.ToLower();
    }

    public CultureInfo getInfo(languages cultureEnum)
    {
        return CultureInfo.GetCultureInfo(new Languages().getISO(cultureEnum));
    }
}

public class Localization : MonoBehaviour
{
    public bool useCustomLanguage;

    public Languages.languages Language;

    private void Awake()
    {
        
        if (useCustomLanguage)
        {
            Thread.CurrentThread.CurrentCulture = new Languages().getInfo(Language);
        }

    }
}