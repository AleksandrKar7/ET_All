using ET_5_NumberToText.Logics.Translator;

namespace ET_5_NumberToText.Logics
{
    class Number
    {
        public NumberToTextConverter Converter { private get; set; }

        public long Value { get; set; }

        public Number(long value, NumberToTextConverter converter)
        {
            Value = value;
            Converter = converter;
        }

        public bool CanConvertToText()
        {
            return Converter.CanConvertNumber(Value);
        }
        public string ConvertToText()
        {
            return Converter.ConvertNumber(Value);
        }
    }
}
