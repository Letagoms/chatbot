using System.Collections.Generic;


namespace Part1
{
    public class StoreResponses
    {
        private List<string> filteredWords;
        private List<string> negativeWords;
        private List<string> followUpResponses;

        private List<KeyValue> key_words = new List<KeyValue>();
        private List<NegativeResponses> sentiment_method = new List<NegativeResponses>();

        //public access modifiers
        public List<string> FilteredWords => filteredWords;
        public List<string> NegativeWords => negativeWords;
        public List<KeyValue> KeyWords => key_words;
        public List<NegativeResponses> SentimentMethods => sentiment_method;

        public void Key()
        {
            //Password response
            key_words.Add(new KeyValue("password safety",
                "Password safety is the practice of securing a password from unauthorized access. \n" +
                "1. You can create a strong password by using a combination of letters, numbers and special characters, and by avoiding common words and phrases. \n" +
                "2. You can protect your password by keeping it secure and not sharing it with anyone. \n" +
                "3. If your password is compromised, change it immediately and report it to the relevant authorities."));

            //phishing response
            key_words.Add(new KeyValue("phishing",
                "Phishing is the fraudulent attempt to obtain sensitive information such as usernames, passwords and credit card details. \n" +
                "1. You can identify phishing by looking out for suspicious emails, websites and requests for sensitive information. \n" +
                "2. You can protect yourself from phishing by being cautious of suspicious emails and websites, and by not sharing sensitive information online. \n" +
                "3. If you receive a phishing email, do not click on any links or download attachments. Report it to your email provider and delete it immediately."));

            //password safety response
            key_words.Add(new KeyValue("safety browsing",
                "Safety browsing is the practice of ensuring a safe and secure online browsing experience." +
                "1. You can stay safe online by using secure passwords, keeping your software up to date, and being cautious of suspicious emails and websites. \n" +
                "2. You can protect your personal information online by being cautious of what you share online, and by using privacy settings on social media platforms. \n" +
                "3. If you encounter a suspicious website, do not enter any personal information. Report it to the relevant authorities and leave the website immediately. \n"
                ));
        }

        public void negative()
        {
            sentiment_method.Add(new NegativeResponses("phishing", 
                "I understand, phishing can be quite frustrating, however i can help give you tips to prevent yourself from it" +
                "1. You can identify phishing by looking out for suspicious emails, websites and requests for sensitive information. \n" +
                "2. You can protect yourself from phishing by being cautious of suspicious emails and websites, and by not sharing sensitive information online. \n" +
                "3. If you receive a phishing email, do not click on any links or download attachments. Report it to your email provider and delete it immediately."
                ));

            sentiment_method.Add(new NegativeResponses("password",
                "1. You can create a strong password by using a combination of letters, numbers and special characters, and by avoiding common words and phrases. \n" +
                "2. You can protect your password by keeping it secure and not sharing it with anyone. \n" +
                "3. If your password is compromised, change it immediately and report it to the relevant authorities."
                ));

            sentiment_method.Add(new NegativeResponses
                ("safety browsing",
                "1. You can stay safe online by using secure passwords, keeping your software up to date, and being cautious of suspicious emails and websites. \n" +
                "2. You can protect your personal information online by being cautious of what you share online, and by using privacy settings on social media platforms. \n" +
                "3. If you encounter a suspicious website, do not enter any personal information. Report it to the relevant authorities and leave the website immediately. \n"
                ));
        }


        public void filtered_words()
        {
           filteredWords = new List<string>
            {
                "tell", "me", "please", "can", "you", "could", "would","how", "what", "when", "where", "why", "who", "which",
                "give", "show", "explain", "describe", "provide", "list","the", "a", "an", "is", "are", "do", "does", "should",
                "will", "might", "may", "must", "have", "has", "had", "need", "want", "like", "thanks", "thank", "hello", "hi", "hey"
            };
        }
        public void sentiment_words()
        {
            negativeWords = new List<string>
            {
                "bad", "terrible", "sad", "angry", "unhappy", "unsafe", "afraid", "scared", "worried"
            };
        }

        public void follow_up_responses()
        {
            followUpResponses = new List<string>
            {
                "Is there anything else I can help with?",
                "Would you like to know more about digital safety?",
                "Feel free to ask another question.",
                "I’m here to help. Ask me something else."
            };
        }

        public class NegativeResponses
        { 
    
        public string sentiment_word { get; set; }

            public string sentiment_response { get; set; }

            public NegativeResponses (string sentiment, string sentiment_feedback)
            {
                
                sentiment_word = sentiment;
                
                sentiment_response = sentiment_feedback;
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
            
        }
    }
}

//1. you must add random responses
            //2. memory recall for the purpose of using it in the conversation. 
            //perhaps create another arraylist to store words like "interested" to be recoginzed as words of interest
            //3. Sentinment detection
            // again you will probably use the array list to detect the sentiment



