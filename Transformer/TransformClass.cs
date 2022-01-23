namespace Transformer
{
    public class TransformClass
    {
        public static string TransformToJson(string message, int indexJsonWord)
        {
            string[] systemInfo = message.Split('|')[0].Split(' ');
            string[] clientInfo = message.Split('|')[1].Split(' ');

            string answer = string.Empty;
            for (int i = 0; i != indexJsonWord; ++i)
            {
                answer += systemInfo[i] + " ";
            }

            answer += "{\"";
            for (int i = indexJsonWord; i < systemInfo.Length - 1; ++i)
            {
                answer += systemInfo[i].Replace("=", "\":\"") + "\",\"";
            }
            answer += systemInfo[systemInfo.Length - 1].Replace("=", "\":\"") + "\"}";

            if (clientInfo.Length > 1)
            {
                answer += " {\"";

                for (int i = 0; i < clientInfo.Length - 1; ++i)
                {
                    answer += clientInfo[i].Replace("=", "\":\"") + "\",\"";
                }

                answer += clientInfo[clientInfo.Length - 1].Replace("=", "\":\"") + "\"}";
            }
            return answer;
        }
    }
}
