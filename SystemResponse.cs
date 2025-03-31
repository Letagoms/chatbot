using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Part1
{
    public class SystemResponse
    {
        private HashSet<string> filteredWords;

        private Dictionary<string, string> key_words_in_dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void Key()
        {
            // Password - all your original sentences combined
            key_words_in_dictionary.Add("Password",
                "Password security is the practice of securing a password from unauthorized access. " +
                "You can create a strong password by using a combination of letters, numbers and special characters, and by avoiding common words and phrases. " +
                "You can protect your password by keeping it secure and not sharing it with anyone. " +
                "If your password is compromised, change it immediately and report it to the relevant authorities.");

            // Phishing - all your original sentences combined
            key_words_in_dictionary.Add("Phishing",
                "Phishing is the fraudulent attempt to obtain sensitive information such as usernames, passwords and credit card details. " +
                "You can identify phishing by looking out for suspicious emails, websites and requests for sensitive information. " +
                "You can protect yourself from phishing by being cautious of suspicious emails and websites, and by not sharing sensitive information online. " +
                "If you receive a phishing email, do not click on any links or download attachments. Report it to your email provider and delete it immediately.");

            // Safety browsing - all your original sentences combined
            key_words_in_dictionary.Add("safety",
                "You can stay safe online by using secure passwords, keeping your software up to date, and being cautious of suspicious emails and websites. " +
                "You can protect your personal information online by being cautious of what you share online, and by using privacy settings on social media platforms. " +
                "If you encounter a suspicious website, do not enter any personal information. Report it to the relevant authorities and leave the website immediately. " +
                "Safety browsing is the practice of ensuring a safe and secure online browsing experience.");
        }

        public void filered_words()
        {
            filteredWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
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
            /* ENGLISH LOGIC FOR WORD PROCESSING:
           1. Take the question and split it into separate words
           2. For each word in the question:
              a. Clean it by removing ?,!,. etc.
              b. If it's NOT in our ignore list, keep it
           3. Now check each kept word against our knowledge base
              a. If we find a match, return that answer immediately
           4. If no matches found, return a default message
        */

            //Important words are key words similar to the dictionary. so if it's not in the filter or ignore list then this is an important word to take note of.
            List<string> importantWords = new List<string>();
            string[] questions_asked_by_user = user_Question.Split(' ');

            foreach (string word in questions_asked_by_user)
            {
                string trimmed_word = word.Trim();

                //if the words are not in the ignore list then that's when the process is allowed to proceed
                if (!filteredWords.Contains(trimmed_word))
                {
                    //once we're here we now begin to check if the important word is in the dictionary
                    importantWords.Add(trimmed_word);
                }
            }

            //now lets continue checking if the word is in our dictionary
            foreach (string word in importantWords)
            {
                if (key_words_in_dictionary.ContainsKey(word))
                {
                    return key_words_in_dictionary[word];
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "ask something relevant to the topics mentioned above";

        }
    }
}