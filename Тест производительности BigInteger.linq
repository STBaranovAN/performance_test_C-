<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	string accountVal="ALFA30122000010020000933BY66";
	
	string convertVal = "";
	
            foreach (char c in accountVal)
            {
                int codeASCII = c;
                if (codeASCII >= 65 && codeASCII <= 90)
                    convertVal += c-55;
                else
                    convertVal += c;
            }

	var stopWatch = new Stopwatch();
	        stopWatch.Start();
	
	for (int i = 0; i <= 10000; i++)
	{
		GetBigNumberModOld(convertVal);
	}
	// Get the elapsed time as a TimeSpan value.
	TimeSpan ts = stopWatch.Elapsed;
	
	stopWatch.Stop();
	
	// Format and display the TimeSpan value.
	string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
		ts.Hours, ts.Minutes, ts.Seconds,
	    ts.Milliseconds / 10);
	    Console.WriteLine("RunTime " + elapsedTime);
		
	stopWatch.Restart();
	
	for (int i = 0; i <= 10000; i++)
	{	
		GetBigNumberMod(convertVal);
	}
	
	// Get the elapsed time as a TimeSpan value.
	ts = stopWatch.Elapsed;
	
	stopWatch.Stop();
	
	// Format and display the TimeSpan value.
	elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
		ts.Hours, ts.Minutes, ts.Seconds,
	    ts.Milliseconds / 10);
	    Console.WriteLine("RunTime " + elapsedTime);
}

// Define other methods and classes here

public int GetBigNumberModOld(string bigNumber)
{
	BigInteger accNumber2 = BigInteger.Parse(bigNumber);
	var NS = new BigInteger(97);
	
	var res2 = BigInteger.Remainder(accNumber2, NS);  //можно заменить три нижние строки одной  
	//BigInteger div2 = BigInteger.Divide(accNumber2, NS);       //
	//BigInteger mul2 = BigInteger.Multiply(div2, NS);
	//BigInteger res2 = BigInteger.Subtract(accNumber2, mul2);
	return (int)res2;
}

public int GetBigNumberMod(string bigNumber)
{
	var rest = 0;
	for (var p = 0; p < bigNumber.Length; p++)
	{
		var digit = (int)Char.GetNumericValue(bigNumber[p]);
		var value = rest * 10 + digit;
		rest = value % 97;
	}
	return rest;
}
