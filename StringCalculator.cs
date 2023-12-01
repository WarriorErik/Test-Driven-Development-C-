namespace strinCalcTDD
{
    public class StringCalculator
    {

        public int Add(string numbers) //returns the sum 
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };//enables multiple delimiters

            if (numbers.StartsWith("//"))
            {
                int delimiterEndIndex = numbers.IndexOf('\n');//hanldes new lines 
                string delimiterSection = numbers.Substring(2, delimiterEndIndex - 2);
                int currentIndex = 0;

                while (currentIndex < delimiterSection.Length)//allows delimters to be of any length
                {
                    if (delimiterSection[currentIndex] == '[')
                    {
                        int endIndex = delimiterSection.IndexOf(']', currentIndex);
                        string delimiter = delimiterSection.Substring(currentIndex + 1, endIndex - currentIndex - 1);
                        delimiters.Add(delimiter);
                        currentIndex = endIndex + 1;
                    }
                    else
                    {
                        delimiters.Add(delimiterSection[currentIndex].ToString());
                        currentIndex++;
                    }
                }

                numbers = numbers.Substring(delimiterEndIndex + 1);
            }

            string[] numStrs = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            int[] nums = Array.ConvertAll(numStrs, int.Parse);

            List<int> negativeNumbers = nums.Where(n => n < 0).ToList();

            if (negativeNumbers.Count > 0)//Exception for negative numbers
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return nums.Where(n => n <= 1000).Sum();//ignoring these numbers
        }

    }
}