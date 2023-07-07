using aspnetapp.Codes;

namespace aspnetapp.LocalTest
{
    public static class TranscodingTest
    {
        public static void EncodeTest()
        {
            var content = "哈喽！世界";
            var result = string.Empty;
            var err = string.Empty;


            (result, err) = content.EncodeBase64Plus();
            (result, err) = result.DecodeBase64Plus();

        }
    }
}
