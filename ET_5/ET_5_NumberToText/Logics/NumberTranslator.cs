using ET_5_NumberToText.Logics.Translators;

namespace ET_5_NumberToText.Logics
{
    class NumberTranslator
    {
        public NumberToTextConverter Converter { private get; set; }

        public NumberTranslator(NumberToTextConverter converter)
        {
            Converter = converter;
        }

        public bool CanConvertToText(long number)
        {
            return Converter.CanConvertNumber(number);
        }
        public string ConvertToText(long number)
        {
            return Converter.ConvertNumber(number);
        }
    }
}
