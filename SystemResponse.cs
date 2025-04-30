using System;
using System.Collections.Generic;



namespace Part1
{
    public class SystemResponse
    {
        //filtered words array list
        //key words in dictionary array list
        private List<string> filteredWords;
        private List<KeyValue> keyWordsInArray = new List<KeyValue>();

        public void Key()
        {
            // Add key-value pairs as objects containing both key and value

            //Password response
            keyWordsInArray.Add(new KeyValue("password safety",
                "Password Safety: Password safety is the practice of securing a password from unauthorized access. \n" +
                "1. You can create a strong password by using a combination of letters, numbers and special characters, and by avoiding common words and phrases. \n" +
                "2. You can protect your password by keeping it secure and not sharing it with anyone. \n" +
                "3. If your password is compromised, change it immediately and report it to the relevant authorities."));

            //phishing response
            keyWordsInArray.Add(new KeyValue("phishing",
                "Phishing: Phishing is the fraudulent attempt to obtain sensitive information such as usernames, passwords and credit card details. \n" +
                "1. You can identify phishing by looking out for suspicious emails, websites and requests for sensitive information. \n" +
                "2. You can protect yourself from phishing by being cautious of suspicious emails and websites, and by not sharing sensitive information online. \n" +
                "3. If you receive a phishing email, do not click on any links or download attachments. Report it to your email provider and delete it immediately."));

            //password safety response
            keyWordsInArray.Add(new KeyValue("safety browsing",
                "Safety browsing: Safety browsing is the practice of ensuring a safe and secure online browsing experience."+
                "1. You can stay safe online by using secure passwords, keeping your software up to date, and being cautious of suspicious emails and websites. \n" +
                "2. You can protect your personal information online by being cautious of what you share online, and by using privacy settings on social media platforms. \n" +
                "3. If you encounter a suspicious website, do not enter any personal information. Report it to the relevant authorities and leave the website immediately. \n"
                ));
        }

        public void filered_words()
        {
            // Add filtered words to ArrayList
            filteredWords = new List<string>
            {
                "tell", "me", "please", "can", "you", "could", "would",
                "how", "what", "when", "where", "why", "who", "which",
                "give", "show", "explain", "describe", "provide", "list",
                "the", "a", "an", "is", "are", "do", "does", "should",
                "will", "might", "may", "must", "have", "has", "had",
                "need", "want", "like", "thanks", "thank", "hello", "hi", "hey"
            };
        }

        public string process_Question(string user_Question)
        {
            //this will be used for the key word that is not filtered.
            List<string> importantWords = new List<string>();

            string[] questions_asked_by_user = user_Question.Split(' ');

            foreach (string word in questions_asked_by_user)
            {
                //trims the words by checkin if its in the filtered list, if not keep the word (acts as a loop)
                string trimmed_word = word.Trim();

                // new boolean variable to test a condition
                bool isFiltered = false;

                //remember: filteredWords comes from the ArrayList which stores filtered words
                //if every word (including the trimmed word) is included inside keywords then its properly filtered "isFiltered=true"
                foreach (string filteredWord in filteredWords)
                {
                    if (string.Equals(trimmed_word, filteredWord, StringComparison.OrdinalIgnoreCase))
                    {
                        isFiltered = true; 
                        break;
                    }
                }

                // If there remains words not filtered, keep it example: "Can", "you", "explain", "Phishing?" → keeps "Phishing" then 
                //add them as important words or an important word (the trimmed word) 
                if (!isFiltered)
                {
                    importantWords.Add(trimmed_word);
                }
            }

            //rebuild the key word into a cleaned version or rather the one existing in the array as it is. in this case giving it a lower case
            string cleaned_words_in_question = string.Join(" ", importantWords).ToLower();

            List<string> the_response = new List<string>();

            // Check against our keywords database
            foreach (KeyValue keyvalue in keyWordsInArray)
            {
               
                //using get to access the Key (lower case keyword)
                if (cleaned_words_in_question.Contains(keyvalue.Key.ToLower()))
                {
                    //Prevent duplicate responses if same keyword appears multiple times
                    if (!the_response.Contains(keyvalue.Value))
                    {
                        //access Value
                        the_response.Add(keyvalue.Value);
                    }

                }

            }
            /* Return formatted responses:
            - If matches found: returns all answers separated by blank lines
            - If no matches: returns error message */
            if (the_response.Count > 0)
            {
                return string.Join("\n\n", the_response);
            }
            else
            {
                return "Ask something relevant to the topics mentioned above";
            }
        }

        public class KeyValue
        {
            // Property to store the keyword (e.g., "Password")
            public string Key { get; set; }

            // Property to store the full answer 
            public string Value { get; set; }

            public KeyValue(string key, string value)
            {
                //read the key for example "password"
                Key = key;      
                // read and give the response "password defintion"
                Value = value;  
            }

            //1. you must add random responses
            //2. memory recall for the purpose of using it in the conversation. 
            //perhaps create another arraylist to store words like "interested" to be recoginzed as words of interest
            //3. Sentinment detection
            // again you will probably use the array list to detect the sentiment

            //done.
        }
    }
}






