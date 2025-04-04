using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;


namespace Part1
{
    public class SystemResponse
    {
        //filtered words array list
        //key words in dictionary array list
        private System.Collections.ArrayList filteredWords;
        private System.Collections.ArrayList keyWordsInArray = new System.Collections.ArrayList();

        public void Key()
        {
            // Add key-value pairs as objects containing both key and value

            //Password response
            keyWordsInArray.Add(new KeyValue("password safety",
                "Definition: Password safety is the practice of securing a password from unauthorized access. \n" +
                "1. You can create a strong password by using a combination of letters, numbers and special characters, and by avoiding common words and phrases. \n" +
                "2. You can protect your password by keeping it secure and not sharing it with anyone. \n" +
                "3. If your password is compromised, change it immediately and report it to the relevant authorities."));

            //phishing response
            keyWordsInArray.Add(new KeyValue("phishing",
                "Definition: Phishing is the fraudulent attempt to obtain sensitive information such as usernames, passwords and credit card details. \n" +
                "1. You can identify phishing by looking out for suspicious emails, websites and requests for sensitive information. \n" +
                "2. You can protect yourself from phishing by being cautious of suspicious emails and websites, and by not sharing sensitive information online. \n" +
                "3. If you receive a phishing email, do not click on any links or download attachments. Report it to your email provider and delete it immediately."));

            //password safety response
            keyWordsInArray.Add(new KeyValue("safety browsing",
                "Definiton: Safety browsing is the practice of ensuring a safe and secure online browsing experience."+
                "1. You can stay safe online by using secure passwords, keeping your software up to date, and being cautious of suspicious emails and websites. \n" +
                "2. You can protect your personal information online by being cautious of what you share online, and by using privacy settings on social media platforms. \n" +
                "3. If you encounter a suspicious website, do not enter any personal information. Report it to the relevant authorities and leave the website immediately. \n" +
                "Definiton: Safety browsing is the practice of ensuring a safe and secure online browsing experience."));
        }

        public void filered_words()
        {
            // Add filtered words to ArrayList
            filteredWords = new System.Collections.ArrayList()
            {
                "tell", "me", "please", "can", "you", "could", "would",
                "how", "what", "when", "where", "why", "who", "which",
                "give", "show", "explain", "describe", "provide", "list",
                "the", "a", "an", "is", "are", "do", "does", "should", "is",
                "will", "might", "may", "must", "have", "has", "had",
                "need", "want", "like", "thanks", "thank", "hello", "hi", "hey"
            };
        }
        //Questions: new Key Value, trim function, 

        public string process_Question(string user_Question)
        {
            List<string> importantWords = new List<string>();

            //1. Split the question into separate words
            //Example: "Can you explain Phishing?" → ["Can", "you", "explain", "Phishing?"]
            string[] questions_asked_by_user = user_Question.Split(' ');

            //2. Clean each word (removes spaces and punctuation) "Phishing?" becomes "Phishing"
            foreach (string word in questions_asked_by_user)
            {
                //trim meaning ignoring any punctuations and whitespaces
                string trimmed_word = word.Trim();

                //3. Check if the word should be ignored
                //example: if "can" is in filtered words 
                bool isFiltered = false;

                foreach (string filteredWord in filteredWords)
                {
                    if (string.Equals(trimmed_word, filteredWord, StringComparison.OrdinalIgnoreCase))
                    {
                        isFiltered = true; //if filtered word matches then mark it as ignored.
                        break;
                    }
                }
                //4. If word is not filtered, keep it
                //example: "Can", "you", "explain", "Phishing?" → keeps "Phishing"
                if (!isFiltered)
                {
                    importantWords.Add(trimmed_word);
                }
            }

            //5. Rebuild cleaned question from important words
            //This joins the filtered words back into a string so we can check for multi-word keywords
            //Example: ["explain", "password", "safety"] → "explain password safety"
            string cleanedQuestion = string.Join(" ", importantWords).ToLower();
            List<string> collects_all_responses = new List<string>();

            //6. Check against our keywords database
            foreach (KeyValue keyvalue in keyWordsInArray)
            {
                // Check if cleaned question contains the full keyword
                // This enables matching multi-word keywords like "password safety"
                if (cleanedQuestion.Contains(keyvalue.Key.ToLower()))
                {
                    //Prevent duplicate responses if same keyword appears multiple times
                    if (!collects_all_responses.Contains(keyvalue.Value))
                    {
                        collects_all_responses.Add(keyvalue.Value);
                    }
                }
            }

            /* Return formatted responses:
            - If matches found: returns all answers separated by blank lines
            - If no matches: returns error message */
            if (collects_all_responses.Count > 0)
            {
                return string.Join("\n\n", collects_all_responses);
            }
            else
            {
                return "Ask something relevant to the topics mentioned above";
            }
        }

        // ArrayList is just a list of objects—it doesn’t have built-in key-value pairing like Dictionary.
        //To store and retrieve answers based on keywords, we need a way to link a keyword(e.g., "Phishing") to its answer
        //The KeyValue class provides this structure, allowing us to mimic a dictionary.
        public class KeyValue
        {
            // Property to store the keyword (e.g., "Password")
            //will be set in the constructor
            public string Key { get; }

            // Property to store the full answer text
            //will be set in constructor
            public string Value { get; }

            // Constructor: Sets the key and value when created
            public KeyValue(string key, string value)
            {
                Key = key;      // Assign keyword
                Value = value;  // Assign answer
            }

        }
    }
}






