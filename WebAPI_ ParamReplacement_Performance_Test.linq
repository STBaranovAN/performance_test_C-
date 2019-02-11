<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	var stopWatch = new Stopwatch();
	TimeSpan ts = new TimeSpan();
	string elapsedTime = string.Empty;
	
	string paramValue = "UsrID=50356~Surname=Сом~Name=Витольд~Secondname=Иванович~MPhone=+375111111111~EMail=svi@sttest.by~IsAdmin=true~UsrID=60442~Surname=Одессов~Name=Дмитрий~Secondname=Иванович~MPhone=+375333333333~EMail=tavrida2@st.by~IsAdmin=false~";
	
	stopWatch.Start();
	CompareLogicFirst(paramValue);
	stopWatch.Stop();
	
	// Get the elapsed time as a TimeSpan value.
	ts = stopWatch.Elapsed;
	// Format and display the TimeSpan value.
	elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
		ts.Hours, ts.Minutes, ts.Seconds,
	    ts.Milliseconds / 10);
	    Console.WriteLine("\nRunTime 1 = " + elapsedTime);
		
	stopWatch.Restart();
	Console.WriteLine(Environment.NewLine);
	CompareLogicSecond(paramValue);	
	stopWatch.Stop();
	
	// Get the elapsed time as a TimeSpan value.
	ts = stopWatch.Elapsed;
	// Format and display the TimeSpan value.
	elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
		ts.Hours, ts.Minutes, ts.Seconds,
	    ts.Milliseconds / 10);
	    Console.WriteLine("\nRunTime 2 = " + elapsedTime);
}

void CompareLogicFirst(string paramValue)
{	
	string result = string.Empty;
	for (int i = 0; i <= 100000; i++)
	{
		string resultTable = string.Empty;
		string[] str_arr = paramValue.Substring(0, paramValue.Length - 1).Split('~');

        foreach (string item in str_arr)
        {
            resultTable += item + "~";
            if (item.StartsWith("MPhone"))
            {
                resultTable += "SignerType=~";
            }
        }
		
		if(i==0)
		{
			result = resultTable;
		}
	}
	Console.WriteLine(result);
}

void CompareLogicSecond(string paramValue)
{
	string result = string.Empty;
	for (int i = 0; i <= 100000; i++)
	{
		string resultTable = string.Empty;
		string httpPattern = "(~MPhone=)(?:[^~]+)",
               processedText = string.Empty,
               nextText = string.Empty;
			   
                var pattern = new Regex(httpPattern, RegexOptions.IgnoreCase);
                MatchCollection match = pattern.Matches(paramValue);

                if (match.Count == 0)
                    return;
					
				nextText = paramValue;

                for (int j = 0; j < match.Count; j++)
                {
                    string occurence = match[j].Value;
                    int matchPos = nextText.IndexOf(match[j].Value, StringComparison.InvariantCulture);
                    processedText = nextText.Substring(0, matchPos + match[j].Value.Length);
                    nextText = nextText.Substring(matchPos + match[j].Value.Length);
                    resultTable += ReplaceFirst(processedText, match[j].Value, string.Concat(occurence, "~SignerType="));
                }
				
				resultTable += nextText;
					
				if(i==0)
		{
			result = resultTable;
		}
	}
	Console.WriteLine(result);
}

 /// <summary>
        /// Вспомогательная функция
        /// </summary>
        public static string ReplaceFirst(string text, string search, string replace)
        {
            string result = string.Empty;
            int pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
            {
                return text;
            }
            result = string.Concat(text.Substring(0, pos), replace, text.Substring(pos + search.Length));

            return
                result;
        }